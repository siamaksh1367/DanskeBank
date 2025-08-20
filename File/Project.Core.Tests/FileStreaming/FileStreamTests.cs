using FluentAssertions;
using Microsoft.Extensions.Options;
using Moq;
using Project.Core.DTO.Configurations;

namespace Project.Core.Tests.FileStreaming
{
    public class FileStreamingTests
    {
        private string _tempDirectory;
        private FileStreams.FileStreaming _fileStream;

        [SetUp]
        public void Setup()
        {
            _tempDirectory = Path.Combine(Path.GetTempPath(), Guid.NewGuid().ToString());
            Directory.CreateDirectory(_tempDirectory);
            var mockOptions = new Mock<IOptions<StreamBuffer>>();
            mockOptions.Setup(o => o.Value).Returns(new StreamBuffer(50));
            _fileStream = new FileStreams.FileStreaming(mockOptions.Object);
        }

        [TearDown]
        public void Teardown()
        {
            Directory.Delete(_tempDirectory, true);
        }

        [Test]
        public async Task StreamBytesAsync_GivenASimpleShortFile_ReturnFileContentInTextAsync()
        {
            //Arrange
            var sample = "Hello, I am a sample test";
            var _filePath = Path.Combine(_tempDirectory, "testfile.txt");
            File.WriteAllText(_filePath, sample);

            // Act
            var iterator =  _fileStream.StreamBytesAsync(_filePath);
            var result= string.Empty;
            await foreach (var response in iterator)
            {
                result = result + response.Text;
            }
            var text = _fileStream.StreamBytesAsync(_filePath);

            // Assert
            result .Should().NotBeNullOrWhiteSpace();
            result.Should().Be(sample);
        }
        [Test]
        public async Task StreamBytesAsync_GivenASemiLargeFile_ReturnFileContentInTextAsync()
        {
            //Arrange
            var sample = GenerateLargeRandomString(100);
            var _filePath = Path.Combine(_tempDirectory, "testfile.txt");
            File.WriteAllText(_filePath, sample);

            // Act
            var iterator = _fileStream.StreamBytesAsync(_filePath);
            var result = string.Empty;
            await foreach (var response in iterator)
            {
                result = result + response.Text;
            }
            var text = _fileStream.StreamBytesAsync(_filePath);

            // Assert
            result.Should().NotBeNullOrWhiteSpace();
            result.Should().Be(sample);
        }

        [TestCase("")]
        [TestCase("   ")]
        public void StreamBytesAsync_GivenInvalidFilePath_ShouldThrowArgumentException(string filePath)
        {
            // Act
            Func<Task> act = async () =>
            {
                await foreach (var _ in _fileStream.StreamBytesAsync(filePath))
                {
                    // intentionally left empty
                }
            };

            // Assert
            act.Should().ThrowAsync<ArgumentException>()
               .WithMessage("File path cannot be null or empty.*");
        }

        [Test]
        public void StreamBytesAsync_GivenNonExistentFilePath_ShouldThrowFileNotFoundException()
        {
            // Arrange
            var fakePath = Path.Combine(_tempDirectory, "does_not_exist.txt");

            // Act
            Func<Task> act = async () =>
            {
                await foreach (var _ in _fileStream.StreamBytesAsync(fakePath))
                {
                    // intentionally left empty
                }
            };

            // Assert
            act.Should().ThrowAsync<FileNotFoundException>()
               .WithMessage($"File not found: {fakePath}");
        }

        private string GenerateLargeRandomString(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789 .,!?;:-_()[]{}\"'";

            var random = new Random();
            var result = new char[length];

            for (int i = 0; i < length; i++)
            {
                result[i] = chars[random.Next(chars.Length)];
            }

            return new string(result);
        }

    }
}
