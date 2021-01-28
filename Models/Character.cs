using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace StarWars.Models
{
    public class Character
    {
        [Key]
        public int ID { get; set; }
        public string Name { get; set; }
        public string Planet { get; set; }
        public virtual ICollection<Episode> Episodes { get; set; }

        public virtual ICollection<Character> Friends { get; set; }
        public virtual ICollection<Character> FriendOf { get; set; }
    }
}
