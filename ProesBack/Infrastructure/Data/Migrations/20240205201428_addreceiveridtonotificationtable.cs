using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProesBack.Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class addreceiveridtonotificationtable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<long>(
                name: "SenderId",
                table: "Notifications",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<long>(
                name: "ReceiverId",
                table: "Notifications",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ReceiverId",
                table: "Notifications");

            migrationBuilder.AlterColumn<int>(
                name: "SenderId",
                table: "Notifications",
                type: "int",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint");
        }
    }
}
