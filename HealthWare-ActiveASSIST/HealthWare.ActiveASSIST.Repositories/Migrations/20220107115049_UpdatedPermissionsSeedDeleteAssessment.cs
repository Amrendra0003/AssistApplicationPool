using Microsoft.EntityFrameworkCore.Migrations;

namespace HealthWare.ActiveASSIST.Repositories.Migrations
{
    public partial class UpdatedPermissionsSeedDeleteAssessment : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "RolesPermissions",
                columns: new[] { "Id", "PermissionId", "RoleId" },
                values: new object[,]
                {
                    { 116L, 26L, 1L },
                    { 117L, 26L, 2L }
                });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: -1L,
                column: "Password",
                value: "$2a$12$qUFHUf748BxHqPoWhi3r1uitHky8L7ARNs1v41bo.yI8dCVsUCocm");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1L,
                column: "Password",
                value: "$2a$12$4JAK45A4/u2sIwUUad1yNuZcsgjNEgE082DcQHQ1ka.ABWGR73i2C");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2L,
                column: "Password",
                value: "$2a$12$Be2OlQfsRWkZKOPIUJMC6uO5JfjLwKc9Ge60wHS25ebJHNeMssaxa");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3L,
                column: "Password",
                value: "$2a$12$csvEZDVv3GE4tngMkWPPG.UhVVhPcgNI/7lQyE/XVul./ERZb8XLG");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 4L,
                column: "Password",
                value: "$2a$12$1u2sv4tU9bX.buk3If8lKOj97UzNZZOHZuNGd.khqL3qSq3vxVHg6");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 5L,
                column: "Password",
                value: "$2a$12$lcSvDnzPB2NH90jP3TFZ8.Ik3BbiQZc3d4qJhQ4S8B8zxJddEQXnW");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 6L,
                column: "Password",
                value: "$2a$12$hg6VwJ2X9Gg719rgLlsf/e5aw2FKWOeGDmsUPkD90NVKgQfGtM/qi");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "RolesPermissions",
                keyColumn: "Id",
                keyValue: 116L);

            migrationBuilder.DeleteData(
                table: "RolesPermissions",
                keyColumn: "Id",
                keyValue: 117L);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: -1L,
                column: "Password",
                value: "$2a$12$DxoIJE0jbEhRqWPN6tAOM.BDGEbOZenIF76EZDhOs1jG1HJ1ucDzi");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1L,
                column: "Password",
                value: "$2a$12$SBMDw9FafF8GFGnjOaO0CuwJ23DDKbV6B8F06Utn3KMtkCW1xhgy.");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2L,
                column: "Password",
                value: "$2a$12$SH.Uj8bAKX7gejcwZlZQkebWceUMEb8T5bSmGFERgwE9j5.XRnlYG");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3L,
                column: "Password",
                value: "$2a$12$DIDHRG9jMfibuxTV3xZQIOc5fMfLHwa/1KPTtOwCE.MXUsi9rHAGS");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 4L,
                column: "Password",
                value: "$2a$12$Je/OZauQA1qgO/RY4jGclOmTSU04TCG9J/7f6c8KeZCmt.bcK6pMS");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 5L,
                column: "Password",
                value: "$2a$12$4CCDbKqBkIBsRO6JGvUmjuSIT786Dct1tsebqqTqh.5BVf10KeGWO");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 6L,
                column: "Password",
                value: "$2a$12$xmGuQntSaZoT6bsmw20BBewpxxQHw2iiv09SUGkNYUMYTOncLe4g2");
        }
    }
}
