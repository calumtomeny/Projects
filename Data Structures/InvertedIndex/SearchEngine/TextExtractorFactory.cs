namespace SearchEngine
{
    using System;

    using SearchEngine.Interfaces;
    using SearchEngine.Models;
    using SearchEngine.TextExtractors;

    internal static class TextExtractorFactory
    {
        static TextExtractorFactory()
        {
            textFileExtractor = new TextFileTextExtractor();
        }

        private static TextFileTextExtractor textFileExtractor;

        /// <summary>
        /// Decides which class to instantiate.
        /// </summary>
        public static ITextExtractor<string> Get(string fileName)
        {
            DocumentType documentType = FileInfo.GetType(fileName);

            switch (documentType)
            {
                case DocumentType.Txt:
                    return textFileExtractor;
                default:
                    throw new NotSupportedException("This file is not supported.");
            }
        }
    }
}
