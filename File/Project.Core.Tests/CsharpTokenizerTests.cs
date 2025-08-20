using FluentAssertions;
using Project.Core.Tokenizer;
using Project.Core.Tokenizer.Tokenizers;

namespace Project.Core.Tests;

public class CsharpTokenizerTests
{
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public void Tokenize_Has4CsharpWordInText_ShouldRemoveAllAndReturnDictionary()
    {
        // Arrange
        var csharpTokenizer = new CsharpTokenizer();
        var inputText = "C#, C# c#, hello i am C#";

        // Act
        var result = csharpTokenizer.Tokenize(inputText, out Dictionary<string, int> occurances);

        // Assert
        occurances.Should().ContainKey("c#");
        occurances["c#"].Should().Be(4);
    }

    [Test]
    public void Tokenize_Has4CsharpAsInnerText_ShouldNotCountInnerWord()
    {
        // Arrange
        var csharpTokenizer = new CsharpTokenizer();
        var inputText = "intheC#middle C#";

        // Act
        var result = csharpTokenizer.Tokenize(inputText, out Dictionary<string, int> occurances);

        // Assert
        occurances.Should().ContainKey("c#");
        occurances["c#"].Should().Be(1);
    }

    [Test]
    public void Tokenize_Has2CsharpInARow_ShouldNotCountAny()
    {
        // Arrange
        var csharpTokenizer = new CsharpTokenizer();
        var inputText = "C#C#";

        // Act
        var result = csharpTokenizer.Tokenize(inputText, out Dictionary<string, int> occurances);

        // Assert
        occurances.Should().NotContainKey("c#");
    }
}
