using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace XlationASP.Migrations
{
    /// <inheritdoc />
    public partial class PopulateNamesOfMembershipType : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("UPDATE MembershipType SET Name = 'Pay as you go' WHERE Id = 1");
            migrationBuilder.Sql("UPDATE MembershipType SET Name = 'Monthly' WHERE Id = 2");
            migrationBuilder.Sql("UPDATE MembershipType SET Name = 'Quarterly' WHERE Id = 3");
            migrationBuilder.Sql("UPDATE MembershipType SET Name = 'Annual' WHERE Id = 4");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("UPDATE MembershipType SET Name = NULL Where ID IN (1, 2, 3, 4)");
        }
    }
}
