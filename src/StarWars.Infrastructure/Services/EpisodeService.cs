using AutoMapper;
using StarWars.Core.Domain;
using StarWars.Core.Repositories;
using StarWars.Infrastructure.DTO;
using System;
using System.Collections.Generic;
using System.Linq;

namespace StarWars.Infrastructure.Services
{
    public interface IEpisodeService
    {
        EpisodeDTO GetByID(int id);
        IEnumerable<EpisodeDTO> GetEpisodes();
        Episode Add(EpisodeDTO character);
        void Update(int id, EpisodeDTO character);
        void Delete(int id);
    }

    public class EpisodeService : IEpisodeService
    {
        private readonly IRepository _repository;
        private readonly IMapper _mapper;

        public EpisodeService(IRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public EpisodeDTO GetByID(int id)
        {
            var ep = _repository.GetById<Episode>(id);
            if (ep != null)
            {
                return _mapper.Map<EpisodeDTO>(ep);
            }
            else return null;
        }

        public IEnumerable<EpisodeDTO> GetEpisodes()
        {
            var ep = _repository.GetAll<Episode>(null);
            if (ep != null)
            {
                return _mapper.Map<IEnumerable<EpisodeDTO>>(ep);
            }
            else return null;
        }

        public Episode Add(EpisodeDTO episode)
        {
            return _repository.Add(_mapper.Map<Episode>(episode));
        }

        public void Update(int id, EpisodeDTO episode)
        {
            var oldEpi = _repository.GetById<Episode>(id);
            if (oldEpi == null)
                throw new Exception($"Could not find a episode with id: {id}");

            var newEpi = _mapper.Map(episode, oldEpi);
            _repository.Update(newEpi);
        }

        public void Delete(int id)
        {
            _repository.Delete<Episode>(id);
        }
    }
}
