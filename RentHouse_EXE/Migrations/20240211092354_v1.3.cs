using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RentHouse_EXE.Migrations
{
    /// <inheritdoc />
    public partial class v13 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Account_Roles_RoleId",
                schema: "dbo",
                table: "Account");

            migrationBuilder.DropForeignKey(
                name: "FK_Account_Statuses_StatusId",
                schema: "dbo",
                table: "Account");

            migrationBuilder.DropForeignKey(
                name: "FK_CommentRealEstates_Account_AccountCommentId",
                table: "CommentRealEstates");

            migrationBuilder.DropForeignKey(
                name: "FK_CommentRealEstates_Account_AdminCommentId",
                table: "CommentRealEstates");

            migrationBuilder.DropForeignKey(
                name: "FK_CommentRealEstates_PostRealEstates_PostRealEstateId",
                table: "CommentRealEstates");

            migrationBuilder.DropForeignKey(
                name: "FK_CommentRealEstates_Statuses_StatusId",
                table: "CommentRealEstates");

            migrationBuilder.DropForeignKey(
                name: "FK_ImageRealEstates_PostRealEstates_PostRealEstateId",
                table: "ImageRealEstates");

            migrationBuilder.DropForeignKey(
                name: "FK_ImageRealEstates_Statuses_StatusId",
                table: "ImageRealEstates");

            migrationBuilder.DropForeignKey(
                name: "FK_LikeComments_Account_AccountLikeCommentId",
                table: "LikeComments");

            migrationBuilder.DropForeignKey(
                name: "FK_LikeComments_CommentRealEstates_CommentId",
                table: "LikeComments");

            migrationBuilder.DropForeignKey(
                name: "FK_LikeComments_ReplyComments_ReplyCommentId",
                table: "LikeComments");

            migrationBuilder.DropForeignKey(
                name: "FK_Messages_Account_CustomerReceiveId",
                table: "Messages");

            migrationBuilder.DropForeignKey(
                name: "FK_Messages_Account_CustomerSendId",
                table: "Messages");

            migrationBuilder.DropForeignKey(
                name: "FK_Payment_Plan_PlanId",
                table: "Payment");

            migrationBuilder.DropForeignKey(
                name: "FK_Payment_Statuses_StatusId",
                table: "Payment");

            migrationBuilder.DropForeignKey(
                name: "FK_PostRealEstates_Account_AdminPostId",
                table: "PostRealEstates");

            migrationBuilder.DropForeignKey(
                name: "FK_PostRealEstates_Account_CustomerPostId",
                table: "PostRealEstates");

            migrationBuilder.DropForeignKey(
                name: "FK_PostRealEstates_Furniture_FurnituresId",
                table: "PostRealEstates");

            migrationBuilder.DropForeignKey(
                name: "FK_PostRealEstates_Payment_PaymentId",
                table: "PostRealEstates");

            migrationBuilder.DropForeignKey(
                name: "FK_PostRealEstates_Price_PriceUnitsId",
                table: "PostRealEstates");

            migrationBuilder.DropForeignKey(
                name: "FK_PostRealEstates_Statuses_StatusId",
                table: "PostRealEstates");

            migrationBuilder.DropForeignKey(
                name: "FK_PostRealEstates_TypeRealEstates_TypeRealEstateId",
                table: "PostRealEstates");

            migrationBuilder.DropForeignKey(
                name: "FK_PriceDecreases_PriceDay_PriceDayId",
                table: "PriceDecreases");

            migrationBuilder.DropForeignKey(
                name: "FK_ReplyComments_Account_AccountReplyCommentId",
                table: "ReplyComments");

            migrationBuilder.DropForeignKey(
                name: "FK_ReplyComments_CommentRealEstates_ParentReplyCommentId",
                table: "ReplyComments");

            migrationBuilder.DropForeignKey(
                name: "FK_ReplyComments_ReplyComments_ParentReplyCommentId",
                table: "ReplyComments");

            migrationBuilder.DropTable(
                name: "PricePlan");

            migrationBuilder.DropTable(
                name: "PriceDay",
                schema: "dbo");

            migrationBuilder.DropIndex(
                name: "IX_Payment_PlanId",
                table: "Payment");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TypeRealEstates",
                table: "TypeRealEstates");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Statuses",
                table: "Statuses");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Roles",
                table: "Roles");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ReplyComments",
                table: "ReplyComments");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PostRealEstates",
                table: "PostRealEstates");

            migrationBuilder.DropIndex(
                name: "IX_PostRealEstates_PaymentId",
                table: "PostRealEstates");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Messages",
                table: "Messages");

            migrationBuilder.DropPrimaryKey(
                name: "PK_LikeComments",
                table: "LikeComments");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ImageRealEstates",
                table: "ImageRealEstates");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CommentRealEstates",
                table: "CommentRealEstates");

            migrationBuilder.RenameTable(
                name: "PriceDecreases",
                newName: "PriceDecreases",
                newSchema: "dbo");

            migrationBuilder.RenameTable(
                name: "Plan",
                newName: "Plan",
                newSchema: "dbo");

            migrationBuilder.RenameTable(
                name: "Payment",
                newName: "Payment",
                newSchema: "dbo");

            migrationBuilder.RenameTable(
                name: "TypeRealEstates",
                newName: "TypeRealEstate",
                newSchema: "dbo");

            migrationBuilder.RenameTable(
                name: "Statuses",
                newName: "Status",
                newSchema: "dbo");

            migrationBuilder.RenameTable(
                name: "Roles",
                newName: "Role",
                newSchema: "dbo");

            migrationBuilder.RenameTable(
                name: "ReplyComments",
                newName: "ReplyComment",
                newSchema: "dbo");

            migrationBuilder.RenameTable(
                name: "PostRealEstates",
                newName: "PostRealEstate",
                newSchema: "dbo");

            migrationBuilder.RenameTable(
                name: "Messages",
                newName: "Message",
                newSchema: "dbo");

            migrationBuilder.RenameTable(
                name: "LikeComments",
                newName: "LikeComment",
                newSchema: "dbo");

            migrationBuilder.RenameTable(
                name: "ImageRealEstates",
                newName: "ImageRealEstate",
                newSchema: "dbo");

            migrationBuilder.RenameTable(
                name: "CommentRealEstates",
                newName: "CommentRealEstate",
                newSchema: "dbo");

            migrationBuilder.RenameColumn(
                name: "PriceDayId",
                schema: "dbo",
                table: "PriceDecreases",
                newName: "PlanDayId");

            migrationBuilder.RenameIndex(
                name: "IX_PriceDecreases_PriceDayId",
                schema: "dbo",
                table: "PriceDecreases",
                newName: "IX_PriceDecreases_PlanDayId");

            migrationBuilder.RenameColumn(
                name: "PlanId",
                schema: "dbo",
                table: "Payment",
                newName: "PriceDescreases");

            migrationBuilder.RenameIndex(
                name: "IX_ReplyComments_ParentReplyCommentId",
                schema: "dbo",
                table: "ReplyComment",
                newName: "IX_ReplyComment_ParentReplyCommentId");

            migrationBuilder.RenameIndex(
                name: "IX_ReplyComments_AccountReplyCommentId",
                schema: "dbo",
                table: "ReplyComment",
                newName: "IX_ReplyComment_AccountReplyCommentId");

            migrationBuilder.RenameIndex(
                name: "IX_PostRealEstates_TypeRealEstateId",
                schema: "dbo",
                table: "PostRealEstate",
                newName: "IX_PostRealEstate_TypeRealEstateId");

            migrationBuilder.RenameIndex(
                name: "IX_PostRealEstates_StatusId",
                schema: "dbo",
                table: "PostRealEstate",
                newName: "IX_PostRealEstate_StatusId");

            migrationBuilder.RenameIndex(
                name: "IX_PostRealEstates_PriceUnitsId",
                schema: "dbo",
                table: "PostRealEstate",
                newName: "IX_PostRealEstate_PriceUnitsId");

            migrationBuilder.RenameIndex(
                name: "IX_PostRealEstates_FurnituresId",
                schema: "dbo",
                table: "PostRealEstate",
                newName: "IX_PostRealEstate_FurnituresId");

            migrationBuilder.RenameIndex(
                name: "IX_PostRealEstates_CustomerPostId",
                schema: "dbo",
                table: "PostRealEstate",
                newName: "IX_PostRealEstate_CustomerPostId");

            migrationBuilder.RenameIndex(
                name: "IX_PostRealEstates_AdminPostId",
                schema: "dbo",
                table: "PostRealEstate",
                newName: "IX_PostRealEstate_AdminPostId");

            migrationBuilder.RenameIndex(
                name: "IX_Messages_CustomerSendId",
                schema: "dbo",
                table: "Message",
                newName: "IX_Message_CustomerSendId");

            migrationBuilder.RenameIndex(
                name: "IX_Messages_CustomerReceiveId",
                schema: "dbo",
                table: "Message",
                newName: "IX_Message_CustomerReceiveId");

            migrationBuilder.RenameIndex(
                name: "IX_LikeComments_ReplyCommentId",
                schema: "dbo",
                table: "LikeComment",
                newName: "IX_LikeComment_ReplyCommentId");

            migrationBuilder.RenameIndex(
                name: "IX_LikeComments_CommentId",
                schema: "dbo",
                table: "LikeComment",
                newName: "IX_LikeComment_CommentId");

            migrationBuilder.RenameIndex(
                name: "IX_LikeComments_AccountLikeCommentId",
                schema: "dbo",
                table: "LikeComment",
                newName: "IX_LikeComment_AccountLikeCommentId");

            migrationBuilder.RenameIndex(
                name: "IX_ImageRealEstates_StatusId",
                schema: "dbo",
                table: "ImageRealEstate",
                newName: "IX_ImageRealEstate_StatusId");

            migrationBuilder.RenameIndex(
                name: "IX_ImageRealEstates_PostRealEstateId",
                schema: "dbo",
                table: "ImageRealEstate",
                newName: "IX_ImageRealEstate_PostRealEstateId");

            migrationBuilder.RenameIndex(
                name: "IX_CommentRealEstates_StatusId",
                schema: "dbo",
                table: "CommentRealEstate",
                newName: "IX_CommentRealEstate_StatusId");

            migrationBuilder.RenameIndex(
                name: "IX_CommentRealEstates_PostRealEstateId",
                schema: "dbo",
                table: "CommentRealEstate",
                newName: "IX_CommentRealEstate_PostRealEstateId");

            migrationBuilder.RenameIndex(
                name: "IX_CommentRealEstates_AdminCommentId",
                schema: "dbo",
                table: "CommentRealEstate",
                newName: "IX_CommentRealEstate_AdminCommentId");

            migrationBuilder.RenameIndex(
                name: "IX_CommentRealEstates_AccountCommentId",
                schema: "dbo",
                table: "CommentRealEstate",
                newName: "IX_CommentRealEstate_AccountCommentId");

            migrationBuilder.AddColumn<Guid>(
                name: "PlanPriceId",
                schema: "dbo",
                table: "Payment",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "PriceDecreaseId",
                schema: "dbo",
                table: "Payment",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "PaymentsId",
                schema: "dbo",
                table: "PostRealEstate",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddPrimaryKey(
                name: "PK_TypeRealEstate",
                schema: "dbo",
                table: "TypeRealEstate",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Status",
                schema: "dbo",
                table: "Status",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Role",
                schema: "dbo",
                table: "Role",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ReplyComment",
                schema: "dbo",
                table: "ReplyComment",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PostRealEstate",
                schema: "dbo",
                table: "PostRealEstate",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Message",
                schema: "dbo",
                table: "Message",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_LikeComment",
                schema: "dbo",
                table: "LikeComment",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ImageRealEstate",
                schema: "dbo",
                table: "ImageRealEstate",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CommentRealEstate",
                schema: "dbo",
                table: "CommentRealEstate",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "PlanDay",
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
                    table.PrimaryKey("PK_PlanDay", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PlanPrice",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PlanDayId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PlanId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,0)", nullable: false),
                    CreateDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateDateTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeleteDateTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlanPrice", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PlanPrice_PlanDay_PlanDayId",
                        column: x => x.PlanDayId,
                        principalSchema: "dbo",
                        principalTable: "PlanDay",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PlanPrice_Plan_PlanId",
                        column: x => x.PlanId,
                        principalSchema: "dbo",
                        principalTable: "Plan",
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
                name: "IX_PostRealEstate_PaymentsId",
                schema: "dbo",
                table: "PostRealEstate",
                column: "PaymentsId");

            migrationBuilder.CreateIndex(
                name: "IX_PlanPrice_PlanDayId",
                schema: "dbo",
                table: "PlanPrice",
                column: "PlanDayId");

            migrationBuilder.CreateIndex(
                name: "IX_PlanPrice_PlanId",
                schema: "dbo",
                table: "PlanPrice",
                column: "PlanId");

            migrationBuilder.AddForeignKey(
                name: "FK_Account_Role_RoleId",
                schema: "dbo",
                table: "Account",
                column: "RoleId",
                principalSchema: "dbo",
                principalTable: "Role",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Account_Status_StatusId",
                schema: "dbo",
                table: "Account",
                column: "StatusId",
                principalSchema: "dbo",
                principalTable: "Status",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CommentRealEstate_Account_AccountCommentId",
                schema: "dbo",
                table: "CommentRealEstate",
                column: "AccountCommentId",
                principalSchema: "dbo",
                principalTable: "Account",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CommentRealEstate_Account_AdminCommentId",
                schema: "dbo",
                table: "CommentRealEstate",
                column: "AdminCommentId",
                principalSchema: "dbo",
                principalTable: "Account",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CommentRealEstate_PostRealEstate_PostRealEstateId",
                schema: "dbo",
                table: "CommentRealEstate",
                column: "PostRealEstateId",
                principalSchema: "dbo",
                principalTable: "PostRealEstate",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CommentRealEstate_Status_StatusId",
                schema: "dbo",
                table: "CommentRealEstate",
                column: "StatusId",
                principalSchema: "dbo",
                principalTable: "Status",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ImageRealEstate_PostRealEstate_PostRealEstateId",
                schema: "dbo",
                table: "ImageRealEstate",
                column: "PostRealEstateId",
                principalSchema: "dbo",
                principalTable: "PostRealEstate",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ImageRealEstate_Status_StatusId",
                schema: "dbo",
                table: "ImageRealEstate",
                column: "StatusId",
                principalSchema: "dbo",
                principalTable: "Status",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_LikeComment_Account_AccountLikeCommentId",
                schema: "dbo",
                table: "LikeComment",
                column: "AccountLikeCommentId",
                principalSchema: "dbo",
                principalTable: "Account",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_LikeComment_CommentRealEstate_CommentId",
                schema: "dbo",
                table: "LikeComment",
                column: "CommentId",
                principalSchema: "dbo",
                principalTable: "CommentRealEstate",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_LikeComment_ReplyComment_ReplyCommentId",
                schema: "dbo",
                table: "LikeComment",
                column: "ReplyCommentId",
                principalSchema: "dbo",
                principalTable: "ReplyComment",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Message_Account_CustomerReceiveId",
                schema: "dbo",
                table: "Message",
                column: "CustomerReceiveId",
                principalSchema: "dbo",
                principalTable: "Account",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Message_Account_CustomerSendId",
                schema: "dbo",
                table: "Message",
                column: "CustomerSendId",
                principalSchema: "dbo",
                principalTable: "Account",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Payment_PlanPrice_PlanPriceId",
                schema: "dbo",
                table: "Payment",
                column: "PlanPriceId",
                principalSchema: "dbo",
                principalTable: "PlanPrice",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Payment_PriceDecreases_PriceDecreaseId",
                schema: "dbo",
                table: "Payment",
                column: "PriceDecreaseId",
                principalSchema: "dbo",
                principalTable: "PriceDecreases",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Payment_Status_StatusId",
                schema: "dbo",
                table: "Payment",
                column: "StatusId",
                principalSchema: "dbo",
                principalTable: "Status",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PostRealEstate_Account_AdminPostId",
                schema: "dbo",
                table: "PostRealEstate",
                column: "AdminPostId",
                principalSchema: "dbo",
                principalTable: "Account",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PostRealEstate_Account_CustomerPostId",
                schema: "dbo",
                table: "PostRealEstate",
                column: "CustomerPostId",
                principalSchema: "dbo",
                principalTable: "Account",
                principalColumn: "Id");

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
                name: "FK_PostRealEstate_Payment_PaymentsId",
                schema: "dbo",
                table: "PostRealEstate",
                column: "PaymentsId",
                principalSchema: "dbo",
                principalTable: "Payment",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PostRealEstate_Price_PriceUnitsId",
                schema: "dbo",
                table: "PostRealEstate",
                column: "PriceUnitsId",
                principalSchema: "dbo",
                principalTable: "Price",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PostRealEstate_Status_StatusId",
                schema: "dbo",
                table: "PostRealEstate",
                column: "StatusId",
                principalSchema: "dbo",
                principalTable: "Status",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PostRealEstate_TypeRealEstate_TypeRealEstateId",
                schema: "dbo",
                table: "PostRealEstate",
                column: "TypeRealEstateId",
                principalSchema: "dbo",
                principalTable: "TypeRealEstate",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PriceDecreases_PlanDay_PlanDayId",
                schema: "dbo",
                table: "PriceDecreases",
                column: "PlanDayId",
                principalSchema: "dbo",
                principalTable: "PlanDay",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ReplyComment_Account_AccountReplyCommentId",
                schema: "dbo",
                table: "ReplyComment",
                column: "AccountReplyCommentId",
                principalSchema: "dbo",
                principalTable: "Account",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ReplyComment_CommentRealEstate_ParentReplyCommentId",
                schema: "dbo",
                table: "ReplyComment",
                column: "ParentReplyCommentId",
                principalSchema: "dbo",
                principalTable: "CommentRealEstate",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ReplyComment_ReplyComment_ParentReplyCommentId",
                schema: "dbo",
                table: "ReplyComment",
                column: "ParentReplyCommentId",
                principalSchema: "dbo",
                principalTable: "ReplyComment",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Account_Role_RoleId",
                schema: "dbo",
                table: "Account");

            migrationBuilder.DropForeignKey(
                name: "FK_Account_Status_StatusId",
                schema: "dbo",
                table: "Account");

            migrationBuilder.DropForeignKey(
                name: "FK_CommentRealEstate_Account_AccountCommentId",
                schema: "dbo",
                table: "CommentRealEstate");

            migrationBuilder.DropForeignKey(
                name: "FK_CommentRealEstate_Account_AdminCommentId",
                schema: "dbo",
                table: "CommentRealEstate");

            migrationBuilder.DropForeignKey(
                name: "FK_CommentRealEstate_PostRealEstate_PostRealEstateId",
                schema: "dbo",
                table: "CommentRealEstate");

            migrationBuilder.DropForeignKey(
                name: "FK_CommentRealEstate_Status_StatusId",
                schema: "dbo",
                table: "CommentRealEstate");

            migrationBuilder.DropForeignKey(
                name: "FK_ImageRealEstate_PostRealEstate_PostRealEstateId",
                schema: "dbo",
                table: "ImageRealEstate");

            migrationBuilder.DropForeignKey(
                name: "FK_ImageRealEstate_Status_StatusId",
                schema: "dbo",
                table: "ImageRealEstate");

            migrationBuilder.DropForeignKey(
                name: "FK_LikeComment_Account_AccountLikeCommentId",
                schema: "dbo",
                table: "LikeComment");

            migrationBuilder.DropForeignKey(
                name: "FK_LikeComment_CommentRealEstate_CommentId",
                schema: "dbo",
                table: "LikeComment");

            migrationBuilder.DropForeignKey(
                name: "FK_LikeComment_ReplyComment_ReplyCommentId",
                schema: "dbo",
                table: "LikeComment");

            migrationBuilder.DropForeignKey(
                name: "FK_Message_Account_CustomerReceiveId",
                schema: "dbo",
                table: "Message");

            migrationBuilder.DropForeignKey(
                name: "FK_Message_Account_CustomerSendId",
                schema: "dbo",
                table: "Message");

            migrationBuilder.DropForeignKey(
                name: "FK_Payment_PlanPrice_PlanPriceId",
                schema: "dbo",
                table: "Payment");

            migrationBuilder.DropForeignKey(
                name: "FK_Payment_PriceDecreases_PriceDecreaseId",
                schema: "dbo",
                table: "Payment");

            migrationBuilder.DropForeignKey(
                name: "FK_Payment_Status_StatusId",
                schema: "dbo",
                table: "Payment");

            migrationBuilder.DropForeignKey(
                name: "FK_PostRealEstate_Account_AdminPostId",
                schema: "dbo",
                table: "PostRealEstate");

            migrationBuilder.DropForeignKey(
                name: "FK_PostRealEstate_Account_CustomerPostId",
                schema: "dbo",
                table: "PostRealEstate");

            migrationBuilder.DropForeignKey(
                name: "FK_PostRealEstate_Furniture_FurnituresId",
                schema: "dbo",
                table: "PostRealEstate");

            migrationBuilder.DropForeignKey(
                name: "FK_PostRealEstate_Payment_PaymentsId",
                schema: "dbo",
                table: "PostRealEstate");

            migrationBuilder.DropForeignKey(
                name: "FK_PostRealEstate_Price_PriceUnitsId",
                schema: "dbo",
                table: "PostRealEstate");

            migrationBuilder.DropForeignKey(
                name: "FK_PostRealEstate_Status_StatusId",
                schema: "dbo",
                table: "PostRealEstate");

            migrationBuilder.DropForeignKey(
                name: "FK_PostRealEstate_TypeRealEstate_TypeRealEstateId",
                schema: "dbo",
                table: "PostRealEstate");

            migrationBuilder.DropForeignKey(
                name: "FK_PriceDecreases_PlanDay_PlanDayId",
                schema: "dbo",
                table: "PriceDecreases");

            migrationBuilder.DropForeignKey(
                name: "FK_ReplyComment_Account_AccountReplyCommentId",
                schema: "dbo",
                table: "ReplyComment");

            migrationBuilder.DropForeignKey(
                name: "FK_ReplyComment_CommentRealEstate_ParentReplyCommentId",
                schema: "dbo",
                table: "ReplyComment");

            migrationBuilder.DropForeignKey(
                name: "FK_ReplyComment_ReplyComment_ParentReplyCommentId",
                schema: "dbo",
                table: "ReplyComment");

            migrationBuilder.DropTable(
                name: "PlanPrice",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "PlanDay",
                schema: "dbo");

            migrationBuilder.DropIndex(
                name: "IX_Payment_PlanPriceId",
                schema: "dbo",
                table: "Payment");

            migrationBuilder.DropIndex(
                name: "IX_Payment_PriceDecreaseId",
                schema: "dbo",
                table: "Payment");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TypeRealEstate",
                schema: "dbo",
                table: "TypeRealEstate");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Status",
                schema: "dbo",
                table: "Status");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Role",
                schema: "dbo",
                table: "Role");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ReplyComment",
                schema: "dbo",
                table: "ReplyComment");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PostRealEstate",
                schema: "dbo",
                table: "PostRealEstate");

            migrationBuilder.DropIndex(
                name: "IX_PostRealEstate_PaymentsId",
                schema: "dbo",
                table: "PostRealEstate");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Message",
                schema: "dbo",
                table: "Message");

            migrationBuilder.DropPrimaryKey(
                name: "PK_LikeComment",
                schema: "dbo",
                table: "LikeComment");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ImageRealEstate",
                schema: "dbo",
                table: "ImageRealEstate");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CommentRealEstate",
                schema: "dbo",
                table: "CommentRealEstate");

            migrationBuilder.DropColumn(
                name: "PlanPriceId",
                schema: "dbo",
                table: "Payment");

            migrationBuilder.DropColumn(
                name: "PriceDecreaseId",
                schema: "dbo",
                table: "Payment");

            migrationBuilder.DropColumn(
                name: "PaymentsId",
                schema: "dbo",
                table: "PostRealEstate");

            migrationBuilder.RenameTable(
                name: "PriceDecreases",
                schema: "dbo",
                newName: "PriceDecreases");

            migrationBuilder.RenameTable(
                name: "Plan",
                schema: "dbo",
                newName: "Plan");

            migrationBuilder.RenameTable(
                name: "Payment",
                schema: "dbo",
                newName: "Payment");

            migrationBuilder.RenameTable(
                name: "TypeRealEstate",
                schema: "dbo",
                newName: "TypeRealEstates");

            migrationBuilder.RenameTable(
                name: "Status",
                schema: "dbo",
                newName: "Statuses");

            migrationBuilder.RenameTable(
                name: "Role",
                schema: "dbo",
                newName: "Roles");

            migrationBuilder.RenameTable(
                name: "ReplyComment",
                schema: "dbo",
                newName: "ReplyComments");

            migrationBuilder.RenameTable(
                name: "PostRealEstate",
                schema: "dbo",
                newName: "PostRealEstates");

            migrationBuilder.RenameTable(
                name: "Message",
                schema: "dbo",
                newName: "Messages");

            migrationBuilder.RenameTable(
                name: "LikeComment",
                schema: "dbo",
                newName: "LikeComments");

            migrationBuilder.RenameTable(
                name: "ImageRealEstate",
                schema: "dbo",
                newName: "ImageRealEstates");

            migrationBuilder.RenameTable(
                name: "CommentRealEstate",
                schema: "dbo",
                newName: "CommentRealEstates");

            migrationBuilder.RenameColumn(
                name: "PlanDayId",
                table: "PriceDecreases",
                newName: "PriceDayId");

            migrationBuilder.RenameIndex(
                name: "IX_PriceDecreases_PlanDayId",
                table: "PriceDecreases",
                newName: "IX_PriceDecreases_PriceDayId");

            migrationBuilder.RenameColumn(
                name: "PriceDescreases",
                table: "Payment",
                newName: "PlanId");

            migrationBuilder.RenameIndex(
                name: "IX_ReplyComment_ParentReplyCommentId",
                table: "ReplyComments",
                newName: "IX_ReplyComments_ParentReplyCommentId");

            migrationBuilder.RenameIndex(
                name: "IX_ReplyComment_AccountReplyCommentId",
                table: "ReplyComments",
                newName: "IX_ReplyComments_AccountReplyCommentId");

            migrationBuilder.RenameIndex(
                name: "IX_PostRealEstate_TypeRealEstateId",
                table: "PostRealEstates",
                newName: "IX_PostRealEstates_TypeRealEstateId");

            migrationBuilder.RenameIndex(
                name: "IX_PostRealEstate_StatusId",
                table: "PostRealEstates",
                newName: "IX_PostRealEstates_StatusId");

            migrationBuilder.RenameIndex(
                name: "IX_PostRealEstate_PriceUnitsId",
                table: "PostRealEstates",
                newName: "IX_PostRealEstates_PriceUnitsId");

            migrationBuilder.RenameIndex(
                name: "IX_PostRealEstate_FurnituresId",
                table: "PostRealEstates",
                newName: "IX_PostRealEstates_FurnituresId");

            migrationBuilder.RenameIndex(
                name: "IX_PostRealEstate_CustomerPostId",
                table: "PostRealEstates",
                newName: "IX_PostRealEstates_CustomerPostId");

            migrationBuilder.RenameIndex(
                name: "IX_PostRealEstate_AdminPostId",
                table: "PostRealEstates",
                newName: "IX_PostRealEstates_AdminPostId");

            migrationBuilder.RenameIndex(
                name: "IX_Message_CustomerSendId",
                table: "Messages",
                newName: "IX_Messages_CustomerSendId");

            migrationBuilder.RenameIndex(
                name: "IX_Message_CustomerReceiveId",
                table: "Messages",
                newName: "IX_Messages_CustomerReceiveId");

            migrationBuilder.RenameIndex(
                name: "IX_LikeComment_ReplyCommentId",
                table: "LikeComments",
                newName: "IX_LikeComments_ReplyCommentId");

            migrationBuilder.RenameIndex(
                name: "IX_LikeComment_CommentId",
                table: "LikeComments",
                newName: "IX_LikeComments_CommentId");

            migrationBuilder.RenameIndex(
                name: "IX_LikeComment_AccountLikeCommentId",
                table: "LikeComments",
                newName: "IX_LikeComments_AccountLikeCommentId");

            migrationBuilder.RenameIndex(
                name: "IX_ImageRealEstate_StatusId",
                table: "ImageRealEstates",
                newName: "IX_ImageRealEstates_StatusId");

            migrationBuilder.RenameIndex(
                name: "IX_ImageRealEstate_PostRealEstateId",
                table: "ImageRealEstates",
                newName: "IX_ImageRealEstates_PostRealEstateId");

            migrationBuilder.RenameIndex(
                name: "IX_CommentRealEstate_StatusId",
                table: "CommentRealEstates",
                newName: "IX_CommentRealEstates_StatusId");

            migrationBuilder.RenameIndex(
                name: "IX_CommentRealEstate_PostRealEstateId",
                table: "CommentRealEstates",
                newName: "IX_CommentRealEstates_PostRealEstateId");

            migrationBuilder.RenameIndex(
                name: "IX_CommentRealEstate_AdminCommentId",
                table: "CommentRealEstates",
                newName: "IX_CommentRealEstates_AdminCommentId");

            migrationBuilder.RenameIndex(
                name: "IX_CommentRealEstate_AccountCommentId",
                table: "CommentRealEstates",
                newName: "IX_CommentRealEstates_AccountCommentId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TypeRealEstates",
                table: "TypeRealEstates",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Statuses",
                table: "Statuses",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Roles",
                table: "Roles",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ReplyComments",
                table: "ReplyComments",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PostRealEstates",
                table: "PostRealEstates",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Messages",
                table: "Messages",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_LikeComments",
                table: "LikeComments",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ImageRealEstates",
                table: "ImageRealEstates",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CommentRealEstates",
                table: "CommentRealEstates",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "PriceDay",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreateDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Day = table.Column<int>(type: "int", nullable: false),
                    DeleteDateTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdateDateTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PriceDay", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PricePlan",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PlanId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PriceDayId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreateDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DeleteDateTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Price = table.Column<decimal>(type: "decimal(18,0)", nullable: false),
                    UpdateDateTime = table.Column<DateTime>(type: "datetime2", nullable: true)
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
                name: "IX_Payment_PlanId",
                table: "Payment",
                column: "PlanId");

            migrationBuilder.CreateIndex(
                name: "IX_PostRealEstates_PaymentId",
                table: "PostRealEstates",
                column: "PaymentId");

            migrationBuilder.CreateIndex(
                name: "IX_PricePlan_PlanId",
                table: "PricePlan",
                column: "PlanId");

            migrationBuilder.CreateIndex(
                name: "IX_PricePlan_PriceDayId",
                table: "PricePlan",
                column: "PriceDayId");

            migrationBuilder.AddForeignKey(
                name: "FK_Account_Roles_RoleId",
                schema: "dbo",
                table: "Account",
                column: "RoleId",
                principalTable: "Roles",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Account_Statuses_StatusId",
                schema: "dbo",
                table: "Account",
                column: "StatusId",
                principalTable: "Statuses",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CommentRealEstates_Account_AccountCommentId",
                table: "CommentRealEstates",
                column: "AccountCommentId",
                principalSchema: "dbo",
                principalTable: "Account",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CommentRealEstates_Account_AdminCommentId",
                table: "CommentRealEstates",
                column: "AdminCommentId",
                principalSchema: "dbo",
                principalTable: "Account",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CommentRealEstates_PostRealEstates_PostRealEstateId",
                table: "CommentRealEstates",
                column: "PostRealEstateId",
                principalTable: "PostRealEstates",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CommentRealEstates_Statuses_StatusId",
                table: "CommentRealEstates",
                column: "StatusId",
                principalTable: "Statuses",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ImageRealEstates_PostRealEstates_PostRealEstateId",
                table: "ImageRealEstates",
                column: "PostRealEstateId",
                principalTable: "PostRealEstates",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ImageRealEstates_Statuses_StatusId",
                table: "ImageRealEstates",
                column: "StatusId",
                principalTable: "Statuses",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_LikeComments_Account_AccountLikeCommentId",
                table: "LikeComments",
                column: "AccountLikeCommentId",
                principalSchema: "dbo",
                principalTable: "Account",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_LikeComments_CommentRealEstates_CommentId",
                table: "LikeComments",
                column: "CommentId",
                principalTable: "CommentRealEstates",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_LikeComments_ReplyComments_ReplyCommentId",
                table: "LikeComments",
                column: "ReplyCommentId",
                principalTable: "ReplyComments",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Messages_Account_CustomerReceiveId",
                table: "Messages",
                column: "CustomerReceiveId",
                principalSchema: "dbo",
                principalTable: "Account",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Messages_Account_CustomerSendId",
                table: "Messages",
                column: "CustomerSendId",
                principalSchema: "dbo",
                principalTable: "Account",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Payment_Plan_PlanId",
                table: "Payment",
                column: "PlanId",
                principalTable: "Plan",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Payment_Statuses_StatusId",
                table: "Payment",
                column: "StatusId",
                principalTable: "Statuses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PostRealEstates_Account_AdminPostId",
                table: "PostRealEstates",
                column: "AdminPostId",
                principalSchema: "dbo",
                principalTable: "Account",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PostRealEstates_Account_CustomerPostId",
                table: "PostRealEstates",
                column: "CustomerPostId",
                principalSchema: "dbo",
                principalTable: "Account",
                principalColumn: "Id");

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

            migrationBuilder.AddForeignKey(
                name: "FK_PostRealEstates_Statuses_StatusId",
                table: "PostRealEstates",
                column: "StatusId",
                principalTable: "Statuses",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PostRealEstates_TypeRealEstates_TypeRealEstateId",
                table: "PostRealEstates",
                column: "TypeRealEstateId",
                principalTable: "TypeRealEstates",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PriceDecreases_PriceDay_PriceDayId",
                table: "PriceDecreases",
                column: "PriceDayId",
                principalSchema: "dbo",
                principalTable: "PriceDay",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ReplyComments_Account_AccountReplyCommentId",
                table: "ReplyComments",
                column: "AccountReplyCommentId",
                principalSchema: "dbo",
                principalTable: "Account",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ReplyComments_CommentRealEstates_ParentReplyCommentId",
                table: "ReplyComments",
                column: "ParentReplyCommentId",
                principalTable: "CommentRealEstates",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ReplyComments_ReplyComments_ParentReplyCommentId",
                table: "ReplyComments",
                column: "ParentReplyCommentId",
                principalTable: "ReplyComments",
                principalColumn: "Id");
        }
    }
}
