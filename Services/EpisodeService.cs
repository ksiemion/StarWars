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
        void Add(Episode character);
        void Update(int id, Episode character);
        void Delete(int id);
    }

    public class EpisodeService : IEpisodeService
    {
        //private readonly AppDBContext _context;

        //public EpisodeService(AppDBContext context)
        //{
        //    _context = context;
        //}

        public void Add(Episode episode)
        {
            //_context.Episodes.Add(episode);
            //_context.SaveChanges();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Episode GetByID(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(int id, Episode character)
        {
            throw new NotImplementedException();
        }
    }
}
