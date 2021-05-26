using AspCoreAppWithTests.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspCoreAppWithTests.Repository
{
    public class UserRepository:IUserRepository
    {
        public MovieApplicationContext _context { get; set; }

        public UserRepository(MovieApplicationContext context)
        {
            _context = context;
        }

        public User GetUser(LoginCredential credential)
        {
            return _context.Users.SingleOrDefault(U => U.UserName == credential.UserName);
        }
    }
}
