using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MasteredTrax.Models
{
    public class MasteredTraxSeedData
    {
        private MastedTraxContext _context;

        public MasteredTraxSeedData(MastedTraxContext context)
        {
            _context = context;
        }

        public void EnsureSeedData()
        {
            if(!_context.Artists.Any())
            {
                var ckan = new Artist()
                {
                    Name = "CKan",
                    Description = "Top artist from Mexico",
                    Biography = "This is the bio",
                    Instagram = "ckan98",
                    Facebook = "ckan98",
                    Twitter = "ckan",
                    Snapchat = "ckan",
                    Youtube = "ckan98",
                    Vevo = "OfficialCKanVEVO",
                    Created = DateTime.UtcNow,
                    Modified = DateTime.UtcNow,
                    Albums = new List<Album>()
                    {
                        new Album()
                        {
                            Name = "Clasificacion C Vol. 1",
                            Description = "Descripton",
                            ReleaseDate = new DateTime(2011, 5, 24),
                            Created = DateTime.UtcNow,
                            Modified = DateTime.UtcNow,
                            Songs = new List<Song>()
                            {
                                new Song() { Name = "La Calle Sabe De Mi Nombre",Mp3 = "LaCalleSabeDeMiNombre.mp3", Created = DateTime.UtcNow, Modified = DateTime.UtcNow },
                                new Song() { Name = "Vivo La Vida Cantando",Mp3 = "VivoLaVidaCantando.mp3", Created = DateTime.UtcNow, Modified = DateTime.UtcNow },
                                new Song() { Name = "Culpame A Mi",Mp3 = "CulpameAMi.mp3", Created = DateTime.UtcNow, Modified = DateTime.UtcNow },
                            }
                        },
                        new Album()
                        {
                            Name = "Clasificacion C Vol. 2",
                            Description = "Descripton",
                            ReleaseDate = new DateTime(2012, 5, 24),
                            Created = DateTime.UtcNow,
                            Modified = DateTime.UtcNow,
                            Songs = new List<Song>()
                            {
                                new Song() { Name = "Intolerable",Mp3 = "Intolerable.mp3", Created = DateTime.UtcNow, Modified = DateTime.UtcNow },
                                new Song() { Name = "Todo Lo Que Brilla No Es Oro",Mp3 = "oro.mp3", Created = DateTime.UtcNow, Modified = DateTime.UtcNow },
                                new Song() { Name = "Yo Soy Quien Soy",Mp3 = "YoSoyQuienSoy.mp3", Created = DateTime.UtcNow, Modified = DateTime.UtcNow },
                            }
                        }
                    },
                    Photos = new List<Photo>()
                    {
                        new Photo() { Title = "Urbano Fest 3", Caption="Saludando al publico", Source="photos/urbano1.png", Created = DateTime.UtcNow,Modified = DateTime.UtcNow},
                        new Photo() { Title = "Urbano Fest 3", Caption="Saludando al publico", Source="photos/urbano2.png", Created = DateTime.UtcNow,Modified = DateTime.UtcNow}
                    },
                    Videos = new List<Video>()
                    {
                        new Video() { Title = "Te Vas", Description="Description", ExternalLink="https://youtu.be/jurjxMNQO-E", Mp4="videos/tevas.mp4", Created = DateTime.UtcNow,Modified = DateTime.UtcNow},
                        new Video() { Title = "Te Vas", Description="Description", ExternalLink="https://youtu.be/jurjxMNQO-E", Mp4="videos/tevas.mp4", Created = DateTime.UtcNow,Modified = DateTime.UtcNow}
                    },
                    Events = new List<Event>()
                    {
                        new Event() { Title = "Urbano Fest 3", Venue = "Pepsi Center", Description = "Urbano Fest 3", Address="151 Drive", City="Mexico DF", State = "Mexico", ZipCode="94949", Date = new DateTime(2015, 10, 21), TicketLink = "", Created = DateTime.UtcNow, Modified = DateTime.UtcNow },
                        new Event() { Title = "Urbano Fest 4", Venue = "Staples Center", Description = "Urbano Fest 4", Address="1069 Olympic", City="Los Angeles", State = "CA", ZipCode="90065", Date = new DateTime(2016, 10, 20), TicketLink = "", Created = DateTime.UtcNow, Modified = DateTime.UtcNow }
                    }
                };

                _context.Artists.Add(ckan);
                _context.Albums.AddRange(ckan.Albums);
                //_context.Songs.AddRange(ckan.Albums.ToList<Album>()[0].Songs);
                //_context.Songs.AddRange(ckan.Albums.ToList<Album>()[1].Songs);
                _context.Photos.AddRange(ckan.Photos);
                _context.Videos.AddRange(ckan.Videos);
                _context.Events.AddRange(ckan.Events);
                _context.SaveChanges();

            }
        }
    }
}
