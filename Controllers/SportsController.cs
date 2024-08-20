using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SponsorAPI.DAO;
using SponsorAPI.Data;


namespace SponsorAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SportsController : ControllerBase
    {
        private readonly ISponsorDAO _sponsorDao;

        public SportsController(ISponsorDAO sponsorDao)
        {
            _sponsorDao = sponsorDao;

        }

        [HttpGet]
        public async Task<ActionResult<Sponsor>> GetAllSponsors()
        {
            List<Sponsor>? spFound = await _sponsorDao.GetSponsors();
            if (spFound == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(spFound);
            }
        }
        [HttpGet("GetSponsorsWithPayments ",Name = "GetSponsorsWithPayments")]
        public async Task<ActionResult<Sponsor>> GetSponsorsWithPayments()
        {
            List<Sponsor>? spFound = await _sponsorDao.GetSponsorsDetailsWithPayments();
            if (spFound == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(spFound);
            }
        }

        [HttpGet("GetMatchDetails ", Name = "GetMatchDetails")]
        public async Task<ActionResult<Sponsor>> GetMatchDetails()
        {
            List<Sponsor>? spFound = await _sponsorDao.GetMatchDetailsWithPayment();
            if (spFound == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(spFound);
            }
        }
        [HttpPost(Name = "AddPayment")]
        public async Task<ActionResult<bool>> CreatePayment(Sponsor payment)
        {
            if (payment == null)
            {
                return BadRequest("Product Not Found");
            }
            else
            {
                int value = await _sponsorDao.InsertPayment(payment);
                return Ok(value);
            }
        }
    }
}
