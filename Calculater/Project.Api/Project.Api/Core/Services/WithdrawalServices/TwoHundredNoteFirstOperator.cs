namespace Project.Api.Core.Services.WithdrawalServices
{
    public class TwoHundredNoteFirstOperator : GeneralWithdrawalOperator<Withdrawal>
    {
        protected override int Value => 200;

        protected override short Location => 1;
    }
}
