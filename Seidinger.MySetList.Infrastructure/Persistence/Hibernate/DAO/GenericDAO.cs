using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NHibernate;
using Seidinger.MySetList.Domain.PersistenceInterfaces;

namespace Seidinger.MySetList.Infrastructure.Persistence.Hibernate.DAO {
    public abstract class GenericDAO<T> : IDAO<T> where T : class {
        public ISession hibernateSesssion { get; set; }
        public GenericDAO(ISession hibernateSession) {
            this.hibernateSesssion = hibernateSession;
        }

        public T GetById(long id) {
            return hibernateSesssion.Get<T>(id);
        }

        public void Save(T entity) {
            this.hibernateSesssion.SaveOrUpdate(entity);
        }

        public void Delete(T entity) {
            this.hibernateSesssion.Delete(entity);
        }
        
        public IList<T> All() {
            ICriteria criteria = hibernateSesssion.CreateCriteria<T>();
            return criteria.List<T>();
        }        
    }
}
