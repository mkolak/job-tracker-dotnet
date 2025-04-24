using System.ComponentModel.DataAnnotations;

namespace JobTrackerAPI.WebAPI.Entities
{
    public class InterviewRequestDto
    {
        [Required]
        public string Title { get; set; } = string.Empty!;
        
        [Required]
        public DateTime Datetime { get; set; }

        [Required]
        public Guid JobAdvertisementId { get; set; }
    }
}
