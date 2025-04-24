namespace JobTrackerAPI.WebAPI.Entities
{
    public class MonthlyStatsResponseDto
    {
        public int Year { get; set; }
        public int Month { get; set; }
        public int Pending { get; set; }
        public int Interview { get; set; }
        public int Rejected { get; set; }
    }
}