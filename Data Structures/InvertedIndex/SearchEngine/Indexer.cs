using System.Collections.Generic;
using System.Linq;

namespace SearchEngine
{
    using System;
    using System.Diagnostics;
    using System.IO;

    using SearchEngine.Interfaces;
    using SearchEngine.Models;

    public class Indexer : IIndexer
    {
        public Indexer(IndexerOptions indexerOptions)
        {
            this.filesNotIndexed = new List<string>();
            this.Index = new Index(indexerOptions.ApplyPorterStemming, indexerOptions.RemoveStopWord);
        }

        public Index Index { get; set; }
        private List<string> filesNotIndexed;

        public Dictionary<int, string> IndexedDocuments { get; set; } 


        public IndexResult IndexFiles(string directoryToIndex)
        {
            if (directoryToIndex == null)
            {
                throw new ArgumentNullException("directoryToIndex");
            }

            if (!Directory.Exists(directoryToIndex))
            {
                throw new DirectoryNotFoundException("The directory specified was not found.");
            }

            string[] files = Directory.GetFiles(directoryToIndex);
            ITextExtractor<string> extractor;

            var stopwatch = new Stopwatch();
            stopwatch.Start();
            foreach (var file in files)
            {
                try
                {
                    extractor = TextExtractorFactory.Get(file);
                    Index.AddEntry(
                        new DocumentToIndex
                            {
                                Words = extractor.ExtractText(file).ToList(),
                                DocumentName = Path.GetFileNameWithoutExtension(file)
                            });
                }
                catch
                {
                    filesNotIndexed.Add(file);
                }
            }

            stopwatch.Stop();

            return new IndexResult
                       {
                           FilesNotIndexed = filesNotIndexed,
                           IndexedFileCount = Index.IndexFileCount,
                           IndexedWordCount = Index.IndexWordCount,
                           TimeTaken = stopwatch.Elapsed
                       };
        }
    }
}
