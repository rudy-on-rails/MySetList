using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Seidinger.MySetList.Infrastructure.Persistence.Hibernate;
using Seidinger.MySetList.Infrastructure.Persistence.Hibernate.DAO;
using Seidinger.MySetList.Domain.Music.Entities;

namespace Seidinger.MySetList.ConsoleUtils {
    class CreateSchema {
        static void Main(string[] args){
            var sessionFactory = HibernateSession.SessionFactory();
            var session = sessionFactory.OpenSession();
            BandDAO bandDAO = new BandDAO(session);
            var band = new Band();
            band.BandName = "PanterA";
            using (var transaction = session.BeginTransaction()) {
                bandDAO.Save(band);
                transaction.Commit();
            }
            Console.ReadKey();
        }
    }
}
