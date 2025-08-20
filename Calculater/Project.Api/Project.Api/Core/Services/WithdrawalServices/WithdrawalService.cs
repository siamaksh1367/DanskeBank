using Project.Api.Core.Queries.WithdrawalQuery;

namespace Project.Api.Core.Services.WithdrawalServices
{
    public class WithdrawalService : IWithdrawalService<WithdrawalQueryResponse>
    {
        private readonly IEnumerable<IWithdrawalOperator<Withdrawal>> _operators;

        public WithdrawalService(IWithdrawalStrategyFactory<Withdrawal> withdrawalStrategyFactory)
        {
            _operators = withdrawalStrategyFactory.GetWithdrawalStrategies();
        }
        public IEnumerable<WithdrawalQueryResponse> CalculateWtihdrawal(int amount)
        {
            var result = new List<WithdrawalQueryResponse>();
            var remaining = amount;
            foreach (var op in _operators)
            {
                var operatoerValue = op.GetValue();
                if (remaining >= operatoerValue)
                {
                    var withdrawal = op.CalculateWithdrawal(remaining);
                    if (withdrawal.Quantity > 0)
                    {
                        result.Add(new WithdrawalQueryResponse(Value: operatoerValue, Quantity: withdrawal.Quantity, Location: withdrawal.Location));
                        if (remaining == 0)
                            break;
                    }
                    remaining = withdrawal.Remaining;
                }
            }
            return result;
        }
    }
}
