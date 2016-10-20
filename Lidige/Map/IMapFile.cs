namespace Lidige.Map
{
    public interface IMapFile
    {
        void Load(string filePath);
        string Json { get; }
    }
}