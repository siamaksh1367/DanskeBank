using Project.Api.Core.Services.WithdrawalServices;
using MediatR;

namespace Project.Api.Core.Queries.WithdrawalQuery
{
    public sealed class WithdrawalQueryHandler : IRequestHandler<WithdrawalQuery, IEnumerable<WithdrawalQueryResponse>>
    {
        private readonly IWithdrawalService<WithdrawalQueryResponse> _withdrawalService;

        public WithdrawalQueryHandler(IWithdrawalService<WithdrawalQueryResponse> withdrawalService)
        {
            this._withdrawalService = withdrawalService;
        }
        public Task<IEnumerable<WithdrawalQueryResponse>> Handle(WithdrawalQuery request, CancellationToken cancellationToken)
        {
            return Task.FromResult(_withdrawalService.CalculateWtihdrawal(request.Amount));
        }
    }
}
