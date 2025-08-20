namespace Project.Core.Tokenizer.Tokenizers
{
    public class WhiteSpaceTokenizer : ITokenizer
    {
        public string Tokenize(string text, out Dictionary<string, int> occurances)
        {
            occurances = text.Split(new[] { ' ', '\t', '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries)
                       .Select(word => word.ToLowerInvariant())
                       .Aggregate(new Dictionary<string, int>(), (dict, word) =>
                       {
                           if (dict.ContainsKey(word))
                               dict[word]++;
                           else
                               dict[word] = 1;
                           return dict;
                       });
            return string.Empty;
        }
    }
}