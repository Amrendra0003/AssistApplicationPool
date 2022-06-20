using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace HealthWare.ActiveASSIST.Repositories.Migrations
{
    public partial class DateOfServiceTypeChanged : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "DateOfService",
                table: "Patient",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "MainUser",
                keyColumn: "Id",
                keyValue: -1L,
                column: "Password",
                value: "$2a$12$t3D2UoOwOZVw2O/Ph3otiOAB3bJsgS6jvEj7BczY4H6GCiv37psYK");

            migrationBuilder.UpdateData(
                table: "MainUser",
                keyColumn: "Id",
                keyValue: 1L,
                column: "Password",
                value: "$2a$12$hJ7MikmpTFem1KnbGxISieAAJLm1j540xRNAH0KuEk1rdsh918ECa");

            migrationBuilder.UpdateData(
                table: "MainUser",
                keyColumn: "Id",
                keyValue: 2L,
                column: "Password",
                value: "$2a$12$d4ZnlrKT061eRDNJrgH67O5FWOlwcGVrgJ.iTCazmBORsGa.9668W");

            migrationBuilder.UpdateData(
                table: "MainUser",
                keyColumn: "Id",
                keyValue: 3L,
                column: "Password",
                value: "$2a$12$9D.5/aEcE5S2n.88sgkrZOAsTK7O0YcmcPS7N5xnoh/pXnEo3x5wO");

            migrationBuilder.UpdateData(
                table: "MainUser",
                keyColumn: "Id",
                keyValue: 4L,
                column: "Password",
                value: "$2a$12$1.CCZhOPyG0gVIR0pFGUPeWGblXANnf.OrV.xt0HiXXJj1xp/HW8m");

            migrationBuilder.UpdateData(
                table: "MainUser",
                keyColumn: "Id",
                keyValue: 5L,
                column: "Password",
                value: "$2a$12$j5v2ToLOsX26.FjRtQQrFuUgqEJucbBt2VYt9VPodt.l/Z7WPkxhm");

            migrationBuilder.UpdateData(
                table: "MainUser",
                keyColumn: "Id",
                keyValue: 6L,
                column: "Password",
                value: "$2a$12$JUna6huBlCqda1pv.fZZtOYP96QVW5nG0bwULWHavNaXz7Bm3YxnW");

            migrationBuilder.UpdateData(
                table: "MainUser",
                keyColumn: "Id",
                keyValue: 7L,
                column: "Password",
                value: "$2a$12$aNGKxXRQnW8C6xZ463MV1..OPuAquo5wyO.5YMlQjoHcOBuqp98CS");

            migrationBuilder.UpdateData(
                table: "MainUser",
                keyColumn: "Id",
                keyValue: 8L,
                column: "Password",
                value: "$2a$12$cjBRa6bZucuhnwsZDpZKqu5KPFKuEWxxzd0abCRiB98j.EXXgg8LS");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "DateOfService",
                table: "Patient",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "MainUser",
                keyColumn: "Id",
                keyValue: -1L,
                column: "Password",
                value: "$2a$12$6CAJRfwtBx.rIrbNo2kZM.rAXKs7ps/OfKBsjAnAyPJA0CH1EV83m");

            migrationBuilder.UpdateData(
                table: "MainUser",
                keyColumn: "Id",
                keyValue: 1L,
                column: "Password",
                value: "$2a$12$zHy2H4N5TmnuGpIpHsx6v.YCKtCZrkAbZHoxr17USeGvs7hmSXLiC");

            migrationBuilder.UpdateData(
                table: "MainUser",
                keyColumn: "Id",
                keyValue: 2L,
                column: "Password",
                value: "$2a$12$trznEn3wIVlbccbd4jJA6OHEb9WuRtxgtAWG49u7xLIk/oKDKBB6C");

            migrationBuilder.UpdateData(
                table: "MainUser",
                keyColumn: "Id",
                keyValue: 3L,
                column: "Password",
                value: "$2a$12$oh/X.jLiePnspq72TwIKju8NCRGLKEXjlEzioDa8ydmEu60.77xGO");

            migrationBuilder.UpdateData(
                table: "MainUser",
                keyColumn: "Id",
                keyValue: 4L,
                column: "Password",
                value: "$2a$12$M6YFpjSpZ3Li.wny9wpBaezG6jSb3IG9kgtYrPrI3Nw0b1UzBHIqS");

            migrationBuilder.UpdateData(
                table: "MainUser",
                keyColumn: "Id",
                keyValue: 5L,
                column: "Password",
                value: "$2a$12$TUSIyQxsKGDF81FPzA0QG.ka0tJxb4wcJfboETTxbVSBdJtaVro/C");

            migrationBuilder.UpdateData(
                table: "MainUser",
                keyColumn: "Id",
                keyValue: 6L,
                column: "Password",
                value: "$2a$12$ejGB8X7XkLUGRkkG5zrqMOhGs/MKjmBHGnL1gQSIvKuGJASGGjvkC");

            migrationBuilder.UpdateData(
                table: "MainUser",
                keyColumn: "Id",
                keyValue: 7L,
                column: "Password",
                value: "$2a$12$8lmzu0easdv6nVfLeQEIq.O6yV3ccL2LXUl0k5FP8TLP3P0QEb3Sy");

            migrationBuilder.UpdateData(
                table: "MainUser",
                keyColumn: "Id",
                keyValue: 8L,
                column: "Password",
                value: "$2a$12$mqS1rgowJ1DoaSY1J/28WOfhnTu0WIMXhsKZPYbYyBGxGbeFIi7fK");
        }
    }
}
