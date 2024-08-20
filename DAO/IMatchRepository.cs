using SponsorAPI.Models;
using System.Text.RegularExpressions;

namespace SponsorAPI.DAO
{
    public interface IMatchRepository
    {
        public interface IMatchRepository
        {
            Task<IEnumerable<Matches>> GetMatchesWithTotalPaymentsAsync();
        }
    }
}
