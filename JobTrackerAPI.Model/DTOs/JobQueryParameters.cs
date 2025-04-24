namespace JobTrackerAPI.Model.DTOs
{
    public class JobQueryParameters
    {
        public string? Advertisement { get; set; }
        public string? Advertiser { get; set; }
        public string? Location { get; set; }
        public string? Status { get; set; }
        public string? Sort { get; set; }
        public string? Fields { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }

        public int Page { get; set; } = 1;
        public int Limit { get; set; } = 10;
    }
}