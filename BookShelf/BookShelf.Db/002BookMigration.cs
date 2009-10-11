using Migrator.Framework;
using System.Data;

namespace BookShelf.Db
{
    [Migration(02)]
    public class BookMigration : Migration
    {
        public override void Up()
        {
            Database.AddTable("Book",
                new Column("ISBN", DbType.Int32, ColumnProperty.PrimaryKey),
                new Column("Title", DbType.String, 128, ColumnProperty.NotNull),
                new Column("Description", DbType.String, 2048),
                new Column("AuthorId", DbType.Guid, ColumnProperty.Unsigned | ColumnProperty.NotNull));
            Database.AddForeignKey("FK_Book_ref_Person", "Book", "AuthorId", "Person", "PersonId");
        }

        public override void Down()
        {
            Database.RemoveTable("Book");
        }
    }
}
