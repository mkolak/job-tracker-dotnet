namespace JobTrackerAPI.Model.Entities
{
    public class Job
    {
        public Guid Id { get; set; }
        public string Advertisement { get; set; } = null!;
        public string Advertiser { get; set; } = null!;
        public string? AdvertiserWebsite { get; set; }
        public string? Location { get; set; }
        public string? AdvertisementUrl { get; set; }
        public string Status { get; set; } = "pending";
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime AppliedAt { get; set; } = DateTime.UtcNow;
        public ICollection<Interview> Interviews { get; set; } = new List<Interview>();
    }
}
