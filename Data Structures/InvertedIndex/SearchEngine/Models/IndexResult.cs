using System.Collections.Generic;

namespace SearchEngine.Models
{
    using System;

    public class IndexResult
    {
        public int IndexedWordCount { get; set; }
        public int IndexedFileCount { get; set; }
        public List<string> FilesNotIndexed { get; set; }
        public TimeSpan TimeTaken { get; set; }
    }
}
