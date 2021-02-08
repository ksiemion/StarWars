using AutoMapper;
using StarWars.Core.Domain;
using StarWars.Infrastructure.DTO;

namespace StarWars.Infrastructure.Mappers
{
    public class EpisodeProfile : Profile
    {
        public EpisodeProfile()
        {
            CreateMap<Episode, EpisodeDTO>().ReverseMap();
            
        }
    }
}
