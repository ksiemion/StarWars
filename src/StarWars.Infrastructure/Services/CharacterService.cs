using StarWars.Core.Domain;
using StarWars.Core.Repositories;
using StarWars.Infrastructure.DTO;
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

        public CharacterService(IRepository repository)
        {
            _repository = repository;
        }

        public CharacterDTO GetCharacter(int id)
        {
            try
            {
                var chr = _repository.GetById<Character>(id, e => e.Episodes, e => e.Friends);
                if (chr != null)
                    return new CharacterDTO()
                    {
                        ID = chr.ID,
                        Name = chr.Name,
                        Episodes = GetEpisodes(chr.Episodes),
                        Friends = GetFriends(chr.Friends),
                        Planet = chr.Planet
                    };
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
                var chr = _repository.GetAll<Character>(x => x.Episodes, x => x.Friends);
                if (chr != null)
                    return chr.Select(ce => new CharacterDTO()
                    {
                        ID = ce.ID,
                        Name = ce.Name,
                        Episodes = GetEpisodes(ce.Episodes),
                        Friends = GetFriends(ce.Friends),
                        Planet = ce.Planet
                    });
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
                var chr = _repository.GetByPage<Character>(pageNumber, pageSize, x => x.Episodes, x => x.Friends);
                if (chr != null)
                    return chr.Select(ce => new CharacterDTO()
                    {
                        ID = ce.ID,
                        Name = ce.Name,
                        Episodes = GetEpisodes(ce.Episodes),
                        Friends = GetFriends(ce.Friends),
                        Planet = ce.Planet
                    });
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
                {
                    _repository.Add(new Character()
                    {
                        Name = character.Name,
                        Friends = GetFriends(character.Friends),
                        Episodes = GetEpisodes(character.Episodes),
                        Planet = character.Planet

                    });
                }
            }
            catch
            {
                //TODO: error
            }
        }

        public void Update(int id, CharacterDTO character)
        {
            try
            {
                if (character != null)
                {
                    Character chr = _repository.GetById<Character>(id, x => x.Episodes, x => x.Friends);
                    if (chr != null)
                    {
                        if (!string.IsNullOrEmpty(character.Name))
                            chr.Name = character.Name;

                        if (character.Episodes != null)
                            if (character.Episodes.Length > 0)
                                chr.Episodes = GetEpisodes(character.Episodes);

                        if (character.Friends != null)
                            if (character.Episodes.Length > 0)
                                chr.Friends = GetFriends(character.Friends);

                        if (!string.IsNullOrEmpty(character.Planet))
                            chr.Planet = character.Planet;

                        _repository.Update(chr);
                    }
                }
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


        //TODO: change this !!!!!
        private string[] GetEpisodes(ICollection<Episode> episodes)
        {
            List<string> result = new List<string>();
            if (episodes != null)
            {
                foreach (var epi in episodes)
                {
                    result.Add(epi.Name);
                }
            }

            return result.ToArray();
        }

        private ICollection<Episode> GetEpisodes(string[] episodes)
        {
            List<Episode> result = new List<Episode>();
            if (episodes != null)
            {
                foreach (var epiName in episodes)
                {
                    var epi = _repository.GetBy<Episode>(e => e.Name == epiName);
                    if (epi != null)
                        result.Add(epi);
                }
            }
            return result.ToArray();
        }

        private string[] GetFriends(ICollection<Character> friends)
        {
            List<string> result = new List<string>();
            if (friends != null)
            {
                foreach (var fri in friends)
                {
                    result.Add(fri.Name);
                }
            }
            return result.ToArray();
        }

        private ICollection<Character> GetFriends(string[] friends)
        {
            List<Character> result = new List<Character>();
            if (friends != null)
            {
                foreach (string friName in friends)
                {
                    var fri = _repository.GetBy<Character>(e => e.Name == friName);
                    if (fri != null)
                        result.Add(fri);
                }
            }
            return result.ToArray();
        }

    }
}
