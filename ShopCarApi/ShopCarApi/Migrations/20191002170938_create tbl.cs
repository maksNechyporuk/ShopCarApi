using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ShopCarApi.Migrations
{
    public partial class createtbl : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tblClients",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: false),
                    Image = table.Column<string>(nullable: false),
                    Phone = table.Column<string>(nullable: false),
                    Total_price = table.Column<float>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblClients", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tblColors",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: false),
                    A = table.Column<int>(nullable: false),
                    R = table.Column<int>(nullable: false),
                    G = table.Column<int>(nullable: false),
                    B = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblColors", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tblFuelTypes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Type = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblFuelTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tblMakes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblMakes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tblTypeCars",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblTypeCars", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tblModels",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: false),
                    MakeId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblModels", x => x.Id);
                    table.ForeignKey(
                        name: "FK_tblModels_tblMakes_MakeId",
                        column: x => x.MakeId,
                        principalTable: "tblMakes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tblCars",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Date = table.Column<DateTime>(nullable: false),
                    ColorId = table.Column<int>(nullable: false),
                    ModelId = table.Column<int>(nullable: false),
                    FuelTypeId = table.Column<int>(nullable: false),
                    TypeId = table.Column<int>(nullable: false),
                    Image = table.Column<string>(nullable: true),
                    Price = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblCars", x => x.Id);
                    table.ForeignKey(
                        name: "FK_tblCars_tblColors_ColorId",
                        column: x => x.ColorId,
                        principalTable: "tblColors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tblCars_tblFuelTypes_FuelTypeId",
                        column: x => x.FuelTypeId,
                        principalTable: "tblFuelTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tblCars_tblModels_ModelId",
                        column: x => x.ModelId,
                        principalTable: "tblModels",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tblCars_tblTypeCars_TypeId",
                        column: x => x.TypeId,
                        principalTable: "tblTypeCars",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tblOrders",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Date = table.Column<DateTime>(nullable: false),
                    Price = table.Column<float>(nullable: false),
                    CarId = table.Column<int>(nullable: false),
                    ClientId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblOrders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_tblOrders_tblCars_CarId",
                        column: x => x.CarId,
                        principalTable: "tblCars",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tblOrders_tblClients_ClientId",
                        column: x => x.ClientId,
                        principalTable: "tblClients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tblPurchase",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    OrderId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblPurchase", x => x.Id);
                    table.ForeignKey(
                        name: "FK_tblPurchase_tblOrders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "tblOrders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_tblCars_ColorId",
                table: "tblCars",
                column: "ColorId");

            migrationBuilder.CreateIndex(
                name: "IX_tblCars_FuelTypeId",
                table: "tblCars",
                column: "FuelTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_tblCars_ModelId",
                table: "tblCars",
                column: "ModelId");

            migrationBuilder.CreateIndex(
                name: "IX_tblCars_TypeId",
                table: "tblCars",
                column: "TypeId");

            migrationBuilder.CreateIndex(
                name: "IX_tblModels_MakeId",
                table: "tblModels",
                column: "MakeId");

            migrationBuilder.CreateIndex(
                name: "IX_tblOrders_CarId",
                table: "tblOrders",
                column: "CarId");

            migrationBuilder.CreateIndex(
                name: "IX_tblOrders_ClientId",
                table: "tblOrders",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_tblPurchase_OrderId",
                table: "tblPurchase",
                column: "OrderId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tblPurchase");

            migrationBuilder.DropTable(
                name: "tblOrders");

            migrationBuilder.DropTable(
                name: "tblCars");

            migrationBuilder.DropTable(
                name: "tblClients");

            migrationBuilder.DropTable(
                name: "tblColors");

            migrationBuilder.DropTable(
                name: "tblFuelTypes");

            migrationBuilder.DropTable(
                name: "tblModels");

            migrationBuilder.DropTable(
                name: "tblTypeCars");

            migrationBuilder.DropTable(
                name: "tblMakes");
        }
    }
}
