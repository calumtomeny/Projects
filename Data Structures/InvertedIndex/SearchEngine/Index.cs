namespace SearchEngine
{
    using System.Collections.Generic;
    using System.Linq;

    using PorterStemmerAlgorithm;

    using SearchEngine.Models;

    public class Index
    {
        public Index(bool porterStemming, bool filterStopWords)
        {
            this.stemming = porterStemming;
            this.removeStopWords = filterStopWords;
            this.IndexedFiles = new Dictionary<int, string>();
        }

        private readonly PorterStemmer stemmer = new PorterStemmer();
        private bool stemming;
        private bool removeStopWords;
        private int currentId;
        public int IndexWordCount { get; set; }
        public int IndexFileCount { get; set; }

        /// <summary>
        /// The Index.
        /// </summary>
        public readonly Dictionary<string, Dictionary<int, List<int>>> InvertedIndex = new Dictionary<string, Dictionary<int, List<int>>>();

        public Dictionary<int, string> IndexedFiles { get; set; }  

        /// <summary>
        /// Add entry to the index.
        /// </summary>
        /// <param name="item">
        /// The item.
        /// </param>
        public virtual void AddEntry(DocumentToIndex entry)
        {
            this.InsertIntoIndex(entry);
        }

        private int InsertIntoIndex(DocumentToIndex entry)
        {
            List<string> documentWords = entry.Words;

            IndexFileCount += 1;

            if (removeStopWords)
            {
                documentWords = documentWords.Where(x => !Constants.stopWords.Contains(x)).ToList();
            }

            if (stemming)
            {
                for (int i = 0; i < documentWords.Count; i++)
                {
                    documentWords[i] = stemmer.stemTerm(documentWords[i]);
                }
            }

            for (int i = 0; i < documentWords.Count; i++)
            {
                this.IndexWordCount++;

                if (!this.InvertedIndex.ContainsKey(documentWords[i]))
                {
                    this.InvertedIndex[documentWords[i]] = new Dictionary<int, List<int>>();
                    this.InvertedIndex[documentWords[i]][this.currentId] = new List<int> { i };
                }
                else
                {
                    if (!this.InvertedIndex[documentWords[i]].ContainsKey(this.currentId))
                    {
                        this.InvertedIndex[documentWords[i]][this.currentId] = new List<int> { i };
                    }
                    else
                    {
                        this.InvertedIndex[documentWords[i]][this.currentId].Add(i);  
                    }
                }
            }

            this.IndexedFiles.Add(this.currentId, entry.DocumentName);
            this.currentId++;
            return this.currentId - 1;
        }
    }
}

