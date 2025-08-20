using Project.Core.DTO;

namespace Project.Core.FileStreams
{
    public interface IFileStreaming
    {
        IAsyncEnumerable<Iteration> StreamBytesAsync(string filePath);
    }
}