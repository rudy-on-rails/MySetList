using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Seidinger.MySetList.Domain.PersistenceInterfaces {
    public interface IDAO<T> {
        T GetById(long id);
        void Save(T entity);
        void Delete(T entity);
        IList<T> All();
    }
}