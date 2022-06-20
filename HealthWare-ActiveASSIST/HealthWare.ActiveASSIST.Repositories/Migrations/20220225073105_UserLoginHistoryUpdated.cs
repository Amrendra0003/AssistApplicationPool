using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace HealthWare.ActiveASSIST.Repositories.Migrations
{
    public partial class UserLoginHistoryUpdated : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "ExpireTime",
                table: "PasswordPolicy",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AddColumn<string>(
                name: "Pattern",
                table: "PasswordPolicy",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "MainUser",
                keyColumn: "Id",
                keyValue: -1L,
                column: "Password",
                value: "$2a$12$BMybSyMuhQBQFWYsvnVY4.2Zlz0h29LnoCemIsuUkFNZAy5vu/HI2");

            migrationBuilder.UpdateData(
                table: "MainUser",
                keyColumn: "Id",
                keyValue: 1L,
                column: "Password",
                value: "$2a$12$DfcY1qQWrM42xvT71cYMteg0M59wkX1eh3OsUEqWr5W04Ee1zD1B.");

            migrationBuilder.UpdateData(
                table: "MainUser",
                keyColumn: "Id",
                keyValue: 2L,
                column: "Password",
                value: "$2a$12$qYrHzI4aJBzSMun99S0/z.HlDEfoM83IQPIowzA9y2Au1VAVURoCe");

            migrationBuilder.UpdateData(
                table: "MainUser",
                keyColumn: "Id",
                keyValue: 3L,
                column: "Password",
                value: "$2a$12$LH.qp23zltZgbyHvT6Ve2.xJlsTTxY/8naYCRDkZbfyvvxkQuSp2S");

            migrationBuilder.UpdateData(
                table: "MainUser",
                keyColumn: "Id",
                keyValue: 4L,
                column: "Password",
                value: "$2a$12$16HOZopNss75du5mt95LvOqz5F0y.pDvRqEZxSQw1Rtc5EtQOCrDi");

            migrationBuilder.UpdateData(
                table: "MainUser",
                keyColumn: "Id",
                keyValue: 5L,
                column: "Password",
                value: "$2a$12$fn0Jky/lNIR2i1gvndLNaunLQZ9JvIFFrttYmCONJgOpQKH6ntoc.");

            migrationBuilder.UpdateData(
                table: "MainUser",
                keyColumn: "Id",
                keyValue: 6L,
                column: "Password",
                value: "$2a$12$sGupu6jvuESUnoUse//BmeSx3QVrteT8Hpt24r6QA9id/Hmlhbz4m");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Pattern",
                table: "PasswordPolicy");

            migrationBuilder.AlterColumn<DateTime>(
                name: "ExpireTime",
                table: "PasswordPolicy",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "MainUser",
                keyColumn: "Id",
                keyValue: -1L,
                column: "Password",
                value: "$2a$12$NQ58N7m221jk4K1UlNpZyepkkGKBxtIBXD4MuntSDZmva8ALacEyK");

            migrationBuilder.UpdateData(
                table: "MainUser",
                keyColumn: "Id",
                keyValue: 1L,
                column: "Password",
                value: "$2a$12$uug5jvJH6Ne/5cWymMjXTO6JAi9N2IDMsUPrvDnPR0Cb6B/wy5JfG");

            migrationBuilder.UpdateData(
                table: "MainUser",
                keyColumn: "Id",
                keyValue: 2L,
                column: "Password",
                value: "$2a$12$miMBrvJCDirKr8L2lhQxY.iUoWIWGFtT9RKZt/he.6dPzlV2JugtK");

            migrationBuilder.UpdateData(
                table: "MainUser",
                keyColumn: "Id",
                keyValue: 3L,
                column: "Password",
                value: "$2a$12$wRzBbh9poWqlkEhqkM1mMOY0t8P8eNzYw33IvesFdaxeAWWTzaC7m");

            migrationBuilder.UpdateData(
                table: "MainUser",
                keyColumn: "Id",
                keyValue: 4L,
                column: "Password",
                value: "$2a$12$N.fzuqwA23EqOYN9tzo9YOL6mUUgNdPuyzS10Gq1nFqL.XzqCgWw2");

            migrationBuilder.UpdateData(
                table: "MainUser",
                keyColumn: "Id",
                keyValue: 5L,
                column: "Password",
                value: "$2a$12$XEyV45xzN5PJALoaeA1nsu.W4imO38S3G1dbpXy9gAvAIsEPeCw.q");

            migrationBuilder.UpdateData(
                table: "MainUser",
                keyColumn: "Id",
                keyValue: 6L,
                column: "Password",
                value: "$2a$12$HFMN5ybMm4dCbqIoVjCm.OjdDboi.BRobXpxpubuZCN6.t83CH07q");
        }
    }
}
