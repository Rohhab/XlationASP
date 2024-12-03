using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace XlationASP.Migrations
{
    /// <inheritdoc />
    public partial class PopulateBooksData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("INSERT INTO Books (Id, Title, Genre, PublishDate, DateAdded, NoOfPages) VALUES (1, 'Chernobyl', 'Novel', '2018-03-18', '2021-05-24', 423)"); migrationBuilder.Sql("INSERT INTO Books (Id, Title, Genre, PublishDate, DateAdded, NoOfPages) VALUES (2, 'Madame Fourcade''s Secret War', 'Novel', '2018-05-23', '2022-08-14', 365)"); migrationBuilder.Sql("INSERT INTO Books (Id, Title, Genre, PublishDate, DateAdded, NoOfPages) VALUES (3, 'Engineering Justice', 'Academic', '2019-01-20', '2023-02-16', 264)");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE FROM Books WHERE Id IN (1, 2, 3)");
        }
    }
}
