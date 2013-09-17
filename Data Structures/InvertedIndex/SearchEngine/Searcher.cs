namespace SearchEngine
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Linq;
    using System.Text.RegularExpressions;

    using SearchEngine.Interfaces;
    using SearchEngine.Models;

    public class Searcher : ISearcher
    {
        public SearchResult SearchIndex(SearchRequest request)
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            string term = request.SearchTerm;

            Regex _findWords = new Regex(@"[A-Za-z]+");


            var words = _findWords.Matches(request.SearchTerm);
            IEnumerable<KeyValuePair<int, List<int>>> rtn = null;

            for (var i = 0; i < words.Count; i++)
            {
                var word = words[i].Value;
                if (request.Index.InvertedIndex.ContainsKey(word))
                {
                    rtn = rtn == null ? request.Index.InvertedIndex[word] : rtn.Intersect(request.Index.InvertedIndex[word]);
                }
                else
                {
                    return new SearchResult();
                }
            }

            rtn = rtn.OrderByDescending(x => x.Value.Count);

            SearchResult result = new SearchResult();
            stopwatch.Stop();
            result.Results = new List<Tuple<string, int>>(rtn.Select(x => new Tuple<string, int>(request.Index.IndexedFiles[x.Key], x.Value.Count))).Take(request.MaxResults).ToList();
            result.TimeTaken = stopwatch.Elapsed;
            return result;
        }
    }
}
