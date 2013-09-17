namespace SearchEngine.TextExtractors
{
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using SearchEngine.Abstract;
    using SearchEngine.Interfaces;

    /// <summary>
    /// The text file text extractor.
    /// </summary>
    public class TextFileTextExtractor : Extractor, ITextExtractor<string>
    {
        public IEnumerable<string> ExtractText(string fileName)
        {
            var streamReader = new StreamReader(fileName);
            var text = streamReader.ReadToEnd();
            text = this.CleanString(text);
            return Split(text);
        }
    }
}