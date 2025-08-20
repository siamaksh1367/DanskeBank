using FluentAssertions;
using Microsoft.Extensions.Options;
using Moq;
using Project.Core.DTO.Configurations;
using Project.Core.Engine;
using Project.Core.SourceMonitors;
using Project.Core.TextProcessor;
using Project.Core.Tokenizer.TokenizerFactory;
using System.IO;

namespace Project.Core.Tests;

public class MainProcessorTests
{
    private MainProcessor _mainProcessor;
    private string _testDirectory;

    [SetUp]
    public void Setup()
    {
        _testDirectory = Path.Combine("d:/Files", Guid.NewGuid().ToString());
        Directory.CreateDirectory(_testDirectory);

        var sourceMonitorOptions = new Mock<IOptions<LocalSourceFile>>();
        sourceMonitorOptions.Setup(o => o.Value).Returns(new LocalSourceFile(_testDirectory));
        var mockSourceMonitor = new LocalTextFileMonitor(sourceMonitorOptions.Object);

        var fileStreamsOptions = new Mock<IOptions<StreamBuffer>>();
        fileStreamsOptions.Setup(o => o.Value).Returns(new StreamBuffer(50));
        var mockFilestream = new FileStreams.FileStreaming(fileStreamsOptions.Object);

        var mockTextProcessor = new SimpleTextProcessor(new SimpleTokenizerFactory());

        _mainProcessor = new MainProcessor(mockSourceMonitor, mockFilestream, mockTextProcessor);

        CreateTestFiles();
    }


    private void CreateTestFiles()
    {
        File.WriteAllText(Path.Combine(_testDirectory, "file1.txt"), "Go and  do that thing  more that you do not so well");
        File.WriteAllText(Path.Combine(_testDirectory, "file2.txt"), "I do many things very well  ");
    }

    [Test]
    public async Task ProcessAsync_GivenPoSample_CountProperly()
    {
        var result = await _mainProcessor.ProcessAsync();

        // Asserting the results
        result.Should().NotBeNull();
        result.Should().ContainKey("do").And.ContainValue(3);
        result.Should().ContainKey("that").And.ContainValue(2);
        result.Should().ContainKey("well").And.ContainValue(2);
        result.Should().ContainKey("things").And.ContainValue(1);
        result.Should().ContainKey("many").And.ContainValue(1);
        result.Should().ContainKey("go").And.ContainValue(1);
        result.Should().ContainKey("more").And.ContainValue(1);
        result.Should().ContainKey("thing").And.ContainValue(1);
        result.Should().ContainKey("not").And.ContainValue(1);
        result.Should().ContainKey("you").And.ContainValue(1);
        result.Should().ContainKey("i").And.ContainValue(1);
        result.Should().ContainKey("and").And.ContainValue(1);
        result.Should().ContainKey("very").And.ContainValue(1);
    }

    [TearDown]
    public void TearDown()
    {
        if (Directory.Exists(_testDirectory))
        {
            Directory.Delete(_testDirectory, true);  
        }
    }
}
