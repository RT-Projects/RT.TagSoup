using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace RT.TagSoup
{
    /// <summary>
    ///     Abstract base class for HTML tags.</summary>
    /// <remarks>
    ///     Useful reference: http://simon.html5.org/html-elements</remarks>
    public abstract class HtmlTag : Tag
    {
        /* HtmlTag generated code START */
        /// <summary>Stringifies the attributes on this tag.</summary>
        protected override IEnumerable<string> enumerateAttributes()
        {
            if (accesskey != null) { yield return " accesskey="; yield return attributeValue(accesskey); }
            if (class_ != null) { yield return " class="; yield return attributeValue(class_); }
            switch (contenteditable) { case truefalse.true_: yield return " contenteditable=true"; break; case truefalse.false_: yield return " contenteditable=false"; break; }
            if (contextmenu != null) { yield return " contextmenu="; yield return attributeValue(contextmenu); }
            switch (dir) { case dir.ltr: yield return " dir=ltr"; break; case dir.rtl: yield return " dir=rtl"; break; case dir.auto: yield return " dir=auto"; break; }
            switch (draggable) { case truefalse.true_: yield return " draggable=true"; break; case truefalse.false_: yield return " draggable=false"; break; }
            switch (dropzone) { case dropzone.copy: yield return " dropzone=copy"; break; case dropzone.move: yield return " dropzone=move"; break; case dropzone.link: yield return " dropzone=link"; break; }
            if (hidden) yield return " hidden";
            if (id != null) { yield return " id="; yield return attributeValue(id); }
            if (itemid != null) { yield return " itemid="; yield return attributeValue(itemid); }
            if (itemprop != null) { yield return " itemprop="; yield return attributeValue(itemprop); }
            if (itemref != null) { yield return " itemref="; yield return attributeValue(itemref); }
            if (itemscope) yield return " itemscope";
            if (itemtype != null) { yield return " itemtype="; yield return attributeValue(itemtype); }
            if (lang != null) { yield return " lang="; yield return attributeValue(lang); }
            switch (spellcheck) { case truefalse.true_: yield return " spellcheck=true"; break; case truefalse.false_: yield return " spellcheck=false"; break; }
            if (style != null) { yield return " style="; yield return attributeValue(style); }
            if (tabindex != null) { yield return " tabindex="; yield return attributeValue(tabindex.ToString()); }
            if (title != null) { yield return " title="; yield return attributeValue(title); }
            if (onabort != null) { yield return " onabort="; yield return attributeValue(onabort); }
            if (onblur != null) { yield return " onblur="; yield return attributeValue(onblur); }
            if (oncanplay != null) { yield return " oncanplay="; yield return attributeValue(oncanplay); }
            if (oncanplaythrough != null) { yield return " oncanplaythrough="; yield return attributeValue(oncanplaythrough); }
            if (onchange != null) { yield return " onchange="; yield return attributeValue(onchange); }
            if (onclick != null) { yield return " onclick="; yield return attributeValue(onclick); }
            if (oncontextmenu != null) { yield return " oncontextmenu="; yield return attributeValue(oncontextmenu); }
            if (ondblclick != null) { yield return " ondblclick="; yield return attributeValue(ondblclick); }
            if (ondrag != null) { yield return " ondrag="; yield return attributeValue(ondrag); }
            if (ondragend != null) { yield return " ondragend="; yield return attributeValue(ondragend); }
            if (ondragenter != null) { yield return " ondragenter="; yield return attributeValue(ondragenter); }
            if (ondragleave != null) { yield return " ondragleave="; yield return attributeValue(ondragleave); }
            if (ondragover != null) { yield return " ondragover="; yield return attributeValue(ondragover); }
            if (ondragstart != null) { yield return " ondragstart="; yield return attributeValue(ondragstart); }
            if (ondrop != null) { yield return " ondrop="; yield return attributeValue(ondrop); }
            if (ondurationchange != null) { yield return " ondurationchange="; yield return attributeValue(ondurationchange); }
            if (onemptied != null) { yield return " onemptied="; yield return attributeValue(onemptied); }
            if (onended != null) { yield return " onended="; yield return attributeValue(onended); }
            if (onerror != null) { yield return " onerror="; yield return attributeValue(onerror); }
            if (onfocus != null) { yield return " onfocus="; yield return attributeValue(onfocus); }
            if (onformchange != null) { yield return " onformchange="; yield return attributeValue(onformchange); }
            if (onforminput != null) { yield return " onforminput="; yield return attributeValue(onforminput); }
            if (oninput != null) { yield return " oninput="; yield return attributeValue(oninput); }
            if (oninvalid != null) { yield return " oninvalid="; yield return attributeValue(oninvalid); }
            if (onkeydown != null) { yield return " onkeydown="; yield return attributeValue(onkeydown); }
            if (onkeypress != null) { yield return " onkeypress="; yield return attributeValue(onkeypress); }
            if (onkeyup != null) { yield return " onkeyup="; yield return attributeValue(onkeyup); }
            if (onload != null) { yield return " onload="; yield return attributeValue(onload); }
            if (onloadeddata != null) { yield return " onloadeddata="; yield return attributeValue(onloadeddata); }
            if (onloadedmetadata != null) { yield return " onloadedmetadata="; yield return attributeValue(onloadedmetadata); }
            if (onloadstart != null) { yield return " onloadstart="; yield return attributeValue(onloadstart); }
            if (onmousedown != null) { yield return " onmousedown="; yield return attributeValue(onmousedown); }
            if (onmousemove != null) { yield return " onmousemove="; yield return attributeValue(onmousemove); }
            if (onmouseout != null) { yield return " onmouseout="; yield return attributeValue(onmouseout); }
            if (onmouseover != null) { yield return " onmouseover="; yield return attributeValue(onmouseover); }
            if (onmouseup != null) { yield return " onmouseup="; yield return attributeValue(onmouseup); }
            if (onmousewheel != null) { yield return " onmousewheel="; yield return attributeValue(onmousewheel); }
            if (onpause != null) { yield return " onpause="; yield return attributeValue(onpause); }
            if (onplay != null) { yield return " onplay="; yield return attributeValue(onplay); }
            if (onplaying != null) { yield return " onplaying="; yield return attributeValue(onplaying); }
            if (onprogress != null) { yield return " onprogress="; yield return attributeValue(onprogress); }
            if (onratechange != null) { yield return " onratechange="; yield return attributeValue(onratechange); }
            if (onreset != null) { yield return " onreset="; yield return attributeValue(onreset); }
            if (onreadystatechange != null) { yield return " onreadystatechange="; yield return attributeValue(onreadystatechange); }
            if (onseeked != null) { yield return " onseeked="; yield return attributeValue(onseeked); }
            if (onseeking != null) { yield return " onseeking="; yield return attributeValue(onseeking); }
            if (onselect != null) { yield return " onselect="; yield return attributeValue(onselect); }
            if (onshow != null) { yield return " onshow="; yield return attributeValue(onshow); }
            if (onstalled != null) { yield return " onstalled="; yield return attributeValue(onstalled); }
            if (onsubmit != null) { yield return " onsubmit="; yield return attributeValue(onsubmit); }
            if (onsuspend != null) { yield return " onsuspend="; yield return attributeValue(onsuspend); }
            if (ontimeupdate != null) { yield return " ontimeupdate="; yield return attributeValue(ontimeupdate); }
            if (onvolumechange != null) { yield return " onvolumechange="; yield return attributeValue(onvolumechange); }
            if (onwaiting != null) { yield return " onwaiting="; yield return attributeValue(onwaiting); }
        }
        /* HtmlTag generated code END */

        /// <summary>Constructor.</summary>
        public HtmlTag() : base() { }
        /// <summary>Constructor.</summary>
        public HtmlTag(params object[] contents) : base(contents) { }

#pragma warning disable 1591    // Missing XML comment for publicly visible type or member

        // Attributes common to all HTML tags
        public string accesskey;
        public string class_;
        public truefalse contenteditable;
        public string contextmenu;
        public dir dir;
        public truefalse draggable;
        public dropzone dropzone;
        public bool hidden;
        public string id;
        public string itemid;
        public string itemprop;
        public string itemref;
        public bool itemscope;
        public string itemtype;
        public string lang;
        public truefalse spellcheck;
        public string style;
        public int? tabindex;
        public string title;

        // Event handlers
        public string onabort;
        public string onblur;
        public string oncanplay;
        public string oncanplaythrough;
        public string onchange;
        public string onclick;
        public string oncontextmenu;
        public string ondblclick;
        public string ondrag;
        public string ondragend;
        public string ondragenter;
        public string ondragleave;
        public string ondragover;
        public string ondragstart;
        public string ondrop;
        public string ondurationchange;
        public string onemptied;
        public string onended;
        public string onerror;
        public string onfocus;
        public string onformchange;
        public string onforminput;
        public string oninput;
        public string oninvalid;
        public string onkeydown;
        public string onkeypress;
        public string onkeyup;
        public string onload;
        public string onloadeddata;
        public string onloadedmetadata;
        public string onloadstart;
        public string onmousedown;
        public string onmousemove;
        public string onmouseout;
        public string onmouseover;
        public string onmouseup;
        public string onmousewheel;
        public string onpause;
        public string onplay;
        public string onplaying;
        public string onprogress;
        public string onratechange;
        public string onreset;
        public string onreadystatechange;
        public string onseeked;
        public string onseeking;
        public string onselect;
        public string onshow;
        public string onstalled;
        public string onsubmit;
        public string onsuspend;
        public string ontimeupdate;
        public string onvolumechange;
        public string onwaiting;
#pragma warning restore 1591    // Missing XML comment for publicly visible type or member
    }

    /// <summary>Represents an HTML <c>&lt;style&gt;</c> tag whose contents are provided literally (not via an <c>href</c>).</summary>
    public sealed class STYLELiteral : HtmlTag
    {
        /// <summary>
        ///     Creates an HTML <c>&lt;style&gt;</c> tag.</summary>
        /// <param name="literal">
        ///     Specifies the literal contents of the tag.</param>
        public STYLELiteral(string literal)
            : base()
        {
            if (Regex.IsMatch(literal, @"<!--|-->|</?style\s*>"))
                throw new ArgumentException("Style literal may not contain <!--, -->, <style> or </style>.", "literal");
            Literal = literal;
        }
        /// <summary>Returns <c>"style"</c>.</summary>
        public override string TagName { get { return "style"; } }
        /// <summary>Specifies the literal tag contents.</summary>
        public string Literal;
        /// <summary>
        ///     Outputs this tag and all its contents.</summary>
        /// <param name="allTags">
        ///     The HTML specification allows certain start and end tags to be omitted. Specify <c>true</c> to emit such tags
        ///     regardless, for compatibility reasons.</param>
        /// <returns>
        ///     A collection of strings which, when concatenated, represent this tag and all its contents.</returns>
        public override IEnumerable<string> ToEnumerable(bool allTags = false)
        {
            yield return @"<style type=text/css>";
            yield return Literal;
            yield return @"</style>";
        }
        /// <summary>Throws NotImplementedException.</summary>
        protected override IEnumerable<string> enumerateAttributes() { throw new NotImplementedException(); }
    }

    /// <summary>Represents an HTML <c>&lt;script&gt;</c> tag whose contents are provided literally (not via an <c>href</c>).</summary>
    public sealed class SCRIPTLiteral : HtmlTag
    {
        /// <summary>
        ///     Creates an HTML <c>&lt;style&gt;</c> tag.</summary>
        /// <param name="literal">
        ///     Specifies the literal contents of the tag.</param>
        public SCRIPTLiteral(string literal)
            : base()
        {
            if (Regex.IsMatch(literal, @"<!--|-->|</?script\s*>"))
                throw new ArgumentException("Script literal may not contain <!--, -->, <script> or </script>.", "literal");
            Literal = literal;
        }
        /// <summary>Returns <c>"script"</c>.</summary>
        public override string TagName { get { return "script"; } }
        /// <summary>Specifies the literal tag contents.</summary>
        public string Literal;
        /// <summary>
        ///     Outputs this tag and all its contents.</summary>
        /// <param name="allTags">
        ///     The HTML specification allows certain start and end tags to be omitted. Specify <c>true</c> to emit such tags
        ///     regardless, for compatibility reasons.</param>
        /// <returns>
        ///     A collection of strings which, when concatenated, represent this tag and all its contents.</returns>
        public override IEnumerable<string> ToEnumerable(bool allTags = false)
        {
            yield return @"<script type=text/javascript>";
            yield return Literal;
            yield return @"</script>";
        }
        /// <summary>Throws NotImplementedException.</summary>
        protected override IEnumerable<string> enumerateAttributes() { throw new NotImplementedException(); }
    }

#pragma warning disable 1591    // Missing XML comment for publicly visible type or member

    [Flags]
    public enum sandbox { _, allowSameOrigin = 1 << 0, allowTopNavigation = 1 << 1, allowForms = 1 << 2, allowScripts = 1 << 3 }
    public enum shape { _, circle, default_, poly, rect }
    public enum cors { _, anonymous, useCredentials }
    public enum preload { _, none, metadata, auto }
    public enum btype { _, submit, reset, button }
    public enum ctype { _, command, checkbox, radio }
    public enum autocomplete { _, on, off }
    public enum enctype { _, application_xWwwFormUrlencoded, multipart_formData, text_plain }
    public enum itype { _, hidden, text, search, tel, url, email, password, datetime, date, month, week, time, datetimeLocal, number, range, color, checkbox, radio, file, submit, image, reset, button }
    public enum keytype { _, rsa }
    public enum mtype { _, context, toolbar }
    public enum scope { _, row, col, rowgroup, colgroup, auto }
    public enum wrap { _, soft, hard }
    public enum kind { _, subtitles, captions, descriptions, chapters, metadata }
    public enum truefalse { _, true_, false_ }
    public enum dir { _, ltr, rtl, auto }
    public enum dropzone { _, copy, move, link }
    public enum method { _, get, post }

    /* HTML tags generated code START */
    
    public sealed class A : HtmlTag
    {
        public A() : base() { }
        public A(params object[] contents) : base(contents) { }
        public override string TagName { get { return "a"; } }
        public string href;
        public string target;
        public string ping;
        public string rel;
        public string media;
        public string hreflang;
        public string type;
        /// <summary>Stringifies the attributes on this tag.</summary>
        protected override IEnumerable<string> enumerateAttributes()
        {
            if (href != null) { yield return " href="; yield return attributeValue(href); }
            if (target != null) { yield return " target="; yield return attributeValue(target); }
            if (ping != null) { yield return " ping="; yield return attributeValue(ping); }
            if (rel != null) { yield return " rel="; yield return attributeValue(rel); }
            if (media != null) { yield return " media="; yield return attributeValue(media); }
            if (hreflang != null) { yield return " hreflang="; yield return attributeValue(hreflang); }
            if (type != null) { yield return " type="; yield return attributeValue(type); }
            var baseAttrs = base.enumerateAttributes();
            if (baseAttrs != null)
                foreach (var obj in baseAttrs)
                    yield return obj;
        }
    }
    public sealed class ABBR : HtmlTag
    {
        public ABBR() : base() { }
        public ABBR(params object[] contents) : base(contents) { }
        public override string TagName { get { return "abbr"; } }
        /// <summary>Stringifies the attributes on this tag.</summary>
        protected override IEnumerable<string> enumerateAttributes()
        {
            
            var baseAttrs = base.enumerateAttributes();
            if (baseAttrs != null)
                foreach (var obj in baseAttrs)
                    yield return obj;
        }
    }
    public sealed class ADDRESS : HtmlTag
    {
        public ADDRESS() : base() { }
        public ADDRESS(params object[] contents) : base(contents) { }
        public override string TagName { get { return "address"; } }
        /// <summary>Stringifies the attributes on this tag.</summary>
        protected override IEnumerable<string> enumerateAttributes()
        {
            
            var baseAttrs = base.enumerateAttributes();
            if (baseAttrs != null)
                foreach (var obj in baseAttrs)
                    yield return obj;
        }
    }
    public sealed class AREA : HtmlTag
    {
        public AREA() : base() { }
        public AREA(params object[] contents) : base(contents) { }
        public override string TagName { get { return "area"; } }
        public override bool EndTag { get { return false; } }
        public string alt;
        public int[] coords;
        public shape shape;
        public string href;
        public string target;
        public string ping;
        public string rel;
        public string media;
        public string hreflang;
        public string type;
        /// <summary>Stringifies the attributes on this tag.</summary>
        protected override IEnumerable<string> enumerateAttributes()
        {
            if (alt != null) { yield return " alt="; yield return attributeValue(alt); }
            if (coords != null) { yield return " coords="; yield return attributeValue(coords.ToString()); }
            switch (shape) { case shape.circle: yield return " shape=circle"; break; case shape.default_: yield return " shape=default"; break; case shape.poly: yield return " shape=poly"; break; case shape.rect: yield return " shape=rect"; break; }
            if (href != null) { yield return " href="; yield return attributeValue(href); }
            if (target != null) { yield return " target="; yield return attributeValue(target); }
            if (ping != null) { yield return " ping="; yield return attributeValue(ping); }
            if (rel != null) { yield return " rel="; yield return attributeValue(rel); }
            if (media != null) { yield return " media="; yield return attributeValue(media); }
            if (hreflang != null) { yield return " hreflang="; yield return attributeValue(hreflang); }
            if (type != null) { yield return " type="; yield return attributeValue(type); }
            var baseAttrs = base.enumerateAttributes();
            if (baseAttrs != null)
                foreach (var obj in baseAttrs)
                    yield return obj;
        }
    }
    public sealed class ARTICLE : HtmlTag
    {
        public ARTICLE() : base() { }
        public ARTICLE(params object[] contents) : base(contents) { }
        public override string TagName { get { return "article"; } }
        /// <summary>Stringifies the attributes on this tag.</summary>
        protected override IEnumerable<string> enumerateAttributes()
        {
            
            var baseAttrs = base.enumerateAttributes();
            if (baseAttrs != null)
                foreach (var obj in baseAttrs)
                    yield return obj;
        }
    }
    public sealed class ASIDE : HtmlTag
    {
        public ASIDE() : base() { }
        public ASIDE(params object[] contents) : base(contents) { }
        public override string TagName { get { return "aside"; } }
        /// <summary>Stringifies the attributes on this tag.</summary>
        protected override IEnumerable<string> enumerateAttributes()
        {
            
            var baseAttrs = base.enumerateAttributes();
            if (baseAttrs != null)
                foreach (var obj in baseAttrs)
                    yield return obj;
        }
    }
    public sealed class AUDIO : HtmlTag
    {
        public AUDIO() : base() { }
        public AUDIO(params object[] contents) : base(contents) { }
        public override string TagName { get { return "audio"; } }
        public string src;
        public cors crossorigin;
        public preload preload;
        public bool autoplay;
        public string mediagroup;
        public bool loop;
        public bool muted;
        public bool controls;
        /// <summary>Stringifies the attributes on this tag.</summary>
        protected override IEnumerable<string> enumerateAttributes()
        {
            if (src != null) { yield return " src="; yield return attributeValue(src); }
            switch (crossorigin) { case cors.anonymous: yield return " crossorigin=anonymous"; break; case cors.useCredentials: yield return " crossorigin=use-credentials"; break; }
            switch (preload) { case preload.none: yield return " preload=none"; break; case preload.metadata: yield return " preload=metadata"; break; case preload.auto: yield return " preload=auto"; break; }
            if (autoplay) yield return " autoplay";
            if (mediagroup != null) { yield return " mediagroup="; yield return attributeValue(mediagroup); }
            if (loop) yield return " loop";
            if (muted) yield return " muted";
            if (controls) yield return " controls";
            var baseAttrs = base.enumerateAttributes();
            if (baseAttrs != null)
                foreach (var obj in baseAttrs)
                    yield return obj;
        }
    }
    public sealed class B : HtmlTag
    {
        public B() : base() { }
        public B(params object[] contents) : base(contents) { }
        public override string TagName { get { return "b"; } }
        /// <summary>Stringifies the attributes on this tag.</summary>
        protected override IEnumerable<string> enumerateAttributes()
        {
            
            var baseAttrs = base.enumerateAttributes();
            if (baseAttrs != null)
                foreach (var obj in baseAttrs)
                    yield return obj;
        }
    }
    public sealed class BASE : HtmlTag
    {
        public BASE() : base() { }
        public BASE(params object[] contents) : base(contents) { }
        public override string TagName { get { return "base"; } }
        public override bool EndTag { get { return false; } }
        public string href;
        public string target;
        /// <summary>Stringifies the attributes on this tag.</summary>
        protected override IEnumerable<string> enumerateAttributes()
        {
            if (href != null) { yield return " href="; yield return attributeValue(href); }
            if (target != null) { yield return " target="; yield return attributeValue(target); }
            var baseAttrs = base.enumerateAttributes();
            if (baseAttrs != null)
                foreach (var obj in baseAttrs)
                    yield return obj;
        }
    }
    public sealed class BDI : HtmlTag
    {
        public BDI() : base() { }
        public BDI(params object[] contents) : base(contents) { }
        public override string TagName { get { return "bdi"; } }
        /// <summary>Stringifies the attributes on this tag.</summary>
        protected override IEnumerable<string> enumerateAttributes()
        {
            
            var baseAttrs = base.enumerateAttributes();
            if (baseAttrs != null)
                foreach (var obj in baseAttrs)
                    yield return obj;
        }
    }
    public sealed class BDO : HtmlTag
    {
        public BDO() : base() { }
        public BDO(params object[] contents) : base(contents) { }
        public override string TagName { get { return "bdo"; } }
        /// <summary>Stringifies the attributes on this tag.</summary>
        protected override IEnumerable<string> enumerateAttributes()
        {
            
            var baseAttrs = base.enumerateAttributes();
            if (baseAttrs != null)
                foreach (var obj in baseAttrs)
                    yield return obj;
        }
    }
    public sealed class BLOCKQUOTE : HtmlTag
    {
        public BLOCKQUOTE() : base() { }
        public BLOCKQUOTE(params object[] contents) : base(contents) { }
        public override string TagName { get { return "blockquote"; } }
        public string cite;
        /// <summary>Stringifies the attributes on this tag.</summary>
        protected override IEnumerable<string> enumerateAttributes()
        {
            if (cite != null) { yield return " cite="; yield return attributeValue(cite); }
            var baseAttrs = base.enumerateAttributes();
            if (baseAttrs != null)
                foreach (var obj in baseAttrs)
                    yield return obj;
        }
    }
    public sealed class BODY : HtmlTag
    {
        public BODY() : base() { }
        public BODY(params object[] contents) : base(contents) { }
        public override string TagName { get { return "body"; } }
        public override bool EndTag { get { return false; } }
        public string onafterprint;
        public string onbeforeprint;
        public string onbeforeunload;
        public string onhashchange;
        public string onmessage;
        public string onoffline;
        public string ononline;
        public string onpagehide;
        public string onpageshow;
        public string onpopstate;
        public string onresize;
        public string onscroll;
        public string onstorage;
        public string onunload;
        /// <summary>Stringifies the attributes on this tag.</summary>
        protected override IEnumerable<string> enumerateAttributes()
        {
            if (onafterprint != null) { yield return " onafterprint="; yield return attributeValue(onafterprint); }
            if (onbeforeprint != null) { yield return " onbeforeprint="; yield return attributeValue(onbeforeprint); }
            if (onbeforeunload != null) { yield return " onbeforeunload="; yield return attributeValue(onbeforeunload); }
            if (onhashchange != null) { yield return " onhashchange="; yield return attributeValue(onhashchange); }
            if (onmessage != null) { yield return " onmessage="; yield return attributeValue(onmessage); }
            if (onoffline != null) { yield return " onoffline="; yield return attributeValue(onoffline); }
            if (ononline != null) { yield return " ononline="; yield return attributeValue(ononline); }
            if (onpagehide != null) { yield return " onpagehide="; yield return attributeValue(onpagehide); }
            if (onpageshow != null) { yield return " onpageshow="; yield return attributeValue(onpageshow); }
            if (onpopstate != null) { yield return " onpopstate="; yield return attributeValue(onpopstate); }
            if (onresize != null) { yield return " onresize="; yield return attributeValue(onresize); }
            if (onscroll != null) { yield return " onscroll="; yield return attributeValue(onscroll); }
            if (onstorage != null) { yield return " onstorage="; yield return attributeValue(onstorage); }
            if (onunload != null) { yield return " onunload="; yield return attributeValue(onunload); }
            var baseAttrs = base.enumerateAttributes();
            if (baseAttrs != null)
                foreach (var obj in baseAttrs)
                    yield return obj;
        }
    }
    public sealed class BR : HtmlTag
    {
        public BR() : base() { }
        public BR(params object[] contents) : base(contents) { }
        public override string TagName { get { return "br"; } }
        public override bool EndTag { get { return false; } }
        /// <summary>Stringifies the attributes on this tag.</summary>
        protected override IEnumerable<string> enumerateAttributes()
        {
            
            var baseAttrs = base.enumerateAttributes();
            if (baseAttrs != null)
                foreach (var obj in baseAttrs)
                    yield return obj;
        }
    }
    public sealed class BUTTON : HtmlTag
    {
        public BUTTON() : base() { }
        public BUTTON(params object[] contents) : base(contents) { }
        public override string TagName { get { return "button"; } }
        public bool autofocus;
        public bool disabled;
        public string form;
        public string formaction;
        public enctype formenctype;
        public method formmethod;
        public bool formnovalidate;
        public string formtarget;
        public string name;
        public btype type;
        public string value;
        /// <summary>Stringifies the attributes on this tag.</summary>
        protected override IEnumerable<string> enumerateAttributes()
        {
            if (autofocus) yield return " autofocus";
            if (disabled) yield return " disabled";
            if (form != null) { yield return " form="; yield return attributeValue(form); }
            if (formaction != null) { yield return " formaction="; yield return attributeValue(formaction); }
            switch (formenctype) { case enctype.application_xWwwFormUrlencoded: yield return " formenctype=application/x-www-form-urlencoded"; break; case enctype.multipart_formData: yield return " formenctype=multipart/form-data"; break; case enctype.text_plain: yield return " formenctype=text/plain"; break; }
            switch (formmethod) { case method.get: yield return " formmethod=get"; break; case method.post: yield return " formmethod=post"; break; }
            if (formnovalidate) yield return " formnovalidate";
            if (formtarget != null) { yield return " formtarget="; yield return attributeValue(formtarget); }
            if (name != null) { yield return " name="; yield return attributeValue(name); }
            switch (type) { case btype.submit: yield return " type=submit"; break; case btype.reset: yield return " type=reset"; break; case btype.button: yield return " type=button"; break; }
            if (value != null) { yield return " value="; yield return attributeValue(value); }
            var baseAttrs = base.enumerateAttributes();
            if (baseAttrs != null)
                foreach (var obj in baseAttrs)
                    yield return obj;
        }
    }
    public sealed class CANVAS : HtmlTag
    {
        public CANVAS() : base() { }
        public CANVAS(params object[] contents) : base(contents) { }
        public override string TagName { get { return "canvas"; } }
        public int? width;
        public int? height;
        /// <summary>Stringifies the attributes on this tag.</summary>
        protected override IEnumerable<string> enumerateAttributes()
        {
            if (width != null) { yield return " width="; yield return attributeValue(width.ToString()); }
            if (height != null) { yield return " height="; yield return attributeValue(height.ToString()); }
            var baseAttrs = base.enumerateAttributes();
            if (baseAttrs != null)
                foreach (var obj in baseAttrs)
                    yield return obj;
        }
    }
    public sealed class CAPTION : HtmlTag
    {
        public CAPTION() : base() { }
        public CAPTION(params object[] contents) : base(contents) { }
        public override string TagName { get { return "caption"; } }
        /// <summary>Stringifies the attributes on this tag.</summary>
        protected override IEnumerable<string> enumerateAttributes()
        {
            
            var baseAttrs = base.enumerateAttributes();
            if (baseAttrs != null)
                foreach (var obj in baseAttrs)
                    yield return obj;
        }
    }
    public sealed class CITE : HtmlTag
    {
        public CITE() : base() { }
        public CITE(params object[] contents) : base(contents) { }
        public override string TagName { get { return "cite"; } }
        /// <summary>Stringifies the attributes on this tag.</summary>
        protected override IEnumerable<string> enumerateAttributes()
        {
            
            var baseAttrs = base.enumerateAttributes();
            if (baseAttrs != null)
                foreach (var obj in baseAttrs)
                    yield return obj;
        }
    }
    public sealed class CODE : HtmlTag
    {
        public CODE() : base() { }
        public CODE(params object[] contents) : base(contents) { }
        public override string TagName { get { return "code"; } }
        /// <summary>Stringifies the attributes on this tag.</summary>
        protected override IEnumerable<string> enumerateAttributes()
        {
            
            var baseAttrs = base.enumerateAttributes();
            if (baseAttrs != null)
                foreach (var obj in baseAttrs)
                    yield return obj;
        }
    }
    public sealed class COL : HtmlTag
    {
        public COL() : base() { }
        public COL(params object[] contents) : base(contents) { }
        public override string TagName { get { return "col"; } }
        public override bool EndTag { get { return false; } }
        public int? span;
        /// <summary>Stringifies the attributes on this tag.</summary>
        protected override IEnumerable<string> enumerateAttributes()
        {
            if (span != null) { yield return " span="; yield return attributeValue(span.ToString()); }
            var baseAttrs = base.enumerateAttributes();
            if (baseAttrs != null)
                foreach (var obj in baseAttrs)
                    yield return obj;
        }
    }
    public sealed class COLGROUP : HtmlTag
    {
        public COLGROUP() : base() { }
        public COLGROUP(params object[] contents) : base(contents) { }
        public override string TagName { get { return "colgroup"; } }
        public override bool EndTag { get { return false; } }
        public int? span;
        /// <summary>Stringifies the attributes on this tag.</summary>
        protected override IEnumerable<string> enumerateAttributes()
        {
            if (span != null) { yield return " span="; yield return attributeValue(span.ToString()); }
            var baseAttrs = base.enumerateAttributes();
            if (baseAttrs != null)
                foreach (var obj in baseAttrs)
                    yield return obj;
        }
    }
    public sealed class COMMAND : HtmlTag
    {
        public COMMAND() : base() { }
        public COMMAND(params object[] contents) : base(contents) { }
        public override string TagName { get { return "command"; } }
        public override bool EndTag { get { return false; } }
        public ctype type;
        public string label;
        public string icon;
        public bool disabled;
        public bool checked_;
        public string radiogroup;
        /// <summary>Stringifies the attributes on this tag.</summary>
        protected override IEnumerable<string> enumerateAttributes()
        {
            switch (type) { case ctype.command: yield return " type=command"; break; case ctype.checkbox: yield return " type=checkbox"; break; case ctype.radio: yield return " type=radio"; break; }
            if (label != null) { yield return " label="; yield return attributeValue(label); }
            if (icon != null) { yield return " icon="; yield return attributeValue(icon); }
            if (disabled) yield return " disabled";
            if (checked_) yield return " checked";
            if (radiogroup != null) { yield return " radiogroup="; yield return attributeValue(radiogroup); }
            var baseAttrs = base.enumerateAttributes();
            if (baseAttrs != null)
                foreach (var obj in baseAttrs)
                    yield return obj;
        }
    }
    public sealed class DATALIST : HtmlTag
    {
        public DATALIST() : base() { }
        public DATALIST(params object[] contents) : base(contents) { }
        public override string TagName { get { return "datalist"; } }
        /// <summary>Stringifies the attributes on this tag.</summary>
        protected override IEnumerable<string> enumerateAttributes()
        {
            
            var baseAttrs = base.enumerateAttributes();
            if (baseAttrs != null)
                foreach (var obj in baseAttrs)
                    yield return obj;
        }
    }
    public sealed class DD : HtmlTag
    {
        public DD() : base() { }
        public DD(params object[] contents) : base(contents) { }
        public override string TagName { get { return "dd"; } }
        public override bool EndTag { get { return false; } }
        /// <summary>Stringifies the attributes on this tag.</summary>
        protected override IEnumerable<string> enumerateAttributes()
        {
            
            var baseAttrs = base.enumerateAttributes();
            if (baseAttrs != null)
                foreach (var obj in baseAttrs)
                    yield return obj;
        }
    }
    public sealed class DEL : HtmlTag
    {
        public DEL() : base() { }
        public DEL(params object[] contents) : base(contents) { }
        public override string TagName { get { return "del"; } }
        public string cite;
        public string datetime;
        /// <summary>Stringifies the attributes on this tag.</summary>
        protected override IEnumerable<string> enumerateAttributes()
        {
            if (cite != null) { yield return " cite="; yield return attributeValue(cite); }
            if (datetime != null) { yield return " datetime="; yield return attributeValue(datetime); }
            var baseAttrs = base.enumerateAttributes();
            if (baseAttrs != null)
                foreach (var obj in baseAttrs)
                    yield return obj;
        }
    }
    public sealed class DETAILS : HtmlTag
    {
        public DETAILS() : base() { }
        public DETAILS(params object[] contents) : base(contents) { }
        public override string TagName { get { return "details"; } }
        public string open;
        /// <summary>Stringifies the attributes on this tag.</summary>
        protected override IEnumerable<string> enumerateAttributes()
        {
            if (open != null) { yield return " open="; yield return attributeValue(open); }
            var baseAttrs = base.enumerateAttributes();
            if (baseAttrs != null)
                foreach (var obj in baseAttrs)
                    yield return obj;
        }
    }
    public sealed class DFN : HtmlTag
    {
        public DFN() : base() { }
        public DFN(params object[] contents) : base(contents) { }
        public override string TagName { get { return "dfn"; } }
        /// <summary>Stringifies the attributes on this tag.</summary>
        protected override IEnumerable<string> enumerateAttributes()
        {
            
            var baseAttrs = base.enumerateAttributes();
            if (baseAttrs != null)
                foreach (var obj in baseAttrs)
                    yield return obj;
        }
    }
    public sealed class DIV : HtmlTag
    {
        public DIV() : base() { }
        public DIV(params object[] contents) : base(contents) { }
        public override string TagName { get { return "div"; } }
        /// <summary>Stringifies the attributes on this tag.</summary>
        protected override IEnumerable<string> enumerateAttributes()
        {
            
            var baseAttrs = base.enumerateAttributes();
            if (baseAttrs != null)
                foreach (var obj in baseAttrs)
                    yield return obj;
        }
    }
    public sealed class DL : HtmlTag
    {
        public DL() : base() { }
        public DL(params object[] contents) : base(contents) { }
        public override string TagName { get { return "dl"; } }
        /// <summary>Stringifies the attributes on this tag.</summary>
        protected override IEnumerable<string> enumerateAttributes()
        {
            
            var baseAttrs = base.enumerateAttributes();
            if (baseAttrs != null)
                foreach (var obj in baseAttrs)
                    yield return obj;
        }
    }
    public sealed class DT : HtmlTag
    {
        public DT() : base() { }
        public DT(params object[] contents) : base(contents) { }
        public override string TagName { get { return "dt"; } }
        public override bool EndTag { get { return false; } }
        /// <summary>Stringifies the attributes on this tag.</summary>
        protected override IEnumerable<string> enumerateAttributes()
        {
            
            var baseAttrs = base.enumerateAttributes();
            if (baseAttrs != null)
                foreach (var obj in baseAttrs)
                    yield return obj;
        }
    }
    public sealed class EM : HtmlTag
    {
        public EM() : base() { }
        public EM(params object[] contents) : base(contents) { }
        public override string TagName { get { return "em"; } }
        /// <summary>Stringifies the attributes on this tag.</summary>
        protected override IEnumerable<string> enumerateAttributes()
        {
            
            var baseAttrs = base.enumerateAttributes();
            if (baseAttrs != null)
                foreach (var obj in baseAttrs)
                    yield return obj;
        }
    }
    public sealed class EMBED : HtmlTag
    {
        public EMBED() : base() { }
        public EMBED(params object[] contents) : base(contents) { }
        public override string TagName { get { return "embed"; } }
        public override bool EndTag { get { return false; } }
        public string src;
        public string type;
        public int? width;
        public int? height;
        /// <summary>Stringifies the attributes on this tag.</summary>
        protected override IEnumerable<string> enumerateAttributes()
        {
            if (src != null) { yield return " src="; yield return attributeValue(src); }
            if (type != null) { yield return " type="; yield return attributeValue(type); }
            if (width != null) { yield return " width="; yield return attributeValue(width.ToString()); }
            if (height != null) { yield return " height="; yield return attributeValue(height.ToString()); }
            var baseAttrs = base.enumerateAttributes();
            if (baseAttrs != null)
                foreach (var obj in baseAttrs)
                    yield return obj;
        }
    }
    public sealed class FIELDSET : HtmlTag
    {
        public FIELDSET() : base() { }
        public FIELDSET(params object[] contents) : base(contents) { }
        public override string TagName { get { return "fieldset"; } }
        public bool disabled;
        public string form;
        public string name;
        /// <summary>Stringifies the attributes on this tag.</summary>
        protected override IEnumerable<string> enumerateAttributes()
        {
            if (disabled) yield return " disabled";
            if (form != null) { yield return " form="; yield return attributeValue(form); }
            if (name != null) { yield return " name="; yield return attributeValue(name); }
            var baseAttrs = base.enumerateAttributes();
            if (baseAttrs != null)
                foreach (var obj in baseAttrs)
                    yield return obj;
        }
    }
    public sealed class FIGCAPTION : HtmlTag
    {
        public FIGCAPTION() : base() { }
        public FIGCAPTION(params object[] contents) : base(contents) { }
        public override string TagName { get { return "figcaption"; } }
        /// <summary>Stringifies the attributes on this tag.</summary>
        protected override IEnumerable<string> enumerateAttributes()
        {
            
            var baseAttrs = base.enumerateAttributes();
            if (baseAttrs != null)
                foreach (var obj in baseAttrs)
                    yield return obj;
        }
    }
    public sealed class FIGURE : HtmlTag
    {
        public FIGURE() : base() { }
        public FIGURE(params object[] contents) : base(contents) { }
        public override string TagName { get { return "figure"; } }
        /// <summary>Stringifies the attributes on this tag.</summary>
        protected override IEnumerable<string> enumerateAttributes()
        {
            
            var baseAttrs = base.enumerateAttributes();
            if (baseAttrs != null)
                foreach (var obj in baseAttrs)
                    yield return obj;
        }
    }
    public sealed class FOOTER : HtmlTag
    {
        public FOOTER() : base() { }
        public FOOTER(params object[] contents) : base(contents) { }
        public override string TagName { get { return "footer"; } }
        /// <summary>Stringifies the attributes on this tag.</summary>
        protected override IEnumerable<string> enumerateAttributes()
        {
            
            var baseAttrs = base.enumerateAttributes();
            if (baseAttrs != null)
                foreach (var obj in baseAttrs)
                    yield return obj;
        }
    }
    public sealed class FORM : HtmlTag
    {
        public FORM() : base() { }
        public FORM(params object[] contents) : base(contents) { }
        public override string TagName { get { return "form"; } }
        public string acceptCharset;
        public string action;
        public autocomplete autocomplete;
        public enctype enctype;
        public method method;
        public string name;
        public bool novalidate;
        public string target;
        /// <summary>Stringifies the attributes on this tag.</summary>
        protected override IEnumerable<string> enumerateAttributes()
        {
            if (acceptCharset != null) { yield return " accept-charset="; yield return attributeValue(acceptCharset); }
            if (action != null) { yield return " action="; yield return attributeValue(action); }
            switch (autocomplete) { case autocomplete.on: yield return " autocomplete=on"; break; case autocomplete.off: yield return " autocomplete=off"; break; }
            switch (enctype) { case enctype.application_xWwwFormUrlencoded: yield return " enctype=application/x-www-form-urlencoded"; break; case enctype.multipart_formData: yield return " enctype=multipart/form-data"; break; case enctype.text_plain: yield return " enctype=text/plain"; break; }
            switch (method) { case method.get: yield return " method=get"; break; case method.post: yield return " method=post"; break; }
            if (name != null) { yield return " name="; yield return attributeValue(name); }
            if (novalidate) yield return " novalidate";
            if (target != null) { yield return " target="; yield return attributeValue(target); }
            var baseAttrs = base.enumerateAttributes();
            if (baseAttrs != null)
                foreach (var obj in baseAttrs)
                    yield return obj;
        }
    }
    public sealed class H1 : HtmlTag
    {
        public H1() : base() { }
        public H1(params object[] contents) : base(contents) { }
        public override string TagName { get { return "h1"; } }
        /// <summary>Stringifies the attributes on this tag.</summary>
        protected override IEnumerable<string> enumerateAttributes()
        {
            
            var baseAttrs = base.enumerateAttributes();
            if (baseAttrs != null)
                foreach (var obj in baseAttrs)
                    yield return obj;
        }
    }
    public sealed class H2 : HtmlTag
    {
        public H2() : base() { }
        public H2(params object[] contents) : base(contents) { }
        public override string TagName { get { return "h2"; } }
        /// <summary>Stringifies the attributes on this tag.</summary>
        protected override IEnumerable<string> enumerateAttributes()
        {
            
            var baseAttrs = base.enumerateAttributes();
            if (baseAttrs != null)
                foreach (var obj in baseAttrs)
                    yield return obj;
        }
    }
    public sealed class H3 : HtmlTag
    {
        public H3() : base() { }
        public H3(params object[] contents) : base(contents) { }
        public override string TagName { get { return "h3"; } }
        /// <summary>Stringifies the attributes on this tag.</summary>
        protected override IEnumerable<string> enumerateAttributes()
        {
            
            var baseAttrs = base.enumerateAttributes();
            if (baseAttrs != null)
                foreach (var obj in baseAttrs)
                    yield return obj;
        }
    }
    public sealed class H4 : HtmlTag
    {
        public H4() : base() { }
        public H4(params object[] contents) : base(contents) { }
        public override string TagName { get { return "h4"; } }
        /// <summary>Stringifies the attributes on this tag.</summary>
        protected override IEnumerable<string> enumerateAttributes()
        {
            
            var baseAttrs = base.enumerateAttributes();
            if (baseAttrs != null)
                foreach (var obj in baseAttrs)
                    yield return obj;
        }
    }
    public sealed class H5 : HtmlTag
    {
        public H5() : base() { }
        public H5(params object[] contents) : base(contents) { }
        public override string TagName { get { return "h5"; } }
        /// <summary>Stringifies the attributes on this tag.</summary>
        protected override IEnumerable<string> enumerateAttributes()
        {
            
            var baseAttrs = base.enumerateAttributes();
            if (baseAttrs != null)
                foreach (var obj in baseAttrs)
                    yield return obj;
        }
    }
    public sealed class H6 : HtmlTag
    {
        public H6() : base() { }
        public H6(params object[] contents) : base(contents) { }
        public override string TagName { get { return "h6"; } }
        /// <summary>Stringifies the attributes on this tag.</summary>
        protected override IEnumerable<string> enumerateAttributes()
        {
            
            var baseAttrs = base.enumerateAttributes();
            if (baseAttrs != null)
                foreach (var obj in baseAttrs)
                    yield return obj;
        }
    }
    public sealed class HEAD : HtmlTag
    {
        public HEAD() : base() { }
        public HEAD(params object[] contents) : base(contents) { }
        public override string TagName { get { return "head"; } }
        public override bool EndTag { get { return false; } }
        /// <summary>Stringifies the attributes on this tag.</summary>
        protected override IEnumerable<string> enumerateAttributes()
        {
            
            var baseAttrs = base.enumerateAttributes();
            if (baseAttrs != null)
                foreach (var obj in baseAttrs)
                    yield return obj;
        }
    }
    public sealed class HEADER : HtmlTag
    {
        public HEADER() : base() { }
        public HEADER(params object[] contents) : base(contents) { }
        public override string TagName { get { return "header"; } }
        /// <summary>Stringifies the attributes on this tag.</summary>
        protected override IEnumerable<string> enumerateAttributes()
        {
            
            var baseAttrs = base.enumerateAttributes();
            if (baseAttrs != null)
                foreach (var obj in baseAttrs)
                    yield return obj;
        }
    }
    public sealed class HGROUP : HtmlTag
    {
        public HGROUP() : base() { }
        public HGROUP(params object[] contents) : base(contents) { }
        public override string TagName { get { return "hgroup"; } }
        /// <summary>Stringifies the attributes on this tag.</summary>
        protected override IEnumerable<string> enumerateAttributes()
        {
            
            var baseAttrs = base.enumerateAttributes();
            if (baseAttrs != null)
                foreach (var obj in baseAttrs)
                    yield return obj;
        }
    }
    public sealed class HR : HtmlTag
    {
        public HR() : base() { }
        public HR(params object[] contents) : base(contents) { }
        public override string TagName { get { return "hr"; } }
        public override bool EndTag { get { return false; } }
        /// <summary>Stringifies the attributes on this tag.</summary>
        protected override IEnumerable<string> enumerateAttributes()
        {
            
            var baseAttrs = base.enumerateAttributes();
            if (baseAttrs != null)
                foreach (var obj in baseAttrs)
                    yield return obj;
        }
    }
    public sealed class HTML : HtmlTag
    {
        public HTML() : base() { }
        public HTML(params object[] contents) : base(contents) { }
        public override string TagName { get { return "html"; } }
        public override bool StartTag { get { return false; } }
        public override bool EndTag { get { return false; } }
        public string manifest;
        public override IEnumerable<string> ToEnumerable(bool allTags = false)
        {
            yield return "<!DOCTYPE html>";
            foreach (var item in base.ToEnumerable(allTags))
                yield return item;
        }
        /// <summary>Stringifies the attributes on this tag.</summary>
        protected override IEnumerable<string> enumerateAttributes()
        {
            if (manifest != null) { yield return " manifest="; yield return attributeValue(manifest); }
            var baseAttrs = base.enumerateAttributes();
            if (baseAttrs != null)
                foreach (var obj in baseAttrs)
                    yield return obj;
        }
    }
    public sealed class I : HtmlTag
    {
        public I() : base() { }
        public I(params object[] contents) : base(contents) { }
        public override string TagName { get { return "i"; } }
        /// <summary>Stringifies the attributes on this tag.</summary>
        protected override IEnumerable<string> enumerateAttributes()
        {
            
            var baseAttrs = base.enumerateAttributes();
            if (baseAttrs != null)
                foreach (var obj in baseAttrs)
                    yield return obj;
        }
    }
    public sealed class IFRAME : HtmlTag
    {
        public IFRAME() : base() { }
        public IFRAME(params object[] contents) : base(contents) { }
        public override string TagName { get { return "iframe"; } }
        public string src;
        public string srcdoc;
        public string name;
        public sandbox sandbox;
        public bool seamless;
        public int? width;
        public int? height;
        /// <summary>Stringifies the attributes on this tag.</summary>
        protected override IEnumerable<string> enumerateAttributes()
        {
            if (src != null) { yield return " src="; yield return attributeValue(src); }
            if (srcdoc != null) { yield return " srcdoc="; yield return attributeValue(srcdoc); }
            if (name != null) { yield return " name="; yield return attributeValue(name); }
            if (sandbox != 0)
            {
                var str = "";
                if ((sandbox & sandbox.allowSameOrigin) != 0) { if (str.Length > 0) str += " "; str += "allow-same-origin"; }
                if ((sandbox & sandbox.allowTopNavigation) != 0) { if (str.Length > 0) str += " "; str += "allow-top-navigation"; }
                if ((sandbox & sandbox.allowForms) != 0) { if (str.Length > 0) str += " "; str += "allow-forms"; }
                if ((sandbox & sandbox.allowScripts) != 0) { if (str.Length > 0) str += " "; str += "allow-scripts"; }
                yield return " sandbox=" + attributeValue(str);
            }
            if (seamless) yield return " seamless";
            if (width != null) { yield return " width="; yield return attributeValue(width.ToString()); }
            if (height != null) { yield return " height="; yield return attributeValue(height.ToString()); }
            var baseAttrs = base.enumerateAttributes();
            if (baseAttrs != null)
                foreach (var obj in baseAttrs)
                    yield return obj;
        }
    }
    public sealed class IMG : HtmlTag
    {
        public IMG() : base() { }
        public IMG(params object[] contents) : base(contents) { }
        public override string TagName { get { return "img"; } }
        public override bool EndTag { get { return false; } }
        public string alt;
        public string src;
        public cors crossorigin;
        public string usemap;
        public bool ismap;
        public int? width;
        public int? height;
        /// <summary>Stringifies the attributes on this tag.</summary>
        protected override IEnumerable<string> enumerateAttributes()
        {
            if (alt != null) { yield return " alt="; yield return attributeValue(alt); }
            if (src != null) { yield return " src="; yield return attributeValue(src); }
            switch (crossorigin) { case cors.anonymous: yield return " crossorigin=anonymous"; break; case cors.useCredentials: yield return " crossorigin=use-credentials"; break; }
            if (usemap != null) { yield return " usemap="; yield return attributeValue(usemap); }
            if (ismap) yield return " ismap";
            if (width != null) { yield return " width="; yield return attributeValue(width.ToString()); }
            if (height != null) { yield return " height="; yield return attributeValue(height.ToString()); }
            var baseAttrs = base.enumerateAttributes();
            if (baseAttrs != null)
                foreach (var obj in baseAttrs)
                    yield return obj;
        }
    }
    public sealed class INPUT : HtmlTag
    {
        public INPUT() : base() { }
        public INPUT(params object[] contents) : base(contents) { }
        public override string TagName { get { return "input"; } }
        public override bool EndTag { get { return false; } }
        public string accept;
        public string alt;
        public autocomplete autocomplete;
        public bool autofocus;
        public bool checked_;
        public string dirname;
        public bool disabled;
        public string form;
        public string formaction;
        public enctype formenctype;
        public method formmethod;
        public bool formnovalidate;
        public string formtarget;
        public int? height;
        public string list;
        public string max;
        public int? maxlength;
        public string min;
        public bool multiple;
        public string name;
        public string pattern;
        public string placeholder;
        public bool readonly_;
        public bool required;
        public int? size;
        public string src;
        public string step;
        public itype type;
        public string value;
        public int? width;
        /// <summary>Stringifies the attributes on this tag.</summary>
        protected override IEnumerable<string> enumerateAttributes()
        {
            if (accept != null) { yield return " accept="; yield return attributeValue(accept); }
            if (alt != null) { yield return " alt="; yield return attributeValue(alt); }
            switch (autocomplete) { case autocomplete.on: yield return " autocomplete=on"; break; case autocomplete.off: yield return " autocomplete=off"; break; }
            if (autofocus) yield return " autofocus";
            if (checked_) yield return " checked";
            if (dirname != null) { yield return " dirname="; yield return attributeValue(dirname); }
            if (disabled) yield return " disabled";
            if (form != null) { yield return " form="; yield return attributeValue(form); }
            if (formaction != null) { yield return " formaction="; yield return attributeValue(formaction); }
            switch (formenctype) { case enctype.application_xWwwFormUrlencoded: yield return " formenctype=application/x-www-form-urlencoded"; break; case enctype.multipart_formData: yield return " formenctype=multipart/form-data"; break; case enctype.text_plain: yield return " formenctype=text/plain"; break; }
            switch (formmethod) { case method.get: yield return " formmethod=get"; break; case method.post: yield return " formmethod=post"; break; }
            if (formnovalidate) yield return " formnovalidate";
            if (formtarget != null) { yield return " formtarget="; yield return attributeValue(formtarget); }
            if (height != null) { yield return " height="; yield return attributeValue(height.ToString()); }
            if (list != null) { yield return " list="; yield return attributeValue(list); }
            if (max != null) { yield return " max="; yield return attributeValue(max); }
            if (maxlength != null) { yield return " maxlength="; yield return attributeValue(maxlength.ToString()); }
            if (min != null) { yield return " min="; yield return attributeValue(min); }
            if (multiple) yield return " multiple";
            if (name != null) { yield return " name="; yield return attributeValue(name); }
            if (pattern != null) { yield return " pattern="; yield return attributeValue(pattern); }
            if (placeholder != null) { yield return " placeholder="; yield return attributeValue(placeholder); }
            if (readonly_) yield return " readonly";
            if (required) yield return " required";
            if (size != null) { yield return " size="; yield return attributeValue(size.ToString()); }
            if (src != null) { yield return " src="; yield return attributeValue(src); }
            if (step != null) { yield return " step="; yield return attributeValue(step); }
            switch (type) { case itype.hidden: yield return " type=hidden"; break; case itype.text: yield return " type=text"; break; case itype.search: yield return " type=search"; break; case itype.tel: yield return " type=tel"; break; case itype.url: yield return " type=url"; break; case itype.email: yield return " type=email"; break; case itype.password: yield return " type=password"; break; case itype.datetime: yield return " type=datetime"; break; case itype.date: yield return " type=date"; break; case itype.month: yield return " type=month"; break; case itype.week: yield return " type=week"; break; case itype.time: yield return " type=time"; break; case itype.datetimeLocal: yield return " type=datetime-local"; break; case itype.number: yield return " type=number"; break; case itype.range: yield return " type=range"; break; case itype.color: yield return " type=color"; break; case itype.checkbox: yield return " type=checkbox"; break; case itype.radio: yield return " type=radio"; break; case itype.file: yield return " type=file"; break; case itype.submit: yield return " type=submit"; break; case itype.image: yield return " type=image"; break; case itype.reset: yield return " type=reset"; break; case itype.button: yield return " type=button"; break; }
            if (value != null) { yield return " value="; yield return attributeValue(value); }
            if (width != null) { yield return " width="; yield return attributeValue(width.ToString()); }
            var baseAttrs = base.enumerateAttributes();
            if (baseAttrs != null)
                foreach (var obj in baseAttrs)
                    yield return obj;
        }
    }
    public sealed class INS : HtmlTag
    {
        public INS() : base() { }
        public INS(params object[] contents) : base(contents) { }
        public override string TagName { get { return "ins"; } }
        public string cite;
        public string datetime;
        /// <summary>Stringifies the attributes on this tag.</summary>
        protected override IEnumerable<string> enumerateAttributes()
        {
            if (cite != null) { yield return " cite="; yield return attributeValue(cite); }
            if (datetime != null) { yield return " datetime="; yield return attributeValue(datetime); }
            var baseAttrs = base.enumerateAttributes();
            if (baseAttrs != null)
                foreach (var obj in baseAttrs)
                    yield return obj;
        }
    }
    public sealed class KBD : HtmlTag
    {
        public KBD() : base() { }
        public KBD(params object[] contents) : base(contents) { }
        public override string TagName { get { return "kbd"; } }
        /// <summary>Stringifies the attributes on this tag.</summary>
        protected override IEnumerable<string> enumerateAttributes()
        {
            
            var baseAttrs = base.enumerateAttributes();
            if (baseAttrs != null)
                foreach (var obj in baseAttrs)
                    yield return obj;
        }
    }
    public sealed class KEYGEN : HtmlTag
    {
        public KEYGEN() : base() { }
        public KEYGEN(params object[] contents) : base(contents) { }
        public override string TagName { get { return "keygen"; } }
        public override bool EndTag { get { return false; } }
        public bool autofocus;
        public string challenge;
        public bool disabled;
        public string form;
        public keytype keytype;
        public string name;
        /// <summary>Stringifies the attributes on this tag.</summary>
        protected override IEnumerable<string> enumerateAttributes()
        {
            if (autofocus) yield return " autofocus";
            if (challenge != null) { yield return " challenge="; yield return attributeValue(challenge); }
            if (disabled) yield return " disabled";
            if (form != null) { yield return " form="; yield return attributeValue(form); }
            switch (keytype) { case keytype.rsa: yield return " keytype=rsa"; break; }
            if (name != null) { yield return " name="; yield return attributeValue(name); }
            var baseAttrs = base.enumerateAttributes();
            if (baseAttrs != null)
                foreach (var obj in baseAttrs)
                    yield return obj;
        }
    }
    public sealed class LABEL : HtmlTag
    {
        public LABEL() : base() { }
        public LABEL(params object[] contents) : base(contents) { }
        public override string TagName { get { return "label"; } }
        public string form;
        public string for_;
        /// <summary>Stringifies the attributes on this tag.</summary>
        protected override IEnumerable<string> enumerateAttributes()
        {
            if (form != null) { yield return " form="; yield return attributeValue(form); }
            if (for_ != null) { yield return " for="; yield return attributeValue(for_); }
            var baseAttrs = base.enumerateAttributes();
            if (baseAttrs != null)
                foreach (var obj in baseAttrs)
                    yield return obj;
        }
    }
    public sealed class LEGEND : HtmlTag
    {
        public LEGEND() : base() { }
        public LEGEND(params object[] contents) : base(contents) { }
        public override string TagName { get { return "legend"; } }
        /// <summary>Stringifies the attributes on this tag.</summary>
        protected override IEnumerable<string> enumerateAttributes()
        {
            
            var baseAttrs = base.enumerateAttributes();
            if (baseAttrs != null)
                foreach (var obj in baseAttrs)
                    yield return obj;
        }
    }
    public sealed class LI : HtmlTag
    {
        public LI() : base() { }
        public LI(params object[] contents) : base(contents) { }
        public override string TagName { get { return "li"; } }
        public override bool EndTag { get { return false; } }
        public int? value;
        /// <summary>Stringifies the attributes on this tag.</summary>
        protected override IEnumerable<string> enumerateAttributes()
        {
            if (value != null) { yield return " value="; yield return attributeValue(value.ToString()); }
            var baseAttrs = base.enumerateAttributes();
            if (baseAttrs != null)
                foreach (var obj in baseAttrs)
                    yield return obj;
        }
    }
    public sealed class LINK : HtmlTag
    {
        public LINK() : base() { }
        public LINK(params object[] contents) : base(contents) { }
        public override string TagName { get { return "link"; } }
        public override bool EndTag { get { return false; } }
        public string href;
        public string rel;
        public string media;
        public string hreflang;
        public string type;
        public string sizes;
        /// <summary>Stringifies the attributes on this tag.</summary>
        protected override IEnumerable<string> enumerateAttributes()
        {
            if (href != null) { yield return " href="; yield return attributeValue(href); }
            if (rel != null) { yield return " rel="; yield return attributeValue(rel); }
            if (media != null) { yield return " media="; yield return attributeValue(media); }
            if (hreflang != null) { yield return " hreflang="; yield return attributeValue(hreflang); }
            if (type != null) { yield return " type="; yield return attributeValue(type); }
            if (sizes != null) { yield return " sizes="; yield return attributeValue(sizes); }
            var baseAttrs = base.enumerateAttributes();
            if (baseAttrs != null)
                foreach (var obj in baseAttrs)
                    yield return obj;
        }
    }
    public sealed class MAP : HtmlTag
    {
        public MAP() : base() { }
        public MAP(params object[] contents) : base(contents) { }
        public override string TagName { get { return "map"; } }
        public string name;
        /// <summary>Stringifies the attributes on this tag.</summary>
        protected override IEnumerable<string> enumerateAttributes()
        {
            if (name != null) { yield return " name="; yield return attributeValue(name); }
            var baseAttrs = base.enumerateAttributes();
            if (baseAttrs != null)
                foreach (var obj in baseAttrs)
                    yield return obj;
        }
    }
    public sealed class MARK : HtmlTag
    {
        public MARK() : base() { }
        public MARK(params object[] contents) : base(contents) { }
        public override string TagName { get { return "mark"; } }
        /// <summary>Stringifies the attributes on this tag.</summary>
        protected override IEnumerable<string> enumerateAttributes()
        {
            
            var baseAttrs = base.enumerateAttributes();
            if (baseAttrs != null)
                foreach (var obj in baseAttrs)
                    yield return obj;
        }
    }
    public sealed class MENU : HtmlTag
    {
        public MENU() : base() { }
        public MENU(params object[] contents) : base(contents) { }
        public override string TagName { get { return "menu"; } }
        public mtype type;
        public string label;
        /// <summary>Stringifies the attributes on this tag.</summary>
        protected override IEnumerable<string> enumerateAttributes()
        {
            switch (type) { case mtype.context: yield return " type=context"; break; case mtype.toolbar: yield return " type=toolbar"; break; }
            if (label != null) { yield return " label="; yield return attributeValue(label); }
            var baseAttrs = base.enumerateAttributes();
            if (baseAttrs != null)
                foreach (var obj in baseAttrs)
                    yield return obj;
        }
    }
    public sealed class META : HtmlTag
    {
        public META() : base() { }
        public META(params object[] contents) : base(contents) { }
        public override string TagName { get { return "meta"; } }
        public override bool EndTag { get { return false; } }
        public string name;
        public string httpEquiv;
        public string content;
        public string charset;
        /// <summary>Stringifies the attributes on this tag.</summary>
        protected override IEnumerable<string> enumerateAttributes()
        {
            if (name != null) { yield return " name="; yield return attributeValue(name); }
            if (httpEquiv != null) { yield return " http-equiv="; yield return attributeValue(httpEquiv); }
            if (content != null) { yield return " content="; yield return attributeValue(content); }
            if (charset != null) { yield return " charset="; yield return attributeValue(charset); }
            var baseAttrs = base.enumerateAttributes();
            if (baseAttrs != null)
                foreach (var obj in baseAttrs)
                    yield return obj;
        }
    }
    public sealed class METER : HtmlTag
    {
        public METER() : base() { }
        public METER(params object[] contents) : base(contents) { }
        public override string TagName { get { return "meter"; } }
        public double value;
        public double? min;
        public double? max;
        public double? low;
        public double? high;
        public double? optimum;
        /// <summary>Stringifies the attributes on this tag.</summary>
        protected override IEnumerable<string> enumerateAttributes()
        {
            yield return " value="; yield return attributeValue(value.ToString());
            if (min != null) { yield return " min="; yield return attributeValue(min.ToString()); }
            if (max != null) { yield return " max="; yield return attributeValue(max.ToString()); }
            if (low != null) { yield return " low="; yield return attributeValue(low.ToString()); }
            if (high != null) { yield return " high="; yield return attributeValue(high.ToString()); }
            if (optimum != null) { yield return " optimum="; yield return attributeValue(optimum.ToString()); }
            var baseAttrs = base.enumerateAttributes();
            if (baseAttrs != null)
                foreach (var obj in baseAttrs)
                    yield return obj;
        }
    }
    public sealed class NAV : HtmlTag
    {
        public NAV() : base() { }
        public NAV(params object[] contents) : base(contents) { }
        public override string TagName { get { return "nav"; } }
        /// <summary>Stringifies the attributes on this tag.</summary>
        protected override IEnumerable<string> enumerateAttributes()
        {
            
            var baseAttrs = base.enumerateAttributes();
            if (baseAttrs != null)
                foreach (var obj in baseAttrs)
                    yield return obj;
        }
    }
    public sealed class NOSCRIPT : HtmlTag
    {
        public NOSCRIPT() : base() { }
        public NOSCRIPT(params object[] contents) : base(contents) { }
        public override string TagName { get { return "noscript"; } }
        /// <summary>Stringifies the attributes on this tag.</summary>
        protected override IEnumerable<string> enumerateAttributes()
        {
            
            var baseAttrs = base.enumerateAttributes();
            if (baseAttrs != null)
                foreach (var obj in baseAttrs)
                    yield return obj;
        }
    }
    public sealed class OBJECT : HtmlTag
    {
        public OBJECT() : base() { }
        public OBJECT(params object[] contents) : base(contents) { }
        public override string TagName { get { return "object"; } }
        public string data;
        public string type;
        public bool typemustmatch;
        public string name;
        public string usemap;
        public string form;
        public int? width;
        public int? height;
        /// <summary>Stringifies the attributes on this tag.</summary>
        protected override IEnumerable<string> enumerateAttributes()
        {
            if (data != null) { yield return " data="; yield return attributeValue(data); }
            if (type != null) { yield return " type="; yield return attributeValue(type); }
            if (typemustmatch) yield return " typemustmatch";
            if (name != null) { yield return " name="; yield return attributeValue(name); }
            if (usemap != null) { yield return " usemap="; yield return attributeValue(usemap); }
            if (form != null) { yield return " form="; yield return attributeValue(form); }
            if (width != null) { yield return " width="; yield return attributeValue(width.ToString()); }
            if (height != null) { yield return " height="; yield return attributeValue(height.ToString()); }
            var baseAttrs = base.enumerateAttributes();
            if (baseAttrs != null)
                foreach (var obj in baseAttrs)
                    yield return obj;
        }
    }
    public sealed class OL : HtmlTag
    {
        public OL() : base() { }
        public OL(params object[] contents) : base(contents) { }
        public override string TagName { get { return "ol"; } }
        public bool reversed;
        public int? start;
        /// <summary>Stringifies the attributes on this tag.</summary>
        protected override IEnumerable<string> enumerateAttributes()
        {
            if (reversed) yield return " reversed";
            if (start != null) { yield return " start="; yield return attributeValue(start.ToString()); }
            var baseAttrs = base.enumerateAttributes();
            if (baseAttrs != null)
                foreach (var obj in baseAttrs)
                    yield return obj;
        }
    }
    public sealed class OPTGROUP : HtmlTag
    {
        public OPTGROUP() : base() { }
        public OPTGROUP(params object[] contents) : base(contents) { }
        public override string TagName { get { return "optgroup"; } }
        public bool disabled;
        public string label;
        /// <summary>Stringifies the attributes on this tag.</summary>
        protected override IEnumerable<string> enumerateAttributes()
        {
            if (disabled) yield return " disabled";
            if (label != null) { yield return " label="; yield return attributeValue(label); }
            var baseAttrs = base.enumerateAttributes();
            if (baseAttrs != null)
                foreach (var obj in baseAttrs)
                    yield return obj;
        }
    }
    public sealed class OPTION : HtmlTag
    {
        public OPTION() : base() { }
        public OPTION(params object[] contents) : base(contents) { }
        public override string TagName { get { return "option"; } }
        public override bool EndTag { get { return false; } }
        public bool disabled;
        public string label;
        public bool selected;
        public string value;
        /// <summary>Stringifies the attributes on this tag.</summary>
        protected override IEnumerable<string> enumerateAttributes()
        {
            if (disabled) yield return " disabled";
            if (label != null) { yield return " label="; yield return attributeValue(label); }
            if (selected) yield return " selected";
            if (value != null) { yield return " value="; yield return attributeValue(value); }
            var baseAttrs = base.enumerateAttributes();
            if (baseAttrs != null)
                foreach (var obj in baseAttrs)
                    yield return obj;
        }
    }
    public sealed class OUTPUT : HtmlTag
    {
        public OUTPUT() : base() { }
        public OUTPUT(params object[] contents) : base(contents) { }
        public override string TagName { get { return "output"; } }
        public string for_;
        public string form;
        public string name;
        /// <summary>Stringifies the attributes on this tag.</summary>
        protected override IEnumerable<string> enumerateAttributes()
        {
            if (for_ != null) { yield return " for="; yield return attributeValue(for_); }
            if (form != null) { yield return " form="; yield return attributeValue(form); }
            if (name != null) { yield return " name="; yield return attributeValue(name); }
            var baseAttrs = base.enumerateAttributes();
            if (baseAttrs != null)
                foreach (var obj in baseAttrs)
                    yield return obj;
        }
    }
    public sealed class P : HtmlTag
    {
        public P() : base() { }
        public P(params object[] contents) : base(contents) { }
        public override string TagName { get { return "p"; } }
        /// <summary>Stringifies the attributes on this tag.</summary>
        protected override IEnumerable<string> enumerateAttributes()
        {
            
            var baseAttrs = base.enumerateAttributes();
            if (baseAttrs != null)
                foreach (var obj in baseAttrs)
                    yield return obj;
        }
    }
    public sealed class PARAM : HtmlTag
    {
        public PARAM() : base() { }
        public PARAM(params object[] contents) : base(contents) { }
        public override string TagName { get { return "param"; } }
        public override bool EndTag { get { return false; } }
        public string name;
        public string value;
        /// <summary>Stringifies the attributes on this tag.</summary>
        protected override IEnumerable<string> enumerateAttributes()
        {
            if (name != null) { yield return " name="; yield return attributeValue(name); }
            if (value != null) { yield return " value="; yield return attributeValue(value); }
            var baseAttrs = base.enumerateAttributes();
            if (baseAttrs != null)
                foreach (var obj in baseAttrs)
                    yield return obj;
        }
    }
    public sealed class PRE : HtmlTag
    {
        public PRE() : base() { }
        public PRE(params object[] contents) : base(contents) { }
        public override string TagName { get { return "pre"; } }
        /// <summary>Stringifies the attributes on this tag.</summary>
        protected override IEnumerable<string> enumerateAttributes()
        {
            
            var baseAttrs = base.enumerateAttributes();
            if (baseAttrs != null)
                foreach (var obj in baseAttrs)
                    yield return obj;
        }
    }
    public sealed class PROGRESS : HtmlTag
    {
        public PROGRESS() : base() { }
        public PROGRESS(params object[] contents) : base(contents) { }
        public override string TagName { get { return "progress"; } }
        public double? value;
        public double? max;
        /// <summary>Stringifies the attributes on this tag.</summary>
        protected override IEnumerable<string> enumerateAttributes()
        {
            if (value != null) { yield return " value="; yield return attributeValue(value.ToString()); }
            if (max != null) { yield return " max="; yield return attributeValue(max.ToString()); }
            var baseAttrs = base.enumerateAttributes();
            if (baseAttrs != null)
                foreach (var obj in baseAttrs)
                    yield return obj;
        }
    }
    public sealed class Q : HtmlTag
    {
        public Q() : base() { }
        public Q(params object[] contents) : base(contents) { }
        public override string TagName { get { return "q"; } }
        public string cite;
        /// <summary>Stringifies the attributes on this tag.</summary>
        protected override IEnumerable<string> enumerateAttributes()
        {
            if (cite != null) { yield return " cite="; yield return attributeValue(cite); }
            var baseAttrs = base.enumerateAttributes();
            if (baseAttrs != null)
                foreach (var obj in baseAttrs)
                    yield return obj;
        }
    }
    public sealed class RP : HtmlTag
    {
        public RP() : base() { }
        public RP(params object[] contents) : base(contents) { }
        public override string TagName { get { return "rp"; } }
        public override bool EndTag { get { return false; } }
        /// <summary>Stringifies the attributes on this tag.</summary>
        protected override IEnumerable<string> enumerateAttributes()
        {
            
            var baseAttrs = base.enumerateAttributes();
            if (baseAttrs != null)
                foreach (var obj in baseAttrs)
                    yield return obj;
        }
    }
    public sealed class RT : HtmlTag
    {
        public RT() : base() { }
        public RT(params object[] contents) : base(contents) { }
        public override string TagName { get { return "rt"; } }
        public override bool EndTag { get { return false; } }
        /// <summary>Stringifies the attributes on this tag.</summary>
        protected override IEnumerable<string> enumerateAttributes()
        {
            
            var baseAttrs = base.enumerateAttributes();
            if (baseAttrs != null)
                foreach (var obj in baseAttrs)
                    yield return obj;
        }
    }
    public sealed class RUBY : HtmlTag
    {
        public RUBY() : base() { }
        public RUBY(params object[] contents) : base(contents) { }
        public override string TagName { get { return "ruby"; } }
        /// <summary>Stringifies the attributes on this tag.</summary>
        protected override IEnumerable<string> enumerateAttributes()
        {
            
            var baseAttrs = base.enumerateAttributes();
            if (baseAttrs != null)
                foreach (var obj in baseAttrs)
                    yield return obj;
        }
    }
    public sealed class S : HtmlTag
    {
        public S() : base() { }
        public S(params object[] contents) : base(contents) { }
        public override string TagName { get { return "s"; } }
        /// <summary>Stringifies the attributes on this tag.</summary>
        protected override IEnumerable<string> enumerateAttributes()
        {
            
            var baseAttrs = base.enumerateAttributes();
            if (baseAttrs != null)
                foreach (var obj in baseAttrs)
                    yield return obj;
        }
    }
    public sealed class SAMP : HtmlTag
    {
        public SAMP() : base() { }
        public SAMP(params object[] contents) : base(contents) { }
        public override string TagName { get { return "samp"; } }
        /// <summary>Stringifies the attributes on this tag.</summary>
        protected override IEnumerable<string> enumerateAttributes()
        {
            
            var baseAttrs = base.enumerateAttributes();
            if (baseAttrs != null)
                foreach (var obj in baseAttrs)
                    yield return obj;
        }
    }
    public sealed class SCRIPT : HtmlTag
    {
        public SCRIPT() : base() { }
        public SCRIPT(params object[] contents) : base(contents) { }
        public override string TagName { get { return "script"; } }
        public string src;
        public bool async;
        public bool defer;
        public string type;
        public string charset;
        /// <summary>Stringifies the attributes on this tag.</summary>
        protected override IEnumerable<string> enumerateAttributes()
        {
            if (src != null) { yield return " src="; yield return attributeValue(src); }
            if (async) yield return " async";
            if (defer) yield return " defer";
            if (type != null) { yield return " type="; yield return attributeValue(type); }
            if (charset != null) { yield return " charset="; yield return attributeValue(charset); }
            var baseAttrs = base.enumerateAttributes();
            if (baseAttrs != null)
                foreach (var obj in baseAttrs)
                    yield return obj;
        }
    }
    public sealed class SECTION : HtmlTag
    {
        public SECTION() : base() { }
        public SECTION(params object[] contents) : base(contents) { }
        public override string TagName { get { return "section"; } }
        /// <summary>Stringifies the attributes on this tag.</summary>
        protected override IEnumerable<string> enumerateAttributes()
        {
            
            var baseAttrs = base.enumerateAttributes();
            if (baseAttrs != null)
                foreach (var obj in baseAttrs)
                    yield return obj;
        }
    }
    public sealed class SELECT : HtmlTag
    {
        public SELECT() : base() { }
        public SELECT(params object[] contents) : base(contents) { }
        public override string TagName { get { return "select"; } }
        public bool autofocus;
        public bool disabled;
        public string form;
        public bool multiple;
        public string name;
        public bool required;
        public int? size;
        /// <summary>Stringifies the attributes on this tag.</summary>
        protected override IEnumerable<string> enumerateAttributes()
        {
            if (autofocus) yield return " autofocus";
            if (disabled) yield return " disabled";
            if (form != null) { yield return " form="; yield return attributeValue(form); }
            if (multiple) yield return " multiple";
            if (name != null) { yield return " name="; yield return attributeValue(name); }
            if (required) yield return " required";
            if (size != null) { yield return " size="; yield return attributeValue(size.ToString()); }
            var baseAttrs = base.enumerateAttributes();
            if (baseAttrs != null)
                foreach (var obj in baseAttrs)
                    yield return obj;
        }
    }
    public sealed class SMALL : HtmlTag
    {
        public SMALL() : base() { }
        public SMALL(params object[] contents) : base(contents) { }
        public override string TagName { get { return "small"; } }
        /// <summary>Stringifies the attributes on this tag.</summary>
        protected override IEnumerable<string> enumerateAttributes()
        {
            
            var baseAttrs = base.enumerateAttributes();
            if (baseAttrs != null)
                foreach (var obj in baseAttrs)
                    yield return obj;
        }
    }
    public sealed class SOURCE : HtmlTag
    {
        public SOURCE() : base() { }
        public SOURCE(params object[] contents) : base(contents) { }
        public override string TagName { get { return "source"; } }
        public override bool EndTag { get { return false; } }
        public string src;
        public string type;
        public string media;
        /// <summary>Stringifies the attributes on this tag.</summary>
        protected override IEnumerable<string> enumerateAttributes()
        {
            if (src != null) { yield return " src="; yield return attributeValue(src); }
            if (type != null) { yield return " type="; yield return attributeValue(type); }
            if (media != null) { yield return " media="; yield return attributeValue(media); }
            var baseAttrs = base.enumerateAttributes();
            if (baseAttrs != null)
                foreach (var obj in baseAttrs)
                    yield return obj;
        }
    }
    public sealed class SPAN : HtmlTag
    {
        public SPAN() : base() { }
        public SPAN(params object[] contents) : base(contents) { }
        public override string TagName { get { return "span"; } }
        /// <summary>Stringifies the attributes on this tag.</summary>
        protected override IEnumerable<string> enumerateAttributes()
        {
            
            var baseAttrs = base.enumerateAttributes();
            if (baseAttrs != null)
                foreach (var obj in baseAttrs)
                    yield return obj;
        }
    }
    public sealed class STRONG : HtmlTag
    {
        public STRONG() : base() { }
        public STRONG(params object[] contents) : base(contents) { }
        public override string TagName { get { return "strong"; } }
        /// <summary>Stringifies the attributes on this tag.</summary>
        protected override IEnumerable<string> enumerateAttributes()
        {
            
            var baseAttrs = base.enumerateAttributes();
            if (baseAttrs != null)
                foreach (var obj in baseAttrs)
                    yield return obj;
        }
    }
    public sealed class STYLE : HtmlTag
    {
        public STYLE() : base() { }
        public STYLE(params object[] contents) : base(contents) { }
        public override string TagName { get { return "style"; } }
        public string media;
        public string type;
        public bool scoped;
        /// <summary>Stringifies the attributes on this tag.</summary>
        protected override IEnumerable<string> enumerateAttributes()
        {
            if (media != null) { yield return " media="; yield return attributeValue(media); }
            if (type != null) { yield return " type="; yield return attributeValue(type); }
            if (scoped) yield return " scoped";
            var baseAttrs = base.enumerateAttributes();
            if (baseAttrs != null)
                foreach (var obj in baseAttrs)
                    yield return obj;
        }
    }
    public sealed class SUB : HtmlTag
    {
        public SUB() : base() { }
        public SUB(params object[] contents) : base(contents) { }
        public override string TagName { get { return "sub"; } }
        /// <summary>Stringifies the attributes on this tag.</summary>
        protected override IEnumerable<string> enumerateAttributes()
        {
            
            var baseAttrs = base.enumerateAttributes();
            if (baseAttrs != null)
                foreach (var obj in baseAttrs)
                    yield return obj;
        }
    }
    public sealed class SUMMARY : HtmlTag
    {
        public SUMMARY() : base() { }
        public SUMMARY(params object[] contents) : base(contents) { }
        public override string TagName { get { return "summary"; } }
        /// <summary>Stringifies the attributes on this tag.</summary>
        protected override IEnumerable<string> enumerateAttributes()
        {
            
            var baseAttrs = base.enumerateAttributes();
            if (baseAttrs != null)
                foreach (var obj in baseAttrs)
                    yield return obj;
        }
    }
    public sealed class SUP : HtmlTag
    {
        public SUP() : base() { }
        public SUP(params object[] contents) : base(contents) { }
        public override string TagName { get { return "sup"; } }
        /// <summary>Stringifies the attributes on this tag.</summary>
        protected override IEnumerable<string> enumerateAttributes()
        {
            
            var baseAttrs = base.enumerateAttributes();
            if (baseAttrs != null)
                foreach (var obj in baseAttrs)
                    yield return obj;
        }
    }
    public sealed class TABLE : HtmlTag
    {
        public TABLE() : base() { }
        public TABLE(params object[] contents) : base(contents) { }
        public override string TagName { get { return "table"; } }
        public string border;
        /// <summary>Stringifies the attributes on this tag.</summary>
        protected override IEnumerable<string> enumerateAttributes()
        {
            if (border != null) { yield return " border="; yield return attributeValue(border); }
            var baseAttrs = base.enumerateAttributes();
            if (baseAttrs != null)
                foreach (var obj in baseAttrs)
                    yield return obj;
        }
    }
    public sealed class TBODY : HtmlTag
    {
        public TBODY() : base() { }
        public TBODY(params object[] contents) : base(contents) { }
        public override string TagName { get { return "tbody"; } }
        public override bool EndTag { get { return false; } }
        /// <summary>Stringifies the attributes on this tag.</summary>
        protected override IEnumerable<string> enumerateAttributes()
        {
            
            var baseAttrs = base.enumerateAttributes();
            if (baseAttrs != null)
                foreach (var obj in baseAttrs)
                    yield return obj;
        }
    }
    public sealed class TD : HtmlTag
    {
        public TD() : base() { }
        public TD(params object[] contents) : base(contents) { }
        public override string TagName { get { return "td"; } }
        public override bool EndTag { get { return false; } }
        public int? colspan;
        public int? rowspan;
        public string headers;
        /// <summary>Stringifies the attributes on this tag.</summary>
        protected override IEnumerable<string> enumerateAttributes()
        {
            if (colspan != null) { yield return " colspan="; yield return attributeValue(colspan.ToString()); }
            if (rowspan != null) { yield return " rowspan="; yield return attributeValue(rowspan.ToString()); }
            if (headers != null) { yield return " headers="; yield return attributeValue(headers); }
            var baseAttrs = base.enumerateAttributes();
            if (baseAttrs != null)
                foreach (var obj in baseAttrs)
                    yield return obj;
        }
    }
    public sealed class TEXTAREA : HtmlTag
    {
        public TEXTAREA() : base() { }
        public TEXTAREA(params object[] contents) : base(contents) { }
        public override string TagName { get { return "textarea"; } }
        public bool autofocus;
        public int? cols;
        public string dirname;
        public bool disabled;
        public string form;
        public int? maxlength;
        public string name;
        public string placeholder;
        public bool readonly_;
        public bool required;
        public int? rows;
        public wrap wrap;
        /// <summary>Stringifies the attributes on this tag.</summary>
        protected override IEnumerable<string> enumerateAttributes()
        {
            if (autofocus) yield return " autofocus";
            if (cols != null) { yield return " cols="; yield return attributeValue(cols.ToString()); }
            if (dirname != null) { yield return " dirname="; yield return attributeValue(dirname); }
            if (disabled) yield return " disabled";
            if (form != null) { yield return " form="; yield return attributeValue(form); }
            if (maxlength != null) { yield return " maxlength="; yield return attributeValue(maxlength.ToString()); }
            if (name != null) { yield return " name="; yield return attributeValue(name); }
            if (placeholder != null) { yield return " placeholder="; yield return attributeValue(placeholder); }
            if (readonly_) yield return " readonly";
            if (required) yield return " required";
            if (rows != null) { yield return " rows="; yield return attributeValue(rows.ToString()); }
            switch (wrap) { case wrap.soft: yield return " wrap=soft"; break; case wrap.hard: yield return " wrap=hard"; break; }
            var baseAttrs = base.enumerateAttributes();
            if (baseAttrs != null)
                foreach (var obj in baseAttrs)
                    yield return obj;
        }
    }
    public sealed class TFOOT : HtmlTag
    {
        public TFOOT() : base() { }
        public TFOOT(params object[] contents) : base(contents) { }
        public override string TagName { get { return "tfoot"; } }
        public override bool EndTag { get { return false; } }
        /// <summary>Stringifies the attributes on this tag.</summary>
        protected override IEnumerable<string> enumerateAttributes()
        {
            
            var baseAttrs = base.enumerateAttributes();
            if (baseAttrs != null)
                foreach (var obj in baseAttrs)
                    yield return obj;
        }
    }
    public sealed class TH : HtmlTag
    {
        public TH() : base() { }
        public TH(params object[] contents) : base(contents) { }
        public override string TagName { get { return "th"; } }
        public override bool EndTag { get { return false; } }
        public int? colspan;
        public int? rowspan;
        public string headers;
        public scope scope;
        /// <summary>Stringifies the attributes on this tag.</summary>
        protected override IEnumerable<string> enumerateAttributes()
        {
            if (colspan != null) { yield return " colspan="; yield return attributeValue(colspan.ToString()); }
            if (rowspan != null) { yield return " rowspan="; yield return attributeValue(rowspan.ToString()); }
            if (headers != null) { yield return " headers="; yield return attributeValue(headers); }
            switch (scope) { case scope.row: yield return " scope=row"; break; case scope.col: yield return " scope=col"; break; case scope.rowgroup: yield return " scope=rowgroup"; break; case scope.colgroup: yield return " scope=colgroup"; break; case scope.auto: yield return " scope=auto"; break; }
            var baseAttrs = base.enumerateAttributes();
            if (baseAttrs != null)
                foreach (var obj in baseAttrs)
                    yield return obj;
        }
    }
    public sealed class THEAD : HtmlTag
    {
        public THEAD() : base() { }
        public THEAD(params object[] contents) : base(contents) { }
        public override string TagName { get { return "thead"; } }
        public override bool EndTag { get { return false; } }
        /// <summary>Stringifies the attributes on this tag.</summary>
        protected override IEnumerable<string> enumerateAttributes()
        {
            
            var baseAttrs = base.enumerateAttributes();
            if (baseAttrs != null)
                foreach (var obj in baseAttrs)
                    yield return obj;
        }
    }
    public sealed class TIME : HtmlTag
    {
        public TIME() : base() { }
        public TIME(params object[] contents) : base(contents) { }
        public override string TagName { get { return "time"; } }
        public string datetime;
        public bool pubdate;
        /// <summary>Stringifies the attributes on this tag.</summary>
        protected override IEnumerable<string> enumerateAttributes()
        {
            if (datetime != null) { yield return " datetime="; yield return attributeValue(datetime); }
            if (pubdate) yield return " pubdate";
            var baseAttrs = base.enumerateAttributes();
            if (baseAttrs != null)
                foreach (var obj in baseAttrs)
                    yield return obj;
        }
    }
    public sealed class TITLE : HtmlTag
    {
        public TITLE() : base() { }
        public TITLE(params object[] contents) : base(contents) { }
        public override string TagName { get { return "title"; } }
        /// <summary>Stringifies the attributes on this tag.</summary>
        protected override IEnumerable<string> enumerateAttributes()
        {
            
            var baseAttrs = base.enumerateAttributes();
            if (baseAttrs != null)
                foreach (var obj in baseAttrs)
                    yield return obj;
        }
    }
    public sealed class TR : HtmlTag
    {
        public TR() : base() { }
        public TR(params object[] contents) : base(contents) { }
        public override string TagName { get { return "tr"; } }
        public override bool EndTag { get { return false; } }
        /// <summary>Stringifies the attributes on this tag.</summary>
        protected override IEnumerable<string> enumerateAttributes()
        {
            
            var baseAttrs = base.enumerateAttributes();
            if (baseAttrs != null)
                foreach (var obj in baseAttrs)
                    yield return obj;
        }
    }
    public sealed class TRACK : HtmlTag
    {
        public TRACK() : base() { }
        public TRACK(params object[] contents) : base(contents) { }
        public override string TagName { get { return "track"; } }
        public override bool EndTag { get { return false; } }
        public bool default_;
        public kind kind;
        public string label;
        public string src;
        public string srclang;
        /// <summary>Stringifies the attributes on this tag.</summary>
        protected override IEnumerable<string> enumerateAttributes()
        {
            if (default_) yield return " default";
            switch (kind) { case kind.subtitles: yield return " kind=subtitles"; break; case kind.captions: yield return " kind=captions"; break; case kind.descriptions: yield return " kind=descriptions"; break; case kind.chapters: yield return " kind=chapters"; break; case kind.metadata: yield return " kind=metadata"; break; }
            if (label != null) { yield return " label="; yield return attributeValue(label); }
            if (src != null) { yield return " src="; yield return attributeValue(src); }
            if (srclang != null) { yield return " srclang="; yield return attributeValue(srclang); }
            var baseAttrs = base.enumerateAttributes();
            if (baseAttrs != null)
                foreach (var obj in baseAttrs)
                    yield return obj;
        }
    }
    public sealed class U : HtmlTag
    {
        public U() : base() { }
        public U(params object[] contents) : base(contents) { }
        public override string TagName { get { return "u"; } }
        /// <summary>Stringifies the attributes on this tag.</summary>
        protected override IEnumerable<string> enumerateAttributes()
        {
            
            var baseAttrs = base.enumerateAttributes();
            if (baseAttrs != null)
                foreach (var obj in baseAttrs)
                    yield return obj;
        }
    }
    public sealed class UL : HtmlTag
    {
        public UL() : base() { }
        public UL(params object[] contents) : base(contents) { }
        public override string TagName { get { return "ul"; } }
        /// <summary>Stringifies the attributes on this tag.</summary>
        protected override IEnumerable<string> enumerateAttributes()
        {
            
            var baseAttrs = base.enumerateAttributes();
            if (baseAttrs != null)
                foreach (var obj in baseAttrs)
                    yield return obj;
        }
    }
    public sealed class VAR : HtmlTag
    {
        public VAR() : base() { }
        public VAR(params object[] contents) : base(contents) { }
        public override string TagName { get { return "var"; } }
        /// <summary>Stringifies the attributes on this tag.</summary>
        protected override IEnumerable<string> enumerateAttributes()
        {
            
            var baseAttrs = base.enumerateAttributes();
            if (baseAttrs != null)
                foreach (var obj in baseAttrs)
                    yield return obj;
        }
    }
    public sealed class VIDEO : HtmlTag
    {
        public VIDEO() : base() { }
        public VIDEO(params object[] contents) : base(contents) { }
        public override string TagName { get { return "video"; } }
        public string src;
        public cors crossorigin;
        public string poster;
        public preload preload;
        public bool autoplay;
        public string mediagroup;
        public bool loop;
        public bool muted;
        public bool controls;
        public int? width;
        public int? height;
        /// <summary>Stringifies the attributes on this tag.</summary>
        protected override IEnumerable<string> enumerateAttributes()
        {
            if (src != null) { yield return " src="; yield return attributeValue(src); }
            switch (crossorigin) { case cors.anonymous: yield return " crossorigin=anonymous"; break; case cors.useCredentials: yield return " crossorigin=use-credentials"; break; }
            if (poster != null) { yield return " poster="; yield return attributeValue(poster); }
            switch (preload) { case preload.none: yield return " preload=none"; break; case preload.metadata: yield return " preload=metadata"; break; case preload.auto: yield return " preload=auto"; break; }
            if (autoplay) yield return " autoplay";
            if (mediagroup != null) { yield return " mediagroup="; yield return attributeValue(mediagroup); }
            if (loop) yield return " loop";
            if (muted) yield return " muted";
            if (controls) yield return " controls";
            if (width != null) { yield return " width="; yield return attributeValue(width.ToString()); }
            if (height != null) { yield return " height="; yield return attributeValue(height.ToString()); }
            var baseAttrs = base.enumerateAttributes();
            if (baseAttrs != null)
                foreach (var obj in baseAttrs)
                    yield return obj;
        }
    }
    public sealed class WBR : HtmlTag
    {
        public WBR() : base() { }
        public WBR(params object[] contents) : base(contents) { }
        public override string TagName { get { return "wbr"; } }
        public override bool EndTag { get { return false; } }
        /// <summary>Stringifies the attributes on this tag.</summary>
        protected override IEnumerable<string> enumerateAttributes()
        {
            
            var baseAttrs = base.enumerateAttributes();
            if (baseAttrs != null)
                foreach (var obj in baseAttrs)
                    yield return obj;
        }
    }
    /* HTML tags generated code END */
#pragma warning restore 1591    // Missing XML comment for publicly visible type or member
}
