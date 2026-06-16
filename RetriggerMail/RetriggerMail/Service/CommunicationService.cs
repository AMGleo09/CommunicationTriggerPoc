using RetriggerMail.Models;
using RetriggerMail.Repository;
using RetriggerMail.Data;
using Microsoft.EntityFrameworkCore;

namespace RetriggerMail.Service
{
    public class CommunicationService: ICommunicationService
    {
        private readonly InsuranceDbContext _context;

        public CommunicationService(InsuranceDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<CommunicationLog>> GetLogsByClaimAsync(string claimNumber)
        {
            return await _context.CommunicationLogs
                .Where(l => l.ClaimNumber == claimNumber)
                .ToListAsync();
        }

        public async Task<bool> RetriggerAsync(int logId)
        {
            var log = await _context.CommunicationLogs.FindAsync(logId);
            if (log == null) return false;

            // Simulate sending communication
            await Task.Delay(500); // mimic async call to SMS/Email gateway
            log.IsSuccess = true;
            log.SentDate = DateTime.Now;

            await _context.SaveChangesAsync();
            return true;
        }
    }
}
