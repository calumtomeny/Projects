using System.Collections.Generic;

namespace SearchEngine.Interfaces
{
    /// <summary>
    /// The TextExtractor interface.
    /// </summary>
    /// <typeparam name="T">
    /// </typeparam>
    public interface ITextExtractor<T>
    {
        IEnumerable<string> ExtractText(T Subject);
    }
}
