namespace Project.Core.SourceMonitors
{
    public interface ISourceMonitor<T> where T : class
    {
        IEnumerable<string> Monitor(string path = "");
    }
}