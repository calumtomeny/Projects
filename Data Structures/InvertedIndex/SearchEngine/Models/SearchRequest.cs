using System.Collections.Generic;

namespace SearchEngine.Models
{
    /// <summary>
    /// The index request.
    /// </summary>
    public class SearchRequest
    {
        /// <summary>
        /// Gets or sets the index.
        /// </summary>
        public Index Index { get; set; }

        /// <summary>
        /// Gets or sets the search term.
        /// </summary>
        public string SearchTerm { get; set; }

        /// <summary>
        /// Gets or sets the max results.
        /// </summary>
        public int MaxResults { get; set; }
    }
}
