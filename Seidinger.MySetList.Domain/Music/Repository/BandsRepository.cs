using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Seidinger.MySetList.Domain.PersistenceInterfaces;
using Seidinger.MySetList.Domain.Music.Entities;

namespace Seidinger.MySetList.Domain.Music.Repository {
    public class BandsRepository{
        private IBandDAO bandDAO;
        public BandsRepository(IBandDAO bandDAO) {
            this.bandDAO = bandDAO;
        }

        public Band GetById(long id) {
            return this.bandDAO.GetById(id);
        }

        public void Save(Band entity) {
            this.bandDAO.Save(entity);
        }

        public void Delete(Band entity) {
            this.bandDAO.Delete(entity);
        }

        public IList<Band> All() {
            return this.bandDAO.All();
        }
    }
}
