using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;

namespace RT.TagSoup
{
    /// <summary>
    ///     Abstract base class for an HTML tag.</summary>
    /// <remarks>
    ///     <para>
    ///         The following types are supported in tag contents:</para>
    ///     <list type="bullet">
    ///         <item><term>
    ///             <c>string</c></term>
    ///         <description>
    ///             outputs that string (HTML-escaped, of course)</description></item>
    ///         <item><term>
    ///             <c>Tag</c></term>
    ///         <description>
    ///             outputs that tag and its contents</description></item>
    ///         <item><term>
    ///             <c>IEnumerable&lt;T&gt;</c></term>
    ///         <description>
    ///             enumerates all contained objects and recursively processes them individually</description></item>
    ///         <item><term>
    ///             <c>Func&lt;T&gt;</c> (or any other delegate with no parameters)</term>
    ///         <description>
    ///             calls the delegate and recursively processes the return value</description></item></list>
    ///     <para>
    ///         Using lazy-evaluated IEnumerable&lt;T&gt;s and/or delegates is a convenient way to defer execution to ensure
    ///         maximally responsive output.</para></remarks>
    public abstract class Tag
    {
        /// <summary>Remembers the contents of this tag.</summary>
        private IEnumerable _tagContents = null;

        /// <summary>Constructor.</summary>
        public Tag() { _tagContents = null; }
        /// <summary>Constructor.</summary>
        public Tag(object[] contents) : this() { _tagContents = contents; }
        /// <summary>Constructor.</summary>
        public Tag(IEnumerable contents) : this() { _tagContents = contents; }

        /// <summary>Name of the tag.</summary>
        public abstract string TagName { get; }
        /// <summary>Whether the start tag should be printed. If the tag has attributes, it will be printed regardless.</summary>
        public virtual bool StartTag { get { return true; } }
        /// <summary>Whether the end tag should be printed.</summary>
        public virtual bool EndTag { get { return true; } }

        /// <summary>
        ///     Creates a simple HTML document from the specified elements.</summary>
        /// <param name="title">
        ///     Title to use in the &lt;TITLE&gt; tag in the head.</param>
        /// <param name="bodyContent">
        ///     Contents of the &lt;BODY&gt; tag.</param>
        /// <returns>
        ///     An <see cref="HtmlTag"/> representing the entire HTML document.</returns>
        public static Tag HtmlDocument(object title, params object[] bodyContent) { return new HTML(new HEAD(new TITLE(title), new META { httpEquiv = "Content-type", content = "text/html; charset=utf-8" }), new BODY(bodyContent)); }

        /// <summary>
        ///     Special method to help construct an HTML <c>&lt;TABLE&gt;</c> element without needing to manually instantiate
        ///     all intermediate row and cell tags.</summary>
        /// <param name="classOnAllTags">
        ///     If set to a value other than null, causes all rows and cells within the generated table to have the specified
        ///     CSS class.</param>
        /// <param name="rows">
        ///     Rows (arrays of cell contents).</param>
        public static Tag HtmlTable(string classOnAllTags, params object[][] rows)
        {
            return new TABLE(rows.Select(row => new TR(row.Select(cell => new TD(cell) { class_ = classOnAllTags })) { class_ = classOnAllTags })) { class_ = classOnAllTags };
        }

        /// <summary>
        ///     Sets the contents of the tag. Any objects are allowed.</summary>
        /// <param name="contents">
        ///     Contents to set to.</param>
        /// <returns>
        ///     The same tag.</returns>
        public Tag _(params object[] contents)
        {
            _tagContents = contents;
            return this;
        }

        /// <summary>
        ///     Sets the contents of the tag using lazy evaluation.</summary>
        /// <param name="contents">
        ///     Contents to set to.</param>
        /// <returns>
        ///     The same tag.</returns>
        public Tag _(params Func<object>[] contents)
        {
            _tagContents = contents;
            return this;
        }

        /// <summary>
        ///     Sets the contents of the tag. Any objects are allowed.</summary>
        /// <param name="contents">
        ///     Contents to set to.</param>
        /// <returns>
        ///     The same tag.</returns>
        public Tag _(IEnumerable contents)
        {
            _tagContents = contents;
            return this;
        }

        private Dictionary<string, object> _data;

        /// <summary>
        ///     Specifies a <c>data</c> attribute for this tag.</summary>
        /// <param name="key">
        ///     The key. For example, if you pass in <c>name</c> here, the attribute will be <c>data-name="..."</c>.</param>
        /// <param name="value">
        ///     The value for the data attribute.</param>
        /// <returns>
        ///     The same tag.</returns>
        public Tag Data(string key, object value)
        {
            if (value != null)
                (_data ?? (_data = new Dictionary<string, object>()))[key] = value;
            return this;
        }

