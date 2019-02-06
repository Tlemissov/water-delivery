using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace WaterDelivery.EntityFrameworkCore.Migrations
{
    public partial class Added_Orders : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    FullName = table.Column<string>(maxLength: 64, nullable: false),
                    Adress = table.Column<string>(maxLength: 128, nullable: false),
                    Phone = table.Column<string>(maxLength: 12, nullable: false),
                    Quantity = table.Column<byte>(nullable: false),
                    Status = table.Column<int>(nullable: false),
                    OrderDate = table.Column<DateTime>(nullable: false),
                    DeliveryDate = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Orders");
        }
    }
}
