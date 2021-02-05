using AutoMapper;
using StarWars.Core.Domain;
using StarWars.Core.Repositories;
using StarWars.Infrastructure.DTO;
using System;
using System.Collections.Generic;
using System.Linq;

namespace StarWars.Infrastructure.Services
{
    public interface ICharacterService
    {
        CharacterDTO GetCharacter(int id);
        IEnumerable<CharacterDTO> GetCharacters();
        IEnumerable<CharacterDTO> GetCharacters(int pageNumber, int pageSize);
        void Add(CharacterDTO character);
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
            try
            {
                var chr = _repository.GetById<Character>(id, x => x.Episodes, x => x.Friends, x => x.Planet);
                if (chr != null)
                    return _mapper.Map<CharacterDTO>(chr);

                else return null;
            }
            catch
            {
                //TODO: error
                return null;
            }
        }

        public IEnumerable<CharacterDTO> GetCharacters()
        {
            try
            {
                var chr = _repository.GetAll<Character>(x => x.Episodes, x => x.Friends, x => x.Planet);
                if (chr != null)
                    return _mapper.Map<IEnumerable<CharacterDTO>>(chr);

                else return null;
            }
            catch
            {
                return null; //TODO: error
            }
        }

        public IEnumerable<CharacterDTO> GetCharacters(int pageNumber, int pageSize)
        {
            try
            {
                var chr = _repository.GetByPage<Character>(pageNumber, pageSize, x => x.Episodes, x => x.Friends, x => x.Planet);
                if (chr != null)
                    return _mapper.Map<IEnumerable<CharacterDTO>>(chr);

                else return null;
            }
            catch
            {
                return null; //TODO: error
            }
        }

        public void Add(CharacterDTO character)
        {
            try
            {
                if (character != null)
                    _repository.Add(_mapper.Map<Character>(character));
            }
            catch(Exception exc)
            {
                //TODO: error
            }
        }

        public void Update(int id, CharacterDTO character)
        {
            try
            {
                if (character != null)
                    _repository.Update(_mapper.Map<Character>(character));
            }
            catch
            {
                //TODO: error
            }
        }

        public void Delete(int id)
        {
            try
            {
                _repository.Delete<Character>(id);
            }
            catch
            {
                //TODO: error
            }
        }
    }
}
