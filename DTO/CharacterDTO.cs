using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StarWars.DTO
{
    public class CharacterDTO
    {
        public string Name { get; set; }
        public string[] Episodes { get; set; }
        public string[] Friends { get; set; }
        public string Planet { get; set; }
    }
}
