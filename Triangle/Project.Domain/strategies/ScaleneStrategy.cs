using Project.Domain.strategies;

namespace Project.Domain.Strategies
{
    public class ScaleneStrategy : ITriangleTypeStrategy
    {
        public string DetermineTriangleType(IEnumerable<double> sides)
        {
            return sides.Distinct().Count() == 3 ? "Scalene" : null;
        }
    }
}
