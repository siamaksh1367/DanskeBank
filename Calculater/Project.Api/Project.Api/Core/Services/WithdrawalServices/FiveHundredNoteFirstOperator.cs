namespace Project.Api.Core.Services.WithdrawalServices
{
    public class FiveHundredNoteFirstOperator : GeneralWithdrawalOperator<Withdrawal>
    {
        protected override int Value => 500;

        protected override short Location => 1;
    }
}
