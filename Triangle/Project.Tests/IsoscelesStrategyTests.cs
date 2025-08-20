using FluentAssertions;
using Project.Domain.Strategies;

namespace Project.Tests
{
    public class IsoscelesStrategyTests
    {
        [Test]
        public void DetermineTriangleType_ShouldReturnIsosceles_WhenTwoSidesAreEqual()
        {
            // Arrange
            var isoscelesStrategy = new IsoscelesStrategy();

            // Act
            var result = isoscelesStrategy.DetermineTriangleType(new[] { 3.0, 4.0, 4.0 });

            // Assert
            result.Should().Be("Isosceles");
        }

        [Test]
        public void DetermineTriangleType_ShouldReturnNull_WhenNoSidesAreEqual()
        {
            // Arrange
            var isoscelesStrategy = new IsoscelesStrategy();

            // Act
            var result = isoscelesStrategy.DetermineTriangleType(new[] { 3.0, 4.0, 5.0 });

            // Assert
            result.Should().BeNull();
        }

        [Test]
        public void DetermineTriangleType_ShouldReturnNull_WhenAllSidesAreEqual()
        {
            // Arrange
            var isoscelesStrategy = new IsoscelesStrategy();

            // Act
            var result = isoscelesStrategy.DetermineTriangleType(new[] { 4.0, 4.0, 4.0 });

            // Assert
            result.Should().BeNull();
        }
    }
}