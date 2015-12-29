using System;
using System.ComponentModel.DataAnnotations;

namespace MasteredTrax.Models
{
    public class Song
    {
        public int Id { get; set; }
        [Required]
        [StringLength(255, MinimumLength = 3)]
        public string Name { get; set; }
        public string Mp3 { get; set; }
        public DateTime Created { get; set; } = DateTime.UtcNow;
        public DateTime Modified { get; set; } = DateTime.UtcNow;
    }
}