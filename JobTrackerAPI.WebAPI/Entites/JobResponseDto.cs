namespace JobTrackerAPI.WebAPI.Entities
{
    public class JobResponseDto
    {
        public Guid _id { get; set; }
        public Guid id { get; set; }
        public string Advertisement { get; set; } = null!;
        public string Advertiser { get; set; } = null!;
        public string? AdvertiserWebsite { get; set; }
        public string? Location { get; set; }
        public string? AdvertisementUrl { get; set; }
        public string Status { get; set; } = null!;
        public DateTime CreatedAt { get; set; }
        public DateTime AppliedAt { get; set; }
        public ICollection<InterviewResponseDto> Interviews { get; set; } = new List<InterviewResponseDto>();
    }
}
