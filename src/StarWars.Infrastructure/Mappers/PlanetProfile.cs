using AutoMapper;
using StarWars.Core.Domain;
using StarWars.Infrastructure.DTO;

namespace StarWars.Infrastructure.Mappers
{
    public class PlanetProfile: Profile
    {
        public PlanetProfile()
        {
            CreateMap<Planet, PlanetDTO>().ReverseMap();
        }
    }
}
