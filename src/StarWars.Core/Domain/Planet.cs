using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace StarWars.Core.Domain
{
    public class Planet : BaseEntity
    {
        public string Name { get; set; }
        [JsonIgnore]
        public virtual ICollection<Character> Characters { get; set; }
    }
}
