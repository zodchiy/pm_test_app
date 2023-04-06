using Ardalis.Specification;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestApp.Core.Entities.UserAggregade;

namespace TestApp.Core.Specifications
{
    public sealed class ProvinceFilterSpecification : Specification<Province>
    {
        public ProvinceFilterSpecification(int? countryId)
        {
            Query.Where(i => (!countryId.HasValue || i.CountryId == countryId));
        }
    }
}
