using BookShelf.Maps;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;
using StructureMap.Attributes;
using StructureMap.Configuration.DSL;

namespace BookShelf.Registries
{
    public class NHibernateRegistry : Registry
    {
        public NHibernateRegistry()
        {
            ForRequestedType<ISessionFactory>()
                .CacheBy(InstanceScope.Singleton)
                .TheDefault.Is.ConstructedBy(() => Fluently.Configure()
                .Database(MsSqlConfiguration.MsSql2008
                .ConnectionString(x => x.FromConnectionStringWithKey("Connection String"))
                .Dialect<NHibernate.Dialect.MsSql2005Dialect>())
                .Mappings(x => x.FluentMappings.AddFromAssemblyOf<BookMap>())
                .BuildSessionFactory());
            ForRequestedType<ISession>()
                .CacheBy(InstanceScope.Hybrid)
                .TheDefault.Is.ConstructedBy((ctx) => ctx.GetInstance<ISessionFactory>().OpenSession());
            ForRequestedType<ITransaction>()
                .CacheBy(InstanceScope.Hybrid)
                .TheDefault.Is.ConstructedBy((ctx) => ctx.GetInstance<ISession>().BeginTransaction());

        }
    }
}
