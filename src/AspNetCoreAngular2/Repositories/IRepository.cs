using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetCoreAngular2.Repositories
{
    public interface IRepository<T>
    {
       T GetById( int id );

    }
}
