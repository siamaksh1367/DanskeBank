using Project.Core.Tokenizer.Tokenizers;

namespace Project.Core.Tests.Tokenizer.Tokenizers
{
    public class TestTokenizer : GenericsSpecialWordTokenizer
    {
        private readonly string _word;

        public TestTokenizer(string word)
        {
            _word = word;
        }

        public override string SpecialWord => _word;
    }
}

