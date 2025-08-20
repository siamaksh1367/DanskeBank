using FluentAssertions;
using Project.Core.Tokenizer.Tokenizers;

namespace Project.Core.Tests.Tokenizer.Tokenizers
{
    public class WhiteSpaceTokenizerTests
    {
        private WhiteSpaceTokenizer _whiteSpaceTokenizer;

        [SetUp]
        public void Setup()
        {
            _whiteSpaceTokenizer = new WhiteSpaceTokenizer();
        }

        [Test]
        public void Tokenize_GivenTextWithMultipleSpaces_ReturnsExpectedWordCounts()
        {
            // Arrange
            var text = "Go and  do that thing  more that you do not so well";
            var expected = new Dictionary<string, int>(StringComparer.OrdinalIgnoreCase)
            {
                { "go", 1 },
                { "and", 1 },
                { "do", 2 },
                { "that", 2 },
                { "thing", 1 },
                { "more", 1 },
                { "you", 1 },
                { "not", 1 },
                { "so", 1 },
                { "well", 1 }
            };

            // Act
            var result = _whiteSpaceTokenizer.Tokenize(text, out var occurances);

            // Assert
            result.Should().Be("");
            CollectionAssert.AreEquivalent(expected, occurances);
        }

        [Test]
        public void Tokenize_GivenTextWithTabCharacters_ReturnsExpectedWordCounts()
        {
            // Arrange
            var text = "Go\tand\tdo\tthat";
            var expected = new Dictionary<string, int>(StringComparer.OrdinalIgnoreCase)
            {
                { "go", 1 },
                { "and", 1 },
                { "do", 1 },
                { "that", 1 }
            };

            // Act
            var result = _whiteSpaceTokenizer.Tokenize(text, out var occurances);

            // Assert
            result.Should().Be("");
            CollectionAssert.AreEquivalent(expected, occurances);
        }

        [Test]
        public void Tokenize_GivenTextWithNewlineCharacters_ReturnsExpectedWordCounts()
        {
            // Arrange
            var text = "Go\nand\ndo\nthat";
            var expected = new Dictionary<string, int>(StringComparer.OrdinalIgnoreCase)
            {
                { "go", 1 },
                { "and", 1 },
                { "do", 1 },
                { "that", 1 }
            };

            // Act
            var result = _whiteSpaceTokenizer.Tokenize(text, out var occurances);

            // Assert
            result.Should().Be("");
            CollectionAssert.AreEquivalent(expected, occurances);
        }

        [Test]
        public void Tokenize_GivenEmptyText_ReturnsEmptyDictionary()
        {
            // Arrange
            var text = "";
            var expected = new Dictionary<string, int>(StringComparer.OrdinalIgnoreCase);

            // Act
            var result = _whiteSpaceTokenizer.Tokenize(text, out var occurances);

            // Assert
            result.Should().Be("");
            occurances.Should().BeEmpty();
        }


        [Test]
        public void Tokenize_GivenMultilineText_ReturnsExpectedWordCounts()
        {
            // Arrange
            var text = """
                    Hello
                    is a multiline
                    string in C#
                    """;
            var expected = new Dictionary<string, int>(StringComparer.OrdinalIgnoreCase)
            {
                { "hello", 1 },
                { "is", 1 },
                { "a", 1 },
                { "multiline", 1 },
                { "string", 1 },
                { "in", 1 },
                { "c#", 1 }
            };

            // Act
            var result = _whiteSpaceTokenizer.Tokenize(text, out var occurances);

            // Assert
            result.Should().Be("");
            CollectionAssert.AreEquivalent(expected, occurances);
        }

        [Test]
        public void Tokenize_GivenTextWithRepeatedWords_ReturnsCorrectWordCounts()
        {
            // Arrange
            var text = "apple apple apple banana banana";
            var expected = new Dictionary<string, int>(StringComparer.OrdinalIgnoreCase)
            {
                { "apple", 3 },
                { "banana", 2 }
            };

            // Act
            var result = _whiteSpaceTokenizer.Tokenize(text, out var occurances);

            // Assert
            result.Should().Be("");
            CollectionAssert.AreEquivalent(expected, occurances);
        }

        [Test]
        public void Tokenize_GivenTextWithMixedCase_ReturnsExpectedWordCountsCaseInsensitive()
        {
            // Arrange
            var text = "Go go GO and And and";
            var expected = new Dictionary<string, int>(StringComparer.OrdinalIgnoreCase)
            {
                { "go", 3 },
                { "and", 3 }
            };

            // Act
            var result = _whiteSpaceTokenizer.Tokenize(text, out var occurances);

            // Assert
            result.Should().Be("");
            CollectionAssert.AreEquivalent(expected, occurances);
        }
    }
}


