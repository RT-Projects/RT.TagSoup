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
    /// <summary>Abstract base class for an HTML or XHTML tag.</summary>
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
        /// <summary>DOCTYPE that is output before the tag. Only used by the &lt;HTML&gt; HTML tag and the &lt;html&gt; XHTML tag.</summary>
        public virtual string DocType { get { return null; } }
        /// <summary>Whether the start tag should be printed. If the tag has attributes, it will be printed regardless.</summary>
        public virtual bool StartTag { get { return true; } }
        /// <summary>Whether the end tag should be printed.</summary>
        public virtual bool EndTag { get { return true; } }
        /// <summary>Whether XHTML-style &lt;/&gt; empty-tag markers are allowed.</summary>
        public abstract bool AllowXhtmlEmpty { get; }

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
            if (!(_tagContents is List<object>))
                _tagContents = _tagContents.Cast<object>().ToList();

            ((List<object>) _tagContents).Add(content);
        }

        /// <summary>Outputs this tag and all its contents.</summary>
        /// <returns>A collection of strings which, when concatenated, represent this tag and all its contents.</returns>
        public virtual IEnumerable<string> ToEnumerable()
        {
            if (DocType != null)
                yield return DocType;

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
            Exception toThrow = null;
            IEnumerator<string> enumerator = null;
            try { enumerator = Tag.ToEnumerable(_tagContents).GetEnumerator(); }
            catch (Exception e) { toThrow = e; }
            while (toThrow == null)
            {
                try
                {
                    if (!enumerator.MoveNext())
                        break;
                }
                catch (Exception e)
                {
                    toThrow = e;
                    break;
                }

                if (tagIncomplete)
                {
                    yield return ">";
                    tagIncomplete = false;
                }
                yield return enumerator.Current;
            }

            if (tagIncomplete && AllowXhtmlEmpty && EndTag)
            {
                yield return "/>";
                yield break;
            }
            else if (tagIncomplete)
                yield return ">";

            if (EndTag)
                yield return "</" + TagName + ">";

            if (toThrow != null)
                throw new TagSoupDeferredException(toThrow);
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

        /// <summary>Converts a tag tree into a string that is generated bit by bit.</summary>
        /// <returns>A collection that generates the entire tag tree as a string.</returns>
        public static IEnumerable<string> ToEnumerable(object tagTree)
        {
            if (tagTree == null)
                return Enumerable.Empty<string>();

            if (tagTree is string)
                return new[] { ((string) tagTree).HtmlEscape() };

            if (tagTree is IEnumerable<string>)
                return ((IEnumerable<string>) tagTree).Select(StringExtensions.HtmlEscape);

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
        ///         <item><c>accept_charset</c> is converted to <c>"accept-charset"</c></item>
        ///         <item><c>xmlLang</c> is converted to <c>"xml:lang"</c></item>
        ///         <item><c>_</c> would be converted to the empty string, but <see cref="ToEnumerable"/> already skips those.</item>
        ///     </list>
        /// </example>
        /// <param name="fn">Field name to convert.</param>
        /// <returns>Converted field name.</returns>
        private static string fixFieldName(string fn)
        {
            var sb = new StringBuilder(fn.Length);
            for (int i = 0; i < fn.Length; i++)
                if (fn[i] >= 'A' && fn[i] <= 'Z')
                    sb.Append("-" + char.ToLowerInvariant(fn[i]));
                else if (fn[i] != '_')
                    sb.Append(fn[i]);
                else if (i < fn.Length - 1)
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
    /// Used by <see cref="TagSoup"/> to defer exceptions until after the output of the entire tag tree is complete.
    /// </summary>
    public sealed class TagSoupDeferredException : Exception
    {
        /// <summary>Constructor.</summary>
        public TagSoupDeferredException(Exception inner) : base(null, inner) { }
    }
}
