namespace Project.Domain.services
{
    public interface IShapeService<TRequest, TResponse>
    {
        TResponse Process(TRequest input);
    }
}
