using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace XlationASP.Migrations
{
    /// <inheritdoc />
    public partial class PopulateGenres : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("INSERT INTO Genre (Id, Name) VALUES (1, 'Novel')");
            migrationBuilder.Sql("INSERT INTO Genre (Id, Name) VALUES (2, 'History')");
            migrationBuilder.Sql("INSERT INTO Genre (Id, Name) VALUES (3, 'Biography')");
            migrationBuilder.Sql("INSERT INTO Genre (Id, Name) VALUES (4, 'Comedy')");
            migrationBuilder.Sql("INSERT INTO Genre (Id, Name) VALUES (5, 'Fiction')");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE FROM Genre WHERE Id IN (1, 2, 3, 4, 5)");
        }
    }
}
