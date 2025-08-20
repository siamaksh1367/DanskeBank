using Project.Core.Tokenizer.Tokenizers;

namespace Project.Core.DTO
{
    public record TokenizerObject(ITokenizer Tokenizer,short Priority );
}