using Project.Core.DTO;
using Project.Core.Tokenizer.Tokenizers;

namespace Project.Core.Tokenizer.TokenizerFactory
{
    public class SimpleTokenizerFactory : ITokenizerListFactory
    {
        public IEnumerable<TokenizerObject> GetTokenzierList()
        {
            return new List<TokenizerObject>()
            {
                new TokenizerObject(new CsharpTokenizer(),1),
                new TokenizerObject(new EmailTokenizer(),1),
                new TokenizerObject(new PunctuationExeptSharpTokenizer(),2),
                new TokenizerObject(new WhiteSpaceTokenizer(),3),
            }.OrderBy(x=>x.Priority);
        }
    }
}