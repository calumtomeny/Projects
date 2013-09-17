namespace SearchEngine.Abstract
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// The abstract extractor.
    /// </summary>
    public class Extractor
    {
        /// <summary>
        /// The clean string.
        /// </summary>
        /// <param name="dirtyString">
        /// The dirty string.
        /// </param>
        /// <returns>
        /// The <see cref="string"/>.
        /// </returns>
        protected string CleanString(string dirtyString)
        {
            return new String(dirtyString.Where(x => char.IsLetterOrDigit(x) || char.IsWhiteSpace(x)).ToArray());
        }

        protected static IEnumerable<string> Split(string text)
        {
            return text.Split(" ".ToCharArray(), StringSplitOptions.RemoveEmptyEntries).Select(x => x.Trim());
        }
    }
}
