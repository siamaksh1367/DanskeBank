namespace Project.Core.Engine
{
    public interface IMainProcessor
    {
        Task<Dictionary<string, int>> ProcessAsync(string path);
    }
}