        /// <summary>
        ///     Adds stuff at the end of the contents of this tag (a string, a tag, a collection of strings or of tags).</summary>
        /// <param name="content">
        ///     The stuff to add.</param>
        public void Add(object content)
        {
            if (_tagContents == null)
                _tagContents = new List<object>();
            else if (!(_tagContents is List<object>))
                _tagContents = _tagContents.Cast<object>().ToList();

            ((List<object>) _tagContents).Add(content);
        }

        /// <summary>
        ///     Outputs this tag and all its contents.</summary>
        /// <param name="allTags">
        ///     The HTML specification allows certain start and end tags to be omitted. Specify <c>true</c> to emit such tags
        ///     regardless, for compatibility reasons.</param>
        /// <returns>
        ///     A collection of strings which, when concatenated, represent this tag and all its contents.</returns>
        public virtual IEnumerable<string> ToEnumerable(bool allTags = false)
        {
            var tagPrinted = false;
            if (StartTag || allTags || (_data != null && _data.Count > 0))
            {
                yield return "<" + TagName;
                tagPrinted = true;
            }

            var attrs = enumerateAttributes();
            if (attrs != null)
                foreach (var str in attrs)
                {
                    if (!tagPrinted)
                    {
                        yield return "<" + TagName;
                        tagPrinted = true;
                    }
                    yield return str;
                }

            if (_data != null)
            {
                foreach (var kvp in _data)
                {
                    for (int i = 0; i < kvp.Key.Length; i++)
                    {
                        var ch = kvp.Key[i];
                        if (ch != '-' && ch != '_' && (ch < '0' || ch > '9') && (ch < 'A' || ch > 'Z') && (ch < 'a' || ch > 'z'))
                            throw new InvalidOperationException(string.Format("data attribute name cannot contain character “{0}”.", ch));
                    }
                    yield return " data-" + kvp.Key + "=" + attributeValue(kvp.Value.ToString());
                }
            }

            if (tagPrinted)
                yield return ">";

            foreach (var element in Tag.ToEnumerable(_tagContents, allTags))
                yield return element;

            if (EndTag || allTags)
                yield return "</" + TagName + ">";
        }

        /// <summary>Stringifies the attributes on this tag.</summary>
        abstract protected IEnumerable<string> enumerateAttributes();

        /// <summary>
        ///     Helper method to safely stringify an attribute value.</summary>
        /// <param name="attrVal">
        ///     Attribute value to stringify.</param>
        protected static string attributeValue(string attrVal)
        {
            if (attrVal.Length == 0)
                return "''";
            if (attrVal.All(ch => !char.IsWhiteSpace(ch) && ch != '"' && ch != '\'' && ch != '=' && ch != '<' && ch != '>' && ch != '`'))
                return attrVal;
            if (attrVal.All(ch => ch != '\''))
                return "'" + attrVal.HtmlEscape(leaveDoubleQuotesAlone: true) + "'";
            return "\"" + attrVal.HtmlEscape(leaveSingleQuotesAlone: true) + "\"";
        }

        /// <summary>
        ///     Converts the entire tag tree into a single string.</summary>
        /// <returns>
        ///     The entire tag tree as a single string.</returns>
        public override string ToString()
        {
            return ToString(false);
        }

        /// <summary>
        ///     Converts the entire tag tree into a single string.</summary>
        /// <param name="allTags">
        ///     The HTML specification allows certain start and end tags to be omitted. Specify <c>true</c> to emit such tags
        ///     regardless, for compatibility reasons.</param>
        /// <returns>
        ///     The entire tag tree as a single string.</returns>
        public string ToString(bool allTags)
        {
            var sb = new StringBuilder();
            foreach (string s in ToEnumerable(allTags))
                sb.Append(s);
            return sb.ToString();
        }

