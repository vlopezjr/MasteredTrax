using System;
using Microsoft.Data.Entity;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MasteredTrax.Models
{
    public class MasteredTraxRepository : IMasteredTraxRepository
    {
        private MastedTraxContext _context;

        public MasteredTraxRepository(MastedTraxContext context)
        {
            _context = context;
        }
        public IEnumerable<Artist> GetAllArtist()
        {
            return _context.Artists
            .Include(a => a.Albums)
            .Include(a => a.Photos)
            .Include(a => a.Videos)
            .Include(a => a.Events)
            .OrderBy(a => a.Name).ToList();
        }

        public Artist GetArtistById(int id)
        {
            return _context.Artists
            .Include(a => a.Albums)
            .Include(a => a.Photos)
            .Include(a => a.Videos)
            .Include(a => a.Events)
            .Where(a => a.Id == id)
            .SingleOrDefault();
        }

        public void AddArtist(Artist artist)
        {
            _context.Add(artist);
        }

        public void UpdateArtist(Artist artist)
        {
            _context.Update(artist, GraphBehavior.SingleObject);
        }

        public void DeleteArtist(int id)
        {
            var artist = GetArtistById(id);

            _context.Remove(artist);
        }

        public bool SaveAll()
        {
            return _context.SaveChanges() > 0;
        }
    }
}
