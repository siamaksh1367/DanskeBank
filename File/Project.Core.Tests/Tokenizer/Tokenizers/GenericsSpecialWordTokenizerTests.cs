using FluentAssertions;

namespace Project.Core.Tests.Tokenizer.Tokenizers
{
    public class GenericsSpecialWordTokenizerTests
    {
        [Test]
        public void Tokenize_WhenWordIsIsolated_ShouldReplaceWithSpaceAndCount()
        {
            var tokenizer = new TestTokenizer("example");
            var input = "This is an example test.";

            var result = tokenizer.Tokenize(input, out var occurances);

            result.Should().Contain("This is an   test.");
            occurances.Should().ContainKey("example");
            occurances["example"].Should().Be(1);
        }

        [Test]
        public void Tokenize_WhenWordIsAttachedToOtherWord_ShouldNotReplace()
        {
            var tokenizer = new TestTokenizer("example");
            var input = "This is an exampleTest case.";

            var result = tokenizer.Tokenize(input, out var occurances);

            result.Should().Be(input);
            occurances.Should().BeEmpty();
        }

        [Test]
        public void Tokenize_ShouldBeCaseInsensitive()
        {
            var tokenizer = new TestTokenizer("example");
            var input = "An ExAmPlE appears here.";

            var result = tokenizer.Tokenize(input, out var occurances);

            result.Should().Contain("An   appears here.");
            occurances.Should().ContainKey("example");
            occurances["example"].Should().Be(1);
        }

        [Test]
        public void Tokenize_WhenMultipleOccurrences_ShouldReplaceEachAndCount()
        {
            var tokenizer = new TestTokenizer("word");
            var input = "word another word. Notword should stay.";

            var result = tokenizer.Tokenize(input, out var occurances);

            occurances.Should().ContainKey("word");
            occurances["word"].Should().Be(2);
            result.Should().Contain("  another  . Notword should stay.");
        }

        [Test]
        public void Tokenize_WhenNoMatch_ShouldLeaveTextUnchanged()
        {
            var tokenizer = new TestTokenizer("absent");
            var input = "This text does not contain the word.";

            var result = tokenizer.Tokenize(input, out var occurances);

            result.Should().Be(input);
            occurances.Should().BeEmpty();
        }
    }
}
