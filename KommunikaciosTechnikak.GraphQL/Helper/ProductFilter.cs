using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KommunikaciosTechnikak.GraphQL.Helper
{
    public class ProductFilter
    {
        public string Name { get; set; }
        public string ProductNumber { get; set; }
        public DateTime? SellStartDate { get; set; }
        public DateTime? SellEndDate { get; set; }
    }
}