        /// <summary>
        ///     Converts a tag tree into a single string.</summary>
        /// <param name="tagTree">
        ///     The tag tree to convert.</param>
        /// <param name="allTags">
        ///     The HTML specification allows certain start and end tags to be omitted. Specify <c>true</c> to emit such tags
        ///     regardless, for compatibility reasons.</param>
        /// <returns>
        ///     The entire tag tree as a single string.</returns>
        public static string ToString(object tagTree, bool allTags = false)
        {
            var sb = new StringBuilder();
            foreach (string s in ToEnumerable(tagTree, allTags))
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

        /// <summary>
        ///     Converts a tag tree into a string that is generated bit by bit.</summary>
        /// <param name="tagTree">
        ///     The tag tree to convert.</param>
        /// <param name="allTags">
        ///     The HTML specification allows certain start and end tags to be omitted. Specify <c>true</c> to emit such tags
        ///     regardless, for compatibility reasons.</param>
        /// <returns>
        ///     A collection that generates the entire tag tree as a string.</returns>
        public static IEnumerable<string> ToEnumerable(object tagTree, bool allTags = false)
        {
            if (tagTree == null)
                return Enumerable.Empty<string>();

            if (tagTree is string)
                return new[] { ((string) tagTree).HtmlEscape() };

            if (tagTree is IEnumerable<string>)
                return ((IEnumerable<string>) tagTree).Select(s => s.HtmlEscape());

            if (tagTree is Tag)
                return ((Tag) tagTree).ToEnumerable(allTags);

            if (tagTree is IEnumerable)
                return ((IEnumerable) tagTree).Cast<object>().SelectMany(t => ToEnumerable(t, allTags));

            if (tagTree is Func<object> || (tagTree is Delegate && ((Delegate) tagTree).Method.GetParameters().Length == 0))
                return ToEnumerable(((Delegate) tagTree).DynamicInvoke(null), allTags);

            return new[] { tagTree.ToString().HtmlEscape() };
        }

        /// <summary>
        ///     Creates a new file and outputs this tag and all its contents to it.</summary>
        /// <param name="filename">
        ///     The path and filename of the file to create. If the file already exists, it will be overwritten.</param>
        /// <param name="allTags">
        ///     The HTML specification allows certain start and end tags to be omitted. Specify <c>true</c> to emit such tags
        ///     regardless, for compatibility reasons.</param>
        public void WriteToFile(string filename, bool allTags = false)
        {
            using (var f = File.Open(filename, FileMode.Create, FileAccess.Write, FileShare.Write))
            using (var t = new StreamWriter(f))
            {
                foreach (var str in ToEnumerable(allTags))
                    t.Write(str);
            }
        }
    }

    /// <summary>
    ///     Outputs whatever content is passed to it without any escaping. Do not use unless there's absolutely no other way
    ///     of doing something.</summary>
    public sealed class RawTag : Tag
    {
        private readonly string _value;
        /// <summary>Constructor.</summary>
        public RawTag(string value_) { _value = value_; }
        /// <summary>Throws NotImplementedException.</summary>
        public override string TagName { get { throw new NotImplementedException(); } }
        /// <summary>
        ///     Enumerates the content.</summary>
        /// <param name="allTags">
        ///     The HTML specification allows certain start and end tags to be omitted. Specify <c>true</c> to emit such tags
        ///     regardless, for compatibility reasons.</param>
        public override IEnumerable<string> ToEnumerable(bool allTags = false) { yield return _value; }
        /// <summary>Returns the content.</summary>
        public override string ToString() { return _value; }
        /// <summary>Throws NotImplementedException.</summary>
        protected override IEnumerable<string> enumerateAttributes() { throw new NotImplementedException(); }
    }

