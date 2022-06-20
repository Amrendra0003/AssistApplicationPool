using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace HealthWare.ActiveASSIST.Repositories.Migrations
{
    public partial class Tenant3Added : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "ContactDetails",
                columns: new[] { "Id", "Cell", "City", "ContactTypeDetailsId", "County", "CountyCode", "CreatedBy", "CreatedDate", "Email", "Fax", "Name", "PhoneType", "State", "StateCode", "StreetAddress", "Suite", "UpdatedBy", "UpdatedDate", "Zip" },
                values: new object[,]
                {
                    { 8L, "3333333333", "Schenectady", 9L, "United States", "1", null, new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "mynthan.k@zucisystems.com", null, "Mynthan Kumar", null, "New York", "NY", null, null, null, null, "12345" },
                    { 9L, "3333333333", "Schenectady", 9L, "United States", "1", null, new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "uma.r@zucisystems.com", null, "Uma Raja", null, "New York", "NY", null, null, null, null, "12345" }
                });

            migrationBuilder.UpdateData(
                table: "MainUser",
                keyColumn: "Id",
                keyValue: -1L,
                column: "Password",
                value: "$2a$12$ykMKtsIXRYTR6r6DEbk8AOprJjXf1Kbsj8vfKSCNOH0z4WNXHGkqC");

            migrationBuilder.UpdateData(
                table: "MainUser",
                keyColumn: "Id",
                keyValue: 1L,
                column: "Password",
                value: "$2a$12$jrxy7hJAQu4Nakbz/Tu9eOCotx8DaJgwguhQjKdHrhBUiykXlnGvG");

            migrationBuilder.UpdateData(
                table: "MainUser",
                keyColumn: "Id",
                keyValue: 2L,
                column: "Password",
                value: "$2a$12$lqG0uKh7QKnr32WipUTFvuJuv6oh154qhtEv1nFxFkGAq6s28bDqS");

            migrationBuilder.UpdateData(
                table: "MainUser",
                keyColumn: "Id",
                keyValue: 3L,
                column: "Password",
                value: "$2a$12$Bn3IBX/1kwcm8pqnjHgG6.IipF.KUkLjCHkCJkwvktBd9o9lKV6WK");

            migrationBuilder.UpdateData(
                table: "MainUser",
                keyColumn: "Id",
                keyValue: 4L,
                column: "Password",
                value: "$2a$12$MA2/FG.rnpGHtWL0QUxB3u2sjZ4vZ3yw3pEYDYROdz2ZAyzOp9Ove");

            migrationBuilder.UpdateData(
                table: "MainUser",
                keyColumn: "Id",
                keyValue: 5L,
                column: "Password",
                value: "$2a$12$ObMDMUfat46..49hiMR67OLW6UUS5q242QiTUSRyJ5gFV1S2MSs/.");

            migrationBuilder.UpdateData(
                table: "MainUser",
                keyColumn: "Id",
                keyValue: 6L,
                column: "Password",
                value: "$2a$12$fPImBtkUfmHqiMayLY.zmOcwuMdLpyRYOEPowNHI.7/XSfx4x1/iS");

            migrationBuilder.InsertData(
                table: "SubDomainMaster",
                columns: new[] { "Id", "SubDomain", "TenantId" },
                values: new object[] { 3L, "activeassist-pt.zucisystems.com:8080", "3" });

            migrationBuilder.InsertData(
                table: "TenantDetails",
                columns: new[] { "Id", "CountyCode", "CreatedBy", "CreatedDate", "PhoneNumber", "TenantName", "UpdatedBy", "UpdatedDate" },
                values: new object[] { 3L, "1", null, new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "4463432341", "Tenant 3", null, null });

            migrationBuilder.InsertData(
                table: "MainUser",
                columns: new[] { "Id", "CanChangePassword", "Cell", "ContactDetailsId", "CountyCode", "CreatedBy", "CreatedDate", "DateOfBirth", "Discriminator", "EmailAddress", "FirstName", "Gender", "IsActive", "IsAuthenticated", "IsTokenConsumed", "IsTwoFactorEnabled", "LastName", "LoginOTPUpdatedTime", "MaritalStatus", "MiddleName", "OtpNumber", "Password", "SSNNumber", "TenantId", "UpdatedBy", "UpdatedDate" },
                values: new object[] { 7L, false, "9998789876", 8L, "1", null, new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1996, 11, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "User", "mynthan.k@zucisystems.com", "Mynthan", "Male", true, false, false, null, "Kumar", null, "Single", null, null, "$2a$12$4zx.8ATdP8DHOk/vNAeW0OtrLKCs0n8ACaRZMp6zMyfjPywSn.Svq", "215526682", null, null, null });

            migrationBuilder.InsertData(
                table: "MainUser",
                columns: new[] { "Id", "CanChangePassword", "Cell", "ContactDetailsId", "CountyCode", "CreatedBy", "CreatedDate", "DateOfBirth", "Discriminator", "EmailAddress", "FirstName", "Gender", "IsActive", "IsAuthenticated", "IsTokenConsumed", "IsTwoFactorEnabled", "LastName", "LoginOTPUpdatedTime", "MaritalStatus", "MiddleName", "OtpNumber", "Password", "SSNNumber", "TenantId", "UpdatedBy", "UpdatedDate" },
                values: new object[] { 8L, false, "9998789876", 9L, "1", null, new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1996, 11, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "User", "uma.r@zucisystems.com", "Uma", "Male", true, false, false, null, "Raja", null, "Married", null, null, "$2a$12$hQRLjkxQfz.Ydq5JlC9Zq.4dGSxjLCoAR4KwZlBvecA.2gq/4PwNu", "215526999", null, null, null });

            migrationBuilder.InsertData(
                table: "UserHasRoles",
                columns: new[] { "Id", "RoleId", "UserId" },
                values: new object[] { 7L, 1L, 7L });

            migrationBuilder.InsertData(
                table: "UserHasRoles",
                columns: new[] { "Id", "RoleId", "UserId" },
                values: new object[] { 8L, 2L, 8L });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "SubDomainMaster",
                keyColumn: "Id",
                keyValue: 3L);

            migrationBuilder.DeleteData(
                table: "TenantDetails",
                keyColumn: "Id",
                keyValue: 3L);

            migrationBuilder.DeleteData(
                table: "UserHasRoles",
                keyColumn: "Id",
                keyValue: 7L);

            migrationBuilder.DeleteData(
                table: "UserHasRoles",
                keyColumn: "Id",
                keyValue: 8L);

            migrationBuilder.DeleteData(
                table: "MainUser",
                keyColumn: "Id",
                keyValue: 7L);

            migrationBuilder.DeleteData(
                table: "MainUser",
                keyColumn: "Id",
                keyValue: 8L);

            migrationBuilder.DeleteData(
                table: "ContactDetails",
                keyColumn: "Id",
                keyValue: 8L);

            migrationBuilder.DeleteData(
                table: "ContactDetails",
                keyColumn: "Id",
                keyValue: 9L);

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
        }
    }
}
