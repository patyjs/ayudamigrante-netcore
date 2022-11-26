using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Database.Migrations
{
    public partial class first : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Post",
                columns: table => new
                {
                    IDPost = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    IDAccount = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    DateTimeUTC = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    Body = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Post", x => x.IDPost);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Session",
                columns: table => new
                {
                    IDSession = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    IDAccount = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    SessionToken = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    LastLogin = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Session", x => x.IDSession);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "UserRol",
                columns: table => new
                {
                    IDUserRol = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    UserLevel = table.Column<int>(type: "int", nullable: false),
                    UserRolName = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    UserRolPermisions = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserRol", x => x.IDUserRol);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Account",
                columns: table => new
                {
                    IDAccount = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Email = table.Column<string>(type: "varchar(150)", maxLength: 150, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    PasswordHash = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    IDUserRol = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    IsVerified = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    RequirePasswordReset = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Account", x => x.IDAccount);
                    table.ForeignKey(
                        name: "FK_Account_UserRol_IDUserRol",
                        column: x => x.IDUserRol,
                        principalTable: "UserRol",
                        principalColumn: "IDUserRol",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "AccountPost",
                columns: table => new
                {
                    LikedPostsIDPost = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    LikesIDAccount = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AccountPost", x => new { x.LikedPostsIDPost, x.LikesIDAccount });
                    table.ForeignKey(
                        name: "FK_AccountPost_Account_LikesIDAccount",
                        column: x => x.LikesIDAccount,
                        principalTable: "Account",
                        principalColumn: "IDAccount",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AccountPost_Post_LikedPostsIDPost",
                        column: x => x.LikedPostsIDPost,
                        principalTable: "Post",
                        principalColumn: "IDPost",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Comment",
                columns: table => new
                {
                    IDComment = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    IDAccount = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    IDPost = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    DateTimeUTC = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    Content = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comment", x => x.IDComment);
                    table.ForeignKey(
                        name: "FK_Comment_Account_IDAccount",
                        column: x => x.IDAccount,
                        principalTable: "Account",
                        principalColumn: "IDAccount",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Comment_Post_IDPost",
                        column: x => x.IDPost,
                        principalTable: "Post",
                        principalColumn: "IDPost",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Profile",
                columns: table => new
                {
                    IDProfile = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    IDAccount = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Name = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    LastName = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Gender = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AboutMe = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    OriginCity = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    BirthDay = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Profile", x => x.IDProfile);
                    table.ForeignKey(
                        name: "FK_Profile_Account_IDAccount",
                        column: x => x.IDAccount,
                        principalTable: "Account",
                        principalColumn: "IDAccount",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.InsertData(
                table: "UserRol",
                columns: new[] { "IDUserRol", "UserLevel", "UserRolName", "UserRolPermisions" },
                values: new object[] { "38B9F907-5961-4589-90E8-9EC020B7D40D", 10, "Voluntario", "Permiso a interactuar como voluntario en la plataformaº" });

            migrationBuilder.InsertData(
                table: "UserRol",
                columns: new[] { "IDUserRol", "UserLevel", "UserRolName", "UserRolPermisions" },
                values: new object[] { "74F61449-AFA3-4D38-BBDE-4CE2600732D6", 0, "Migrante", "Permiso a interactuar como migrante en la plataformaº" });

            migrationBuilder.InsertData(
                table: "Account",
                columns: new[] { "IDAccount", "CreatedAt", "Email", "IDUserRol", "IsVerified", "PasswordHash", "RequirePasswordReset" },
                values: new object[] { "38B9F907-5961-4589-90E8-9EC020B7D40D", new DateTime(2022, 11, 26, 2, 5, 39, 789, DateTimeKind.Utc).AddTicks(2496), "angel.g.j.reyes@gmail.com", "38B9F907-5961-4589-90E8-9EC020B7D40D", true, "40a914448eff394e9cb44b9042f2e48c52727a49a7ff2f5062bd199014003645", false });

            migrationBuilder.CreateIndex(
                name: "IX_Account_Email",
                table: "Account",
                column: "Email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Account_IDUserRol",
                table: "Account",
                column: "IDUserRol");

            migrationBuilder.CreateIndex(
                name: "IX_AccountPost_LikesIDAccount",
                table: "AccountPost",
                column: "LikesIDAccount");

            migrationBuilder.CreateIndex(
                name: "IX_Comment_IDAccount",
                table: "Comment",
                column: "IDAccount");

            migrationBuilder.CreateIndex(
                name: "IX_Comment_IDPost",
                table: "Comment",
                column: "IDPost");

            migrationBuilder.CreateIndex(
                name: "IX_Profile_IDAccount",
                table: "Profile",
                column: "IDAccount");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AccountPost");

            migrationBuilder.DropTable(
                name: "Comment");

            migrationBuilder.DropTable(
                name: "Profile");

            migrationBuilder.DropTable(
                name: "Session");

            migrationBuilder.DropTable(
                name: "Post");

            migrationBuilder.DropTable(
                name: "Account");

            migrationBuilder.DropTable(
                name: "UserRol");
        }
    }
}
