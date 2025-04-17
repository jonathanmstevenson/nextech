namespace Application.DTOs
{
    public class StoryDTO
    {
        public int Id { get; set; }
        public string? By { get; set; }
        public int Descendants { get; set; }
        public List<int>? Kids { get; set; }
        public int Score { get; set; }
        public int Time { get; set; }
        public string? Title { get; set; }
        public required string Type { get; set; }   // The type of item. One of "job", "story", "comment", "poll", or "pollopt".
        public string? Url { get; set; }
    }
}