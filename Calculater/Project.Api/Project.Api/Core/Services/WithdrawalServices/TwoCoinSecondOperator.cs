namespace Project.Api.Core.Services.WithdrawalServices
{
    public class TwoCoinSecondOperator : GeneralWithdrawalOperator<Withdrawal>
    {
        protected override int Value => 2;

        protected override short Location => 2;
    }
}
