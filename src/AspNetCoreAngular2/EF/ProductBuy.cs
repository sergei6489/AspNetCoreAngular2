using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetCoreAngular2.EF
{
    public class ProductBuy
    {
        public virtual Product Product {get;set;}
        public int Count { get; set; }
    }
}
