using System.Web.Http;
using TennisMatch.Models;
using TennisMatch.Services;

namespace TennisMatch.Controllers
{
    public class TennisController : ApiController
    {
        private ITennisService _tennisService;

        public TennisController(ITennisService tennisService)
        {
            _tennisService = tennisService;
        }

        public Score Get()
        {
            return _tennisService.Get();
        }

        public Score Get(int id, int sp1, int sp2)
        {
            return _tennisService.Increment(id, sp1, sp2);

        }
    }
}
