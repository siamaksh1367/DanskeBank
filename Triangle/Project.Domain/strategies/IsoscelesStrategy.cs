using Project.Domain.strategies;

namespace Project.Domain.Strategies
{
    public class IsoscelesStrategy : ITriangleTypeStrategy
    {
        public string DetermineTriangleType(IEnumerable<double> sides)
        {
            return sides.Distinct().Count() == 2 ? "Isosceles" : null;
        }
    }
}
