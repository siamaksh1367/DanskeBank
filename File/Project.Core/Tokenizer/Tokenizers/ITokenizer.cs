namespace Project.Core.Tokenizer.Tokenizers
{
    public interface ITokenizer
    {
        string Tokenize(string text, out Dictionary<string, int> occurances);
    }
}