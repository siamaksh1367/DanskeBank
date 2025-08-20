namespace Project.Api.Core.Services.WithdrawalServices
{
    public class WithdrawalStrategyFactory : IWithdrawalStrategyFactory<Withdrawal>
    {
        private readonly List<IWithdrawalOperator<Withdrawal>> _withdrawalOperators;
        public WithdrawalStrategyFactory()
        {
            _withdrawalOperators = new List<IWithdrawalOperator<Withdrawal>>();
        }

        public IEnumerable<IWithdrawalOperator<Withdrawal>> GetWithdrawalStrategies()
        {
            _withdrawalOperators.Add(new OneThousandNoteFirstOperator());
            _withdrawalOperators.Add(new FiveHundredNoteFirstOperator());
            _withdrawalOperators.Add(new TwoHundredNoteFirstOperator());
            _withdrawalOperators.Add(new OneHundredNoteFirstOperator());
            _withdrawalOperators.Add(new FiftyNoteFirstOperator());
            _withdrawalOperators.Add(new TwentyCoinSecondOperator());
            _withdrawalOperators.Add(new TenCoinThirdOperator());
            _withdrawalOperators.Add(new FiveCoinSecondOperator());
            _withdrawalOperators.Add(new TwoCoinSecondOperator());
            _withdrawalOperators.Add(new OneCoinThirdOperator());
            return _withdrawalOperators.OrderByDescending(x => x.GetValue());
        }
    }
}
