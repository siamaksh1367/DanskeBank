namespace Project.Api.Core.Services.WithdrawalServices
{
    public class OneCoinThirdOperator : GeneralWithdrawalOperator<Withdrawal>
    {
        protected override int Value => 1;

        protected override short Location => 3;
    }
}
