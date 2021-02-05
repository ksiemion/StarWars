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
        void Add(PlanetDTO planet);
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

        public void Add(PlanetDTO planet)
        {
            try
            {
                if (planet != null)
                {
                    _repository.Add(_mapper.Map<Planet>(planet));
                }
            }
            catch (Exception exc)
            {
                //TODO: error
            }
        }

        public void Delete(int id)
        {
            try
            {
                _repository.Delete<Planet>(id);
            }
            catch
            {
                //TODO: error
            }
        }

        public IEnumerable<PlanetDTO> GetAll()
        {
            try
            {
                var pl = _repository.GetAll<Planet>();
                if (pl != null)
                    return _mapper.Map<IEnumerable<PlanetDTO>>(pl);

                else return null;
            }
            catch
            {
                return null; //TODO: error
            }
        }

        public PlanetDTO GetByID(int id)
        {
            try
            {
                var pl = _repository.GetById<Planet>(id);
                if (pl != null)
                    return _mapper.Map<PlanetDTO>(pl);
                else return null;
            }
            catch
            {
                //TODO: error
                return null;
            }
        }

        public void Update(int id, PlanetDTO planet)
        {
            try
            {
                if (planet != null)
                {
                    _repository.Update(_mapper.Map<Planet>(planet));
                    
                }
            }
            catch
            {
                //TODO: error
            }
        }
    }
}
