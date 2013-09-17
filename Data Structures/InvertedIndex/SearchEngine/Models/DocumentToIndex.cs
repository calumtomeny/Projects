using System.Collections.Generic;

namespace SearchEngine.Models
{
    public class DocumentToIndex
    {
        public List<string> Words { get; set; } 
        public string DocumentName { get; set; }
    }
}
