using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace HealthWare.ActiveASSIST.Repositories.Migrations
{
    public partial class ContactDetailsTableSecondaryEmailUpdated : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "ContactDetails",
                keyColumn: "Id",
                keyValue: 3L,
                columns: new[] { "Cell", "City", "ContactTypeDetailsId", "County", "CountyCode", "Email", "Name", "State", "StateCode", "Zip" },
                values: new object[] { null, null, 10L, null, null, "naresh.k@zucisystems.com", "Naresh Kumar", null, null, null });

            migrationBuilder.UpdateData(
                table: "ContactDetails",
                keyColumn: "Id",
                keyValue: 4L,
                columns: new[] { "Email", "Name" },
                values: new object[] { "iniya.j@zucisystems.com", "Iniya J" });

            migrationBuilder.UpdateData(
                table: "ContactDetails",
                keyColumn: "Id",
                keyValue: 5L,
                columns: new[] { "Cell", "City", "ContactTypeDetailsId", "County", "CountyCode", "Email", "Name", "State", "StateCode", "Zip" },
                values: new object[] { null, null, 10L, null, null, "iniya.j@zucisystems.com", "Iniya J", null, null, null });

            migrationBuilder.UpdateData(
                table: "ContactDetails",
                keyColumn: "Id",
                keyValue: 6L,
                columns: new[] { "Email", "Name" },
                values: new object[] { "dkucherina@healthwaresystems.com", "Dimitriy Kucherina" });

            migrationBuilder.UpdateData(
                table: "ContactDetails",
                keyColumn: "Id",
                keyValue: 7L,
                columns: new[] { "Cell", "City", "ContactTypeDetailsId", "County", "CountyCode", "Email", "Name", "State", "StateCode", "Zip" },
                values: new object[] { null, null, 10L, null, null, "dkucherina@healthwaresystems.com", "Dimitriy Kucherina", null, null, null });

            migrationBuilder.UpdateData(
                table: "ContactDetails",
                keyColumn: "Id",
                keyValue: 8L,
                columns: new[] { "Email", "Name" },
                values: new object[] { "psubbaraman@healthwaresystems.com", "Subba Raman" });

            migrationBuilder.UpdateData(
                table: "ContactDetails",
                keyColumn: "Id",
                keyValue: 9L,
                columns: new[] { "Cell", "City", "ContactTypeDetailsId", "County", "CountyCode", "Email", "Name", "State", "StateCode", "Zip" },
                values: new object[] { null, null, 10L, null, null, "psubbaraman@healthwaresystems.com", "Subba Raman", null, null, null });

            migrationBuilder.InsertData(
                table: "ContactDetails",
                columns: new[] { "Id", "Cell", "City", "ContactTypeDetailsId", "County", "CountyCode", "CreatedBy", "CreatedDate", "Email", "Fax", "Name", "PhoneType", "State", "StateCode", "StreetAddress", "Suite", "UpdatedBy", "UpdatedDate", "Zip" },
                values: new object[,]
                {
                    { 10L, "3333333333", "Schenectady", 9L, "United States", "1", null, new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "sgruner@healthwaresystems.com", null, "Stephen Gruner", null, "New York", "NY", null, null, null, null, "12345" },
                    { 16L, "3333333333", "Schenectady", 9L, "United States", "1", null, new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "uma.r@zucisystems.com", null, "Uma Raja", null, "New York", "NY", null, null, null, null, "12345" },
                    { 15L, null, null, 10L, null, null, null, new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "mynthan.k@zucisystems.com", null, "Mynthan Kumar", null, null, null, null, null, null, null, null },
                    { 14L, "3333333333", "Schenectady", 9L, "United States", "1", null, new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "mynthan.k@zucisystems.com", null, "Mynthan Kumar", null, "New York", "NY", null, null, null, null, "12345" },
                    { 13L, null, null, 10L, null, null, null, new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "jkunwar@healthwaresystems.com", null, "Jay Kunwar", null, null, null, null, null, null, null, null },
                    { 12L, "3333333333", "Schenectady", 9L, "United States", "1", null, new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "jkunwar@healthwaresystems.com", null, "Jay Kunwar", null, "New York", "NY", null, null, null, null, "12345" },
                    { 11L, null, null, 10L, null, null, null, new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "sgruner@healthwaresystems.com", null, "Stephen Gruner", null, null, null, null, null, null, null, null },
                    { 17L, null, null, 10L, null, null, null, new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "uma.r@zucisystems.com", null, "Uma Raja", null, null, null, null, null, null, null, null }
                });

            migrationBuilder.UpdateData(
                table: "MainUser",
                keyColumn: "Id",
                keyValue: -1L,
                column: "Password",
                value: "$2a$12$Gycq4zhPuq7Hzi6PlmrnLeCk9FE8mACErnmA5V1ZOb4X7DmB0Bi1i");

            migrationBuilder.UpdateData(
                table: "MainUser",
                keyColumn: "Id",
                keyValue: 1L,
                column: "Password",
                value: "$2a$12$Uw6zH.f3KRjh1no59umMSOB2tfCBeUObeIh1/RmlvmIAvjrf7SWd2");

            migrationBuilder.UpdateData(
                table: "MainUser",
                keyColumn: "Id",
                keyValue: 2L,
                column: "Password",
                value: "$2a$12$Yxlq.UByq.76TEIjjgdsuOMz3dwdkp4RdOruMlSjpRErSUzatGnAG");

            migrationBuilder.UpdateData(
                table: "MainUser",
                keyColumn: "Id",
                keyValue: 3L,
                column: "Password",
                value: "$2a$12$90R58oTvw59I9G25nJPwEetvyMpnEF6vUhrzGZD3sO965e.2F7GFG");

            migrationBuilder.UpdateData(
                table: "MainUser",
                keyColumn: "Id",
                keyValue: 4L,
                column: "Password",
                value: "$2a$12$83UCWmmFeeN/Z4Wv2k7aPejkZkq94X8O72J86pktKYm6B.siBkng.");

            migrationBuilder.UpdateData(
                table: "MainUser",
                keyColumn: "Id",
                keyValue: 5L,
                column: "Password",
                value: "$2a$12$xuHhyckdUAQpWvWBKm.fQef2WxSryk7h0C.yaRiymQEpG30L8/a/K");

            migrationBuilder.UpdateData(
                table: "MainUser",
                keyColumn: "Id",
                keyValue: 6L,
                column: "Password",
                value: "$2a$12$d0Wwd3kqe7dsuszbHl8Qk.MvfQbCZZrPjKzv0L4kQmhtLk6J6gUla");

            migrationBuilder.UpdateData(
                table: "MainUser",
                keyColumn: "Id",
                keyValue: 7L,
                column: "Password",
                value: "$2a$12$9sll62li40jumd5rr9rfIu6pMDfFTZw0zNOh7t6EEIIdwDZGGjonG");

            migrationBuilder.UpdateData(
                table: "MainUser",
                keyColumn: "Id",
                keyValue: 8L,
                column: "Password",
                value: "$2a$12$2aKhWoikoBdpEiC58451I.K1bh8bowbwDYxTNtrMNdVM3UR/tRtVy");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ContactDetails",
                keyColumn: "Id",
                keyValue: 10L);

            migrationBuilder.DeleteData(
                table: "ContactDetails",
                keyColumn: "Id",
                keyValue: 11L);

            migrationBuilder.DeleteData(
                table: "ContactDetails",
                keyColumn: "Id",
                keyValue: 12L);

            migrationBuilder.DeleteData(
                table: "ContactDetails",
                keyColumn: "Id",
                keyValue: 13L);

            migrationBuilder.DeleteData(
                table: "ContactDetails",
                keyColumn: "Id",
                keyValue: 14L);

            migrationBuilder.DeleteData(
                table: "ContactDetails",
                keyColumn: "Id",
                keyValue: 15L);

            migrationBuilder.DeleteData(
                table: "ContactDetails",
                keyColumn: "Id",
                keyValue: 16L);

            migrationBuilder.DeleteData(
                table: "ContactDetails",
                keyColumn: "Id",
                keyValue: 17L);

            migrationBuilder.UpdateData(
                table: "ContactDetails",
                keyColumn: "Id",
                keyValue: 3L,
                columns: new[] { "Cell", "City", "ContactTypeDetailsId", "County", "CountyCode", "Email", "Name", "State", "StateCode", "Zip" },
                values: new object[] { "3333333333", "Schenectady", 9L, "United States", "1", "iniya.j@zucisystems.com", "Iniya J", "New York", "NY", "12345" });

            migrationBuilder.UpdateData(
                table: "ContactDetails",
                keyColumn: "Id",
                keyValue: 4L,
                columns: new[] { "Email", "Name" },
                values: new object[] { "dkucherina@healthwaresystems.com", "Dimitriy Kucherina" });

            migrationBuilder.UpdateData(
                table: "ContactDetails",
                keyColumn: "Id",
                keyValue: 5L,
                columns: new[] { "Cell", "City", "ContactTypeDetailsId", "County", "CountyCode", "Email", "Name", "State", "StateCode", "Zip" },
                values: new object[] { "3333333333", "Schenectady", 9L, "United States", "1", "psubbaraman@healthwaresystems.com", "Subba Raman", "New York", "NY", "12345" });

            migrationBuilder.UpdateData(
                table: "ContactDetails",
                keyColumn: "Id",
                keyValue: 6L,
                columns: new[] { "Email", "Name" },
                values: new object[] { "sgruner@healthwaresystems.com", "Stephen Gruner" });

            migrationBuilder.UpdateData(
                table: "ContactDetails",
                keyColumn: "Id",
                keyValue: 7L,
                columns: new[] { "Cell", "City", "ContactTypeDetailsId", "County", "CountyCode", "Email", "Name", "State", "StateCode", "Zip" },
                values: new object[] { "3333333333", "Schenectady", 9L, "United States", "1", "jkunwar@healthwaresystems.com", "Jay Kunwar", "New York", "NY", "12345" });

            migrationBuilder.UpdateData(
                table: "ContactDetails",
                keyColumn: "Id",
                keyValue: 8L,
                columns: new[] { "Email", "Name" },
                values: new object[] { "mynthan.k@zucisystems.com", "Mynthan Kumar" });

            migrationBuilder.UpdateData(
                table: "ContactDetails",
                keyColumn: "Id",
                keyValue: 9L,
                columns: new[] { "Cell", "City", "ContactTypeDetailsId", "County", "CountyCode", "Email", "Name", "State", "StateCode", "Zip" },
                values: new object[] { "3333333333", "Schenectady", 9L, "United States", "1", "uma.r@zucisystems.com", "Uma Raja", "New York", "NY", "12345" });

            migrationBuilder.UpdateData(
                table: "MainUser",
                keyColumn: "Id",
                keyValue: -1L,
                column: "Password",
                value: "$2a$12$Tt8KwJJIwVy/XEYeVhXu.Orm/08DmGmMqWlRDkzF6one7WegZWF86");

            migrationBuilder.UpdateData(
                table: "MainUser",
                keyColumn: "Id",
                keyValue: 1L,
                column: "Password",
                value: "$2a$12$OreT6TOz8X7KcLa3Gyt4.O9nPzZyHJQ51O2I70S02GGg/wwAcvXBq");

            migrationBuilder.UpdateData(
                table: "MainUser",
                keyColumn: "Id",
                keyValue: 2L,
                column: "Password",
                value: "$2a$12$WJxf9vCeM6uJwAsd3ME3GuLKuOM10pSpGhegq3VNO4vUw90DrLJ6.");

            migrationBuilder.UpdateData(
                table: "MainUser",
                keyColumn: "Id",
                keyValue: 3L,
                column: "Password",
                value: "$2a$12$dv3ca1bcaWJNS1m5AvpN6e0ceJ/DUiHzDdwujBEgLBXYPNmgNpW4G");

            migrationBuilder.UpdateData(
                table: "MainUser",
                keyColumn: "Id",
                keyValue: 4L,
                column: "Password",
                value: "$2a$12$aeq7miWg3pXlzBXpIeM1t.ajLze6fzmW2kDayk8phYM0XtfQz7FkK");

            migrationBuilder.UpdateData(
                table: "MainUser",
                keyColumn: "Id",
                keyValue: 5L,
                column: "Password",
                value: "$2a$12$Xe/gseSIfer5OS9tXtv85eGk0wJbJHXqqC/WAczvNtxenImEZuND6");

            migrationBuilder.UpdateData(
                table: "MainUser",
                keyColumn: "Id",
                keyValue: 6L,
                column: "Password",
                value: "$2a$12$r9Fy9i/fXBjFO1hGJnqjze3pASV1UzwOP1c1cNYQ4mYc2DImN9byC");

            migrationBuilder.UpdateData(
                table: "MainUser",
                keyColumn: "Id",
                keyValue: 7L,
                column: "Password",
                value: "$2a$12$aisA6K9ILrGP4JHOV.Sw6OyiKI..VVbvVO2AMxt2lK48HJwaoIcQ.");

            migrationBuilder.UpdateData(
                table: "MainUser",
                keyColumn: "Id",
                keyValue: 8L,
                column: "Password",
                value: "$2a$12$Pkeyt9rfwm6.DGyT5X5cEu0mrsLmrTLXf9.9gQsak5Yjs3bNhs62S");
        }
    }
}
