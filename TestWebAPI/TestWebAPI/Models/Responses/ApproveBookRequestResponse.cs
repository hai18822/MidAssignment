namespace TestWebAPI.Models.Responses
{
    public class ApproveBookRequestResponse
    {
        public int Id { get; set; }
        public string Status { get; set; }
        public int RequestedUserId { get; set; }
        public DateTime? RequestedDate { get; set; }
    }
}
