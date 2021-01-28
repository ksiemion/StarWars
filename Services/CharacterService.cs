using StarWars.Data;
using StarWars.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StarWars.Services
{
    public interface ICharacterService
    {
        Character GetCharacter(int id);
        List<Character> GetCharacters();
        void Add(Character character);
        void Update(int id, Character character);
        void Delete(int id);
    }

    public class CharacterService : ICharacterService
    {
        private readonly AppDBContext _context;

        public CharacterService(AppDBContext context)
        {
            _context = context;
        }

        public Character GetCharacter(int id)
        {
            return _context.Characters.SingleOrDefault(c => c.ID == id);
        }

        public List<Character> GetCharacters()
        {
            return _context.Characters.ToList();
        }

        public void Add(Character character)
        {
            _context.Characters.Add(character);
            _context.SaveChanges();
        }

        public void Update(int id, Character character)
        {
            Character chr = _context.Characters.SingleOrDefault(c => c.ID == id);
            if (chr != null)
            {
                chr.Name = character.Name;
                chr.Episodes = character.Episodes;
                chr.Friends = character.Friends;
                chr.Planet = character.Planet;
                _context.SaveChanges();
            }
        }

        public void Delete(int id)
        {
            Character chr = _context.Characters.SingleOrDefault(c => c.ID == id);
            if (chr != null)
            {
                _context.Characters.Remove(chr);
                _context.SaveChanges();
            }
        }
    }
}
