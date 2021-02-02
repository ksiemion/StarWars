using System.Collections.Generic;

namespace StarWars.Core.Domain
{
    public class Episode : BaseEntity
    {
        public string Name { get;  set; }
        public virtual ICollection<Character> Characters { get;  set; }
    }
}
