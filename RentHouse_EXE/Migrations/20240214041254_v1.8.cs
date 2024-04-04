using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RentHouse_EXE.Migrations
{
    /// <inheritdoc />
    public partial class v18 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PostRealEstate_Payment_PaymentsId",
                schema: "dbo",
                table: "PostRealEstate");

            migrationBuilder.DropTable(
                name: "Payment",
                schema: "dbo");

            migrationBuilder.RenameColumn(
                name: "PaymentsId",
                schema: "dbo",
                table: "PostRealEstate",
                newName: "PlanPriceId");

            migrationBuilder.RenameColumn(
                name: "PaymentId",
                schema: "dbo",
                table: "PostRealEstate",
                newName: "PlanDayId");

            migrationBuilder.RenameIndex(
                name: "IX_PostRealEstate_PaymentsId",
                schema: "dbo",
                table: "PostRealEstate",
                newName: "IX_PostRealEstate_PlanPriceId");

            migrationBuilder.AddColumn<decimal>(
                name: "TotalPrice",
                schema: "dbo",
                table: "PostRealEstate",
                type: "decimal(18,0)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.CreateIndex(
                name: "IX_PostRealEstate_PlanDayId",
                schema: "dbo",
                table: "PostRealEstate",
                column: "PlanDayId");

            migrationBuilder.AddForeignKey(
                name: "FK_PostRealEstate_PlanDay_PlanDayId",
                schema: "dbo",
                table: "PostRealEstate",
                column: "PlanDayId",
                principalSchema: "dbo",
                principalTable: "PlanDay",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PostRealEstate_PlanPrice_PlanPriceId",
                schema: "dbo",
                table: "PostRealEstate",
                column: "PlanPriceId",
                principalSchema: "dbo",
                principalTable: "PlanPrice",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PostRealEstate_PlanDay_PlanDayId",
                schema: "dbo",
                table: "PostRealEstate");

            migrationBuilder.DropForeignKey(
                name: "FK_PostRealEstate_PlanPrice_PlanPriceId",
                schema: "dbo",
                table: "PostRealEstate");

            migrationBuilder.DropIndex(
                name: "IX_PostRealEstate_PlanDayId",
                schema: "dbo",
                table: "PostRealEstate");

            migrationBuilder.DropColumn(
                name: "TotalPrice",
                schema: "dbo",
                table: "PostRealEstate");

            migrationBuilder.RenameColumn(
                name: "PlanPriceId",
                schema: "dbo",
                table: "PostRealEstate",
                newName: "PaymentsId");

            migrationBuilder.RenameColumn(
                name: "PlanDayId",
                schema: "dbo",
                table: "PostRealEstate",
                newName: "PaymentId");

            migrationBuilder.RenameIndex(
                name: "IX_PostRealEstate_PlanPriceId",
                schema: "dbo",
                table: "PostRealEstate",
                newName: "IX_PostRealEstate_PaymentsId");

            migrationBuilder.CreateTable(
                name: "Payment",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PlanPriceId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PriceDecreaseId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    StatusId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreateDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CustomerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DeleteDateTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PostRealEstateId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PriceDescreases = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TotalPrice = table.Column<decimal>(type: "decimal(18,0)", nullable: false),
                    UpdateDateTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Payment", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Payment_PlanPrice_PlanPriceId",
                        column: x => x.PlanPriceId,
                        principalSchema: "dbo",
                        principalTable: "PlanPrice",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Payment_PriceDecreases_PriceDecreaseId",
                        column: x => x.PriceDecreaseId,
                        principalSchema: "dbo",
                        principalTable: "PriceDecreases",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Payment_Status_StatusId",
                        column: x => x.StatusId,
                        principalSchema: "dbo",
                        principalTable: "Status",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Payment_PlanPriceId",
                schema: "dbo",
                table: "Payment",
                column: "PlanPriceId");

            migrationBuilder.CreateIndex(
                name: "IX_Payment_PriceDecreaseId",
                schema: "dbo",
                table: "Payment",
                column: "PriceDecreaseId");

            migrationBuilder.CreateIndex(
                name: "IX_Payment_StatusId",
                schema: "dbo",
                table: "Payment",
                column: "StatusId");

            migrationBuilder.AddForeignKey(
                name: "FK_PostRealEstate_Payment_PaymentsId",
                schema: "dbo",
                table: "PostRealEstate",
                column: "PaymentsId",
                principalSchema: "dbo",
                principalTable: "Payment",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
