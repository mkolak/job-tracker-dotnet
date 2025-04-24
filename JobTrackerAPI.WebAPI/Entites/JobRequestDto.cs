using System.ComponentModel.DataAnnotations;

namespace JobTrackerAPI.WebAPI.Entities
{
    public class JobRequestDto
    {
        [Required]
        public string Advertisement { get; set; } = null!;

        [Required]
        public string Advertiser { get; set; } = null!;

        public string? AdvertiserWebsite { get; set; }
        public string? Location { get; set; }
        public string? AdvertisementUrl { get; set; }

        [Required]
        public string Status { get; set; } = "pending";

        public DateTime? AppliedAt { get; set; } // optional – if null, use default in service
    }
}
