using System;
using Seidinger.MySetList.Domain.Voting.Entities;
using System.Collections.Generic;
using Seidinger.MySetList.Domain.Music.Entities;
namespace Seidinger.MySetList.Domain.PersistenceInterfaces {
    public interface IVoteDAO : IDAO<Vote> {
        IList<Vote> VotesCastedTo(Band band);
    }
}
