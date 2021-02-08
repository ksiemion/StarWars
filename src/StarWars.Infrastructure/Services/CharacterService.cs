using AutoMapper;
using StarWars.Core.Domain;
using StarWars.Core.Repositories;
using StarWars.Infrastructure.DTO;
using System;
using System.Collections.Generic;

namespace StarWars.Infrastructure.Services
{
    public interface ICharacterService
    {
        CharacterDTO GetCharacter(int id);
        IEnumerable<CharacterDTO> GetCharacters();
        IEnumerable<CharacterDTO> GetCharacters(int pageNumber, int pageSize);
        Character Add(CharacterDTO character);
        void Update(int id, CharacterDTO character);
        void Delete(int id);
    }

    public class CharacterService : ICharacterService
    {
        private readonly IRepository _repository;
        private readonly IMapper _mapper;

        public CharacterService(IRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public CharacterDTO GetCharacter(int id)
        {
            var chr = _repository.GetById<Character>(id, x => x.Episodes, x => x.Friends, x => x.Planet);
            if (chr != null)
            {
                return _mapper.Map<CharacterDTO>(chr);
            }
            else return null;
        }

        public IEnumerable<CharacterDTO> GetCharacters()
        {
            var chr = _repository.GetAll<Character>(x => x.Episodes, x => x.Friends, x => x.Planet);
            if (chr != null)
            {
                return _mapper.Map<IEnumerable<CharacterDTO>>(chr);
            }
            else return null;
        }

        public IEnumerable<CharacterDTO> GetCharacters(int pageNumber, int pageSize)
        {
            var chr = _repository.GetByPage<Character>(pageNumber, pageSize, x => x.Episodes, x => x.Friends, x => x.Planet);
            if (chr != null)
            {
                return _mapper.Map<IEnumerable<CharacterDTO>>(chr);
            }

            else return null;
        }

        public Character Add(CharacterDTO character)
        {
            return _repository.Add(_mapper.Map<Character>(character));
        }

        public void Update(int id, CharacterDTO character)
        {
            var oldChr = _repository.GetById<Character>(id, x => x.Episodes, x => x.Friends, x => x.Planet);
            if (oldChr == null)
            {
                throw new Exception($"Could not find a character with id: {id}");
            }

            var newChr = _mapper.Map(character, oldChr);
            _repository.Update(newChr);
        }

        public void Delete(int id)
        {
            _repository.Delete<Character>(id);
        }
    }
}
