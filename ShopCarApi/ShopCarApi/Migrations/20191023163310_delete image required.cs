using Microsoft.EntityFrameworkCore.Migrations;

namespace ShopCarApi.Migrations
{
    public partial class deleteimagerequired : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Image",
                table: "tblClients",
                nullable: true,
                oldClrType: typeof(string));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Image",
                table: "tblClients",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);
        }
    }
}
