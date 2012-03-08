using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace RT.TagSoup
{
    /// <summary>Abstract base class for HTML tags.</summary>
    /// <remarks>Useful reference: http://simon.html5.org/html-elements</remarks>
    public abstract class HtmlTag : Tag
    {
        /// <summary>Constructor.</summary>
        public HtmlTag() : base() { }
        /// <summary>Constructor.</summary>
        public HtmlTag(params object[] contents) : base(contents) { }

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

    public sealed class STYLELiteral : HtmlTag
    {
        public STYLELiteral(string literal)
            : base()
        {
            if (Regex.IsMatch(literal, @"<!--|-->|</?style\s*>"))
                throw new ArgumentException("Style literal may not contain <!--, -->, <style> or </style>.", "literal");
            Literal = literal;
        }
        public override string TagName { get { return "style"; } }
        public string Literal;
        public override IEnumerable<string> ToEnumerable()
        {
            yield return @"<style type=text/css>";
            yield return Literal;
            yield return @"</style>";
        }
    }

    public sealed class SCRIPTLiteral : HtmlTag
    {
        public SCRIPTLiteral(string literal)
            : base()
        {
            if (Regex.IsMatch(literal,@"<!--|-->|</?script\s*>"))
                throw new ArgumentException("Script literal may not contain <!--, -->, <script> or </script>.", "literal");
            Literal = literal;
        }
        public override string TagName { get { return "script"; } }
        public string Literal;
        public override IEnumerable<string> ToEnumerable()
        {
            yield return @"<script type=text/javascript>";
            yield return Literal;
            yield return @"</script>";
        }
    }

    public sealed class A : HtmlTag
    {
        public A() : base(null) { }
        public A(params object[] contents) : base(contents) { }
        public override string TagName { get { return "a"; } }
        public string href;
        public string target;
        public string ping;
        public string rel;
        public string media;
        public string hreflang;
        public string type;
    }
    public sealed class ABBR : HtmlTag
    {
        public ABBR() : base(null) { }
        public ABBR(params object[] contents) : base(contents) { }
        public override string TagName { get { return "abbr"; } }
    }
    public sealed class ADDRESS : HtmlTag
    {
        public ADDRESS() : base(null) { }
        public ADDRESS(params object[] contents) : base(contents) { }
        public override string TagName { get { return "address"; } }
    }
    public sealed class AREA : HtmlTag
    {
        public AREA() : base(null) { }
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
    }
    public sealed class ARTICLE : HtmlTag
    {
        public ARTICLE() : base(null) { }
        public ARTICLE(params object[] contents) : base(contents) { }
        public override string TagName { get { return "article"; } }
    }
    public sealed class ASIDE : HtmlTag
    {
        public ASIDE() : base(null) { }
        public ASIDE(params object[] contents) : base(contents) { }
        public override string TagName { get { return "aside"; } }
    }
    public sealed class AUDIO : HtmlTag
    {
        public AUDIO() : base(null) { }
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
    }
    public sealed class B : HtmlTag
    {
        public B() : base(null) { }
        public B(params object[] contents) : base(contents) { }
        public override string TagName { get { return "b"; } }
    }
    public sealed class BASE : HtmlTag
    {
        public BASE() : base(null) { }
        public BASE(params object[] contents) : base(contents) { }
        public override string TagName { get { return "base"; } }
        public override bool EndTag { get { return false; } }
        public string href;
        public string target;
    }
    public sealed class BDI : HtmlTag
    {
        public BDI() : base(null) { }
        public BDI(params object[] contents) : base(contents) { }
        public override string TagName { get { return "bdi"; } }
    }
    public sealed class BDO : HtmlTag
    {
        public BDO() : base(null) { }
        public BDO(params object[] contents) : base(contents) { }
        public override string TagName { get { return "bdo"; } }
    }
    public sealed class BLOCKQUOTE : HtmlTag
    {
        public BLOCKQUOTE() : base(null) { }
        public BLOCKQUOTE(params object[] contents) : base(contents) { }
        public override string TagName { get { return "blockquote"; } }
        public string cite;
    }
    public sealed class BODY : HtmlTag
    {
        public BODY() : base(null) { }
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
    }
    public sealed class BR : HtmlTag
    {
        public BR() : base(null) { }
        public BR(params object[] contents) : base(contents) { }
        public override string TagName { get { return "br"; } }
        public override bool EndTag { get { return false; } }
    }
    public sealed class BUTTON : HtmlTag
    {
        public BUTTON() : base(null) { }
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
    }
    public sealed class CANVAS : HtmlTag
    {
        public CANVAS() : base(null) { }
        public CANVAS(params object[] contents) : base(contents) { }
        public override string TagName { get { return "canvas"; } }
        public int? width;
        public int? height;
    }
    public sealed class CAPTION : HtmlTag
    {
        public CAPTION() : base(null) { }
        public CAPTION(params object[] contents) : base(contents) { }
        public override string TagName { get { return "caption"; } }
    }
    public sealed class CITE : HtmlTag
    {
        public CITE() : base(null) { }
        public CITE(params object[] contents) : base(contents) { }
        public override string TagName { get { return "cite"; } }
    }
    public sealed class CODE : HtmlTag
    {
        public CODE() : base(null) { }
        public CODE(params object[] contents) : base(contents) { }
        public override string TagName { get { return "code"; } }
    }
    public sealed class COL : HtmlTag
    {
        public COL() : base(null) { }
        public COL(params object[] contents) : base(contents) { }
        public override string TagName { get { return "col"; } }
        public override bool EndTag { get { return false; } }
        public int? span;
    }
    public sealed class COLGROUP : HtmlTag
    {
        public COLGROUP() : base(null) { }
        public COLGROUP(params object[] contents) : base(contents) { }
        public override string TagName { get { return "colgroup"; } }
        public override bool EndTag { get { return false; } }
        public int? span;
    }
    public sealed class COMMAND : HtmlTag
    {
        public COMMAND() : base(null) { }
        public COMMAND(params object[] contents) : base(contents) { }
        public override string TagName { get { return "command"; } }
        public override bool EndTag { get { return false; } }
        public ctype type;
        public string label;
        public string icon;
        public bool disabled;
        public bool checked_;
        public string radiogroup;
    }
    public sealed class DATALIST : HtmlTag
    {
        public DATALIST() : base(null) { }
        public DATALIST(params object[] contents) : base(contents) { }
        public override string TagName { get { return "datalist"; } }
    }
    public sealed class DD : HtmlTag
    {
        public DD() : base(null) { }
        public DD(params object[] contents) : base(contents) { }
        public override string TagName { get { return "dd"; } }
        public override bool EndTag { get { return false; } }
    }
    public sealed class DEL : HtmlTag
    {
        public DEL() : base(null) { }
        public DEL(params object[] contents) : base(contents) { }
        public override string TagName { get { return "del"; } }
        public string cite;
        public string datetime;
    }
    public sealed class DETAILS : HtmlTag
    {
        public DETAILS() : base(null) { }
        public DETAILS(params object[] contents) : base(contents) { }
        public override string TagName { get { return "details"; } }
        public string open;
    }
    public sealed class DFN : HtmlTag
    {
        public DFN() : base(null) { }
        public DFN(params object[] contents) : base(contents) { }
        public override string TagName { get { return "dfn"; } }
    }
    public sealed class DIV : HtmlTag
    {
        public DIV() : base(null) { }
        public DIV(params object[] contents) : base(contents) { }
        public override string TagName { get { return "div"; } }
    }
    public sealed class DL : HtmlTag
    {
        public DL() : base(null) { }
        public DL(params object[] contents) : base(contents) { }
        public override string TagName { get { return "dl"; } }
    }
    public sealed class DT : HtmlTag
    {
        public DT() : base(null) { }
        public DT(params object[] contents) : base(contents) { }
        public override string TagName { get { return "dt"; } }
        public override bool EndTag { get { return false; } }
    }
    public sealed class EM : HtmlTag
    {
        public EM() : base(null) { }
        public EM(params object[] contents) : base(contents) { }
        public override string TagName { get { return "em"; } }
    }
    public sealed class EMBED : HtmlTag
    {
        public EMBED() : base(null) { }
        public EMBED(params object[] contents) : base(contents) { }
        public override string TagName { get { return "embed"; } }
        public override bool EndTag { get { return false; } }
        public string src;
        public string type;
        public int? width;
        public int? height;
    }
    public sealed class FIELDSET : HtmlTag
    {
        public FIELDSET() : base(null) { }
        public FIELDSET(params object[] contents) : base(contents) { }
        public override string TagName { get { return "fieldset"; } }
        public bool disabled;
        public string form;
        public string name;
    }
    public sealed class FIGCAPTION : HtmlTag
    {
        public FIGCAPTION() : base(null) { }
        public FIGCAPTION(params object[] contents) : base(contents) { }
        public override string TagName { get { return "figcaption"; } }
    }
    public sealed class FIGURE : HtmlTag
    {
        public FIGURE() : base(null) { }
        public FIGURE(params object[] contents) : base(contents) { }
        public override string TagName { get { return "figure"; } }
    }
    public sealed class FOOTER : HtmlTag
    {
        public FOOTER() : base(null) { }
        public FOOTER(params object[] contents) : base(contents) { }
        public override string TagName { get { return "footer"; } }
    }
    public sealed class FORM : HtmlTag
    {
        public FORM() : base(null) { }
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
    }
    public sealed class H1 : HtmlTag
    {
        public H1() : base(null) { }
        public H1(params object[] contents) : base(contents) { }
        public override string TagName { get { return "h1"; } }
    }
    public sealed class H2 : HtmlTag
    {
        public H2() : base(null) { }
        public H2(params object[] contents) : base(contents) { }
        public override string TagName { get { return "h2"; } }
    }
    public sealed class H3 : HtmlTag
    {
        public H3() : base(null) { }
        public H3(params object[] contents) : base(contents) { }
        public override string TagName { get { return "h3"; } }
    }
    public sealed class H4 : HtmlTag
    {
        public H4() : base(null) { }
        public H4(params object[] contents) : base(contents) { }
        public override string TagName { get { return "h4"; } }
    }
    public sealed class H5 : HtmlTag
    {
        public H5() : base(null) { }
        public H5(params object[] contents) : base(contents) { }
        public override string TagName { get { return "h5"; } }
    }
    public sealed class H6 : HtmlTag
    {
        public H6() : base(null) { }
        public H6(params object[] contents) : base(contents) { }
        public override string TagName { get { return "h6"; } }
    }
    public sealed class HEAD : HtmlTag
    {
        public HEAD() : base(null) { }
        public HEAD(params object[] contents) : base(contents) { }
        public override string TagName { get { return "head"; } }
        public override bool EndTag { get { return false; } }
    }
    public sealed class HEADER : HtmlTag
    {
        public HEADER() : base(null) { }
        public HEADER(params object[] contents) : base(contents) { }
        public override string TagName { get { return "header"; } }
    }
    public sealed class HGROUP : HtmlTag
    {
        public HGROUP() : base(null) { }
        public HGROUP(params object[] contents) : base(contents) { }
        public override string TagName { get { return "hgroup"; } }
    }
    public sealed class HR : HtmlTag
    {
        public HR() : base(null) { }
        public HR(params object[] contents) : base(contents) { }
        public override string TagName { get { return "hr"; } }
        public override bool EndTag { get { return false; } }
    }
    public sealed class HTML : HtmlTag
    {
        public HTML() : base(null) { }
        public HTML(params object[] contents) : base(contents) { }
        public override string TagName { get { return "html"; } }
        public override bool StartTag { get { return false; } }
        public override bool EndTag { get { return false; } }
        public string manifest;
        public override IEnumerable<string> ToEnumerable()
        {
            yield return "<!DOCTYPE html>";
            foreach (var item in base.ToEnumerable())
                yield return item;
        }
    }
    public sealed class I : HtmlTag
    {
        public I() : base(null) { }
        public I(params object[] contents) : base(contents) { }
        public override string TagName { get { return "i"; } }
    }
    public sealed class IFRAME : HtmlTag
    {
        public IFRAME() : base(null) { }
        public IFRAME(params object[] contents) : base(contents) { }
        public override string TagName { get { return "iframe"; } }
        public string src;
        public string srcdoc;
        public string name;
        public sandbox sandbox;
        public bool seamless;
        public int? width;
        public int? height;
    }
    public sealed class IMG : HtmlTag
    {
        public IMG() : base(null) { }
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
    }
    public sealed class INPUT : HtmlTag
    {
        public INPUT() : base(null) { }
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
    }
    public sealed class INS : HtmlTag
    {
        public INS() : base(null) { }
        public INS(params object[] contents) : base(contents) { }
        public override string TagName { get { return "ins"; } }
        public string cite;
        public string datetime;
    }
    public sealed class KBD : HtmlTag
    {
        public KBD() : base(null) { }
        public KBD(params object[] contents) : base(contents) { }
        public override string TagName { get { return "kbd"; } }
    }
    public sealed class KEYGEN : HtmlTag
    {
        public KEYGEN() : base(null) { }
        public KEYGEN(params object[] contents) : base(contents) { }
        public override string TagName { get { return "keygen"; } }
        public override bool EndTag { get { return false; } }
        public bool autofocus;
        public string challenge;
        public bool disabled;
        public string form;
        public keytype keytype;
        public string name;
    }
    public sealed class LABEL : HtmlTag
    {
        public LABEL() : base(null) { }
        public LABEL(params object[] contents) : base(contents) { }
        public override string TagName { get { return "label"; } }
        public string form;
        public string for_;
    }
    public sealed class LEGEND : HtmlTag
    {
        public LEGEND() : base(null) { }
        public LEGEND(params object[] contents) : base(contents) { }
        public override string TagName { get { return "legend"; } }
    }
    public sealed class LI : HtmlTag
    {
        public LI() : base(null) { }
        public LI(params object[] contents) : base(contents) { }
        public override string TagName { get { return "li"; } }
        public override bool EndTag { get { return false; } }
        public int? value;
    }
    public sealed class LINK : HtmlTag
    {
        public LINK() : base(null) { }
        public LINK(params object[] contents) : base(contents) { }
        public override string TagName { get { return "link"; } }
        public override bool EndTag { get { return false; } }
        public string href;
        public string rel;
        public string media;
        public string hreflang;
        public string type;
        public string sizes;
    }
    public sealed class MAP : HtmlTag
    {
        public MAP() : base(null) { }
        public MAP(params object[] contents) : base(contents) { }
        public override string TagName { get { return "map"; } }
        public string name;
    }
    public sealed class MARK : HtmlTag
    {
        public MARK() : base(null) { }
        public MARK(params object[] contents) : base(contents) { }
        public override string TagName { get { return "mark"; } }
    }
    public sealed class MENU : HtmlTag
    {
        public MENU() : base(null) { }
        public MENU(params object[] contents) : base(contents) { }
        public override string TagName { get { return "menu"; } }
        public mtype type;
        public string label;
    }
    public sealed class META : HtmlTag
    {
        public META() : base(null) { }
        public META(params object[] contents) : base(contents) { }
        public override string TagName { get { return "meta"; } }
        public override bool EndTag { get { return false; } }
        public string name;
        public string httpEquiv;
        public string content;
        public string charset;
    }
    public sealed class METER : HtmlTag
    {
        public METER() : base(null) { }
        public METER(params object[] contents) : base(contents) { }
        public override string TagName { get { return "meter"; } }
        public double value;
        public double? min;
        public double? max;
        public double? low;
        public double? high;
        public double? optimum;
    }
    public sealed class NAV : HtmlTag
    {
        public NAV() : base(null) { }
        public NAV(params object[] contents) : base(contents) { }
        public override string TagName { get { return "nav"; } }
    }
    public sealed class NOSCRIPT : HtmlTag
    {
        public NOSCRIPT() : base(null) { }
        public NOSCRIPT(params object[] contents) : base(contents) { }
        public override string TagName { get { return "noscript"; } }
    }
    public sealed class OBJECT : HtmlTag
    {
        public OBJECT() : base(null) { }
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
    }
    public sealed class OL : HtmlTag
    {
        public OL() : base(null) { }
        public OL(params object[] contents) : base(contents) { }
        public override string TagName { get { return "ol"; } }
        public bool reversed;
        public int? start;
    }
    public sealed class OPTGROUP : HtmlTag
    {
        public OPTGROUP() : base(null) { }
        public OPTGROUP(params object[] contents) : base(contents) { }
        public override string TagName { get { return "optgroup"; } }
        public bool disabled;
        public string label;
    }
    public sealed class OPTION : HtmlTag
    {
        public OPTION() : base(null) { }
        public OPTION(params object[] contents) : base(contents) { }
        public override string TagName { get { return "option"; } }
        public override bool EndTag { get { return false; } }
        public bool disabled;
        public string label;
        public bool selected;
        public string value;
    }
    public sealed class OUTPUT : HtmlTag
    {
        public OUTPUT() : base(null) { }
        public OUTPUT(params object[] contents) : base(contents) { }
        public override string TagName { get { return "output"; } }
        public string for_;
        public string form;
        public string name;
    }
    public sealed class P : HtmlTag
    {
        public P() : base(null) { }
        public P(params object[] contents) : base(contents) { }
        public override string TagName { get { return "p"; } }
    }
    public sealed class PARAM : HtmlTag
    {
        public PARAM() : base(null) { }
        public PARAM(params object[] contents) : base(contents) { }
        public override string TagName { get { return "param"; } }
        public override bool EndTag { get { return false; } }
        public string name;
        public string value;
    }
    public sealed class PRE : HtmlTag
    {
        public PRE() : base(null) { }
        public PRE(params object[] contents) : base(contents) { }
        public override string TagName { get { return "pre"; } }
    }
    public sealed class PROGRESS : HtmlTag
    {
        public PROGRESS() : base(null) { }
        public PROGRESS(params object[] contents) : base(contents) { }
        public override string TagName { get { return "progress"; } }
        public double? value;
        public double? max;
    }
    public sealed class Q : HtmlTag
    {
        public Q() : base(null) { }
        public Q(params object[] contents) : base(contents) { }
        public override string TagName { get { return "q"; } }
        public string cite;
    }
    public sealed class RP : HtmlTag
    {
        public RP() : base(null) { }
        public RP(params object[] contents) : base(contents) { }
        public override string TagName { get { return "rp"; } }
        public override bool EndTag { get { return false; } }
    }
    public sealed class RT : HtmlTag
    {
        public RT() : base(null) { }
        public RT(params object[] contents) : base(contents) { }
        public override string TagName { get { return "rt"; } }
        public override bool EndTag { get { return false; } }
    }
    public sealed class RUBY : HtmlTag
    {
        public RUBY() : base(null) { }
        public RUBY(params object[] contents) : base(contents) { }
        public override string TagName { get { return "ruby"; } }
    }
    public sealed class S : HtmlTag
    {
        public S() : base(null) { }
        public S(params object[] contents) : base(contents) { }
        public override string TagName { get { return "s"; } }
    }
    public sealed class SAMP : HtmlTag
    {
        public SAMP() : base(null) { }
        public SAMP(params object[] contents) : base(contents) { }
        public override string TagName { get { return "samp"; } }
    }
    public sealed class SCRIPT : HtmlTag
    {
        public SCRIPT() : base(null) { }
        public SCRIPT(params object[] contents) : base(contents) { }
        public override string TagName { get { return "script"; } }
        public string src;
        public bool @async;
        public bool defer;
        public string type;
        public string charset;
    }
    public sealed class SECTION : HtmlTag
    {
        public SECTION() : base(null) { }
        public SECTION(params object[] contents) : base(contents) { }
        public override string TagName { get { return "section"; } }
    }
    public sealed class SELECT : HtmlTag
    {
        public SELECT() : base(null) { }
        public SELECT(params object[] contents) : base(contents) { }
        public override string TagName { get { return "select"; } }
        public bool autofocus;
        public bool disabled;
        public string form;
        public bool multiple;
        public string name;
        public bool required;
        public int? size;
    }
    public sealed class SMALL : HtmlTag
    {
        public SMALL() : base(null) { }
        public SMALL(params object[] contents) : base(contents) { }
        public override string TagName { get { return "small"; } }
    }
    public sealed class SOURCE : HtmlTag
    {
        public SOURCE() : base(null) { }
        public SOURCE(params object[] contents) : base(contents) { }
        public override string TagName { get { return "source"; } }
        public override bool EndTag { get { return false; } }
        public string src;
        public string type;
        public string media;
    }
    public sealed class SPAN : HtmlTag
    {
        public SPAN() : base(null) { }
        public SPAN(params object[] contents) : base(contents) { }
        public override string TagName { get { return "span"; } }
    }
    public sealed class STRONG : HtmlTag
    {
        public STRONG() : base(null) { }
        public STRONG(params object[] contents) : base(contents) { }
        public override string TagName { get { return "strong"; } }
    }
    public sealed class STYLE : HtmlTag
    {
        public STYLE() : base(null) { }
        public STYLE(params object[] contents) : base(contents) { }
        public override string TagName { get { return "style"; } }
        public string media;
        public string type;
        public bool scoped;
    }
    public sealed class SUB : HtmlTag
    {
        public SUB() : base(null) { }
        public SUB(params object[] contents) : base(contents) { }
        public override string TagName { get { return "sub"; } }
    }
    public sealed class SUMMARY : HtmlTag
    {
        public SUMMARY() : base(null) { }
        public SUMMARY(params object[] contents) : base(contents) { }
        public override string TagName { get { return "summary"; } }
    }
    public sealed class SUP : HtmlTag
    {
        public SUP() : base(null) { }
        public SUP(params object[] contents) : base(contents) { }
        public override string TagName { get { return "sup"; } }
    }
    public sealed class TABLE : HtmlTag
    {
        public TABLE() : base(null) { }
        public TABLE(params object[] contents) : base(contents) { }
        public override string TagName { get { return "table"; } }
        public string border;
    }
    public sealed class TBODY : HtmlTag
    {
        public TBODY() : base(null) { }
        public TBODY(params object[] contents) : base(contents) { }
        public override string TagName { get { return "tbody"; } }
        public override bool EndTag { get { return false; } }
    }
    public sealed class TD : HtmlTag
    {
        public TD() : base(null) { }
        public TD(params object[] contents) : base(contents) { }
        public override string TagName { get { return "td"; } }
        public override bool EndTag { get { return false; } }
        public int? colspan;
        public int? rowspan;
        public string headers;
    }
    public sealed class TEXTAREA : HtmlTag
    {
        public TEXTAREA() : base(null) { }
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
    }
    public sealed class TFOOT : HtmlTag
    {
        public TFOOT() : base(null) { }
        public TFOOT(params object[] contents) : base(contents) { }
        public override string TagName { get { return "tfoot"; } }
        public override bool EndTag { get { return false; } }
    }
    public sealed class TH : HtmlTag
    {
        public TH() : base(null) { }
        public TH(params object[] contents) : base(contents) { }
        public override string TagName { get { return "th"; } }
        public override bool EndTag { get { return false; } }
        public int? colspan;
        public int? rowspan;
        public string headers;
        public scope scope;
    }
    public sealed class THEAD : HtmlTag
    {
        public THEAD() : base(null) { }
        public THEAD(params object[] contents) : base(contents) { }
        public override string TagName { get { return "thead"; } }
        public override bool EndTag { get { return false; } }
    }
    public sealed class TIME : HtmlTag
    {
        public TIME() : base(null) { }
        public TIME(params object[] contents) : base(contents) { }
        public override string TagName { get { return "time"; } }
        public string datetime;
        public bool pubdate;
    }
    public sealed class TITLE : HtmlTag
    {
        public TITLE() : base(null) { }
        public TITLE(params object[] contents) : base(contents) { }
        public override string TagName { get { return "title"; } }
    }
    public sealed class TR : HtmlTag
    {
        public TR() : base(null) { }
        public TR(params object[] contents) : base(contents) { }
        public override string TagName { get { return "tr"; } }
        public override bool EndTag { get { return false; } }
    }
    public sealed class TRACK : HtmlTag
    {
        public TRACK() : base(null) { }
        public TRACK(params object[] contents) : base(contents) { }
        public override string TagName { get { return "track"; } }
        public override bool EndTag { get { return false; } }
        public bool default_;
        public kind kind;
        public string label;
        public string src;
        public string srclang;
    }
    public sealed class U : HtmlTag
    {
        public U() : base(null) { }
        public U(params object[] contents) : base(contents) { }
        public override string TagName { get { return "u"; } }
    }
    public sealed class UL : HtmlTag
    {
        public UL() : base(null) { }
        public UL(params object[] contents) : base(contents) { }
        public override string TagName { get { return "ul"; } }
    }
    public sealed class VAR : HtmlTag
    {
        public VAR() : base(null) { }
        public VAR(params object[] contents) : base(contents) { }
        public override string TagName { get { return "var"; } }
    }
    public sealed class VIDEO : HtmlTag
    {
        public VIDEO() : base(null) { }
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
    }
    public sealed class WBR : HtmlTag
    {
        public WBR() : base(null) { }
        public WBR(params object[] contents) : base(contents) { }
        public override string TagName { get { return "wbr"; } }
        public override bool EndTag { get { return false; } }
    }

#pragma warning restore 1591    // Missing XML comment for publicly visible type or member

}
