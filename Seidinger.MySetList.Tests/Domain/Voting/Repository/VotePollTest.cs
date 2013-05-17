using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using Seidinger.MySetList.Domain.Music.Entities;
using Seidinger.MySetList.Domain.Voting.Entities;
using NHibernate;
using Seidinger.MySetList.Domain.PersistenceInterfaces;
using Moq;
using Seidinger.MySetList.Domain.Voting.Repository;

namespace Seidinger.MySetList.Tests.Infrastructure.Persistence {
    
    [TestFixture]
    public class VotePollTest {
        Mock<IVoteDAO> voteDAO;
        VotePoll votePoll;
        Band band;

        [SetUp]
        public void SetUp() {
            this.voteDAO = new Mock<IVoteDAO>();
            this.votePoll = new VotePoll(voteDAO.Object);
            this.band = new Band();
        }

        [Test]
        public void CaseThereAreThreeEqualVotes_ShouldReturnOneInstanceOfVotesPerSong_With3Votes() {             
            var song = new Song();
            var firstVote = new Vote();
            firstVote.VotedSong = song;
            var secondVote = new Vote();
            secondVote.VotedSong = song;
            var thirdVote = new Vote();
            thirdVote.VotedSong = song;
            List<Vote> votesList = new List<Vote>() {firstVote, secondVote, thirdVote};
            this.voteDAO.Setup(x => x.VotesCastedTo(band)).Returns(votesList);
            var votes = this.votePoll.AllVotesPerSongForBand(band);
            var uniqVote = votes.First();
            Assert.AreEqual(1, votes.Count());
            Assert.AreEqual(3, uniqVote.NumberOfVotes);
            Assert.AreEqual(song, uniqVote.Song);
        }

        [Test]
        public void CaseThereAreTwoDifferentVotes_ShouldReturnTwoInstancesOfVotesPerSong_With1VoteEach() {
            var song = new Song();
            var firstVote = new Vote();
            firstVote.VotedSong = song;
            var secondVote = new Vote();
            var otherSong = new Song();
            secondVote.VotedSong = otherSong;
            List<Vote> votesList = new List<Vote>() { firstVote, secondVote };
            this.voteDAO.Setup(x => x.VotesCastedTo(band)).Returns(votesList);
            var votes = this.votePoll.AllVotesPerSongForBand(band);            
            Assert.AreEqual(2, votes.Count());
            var voteOne = votes.First();
            Assert.AreEqual(1, voteOne.NumberOfVotes);
            Assert.AreEqual(song, voteOne.Song);
            var voteTwo = votes.Last();
            Assert.AreEqual(1, voteTwo.NumberOfVotes);
            Assert.AreEqual(otherSong, voteTwo.Song);
        }
    }
}
