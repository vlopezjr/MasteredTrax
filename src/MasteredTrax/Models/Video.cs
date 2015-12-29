using System;
using System.ComponentModel.DataAnnotations;

namespace MasteredTrax.Models
{
    public class Video
    {
        public int Id { get; set; }
        [Required]
        [StringLength(255, MinimumLength = 3)]
        public string Title { get; set; }
        public string Description { get; set; }
        public string Mp4 { get; set; }
        public string ExternalLink { get; set; }
        public DateTime Created { get; set; } = DateTime.UtcNow;
        public DateTime Modified { get; set; } = DateTime.UtcNow;
    }
}