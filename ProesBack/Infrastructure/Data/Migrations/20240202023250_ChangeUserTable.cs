using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProesBack.Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class ChangeUserTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "loginId",
                table: "User",
                newName: "LoginId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "LoginId",
                table: "User",
                newName: "loginId");
        }
    }
}
