using Microsoft.Extensions.Options;
using Project.Core.DTO;
using Project.Core.DTO.Configurations;

namespace Project.Core.FileStreams
{
    public class FileStreaming : IFileStreaming
    {
        private const int DEFAULT_BUFFER_SIZE = 4096;
        private readonly IOptions<StreamBuffer> _config;

        public FileStreaming(IOptions<StreamBuffer> config)
        {
            _config = config;
        }
        public async IAsyncEnumerable<Iteration> StreamBytesAsync(string filePath)
        {
            if (string.IsNullOrWhiteSpace(filePath))
                throw new ArgumentException("File path cannot be null or empty.", nameof(filePath));

            if (!File.Exists(filePath))
                throw new FileNotFoundException($"File not found: {filePath}");
            var bufferSize = 0;
            try
            {
                bufferSize = (_config?.Value?.BufferSize > 0)
                    ? _config.Value.BufferSize
                    : DEFAULT_BUFFER_SIZE;
            }
            catch {
                bufferSize = DEFAULT_BUFFER_SIZE;
            }

            using var stream = new FileStream(filePath, FileMode.Open, FileAccess.Read, FileShare.Read, bufferSize, useAsync: true);

            var buffer = new byte[bufferSize];
            int bytesRead;

            while ((bytesRead = await stream.ReadAsync(buffer, 0, buffer.Length)) > 0)
            {
                
                var actualData = new byte[bytesRead];
                Array.Copy(buffer, actualData, bytesRead);
                yield return new Iteration(System.Text.Encoding.UTF8.GetString(actualData), bytesRead==bufferSize ?true:false); 
            }
        }
    }
}
