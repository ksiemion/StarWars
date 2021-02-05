﻿using AutoMapper;
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
    public class CharacterProfile : Profile
    {
        public CharacterProfile()
        {
            CreateMap<Character, CharacterDTO>()
                .ForMember(dest => dest.Episodes, opt => opt.MapFrom(c => c.Episodes.Select(x => x.Name).ToArray()))
                .ForMember(dest => dest.Friends, opt => opt.MapFrom(c => c.Friends.Select(x => x.Name).ToArray()))
                 .ForMember(dest => dest.Planet, opt => opt.MapFrom(c => c.Planet.Name));

            CreateMap<CharacterDTO, Character>()
                .ForMember(dest => dest.Episodes, opt => opt.MapFrom<EpisodeResolver>())
                .ForMember(dest => dest.Friends, opt => opt.MapFrom<FriendResolver>())
                .ForMember(dest => dest.Planet, opt => opt.MapFrom<PlanetResolver>());
        }
    }
}