    static class GenerateCode
    {
        public static void Do(string htmlCsPath)
        {
            var exclude = "SCRIPTLiteral,STYLELiteral".Split(',');
            var keywords = "abstract,as,base,bool,break,byte,case,catch,char,checked,class,const,continue,decimal,default,delegate,do,double,else,enum,event,explicit,extern,false,finally,fixed,float,for,foreach,goto,if,implicit,in,int,interface,internal,is,lock,long,namespace,new,null,object,operator,out,override,params,private,protected,public,readonly,ref,return,sbyte,sealed,short,sizeof,stackalloc,static,string,struct,switch,this,throw,true,try,typeof,uint,ulong,unchecked,unsafe,ushort,using,var,virtual,void,volatile,while".Split(',');
            ReplaceInFile(htmlCsPath, @"/* HTML tags generated code START */", @"/* HTML tags generated code END */",
                typeof(A).Assembly.GetTypes().Where(t => typeof(HtmlTag).IsAssignableFrom(t) && !t.IsAbstract && !exclude.Contains(t.Name)).Select(t =>
                {
                    var fields = t.GetFields(BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly).Where(f => f.DeclaringType == t);
                    return $@"
    public sealed class {t.Name} : HtmlTag
    {{
        public {t.Name}() : base() {{ }}
        public {t.Name}(params object[] contents) : base(contents) {{ }}
        public override string TagName {{ get {{ return ""{t.Name.ToLowerInvariant()}""; }} }}{
(((Tag) Activator.CreateInstance(t)).StartTag ? "" : "\r\n        public override bool StartTag { get { return false; } }")}{
(((Tag) Activator.CreateInstance(t)).EndTag ? "" : "\r\n        public override bool EndTag { get { return false; } }")}{
fields.Select(f => $"\r\n        public {typeName(f.FieldType)} {f.Name}{(keywords.Contains(f.Name) ? "_" : null)};").JoinString()}{
(t.Name == "HTML" ? @"
        public override IEnumerable<string> ToEnumerable(bool allTags = false)
        {
            yield return ""<!DOCTYPE html>"";
            foreach (var item in base.ToEnumerable(allTags))
                yield return item;
        }" : "")}
        {GenerateEnumerateAttributesMethod(fields, callBase: true).Indent("        ".Length, indentFirstLine: false)}
    }}";
                }).JoinString());
            ReplaceInFile(htmlCsPath, @"/* HtmlTag generated code START */", @"/* HtmlTag generated code END */",
                GenerateEnumerateAttributesMethod(typeof(HtmlTag).GetFields(BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly).Where(f => f.DeclaringType == typeof(HtmlTag)), callBase: false));
        }

        private static string GenerateEnumerateAttributesMethod(IEnumerable<FieldInfo> fields, bool callBase)
        {
            return $@"/// <summary>Stringifies the attributes on this tag.</summary>
protected override IEnumerable<string> enumerateAttributes()
{{
    {(!fields.Any() && !callBase ? "return null;" : fields.Select(f =>
            {
                if (f.FieldType == typeof(bool))
                    return $@"if ({f.Name}) yield return "" {fixFieldName(f.Name)}"";";
                if (f.FieldType.IsEnum && f.FieldType.IsDefined<FlagsAttribute>())
                    return $@"if ({f.Name} != 0)
    {{
        var str = """";
        {Enum.GetValues(f.FieldType).Cast<object>().Where(v => (int) v != 0).Select(v => $@"if (({f.Name} & {f.FieldType.Name}.{v}) != 0) {{ if (str.Length > 0) str += "" ""; str += ""{fixFieldName(v.ToString())}""; }}").JoinString("\r\n        ")}
        yield return "" {fixFieldName(f.Name)}="" + attributeValue(str);
    }}";
                if (f.FieldType.IsEnum)
                    return $@"switch ({f.Name}) {{ {Enum.GetValues(f.FieldType).Cast<object>().Where(v => (int) v != 0).Select(v => $@"case {f.FieldType.Name}.{v}: yield return "" {fixFieldName(f.Name)}={fixFieldName(v.ToString())}""; break;").JoinString(" ")} }}";
                if (f.FieldType == typeof(double))
                    return $@"yield return "" {fixFieldName(f.Name)}=""; yield return attributeValue({f.Name}.ToString());";
                return $@"if ({f.Name} != null) {{ yield return "" {fixFieldName(f.Name)}=""; yield return attributeValue({f.Name}{(f.FieldType == typeof(string) ? null : ".ToString()")}); }}";
            }).JoinString("\r\n    "))}{
    (callBase ? @"
    var baseAttrs = base.enumerateAttributes();
    if (baseAttrs != null)
        foreach (var obj in baseAttrs)
            yield return obj;" : null)}
}}";
        }

        /// <summary>
        ///     Inserts spaces at the beginning of every line contained within the specified string.</summary>
        /// <param name="str">
        ///     String to add indentation to.</param>
        /// <param name="by">
        ///     Number of spaces to add.</param>
        /// <param name="indentFirstLine">
        ///     If true (default), all lines are indented; otherwise, all lines except the first.</param>
        /// <returns>
        ///     The indented string.</returns>
        private static string Indent(this string str, int by, bool indentFirstLine = true)
        {
            if (indentFirstLine)
                return Regex.Replace(str, "^", new string(' ', by), RegexOptions.Multiline);
            return Regex.Replace(str, "(?<=\n)", new string(' ', by));
        }

        /// <summary>
        ///     Removes the overall indentation of the specified string while maintaining the relative indentation of each
        ///     line.</summary>
        /// <param name="str">
        ///     String to remove indentation from.</param>
        /// <returns>
        ///     A string in which every line that isn’t all whitespace has had spaces removed from the beginning equal to the
        ///     least amount of spaces at the beginning of any line.</returns>
        private static string Unindent(this string str)
        {
            var least = Regex.Matches(str, @"^( *)(?![\r\n ]|\z)", RegexOptions.Multiline).Cast<Match>().Min(m => m.Groups[1].Length);
            return least == 0 ? str : Regex.Replace(str, "^" + new string(' ', least), "", RegexOptions.Multiline);
        }

        /// <summary>
        ///     Converts a C#-compatible field name into an HTML/XHTML-compatible one.</summary>
        /// <example>
        ///     <list type="bullet">
        ///         <item><c>class_</c> is converted to <c>"class"</c></item>
        ///         <item><c>acceptCharset</c> is converted to <c>"accept-charset"</c></item>
        ///         <item><c>text_plain</c> is converted to <c>"text/plain"</c></item>
        ///         <item><c>_</c> would be converted to the empty string, but <see cref="ToEnumerable(bool)"/> already skips
        ///         those.</item></list></example>
        /// <param name="fieldName">
        ///     Field name to convert.</param>
        /// <returns>
        ///     Converted field name.</returns>
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

        private static string typeName(Type type)
        {
            if (type.IsGenericType && type.GetGenericTypeDefinition() == typeof(Nullable<>))
                return typeName(type.GenericTypeArguments[0]) + "?";
            if (type.IsArray)
                return typeName(type.GetElementType()) + "[]";
            if (type == typeof(double))
                return "double";
            if (type == typeof(string))
                return "string";
            if (type == typeof(int))
                return "int";
            if (type == typeof(bool))
                return "bool";
            return type.Name;
        }

        private static void ReplaceInFile(string path, string startMarker, string endMarker, string newText)
        {
            File.WriteAllText(path, Regex.Replace(File.ReadAllText(path), $@"(?<={Regex.Escape(startMarker)})(\r?\n)*( *).*?(\r?\n *)?(?={Regex.Escape(endMarker)})", m => m.Groups[1].Value + newText.Unindent().Indent(m.Groups[2].Length) + m.Groups[3].Value, RegexOptions.Singleline));
        }

        /// <summary>
        ///     Turns all elements in the enumerable to strings and joins them using the specified <paramref
        ///     name="separator"/> and the specified <paramref name="prefix"/> and <paramref name="suffix"/> for each string.</summary>
        /// <param name="values">
        ///     The sequence of elements to join into a string.</param>
        /// <param name="separator">
        ///     Optionally, a separator to insert between each element and the next.</param>
        /// <param name="prefix">
        ///     Optionally, a string to insert in front of each element.</param>
        /// <param name="suffix">
        ///     Optionally, a string to insert after each element.</param>
        /// <param name="lastSeparator">
        ///     Optionally, a separator to use between the second-to-last and the last element.</param>
        /// <example>
        ///     <code>
        ///         // Returns "[Paris], [London], [Tokyo]"
        ///         (new[] { "Paris", "London", "Tokyo" }).JoinString(", ", "[", "]")
        ///         
        ///         // Returns "[Paris], [London] and [Tokyo]"
        ///         (new[] { "Paris", "London", "Tokyo" }).JoinString(", ", "[", "]", " and ");</code></example>
        private static string JoinString<T>(this IEnumerable<T> values, string separator = null, string prefix = null, string suffix = null, string lastSeparator = null)
        {
            if (values == null)
                throw new ArgumentNullException("values");
            if (lastSeparator == null)
                lastSeparator = separator;

            using (var enumerator = values.GetEnumerator())
            {
                if (!enumerator.MoveNext())
                    return "";

                // Optimise the case where there is only one element
                var one = enumerator.Current;
                if (!enumerator.MoveNext())
                    return prefix + one + suffix;

                // Optimise the case where there are only two elements
                var two = enumerator.Current;
                if (!enumerator.MoveNext())
                {
                    // Optimise the (common) case where there is no prefix/suffix; this prevents an array allocation when calling string.Concat()
                    if (prefix == null && suffix == null)
                        return one + lastSeparator + two;
                    return prefix + one + suffix + lastSeparator + prefix + two + suffix;
                }

                StringBuilder sb = new StringBuilder()
                    .Append(prefix).Append(one).Append(suffix).Append(separator)
                    .Append(prefix).Append(two).Append(suffix);
                var prev = enumerator.Current;
                while (enumerator.MoveNext())
                {
                    sb.Append(separator).Append(prefix).Append(prev).Append(suffix);
                    prev = enumerator.Current;
                }
                sb.Append(lastSeparator).Append(prefix).Append(prev).Append(suffix);
                return sb.ToString();
            }
        }
    }
}
