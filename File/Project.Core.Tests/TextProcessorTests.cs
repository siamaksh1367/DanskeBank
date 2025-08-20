using FluentAssertions;
using Project.Core.Tests.Tokenizer.Tokenizers;
using Project.Core.TextProcessor;
using Project.Core.Tokenizer.TokenizerFactory;

namespace Project.Core.Tests
{
    public class TextProcessorTests
    {
        private SimpleTextProcessor _simpleTextProcessor;

        [SetUp]
        public void Setup()
        {
            _simpleTextProcessor = new SimpleTextProcessor(new SimpleTokenizerFactory());
        }

        [Test]
        public void Process_GivenCustomerSample1_ReturnsExpectedWordCounts()
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
            ;

            // Act
            var result = _simpleTextProcessor.Process(text);

            // Assert
            CollectionAssert.AreEquivalent(expected, result);
        }


        [Test]
        public void Process_GivenCustomerSample2_ReturnsExpectedWordCounts()
        {
            // Arrange
            var text = "I do many things very well  ";
            var expected = new Dictionary<string, int>(StringComparer.OrdinalIgnoreCase)
            {
                { "i", 1 },
                { "do", 1 },
                { "many", 1 },
                { "things", 1 },
                { "very", 1 },
                { "well", 1 },
            };

            // Act
            var result = _simpleTextProcessor.Process(text);

            // Assert
            CollectionAssert.AreEquivalent(expected, result);
        }

        [Test]
        public void Process_GivenEmptyText_ReturnsEmptyDictionary()
        {
            // Arrange
            var text = "";
            var expected = new Dictionary<string, int>(StringComparer.OrdinalIgnoreCase);

            // Act
            var result = _simpleTextProcessor.Process(text);

            // Assert
            CollectionAssert.AreEquivalent(expected, result);
        }

        [Test]

        public void Process_GivenMultilinerText_ReturnsExpectedWordCounts()
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
                { "c#", 1 },
            };

            // Act
            var result = _simpleTextProcessor.Process(text);

            // Assert
            CollectionAssert.AreEquivalent(expected, result);
        }

        [Test]
        public void Process_GivenSpecialCharacter_ShouldSkipCharacter()
        {
            // Arrange
            var text = "Hello, hello! I am here to say hello";
            var expected = new Dictionary<string, int>(StringComparer.OrdinalIgnoreCase)
            {
                { "hello", 3 },
                { "i", 1 },
                { "am", 1 },
                { "here", 1 },
                { "to", 1 },
                { "say", 1 },
            };

            // Act
            var result = _simpleTextProcessor.Process(text);

            // Assert
            CollectionAssert.AreEquivalent(expected, result);
        }
        [Test]
        public void Process_GivenMultiSpecialWordsWithPunctuation_ReturnsExpectedWordCounts()
        {
            // Arrange
            var text = "Hello, hello C#. we love C#";
            var expected = new Dictionary<string, int>(StringComparer.OrdinalIgnoreCase)
            {
                { "hello", 2 },
                { "we", 1 },
                { "love", 1 },
                { "c#", 2 },
            };

            // Act
            var result = _simpleTextProcessor.Process(text);

            // Assert
            CollectionAssert.AreEquivalent(expected, result);
        }

        [Test]
        public void Process_GivenPunctuation_ReturnsExpectedWordCounts()
        {
            var text = "This is a (target) and also target.";
            var expected = new Dictionary<string, int>(StringComparer.OrdinalIgnoreCase)
            {
                { "this", 1 },
                { "is", 1 },
                { "a", 1 },
                { "target", 2 },
                { "and", 1 },
                { "also", 1 },
            };
            var result = _simpleTextProcessor.Process(text);

            CollectionAssert.AreEquivalent(expected, result);
        }

        [Test]
        public void Process_GivenEmailAddress_ReturnsGoogleAndTheNameTwice()
        {
            var text = "Google  e-mail for Thename is Thename@google.com";
            var expected = new Dictionary<string, int>(StringComparer.OrdinalIgnoreCase)
            {
                { "google", 2 },
                { "e-mail", 1 },
                { "for", 1 },
                { "thename", 2 },
                { "com", 1 },
                { "is", 1 },
            };
            var result = _simpleTextProcessor.Process(text);

            CollectionAssert.AreEquivalent(expected, result);
        }

        [Test]
        public void Process_Givensss_ReturnsGoogleAndTheNameTwice()
        {
            var text = "C#C#";
            var expected = new Dictionary<string, int>(StringComparer.OrdinalIgnoreCase)
            {
                { "c#c#", 1 }
            };
            var result = _simpleTextProcessor.Process(text);

            CollectionAssert.AreEquivalent(expected, result);
        }
    }
}