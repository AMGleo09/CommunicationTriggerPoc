using RetriggerMail.Models;

namespace RetriggerMail.Repository
{
    public interface ICommunicationService
    {
        Task<IEnumerable<CommunicationLog>> GetLogsByClaimAsync(string claimNumber);
        Task<bool> RetriggerAsync(int logId);
    }
}
