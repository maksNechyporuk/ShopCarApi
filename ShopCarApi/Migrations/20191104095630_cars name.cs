using Microsoft.EntityFrameworkCore.Migrations;

namespace ShopCarApi.Migrations
{
    public partial class carsname : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tblModels_tblMakes_MakeId",
                table: "tblModels");

            migrationBuilder.AlterColumn<int>(
                name: "MakeId",
                table: "tblModels",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddColumn<int>(
                name: "ValueId",
                table: "tblModels",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "tblCars",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_tblModels_ValueId",
                table: "tblModels",
                column: "ValueId");

            migrationBuilder.AddForeignKey(
                name: "FK_tblModels_tblMakes_MakeId",
                table: "tblModels",
                column: "MakeId",
                principalTable: "tblMakes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_tblModels_tblFilterValues_ValueId",
                table: "tblModels",
                column: "ValueId",
                principalTable: "tblFilterValues",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tblModels_tblMakes_MakeId",
                table: "tblModels");

            migrationBuilder.DropForeignKey(
                name: "FK_tblModels_tblFilterValues_ValueId",
                table: "tblModels");

            migrationBuilder.DropIndex(
                name: "IX_tblModels_ValueId",
                table: "tblModels");

            migrationBuilder.DropColumn(
                name: "ValueId",
                table: "tblModels");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "tblCars");

            migrationBuilder.AlterColumn<int>(
                name: "MakeId",
                table: "tblModels",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_tblModels_tblMakes_MakeId",
                table: "tblModels",
                column: "MakeId",
                principalTable: "tblMakes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
