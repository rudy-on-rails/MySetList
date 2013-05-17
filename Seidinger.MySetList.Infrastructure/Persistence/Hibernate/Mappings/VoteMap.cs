using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentNHibernate.Mapping;
using Seidinger.MySetList.Domain.Voting.Entities;

namespace Seidinger.MySetList.Infrastructure.Persistence.Hibernate.Mappings {
    internal class VoteMap : ClassMap<Vote> {
        public VoteMap() {
            Id(x => x.Id);
            Map(x => x.VotingDate);
            References(x => x.VotedBand).Not.Nullable();
            References(x => x.VotedSong).Not.Nullable();
        }
    }
}
