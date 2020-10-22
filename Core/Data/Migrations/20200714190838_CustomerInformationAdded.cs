using Microsoft.EntityFrameworkCore.Migrations;

namespace Core.Migrations
{
    public partial class CustomerInformationAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "BillingAddress",
                table: "Customers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CurrentAddress",
                table: "Customers",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BillingAddress",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "CurrentAddress",
                table: "Customers");
        }
    }
}
