using Microsoft.EntityFrameworkCore.Migrations;

namespace DAL.Migrations
{
    public partial class addingdiscattrs : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TotalCash",
                table: "invoices");

            migrationBuilder.AddColumn<double>(
                name: "DistDisc",
                table: "invoices",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "PharmDisc",
                table: "invoices",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "TotalInvoice",
                table: "invoices",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "Value",
                table: "invoices",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "VatValue",
                table: "invoices",
                nullable: false,
                defaultValue: 0.0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DistDisc",
                table: "invoices");

            migrationBuilder.DropColumn(
                name: "PharmDisc",
                table: "invoices");

            migrationBuilder.DropColumn(
                name: "TotalInvoice",
                table: "invoices");

            migrationBuilder.DropColumn(
                name: "Value",
                table: "invoices");

            migrationBuilder.DropColumn(
                name: "VatValue",
                table: "invoices");

            migrationBuilder.AddColumn<double>(
                name: "TotalCash",
                table: "invoices",
                type: "float",
                nullable: false,
                defaultValue: 0.0);
        }
    }
}
