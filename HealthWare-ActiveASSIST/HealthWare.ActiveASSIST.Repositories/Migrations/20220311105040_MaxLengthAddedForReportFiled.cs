using Microsoft.EntityFrameworkCore.Migrations;

namespace HealthWare.ActiveASSIST.Repositories.Migrations
{
    public partial class MaxLengthAddedForReportFiled : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "MainUser",
                keyColumn: "Id",
                keyValue: -1L,
                column: "Password",
                value: "$2a$12$PECdtTsg/3yKSwiYckUB7eLaTuzkr4aOFD.wU6wieJK0sDx/oaoFe");

            migrationBuilder.UpdateData(
                table: "MainUser",
                keyColumn: "Id",
                keyValue: 1L,
                column: "Password",
                value: "$2a$12$6fD4.DBIlpO3T5Dxy4QQp.vyPOZ3y.8Hn8RYlgX4sa1iUcHwQ3Lhi");

            migrationBuilder.UpdateData(
                table: "MainUser",
                keyColumn: "Id",
                keyValue: 2L,
                column: "Password",
                value: "$2a$12$fnLG/f43HH1EfOA.8GHwKe7je/ZU176wAzv/aYGdyDbZYqzAk9BR6");

            migrationBuilder.UpdateData(
                table: "MainUser",
                keyColumn: "Id",
                keyValue: 3L,
                column: "Password",
                value: "$2a$12$7jze1CRInWyCV2P7aUH7quGb/uTaFOCkNcMyIUgumYSsaCRpwXREq");

            migrationBuilder.UpdateData(
                table: "MainUser",
                keyColumn: "Id",
                keyValue: 4L,
                column: "Password",
                value: "$2a$12$y/jub6rCKqp48wwSmsEg7uLQZybNfL5xDQwY8SORzr3oz5H1.JlpO");

            migrationBuilder.UpdateData(
                table: "MainUser",
                keyColumn: "Id",
                keyValue: 5L,
                column: "Password",
                value: "$2a$12$qNWl9NrHZpo/z.gXIvuX9.ERx84PqpB5QpeCyRixfU1KsjlCPRJUS");

            migrationBuilder.UpdateData(
                table: "MainUser",
                keyColumn: "Id",
                keyValue: 6L,
                column: "Password",
                value: "$2a$12$hyoSpkA09wlvAAKCQxgd6OrRPyXZEBxMO0olpEcwTEZ.FwcSgsrH6");

            migrationBuilder.UpdateData(
                table: "Validators",
                keyColumn: "Id",
                keyValue: 35L,
                column: "MaxLength",
                value: 1000);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "MainUser",
                keyColumn: "Id",
                keyValue: -1L,
                column: "Password",
                value: "$2a$12$qaDE4Px3voEr5XIq8D404OZSRTNkegbCoilVXsohoJPKDiF61DuFe");

            migrationBuilder.UpdateData(
                table: "MainUser",
                keyColumn: "Id",
                keyValue: 1L,
                column: "Password",
                value: "$2a$12$jLz7Vim5AKaV1t.HhERKfef0ckKQaqoxMnKE1E1UQKmvxZFDbYSSC");

            migrationBuilder.UpdateData(
                table: "MainUser",
                keyColumn: "Id",
                keyValue: 2L,
                column: "Password",
                value: "$2a$12$1aNwEYEC1JFLICSe2c4lLenOXHkbN8jQw02ZHMNpjABQHpk9UGeI.");

            migrationBuilder.UpdateData(
                table: "MainUser",
                keyColumn: "Id",
                keyValue: 3L,
                column: "Password",
                value: "$2a$12$nULZBsMikEbRj/gwyb/BweMlh5x.LPCQc8RkfBPAgglpQYGyn1ucq");

            migrationBuilder.UpdateData(
                table: "MainUser",
                keyColumn: "Id",
                keyValue: 4L,
                column: "Password",
                value: "$2a$12$5jKSLDUXgL4AaJVtOiLZ4..M/2.ua3d/RdPWISJdYzponJ8JhnYzW");

            migrationBuilder.UpdateData(
                table: "MainUser",
                keyColumn: "Id",
                keyValue: 5L,
                column: "Password",
                value: "$2a$12$rHTbNcij90fD.zw/ke7V3Oye8a9KXXXM3wpxwCip9j8zBC1UuWRCK");

            migrationBuilder.UpdateData(
                table: "MainUser",
                keyColumn: "Id",
                keyValue: 6L,
                column: "Password",
                value: "$2a$12$wKzP2CJvhPGglAO6C0jsAeWnZGd8CROmmlqsAzU8uEwRrn7h7DVXO");

            migrationBuilder.UpdateData(
                table: "Validators",
                keyColumn: "Id",
                keyValue: 35L,
                column: "MaxLength",
                value: 0);
        }
    }
}
