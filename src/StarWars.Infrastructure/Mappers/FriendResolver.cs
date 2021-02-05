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
    public class FriendResolver : IValueResolver<CharacterDTO, Character, ICollection<Character>>
    {
        private readonly IRepository _repository;

        public FriendResolver(IRepository repository)
        {
            _repository = repository;
        }

        public ICollection<Character> Resolve(CharacterDTO source, Character destination, ICollection<Character> destMember, ResolutionContext context)
        {
            List<Character> coll = new List<Character>();
            if (source.Friends != null)
            {
                foreach (string name in source.Friends)
                {
                    var epi = _repository.GetBy<Character>(X => X.Name == name);
                    if (epi != null)
                    {
                        coll.Add(epi);
                    }
                }
            }
            return coll;
        }
    }
}
