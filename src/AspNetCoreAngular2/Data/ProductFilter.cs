using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetCoreAngular2.Data
{
    public class ProductFilter
    {
        public string Name { get; set; }
        public decimal? MinimalPrice { get; set; }
        public decimal? MaxPrice { get; set; }
        public string Category { get; set; }
    }
}
