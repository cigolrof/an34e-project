using System;
using System.Collections.Generic;

namespace BancoAcessaDados.Interface {
    public interface IRepository<T> where T: class {
        string Save(T entity);
        string Removed(T entity);
        string searchId(Int32 id);
        IEnumerable<T> ListAll();
    }
}
