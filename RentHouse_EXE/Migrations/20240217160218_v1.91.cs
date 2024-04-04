using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RentHouse_EXE.Migrations
{
    /// <inheritdoc />
    public partial class v191 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RealEstateId",
                schema: "dbo",
                table: "ImageRealEstate");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "RealEstateId",
                schema: "dbo",
                table: "ImageRealEstate",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));
        }
    }
}
