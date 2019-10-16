using System;
using TennisMatch.Models;

namespace TennisMatch.Services
{
    public class PlayerScore: Score
    {
        public PlayerScore(Player player1, Player player2)
            : base(player1, player2)
        {
        }

        public Score Increment(Player player)
        {
            Score score = null;
            var diff = Math.Abs((int)Player1.PlayerGamePoint - (int)Player2.PlayerGamePoint);
            if ((int)player.PlayerGamePoint < 3)
            {
                player.PlayerGamePoint += 1;
                score = player.Id == 1 ? new PlayerScore(player, Player2) :
                    new PlayerScore(Player1, player);
            }
            else
            {
                if(diff == 0)
                {
                    if(player.Id == Player1.Id)
                    {
                        Player1.PlayerGamePoint = GamePoint.Advantage;
                        Player2.PlayerGamePoint = GamePoint.Deuce;
                    }
                    else
                    {
                        Player1.PlayerGamePoint = GamePoint.Deuce;
                        Player2.PlayerGamePoint = GamePoint.Advantage;                        
                    }                    
                }
                else
                {
                    if(player.Id == Player1.Id)
                    {
                        Player1.PlayerGamePoint = Player2.PlayerGamePoint = Player1.PlayerGamePoint > Player2.PlayerGamePoint ? GamePoint.zero : GamePoint.Deuce;                        
                    }
                    else
                    {
                        Player1.PlayerGamePoint = Player2.PlayerGamePoint = Player1.PlayerGamePoint > Player2.PlayerGamePoint ? GamePoint.Deuce : GamePoint.zero;                        
                    }                    
                }

                score = new PlayerScore(Player1, Player2);
            }
            return score;
        }
    }
}