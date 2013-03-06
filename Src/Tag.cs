using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using RT.Util;
using RT.Util.ExtensionMethods;

namespace RT.TagSoup
{
    /// <summary>Abstract base class for an HTML tag.</summary>
    /// <remarks>
    ///     <para>The following types are supported in tag contents:</para>
    ///     <list type="bullet">
    ///         <item><term><c>string</c></term><description>outputs that string (HTML-escaped, of course)</description></item>
    ///         <item><term><c>Tag</c></term><description>outputs that tag and its contents</description></item>
    ///         <item><term><c>IEnumerable&lt;T&gt;</c></term><description>enumerates all contained objects and recursively processes them individually</description></item>
    ///         <item><term><c>Func&lt;T&gt;</c> (or any other delegate with no parameters)</term><description>calls the delegate and recursively processes the return value</description></item>
    ///     </list>
    ///     <para>Using lazy-evaluated IEnumerable&lt;T&gt;s and/or delegates is a convenient way to defer execution to ensure maximally responsive output.</para>
    /// </remarks>
    public abstract class Tag
    {
        /// <summary>Remembers the contents of this tag.</summary>
        private IEnumerable _tagContents = null;

        /// <summary>Constructor.</summary>
        public Tag() { _tagContents = null; }
        /// <summary>Constructor.</summary>
        public Tag(object[] contents) { _tagContents = contents; }
        /// <summary>Constructor.</summary>
        public Tag(IEnumerable contents) { _tagContents = contents; }

        /// <summary>Name of the tag.</summary>
        public abstract string TagName { get; }
        /// <summary>Whether the start tag should be printed. If the tag has attributes, it will be printed regardless.</summary>
        public virtual bool StartTag { get { return true; } }
        /// <summary>Whether the end tag should be printed.</summary>
        public virtual bool EndTag { get { return true; } }

        /// <summary>Creates a simple HTML document from the specified elements.</summary>
        /// <param name="title">Title to use in the &lt;TITLE&gt; tag in the head.</param>
        /// <param name="bodyContent">Contents of the &lt;BODY&gt; tag.</param>
        /// <returns>An <see cref="HtmlTag"/> representing the entire HTML document.</returns>
        public static Tag HtmlDocument(object title, params object[] bodyContent) { return new HTML(new HEAD(new TITLE(title), new META { httpEquiv = "Content-type", content = "text/html; charset=utf-8" }), new BODY(bodyContent)); }

        /// <summary>Special method to help construct an HTML <c>&lt;TABLE&gt;</c> element
        /// without needing to manually instantiate all intermediate row and cell tags.</summary>
        /// <param name="classOnAllTags">If set to a value other than null, causes all rows and cells within the generated table to have the specified CSS class.</param>
        /// <param name="rows">Rows (arrays of cell contents).</param>
        public static Tag HtmlTable(string classOnAllTags, params object[][] rows)
        {
            return new TABLE(rows.Select(row => new TR(row.Select(cell => new TD(cell) { class_ = classOnAllTags })) { class_ = classOnAllTags })) { class_ = classOnAllTags };
        }

        /// <summary>Sets the contents of the tag. Any objects are allowed.</summary>
        /// <param name="contents">Contents to set to.</param>
        /// <returns>The same tag.</returns>
        public Tag _(params object[] contents)
        {
            _tagContents = contents;
            return this;
        }

        /// <summary>Sets the contents of the tag. Any objects are allowed.</summary>
        /// <param name="contents">Contents to set to.</param>
        /// <returns>The same tag.</returns>
        public Tag _(IEnumerable contents)
        {
            _tagContents = contents;
            return this;
        }

        private Dictionary<string, object> _data;

        public Tag Data(string key, object value)
        {
            if (value != null)
                (_data ?? (_data = new Dictionary<string, object>()))[key] = value;
            return this;
        }

        /// <summary>Adds stuff at the end of the contents of this tag (a string, a tag, a collection of strings or of tags).</summary>
        /// <param name="content">The stuff to add.</param>
        public void Add(object content)
        {
            if (_tagContents == null)
                _tagContents = new List<object>();
            else if (!(_tagContents is List<object>))
                _tagContents = _tagContents.Cast<object>().ToList();

            ((List<object>) _tagContents).Add(content);
        }

        /// <summary>Outputs this tag and all its contents.</summary>
        /// <returns>A collection of strings which, when concatenated, represent this tag and all its contents.</returns>
        public virtual IEnumerable<string> ToEnumerable()
        {
            if (StartTag)
                yield return "<" + TagName;
            bool tagPrinted = StartTag;

            foreach (var field in this.GetType().GetFields())
            {
                if (field.Name.StartsWith("_"))
                    continue;
                object val = field.GetValue(this);
                if (val == null) continue;
                if (val is bool && !((bool) val))
                    continue;
                bool isEnum = field.FieldType.IsEnum;
                if (isEnum && (int) val == 0)
                    continue;

                if (!tagPrinted)
                {
                    yield return "<" + TagName;
                    tagPrinted = true;
                }

                yield return " " + fixFieldName(field.Name);
                if (val is bool)
                    continue;
                yield return "=";

                var stringValue =
                    isEnum && field.FieldType.IsDefined<FlagsAttribute>() ? Enum.GetValues(field.FieldType).Cast<object>().Where(v => ((int) v & (int) val) != 0).Select(v => fixFieldName(v.ToString())).JoinString(" ") :
                    isEnum ? fixFieldName(val.ToString()) :
                    val.ToString().HtmlEscape();
                yield return stringValue.Length > 0 && stringValue.All(ch => !char.IsWhiteSpace(ch) && ch != '"' && ch != '\'' && ch != '=' && ch != '<' && ch != '>' && ch != '`') ? stringValue : "\"" + stringValue + "\"";
            }

            if (_data != null)
            {
                foreach (var kvp in _data)
                {
                    for (int i = 0; i < kvp.Key.Length; i++)
                    {
                        var ch = kvp.Key[i];
                        if (ch != '-' && ch != '_' && (ch < '0' || ch > '9') && (ch < 'A' || ch > 'Z') && (ch < 'a' || ch > 'z'))
                            throw new InvalidOperationException("data attribute name cannot contain character “{0}”.".Fmt(ch));
                    }
                    yield return " data-" + kvp.Key + "=\"" + kvp.Value.ToString().HtmlEscape() + "\"";
                }
            }

            var tagIncomplete = tagPrinted;
            foreach (var element in Tag.ToEnumerable(_tagContents))
            {
                if (tagIncomplete)
                {
                    yield return ">";
                    tagIncomplete = false;
                }
                yield return element;
            }

            if (tagIncomplete)
                yield return ">";

            if (EndTag)
                yield return "</" + TagName + ">";
        }

