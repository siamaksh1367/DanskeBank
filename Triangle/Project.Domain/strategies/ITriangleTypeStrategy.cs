namespace Project.Domain.strategies
{
    public interface ITriangleTypeStrategy
    {
        string DetermineTriangleType(IEnumerable<double> sides);
    }
}
