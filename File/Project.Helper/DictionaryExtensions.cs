namespace Project.Core.TextProcessor
{
    public static class DictionaryExtensions
        {
            public static Dictionary<T, S> MergeResults<T, S>(
                this Dictionary<T, S> result,
                Dictionary<T, S> occurrences)
                where S : struct, IComparable, IConvertible, IFormattable 
            {
                return result
                        .Concat(occurrences)
                        .GroupBy(kvp => kvp.Key)
                        .ToDictionary(
                            g => g.Key,
                            g => g.Aggregate(
                                default(S),
                                (acc, kvp) => (dynamic)acc + (dynamic)kvp.Value) 
                        );
            }
    }

}