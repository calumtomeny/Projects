using System.Collections.Generic;

namespace SearchEngine.Models
{
    public class DocumentWord
    {
        public int DocumentId { get; set; }
        public List<int> WordLocations { get; set; } 
    }
}
