using System;
using System.Linq;
using System.Reflection;

namespace RT.TagSoup
{
    static class InternalUtil
    {
        /// <summary>
        ///     Escapes all necessary characters in the specified string so as to make it usable safely in an HTML or XML
        ///     context.</summary>
        /// <param name="input">
        ///     The string to apply HTML or XML escaping to.</param>
        /// <param name="leaveSingleQuotesAlone">
        ///     If <c>true</c>, does not escape single quotes (<c>'</c>, U+0027).</param>
        /// <param name="leaveDoubleQuotesAlone">
        ///     If <c>true</c>, does not escape single quotes (<c>"</c>, U+0022).</param>
        /// <returns>
        ///     The specified string with the necessary HTML or XML escaping applied.</returns>
        public static string HtmlEscape(this string input, bool leaveSingleQuotesAlone = false, bool leaveDoubleQuotesAlone = false)
        {
            if (input == null)
                throw new ArgumentNullException("input");
            var result = input.Replace("&", "&amp;").Replace("<", "&lt;").Replace(">", "&gt;");
            if (!leaveSingleQuotesAlone)
                result = result.Replace("'", "&#39;");
            if (!leaveDoubleQuotesAlone)
                result = result.Replace("\"", "&quot;");
            return result;
        }

        /// <summary>
        ///     Indicates whether one or more instance of the specified attribute type is applied to this member.</summary>
        /// <typeparam name="T">
        ///     The type of attribute to search for.</typeparam>
        /// <param name="member">
        ///     Member whose custom attributes to search.</param>
        /// <param name="inherit">
        ///     Specifies whether to search this member's inheritance chain to find the attributes.</param>
        public static bool IsDefined<T>(this MemberInfo member, bool inherit = false)
        {
            return member.IsDefined(typeof(T), inherit);
        }
    }
}
