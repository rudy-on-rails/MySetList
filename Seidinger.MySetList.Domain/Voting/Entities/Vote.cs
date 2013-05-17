using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Seidinger.MySetList.Domain.Music.Entities;

namespace Seidinger.MySetList.Domain.Voting.Entities {
    public class Vote {
        public virtual int Id { get; protected set; }
        public virtual DateTime VotingDate { get; set; }
        public virtual Band VotedBand { get; set; }
        public virtual Song VotedSong { get; set; }
    }
}
