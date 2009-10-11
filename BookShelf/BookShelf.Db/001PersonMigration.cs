using Migrator.Framework;
using System.Data;

namespace BookShelf.Db
{
    [Migration (01)]
    public class PersonMigration : Migration
    {
        public override void Down()
        {
            Database.RemoveTable("Person");
        }

        public override void Up()
        {
            Database.AddTable("Person",
                new Column("PersonId", DbType.Guid, ColumnProperty.PrimaryKey),
                new Column("FirstName", DbType.String, 70, ColumnProperty.NotNull),
                new Column("LastName", DbType.String, 70, ColumnProperty.NotNull)
                );
        }
    }
}
