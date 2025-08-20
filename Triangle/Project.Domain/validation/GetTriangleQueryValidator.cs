using FluentValidation;
using Project.Domain.application;

namespace Project.Domain.validation
{
    public class GetTriangleQueryValidator : AbstractValidator<GetTriangleTypeQuery>
    {
        public GetTriangleQueryValidator()
        {
            RuleFor(x => x.Sides)
             .NotEmpty().WithMessage("Sides list cannot be empty.")
             .Must(HaveThreePositiveDoubles)
             .WithMessage("Invalid format for the sides list. It must be a space-separated list of three positive doubles.")
             .DependentRules(() =>
             {
                 RuleFor(x => x.Sides)
                     .Must(SatisfyTriangleInequality)
                     .WithMessage("The sides must satisfy the triangle inequality conditions.");
             });
        }

        private bool HaveThreePositiveDoubles(string sides)
        {
            var sideValues = sides.Split(' ', StringSplitOptions.RemoveEmptyEntries);

            if (sideValues.Length != 3)
            {
                return false;
            }
            return sideValues.All(side => double.TryParse(side, out var parsedValue) && parsedValue > 0);
        }

        private bool SatisfyTriangleInequality(string sides)
        {
            var sideValues = sides.Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(double.Parse).ToList();
            var sortedSides = sideValues.OrderBy(side => side).ToArray();
            return sortedSides[0] + sortedSides[1] > sortedSides[2];
        }
    }
}
