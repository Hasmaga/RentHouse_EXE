using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RentHouse_EXE.Migrations
{
    /// <inheritdoc />
    public partial class v16 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PostRealEstate_Price_PriceUnitsId",
                schema: "dbo",
                table: "PostRealEstate");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Price",
                schema: "dbo",
                table: "Price");

            migrationBuilder.RenameTable(
                name: "Price",
                schema: "dbo",
                newName: "PriceUnit",
                newSchema: "dbo");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PriceUnit",
                schema: "dbo",
                table: "PriceUnit",
                column: "Id");

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PostRealEstate_PriceUnit_PriceUnitsId",
                schema: "dbo",
                table: "PostRealEstate");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PriceUnit",
                schema: "dbo",
                table: "PriceUnit");

            migrationBuilder.RenameTable(
                name: "PriceUnit",
                schema: "dbo",
                newName: "Price",
                newSchema: "dbo");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Price",
                schema: "dbo",
                table: "Price",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PostRealEstate_Price_PriceUnitsId",
                schema: "dbo",
                table: "PostRealEstate",
                column: "PriceUnitsId",
                principalSchema: "dbo",
                principalTable: "Price",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
