using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace JobTrackerAPI.Repository.Entities
{

    [Table("interviews")]
    public class InterviewEntity
    {
        [Key]
        [Column("id")]
        public Guid Id { get; set; }

        [Required]
        [Column("title")]
        public string Title { get; set; } = null!;

        [Required]
        [Column("datetime")]
        public DateTime Datetime { get; set; }

        [Column("created_at")]
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        [Required]
        [Column("job_advertisement_id")]
        public Guid JobAdvertisementId { get; set; }

        public JobEntity Job { get; set; } = null!;
    }
}
