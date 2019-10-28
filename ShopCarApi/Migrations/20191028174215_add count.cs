using Microsoft.EntityFrameworkCore.Migrations;

namespace ShopCarApi.Migrations
{
    public partial class addcount : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "tblClients",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "Count",
                table: "tblCars",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Email",
                table: "tblClients");

            migrationBuilder.DropColumn(
                name: "Count",
                table: "tblCars");
        }
    }
}
