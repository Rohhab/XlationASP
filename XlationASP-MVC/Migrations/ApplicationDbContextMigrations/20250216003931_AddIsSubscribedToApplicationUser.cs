using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace XlationASP.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddIsSubscribedToApplicationUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsSubscribedToNewsLetter",
                table: "AspNetUsers",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsSubscribedToNewsLetter",
                table: "AspNetUsers");
        }
    }
}
