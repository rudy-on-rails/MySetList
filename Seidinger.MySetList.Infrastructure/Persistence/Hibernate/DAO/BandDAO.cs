using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Seidinger.MySetList.Domain.Music.Entities;
using NHibernate;
using Seidinger.MySetList.Domain.PersistenceInterfaces;

namespace Seidinger.MySetList.Infrastructure.Persistence.Hibernate.DAO {
    public class BandDAO : GenericDAO<Band>, IBandDAO{
        public BandDAO(ISession hibernateSession) : base(hibernateSession){      
        }
    }
}
