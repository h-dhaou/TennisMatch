using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TennisMatch.Models;
using TennisMatch.Services;

namespace TennisMatch.Tests
{
    [TestClass]
    public class TennisMatchTests
    {
        [TestMethod]
        public void Start_TheGame_Score_ShouldBe_Zero_Zero()
        {
            // Arrange
            var service = new TennisService();

            // Act
            Score score = service.Get();

            // Assert
            Assert.IsNotNull(score);
            score.Player1.Id.Should().Be(1);
            score.Player1.Name.Should().Be("Nadal");
            score.Player1.PlayerGamePoint.Should().Be(GamePoint.zero);

            score.Player2.Id.Should().Be(2);
            score.Player2.Name.Should().Be("Federer");
            score.Player2.PlayerGamePoint.Should().Be(GamePoint.zero);
        }

        [TestMethod]
        public void Start_TheGame_Player1_WinPoint_First_Point_ShouldBe_Fivteen_Zero()
        {
            // Arrange
            var service = new TennisService();

            // Act
            Score score = service.Increment(1, (int)GamePoint.zero, (int)GamePoint.zero);

            // Assert
            Assert.IsNotNull(score);
            score.Player1.PlayerGamePoint.Should().Be(GamePoint.Fifteen);
            score.Player2.PlayerGamePoint.Should().Be(GamePoint.zero);
        }

        [TestMethod]
        public void Player1_WinPoint_When_Score_Fivteen_zero_Score_ShouldBe_Thirty_zero()
        {
            // Arrange
            var service = new TennisService();

            // Act
            Score score = service.Increment(1, (int)GamePoint.Fifteen, (int)GamePoint.zero);

            // Assert
            Assert.IsNotNull(score);
            score.Player1.PlayerGamePoint.Should().Be(GamePoint.Thirty);
            score.Player2.PlayerGamePoint.Should().Be(GamePoint.zero);
        }

        [TestMethod]
        public void Player1_WinPoint_When_Score_Fivteen_Fivteen_Score_ShouldBe_Thirty_Fivteen()
        {
            // Arrange
            var service = new TennisService();

            // Act
            Score score = service.Increment(1, (int)GamePoint.Fifteen, (int)GamePoint.Fifteen);

            // Assert
            Assert.IsNotNull(score);
            score.Player1.PlayerGamePoint.Should().Be(GamePoint.Thirty);
            score.Player2.PlayerGamePoint.Should().Be(GamePoint.Fifteen);
        }

        [TestMethod]
        public void Player1_WinPoint_When_Score_Thirty_Fivteen_Score_ShouldBe_Fourty_Fivteen()
        {
            // Arrange
            var service = new TennisService();

            // Act
            Score score = service.Increment(1, (int)GamePoint.Thirty, (int)GamePoint.Fifteen);

            // Assert
            Assert.IsNotNull(score);
            score.Player1.PlayerGamePoint.Should().Be(GamePoint.Forty);
            score.Player2.PlayerGamePoint.Should().Be(GamePoint.Fifteen);
        }

        [TestMethod]
        public void Player1_WinPoint_When_Score_Thirty_Thirty_Score_ShouldBe_Fourty_Thirty()
        {
            // Arrange
            var service = new TennisService();

            // Act
            Score score = service.Increment(1, (int)GamePoint.Thirty, (int)GamePoint.Thirty);

            // Assert
            Assert.IsNotNull(score);
            score.Player1.PlayerGamePoint.Should().Be(GamePoint.Forty);
            score.Player2.PlayerGamePoint.Should().Be(GamePoint.Thirty);
        }

        [TestMethod]
        public void Player1_Win_Game_When_Score_Forty_zero_Score_ShouldBe_Zero_Zero()
        {
            // Arrange
            var service = new TennisService();

            // Act
            Score score = service.Increment(1, (int)GamePoint.Forty, (int)GamePoint.zero);

            // Assert
            Assert.IsNotNull(score);
            score.Player1.PlayerGamePoint.Should().Be(GamePoint.zero);
            score.Player2.PlayerGamePoint.Should().Be(GamePoint.zero);
        }

        [TestMethod]
        public void Player1_Win_Game_When_Score_Forty_Fifteen_Score_ShouldBe_Zero_Zero()
        {
            // Arrange
            var service = new TennisService();

            // Act
            Score score = service.Increment(1, (int)GamePoint.Forty, (int)GamePoint.Fifteen);

            // Assert
            Assert.IsNotNull(score);
            score.Player1.PlayerGamePoint.Should().Be(GamePoint.zero);
            score.Player2.PlayerGamePoint.Should().Be(GamePoint.zero);
        }

