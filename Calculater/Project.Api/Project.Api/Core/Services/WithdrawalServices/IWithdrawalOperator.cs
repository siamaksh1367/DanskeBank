namespace Project.Api.Core.Services.WithdrawalServices
{
    public interface IWithdrawalOperator<T>
    {
        Withdrawal CalculateWithdrawal(int remaining);
        int GetValue();
    }
}
