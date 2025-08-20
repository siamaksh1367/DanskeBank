namespace Project.Api.Core.Services.WithdrawalServices
{
    public class OneHundredNoteFirstOperator : GeneralWithdrawalOperator<Withdrawal>
    {
        protected override int Value => 100;

        protected override short Location => 1;
    }
}