        [TestMethod]
        public void Player1_Win_Game_When_Score_Forty_thirty_Score_ShouldBe_Zero_Zero()
        {
            // Arrange
            var service = new TennisService();

            // Act
            Score score = service.Increment(1, (int)GamePoint.Forty, (int)GamePoint.Thirty);

            // Assert
            Assert.IsNotNull(score);
            score.Player1.PlayerGamePoint.Should().Be(GamePoint.zero);
            score.Player2.PlayerGamePoint.Should().Be(GamePoint.zero);
        }

        [TestMethod]
        public void Player2_WinPoint_When_Score_Fivteen_zero__Score_ShouldBe_Fivteen_Fivteen()
        {
            // Arrange
            var service = new TennisService();

            // Act
            Score score = service.Increment(2, (int)GamePoint.Fifteen, (int)GamePoint.zero);

            // Assert
            Assert.IsNotNull(score);
            score.Player1.PlayerGamePoint.Should().Be(GamePoint.Fifteen);
            score.Player2.PlayerGamePoint.Should().Be(GamePoint.Fifteen);
        }


        [TestMethod]
        public void Player2_WinPoint_When_Score_Fivteen_Fivteen_Score_ShouldBe_Fivteen_Thirty()
        {
            // Arrange
            var service = new TennisService();

            // Act
            Score score = service.Increment(2, (int)GamePoint.Fifteen, (int)GamePoint.Fifteen);

            // Assert
            Assert.IsNotNull(score);
            score.Player1.PlayerGamePoint.Should().Be(GamePoint.Fifteen);
            score.Player2.PlayerGamePoint.Should().Be(GamePoint.Thirty);
        }


        [TestMethod]
        public void Player2_WinPoint_When_Score_Fivteen_Thirty_Score_ShouldBe_Fivteen_Forty()
        {
            // Arrange
            var service = new TennisService();

            // Act
            Score score = service.Increment(2, (int)GamePoint.Fifteen, (int)GamePoint.Thirty);

            // Assert
            Assert.IsNotNull(score);
            score.Player1.PlayerGamePoint.Should().Be(GamePoint.Fifteen);
            score.Player2.PlayerGamePoint.Should().Be(GamePoint.Forty);
        }

        [TestMethod]
        public void Player2_WinPoint_When_Score_Thirty_Thirty_Score_ShouldBe_Thirty_Forty()
        {
            // Arrange
            var service = new TennisService();

            // Act
            Score score = service.Increment(2, (int)GamePoint.Thirty, (int)GamePoint.Thirty);

            // Assert
            Assert.IsNotNull(score);
            score.Player1.PlayerGamePoint.Should().Be(GamePoint.Thirty);
            score.Player2.PlayerGamePoint.Should().Be(GamePoint.Forty);
        }

        [TestMethod]
        public void Player2_Win_Game_When_Score_zero_Forty_Score_ShouldBe_Zero_Zero()
        {
            // Arrange
            var service = new TennisService();

            // Act
            Score score = service.Increment(2, (int)GamePoint.zero, (int)GamePoint.Forty);

            // Assert
            Assert.IsNotNull(score);
            score.Player1.PlayerGamePoint.Should().Be(GamePoint.zero);
            score.Player2.PlayerGamePoint.Should().Be(GamePoint.zero);
        }

        [TestMethod]
        public void Player2_Win_Game_When_Score_Fifteen_Forty_Score_ShouldBe_Zero_Zero()
        {
            // Arrange
            var service = new TennisService();

            // Act
            Score score = service.Increment(2, (int)GamePoint.Fifteen, (int)GamePoint.Forty);

            // Assert
            Assert.IsNotNull(score);
            score.Player1.PlayerGamePoint.Should().Be(GamePoint.zero);
            score.Player2.PlayerGamePoint.Should().Be(GamePoint.zero);
        }

        [TestMethod]
        public void Player2_Win_Game_When_Score_thirty_Forty_Score_ShouldBe_Zero_Zero()
        {
            // Arrange
            var service = new TennisService();

            // Act
            Score score = service.Increment(2, (int)GamePoint.Thirty, (int)GamePoint.Forty);

            // Assert
            Assert.IsNotNull(score);
            score.Player1.PlayerGamePoint.Should().Be(GamePoint.zero);
            score.Player2.PlayerGamePoint.Should().Be(GamePoint.zero);
        }

