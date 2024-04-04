using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RentHouse_EXE.Migrations
{
    /// <inheritdoc />
    public partial class v11 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PostRealEstates_PlanPrice_PlanPriceId",
                table: "PostRealEstates");

            migrationBuilder.DropTable(
                name: "PlanPrice");

            migrationBuilder.DropTable(
                name: "PriceDescreases");

            migrationBuilder.DropColumn(
                name: "DateUpPost",
                table: "PostRealEstates");

            migrationBuilder.DropColumn(
                name: "RealEstateCode",
                table: "PostRealEstates");

            migrationBuilder.RenameColumn(
                name: "PlanPriceId",
                table: "PostRealEstates",
                newName: "PriceUnitsId");

            migrationBuilder.RenameColumn(
                name: "Legal",
                table: "PostRealEstates",
                newName: "Ward");

            migrationBuilder.RenameIndex(
                name: "IX_PostRealEstates_PlanPriceId",
                table: "PostRealEstates",
                newName: "IX_PostRealEstates_PriceUnitsId");

            migrationBuilder.AlterColumn<decimal>(
                name: "Area",
                table: "PostRealEstates",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<Guid>(
                name: "Furniture",
                table: "PostRealEstates",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "FurnituresId",
                table: "PostRealEstates",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "PaymentId",
                table: "PostRealEstates",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "PriceUnit",
                table: "PostRealEstates",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<string>(
                name: "Street",
                table: "PostRealEstates",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<decimal>(
                name: "Wallet",
                schema: "dbo",
                table: "Account",
                type: "decimal(18,0)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.CreateTable(
                name: "Furniture",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreateDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateDateTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeleteDateTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Furniture", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Plan",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreateDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateDateTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeleteDateTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Plan", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Price",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreateDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateDateTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeleteDateTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Price", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PriceDay",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Day = table.Column<int>(type: "int", nullable: false),
                    CreateDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateDateTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeleteDateTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PriceDay", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Payment",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CustomerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PostRealEstateId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    StatusId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PlanId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DurationDay = table.Column<int>(type: "int", nullable: false),
                    TotalPrice = table.Column<decimal>(type: "decimal(18,0)", nullable: false),
                    CreateDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateDateTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeleteDateTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Payment", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Payment_Plan_PlanId",
                        column: x => x.PlanId,
                        principalTable: "Plan",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Payment_Statuses_StatusId",
                        column: x => x.StatusId,
                        principalTable: "Statuses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PriceDecreases",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PriceDayId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PercentageDecrease = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CreateDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateDateTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeleteDateTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PriceDecreases", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PriceDecreases_PriceDay_PriceDayId",
                        column: x => x.PriceDayId,
                        principalSchema: "dbo",
                        principalTable: "PriceDay",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PricePlan",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PriceDayId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PlanId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,0)", nullable: false),
                    CreateDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateDateTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeleteDateTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PricePlan", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PricePlan_Plan_PlanId",
                        column: x => x.PlanId,
                        principalTable: "Plan",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PricePlan_PriceDay_PriceDayId",
                        column: x => x.PriceDayId,
                        principalSchema: "dbo",
                        principalTable: "PriceDay",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PostRealEstates_FurnituresId",
                table: "PostRealEstates",
                column: "FurnituresId");

            migrationBuilder.CreateIndex(
                name: "IX_PostRealEstates_PaymentId",
                table: "PostRealEstates",
                column: "PaymentId");

            migrationBuilder.CreateIndex(
                name: "IX_Payment_PlanId",
                table: "Payment",
                column: "PlanId");

            migrationBuilder.CreateIndex(
                name: "IX_Payment_StatusId",
                table: "Payment",
                column: "StatusId");

            migrationBuilder.CreateIndex(
                name: "IX_PriceDecreases_PriceDayId",
                table: "PriceDecreases",
                column: "PriceDayId");

            migrationBuilder.CreateIndex(
                name: "IX_PricePlan_PlanId",
                table: "PricePlan",
                column: "PlanId");

            migrationBuilder.CreateIndex(
                name: "IX_PricePlan_PriceDayId",
                table: "PricePlan",
                column: "PriceDayId");

            migrationBuilder.AddForeignKey(
                name: "FK_PostRealEstates_Furniture_FurnituresId",
                table: "PostRealEstates",
                column: "FurnituresId",
                principalSchema: "dbo",
                principalTable: "Furniture",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PostRealEstates_Payment_PaymentId",
                table: "PostRealEstates",
                column: "PaymentId",
                principalTable: "Payment",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PostRealEstates_Price_PriceUnitsId",
                table: "PostRealEstates",
                column: "PriceUnitsId",
                principalSchema: "dbo",
                principalTable: "Price",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PostRealEstates_Furniture_FurnituresId",
                table: "PostRealEstates");

            migrationBuilder.DropForeignKey(
                name: "FK_PostRealEstates_Payment_PaymentId",
                table: "PostRealEstates");

            migrationBuilder.DropForeignKey(
                name: "FK_PostRealEstates_Price_PriceUnitsId",
                table: "PostRealEstates");

            migrationBuilder.DropTable(
                name: "Furniture",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Payment");

            migrationBuilder.DropTable(
                name: "Price",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "PriceDecreases");

            migrationBuilder.DropTable(
                name: "PricePlan");

            migrationBuilder.DropTable(
                name: "Plan");

            migrationBuilder.DropTable(
                name: "PriceDay",
                schema: "dbo");

            migrationBuilder.DropIndex(
                name: "IX_PostRealEstates_FurnituresId",
                table: "PostRealEstates");

            migrationBuilder.DropIndex(
                name: "IX_PostRealEstates_PaymentId",
                table: "PostRealEstates");

            migrationBuilder.DropColumn(
                name: "Furniture",
                table: "PostRealEstates");

            migrationBuilder.DropColumn(
                name: "FurnituresId",
                table: "PostRealEstates");

            migrationBuilder.DropColumn(
                name: "PaymentId",
                table: "PostRealEstates");

            migrationBuilder.DropColumn(
                name: "PriceUnit",
                table: "PostRealEstates");

            migrationBuilder.DropColumn(
                name: "Street",
                table: "PostRealEstates");

            migrationBuilder.DropColumn(
                name: "Wallet",
                schema: "dbo",
                table: "Account");

            migrationBuilder.RenameColumn(
                name: "Ward",
                table: "PostRealEstates",
                newName: "Legal");

            migrationBuilder.RenameColumn(
                name: "PriceUnitsId",
                table: "PostRealEstates",
                newName: "PlanPriceId");

            migrationBuilder.RenameIndex(
                name: "IX_PostRealEstates_PriceUnitsId",
                table: "PostRealEstates",
                newName: "IX_PostRealEstates_PlanPriceId");

            migrationBuilder.AlterColumn<int>(
                name: "Area",
                table: "PostRealEstates",
                type: "int",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.AddColumn<DateTime>(
                name: "DateUpPost",
                table: "PostRealEstates",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "RealEstateCode",
                table: "PostRealEstates",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "PriceDescreases",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreateDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Day = table.Column<int>(type: "int", nullable: false),
                    DeleteDateTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    PrecentageDescrease = table.Column<decimal>(type: "decimal(18,10)", nullable: false),
                    UpdateDateTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PriceDescreases", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PlanPrice",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PriceDescreaseId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreateDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DeleteDateTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    TagPrice = table.Column<decimal>(type: "decimal(18,0)", nullable: false),
                    TopPrice = table.Column<decimal>(type: "decimal(18,0)", nullable: false),
                    UpPrice = table.Column<decimal>(type: "decimal(18,0)", nullable: false),
                    UpdateDateTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlanPrice", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PlanPrice_PriceDescreases_PriceDescreaseId",
                        column: x => x.PriceDescreaseId,
                        principalTable: "PriceDescreases",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_PlanPrice_PriceDescreaseId",
                table: "PlanPrice",
                column: "PriceDescreaseId");

            migrationBuilder.AddForeignKey(
                name: "FK_PostRealEstates_PlanPrice_PlanPriceId",
                table: "PostRealEstates",
                column: "PlanPriceId",
                principalTable: "PlanPrice",
                principalColumn: "Id");
        }
    }
}
