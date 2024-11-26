using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace XlationASP.Migrations
{
    /// <inheritdoc />
    public partial class AddIsSubscribedToXlator : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsSubscribedToNewsLetter",
                table: "Xlators",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsSubscribedToNewsLetter",
                table: "Xlators");
        }
    }
}
