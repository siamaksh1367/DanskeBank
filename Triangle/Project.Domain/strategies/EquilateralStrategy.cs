using Project.Domain.strategies;

namespace Project.Domain.Strategies
{
    public class EquilateralStrategy : ITriangleTypeStrategy
    {
        public string DetermineTriangleType(IEnumerable<double> sides)
        {
            return sides.Distinct().Count() == 1 ? "Equilateral" : null;
        }
    }
}
