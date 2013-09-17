namespace Search
{
    using System;
    using System.Diagnostics;
    using System.IO;
    using System.Linq;

    using SearchEngine;
    using SearchEngine.Models;
    using SearchEngine.TextExtractors;

    class Program
    {
        static void Main(string[] args)
        {
            string directoryToIndex = @"X:\FilesToIndex";

            long workingSet = Process.GetCurrentProcess().WorkingSet64;

            var indexer = new Indexer(new IndexerOptions { ApplyPorterStemming = false, RemoveStopWord = false });

            //IndexResult result = indexer.IndexFiles(directoryToIndex);
            //workingSet = Process.GetCurrentProcess().WorkingSet64;
            //Console.WriteLine("Index files without porter stemming or removal of stop words:");
            //Console.WriteLine("Time taken: " + result.TimeTaken);
            //Console.WriteLine("Words indexed: " + result.IndexedWordCount);
            //Console.WriteLine("Memory usage(MB): " + ConvertBytesToMegabytes(workingSet));
            //Console.WriteLine(string.Empty);

            indexer = new Indexer(new IndexerOptions { ApplyPorterStemming = true, RemoveStopWord = true });
            IndexResult result = indexer.IndexFiles(directoryToIndex);
            workingSet = Process.GetCurrentProcess().WorkingSet64;
            Console.WriteLine("Index files with porter stemming and removal of stop words:");
            Console.WriteLine("Time taken: " + result.TimeTaken);
            Console.WriteLine("Words indexed: " + result.IndexedWordCount);
            Console.WriteLine("Memory usage(MB): " + ConvertBytesToMegabytes(workingSet));

            Searcher searcher = new Searcher();
            while (true)
            {
                Console.WriteLine("Search index:");
                SearchResult searchResult = searcher.SearchIndex(new SearchRequest { Index = indexer.Index, SearchTerm = Console.ReadLine(), MaxResults = 1});

                foreach (var r in searchResult.Results)
                {
                    Console.WriteLine("File Name: " + r.Item1 + " Count: " + r.Item2);
                    Console.WriteLine("Time taken to search: " + searchResult.TimeTaken.Milliseconds + "ms");
                }
            }
        }

        static double ConvertBytesToMegabytes(long bytes)
        {
            return (bytes / 1024f) / 1024f;
        }
    }
}
