using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetCoreAngular2.EF
{
    public class ProductComment
    {
        public virtual User User { get; set; }
        public virtual Product Product {get;set;}
        public string Text { get; set; }
        public int Mark { get; set; }
    }
}
