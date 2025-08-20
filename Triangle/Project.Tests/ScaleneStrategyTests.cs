using FluentAssertions;
using Project.Domain.Strategies;

namespace Project.Tests
{
    public class ScaleneStrategyTests
    {
        [Test]
        public void DetermineTriangleType_ShouldReturnScalene_WhenAllSidesAreDistinct()
        {
            // Arrange
            var scaleneStrategy = new ScaleneStrategy();

            // Act
            var result = scaleneStrategy.DetermineTriangleType(new[] { 3.0, 4.0, 5.0 });

            // Assert
            result.Should().Be("Scalene");
        }

        [Test]
        public void DetermineTriangleType_ShouldReturnNull_WhenTwoSidesAreEqual()
        {
            // Arrange
            var scaleneStrategy = new ScaleneStrategy();

            // Act
            var result = scaleneStrategy.DetermineTriangleType(new[] { 3.0, 4.0, 4.0 });

            // Assert
            result.Should().BeNull();
        }

        [Test]
        public void DetermineTriangleType_ShouldReturnNull_WhenAllSidesAreEqual()
        {
            // Arrange
            var scaleneStrategy = new ScaleneStrategy();

            // Act
            var result = scaleneStrategy.DetermineTriangleType(new[] { 4.0, 4.0, 4.0 });

            // Assert
            result.Should().BeNull();
        }
    }
}