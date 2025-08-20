using Project.Domain.context;
using Project.Domain.strategies;

namespace Project.Domain.services
{
    public class TriangleService : IShapeService<IEnumerable<double>, string>
    {
        private readonly IEnumerable<ITriangleTypeStrategy> strategies;
        private readonly ITriangleTypeContext context;

        public TriangleService(IEnumerable<ITriangleTypeStrategy> strategies, ITriangleTypeContext context)
        {
            this.strategies = strategies;
            this.context = context;
        }
        public string Process(IEnumerable<double> input)
        {
            foreach (var strategy in strategies)
            {
                context.SetTriangleTypeStrategy(strategy);
                var triangleType = context.GetTriangleType(input);
                if (triangleType != null)
                {
                    return triangleType;
                }
            }
            return null;
        }
    }
}
