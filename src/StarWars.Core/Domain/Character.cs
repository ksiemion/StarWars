using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace StarWars.Core.Domain
{
    public class Character : BaseEntity
    {
        public string Name { get; set; }
        public Planet Planet { get; set; }
        public virtual ICollection<Episode> Episodes { get; set; }
        public virtual ICollection<Character> Friends { get; set; }
        [JsonIgnore]
        public virtual ICollection<Character> FriendOf { get; set; }

        public Character() { }
        public Character(int id)
        {
            ID = id;
        }
    }
}
