using System.Text.RegularExpressions;

namespace Project.Core.Tokenizer.Tokenizers
{
    public abstract class GenericsSpecialWordTokenizer : ITokenizer
    {
        public abstract string SpecialWord { get; }

        public virtual string Tokenize(string text, out Dictionary<string, int> occurances)
        {
            var count = 0;
            var index = 0;
            var previousOccuranceIndex = 0;
            occurances = new Dictionary<string, int>();
            while (index >= previousOccuranceIndex)
            {
                var rightAttched = false;
                var leftAttched = false;

                index = text.IndexOf(SpecialWord, index, StringComparison.OrdinalIgnoreCase);
                if (index != -1)
                {
                    var nextIndex = index + SpecialWord.Length;
                    if (index + SpecialWord.Length < text.Length)
                    {
                        var nextChar = text[nextIndex];
                        if (char.IsSymbol(nextChar) || char.IsLetterOrDigit(nextChar))
                        {
                            rightAttched = true;
                        }
                    }

                    var PreviousIndex = index - 1;
                    if (PreviousIndex >= 0)
                    {
                        if (!char.IsWhiteSpace(text[PreviousIndex]) && !char.IsSymbol(text[PreviousIndex]))
                        {
                            leftAttched = true;
                        }
                    }
                    var isSubWord = rightAttched || leftAttched;
                    if (!isSubWord)
                    {
                        count++;

                        text = text.Remove(index, SpecialWord.Length).Insert(index, " ");
                        previousOccuranceIndex = 0;
                        index = index + 1;
                    }
                    else
                    {
                        previousOccuranceIndex = index;
                        index = index + SpecialWord.Length;
                    }
                }
            }

            if (count != 0)
                occurances = new Dictionary<string, int>() { { SpecialWord, count } };

            return text;
        }
    }
}