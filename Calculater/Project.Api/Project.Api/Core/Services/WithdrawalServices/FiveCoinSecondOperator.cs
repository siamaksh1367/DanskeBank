namespace Project.Api.Core.Services.WithdrawalServices
{
    public class FiveCoinSecondOperator : GeneralWithdrawalOperator<Withdrawal>
    {
        protected override int Value => 5;

        protected override short Location => 2;
    }
}
