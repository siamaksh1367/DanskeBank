namespace Project.Api.Core.Services.WithdrawalServices
{
    public interface IWithdrawalService<T>
    {
        IEnumerable<T> CalculateWtihdrawal(int amount);
    }
}
