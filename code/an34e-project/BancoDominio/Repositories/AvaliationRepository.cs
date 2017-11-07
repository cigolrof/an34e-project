using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BancoAcessaDados;
using BancoAcessaDados.Interface;
using DataBase;

namespace BancoDominio.Repositories {
    public class AvaliationRepository : Context, IRepository<Avaliation> {
        public IEnumerable<Avaliation> ListAll() {
            throw new NotImplementedException();
        }

        public string Removed(Avaliation entity) {
            throw new NotImplementedException();
        }

        public string Save(Avaliation entity) {
            throw new NotImplementedException();
        }

        public string searchId(int id) {
            throw new NotImplementedException();
        }

        public string Insert(Avaliation entity) {
            return null;
        }

        public string Alter(Avaliation entity) {
            return null;
        }
    }
}
