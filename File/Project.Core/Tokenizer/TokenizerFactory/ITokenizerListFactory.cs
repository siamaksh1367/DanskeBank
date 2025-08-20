using Project.Core.DTO;

namespace Project.Core.Tokenizer.TokenizerFactory
{
    public interface ITokenizerListFactory
    {
        IEnumerable<TokenizerObject> GetTokenzierList();
    }
}