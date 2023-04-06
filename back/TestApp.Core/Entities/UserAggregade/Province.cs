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
        public int CountryId { get; private set; }
        public Country? Country { get; private set; }
#pragma warning disable CS8618 // Required by Entity Framework
        private Province() { }
        public Province(int countrydId, string name)
        {
            CountryId = countrydId;
            Name = name;            
        }
    }
}
