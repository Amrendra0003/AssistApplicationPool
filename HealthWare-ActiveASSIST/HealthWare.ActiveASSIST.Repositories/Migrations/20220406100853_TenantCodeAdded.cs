using Microsoft.EntityFrameworkCore.Migrations;

namespace HealthWare.ActiveASSIST.Repositories.Migrations
{
    public partial class TenantCodeAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "EmailAddress",
                table: "TenantDetails",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TenantCode",
                table: "TenantDetails",
                type: "nvarchar(max)",
                nullable: true);

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

            migrationBuilder.UpdateData(
                table: "TenantDetails",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "EmailAddress", "TenantCode" },
                values: new object[] { "support@tenant1.com", "MHC" });

            migrationBuilder.UpdateData(
                table: "TenantDetails",
                keyColumn: "Id",
                keyValue: 2L,
                columns: new[] { "EmailAddress", "TenantCode" },
                values: new object[] { "support@tenant2.com", "LOC" });

            migrationBuilder.UpdateData(
                table: "TenantDetails",
                keyColumn: "Id",
                keyValue: 3L,
                columns: new[] { "EmailAddress", "TenantCode" },
                values: new object[] { "support@tenant3.com", "MV" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EmailAddress",
                table: "TenantDetails");

            migrationBuilder.DropColumn(
                name: "TenantCode",
                table: "TenantDetails");

            migrationBuilder.UpdateData(
                table: "MainUser",
                keyColumn: "Id",
                keyValue: -1L,
                column: "Password",
                value: "$2a$12$nEBx8.oi0gyZ2pMzSp.ZVOU.jTMf7UBh0SehFuvbsGQbNcZ5FOUV.");

            migrationBuilder.UpdateData(
                table: "MainUser",
                keyColumn: "Id",
                keyValue: 1L,
                column: "Password",
                value: "$2a$12$UaA5vyh/C1MhQjXJ0gs0FOhp68H1BytkVIVsz6sqhC4v9tSrw8yU.");

            migrationBuilder.UpdateData(
                table: "MainUser",
                keyColumn: "Id",
                keyValue: 2L,
                column: "Password",
                value: "$2a$12$/P0/KyQMa3nSHumwTJka7uXeTJDsV6LcsEOJJmMfRkb47zj9N9oMO");

            migrationBuilder.UpdateData(
                table: "MainUser",
                keyColumn: "Id",
                keyValue: 3L,
                column: "Password",
                value: "$2a$12$zjLsNcCC52OxdPK10q/4ougSW0tF2QTTXd.okJkFShP7/CGdD5M3G");

            migrationBuilder.UpdateData(
                table: "MainUser",
                keyColumn: "Id",
                keyValue: 4L,
                column: "Password",
                value: "$2a$12$DCimTHfw1q1q00KqAAJIBudctAlxjXyw.gmq5bAikT.AKeN.PmUCq");

            migrationBuilder.UpdateData(
                table: "MainUser",
                keyColumn: "Id",
                keyValue: 5L,
                column: "Password",
                value: "$2a$12$7eNJ5l13CBDTuiB3Oxnuqed1c76a3EZ8rqJ4TJKCwpiqpdZR0L8Fm");

            migrationBuilder.UpdateData(
                table: "MainUser",
                keyColumn: "Id",
                keyValue: 6L,
                column: "Password",
                value: "$2a$12$gV.8dIc7K8fSmWN3id/4reb9wsHvuo.uoO3T7ZT5bJPMr6pD6bzEu");

            migrationBuilder.UpdateData(
                table: "MainUser",
                keyColumn: "Id",
                keyValue: 7L,
                column: "Password",
                value: "$2a$12$xvFFRH1jHmsqQlGyFb2HSe46nd4QTB8Gh0xjIfBmbL.K6lHrD6qLG");

            migrationBuilder.UpdateData(
                table: "MainUser",
                keyColumn: "Id",
                keyValue: 8L,
                column: "Password",
                value: "$2a$12$BL8QnixytajgI7cgoDrPVub/PlAfgYRtuWuPznV7d3tOFe9iDuY1G");
        }
    }
}
