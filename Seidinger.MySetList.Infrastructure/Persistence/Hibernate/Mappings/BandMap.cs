using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentNHibernate.Mapping;
using Seidinger.MySetList.Domain.Music.Entities;

namespace Seidinger.MySetList.Infrastructure.Persistence.Hibernate.Mappings {
    internal class BandMap : ClassMap<Band>  {
        public BandMap() {
            Id(x => x.Id);
            Map(x => x.BandName);
            HasMany(x => x.SetListVotes).Inverse().Cascade.All();
            HasMany(x => x.Songs);
        }
    }
}
