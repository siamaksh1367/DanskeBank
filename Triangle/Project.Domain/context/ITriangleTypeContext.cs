using Project.Domain.strategies;

namespace Project.Domain.context
{
    public interface ITriangleTypeContext
    {
        string GetTriangleType(IEnumerable<double> sides);
        void SetTriangleTypeStrategy(ITriangleTypeStrategy triangleTypeStrategy);
    }
}