namespace RetriggerMail.Models
{
    public class CommunicationLog
    {
        public int Id { get; set; }
        public string ClaimNumber { get; set; }
        public string RecipientEmail { get; set; }
        public string RecipientMobile { get; set; }
        public string TemplateName { get; set; }
        public string MessageBody { get; set; }
        public DateTime SentDate { get; set; }
        public bool IsSuccess { get; set; }
    }
}
