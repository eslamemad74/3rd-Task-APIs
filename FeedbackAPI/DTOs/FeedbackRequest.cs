namespace FeedbackAPI.DTOs
{
    public class FeedbackRequest
    {
        public string UserName { get; set; }
        public int Rate { get; set; }
        public string Comment { get; set; }
    }
}