using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace JobTrackerAPI.Model.Entities
{
    [Table("interviews")]
    public class Interview
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

        public Job Job { get; set; } = null!;
    }
}
