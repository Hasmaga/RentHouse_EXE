using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RentHouse_EXE.Migrations
{
    /// <inheritdoc />
    public partial class v10 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "dbo");

            migrationBuilder.CreateTable(
                name: "administrative_regions",
                schema: "dbo",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    name_en = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    code_name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    code_name_en = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_administrative_regions", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "administrative_units",
                schema: "dbo",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    full_name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    full_name_en = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    short_name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    short_name_en = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    code_name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    code_name_en = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_administrative_units", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "PriceDescreases",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PrecentageDescrease = table.Column<decimal>(type: "decimal(18,10)", nullable: false),
                    Day = table.Column<int>(type: "int", nullable: false),
                    CreateDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateDateTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeleteDateTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PriceDescreases", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RoleName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreateDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateDateTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeleteDateTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Statuses",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    StatusName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreateDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateDateTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeleteDateTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Statuses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TypeRealEstates",
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
                    table.PrimaryKey("PK_TypeRealEstates", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "provinces",
                schema: "dbo",
                columns: table => new
                {
                    code = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    name_en = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    full_name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    full_name_en = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    code_name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    administrative_unit_id = table.Column<int>(type: "int", nullable: true),
                    administrative_region_id = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_provinces", x => x.code);
                    table.ForeignKey(
                        name: "FK_provinces_administrative_regions_administrative_region_id",
                        column: x => x.administrative_region_id,
                        principalSchema: "dbo",
                        principalTable: "administrative_regions",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_provinces_administrative_units_administrative_unit_id",
                        column: x => x.administrative_unit_id,
                        principalSchema: "dbo",
                        principalTable: "administrative_units",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "PlanPrice",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PriceDescreaseId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TopPrice = table.Column<decimal>(type: "decimal(18,0)", nullable: false),
                    UpPrice = table.Column<decimal>(type: "decimal(18,0)", nullable: false),
                    TagPrice = table.Column<decimal>(type: "decimal(18,0)", nullable: false),
                    CreateDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateDateTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeleteDateTime = table.Column<DateTime>(type: "datetime2", nullable: true)
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

            migrationBuilder.CreateTable(
                name: "Account",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PasswordSalt = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StatusId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RoleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreateDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateDateTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeleteDateTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Account", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Account_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Account_Statuses_StatusId",
                        column: x => x.StatusId,
                        principalTable: "Statuses",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "districts",
                schema: "dbo",
                columns: table => new
                {
                    code = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    name_en = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    full_name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    full_name_en = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    code_name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    province_code = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    administrative_unit_id = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_districts", x => x.code);
                    table.ForeignKey(
                        name: "FK_districts_administrative_units_administrative_unit_id",
                        column: x => x.administrative_unit_id,
                        principalSchema: "dbo",
                        principalTable: "administrative_units",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_districts_provinces_province_code",
                        column: x => x.province_code,
                        principalSchema: "dbo",
                        principalTable: "provinces",
                        principalColumn: "code");
                });

            migrationBuilder.CreateTable(
                name: "Messages",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CustomerSendId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CustomerReceiveId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Status = table.Column<bool>(type: "bit", nullable: false),
                    CreateDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateDateTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeleteDateTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Messages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Messages_Account_CustomerReceiveId",
                        column: x => x.CustomerReceiveId,
                        principalSchema: "dbo",
                        principalTable: "Account",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Messages_Account_CustomerSendId",
                        column: x => x.CustomerSendId,
                        principalSchema: "dbo",
                        principalTable: "Account",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "PostRealEstates",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TypeRealEstateId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    District = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PlanPriceId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CustomerPostId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AdminPostId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    StatusId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,0)", nullable: false),
                    TotalRoom = table.Column<int>(type: "int", nullable: false),
                    TotalBathRoom = table.Column<int>(type: "int", nullable: false),
                    TotalBedRoom = table.Column<int>(type: "int", nullable: false),
                    TotalFloor = table.Column<int>(type: "int", nullable: false),
                    Area = table.Column<int>(type: "int", nullable: false),
                    Legal = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RealEstateCode = table.Column<int>(type: "int", nullable: false),
                    DateUpPost = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreateDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateDateTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeleteDateTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PostRealEstates", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PostRealEstates_Account_AdminPostId",
                        column: x => x.AdminPostId,
                        principalSchema: "dbo",
                        principalTable: "Account",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_PostRealEstates_Account_CustomerPostId",
                        column: x => x.CustomerPostId,
                        principalSchema: "dbo",
                        principalTable: "Account",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_PostRealEstates_PlanPrice_PlanPriceId",
                        column: x => x.PlanPriceId,
                        principalTable: "PlanPrice",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_PostRealEstates_Statuses_StatusId",
                        column: x => x.StatusId,
                        principalTable: "Statuses",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_PostRealEstates_TypeRealEstates_TypeRealEstateId",
                        column: x => x.TypeRealEstateId,
                        principalTable: "TypeRealEstates",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "wards",
                schema: "dbo",
                columns: table => new
                {
                    code = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    name_en = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    full_name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    full_name_en = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    code_name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    district_code = table.Column<string>(type: "nvarchar(20)", nullable: true),
                    administrative_unit_id = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_wards", x => x.code);
                    table.ForeignKey(
                        name: "FK_wards_administrative_units_administrative_unit_id",
                        column: x => x.administrative_unit_id,
                        principalSchema: "dbo",
                        principalTable: "administrative_units",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_wards_districts_district_code",
                        column: x => x.district_code,
                        principalSchema: "dbo",
                        principalTable: "districts",
                        principalColumn: "code");
                });

            migrationBuilder.CreateTable(
                name: "CommentRealEstates",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ContentCommon = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RealEstateId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PostRealEstateId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AccountCommentId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AdminCommentId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    StatusId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreateDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateDateTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeleteDateTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CommentRealEstates", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CommentRealEstates_Account_AccountCommentId",
                        column: x => x.AccountCommentId,
                        principalSchema: "dbo",
                        principalTable: "Account",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_CommentRealEstates_Account_AdminCommentId",
                        column: x => x.AdminCommentId,
                        principalSchema: "dbo",
                        principalTable: "Account",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_CommentRealEstates_PostRealEstates_PostRealEstateId",
                        column: x => x.PostRealEstateId,
                        principalTable: "PostRealEstates",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CommentRealEstates_Statuses_StatusId",
                        column: x => x.StatusId,
                        principalTable: "Statuses",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ImageRealEstates",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Image = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    RealEstateId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PostRealEstateId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    StatusId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreateDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateDateTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeleteDateTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ImageRealEstates", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ImageRealEstates_PostRealEstates_PostRealEstateId",
                        column: x => x.PostRealEstateId,
                        principalTable: "PostRealEstates",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ImageRealEstates_Statuses_StatusId",
                        column: x => x.StatusId,
                        principalTable: "Statuses",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ReplyComments",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ReplyCommentContent = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CommentId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AccountReplyCommentId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ParentReplyCommentId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreateDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateDateTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeleteDateTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReplyComments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ReplyComments_Account_AccountReplyCommentId",
                        column: x => x.AccountReplyCommentId,
                        principalSchema: "dbo",
                        principalTable: "Account",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ReplyComments_CommentRealEstates_ParentReplyCommentId",
                        column: x => x.ParentReplyCommentId,
                        principalTable: "CommentRealEstates",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ReplyComments_ReplyComments_ParentReplyCommentId",
                        column: x => x.ParentReplyCommentId,
                        principalTable: "ReplyComments",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "LikeComments",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CommentId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ReplyCommentId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    AccountLikeCommentId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreateDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateDateTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeleteDateTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LikeComments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LikeComments_Account_AccountLikeCommentId",
                        column: x => x.AccountLikeCommentId,
                        principalSchema: "dbo",
                        principalTable: "Account",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_LikeComments_CommentRealEstates_CommentId",
                        column: x => x.CommentId,
                        principalTable: "CommentRealEstates",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_LikeComments_ReplyComments_ReplyCommentId",
                        column: x => x.ReplyCommentId,
                        principalTable: "ReplyComments",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Account_RoleId",
                schema: "dbo",
                table: "Account",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_Account_StatusId",
                schema: "dbo",
                table: "Account",
                column: "StatusId");

            migrationBuilder.CreateIndex(
                name: "IX_CommentRealEstates_AccountCommentId",
                table: "CommentRealEstates",
                column: "AccountCommentId");

            migrationBuilder.CreateIndex(
                name: "IX_CommentRealEstates_AdminCommentId",
                table: "CommentRealEstates",
                column: "AdminCommentId");

            migrationBuilder.CreateIndex(
                name: "IX_CommentRealEstates_PostRealEstateId",
                table: "CommentRealEstates",
                column: "PostRealEstateId");

            migrationBuilder.CreateIndex(
                name: "IX_CommentRealEstates_StatusId",
                table: "CommentRealEstates",
                column: "StatusId");

            migrationBuilder.CreateIndex(
                name: "IX_districts_administrative_unit_id",
                schema: "dbo",
                table: "districts",
                column: "administrative_unit_id");

            migrationBuilder.CreateIndex(
                name: "IX_districts_province_code",
                schema: "dbo",
                table: "districts",
                column: "province_code");

            migrationBuilder.CreateIndex(
                name: "IX_ImageRealEstates_PostRealEstateId",
                table: "ImageRealEstates",
                column: "PostRealEstateId");

            migrationBuilder.CreateIndex(
                name: "IX_ImageRealEstates_StatusId",
                table: "ImageRealEstates",
                column: "StatusId");

            migrationBuilder.CreateIndex(
                name: "IX_LikeComments_AccountLikeCommentId",
                table: "LikeComments",
                column: "AccountLikeCommentId");

            migrationBuilder.CreateIndex(
                name: "IX_LikeComments_CommentId",
                table: "LikeComments",
                column: "CommentId");

            migrationBuilder.CreateIndex(
                name: "IX_LikeComments_ReplyCommentId",
                table: "LikeComments",
                column: "ReplyCommentId");

            migrationBuilder.CreateIndex(
                name: "IX_Messages_CustomerReceiveId",
                table: "Messages",
                column: "CustomerReceiveId");

            migrationBuilder.CreateIndex(
                name: "IX_Messages_CustomerSendId",
                table: "Messages",
                column: "CustomerSendId");

            migrationBuilder.CreateIndex(
                name: "IX_PlanPrice_PriceDescreaseId",
                table: "PlanPrice",
                column: "PriceDescreaseId");

            migrationBuilder.CreateIndex(
                name: "IX_PostRealEstates_AdminPostId",
                table: "PostRealEstates",
                column: "AdminPostId");

            migrationBuilder.CreateIndex(
                name: "IX_PostRealEstates_CustomerPostId",
                table: "PostRealEstates",
                column: "CustomerPostId");

            migrationBuilder.CreateIndex(
                name: "IX_PostRealEstates_PlanPriceId",
                table: "PostRealEstates",
                column: "PlanPriceId");

            migrationBuilder.CreateIndex(
                name: "IX_PostRealEstates_StatusId",
                table: "PostRealEstates",
                column: "StatusId");

            migrationBuilder.CreateIndex(
                name: "IX_PostRealEstates_TypeRealEstateId",
                table: "PostRealEstates",
                column: "TypeRealEstateId");

            migrationBuilder.CreateIndex(
                name: "IX_provinces_administrative_region_id",
                schema: "dbo",
                table: "provinces",
                column: "administrative_region_id");

            migrationBuilder.CreateIndex(
                name: "IX_provinces_administrative_unit_id",
                schema: "dbo",
                table: "provinces",
                column: "administrative_unit_id");

            migrationBuilder.CreateIndex(
                name: "IX_ReplyComments_AccountReplyCommentId",
                table: "ReplyComments",
                column: "AccountReplyCommentId");

            migrationBuilder.CreateIndex(
                name: "IX_ReplyComments_ParentReplyCommentId",
                table: "ReplyComments",
                column: "ParentReplyCommentId");

            migrationBuilder.CreateIndex(
                name: "IX_wards_administrative_unit_id",
                schema: "dbo",
                table: "wards",
                column: "administrative_unit_id");

            migrationBuilder.CreateIndex(
                name: "IX_wards_district_code",
                schema: "dbo",
                table: "wards",
                column: "district_code");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ImageRealEstates");

            migrationBuilder.DropTable(
                name: "LikeComments");

            migrationBuilder.DropTable(
                name: "Messages");

            migrationBuilder.DropTable(
                name: "wards",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "ReplyComments");

            migrationBuilder.DropTable(
                name: "districts",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "CommentRealEstates");

            migrationBuilder.DropTable(
                name: "provinces",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "PostRealEstates");

            migrationBuilder.DropTable(
                name: "administrative_regions",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "administrative_units",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Account",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "PlanPrice");

            migrationBuilder.DropTable(
                name: "TypeRealEstates");

            migrationBuilder.DropTable(
                name: "Roles");

            migrationBuilder.DropTable(
                name: "Statuses");

            migrationBuilder.DropTable(
                name: "PriceDescreases");
        }
    }
}
