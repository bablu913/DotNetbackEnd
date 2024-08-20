using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SponsorAPI.DAO;

namespace SponsorAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MatchesController : ControllerBase
    {
        private readonly IMatchRepository _matchRepository;

        public MatchesController(IMatchRepository matchRepository)
        {
            _matchRepository = matchRepository;
        }

       
       
    }
}
