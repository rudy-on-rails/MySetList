using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Seidinger.MySetList.Domain.PersistenceInterfaces;
using Seidinger.MySetList.Domain.Music.Entities;

namespace Seidinger.MySetList.Domain.Music.Repository {
    public class SongsRepository{
        private ISongDAO songDAO;
        public SongsRepository(ISongDAO songDAO){
            this.songDAO = songDAO;
        }

        public Song GetById(long id) {
            return this.songDAO.GetById(id);
        }

        public void Save(Song song) {
            this.songDAO.Save(song);
        }

        public void Delete(Song song) {
            this.songDAO.Delete(song);
        }

        public IList<Song> All() {
            return this.songDAO.All();
        }
    }
}