        /// <summary>Converts the entire tag tree into a single string.</summary>
        /// <returns>The entire tag tree as a single string.</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            foreach (string s in ToEnumerable())
                sb.Append(s);
            return sb.ToString();
        }

        /// <summary>Converts a tag tree into a single string.</summary>
        /// <returns>The entire tag tree as a single string.</returns>
        public static string ToString(object tagTree)
        {
            var sb = new StringBuilder();
            foreach (string s in ToEnumerable(tagTree))
                sb.Append(s);
            return sb.ToString();
        }

        /// <summary>Converts a tag tree into a raw tag which would render exactly the same as the tag tree.</summary>
        public static RawTag ToRaw(object tagTree)
        {
            return new RawTag(ToString(tagTree));
        }

        /// <summary>Converts a tag tree into a raw tag which would render exactly the same as the tag tree.</summary>
        public static RawTag ToRaw(params object[] tagTree)
        {
            return new RawTag(ToString(tagTree));
        }

        /// <summary>Converts a tag tree into a string that is generated bit by bit.</summary>
        /// <returns>A collection that generates the entire tag tree as a string.</returns>
        public static IEnumerable<string> ToEnumerable(object tagTree)
        {
            if (tagTree == null)
                return Enumerable.Empty<string>();

            if (tagTree is string)
                return new[] { ((string) tagTree).HtmlEscape() };

            if (tagTree is IEnumerable<string>)
                return ((IEnumerable<string>) tagTree).Select(s => s.HtmlEscape());

            if (tagTree is Tag)
                return ((Tag) tagTree).ToEnumerable();

            if (tagTree is IEnumerable)
                return ((IEnumerable) tagTree).Cast<object>().SelectMany(ToEnumerable);

            if (tagTree is Delegate && ((Delegate) tagTree).Method.GetParameters().Length == 0)
                return ToEnumerable(((Delegate) tagTree).DynamicInvoke(null));

            return new[] { tagTree.ToString().HtmlEscape() };
        }

        /// <summary>Converts a C#-compatible field name into an HTML/XHTML-compatible one.</summary>
        /// <example>
        ///     <list type="bullet">
        ///         <item><c>class_</c> is converted to <c>"class"</c></item>
        ///         <item><c>acceptCharset</c> is converted to <c>"accept-charset"</c></item>
        ///         <item><c>text_plain</c> is converted to <c>"text/plain"</c></item>
        ///         <item><c>_</c> would be converted to the empty string, but <see cref="ToEnumerable"/> already skips those.</item>
        ///     </list>
        /// </example>
        /// <param name="fieldName">Field name to convert.</param>
        /// <returns>Converted field name.</returns>
        private static string fixFieldName(string fieldName)
        {
            var sb = new StringBuilder(fieldName.Length);
            for (int i = 0; i < fieldName.Length; i++)
                if (fieldName[i] >= 'A' && fieldName[i] <= 'Z')
                    sb.Append("-" + char.ToLowerInvariant(fieldName[i]));
                else if (fieldName[i] != '_')
                    sb.Append(fieldName[i]);
                else if (i < fieldName.Length - 1)
                    sb.Append('/');
            return sb.ToString();
        }

        /// <summary>Creates a new file and outputs this tag and all its contents to it.</summary>
        /// <param name="filename">The path and filename of the file to create. If the file already exists, it will be overwritten.</param>
        public void WriteToFile(string filename)
        {
            using (var f = File.Open(filename, FileMode.Create, FileAccess.Write, FileShare.Write))
            using (var t = new StreamWriter(f))
            {
                foreach (var str in ToEnumerable())
                    t.Write(str);
            }
        }
    }

    /// <summary>
    /// Outputs whatever content is passed to it without any escaping. Do not use unless there's absolutely no other way of doing something.
    /// </summary>
    public sealed class RawTag : Tag
    {
        private string _value;
        /// <summary>Constructor.</summary>
        public RawTag(string value_) { _value = value_; }
        /// <summary>Throws the not implemented exception.</summary>
        public override string TagName { get { throw new NotImplementedException(); } }
        /// <summary>Enumerates the content.</summary>
        public override IEnumerable<string> ToEnumerable() { yield return _value; }
        /// <summary>Returns the content.</summary>
        public override string ToString() { return _value; }
    }
}
