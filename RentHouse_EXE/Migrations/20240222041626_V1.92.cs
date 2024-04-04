using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RentHouse_EXE.Migrations
{
    /// <inheritdoc />
    public partial class V192 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<Guid>(
                name: "CommentId",
                schema: "dbo",
                table: "ReplyComment",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AddColumn<Guid>(
                name: "StatusId",
                schema: "dbo",
                table: "ReplyComment",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_ReplyComment_StatusId",
                schema: "dbo",
                table: "ReplyComment",
                column: "StatusId");

            migrationBuilder.AddForeignKey(
                name: "FK_ReplyComment_Status_StatusId",
                schema: "dbo",
                table: "ReplyComment",
                column: "StatusId",
                principalSchema: "dbo",
                principalTable: "Status",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ReplyComment_Status_StatusId",
                schema: "dbo",
                table: "ReplyComment");

            migrationBuilder.DropIndex(
                name: "IX_ReplyComment_StatusId",
                schema: "dbo",
                table: "ReplyComment");

            migrationBuilder.DropColumn(
                name: "StatusId",
                schema: "dbo",
                table: "ReplyComment");

            migrationBuilder.AlterColumn<Guid>(
                name: "CommentId",
                schema: "dbo",
                table: "ReplyComment",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);
        }
    }
}
