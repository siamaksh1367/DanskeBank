using Microsoft.Extensions.Options;
using Project.Core.DTO.Configurations;

namespace Project.Core.SourceMonitors
{
    public class LocalTextFileMonitor : ISourceMonitor<LocalSourceFile>
    {
        private const string VALID_FILE_FORMAT = ".txt";
        private readonly IOptions<LocalSourceFile> _config;

        public LocalTextFileMonitor(IOptions<LocalSourceFile> config)
        {
            _config = config;
        }

        public IEnumerable<string> Monitor(string path = "")
        {
            var effectivePath = !string.IsNullOrWhiteSpace(path) ? path : _config.Value.Path;

            if (!Directory.Exists(effectivePath))
                throw new InvalidOperationException("Expected directory does not exist.");

            var allFiles = Directory.GetFiles(effectivePath);
            return allFiles.Where(f => f.EndsWith(VALID_FILE_FORMAT, StringComparison.OrdinalIgnoreCase)).ToList();
        }
    }
}