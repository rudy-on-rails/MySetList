using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using Seidinger.MySetList.Domain.Music.Entities;
using Seidinger.MySetList.Domain.Voting.Entities;
using NHibernate;
using Seidinger.MySetList.Infrastructure.Persistence.Hibernate;
using Seidinger.MySetList.Infrastructure.Persistence.Hibernate.DAO;

namespace Seidinger.MySetList.Tests.Infrastructure.Persistence {
    
    [TestFixture]
    public class VoteDAOTest {
        private ISession session;
        private VoteDAO voteDao;
        private BandDAO bandDao;
        private SongDAO songDao;

        [SetUp]
        public void SetUp() {            
            session = HibernateSession.SessionFactory().OpenSession();
            voteDao = new VoteDAO(session);
            songDao = new SongDAO(session);
            bandDao = new BandDAO(session);
        }
        [TearDown]
        public void Close() {            
            session.Close();
            session.Dispose();
        }

        [Test]
        public void VotesPerBand_ShouldReturnOne() {
            Band myNewBand = new Band();
            myNewBand.BandName = "My Band";
            bandDao.Save(myNewBand);
            var bandSong = new Band() {
                BandName = "Ozzy Osbourne"
            };
            bandDao.Save(bandSong);
            Song song = new Song();
            song.Band = bandSong;
            song.SongName = "Crazy Train";
            songDao.Save(song);
            Vote vote = new Vote();
            vote.VotedBand = myNewBand;
            vote.VotedSong = song;
            vote.VotingDate = DateTime.Now;
            voteDao.Save(vote);
            IList<Vote> votesCasted = voteDao.VotesCastedTo(myNewBand);
            Assert.AreEqual(1, votesCasted.Count);
        }

    }
}
