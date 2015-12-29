using System;
using System.ComponentModel.DataAnnotations;

namespace MasteredTrax.Models
{
    public class Blog
    {
        public int Id { get; set; }
        [Required]
        [StringLength(255, MinimumLength = 3)]
        public string Title { get; set; }
        public string Body { get; set; }
        public string Tags { get; set; }
        public DateTime Created { get; set; } = DateTime.UtcNow;
    }
}
