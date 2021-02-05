using AutoMapper;
using StarWars.Core.Domain;
using StarWars.Core.Repositories;
using StarWars.Infrastructure.DTO;
using System;
using System.Collections.Generic;

namespace StarWars.Infrastructure.Services
{
    public interface IPlanetService
    {
        PlanetDTO GetByID(int id);
        IEnumerable<PlanetDTO> GetAll();
        Planet Add(PlanetDTO planet);
        void Update(int id, PlanetDTO planet);
        void Delete(int id);
    }

    public class PlanetService : IPlanetService
    {
        private readonly IRepository _repository;
        private readonly IMapper _mapper;

        public PlanetService(IRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public Planet Add(PlanetDTO planet)
        {
            return _repository.Add(_mapper.Map<Planet>(planet));
        }

        public void Delete(int id)
        {
            _repository.Delete<Planet>(id);
        }

        public IEnumerable<PlanetDTO> GetAll()
        {
            var pl = _repository.GetAll<Planet>();
            if (pl != null)
            {
                return _mapper.Map<IEnumerable<PlanetDTO>>(pl);
            }
            else return null;
        }

        public PlanetDTO GetByID(int id)
        {
            var pl = _repository.GetById<Planet>(id);
            if (pl != null)
            {
                return _mapper.Map<PlanetDTO>(pl);
            }
            else return null;
        }

        public void Update(int id, PlanetDTO planet)
        {
            var oldPl = _repository.GetById<Character>(id);
            if (oldPl == null)
                throw new Exception($"Could not find a planet with id: {id}");

            var newPl = _mapper.Map(planet, oldPl);
            _repository.Update(newPl);
        }
    }
}
