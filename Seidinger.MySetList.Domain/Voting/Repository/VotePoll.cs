using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Seidinger.MySetList.Domain.Music.Entities;
using Seidinger.MySetList.Domain.Voting.VO;
using Seidinger.MySetList.Domain.PersistenceInterfaces;
using Seidinger.MySetList.Domain.Voting.Entities;

namespace Seidinger.MySetList.Domain.Voting.Repository {
    public class VotePoll {
        private IVoteDAO VoteDAO;
        
        public VotePoll(IVoteDAO VoteDAO){
            this.VoteDAO = VoteDAO;
        }

        public Vote FindVoteById(long Id) {
            return VoteDAO.GetById(Id);    
        }

        public IList<Vote> AllVotes() {
            return VoteDAO.All();
        }

        public void SaveVote(Vote NewVote) {
            VoteDAO.Save(NewVote);
        }

        public void DeleteTheVote(Vote vote) {
            VoteDAO.Delete(vote);
        }

        public IEnumerable<VotesPerSong> AllVotesPerSongForBand(Band band) {
            var bandVotes = this.VoteDAO.VotesCastedTo(band);
            var sumOfVotes = from vote in bandVotes group vote by vote.VotedSong into votePerSong select new VotesPerSong() { Song = votePerSong.Key, NumberOfVotes = votePerSong.Count() };
            return sumOfVotes;
        }
    }
}
