using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace XlationASP.Migrations
{
    /// <inheritdoc />
    public partial class XlationAgreementModelAdded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "XlationAgreementId",
                table: "Xlators",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "XlationAgreementId",
                table: "Books",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "XlationAgreement",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DateOfAgreement = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AgreementDuration = table.Column<TimeSpan>(type: "time", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_XlationAgreement", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Xlators_XlationAgreementId",
                table: "Xlators",
                column: "XlationAgreementId");

            migrationBuilder.CreateIndex(
                name: "IX_Books_XlationAgreementId",
                table: "Books",
                column: "XlationAgreementId");

            migrationBuilder.AddForeignKey(
                name: "FK_Books_XlationAgreement_XlationAgreementId",
                table: "Books",
                column: "XlationAgreementId",
                principalTable: "XlationAgreement",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Xlators_XlationAgreement_XlationAgreementId",
                table: "Xlators",
                column: "XlationAgreementId",
                principalTable: "XlationAgreement",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Books_XlationAgreement_XlationAgreementId",
                table: "Books");

            migrationBuilder.DropForeignKey(
                name: "FK_Xlators_XlationAgreement_XlationAgreementId",
                table: "Xlators");

            migrationBuilder.DropTable(
                name: "XlationAgreement");

            migrationBuilder.DropIndex(
                name: "IX_Xlators_XlationAgreementId",
                table: "Xlators");

            migrationBuilder.DropIndex(
                name: "IX_Books_XlationAgreementId",
                table: "Books");

            migrationBuilder.DropColumn(
                name: "XlationAgreementId",
                table: "Xlators");

            migrationBuilder.DropColumn(
                name: "XlationAgreementId",
                table: "Books");
        }
    }
}
