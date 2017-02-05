using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetCoreAngular2.EF
{
    public class UserBuy
    {
        public virtual ProductBuy Product { get; set; }
        public virtual User User { get; set; }
        public DateTime Date { get; set; }
    }
}
