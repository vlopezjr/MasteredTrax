using System;
using System.Collections.Generic;

namespace MasteredTrax.Models
{
    public interface IArtistRepository
    {
        void Add(Artist item);
        IEnumerable<Artist> GetAll();
        //Artist Find(int id);
        //Artist Remove(int id);
        //void Update(Artist item);
        bool SaveAll();
    }
}
