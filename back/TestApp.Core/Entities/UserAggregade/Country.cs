using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestApp.Core.Interfaces;

namespace TestApp.Core.Entities.UserAggregade
{
    public class Country : BaseEntity, IAggregateRoot
    {
        public string Name { get; private set; }
        public Country(string name)
        {
            Name = name;
        }
    }
}
