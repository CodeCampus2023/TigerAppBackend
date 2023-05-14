using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TigerParkBackend.Host.Migrator.Migrations
{
    /// <inheritdoc />
    public partial class Add_Order_Id_In_Order : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "OrderCrmId",
                table: "Order",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "OrderCrmId",
                table: "Order");
        }
    }
}
