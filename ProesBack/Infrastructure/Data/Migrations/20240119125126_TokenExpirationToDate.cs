using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProesBack.Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class TokenExpirationToDate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                               name: "TokenExpiration",
                                              table: "Login");

            migrationBuilder.AddColumn<DateTime>(
                name: "TokenExpiration",
                table: "Login",
                type: "datetime2",
                nullable: false,
                defaultValue: DateTime.Now.AddMinutes(60)
                );
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                               name: "TokenExpiration",
                                              table: "Login",
                                                             type: "int",
                                                                            nullable: true);

            migrationBuilder.DropColumn(
                               name: "TokenExpiration",
                                              table: "Login");
        }
    }
}
