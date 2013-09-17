namespace SearchEngine.Interfaces
{
    using SearchEngine.Models;

    /// <summary>
    /// The Searcher interface.
    /// </summary>
    public interface ISearcher
    {
        /// <summary>
        /// The search index.
        /// </summary>
        /// <param name="request">
        /// The request.
        /// </param>
        /// <returns>
        /// The <see cref="SearchResult"/>.
        /// </returns>
        SearchResult SearchIndex(SearchRequest request);
    }
}
