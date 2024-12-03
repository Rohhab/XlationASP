using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace XlationASP.Migrations
{
    /// <inheritdoc />
    public partial class AddBirthdateToXlator : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "Birthdate",
                table: "Xlators",
                type: "datetime2",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Birthdate",
                table: "Xlators");
        }
    }
}
