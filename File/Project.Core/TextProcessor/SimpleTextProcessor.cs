using Project.Core.DTO;
using Project.Core.Tokenizer.TokenizerFactory;

namespace Project.Core.TextProcessor
{
    public class SimpleTextProcessor : ITextProcessor
    {
        private readonly ITokenizerListFactory _tokenizerListFactory;
        private readonly IEnumerable<TokenizerObject> _tokenizerObjects;

        public SimpleTextProcessor(ITokenizerListFactory tokenizerListFactory )
        {
            _tokenizerListFactory = tokenizerListFactory;
            _tokenizerObjects = _tokenizerListFactory.GetTokenzierList().OrderBy(x=>x.Priority) ?? Enumerable.Empty<TokenizerObject>();
        }

        public Dictionary<string, int> Process(string text)
        {
            if (string.IsNullOrWhiteSpace(text))
                return new Dictionary<string, int>();

            var occurrences = new Dictionary<string, int>();
            var result = new Dictionary<string, int>();
            foreach (var tokenizerObject in _tokenizerObjects)
            {
                text = tokenizerObject.Tokenizer.Tokenize(text, out occurrences);
                result = result.MergeResults(occurrences);
            }
            return result;
        }
    }

}