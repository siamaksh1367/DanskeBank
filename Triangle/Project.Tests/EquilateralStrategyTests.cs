namespace Project.Tests
{
    using System.Collections.Generic;
    using FluentAssertions;
    using NUnit.Framework;
    using Project.Domain.Strategies;

    public class EquilateralStrategyTests
    {
        [Test]
        public void DetermineTriangleType_ShouldReturnEquilateral_WhenAllSidesAreEqual()
        {
            // Arrange
            var equilateralStrategy = new EquilateralStrategy();

            // Act
            var result = equilateralStrategy.DetermineTriangleType(new[] { 5.0, 5.0, 5.0 });

            // Assert
            result.Should().Be("Equilateral");
        }

        [Test]
        public void DetermineTriangleType_ShouldReturnNull_WhenSidesAreNotEqual()
        {
            // Arrange
            var equilateralStrategy = new EquilateralStrategy();

            // Act
            var result = equilateralStrategy.DetermineTriangleType(new[] { 3.0, 4.0, 5.0 });

            // Assert
            result.Should().BeNull();
        }
    }

}