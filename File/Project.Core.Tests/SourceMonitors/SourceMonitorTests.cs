using FluentAssertions;
using Microsoft.Extensions.Options;
using Moq;
using Project.Core.DTO.Configurations;

namespace Project.Core.SourceMonitors
{
    public class SourceMonitorTests
    {
        private string _tempDirectory;
        private string _filePath;

        [SetUp]
        public void Setup()
        {
            _tempDirectory = Path.Combine(Path.GetTempPath(), Guid.NewGuid().ToString());
            Directory.CreateDirectory(_tempDirectory);
            _filePath = Path.Combine(_tempDirectory, "testfile.txt");
            File.WriteAllText(_filePath, "Test content");
        }
        [TearDown] public void Teardown() 
        {
            Directory.Delete(_tempDirectory, true);

        }
        [Test]
        public void Monitor_OneFileInLocation_ShouldReturnsFile()
        {
            // Arrange
            var mockOptions = new Mock<IOptions<LocalSourceFile>>();
            mockOptions.Setup(o => o.Value).Returns(new LocalSourceFile (_tempDirectory));

            var sourceMonitor = new LocalTextFileMonitor(mockOptions.Object);

            // Act
            var files = sourceMonitor.Monitor();

            // Assert
            files.Should().NotBeNull();
            files.Should().ContainSingle();
            files.Should().Contain(_filePath);
        }

        [Test]
        public void Monitor_MultipleFileInLocation_ShouldReturnsFiles()
        {
            // Arrange
            var filePath2 = Path.Combine(_tempDirectory, "testfile2.txt");
            File.WriteAllText(filePath2, "Test content2");

            var filePath3 = Path.Combine(_tempDirectory, "testfile3.txt");
            File.WriteAllText(filePath3, "Test content3");

            var mockOptions = new Mock<IOptions<LocalSourceFile>>();
            mockOptions.Setup(o => o.Value).Returns(new LocalSourceFile(_tempDirectory));

            var sourceMonitor = new LocalTextFileMonitor(mockOptions.Object);

            // Act
            var files = sourceMonitor.Monitor();

            // Assert
            files.Should().NotBeNull();
            files.Should().HaveCount(3);
            files.Should().Contain(new[] { _filePath, filePath2, filePath3 });
        }

        [Test]
        public void Monitor_SourceDoesNotExist_ShouldThrowInvalidOperationException()
        {
            // Arrange
            var nonExistentPath = Path.Combine(Path.GetTempPath(), Guid.NewGuid().ToString());

            var mockOptions = new Mock<IOptions<LocalSourceFile>>();
            mockOptions.Setup(o => o.Value).Returns(new LocalSourceFile(nonExistentPath));

            var sourceMonitor = new LocalTextFileMonitor(mockOptions.Object);

            // Act
            Action act = () => sourceMonitor.Monitor();

            // Assert
            act.Should().Throw<InvalidOperationException>()
                .WithMessage($"Expected directory does not exist.");
        }


        [Test]
        public void Monitor_MultipleFileTypesInLocation_ShouldReturnOnlyTextFiles()
        {
            // Arrange
            var jpegFile = Path.Combine(_tempDirectory, "testfile2.jpeg");
            File.WriteAllText(jpegFile, "Fake image content");

            var pngFile = Path.Combine(_tempDirectory, "testfile3.png");
            File.WriteAllText(pngFile, "Fake image content");

            var mockOptions = new Mock<IOptions<LocalSourceFile>>();
            mockOptions.Setup(o => o.Value).Returns(new LocalSourceFile(_tempDirectory));

            var sourceMonitor = new LocalTextFileMonitor(mockOptions.Object);

            // Act
            var files = sourceMonitor.Monitor();

            // Assert
            files.Should().NotBeNull();
            files.Should().HaveCount(1);
            files.Should().Contain(_filePath);
            files.Should().NotContain(jpegFile);
            files.Should().NotContain(pngFile);
        }
    }
}