namespace Project.Api.Core.Services.WithdrawalServices
{
    public class OneThousandNoteFirstOperator : GeneralWithdrawalOperator<Withdrawal>
    {
        protected override int Value => 1000;

        protected override short Location => 1;
    }
}
