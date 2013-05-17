using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NHibernate;
using NHibernate.Linq;
using Seidinger.MySetList.Domain.Voting.Entities;
using Seidinger.MySetList.Domain.Music.Entities;
using Seidinger.MySetList.Domain.PersistenceInterfaces;

namespace Seidinger.MySetList.Infrastructure.Persistence.Hibernate.DAO {
    public class VoteDAO : GenericDAO<Vote>, IVoteDAO {
        public VoteDAO(ISession hibernateSession) : base(hibernateSession){
        }

        public IList<Vote> VotesCastedTo(Band band) {
            var votes = (from vote in hibernateSesssion.Query<Vote>()
            where vote.VotedBand != null && vote.VotedBand.Id == band.Id select vote).ToList();
            return votes;
        }
    }
}
