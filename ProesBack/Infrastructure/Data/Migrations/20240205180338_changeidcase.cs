using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProesBack.Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class changeidcase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "TeacherID",
                table: "Courses",
                newName: "TeacherId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "TeacherId",
                table: "Courses",
                newName: "TeacherID");
        }
    }
}
