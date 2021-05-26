using AspCoreAppWithTests.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspCoreAppWithTests.Repository
{
    public interface IUserRepository
    {
        public User GetUser(LoginCredential credential);

    }
}
