using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Seidinger.MySetList.Domain.Voting.Entities;

namespace Seidinger.MySetList.Domain.Music.Entities {
    public class Song {
        public virtual int Id { get; protected set; }
        public virtual string SongName { get; set; }
        public virtual IList<Vote> ReceivedVotes { get; protected set; }
        public virtual Band Band { get; set; }
        
        public Song() {
            this.ReceivedVotes = new List<Vote>();            
        }
    }
}
