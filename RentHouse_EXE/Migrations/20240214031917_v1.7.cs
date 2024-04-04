using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RentHouse_EXE.Migrations
{
    /// <inheritdoc />
    public partial class v17 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PostRealEstate_Furniture_FurnituresId",
                schema: "dbo",
                table: "PostRealEstate");

            migrationBuilder.DropForeignKey(
                name: "FK_PostRealEstate_PriceUnit_PriceUnitsId",
                schema: "dbo",
                table: "PostRealEstate");

            migrationBuilder.DropIndex(
                name: "IX_PostRealEstate_FurnituresId",
                schema: "dbo",
                table: "PostRealEstate");

            migrationBuilder.DropIndex(
                name: "IX_PostRealEstate_PriceUnitsId",
                schema: "dbo",
                table: "PostRealEstate");

            migrationBuilder.DropColumn(
                name: "FurnituresId",
                schema: "dbo",
                table: "PostRealEstate");

            migrationBuilder.DropColumn(
                name: "PriceUnitsId",
                schema: "dbo",
                table: "PostRealEstate");

            migrationBuilder.AlterColumn<TimeOnly>(
                name: "PostTime",
                schema: "dbo",
                table: "PostRealEstate",
                type: "time",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<DateOnly>(
                name: "PostDate",
                schema: "dbo",
                table: "PostRealEstate",
                type: "date",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.CreateIndex(
                name: "IX_PostRealEstate_Furniture",
                schema: "dbo",
                table: "PostRealEstate",
                column: "Furniture");

            migrationBuilder.CreateIndex(
                name: "IX_PostRealEstate_PriceUnit",
                schema: "dbo",
                table: "PostRealEstate",
                column: "PriceUnit");

            migrationBuilder.AddForeignKey(
                name: "FK_PostRealEstate_Furniture_Furniture",
                schema: "dbo",
                table: "PostRealEstate",
                column: "Furniture",
                principalSchema: "dbo",
                principalTable: "Furniture",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PostRealEstate_PriceUnit_PriceUnit",
                schema: "dbo",
                table: "PostRealEstate",
                column: "PriceUnit",
                principalSchema: "dbo",
                principalTable: "PriceUnit",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PostRealEstate_Furniture_Furniture",
                schema: "dbo",
                table: "PostRealEstate");

            migrationBuilder.DropForeignKey(
                name: "FK_PostRealEstate_PriceUnit_PriceUnit",
                schema: "dbo",
                table: "PostRealEstate");

            migrationBuilder.DropIndex(
                name: "IX_PostRealEstate_Furniture",
                schema: "dbo",
                table: "PostRealEstate");

            migrationBuilder.DropIndex(
                name: "IX_PostRealEstate_PriceUnit",
                schema: "dbo",
                table: "PostRealEstate");

            migrationBuilder.AlterColumn<DateTime>(
                name: "PostTime",
                schema: "dbo",
                table: "PostRealEstate",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(TimeOnly),
                oldType: "time");

            migrationBuilder.AlterColumn<DateTime>(
                name: "PostDate",
                schema: "dbo",
                table: "PostRealEstate",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateOnly),
                oldType: "date");

            migrationBuilder.AddColumn<Guid>(
                name: "FurnituresId",
                schema: "dbo",
                table: "PostRealEstate",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "PriceUnitsId",
                schema: "dbo",
                table: "PostRealEstate",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_PostRealEstate_FurnituresId",
                schema: "dbo",
                table: "PostRealEstate",
                column: "FurnituresId");

            migrationBuilder.CreateIndex(
                name: "IX_PostRealEstate_PriceUnitsId",
                schema: "dbo",
                table: "PostRealEstate",
                column: "PriceUnitsId");

            migrationBuilder.AddForeignKey(
                name: "FK_PostRealEstate_Furniture_FurnituresId",
                schema: "dbo",
                table: "PostRealEstate",
                column: "FurnituresId",
                principalSchema: "dbo",
                principalTable: "Furniture",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PostRealEstate_PriceUnit_PriceUnitsId",
                schema: "dbo",
                table: "PostRealEstate",
                column: "PriceUnitsId",
                principalSchema: "dbo",
                principalTable: "PriceUnit",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
