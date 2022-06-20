using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace HealthWare.ActiveASSIST.Repositories.Migrations
{
    public partial class SeedDataForPasswordPolicy : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "MaximumLength",
                table: "PasswordPolicy",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "MinimumLength",
                table: "PasswordPolicy",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "MainUser",
                keyColumn: "Id",
                keyValue: -1L,
                column: "Password",
                value: "$2a$12$82TJbVDKTQEJDKDJonZkSuY5TKpI10QsiEXS5h5qq0zmDeQbMIFeO");

            migrationBuilder.UpdateData(
                table: "MainUser",
                keyColumn: "Id",
                keyValue: 1L,
                column: "Password",
                value: "$2a$12$8EeA0WMeLZgjiH7zvqhDyeP5FChEyE2sfaFXGBEri2FawP9DkXtUO");

            migrationBuilder.UpdateData(
                table: "MainUser",
                keyColumn: "Id",
                keyValue: 2L,
                column: "Password",
                value: "$2a$12$2/S28mTRud5tbkZ5N5G14eKrgrpgP2KkY1N7H5Qp8ARB80.YrYw0K");

            migrationBuilder.UpdateData(
                table: "MainUser",
                keyColumn: "Id",
                keyValue: 3L,
                column: "Password",
                value: "$2a$12$xQwAm85lM6WaNwt.PwgWnONYpCbyfPYjnp.eXGH6INmhatbjBE1RS");

            migrationBuilder.UpdateData(
                table: "MainUser",
                keyColumn: "Id",
                keyValue: 4L,
                column: "Password",
                value: "$2a$12$C/G2Pxbf6R6cmHXvElGjDOGUwVmoNXVHJGwmiuKdwjM18EDTqRj5q");

            migrationBuilder.UpdateData(
                table: "MainUser",
                keyColumn: "Id",
                keyValue: 5L,
                column: "Password",
                value: "$2a$12$V4faenm1ozMcdVyFHVBLUO/cZreQJGq/ELzH26WlqRNPmwHJ7S39C");

            migrationBuilder.UpdateData(
                table: "MainUser",
                keyColumn: "Id",
                keyValue: 6L,
                column: "Password",
                value: "$2a$12$EAnl2ITVuCK76juKRLVY1uhW0yGGQTztmaYsS7BuFqJbqNd9Zocva");

            migrationBuilder.InsertData(
                table: "PasswordPolicy",
                columns: new[] { "Id", "AttemptLimits", "CreatedBy", "CreatedDate", "ExpireTime", "MaximumLength", "MinimumLength", "Pattern", "TenantId", "UpdatedBy", "UpdatedDate" },
                values: new object[,]
                {
                    { 1L, 4, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "24", 15, 8, "^(?=.*[A-Za-z])(?=.*\\d)(?=.*[@$!%*#?&])[A-Za-z\\d@$!%*#?&]{8,}$", "1", null, null },
                    { 2L, 4, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "24", 15, 8, "^(?=.*[A-Za-z])(?=.*\\d)(?=.*[@$!%*#?&])[A-Za-z\\d@$!%*#?&]{8,}$", "2", null, null }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "PasswordPolicy",
                keyColumn: "Id",
                keyValue: 1L);

            migrationBuilder.DeleteData(
                table: "PasswordPolicy",
                keyColumn: "Id",
                keyValue: 2L);

            migrationBuilder.DropColumn(
                name: "MaximumLength",
                table: "PasswordPolicy");

            migrationBuilder.DropColumn(
                name: "MinimumLength",
                table: "PasswordPolicy");

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
    }
}
