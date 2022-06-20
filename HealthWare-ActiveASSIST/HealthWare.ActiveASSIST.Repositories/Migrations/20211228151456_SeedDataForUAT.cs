using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace HealthWare.ActiveASSIST.Repositories.Migrations
{
    public partial class SeedDataForUAT : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "ContactDetails",
                keyColumn: "Id",
                keyValue: 1L,
                column: "CountyCode",
                value: "1");

            migrationBuilder.UpdateData(
                table: "ContactDetails",
                keyColumn: "Id",
                keyValue: 3L,
                column: "CountyCode",
                value: "1");

            migrationBuilder.InsertData(
                table: "ContactDetails",
                columns: new[] { "Id", "Cell", "City", "ContactTypeDetailsId", "County", "CountyCode", "CreatedBy", "CreatedDate", "Email", "Fax", "Name", "PhoneType", "State", "StateCode", "StreetAddress", "Suite", "UpdatedBy", "UpdatedDate", "Zip" },
                values: new object[,]
                {
                    { 4L, "3333333333", null, 9L, null, "1", null, new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "dkucherina@healthwaresystems.com", null, "Dimitriy Kucherina", null, null, null, null, null, null, null, null },
                    { 5L, "3333333333", null, 9L, null, "1", null, new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "psubbaraman@healthwaresystems.com", null, "Subba Raman", null, null, null, null, null, null, null, null },
                    { 6L, "3333333333", null, 9L, null, "1", null, new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "sgruner@healthwaresystems.com", null, "Stephen Gruner", null, null, null, null, null, null, null, null },
                    { 7L, "3333333333", null, 9L, null, "1", null, new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "jkunwar@healthwaresystems.com", null, "Jay Kunwar", null, null, null, null, null, null, null, null }
                });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: -1L,
                column: "Password",
                value: "$2a$12$CJ9lkR.MbnwOqGcDQ.qNu.xLGxylavVqsRszedOCYGVAWlL2ggXVG");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "CountyCode", "Password", "SSNNumber" },
                values: new object[] { "1", "$2a$12$lMrhEkDQJOFw4BEfG0mCtO12WtIZiMbSixFyMnbkhdmPT1hnODGGC", "212128812" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2L,
                columns: new[] { "CountyCode", "Password", "SSNNumber" },
                values: new object[] { "1", "$2a$12$eEvQhkiJxeS2tZS1S060yeB1Dlpzpm.e/qOSpJDDOfW7uTemMf7VS", "212127744" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CanChangePassword", "Cell", "ContactDetailsId", "CountyCode", "CreatedBy", "CreatedDate", "DateOfBirth", "EmailAddress", "FirstName", "Gender", "IsActive", "IsAuthenticated", "IsTokenConsumed", "IsTwoFactorEnabled", "LastName", "LoginOTPUpdatedTime", "MaritalStatus", "MiddleName", "OtpNumber", "Password", "SSNNumber", "UpdatedBy", "UpdatedDate" },
                values: new object[,]
                {
                    { 3L, false, "9998789876", 4L, "1", null, new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1996, 11, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "dkucherina@healthwaresystems.com", "Dimitriy", "Male", true, false, false, null, "Kucherina", null, "Single", null, null, "$2a$12$AwObjAP.ofpDnefuZ9wwBOROu1Q7I1f.wWdg4NCSctiS6xvF/vAIm", "212127766", null, null },
                    { 4L, false, "9998789876", 5L, "1", null, new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1996, 11, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "psubbaraman@healthwaresystems.com", "Subba", "Male", true, false, false, null, "Raman", null, "Single", null, null, "$2a$12$LtJLALh8WHtif./3.zcmFedeE.P1JhRg3NW.EoUdLqQtbodVQQlyG", "212127788", null, null },
                    { 5L, false, "9998789876", 6L, "1", null, new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1996, 11, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "jkunwar@healthwaresystems.com", "Jay", "Male", true, false, false, null, "Kunwar", null, "Single", null, null, "$2a$12$p52oxbz6AJOfMKqIdDa8u.bK17xic3xEMAIwA2Pa6bWF8qhUhSisu", "212127724", null, null },
                    { 6L, false, "9998789876", 7L, "1", null, new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1996, 11, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "sgruner@healthwaresystems.com", "Stephen", "Male", true, false, false, null, "Gruner", null, "Single", null, null, "$2a$12$1JWC.dpRqjaYuuP2NY5MTO3DvhoLDiOp605LiNh74b/Mzu5xxPvFi", "212126682", null, null }
                });

            migrationBuilder.InsertData(
                table: "UserHasRoles",
                columns: new[] { "Id", "RoleId", "UserId" },
                values: new object[,]
                {
                    { 3L, 1L, 3L },
                    { 4L, 2L, 4L },
                    { 5L, 1L, 5L },
                    { 6L, 2L, 6L }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "UserHasRoles",
                keyColumn: "Id",
                keyValue: 3L);

            migrationBuilder.DeleteData(
                table: "UserHasRoles",
                keyColumn: "Id",
                keyValue: 4L);

            migrationBuilder.DeleteData(
                table: "UserHasRoles",
                keyColumn: "Id",
                keyValue: 5L);

            migrationBuilder.DeleteData(
                table: "UserHasRoles",
                keyColumn: "Id",
                keyValue: 6L);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3L);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 4L);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 5L);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 6L);

            migrationBuilder.DeleteData(
                table: "ContactDetails",
                keyColumn: "Id",
                keyValue: 4L);

            migrationBuilder.DeleteData(
                table: "ContactDetails",
                keyColumn: "Id",
                keyValue: 5L);

            migrationBuilder.DeleteData(
                table: "ContactDetails",
                keyColumn: "Id",
                keyValue: 6L);

            migrationBuilder.DeleteData(
                table: "ContactDetails",
                keyColumn: "Id",
                keyValue: 7L);

            migrationBuilder.UpdateData(
                table: "ContactDetails",
                keyColumn: "Id",
                keyValue: 1L,
                column: "CountyCode",
                value: "-1");

            migrationBuilder.UpdateData(
                table: "ContactDetails",
                keyColumn: "Id",
                keyValue: 3L,
                column: "CountyCode",
                value: "-1");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: -1L,
                column: "Password",
                value: "$2a$12$ZvyDV2TZ3xa1BZrNBv36zu92ZmJ66qEzBOTsUKjSQnqm2w4LYKgPO");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "CountyCode", "Password", "SSNNumber" },
                values: new object[] { null, "$2a$12$bG1CSkTzMa9ZxRvuaTSehO87OuATtLlhi6XbC0JzX6eL.YRV6X1Pm", "2121288888" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2L,
                columns: new[] { "CountyCode", "Password", "SSNNumber" },
                values: new object[] { null, "$2a$12$shzWINP5YBb9NUO9hICks.HXZ1ewRSLJ1RAO1mbD/o7ysiO028ZwG", "2121277777" });
        }
    }
}
