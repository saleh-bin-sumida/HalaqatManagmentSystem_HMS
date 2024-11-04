using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InstitutionManagmentSystem.Migrations
{
    /// <inheritdoc />
    public partial class oneToOneRealtionShip : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Halaqat_TeacherId",
                table: "Halaqat");

            migrationBuilder.CreateIndex(
                name: "IX_Halaqat_TeacherId",
                table: "Halaqat",
                column: "TeacherId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Halaqat_TeacherId",
                table: "Halaqat");

            migrationBuilder.CreateIndex(
                name: "IX_Halaqat_TeacherId",
                table: "Halaqat",
                column: "TeacherId");
        }
    }
}
