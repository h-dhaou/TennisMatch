namespace TennisMatch.Models
{
    public class Score
    {
        public Player Player1;
        public Player Player2;

        public Score(Player player1, Player player2)
        {
            Player1 = player1;
            Player2 = player2;
        }
    }
}