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
    public class EpisodeResolver : IValueResolver<CharacterDTO, Character, ICollection<Episode>>
    {
        private readonly IRepository _repository;

        public EpisodeResolver(IRepository repository)
        {
            _repository = repository;
        }

        public ICollection<Episode> Resolve(CharacterDTO source, Character destination, ICollection<Episode> destMember, ResolutionContext context)
        {
            List<Episode> coll = new List<Episode>();
            if (source.Episodes != null)
            {
                foreach (string name in source.Episodes)
                {
                    var epi = _repository.GetBy<Episode>(X => X.Name == name);
                    if (epi != null)
                        coll.Add(epi);
                }
            }
            return coll;
        }
    }
}
