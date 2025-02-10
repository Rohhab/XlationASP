using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace XlationASP.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddMembershipTypeToApplicationUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<byte>(
                name: "MembershipTypeId",
                table: "AspNetUsers",
                type: "tinyint",
                nullable: false,
                defaultValue: (byte)0);

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_MembershipTypeId",
                table: "AspNetUsers",
                column: "MembershipTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_MembershipTypes_MembershipTypeId",
                table: "AspNetUsers",
                column: "MembershipTypeId",
                principalTable: "MembershipTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_MembershipTypes_MembershipTypeId",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_MembershipTypeId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "MembershipTypeId",
                table: "AspNetUsers");
        }
    }
}
