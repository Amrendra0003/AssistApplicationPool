using Microsoft.EntityFrameworkCore.Migrations;

namespace HealthWare.ActiveASSIST.Repositories.Migrations
{
    public partial class PermissionsUpdated : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Permission",
                columns: new[] { "Id", "Name" },
                values: new object[] { 81L, "ViewComponentApplicationCompleted" });

            migrationBuilder.InsertData(
                table: "RolesPermissions",
                columns: new[] { "Id", "PermissionId", "RoleId" },
                values: new object[,]
                {
                    { 118L, 45L, 1L },
                    { 119L, 29L, 1L },
                    { 120L, 25L, 1L },
                    { 121L, 53L, 1L },
                    { 122L, 21L, 1L },
                    { 123L, 21L, 2L },
                    { 125L, 80L, 1L },
                    { 126L, 80L, 2L }
                });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: -1L,
                column: "Password",
                value: "$2a$12$yoyGzPrn8yIzr/KWojSv6OPtEK28G6eGc4bG2uBFn/ACm/S7WQnEO");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1L,
                column: "Password",
                value: "$2a$12$UV8mIanFnXgT2.WsVDaiMu8T153gA9Kyc9q144m6g.GrtTnVTzKMK");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2L,
                column: "Password",
                value: "$2a$12$1V1tr4V5ANz7RE5DkXwU6uThp5JfoelVHehtForjoxV4hm0ElqEPy");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3L,
                column: "Password",
                value: "$2a$12$VE.HElseS1Tyd9WbhvD0KOsGA3MQy0ITjd5srpDNZnAdQVwuD8X8.");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 4L,
                column: "Password",
                value: "$2a$12$o7qmiDTOdZBRQnH0VycujeU6i9k45dpNMwTvZ.ie15iKosJXbu7SK");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 5L,
                column: "Password",
                value: "$2a$12$fyhpWUPWsTCNkD98Nd8J2uakcaRQn9/HKgx6wIvAwGswy8QN415RW");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 6L,
                column: "Password",
                value: "$2a$12$GdlYHDkXupeAic/d/MsxNu9TeHSHtv0cnpZ.qiSdTj6BUUjcKQFLW");

            migrationBuilder.InsertData(
                table: "RolesPermissions",
                columns: new[] { "Id", "PermissionId", "RoleId" },
                values: new object[] { 124L, 81L, 1L });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "RolesPermissions",
                keyColumn: "Id",
                keyValue: 118L);

            migrationBuilder.DeleteData(
                table: "RolesPermissions",
                keyColumn: "Id",
                keyValue: 119L);

            migrationBuilder.DeleteData(
                table: "RolesPermissions",
                keyColumn: "Id",
                keyValue: 120L);

            migrationBuilder.DeleteData(
                table: "RolesPermissions",
                keyColumn: "Id",
                keyValue: 121L);

            migrationBuilder.DeleteData(
                table: "RolesPermissions",
                keyColumn: "Id",
                keyValue: 122L);

            migrationBuilder.DeleteData(
                table: "RolesPermissions",
                keyColumn: "Id",
                keyValue: 123L);

            migrationBuilder.DeleteData(
                table: "RolesPermissions",
                keyColumn: "Id",
                keyValue: 124L);

            migrationBuilder.DeleteData(
                table: "RolesPermissions",
                keyColumn: "Id",
                keyValue: 125L);

            migrationBuilder.DeleteData(
                table: "RolesPermissions",
                keyColumn: "Id",
                keyValue: 126L);

            migrationBuilder.DeleteData(
                table: "Permission",
                keyColumn: "Id",
                keyValue: 81L);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: -1L,
                column: "Password",
                value: "$2a$12$dSrTJVs.D.y7TXrS.eUxDuliIkh1jbK4HEUI8hczzHLCymEpWRwy2");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1L,
                column: "Password",
                value: "$2a$12$cFk5nEZbp4uhJXvtSHIxBOOs4mwJEq3GjT/kvbgCGdpPrGBH.skeO");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2L,
                column: "Password",
                value: "$2a$12$B0nGBcUIPmKqwHRZ88CspOVnK8mIcxFCjS9.1A1uA.pL.etz/R34y");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3L,
                column: "Password",
                value: "$2a$12$FjTVksE87s0Z8I3XdJSQkeee/mNYPTf/Xf5n86pDgWzCf07lnooSq");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 4L,
                column: "Password",
                value: "$2a$12$XMMvO6cP95rknHRaQ9N/X.e9t/KvwSsIqRp3epfs/YIQIyRJQuskO");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 5L,
                column: "Password",
                value: "$2a$12$uCbtkVhX71TJV41nMhnMeub3b6xOZI9ka1wrxNE7a/65iPLVjv0s.");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 6L,
                column: "Password",
                value: "$2a$12$KXSFawV4aXJBSLlU2Pp4o.kJ5tmTNEuurGQGAvj9fXKTDKPN0DsDW");
        }
    }
}
