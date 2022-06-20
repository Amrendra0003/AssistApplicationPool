using Microsoft.EntityFrameworkCore.Migrations;

namespace HealthWare.ActiveASSIST.Repositories.Migrations
{
    public partial class ContactDetailsUpdated : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "ContactDetails",
                keyColumn: "Id",
                keyValue: 2L,
                columns: new[] { "City", "County", "State", "StateCode", "Zip" },
                values: new object[] { "Schenectady", "United States", "New York", "NY", "12345" });

            migrationBuilder.UpdateData(
                table: "ContactDetails",
                keyColumn: "Id",
                keyValue: 3L,
                columns: new[] { "City", "County", "State", "StateCode", "Zip" },
                values: new object[] { "Schenectady", "United States", "New York", "NY", "12345" });

            migrationBuilder.UpdateData(
                table: "ContactDetails",
                keyColumn: "Id",
                keyValue: 4L,
                columns: new[] { "City", "County", "State", "StateCode", "Zip" },
                values: new object[] { "Schenectady", "United States", "New York", "NY", "12345" });

            migrationBuilder.UpdateData(
                table: "ContactDetails",
                keyColumn: "Id",
                keyValue: 5L,
                columns: new[] { "City", "County", "State", "StateCode", "Zip" },
                values: new object[] { "Schenectady", "United States", "New York", "NY", "12345" });

            migrationBuilder.UpdateData(
                table: "ContactDetails",
                keyColumn: "Id",
                keyValue: 6L,
                columns: new[] { "City", "County", "State", "StateCode", "Zip" },
                values: new object[] { "Schenectady", "United States", "New York", "NY", "12345" });

            migrationBuilder.UpdateData(
                table: "ContactDetails",
                keyColumn: "Id",
                keyValue: 7L,
                columns: new[] { "City", "County", "State", "StateCode", "Zip" },
                values: new object[] { "Schenectady", "United States", "New York", "NY", "12345" });

            migrationBuilder.UpdateData(
                table: "MainUser",
                keyColumn: "Id",
                keyValue: -1L,
                column: "Password",
                value: "$2a$12$2jpXKn8RrnjbxzDOFE8sduVsu.BOXD3HH3ylqaQvkpV0yQqzh38Xy");

            migrationBuilder.UpdateData(
                table: "MainUser",
                keyColumn: "Id",
                keyValue: 1L,
                column: "Password",
                value: "$2a$12$6nYs3Cm12fMZb5tZnzbCG.VIezUa0e6yeVrCpG3vlynY.7aQwbWR2");

            migrationBuilder.UpdateData(
                table: "MainUser",
                keyColumn: "Id",
                keyValue: 2L,
                column: "Password",
                value: "$2a$12$bV8GQOSET7e1fDwiMPsyuOVZzhO5kc1YvtqAQfy5euP28/XWHytK6");

            migrationBuilder.UpdateData(
                table: "MainUser",
                keyColumn: "Id",
                keyValue: 3L,
                column: "Password",
                value: "$2a$12$BNHJ/1Odi.B1EPey3KdL5udntMrWE25982uHLx5CkHI0r/vNlKtua");

            migrationBuilder.UpdateData(
                table: "MainUser",
                keyColumn: "Id",
                keyValue: 4L,
                column: "Password",
                value: "$2a$12$5YAS98gvwyfa8hhO08CpLuNILYdI84igzzE2sdlr9sh0EPZoqv57G");

            migrationBuilder.UpdateData(
                table: "MainUser",
                keyColumn: "Id",
                keyValue: 5L,
                column: "Password",
                value: "$2a$12$lUFWHbGIAnlbaTdT3f17ke.ckH77CiksAhTDdoLVmiY.A7p3SPRfO");

            migrationBuilder.UpdateData(
                table: "MainUser",
                keyColumn: "Id",
                keyValue: 6L,
                column: "Password",
                value: "$2a$12$Os0Ul/T7dDu9JCFoAX7HV.sbNSkVp/068rTvDGVriJXcL28acvipu");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "ContactDetails",
                keyColumn: "Id",
                keyValue: 2L,
                columns: new[] { "City", "County", "State", "StateCode", "Zip" },
                values: new object[] { null, null, null, null, null });

            migrationBuilder.UpdateData(
                table: "ContactDetails",
                keyColumn: "Id",
                keyValue: 3L,
                columns: new[] { "City", "County", "State", "StateCode", "Zip" },
                values: new object[] { null, null, null, null, null });

            migrationBuilder.UpdateData(
                table: "ContactDetails",
                keyColumn: "Id",
                keyValue: 4L,
                columns: new[] { "City", "County", "State", "StateCode", "Zip" },
                values: new object[] { null, null, null, null, null });

            migrationBuilder.UpdateData(
                table: "ContactDetails",
                keyColumn: "Id",
                keyValue: 5L,
                columns: new[] { "City", "County", "State", "StateCode", "Zip" },
                values: new object[] { null, null, null, null, null });

            migrationBuilder.UpdateData(
                table: "ContactDetails",
                keyColumn: "Id",
                keyValue: 6L,
                columns: new[] { "City", "County", "State", "StateCode", "Zip" },
                values: new object[] { null, null, null, null, null });

            migrationBuilder.UpdateData(
                table: "ContactDetails",
                keyColumn: "Id",
                keyValue: 7L,
                columns: new[] { "City", "County", "State", "StateCode", "Zip" },
                values: new object[] { null, null, null, null, null });

            migrationBuilder.UpdateData(
                table: "MainUser",
                keyColumn: "Id",
                keyValue: -1L,
                column: "Password",
                value: "$2a$12$n3jwbsrSD2x.JoYK/VumTuMR.PcfUHVNnEFdJqdoyUQRBrgFoFffy");

            migrationBuilder.UpdateData(
                table: "MainUser",
                keyColumn: "Id",
                keyValue: 1L,
                column: "Password",
                value: "$2a$12$ckoA4XzAETK3kqkBBgE2Auh26iIYxFYUYLtwUmahWTbPO3506hCvm");

            migrationBuilder.UpdateData(
                table: "MainUser",
                keyColumn: "Id",
                keyValue: 2L,
                column: "Password",
                value: "$2a$12$ELIYyLqMnK5KvMiV1dB5h.H6p2x/ybo9B0TT4b8T.kDGwDQnpmAGi");

            migrationBuilder.UpdateData(
                table: "MainUser",
                keyColumn: "Id",
                keyValue: 3L,
                column: "Password",
                value: "$2a$12$Cn0zua0OJKyoimdGjwi2IO5743AHqgf3TwqZw4SCt9uPNpJz1jg5O");

            migrationBuilder.UpdateData(
                table: "MainUser",
                keyColumn: "Id",
                keyValue: 4L,
                column: "Password",
                value: "$2a$12$ipsqrzYFpV8sqRPnFFTBX.UjrVl1T6LN24JpW/y3MJvPoUtRpGwz.");

            migrationBuilder.UpdateData(
                table: "MainUser",
                keyColumn: "Id",
                keyValue: 5L,
                column: "Password",
                value: "$2a$12$r/JLUTIQlzf5UbRrB1g.zOJ8MYQ11UtW7eJTItBpn07vquLF1mYt2");

            migrationBuilder.UpdateData(
                table: "MainUser",
                keyColumn: "Id",
                keyValue: 6L,
                column: "Password",
                value: "$2a$12$fWGpSr.WXRT.a8ytChsNjumTCMk8ZBVNr6C7ovGvEe834uJrwierq");
        }
    }
}
