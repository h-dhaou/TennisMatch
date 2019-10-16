using TennisMatch.Models;

namespace TennisMatch.Services
{
    public interface ITennisService
    {
        Score Get();
        Score Increment(int id, int sp1, int sp2);
        
    }
}
