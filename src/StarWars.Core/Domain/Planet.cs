using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StarWars.Core.Domain
{
    public class Planet : BaseEntity
    {
        public string Name { get; set; }
        public virtual ICollection<Character> Characters { get; set; }
    }
}
