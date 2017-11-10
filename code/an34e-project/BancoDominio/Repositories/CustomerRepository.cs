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
        public string Insert(Customer entity) {
            try {

                ClearParameter();
                AddParameter("@Nome", entity.Name);
                AddParameter("@Responsible", entity.Responsible);
                AddParameter("@Area", entity.Area);
                AddParameter("@NpsStatus", entity.NpsStatus);
                AddParameter("@CustomerSince", entity.CustomerSince);
                AddParameter("@LastAvaliation", entity.LastAvaliation);                

                return null;
            } catch (Exception ex) {

                return ex.Message;
            }            
        }

        public string Alter(Customer entity) {
            return null;
        }
    }
}
