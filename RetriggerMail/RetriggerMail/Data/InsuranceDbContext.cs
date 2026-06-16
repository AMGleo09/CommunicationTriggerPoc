using Microsoft.EntityFrameworkCore;
using RetriggerMail.Models;

namespace RetriggerMail.Data
{
    public class InsuranceDbContext : DbContext
    {
        public InsuranceDbContext(DbContextOptions<InsuranceDbContext> options) : base(options)
        {
        }

        public DbSet<CommunicationLog> CommunicationLogs { get; set; }

        // Data/InsuranceDbContext.cs
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CommunicationLog>().HasData(
                new CommunicationLog
                {
                    Id = 1,
                    ClaimNumber = "CLM123",
                    RecipientEmail = "customer1@test.com",
                    RecipientMobile = "9876543210",
                    TemplateName = "Claim Update Email",
                    MessageBody = "Your claim CLM123 is under review.",
                    SentDate = DateTime.Now.AddDays(-1),
                    IsSuccess = false
                },
                new CommunicationLog
                {
                    Id = 2,
                    ClaimNumber = "CLM123",
                    RecipientEmail = "customer1@test.com",
                    RecipientMobile = "9876543210",
                    TemplateName = "Claim Update SMS",
                    MessageBody = "Claim CLM123 status updated.",
                    SentDate = DateTime.Now.AddDays(-1),
                    IsSuccess = true
                },
                new CommunicationLog
                {
                    Id = 3,
                    ClaimNumber = "CLM456",
                    RecipientEmail = "customer2@test.com",
                    RecipientMobile = "9123456789",
                    TemplateName = "Claim Approved Email",
                    MessageBody = "Your claim CLM456 has been approved.",
                    SentDate = DateTime.Now.AddDays(-2),
                    IsSuccess = true
                }
            );
        }


    }
}
