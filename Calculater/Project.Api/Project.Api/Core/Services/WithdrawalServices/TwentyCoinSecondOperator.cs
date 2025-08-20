namespace Project.Api.Core.Services.WithdrawalServices
{
    public class TwentyCoinSecondOperator : GeneralWithdrawalOperator<Withdrawal>
    {
        protected override int Value => 20;

        protected override short Location => 2;
    }
}
