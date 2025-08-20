using FluentValidation.TestHelper;
using Project.Domain.application;
using Project.Domain.validation;

namespace Project.Tests
{
    [TestFixture]
    public class GetTriangleQueryValidatorTests
    {
        private GetTriangleQueryValidator _validator;

        [SetUp]
        public void Setup()
        {
            _validator = new GetTriangleQueryValidator();
        }

        [Test]
        public void SidesShouldNotBeEmpty()
        {
            var result = _validator.TestValidate(new GetTriangleTypeQuery { Sides = string.Empty });
            result.ShouldHaveValidationErrorFor(x => x.Sides)
                .WithErrorMessage("Sides list cannot be empty.");
        }

        [Test]
        public void SidesShouldBeSpaceSeparatedList()
        {
            var result = _validator.TestValidate(new GetTriangleTypeQuery { Sides = "1,2,3" });
            result.ShouldHaveValidationErrorFor(x => x.Sides)
                .WithErrorMessage("Invalid format for the sides list. It must be a space-separated list of three positive doubles.");
        }

        [Test]
        public void SidesShouldContainThreePositiveDoubles()
        {
            var result = _validator.TestValidate(new GetTriangleTypeQuery { Sides = "1 2 -3" });
            result.ShouldHaveValidationErrorFor(x => x.Sides)
                .WithErrorMessage("Invalid format for the sides list. It must be a space-separated list of three positive doubles.");
        }

        [Test]
        public void SidesShouldSatisfyTriangleInequality()
        {
            var result = _validator.TestValidate(new GetTriangleTypeQuery { Sides = "1 2 10" });
            result.ShouldHaveValidationErrorFor(x => x.Sides)
                .WithErrorMessage("The sides must satisfy the triangle inequality conditions.");
        }

        [Test]
        public void ValidSidesShouldPassValidation()
        {
            var result = _validator.TestValidate(new GetTriangleTypeQuery { Sides = "3 4 5" });
            result.ShouldNotHaveValidationErrorFor(x => x.Sides);
        }
    }
}