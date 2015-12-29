using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MasteredTrax.Models
{
    public class Album
    {
        public int Id { get; set; }
        [Required]
        [StringLength(255, MinimumLength = 3)]
        public string Name { get; set; }
        public string Description { get; set; }
        public  DateTime ReleaseDate { get; set; }
        public DateTime Created { get; set; } = DateTime.UtcNow;
        public DateTime Modified { get; set; } = DateTime.UtcNow;
        public ICollection<Song> Songs { get; set; }
    }
}