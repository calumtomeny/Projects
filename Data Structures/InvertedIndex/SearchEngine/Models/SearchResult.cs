using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SearchEngine.Models
{
    public class SearchResult
    {
        public SearchResult()
        {
            Results = new List<Tuple<string, int>>();
        }

        public List<Tuple<string, int>> Results {get; set;}

        public TimeSpan TimeTaken { get; set; }
    }
}
