namespace JobTrackerAPI.WebAPI.Entities { 
    public class InterviewResponseDto
    {
        public Guid _id { get; set; }
        public string Title { get; set; } = null!;
        public DateTime Datetime { get; set; }
        public DateTime CreatedAt { get; set; }
        public Guid JobAdvertisementId { get; set; }

        public string? Advertiser { get; set; }
    }
}
