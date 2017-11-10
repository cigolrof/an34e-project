using System;
using System.Collections.Generic;
using an34e_project.Models;
using BancoAcessaDados.Interface;
using DataBase;

namespace an34e_project.Controllers
{
    public class UserRepository : Context, IRepository<User>
    {
        public IEnumerable<User> ListAll()
        {
            throw new NotImplementedException();
        }

        public string Removed(User entity)
        {
            throw new NotImplementedException();
        }

        public string Save(User entity)
        {
            throw new NotImplementedException();
        }

        public string searchId(int id)
        {
            throw new NotImplementedException();
        }
    }
}