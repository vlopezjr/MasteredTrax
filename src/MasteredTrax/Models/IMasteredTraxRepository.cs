using System;
using System.Collections.Generic;

namespace MasteredTrax.Models
{
    public interface IMasteredTraxRepository
    {
        IEnumerable<Artist> GetAllArtist();
        Artist GetArtistById(int id);
        void AddArtist(Artist artist);
        void UpdateArtist(Artist artist);
        void DeleteArtist(int id);
        bool SaveAll();
    }
}
