using System;
using System.ComponentModel.DataAnnotations;

namespace MasteredTrax.Models
{
    public class Photo
    {
        public int Id { get; set; }
        [Required]
        [StringLength(255, MinimumLength = 3)]
        public string Title { get; set; }
        public string Caption { get; set; }
        public string Source { get; set; }
        public DateTime Created { get; set; } = DateTime.UtcNow;
        public DateTime Modified { get; set; } = DateTime.UtcNow;
    }
}