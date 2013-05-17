using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Seidinger.MySetList.Domain.Music.Entities;

namespace Seidinger.MySetList.Domain.Voting.VO {
    public class VotesPerSong {
        public Song Song { get; set; }
        public int NumberOfVotes { get; set; }
    }
}
