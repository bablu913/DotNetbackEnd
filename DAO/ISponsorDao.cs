using SponsorAPI.Data;

namespace SponsorAPI.DAO
{
    public interface ISponsorDAO
    {
        Task<List<Sponsor>> GetSponsors();
        Task<List<Sponsor>> GetSponsorsDetailsWithPayments();
        Task<List<Sponsor>> GetMatchDetailsWithPayment();
        Task<int> InsertPayment(Sponsor payment);
    }
}
