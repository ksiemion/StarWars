using StarWars.Data;
using StarWars.DTO;
using StarWars.Models;
using System.Collections.Generic;
using System.Linq;

namespace StarWars.Services
{
    public interface IEpisodeService
    {
        EpisodeDTO GetByID(int id);
        IEnumerable<EpisodeDTO> GetEpisodes();
        void Add(EpisodeDTO character);
        void Update(int id, EpisodeDTO character);
        void Delete(int id);
    }

    public class EpisodeService : IEpisodeService
    {
        private readonly AppDBContext _context;

        public EpisodeService(AppDBContext context)
        {
            _context = context;
        }

        public IEnumerable<EpisodeDTO> GetEpisodes()
        {
            var ep = _context.Episodes.ToList();
            if (ep != null)
                return ep.Select(ce => new EpisodeDTO()
                {
                    Name = ce.Name
                });
            else return null;
        }

        public void Add(EpisodeDTO episode)
        {
            if (episode != null)
            {
                _context.Episodes.Add(new Episode()
                {
                    Name = episode.Name,

                });
                _context.SaveChanges();
            }
        }

        public void Delete(int id)
        {
            var ep = _context.Episodes.SingleOrDefault(c => c.ID == id);
            if (ep != null)
            {
                _context.Episodes.Remove(ep);
                _context.SaveChanges();
            }
        }

        public EpisodeDTO GetByID(int id)
        {
            var ep = _context.Episodes.SingleOrDefault(c => c.ID == id);
            if (ep != null)
                return new EpisodeDTO()
                {
                    Name = ep.Name
                };
            else return null;
        }

        public void Update(int id, EpisodeDTO episode)
        {
            if (episode != null)
            {
                var ep = _context.Episodes.SingleOrDefault(c => c.ID == id);
                if (ep != null)
                {
                    if (!string.IsNullOrEmpty(episode.Name))
                        ep.Name = episode.Name;

                    _context.SaveChanges();
                }
            }
        }
    }
}
