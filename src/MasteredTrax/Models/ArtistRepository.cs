using System;
using Microsoft.Data.Entity;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MasteredTrax.Models
{
    public class ArtistRepository : IArtistRepository
    {
        private MastedTraxContext _context;

        public ArtistRepository(MastedTraxContext context)
        {
            _context = context;
        }
        public IEnumerable<Artist> GetAll()
        {
            return _context.Artists
            .Include(a => a.Albums)
            .Include(a => a.Photos)
            .Include(a => a.Videos)
            .Include(a => a.Events)
            .OrderBy(a => a.Name).ToList();
        }

        public void Add(Artist artist)
        {
            _context.Add(artist);
        }

        public bool SaveAll()
        {
            return _context.SaveChanges() > 0;
        }
    }
}
