using FluentValidation;
using MediatR;

namespace Project.Api.Core.Queries.WithdrawalQuery
{
    public record WithdrawalQuery(int Amount) : IRequest<IEnumerable<WithdrawalQueryResponse>>;

    public class WithdrawalQueryValidator : AbstractValidator<WithdrawalQuery>
    {
        public WithdrawalQueryValidator()
        {
            RuleFor(x => x.Amount)
            .NotEmpty().WithMessage("Amount is required.")
            .GreaterThan(0).WithMessage("Amount must be greater than zero.");
        }
    }
}
