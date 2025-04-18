using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace JobTrackerAPI.Model.Entities
{
    [Table("jobs")]
    public class Job
    {
        [Key]
        [Column("id")]
        public Guid Id { get; set; }

        [Required]
        [Column("advertisement")]
        public string Advertisement { get; set; } = null!;

        [Required]
        [Column("advertiser")]
        public string Advertiser { get; set; } = null!;

        [Column("advertiser_website")]
        public string? AdvertiserWebsite { get; set; }

        [Column("location")]
        public string? Location { get; set; }

        [Column("advertisement_url")]
        public string? AdvertisementUrl { get; set; }

        [Required]
        [Column("status")]
        public string Status { get; set; } = "pending";

        [Column("created_at")]
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        [Column("applied_at")]
        public DateTime AppliedAt { get; set; } = DateTime.UtcNow;

        public ICollection<Interview> Interviews { get; set; } = new List<Interview>();
    }
}
