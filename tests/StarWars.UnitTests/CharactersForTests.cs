using StarWars.Core.Domain;
using StarWars.Infrastructure.DTO;
using System.Collections.Generic;

namespace StarWars.UnitTests
{
    public static class CharactersForTests
    {
        public static List<Character> GetCharacters()
        {
            return new List<Character>
            {
               new Character(1)
                {
                    Name = "Luke Skywalker",
                    Planet = new Planet() { Name = "Alderaan" },
                    Episodes = new List<Episode> { new Episode() { Name = "NEWHOPE" }, new Episode() { Name = "EMPIRE" }, new Episode() { Name = "JEDI" }  },
                    Friends = new List<Character> { new Character() { Name = "Han Solo" }, new Character() { Name = "Leia Organa" }, new Character() { Name = "C-3PO" } }
                },
                new Character(2)
                {
                    Name = "Darth Vader",
                    Episodes = new List<Episode> { new Episode() { Name = "NEWHOPE" }, new Episode() { Name = "EMPIRE" }, new Episode() { Name = "JEDI" }  },
                    Friends = new List<Character> { new Character() { Name = "Wilhuff Tarkin" } }
                },
                 new Character(3)
                {
                    Name = "Han Solo",
                    Planet = new Planet() { Name = "Eadu" },
                    Episodes = new List<Episode> { new Episode() { Name = "NEWHOPE" }, new Episode() { Name = "EMPIRE" }, new Episode() { Name = "JEDI" }  },
                    Friends = new List<Character> { new Character() { Name = "Luke Skywalker" }, new Character() { Name = "Leia Organa" }, new Character() { Name = "R2-D2" } }
                },
                 new Character(4)
                {
                    Name = "Leia Organa",
                    Planet = new Planet() { Name = "Alderaan" },
                    Episodes = new List<Episode> { new Episode() { Name = "NEWHOPE" }, new Episode() { Name = "EMPIRE" }, new Episode() { Name = "JEDI" }  },
                    Friends = new List<Character> { new Character() { Name = "Luke Skywalker" }, new Character() { Name = "Han Solo" }, new Character() { Name = "C-3PO" }, new Character() { Name = "R2-D2" } }
                },
                  new Character(5)
                {
                    Name = "Wilhuff Tarkin",
                    Planet = new Planet() { Name = "Alderaan" },
                    Episodes = new List<Episode> { new Episode() { Name = "NEWHOPE" } },
                    Friends = new List<Character> { new Character() { Name = "Darth Vader" } }
                },
                  new Character(6)
                {
                    Name = "C-3PO",
                    Episodes = new List<Episode> { new Episode() { Name = "NEWHOPE" }, new Episode() { Name = "EMPIRE" }, new Episode() { Name = "JEDI" }  },
                    Friends = new List<Character> { new Character() { Name = "Luke Skywalker" }, new Character() { Name = "Han Solo" }, new Character() { Name = "Leia Organa" }, new Character() { Name = "R2-D2" } }
                },
                   new Character(7)
                {
                    Name = "R2-D2",
                    Episodes = new List<Episode> { new Episode() { Name = "NEWHOPE" }, new Episode() { Name = "EMPIRE" }, new Episode() { Name = "JEDI" }  },
                    Friends = new List<Character> { new Character() { Name = "Luke Skywalker" }, new Character() { Name = "Han Solo" }, new Character() { Name = "Leia Organa" } }
                }
            };
        }

        public static List<CharacterDTO> GetCharactersDTO()
        {
            return new List<CharacterDTO>
            {
               new CharacterDTO()
                {
                    Name = "Luke Skywalker",
                    Planet = "Alderaan",
                    Episodes = new string[] { "NEWHOPE", "EMPIRE", "JEDI" },
                    Friends = new string[] { "Han Solo","Leia Organa","C-3PO" }
                },
                new CharacterDTO()
                {
                    Name = "Darth Vader",
                     Episodes = new string[] { "NEWHOPE", "EMPIRE", "JEDI" },
                    Friends = new string[] { "Wilhuff Tarkin" }
                },
                 new CharacterDTO()
                {
                    Name = "Han Solo",
                    Planet = "Eadu" ,
                    Episodes = new string[] { "NEWHOPE", "EMPIRE", "JEDI" },
                    Friends = new string[] { "Luke Skywalker", "Leia Organa", "R2-D2" }
                },
                 new CharacterDTO()
                {
                    Name = "Leia Organa",
                    Planet = "Alderaan" ,
                     Episodes = new string[] { "NEWHOPE", "EMPIRE", "JEDI" },
                    Friends = new string[] { "Luke Skywalker", "Han Solo", "C-3PO", "R2-D2" }
                },
                  new CharacterDTO()
                {
                    Name = "Wilhuff Tarkin",
                    Planet = "Alderaan" ,
                    Episodes = new string[] { "NEWHOPE" },
                    Friends = new string[] { "Darth Vader" }
                },
                  new CharacterDTO()
                {
                    Name = "C-3PO",
                     Episodes = new string[] { "NEWHOPE", "EMPIRE", "JEDI" },
                    Friends = new string[] { "Luke Skywalker", "Han Solo", "Leia Organa", "R2-D2" }
                },
                   new CharacterDTO()
                {
                    Name = "R2-D2",
                    Episodes = new string[] { "NEWHOPE", "EMPIRE", "JEDI" },
                    Friends = new string[] { "Luke Skywalker", "Han Solo", "Leia Organa" }
                }
            };
        }

    }
}
