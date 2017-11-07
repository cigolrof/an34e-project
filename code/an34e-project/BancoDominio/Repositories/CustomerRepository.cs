using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BancoAcessaDados.Interface;
using DataBase;

namespace BancoDominio.Repositories {
    class CustomerRepository : Context, IRepository<Customer> {
        public IEnumerable<Customer> ListAll() {
            throw new NotImplementedException();
        }

        public string Removed(Customer entity) {
            throw new NotImplementedException();
        }

        public string Save(Customer entity) {
            throw new NotImplementedException();
        }

        public string searchId(int id) {
            throw new NotImplementedException();
        }
    }
}
