using Project.Core.DTO.Configurations;
using Project.Core.FileStreams;
using Project.Core.SourceMonitors;
using Project.Core.TextProcessor;

namespace Project.Core.Engine
{
    public class MainProcessor : IMainProcessor
    {
        private readonly ISourceMonitor<LocalSourceFile> _sourceMonitor;
        private readonly IFileStreaming _fileStreaming;
        private readonly ITextProcessor _textProcessor;

        public MainProcessor(ISourceMonitor<LocalSourceFile> sourceMonitor, IFileStreaming fileStreaming, ITextProcessor textProcessor)
        {
            _sourceMonitor = sourceMonitor;
            _fileStreaming = fileStreaming;
            _textProcessor = textProcessor;
        }
        public async Task<Dictionary<string, int>> ProcessAsync(string path = "")
        {
            var files = _sourceMonitor.Monitor(path);
            var tasks = files.Select(async file =>
            {
                Dictionary<string, int> localResult = [];
                string passOver = string.Empty;
                var iterations = _fileStreaming.StreamBytesAsync(file);
                await foreach (var iteration in iterations)
                {
                    var text = passOver + iteration.Text;

                    if (iteration.PossibleBrokenWord)
                    {
                        int index = iteration.Text.LastIndexOf(' ');
                        if (index != -1 && index != iteration.Text.Length - 1)
                        {
                            passOver = iteration.Text.Substring(index);
                            text = iteration.Text.Substring(0, index + 1);
                        }
                        else
                        {
                            passOver = string.Empty;
                        }
                    }
                    else
                    {
                        passOver = string.Empty;
                    }

                    localResult = localResult.MergeResults(_textProcessor.Process(text));
                }

                return localResult;
            });

            var allResults = await Task.WhenAll(tasks);
            return allResults.Aggregate(new Dictionary<string, int>(), (acc, next) => acc.MergeResults(next));
        }

    }
}
