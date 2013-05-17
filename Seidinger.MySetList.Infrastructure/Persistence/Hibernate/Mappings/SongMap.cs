using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentNHibernate.Mapping;
using Seidinger.MySetList.Domain.Music.Entities;

namespace Seidinger.MySetList.Infrastructure.Persistence.Hibernate.Mappings {
    internal class SongMap : ClassMap<Song> {
        public SongMap() {
            Id(x => x.Id);
            Map(x => x.SongName);
            References(x => x.Band);
            HasMany(x => x.ReceivedVotes).Inverse().Cascade.All();
        }
    }
}
