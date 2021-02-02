using System;
using System.Collections.Generic;
using System.Text;

namespace StarWars.Core.Domain
{
    public abstract class BaseEntity
    {
        public int ID { get; protected set; }
    }
}
