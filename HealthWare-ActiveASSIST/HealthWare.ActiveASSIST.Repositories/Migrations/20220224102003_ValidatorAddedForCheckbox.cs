using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace HealthWare.ActiveASSIST.Repositories.Migrations
{
    public partial class ValidatorAddedForCheckbox : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.InsertData(
                table: "Validators",
                columns: new[] { "Id", "CreatedBy", "CreatedDate", "Max", "MaxLength", "Min", "MinLength", "PatternId", "QuickAssessmentQuestionsId", "Required", "UpdatedBy", "UpdatedDate" },
                values: new object[] { 35L, null, new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 0, null, 0, null, 33L, true, null, null });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Validators",
                keyColumn: "Id",
                keyValue: 35L);

            migrationBuilder.UpdateData(
                table: "MainUser",
                keyColumn: "Id",
                keyValue: -1L,
                column: "Password",
                value: "$2a$12$AGaKlEIXLSHWGPlXo16bBOXAGF1JvYH/NXhZdgzRP0zftlZHr7A7W");

            migrationBuilder.UpdateData(
                table: "MainUser",
                keyColumn: "Id",
                keyValue: 1L,
                column: "Password",
                value: "$2a$12$OcOtSiXj0J5WQ1jcBX3g6.poF6RMuU9V8lc7JJbsrR4us229RrMau");

            migrationBuilder.UpdateData(
                table: "MainUser",
                keyColumn: "Id",
                keyValue: 2L,
                column: "Password",
                value: "$2a$12$dK/fnfyE3aHEQREuWkYHMOT230erPn9E04jaSsxCP2yJYllhVrqSm");

            migrationBuilder.UpdateData(
                table: "MainUser",
                keyColumn: "Id",
                keyValue: 3L,
                column: "Password",
                value: "$2a$12$Pd6Gv37w9FZud1az7Kffb.kBFUP9UhZarkjtJMtYnZLLEzKSlxcIi");

            migrationBuilder.UpdateData(
                table: "MainUser",
                keyColumn: "Id",
                keyValue: 4L,
                column: "Password",
                value: "$2a$12$MNgeL14MomIk7CshV6s34.60xbIpNjeTA7xY58YJNwX..VkKuzWoS");

            migrationBuilder.UpdateData(
                table: "MainUser",
                keyColumn: "Id",
                keyValue: 5L,
                column: "Password",
                value: "$2a$12$SmzmKLHruMBzDcofKy3louO5p4t0i87ClwshNTcptRJpr8b9TLlxe");

            migrationBuilder.UpdateData(
                table: "MainUser",
                keyColumn: "Id",
                keyValue: 6L,
                column: "Password",
                value: "$2a$12$MfNtpdc2bljRaBfJTdFtp.Y46Upyda1V4Y16SF9I6HvYFuNPjHNkm");
        }
    }
}
