namespace SearchEngine.Interfaces
{
    using SearchEngine.Models;

    public interface IIndexer
    {
        IndexResult IndexFiles(string directoryToIndex);
    }
}
