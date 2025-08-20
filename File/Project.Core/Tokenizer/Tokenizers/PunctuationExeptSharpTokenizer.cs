using System.Text.RegularExpressions;

namespace Project.Core.Tokenizer.Tokenizers
{
    public class PunctuationExeptSharpTokenizer : ITokenizer
    {
        public string Tokenize(string text, out Dictionary<string, int> occurances)
        {
            occurances = new Dictionary<string, int>();
            return Regex.Replace(text.ToLowerInvariant(), @"[^\w\s#]", " ");
        }
    }
}