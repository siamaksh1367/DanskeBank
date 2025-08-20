namespace Project.Api.Core.Services.WithdrawalServices
{
    public class FiftyNoteFirstOperator : GeneralWithdrawalOperator<Withdrawal>
    {
        protected override int Value => 50;

        protected override short Location => 1;
    }
}
