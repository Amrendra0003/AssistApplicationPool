using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace HealthWare.ActiveASSIST.Repositories.Migrations
{
    public partial class SecondaryEmailTypeAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "ContactTypeMaster",
                columns: new[] { "Id", "ContactType", "CreatedBy", "CreatedDate", "EntityType", "UpdatedBy", "UpdatedDate" },
                values: new object[] { 10L, "SecondaryEmail", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "User Profile", null, null });

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ContactTypeMaster",
                keyColumn: "Id",
                keyValue: 10L);

            migrationBuilder.UpdateData(
                table: "MainUser",
                keyColumn: "Id",
                keyValue: -1L,
                column: "Password",
                value: "$2a$12$1iiAG9h33ups/tes/sj22.wEA02rT1MZWBjHhXYqRXhi5kbwuezmm");

            migrationBuilder.UpdateData(
                table: "MainUser",
                keyColumn: "Id",
                keyValue: 1L,
                column: "Password",
                value: "$2a$12$B3GEhm12I4sa7zhiSNyS8..snFYu1/VKhHxW0UWtKqr2KkJ.0NrQG");

            migrationBuilder.UpdateData(
                table: "MainUser",
                keyColumn: "Id",
                keyValue: 2L,
                column: "Password",
                value: "$2a$12$yF6x7LB1HRXxjWIR/FaWKuUn0crHTnqS8uwK/Uf4CW.6cQ5umW/K2");

            migrationBuilder.UpdateData(
                table: "MainUser",
                keyColumn: "Id",
                keyValue: 3L,
                column: "Password",
                value: "$2a$12$ri2Legap75Y94GAcTQsWSejKEgZaXOWcaK2QkTaobZBDxGB5TqXZa");

            migrationBuilder.UpdateData(
                table: "MainUser",
                keyColumn: "Id",
                keyValue: 4L,
                column: "Password",
                value: "$2a$12$4bk9B3R6cW9qythwP7SC2ushQhUqPRGPg3W68e/BQNe60uew7Uii2");

            migrationBuilder.UpdateData(
                table: "MainUser",
                keyColumn: "Id",
                keyValue: 5L,
                column: "Password",
                value: "$2a$12$PF6HMYLN.97V7gpZdGSSa.owi277mEn8atdLC7ha3R0OMKFN.RH92");

            migrationBuilder.UpdateData(
                table: "MainUser",
                keyColumn: "Id",
                keyValue: 6L,
                column: "Password",
                value: "$2a$12$tKC6fx.uv/EbFXWJAIyPv.jJv7Siylv67Ur5riyKOR2lPIAruHW0y");

            migrationBuilder.UpdateData(
                table: "MainUser",
                keyColumn: "Id",
                keyValue: 7L,
                column: "Password",
                value: "$2a$12$.IHScIswQ.98Bot0.3NxkektBt5givSXlDUoiAlVk8BdnMn6oVnZO");

            migrationBuilder.UpdateData(
                table: "MainUser",
                keyColumn: "Id",
                keyValue: 8L,
                column: "Password",
                value: "$2a$12$zUpQozuiyE00uNNwS9Kvq.p40qgEeQUg3hfcdT9mKqL.w41NNQ3be");
        }
    }
}
