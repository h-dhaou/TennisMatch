using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using TennisMatch.Controllers;
using TennisMatch.Models;
using TennisMatch.Services;

namespace TennisMatch.Tests
{
    [TestClass]
    public class TennisControllerTests
    {
        [TestMethod]
        public void Get()
        {
            // Arrange
            var player1 = new Player() { Id = 1, Name = "Nadal", PlayerGamePoint = GamePoint.zero };
            var player2 = new Player() { Id = 2, Name = "Federer", PlayerGamePoint = GamePoint.zero };
            var mockService = new Mock<ITennisService>();
            mockService.Setup(service => service.Get()).Returns(new PlayerScore(player1, player2));
            TennisController controller = new TennisController(mockService.Object);

            // Act
            Score result = controller.Get();

            // Assertf
            Assert.IsNotNull(result);
            result.Player1.Id.Should().Be(1);
            result.Player1.Name.Should().Be("Nadal");
            result.Player1.PlayerGamePoint.Should().Be(GamePoint.zero);
            result.Player2.Id.Should().Be(2);
            result.Player2.Name.Should().Be("Federer");
            result.Player2.PlayerGamePoint.Should().Be(GamePoint.zero);
        }
    }
}
