using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetCoreAngular2.Repositories
{
    public class Pager<T>
    {
        public int Count { get; set; }
        public int TotalCount { get; set; }
        public int PageCount { get; set; }
        public List<T> List { get; set; }
    }
}
