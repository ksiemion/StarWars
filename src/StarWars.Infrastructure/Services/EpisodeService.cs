using StarWars.Core.Domain;
using StarWars.Core.Repositories;
using StarWars.Infrastructure.DTO;
using System.Collections.Generic;
using System.Linq;

namespace StarWars.Infrastructure.Services
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
        private readonly IRepository _repository;

        public EpisodeService(IRepository repository)
        {
            _repository = repository;
        }

        public EpisodeDTO GetByID(int id)
        {
            try
            {
                var ep = _repository.GetById<Episode>(id);
                if (ep != null)
                    return new EpisodeDTO()
                    {
                        Name = ep.Name
                    };
                else return null;
            }
            catch
            {
                //TODO: error
                return null;
            }
        }

        public IEnumerable<EpisodeDTO> GetEpisodes()
        {
            try
            {
                var ep = _repository.GetAll<Episode>(null);
                if (ep != null)
                    return ep.Select(ce => new EpisodeDTO()
                    {
                        Name = ce.Name
                    });
                else return null;
            }
            catch
            {
                //TODO: error
                return null;
            }
        }

        public void Add(EpisodeDTO episode)
        {
            try
            {
                if (episode != null)
                {
                    _repository.Add(new Episode()
                    {
                        Name = episode.Name
                    });

                    //_context.Episodes.Add(new Episode()
                    //{
                    //    Name = episode.Name,

                    //});
                    //_context.SaveChanges();
                }
            }
            catch
            {
                //TODO: error
            }
        }
        public void Update(int id, EpisodeDTO episode)
        {
            try
            {
                if (episode != null)
                {
                    _repository.Update(new Episode()
                    {
                        Name = episode.Name
                    });

                    //if (ep != null)
                    //{
                    //    if (!string.IsNullOrEmpty(episode.Name))
                    //        ep.Name = episode.Name;

                    //    _context.SaveChanges();
                    //}
                }
            }
            catch
            {
                //TODO: error
            }
        }

        public void Delete(int id)
        {
            try
            {
                _repository.Delete<Episode>(id);
            }
            catch
            {
                //TODO: error
            }
        }
    }
}
