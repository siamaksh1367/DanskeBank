namespace Project.Core.TextProcessor
{
    public interface ITextProcessor
    {
        Dictionary<string, int> Process(string text);
    }
}