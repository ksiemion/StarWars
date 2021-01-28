using StarWars.Data;
using StarWars.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StarWars.Services
{
    public interface IEpisodeService
    {
        Episode GetByID(int id);
        IEnumerable<Episode> GetEpisodes();
        void Add(Episode character);
        void Update(int id, Episode character);
        void Delete(int id);
    }

    public class EpisodeService : IEpisodeService
    {
        private readonly AppDBContext _context;

        public EpisodeService(AppDBContext context)
        {
            _context = context;
        }

        public IEnumerable<Episode> GetEpisodes()
        {
            return _context.Episodes.ToList();
        }

        public void Add(Episode episode)
        {
            _context.Episodes.Add(episode);
            _context.SaveChanges();
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

        public Episode GetByID(int id)
        {
            var ep = _context.Episodes.SingleOrDefault(c => c.ID == id);
            return ep;
        }

        public void Update(int id, Episode episode)
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
