namespace JobTrackerAPI.Model.Entities
{
    public class Interview
    {
        public Guid Id { get; set; }
        public string Title { get; set; } = null!;
        public DateTime Datetime { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public Guid JobAdvertisementId { get; set; }
        public Job Job { get; set; } = null!;
    }
}
