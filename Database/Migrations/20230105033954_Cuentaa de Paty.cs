using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Database.Migrations
{
    public partial class CuentaadePaty : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Account",
                keyColumn: "IDAccount",
                keyValue: "38B9F907-5961-4589-90E8-9EC020B7D40D",
                column: "CreatedAt",
                value: new DateTime(2023, 1, 5, 3, 39, 54, 367, DateTimeKind.Utc).AddTicks(4565));

            migrationBuilder.InsertData(
                table: "Account",
                columns: new[] { "IDAccount", "CreatedAt", "Email", "IDUserRol", "IsVerified", "PasswordHash", "RequirePasswordReset" },
                values: new object[] { "701D5C1F-1243-4898-81B0-6DA7A9D29152", new DateTime(2023, 1, 5, 3, 39, 54, 367, DateTimeKind.Utc).AddTicks(4626), "paty.jaimessantos@gmail.com", "38B9F907-5961-4589-90E8-9EC020B7D40D", true, "8b5ff0be6ed40b3c83876d4c19557c27328dc94b6ecf3fc1a57784a432191e12", false });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Account",
                keyColumn: "IDAccount",
                keyValue: "701D5C1F-1243-4898-81B0-6DA7A9D29152");

            migrationBuilder.UpdateData(
                table: "Account",
                keyColumn: "IDAccount",
                keyValue: "38B9F907-5961-4589-90E8-9EC020B7D40D",
                column: "CreatedAt",
                value: new DateTime(2022, 11, 26, 2, 5, 39, 789, DateTimeKind.Utc).AddTicks(2496));
        }
    }
}
