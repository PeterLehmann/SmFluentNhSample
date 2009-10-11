using System;
using System.Configuration;
using BookShelf.Db;
using MigratorClass = Migrator.Migrator;

namespace BookShelf.Migrators
{
    public class MigratorSet
    {
        public static void Setup(ConnectionStringSettings connectionStringSettings)
        {
            if (connectionStringSettings == null) throw new ArgumentNullException("connectionStringSettings");
            
            var assembly = typeof(BookMigration).Assembly;
            var migrator = new MigratorClass(connectionStringSettings.ProviderName, connectionStringSettings.ConnectionString, assembly);
            migrator.MigrateToLastVersion();
        }
    }
}
