using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SaveSyncNew.Migrations
{
    /// <inheritdoc />
    public partial class _1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Customer",
                columns: table => new
                {
                    CustomerId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LicenseCode = table.Column<string>(type: "nchar(4)", nullable: true),
                    ShopCode = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    ShopName = table.Column<string>(type: "nvarchar(100)", nullable: true),
                    CustomerName = table.Column<string>(type: "nvarchar(200)", nullable: true),
                    Address = table.Column<string>(type: "nvarchar(200)", nullable: true),
                    SubDistrict = table.Column<string>(type: "nvarchar(100)", nullable: true),
                    District = table.Column<string>(type: "nvarchar(100)", nullable: true),
                    Province = table.Column<string>(type: "nvarchar(100)", nullable: true),
                    PostalCode = table.Column<int>(type: "int", nullable: true),
                    Phone = table.Column<string>(type: "nvarchar(10)", nullable: true),
                    RegisterDate = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customer", x => x.CustomerId);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Customer");
        }
    }
}
