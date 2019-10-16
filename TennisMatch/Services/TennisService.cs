using TennisMatch.Models;

namespace TennisMatch.Services
{
    public class TennisService : ITennisService
    {
        private Player player1;
        private Player player2;
        private PlayerScore score;

        public TennisService()
        {
            player1 = new Player() { Id = 1, Name = "Nadal", PlayerGamePoint = GamePoint.zero };
            player2 = new Player() { Id = 2, Name = "Federer", PlayerGamePoint = GamePoint.zero };
            score = new PlayerScore(player1, player2);
        }

        public Score Get()
        {
            return new PlayerScore(player1, player2);
        }

        public Score Increment(int id, int sp1, int sp2)
        {
            player1 = new Player() { Id = 1, Name = "Nadal", PlayerGamePoint = (GamePoint)sp1 };
            player2 = new Player() { Id = 2, Name = "Federer", PlayerGamePoint = (GamePoint)sp2 };
            score = new PlayerScore(player1, player2);
            return id == 1 ? score.Increment(player1) : score.Increment(player2);
        }
    }
}