using AutoMapper;
using StarWars.Core.Domain;
using StarWars.Core.Repositories;
using StarWars.Infrastructure.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StarWars.Infrastructure.Mappers
{
    public class PlanetResolver : IValueResolver<CharacterDTO, Character, Planet>
    {
        private readonly IRepository _repository;

        public PlanetResolver(IRepository repository)
        {
            _repository = repository;
        }

        public Planet Resolve(CharacterDTO source, Character destination, Planet destMember, ResolutionContext context)
        {
            var name = source.Planet;
            var pl = _repository.GetBy<Planet>(x=>x.Name == name);
            return pl;
        }
    }
}
