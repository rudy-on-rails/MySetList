using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Seidinger.MySetList.Domain.Voting.Entities;

namespace Seidinger.MySetList.Domain.Music.Entities {
    public class Band {
        public virtual int Id { get; protected set; }
        public virtual string BandName { get; set; }
        public virtual IList<Vote> SetListVotes { get; protected set; }
        public virtual IList<Song> Songs { get; protected set; }

        public Band() {
            this.Songs = new List<Song>();
            this.SetListVotes = new List<Vote>();
        }
    }
}
