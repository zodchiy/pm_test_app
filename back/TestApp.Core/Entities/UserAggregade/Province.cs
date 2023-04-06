using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestApp.Core.Interfaces;

namespace TestApp.Core.Entities.UserAggregade
{
    public class Province : BaseEntity, IAggregateRoot
    {
        public string Name { get; private set; }
        public int CountrydId { get; private set; }
        public Country? Country { get; private set; }
        public Province(int countrydId, string name)
        {
            CountrydId = countrydId;
            Name = name;
            
        }
    }
}
