namespace RT.TagSoup
{
    /// <summary>Contains extension methods for code using RT.TagSoup.</summary>
    public static class Util
    {
        /// <summary>
        ///     Adds a <c>KBD</c> tag to a single character to indicate a keyboard shortcut in a UI.</summary>
        /// <param name="str">
        ///     The string or label to add the shortcut indicator to.</param>
        /// <param name="accel">
        ///     The shortcut key (<c>accesskey</c> attribute).</param>
        public static object Accel(this string str, char accel)
        {
            var pos = str.IndexOf(accel);
            return pos >= 0
                ? new object[] { str.Substring(0, pos), new KBD(accel), str.Substring(pos + 1) }
                : new object[] { str, " (", new KBD(accel), ")" };
        }
    }
}
