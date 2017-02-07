using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AspNetCoreAngular2.EF;

namespace AspNetCoreAngular2.Repositories
{
    public interface IUserRepository
    {
        User GetByLogin( string login );
        void Update( string login, bool isAdmin, string email, string passwordHash );
        void AddUser( string login, bool isAdmin, string email, string passwordHash );
        Pager<User> GetUsers( int page, int pageCount );
    }
}
