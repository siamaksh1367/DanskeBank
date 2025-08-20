using Project.Core.TextProcessor;

namespace Project.Core.Tests
{
    public class DictionaryExtensionsTests
    {
        [Test]
        public void MergeResults_GivenTwoDictionariesWithCommonAndDistinctKeys_ReturnsCorrectMergedDictionary()
        {
            // Arrange
            var dict1 = new Dictionary<string, int>
            {
                { "apple", 2 },
                { "banana", 3 },
                { "cherry", 5 }
            };

            var dict2 = new Dictionary<string, int>
            {
                { "banana", 2 },
                { "cherry", 3 },
                { "date", 7 }
            };

            var expected = new Dictionary<string, int>(StringComparer.OrdinalIgnoreCase)
            {
                { "apple", 2 },
                { "banana", 5 },  
                { "cherry", 8 },  
                { "date", 7 }
            };

            // Act
            var result = dict1.MergeResults(dict2);

            // Assert
            CollectionAssert.AreEquivalent(expected, result);
        }

        [Test]
        public void MergeResults_GivenTwoDictionariesWithNoCommonKeys_ReturnsCorrectMergedDictionary()
        {
            // Arrange
            var dict1 = new Dictionary<string, int>
            {
                { "apple", 2 },
                { "banana", 3 }
            };

            var dict2 = new Dictionary<string, int>
            {
                { "cherry", 5 },
                { "date", 7 }
            };

            var expected = new Dictionary<string, int>(StringComparer.OrdinalIgnoreCase)
            {
                { "apple", 2 },
                { "banana", 3 },
                { "cherry", 5 },
                { "date", 7 }
            };

            // Act
            var result = dict1.MergeResults(dict2);

            // Assert
            CollectionAssert.AreEquivalent(expected, result);
        }

        [Test]
        public void MergeResults_GivenEmptyDictionaries_ReturnsEmptyDictionary()
        {
            // Arrange
            var dict1 = new Dictionary<string, int>();
            var dict2 = new Dictionary<string, int>();
            var expected = new Dictionary<string, int>();

            // Act
            var result = dict1.MergeResults(dict2);

            // Assert
            CollectionAssert.AreEquivalent(expected, result);
        }

        [Test]
        public void MergeResults_GivenOneEmptyDictionary_ReturnsOtherDictionary()
        {
            // Arrange
            var dict1 = new Dictionary<string, int>
            {
                { "apple", 2 },
                { "banana", 3 }
            };

            var dict2 = new Dictionary<string, int>();

            var expected = new Dictionary<string, int>(StringComparer.OrdinalIgnoreCase)
            {
                { "apple", 2 },
                { "banana", 3 }
            };

            // Act
            var result = dict1.MergeResults(dict2);

            // Assert
            CollectionAssert.AreEquivalent(expected, result);
        }
    }
}
