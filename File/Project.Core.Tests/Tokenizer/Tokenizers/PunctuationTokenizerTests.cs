using FluentAssertions;
using Project.Core.Tokenizer.Tokenizers;

namespace Project.Core.Tests.Tokenizer.Tokenizers
{
    public class PunctuationTokenizerTests
    {
        private PunctuationExeptSharpTokenizer _punctuationTokenizer;

        [SetUp]
        public void Setup()
        {
            _punctuationTokenizer = new PunctuationExeptSharpTokenizer();
        }

        [Test]
        public void Tokenize_GivenTextWithPunctuation_RemovesPunctuationAndReturnsExpectedWordCounts()
        {
            // Arrange
            var text = "Hello, World! How's it going?";
            var expected = new Dictionary<string, int>(StringComparer.OrdinalIgnoreCase);

            // Act
            var result = _punctuationTokenizer.Tokenize(text, out var occurances);

            // Assert
            result.Should().Be("hello  world  how s it going ");
            CollectionAssert.AreEquivalent(expected, occurances);
        }

        [Test]
        public void Tokenize_GivenTextWithNoPunctuation_ReturnsTextAsIsAndExpectedWordCounts()
        {
            // Arrange
            var text = "Hello world how are you";
            var expected = new Dictionary<string, int>(StringComparer.OrdinalIgnoreCase);

            // Act
            var result = _punctuationTokenizer.Tokenize(text, out var occurances);

            // Assert
            result.Should().Be("hello world how are you");
            CollectionAssert.AreEquivalent(expected, occurances);
        }

        [Test]
        public void Tokenize_GivenEmptyText_ReturnsEmptyTextAndEmptyDictionary()
        {
            // Arrange
            var text = "";
            var expected = new Dictionary<string, int>(StringComparer.OrdinalIgnoreCase);

            // Act
            var result = _punctuationTokenizer.Tokenize(text, out var occurances);

            // Assert
            result.Should().Be("");
            occurances.Should().BeEmpty();
        }

        [Test]
        public void Tokenize_GivenTextWithOnlyPunctuation_RemovesPunctuationAndReturnsEmptyText()
        {
            // Arrange
            var text = "!!! ??? !!!";
            var expected = new Dictionary<string, int>(StringComparer.OrdinalIgnoreCase);

            // Act
            var result = _punctuationTokenizer.Tokenize(text, out var occurances);

            // Assert
            result.Should().Be("           ");
            occurances.Should().BeEmpty();
        }

        [Test]
        public void Tokenize_GivenSingleWordWithPunctuation_RemovesPunctuationAndReturnsWordCount()
        {
            // Arrange
            var text = "Hello!";
            var expected = new Dictionary<string, int>(StringComparer.OrdinalIgnoreCase);

            // Act
            var result = _punctuationTokenizer.Tokenize(text, out var occurances);

            // Assert
            result.Should().Be("hello ");
            CollectionAssert.AreEquivalent(expected, occurances);
        }


        [Test]
        public void Tokenize_GivenTextWithSpecialCharacters_SkipsSpecialCharactersAndCountsWords()
        {
            // Arrange
            var text = "Hello, hello! I am here to say hello";
            var expected = new Dictionary<string, int>(StringComparer.OrdinalIgnoreCase);

            // Act
            var result = _punctuationTokenizer.Tokenize(text, out var occurances);

            // Assert
            result.Should().Be("hello  hello  i am here to say hello");
            CollectionAssert.AreEquivalent(expected, occurances);
        }
    }
}


