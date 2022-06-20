using Microsoft.EntityFrameworkCore.Migrations;

namespace HealthWare.ActiveASSIST.Repositories.Migrations
{
    public partial class seedDataAddedMaxlength : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.UpdateData(
                table: "Validators",
                keyColumn: "Id",
                keyValue: 25L,
                column: "Max",
                value: 50000);

            migrationBuilder.UpdateData(
                table: "Validators",
                keyColumn: "Id",
                keyValue: 27L,
                column: "Max",
                value: 50000);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "MainUser",
                keyColumn: "Id",
                keyValue: -1L,
                column: "Password",
                value: "$2a$12$N0AwCxVAsQJCDdMJ1JhLUu..NLLZt.Jt44aog2G5Gq41G/iLbxKL2");

            migrationBuilder.UpdateData(
                table: "MainUser",
                keyColumn: "Id",
                keyValue: 1L,
                column: "Password",
                value: "$2a$12$ytbVsQUVOuKcwurjnovNguf6oKhrJGnZm0O.0qjkUhd5/aSJJnzMu");

            migrationBuilder.UpdateData(
                table: "MainUser",
                keyColumn: "Id",
                keyValue: 2L,
                column: "Password",
                value: "$2a$12$qkLTFUxuvhrEGC78uHwnquFmyfCJysqj8NkK0t/GjLC1sJyfAx.WG");

            migrationBuilder.UpdateData(
                table: "MainUser",
                keyColumn: "Id",
                keyValue: 3L,
                column: "Password",
                value: "$2a$12$vCo6tuEhskbAHKrz0CCWJuq.5og0IH4MMRVjnqQmtJVfBDQTgLyJ6");

            migrationBuilder.UpdateData(
                table: "MainUser",
                keyColumn: "Id",
                keyValue: 4L,
                column: "Password",
                value: "$2a$12$0U1Ww4v5kgyYleK7wXULV.6w7E7YVh91rYuQQqY3DoAsiq5.PcD6u");

            migrationBuilder.UpdateData(
                table: "MainUser",
                keyColumn: "Id",
                keyValue: 5L,
                column: "Password",
                value: "$2a$12$Mix6lEOLjp7/vr8ZHr6c0u.TVs5jcmNOcFbZZ5nbFOwSr.RCTqioC");

            migrationBuilder.UpdateData(
                table: "MainUser",
                keyColumn: "Id",
                keyValue: 6L,
                column: "Password",
                value: "$2a$12$uosTd6egyZB7iiJfli0ZOOE.drTU7AmncfhgL7/In5l4raUxij/0u");

            migrationBuilder.UpdateData(
                table: "Validators",
                keyColumn: "Id",
                keyValue: 25L,
                column: "Max",
                value: null);

            migrationBuilder.UpdateData(
                table: "Validators",
                keyColumn: "Id",
                keyValue: 27L,
                column: "Max",
                value: null);
        }
    }
}
