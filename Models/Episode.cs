using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace StarWars.Models
{
    public class Episode
    {
        [Key]
        public int ID { get; set; }
        public string Name { get; set; }
        public virtual ICollection<Character> Characters { get; set; }
    }
}
