using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AspNetCoreAngular2.EF;

namespace AspNetCoreAngular2.Repositories
{
    public class UserRepository: IUserRepository
    {
        private MainDBContext context;

        public UserRepository(MainDBContext context)
        {
            this.context = context;
        }

        public User GetByLogin(string login)
        {
          return this.context.Users.FirstOrDefault( n => n.UserName == login );
        }

        public void Update(string login, bool isAdmin,string email, string passwordHash)
        {
            var user = this.context.Users.FirstOrDefault( n => n.UserName == login );
            if (user!=null)
            {
                user.IsAdmin = isAdmin;
                user.PasswordHash = passwordHash;
                user.Email = email;
            }
            else
            {
                throw new Exception( "Данный пользователь отсутствует!" );
            }
           
        }

        public void AddUser(string login,bool isAdmin, string email, string passwordHash)
        {
            if (GetByLogin(login)==null)
            {
                var user = new User()
                {
                    UserName = login,
                    IsAdmin = isAdmin,
                    PasswordHash = passwordHash,
                    Email = email
                };
                this.context.Users.Add( user );
            }
            else
            {
                throw new Exception( String.Format( "User {0} already exists in DataBase",login) );
            }
        }

        public Pager<User> GetUsers(int page,int pageCount)
        {
            var users = this.context.Users.Skip( page * pageCount ).Take( pageCount ).ToList();
            return new Pager<User>()
            {
                Count = users.Count,
                List = users,
                TotalCount = this.context.Users.Count(),
                PageCount = pageCount
            };
        }
    }
}