        [TestMethod]
        public void Player1_Take_Advantage_When_Score_Forty_Forty_Score_ShouldBe_Advantage_None()
        {
            // Arrange
            var service = new TennisService();

            // Act
            Score score = service.Increment(1, (int)GamePoint.Forty, (int)GamePoint.Forty);

            // Assert
            Assert.IsNotNull(score);
            score.Player1.PlayerGamePoint.Should().Be(GamePoint.Advantage);
            score.Player2.PlayerGamePoint.Should().Be(GamePoint.Deuce);
        }

        [TestMethod]
        public void Player2_Take_Advantage_When_Score_Forty_Forty_Score_ShouldBe_None_Advantage()
        {
            // Arrange
            var service = new TennisService();

            // Act
            Score score = service.Increment(2, (int)GamePoint.Forty, (int)GamePoint.Forty);

            // Assert
            Assert.IsNotNull(score);
            score.Player1.PlayerGamePoint.Should().Be(GamePoint.Deuce);
            score.Player2.PlayerGamePoint.Should().Be(GamePoint.Advantage);
        }

        [TestMethod]
        public void Score_ShouldBe_Deuce_When_Player1_WinPoint_And_Score_Forty_Forty()
        {
            // Arrange
            var service = new TennisService();

            // Act
            Score score = service.Increment(1, (int)GamePoint.Forty, (int)GamePoint.Forty);

            // Assert
            Assert.IsNotNull(score);
            score.Player1.PlayerGamePoint.Should().Be(GamePoint.Advantage);
            score.Player2.PlayerGamePoint.Should().Be(GamePoint.Deuce);
        }

        [TestMethod]
        public void Score_ShouldBe_Deuce_When_Player2_WinPoint_And_Score_Forty_Forty()
        {
            // Arrange
            var service = new TennisService();

            // Act
            Score score = service.Increment(2, (int)GamePoint.Forty, (int)GamePoint.Forty);

            // Assert
            Assert.IsNotNull(score);
            score.Player1.PlayerGamePoint.Should().Be(GamePoint.Deuce);
            score.Player2.PlayerGamePoint.Should().Be(GamePoint.Advantage);
        }

        [TestMethod]
        public void Score_ShouldBe_Deuce_When_Player2_WinPoint_And_Player1_Have_Advantage()
        {
            // Arrange
            var service = new TennisService();

            // Act
            Score score = service.Increment(2, (int)GamePoint.Advantage, (int)GamePoint.Deuce);

            // Assert
            Assert.IsNotNull(score);
            score.Player1.PlayerGamePoint.Should().Be(GamePoint.Deuce);
            score.Player2.PlayerGamePoint.Should().Be(GamePoint.Deuce);
        }

        [TestMethod]
        public void Score_ShouldBe_Deuce_When_Player1_WinPoint_And_Player2_Have_Advantage()
        {
            // Arrange
            var service = new TennisService();

            // Act
            Score score = service.Increment(1, (int)GamePoint.Deuce, (int)GamePoint.Advantage);

            // Assert
            Assert.IsNotNull(score);
            score.Player1.PlayerGamePoint.Should().Be(GamePoint.Deuce);
            score.Player2.PlayerGamePoint.Should().Be(GamePoint.Deuce);
        }

        [TestMethod]
        public void Player1_Win_Game_When_Have_Advantage_Score_ShouldBe_Zero_Zero()
        {
            // Arrange
            var service = new TennisService();

            // Act
            Score score = service.Increment(1, (int)GamePoint.Advantage, (int)GamePoint.Deuce);

            // Assert
            Assert.IsNotNull(score);
            score.Player1.PlayerGamePoint.Should().Be(GamePoint.zero);
            score.Player2.PlayerGamePoint.Should().Be(GamePoint.zero);
        }

        [TestMethod]
        public void Player2_Win_Game_When_Have_Advantage_Score_ShouldBe_Zero_Zero()
        {
            // Arrange
            var service = new TennisService();

            // Act
            Score score = service.Increment(2, (int)GamePoint.Deuce, (int)GamePoint.Advantage);

            // Assert
            Assert.IsNotNull(score);
            score.Player1.PlayerGamePoint.Should().Be(GamePoint.zero);
            score.Player2.PlayerGamePoint.Should().Be(GamePoint.zero);
        }
    }
}
