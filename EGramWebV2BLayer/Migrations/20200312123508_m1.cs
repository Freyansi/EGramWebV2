using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EGramWebV2BLayer.Migrations
{
    public partial class m1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "UserTypeMst",
                columns: table => new
                {
                    UserTypeId = table.Column<short>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    UserTypeName = table.Column<string>(nullable: true),
                    IsActive = table.Column<bool>(nullable: false),
                    CreateDate = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserTypeMst", x => x.UserTypeId);
                });

            migrationBuilder.CreateTable(
                name: "UserMst",
                columns: table => new
                {
                    UserId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    UserName = table.Column<string>(maxLength: 50, nullable: false),
                    UserTypeId = table.Column<short>(nullable: false),
                    Password = table.Column<string>(nullable: false),
                    EmailId = table.Column<string>(maxLength: 70, nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    UpdateDate = table.Column<DateTime>(nullable: true),
                    IsActive = table.Column<bool>(nullable: false),
                    LastPassword = table.Column<string>(nullable: true),
                    LastPassword1 = table.Column<string>(nullable: true),
                    LastPassword2 = table.Column<string>(nullable: true),
                    PasswordAttempt = table.Column<int>(nullable: true),
                    UnlockDate = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserMst", x => x.UserId);
                    table.ForeignKey(
                        name: "FK_UserMst_UserTypeMst_UserTypeId",
                        column: x => x.UserTypeId,
                        principalTable: "UserTypeMst",
                        principalColumn: "UserTypeId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "LoginHistory",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    UserId = table.Column<int>(nullable: false),
                    Status = table.Column<bool>(nullable: false),
                    LoginDate = table.Column<DateTime>(nullable: false),
                    IP = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LoginHistory", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LoginHistory_UserMst_UserId",
                        column: x => x.UserId,
                        principalTable: "UserMst",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_LoginHistory_UserId",
                table: "LoginHistory",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserMst_UserTypeId",
                table: "UserMst",
                column: "UserTypeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LoginHistory");

            migrationBuilder.DropTable(
                name: "UserMst");

            migrationBuilder.DropTable(
                name: "UserTypeMst");
        }
    }
}
