using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NHibernate;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using Seidinger.MySetList.Infrastructure.Persistence.Hibernate.Mappings;
using NHibernate.Tool.hbm2ddl;
using System.IO;
using NHibernate.Cfg;

namespace Seidinger.MySetList.Infrastructure.Persistence.Hibernate {
    public sealed class HibernateSession{
        static readonly object factorylock = new object();
        private static volatile ISessionFactory instance;
        private static readonly string DbFile = "SetListVoting.db";
        
        private HibernateSession() { }

        public static ISessionFactory SessionFactory() {
            if (instance == null) {
                lock (factorylock) {
                    var cfg = Fluently.Configure().Database(SQLiteConfiguration.Standard.ShowSql().UsingFile(DbFile)).
                    Mappings(m => m.FluentMappings.AddFromAssemblyOf<BandMap>()).
                    Mappings(m => m.FluentMappings.AddFromAssemblyOf<VoteMap>()).
                    Mappings(m => m.FluentMappings.AddFromAssemblyOf<SongMap>()).
                    ExposeConfiguration(BuildSchema);
                    instance = cfg.BuildSessionFactory();
                }
            }
            return instance;
        }

        private static void BuildSchema(Configuration config) {
            if (!File.Exists(DbFile)) {
                new SchemaExport(config).Create(false, true);
            }
        }

    }
}
