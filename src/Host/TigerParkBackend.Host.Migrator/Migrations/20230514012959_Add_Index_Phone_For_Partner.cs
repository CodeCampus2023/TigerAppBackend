using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TigerParkBackend.Host.Migrator.Migrations
{
    /// <inheritdoc />
    public partial class Add_Index_Phone_For_Partner : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Partner_Phone",
                table: "Partner",
                column: "Phone",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Partner_Phone",
                table: "Partner");
        }
    }
}
