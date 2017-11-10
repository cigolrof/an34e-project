using BancoAcessaDados.Interface;
using DataBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BancoDominio.Repositories {
    class UserRepository : Context, IRepository<User> {
        public IEnumerable<User> ListAll() {
            throw new NotImplementedException();
        }

        public string Removed(User entity) {
            throw new NotImplementedException();
        }

        public string Save(User entity) {
            throw new NotImplementedException();
        }

        public string searchId(int id) {
            throw new NotImplementedException();
        }
    }
}
