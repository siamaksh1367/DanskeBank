using Project.Domain.strategies;

namespace Project.Domain.context
{
    public class TriangleTypeContext : ITriangleTypeContext
    {
        private ITriangleTypeStrategy _triangleTypeStrategy;

        public TriangleTypeContext(ITriangleTypeStrategy triangleTypeStrategy)
        {
            _triangleTypeStrategy = triangleTypeStrategy;
        }

        public void SetTriangleTypeStrategy(ITriangleTypeStrategy triangleTypeStrategy)
        {
            _triangleTypeStrategy = triangleTypeStrategy;
        }

        public string GetTriangleType(IEnumerable<double> sides)
        {
            return _triangleTypeStrategy.DetermineTriangleType(sides);
        }
    }
}
