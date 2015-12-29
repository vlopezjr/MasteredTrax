using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MasteredTrax.Models
{
    public class Artist
    {
        public int Id { get; set; }
        [Required]
        [StringLength(255, MinimumLength = 3)]
        public string Name { get; set; }
        public string Description { get; set; }
        public string Biography { get; set; }
        public string Twitter { get; set; }
        public string Instagram { get; set; }
        public string Facebook { get; set; }
        public string Snapchat { get; set; }
        public string Youtube { get; set; }
        public string Vevo { get; set; }
        public DateTime Created { get; set; } = DateTime.UtcNow;
        public DateTime Modified { get; set; } = DateTime.UtcNow;

        public ICollection<Album> Albums { get; set; }
        public ICollection<Photo> Photos { get; set; }
        public ICollection<Video> Videos { get; set; }
        public ICollection<Event> Events { get; set; }
    }
}