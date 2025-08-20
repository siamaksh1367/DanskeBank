namespace Project.Api.Core.Services.WithdrawalServices
{
    public class TenCoinThirdOperator : GeneralWithdrawalOperator<Withdrawal>
    {
        protected override int Value => 10;

        protected override short Location => 3;
    }
}
