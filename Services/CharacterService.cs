using Microsoft.EntityFrameworkCore;
using StarWars.Data;
using StarWars.DTO;
using StarWars.Models;
using System.Collections.Generic;
using System.Linq;

namespace StarWars.Services
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
        private readonly AppDBContext _context;

        public CharacterService(AppDBContext context)
        {
            _context = context;
        }

        public CharacterDTO GetCharacter(int id)
        {
            var chr = _context.Characters.Include(e => e.Episodes).Include(e => e.Friends).SingleOrDefault(c => c.ID == id);
            if (chr != null)
                return new CharacterDTO()
                {
                    Name = chr.Name,
                    Episodes = GetEpisodes(chr.Episodes),
                    Friends = GetFriends(chr.Friends),
                    Planet = chr.Planet
                };
            else return null;
        }

        public IEnumerable<CharacterDTO> GetCharacters()
        {
            var chr = _context.Characters.Include(e => e.Episodes).Include(e => e.Friends).ToList();
            if (chr != null)
                return chr.Select(ce => new CharacterDTO()
                {
                    Name = ce.Name,
                    Episodes = GetEpisodes(ce.Episodes),
                    Friends = GetFriends(ce.Friends),
                    Planet = ce.Planet
                });
            else return null;
        }

        public IEnumerable<CharacterDTO> GetCharacters(int pageNumber, int pageSize)
        {
            var chr = _context.Characters.Include(e => e.Episodes).Include(e => e.Friends)
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize).ToList();

            if (chr != null)
                return chr.Select(ce => new CharacterDTO()
                {
                    Name = ce.Name,
                    Episodes = GetEpisodes(ce.Episodes),
                    Friends = GetFriends(ce.Friends),
                    Planet = ce.Planet
                });
            else return null;
        }

        public void Add(CharacterDTO character)
        {
            if (character != null)
            {
                _context.Characters.Add(new Character()
                {
                    Name = character.Name,
                    Friends = GetFriends(character.Friends),
                    Episodes = GetEpisodes(character.Episodes),
                    Planet = character.Planet

                });
                _context.SaveChanges();
            }
        }

        public void Update(int id, CharacterDTO character)
        {
            if (character != null)
            {
                Character chr = _context.Characters.Include(e => e.Episodes).Include(e => e.Friends).SingleOrDefault(c => c.ID == id);
                if (chr != null)
                {
                    if (!string.IsNullOrEmpty(character.Name))
                        chr.Name = character.Name;

                    if (character.Episodes != null)
                        if (character.Episodes.Length > 0)
                            chr.Episodes = GetEpisodes(character.Episodes);

                    if (character.Episodes != null)
                        if (character.Episodes.Length > 0)
                            chr.Friends = GetFriends(character.Friends);

                    if (!string.IsNullOrEmpty(character.Planet))
                        chr.Planet = character.Planet;

                    _context.SaveChanges();
                }
            }
        }

        public void Delete(int id)
        {
            var chr = _context.Characters.SingleOrDefault(c => c.ID == id);
            if (chr != null)
            {
                _context.Characters.Remove(chr);
                _context.SaveChanges();
            }
        }

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
                    var epi = _context.Episodes.SingleOrDefault(e => e.Name == epiName);
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
                foreach (var friName in friends)
                {
                    var fri = _context.Characters.SingleOrDefault(e => e.Name == friName);
                    if (fri != null)
                        result.Add(fri);
                }
            }
            return result.ToArray();
        }

    }
}
