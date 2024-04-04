using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RentHouse_EXE.Migrations
{
    /// <inheritdoc />
    public partial class v14 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PlanPrice_PlanDay_PlanDayId",
                schema: "dbo",
                table: "PlanPrice");

            migrationBuilder.DropIndex(
                name: "IX_PlanPrice_PlanDayId",
                schema: "dbo",
                table: "PlanPrice");

            migrationBuilder.DropColumn(
                name: "PlanDayId",
                schema: "dbo",
                table: "PlanPrice");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "PlanDayId",
                schema: "dbo",
                table: "PlanPrice",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_PlanPrice_PlanDayId",
                schema: "dbo",
                table: "PlanPrice",
                column: "PlanDayId");

            migrationBuilder.AddForeignKey(
                name: "FK_PlanPrice_PlanDay_PlanDayId",
                schema: "dbo",
                table: "PlanPrice",
                column: "PlanDayId",
                principalSchema: "dbo",
                principalTable: "PlanDay",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
