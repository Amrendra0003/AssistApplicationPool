using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace HealthWare.ActiveASSIST.Repositories.Migrations
{
    public partial class UserContactDetailsChangeAndDynamicScreenMaxMinValidators : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "City",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "County",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "MailingAddressCell",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "MailingAddressCountyCode",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "State",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "StreetAddress",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "Suite",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "ZipCode",
                table: "Users");

            migrationBuilder.AddColumn<int>(
                name: "Max",
                table: "Validators",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Min",
                table: "Validators",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "ContactDetailsId",
                table: "Users",
                type: "bigint",
                nullable: true);

            migrationBuilder.InsertData(
                table: "ContactDetails",
                columns: new[] { "Id", "Cell", "City", "ContactTypeDetailsId", "County", "CountyCode", "CreatedBy", "CreatedDate", "Email", "Fax", "Name", "PhoneType", "State", "StateCode", "StreetAddress", "Suite", "UpdatedBy", "UpdatedDate", "Zip" },
                values: new object[,]
                {
                    { 1L, "1111111111", null, 9L, null, "-1", null, new DateTime(2021, 12, 26, 20, 7, 43, 288, DateTimeKind.Utc).AddTicks(1721), "dummy", null, "Dummy", null, null, null, null, null, null, null, null },
                    { 2L, "2222222222", null, 9L, null, "1", null, new DateTime(2021, 12, 26, 20, 7, 43, 288, DateTimeKind.Utc).AddTicks(2868), "naresh.k@zucisystems.com", null, "Naresh Kumar", null, null, null, null, null, null, null, null },
                    { 3L, "3333333333", null, 9L, null, "-1", null, new DateTime(2021, 12, 26, 20, 7, 43, 288, DateTimeKind.Utc).AddTicks(3678), "iniya.j@zucisystems.com", null, "Iniya J", null, null, null, null, null, null, null, null }
                });

            migrationBuilder.UpdateData(
                table: "ContactTypeMaster",
                keyColumn: "Id",
                keyValue: 7L,
                columns: new[] { "ContactType", "EntityType" },
                values: new object[] { "Work", "HouseHoldMember" });

            migrationBuilder.UpdateData(
                table: "ContactTypeMaster",
                keyColumn: "Id",
                keyValue: 9L,
                column: "ContactType",
                value: "Home");

            migrationBuilder.UpdateData(
                table: "DynamicScreens",
                keyColumn: "Id",
                keyValue: 1L,
                column: "CreatedDate",
                value: new DateTime(2021, 12, 26, 20, 7, 44, 264, DateTimeKind.Utc).AddTicks(1943));

            migrationBuilder.UpdateData(
                table: "DynamicScreens",
                keyColumn: "Id",
                keyValue: 2L,
                column: "CreatedDate",
                value: new DateTime(2021, 12, 26, 20, 7, 44, 264, DateTimeKind.Utc).AddTicks(2522));

            migrationBuilder.UpdateData(
                table: "DynamicScreens",
                keyColumn: "Id",
                keyValue: 3L,
                column: "CreatedDate",
                value: new DateTime(2021, 12, 26, 20, 7, 44, 264, DateTimeKind.Utc).AddTicks(2535));

            migrationBuilder.UpdateData(
                table: "DynamicScreens",
                keyColumn: "Id",
                keyValue: 4L,
                column: "CreatedDate",
                value: new DateTime(2021, 12, 26, 20, 7, 44, 264, DateTimeKind.Utc).AddTicks(2537));

            migrationBuilder.UpdateData(
                table: "DynamicScreens",
                keyColumn: "Id",
                keyValue: 5L,
                column: "CreatedDate",
                value: new DateTime(2021, 12, 26, 20, 7, 44, 264, DateTimeKind.Utc).AddTicks(2538));

            migrationBuilder.UpdateData(
                table: "DynamicScreens",
                keyColumn: "Id",
                keyValue: 6L,
                column: "CreatedDate",
                value: new DateTime(2021, 12, 26, 20, 7, 44, 264, DateTimeKind.Utc).AddTicks(2541));

            migrationBuilder.UpdateData(
                table: "DynamicScreens",
                keyColumn: "Id",
                keyValue: 7L,
                column: "CreatedDate",
                value: new DateTime(2021, 12, 26, 20, 7, 44, 264, DateTimeKind.Utc).AddTicks(2542));

            migrationBuilder.UpdateData(
                table: "DynamicScreens",
                keyColumn: "Id",
                keyValue: 8L,
                column: "CreatedDate",
                value: new DateTime(2021, 12, 26, 20, 7, 44, 264, DateTimeKind.Utc).AddTicks(2544));

            migrationBuilder.UpdateData(
                table: "DynamicScreens",
                keyColumn: "Id",
                keyValue: 9L,
                column: "CreatedDate",
                value: new DateTime(2021, 12, 26, 20, 7, 44, 264, DateTimeKind.Utc).AddTicks(2545));

            migrationBuilder.UpdateData(
                table: "DynamicScreens",
                keyColumn: "Id",
                keyValue: 10L,
                column: "CreatedDate",
                value: new DateTime(2021, 12, 26, 20, 7, 44, 264, DateTimeKind.Utc).AddTicks(2547));

            migrationBuilder.UpdateData(
                table: "DynamicScreens",
                keyColumn: "Id",
                keyValue: 11L,
                column: "CreatedDate",
                value: new DateTime(2021, 12, 26, 20, 7, 44, 264, DateTimeKind.Utc).AddTicks(2548));

            migrationBuilder.UpdateData(
                table: "Options",
                keyColumn: "Id",
                keyValue: 1L,
                column: "CreatedDate",
                value: new DateTime(2021, 12, 26, 20, 7, 44, 267, DateTimeKind.Utc).AddTicks(8780));

            migrationBuilder.UpdateData(
                table: "Options",
                keyColumn: "Id",
                keyValue: 2L,
                column: "CreatedDate",
                value: new DateTime(2021, 12, 26, 20, 7, 44, 267, DateTimeKind.Utc).AddTicks(9729));

            migrationBuilder.UpdateData(
                table: "Options",
                keyColumn: "Id",
                keyValue: 3L,
                column: "CreatedDate",
                value: new DateTime(2021, 12, 26, 20, 7, 44, 267, DateTimeKind.Utc).AddTicks(9748));

            migrationBuilder.UpdateData(
                table: "Options",
                keyColumn: "Id",
                keyValue: 4L,
                column: "CreatedDate",
                value: new DateTime(2021, 12, 26, 20, 7, 44, 267, DateTimeKind.Utc).AddTicks(9749));

            migrationBuilder.UpdateData(
                table: "Options",
                keyColumn: "Id",
                keyValue: 5L,
                column: "CreatedDate",
                value: new DateTime(2021, 12, 26, 20, 7, 44, 267, DateTimeKind.Utc).AddTicks(9751));

            migrationBuilder.UpdateData(
                table: "Options",
                keyColumn: "Id",
                keyValue: 6L,
                column: "CreatedDate",
                value: new DateTime(2021, 12, 26, 20, 7, 44, 267, DateTimeKind.Utc).AddTicks(9752));

            migrationBuilder.UpdateData(
                table: "Options",
                keyColumn: "Id",
                keyValue: 7L,
                column: "CreatedDate",
                value: new DateTime(2021, 12, 26, 20, 7, 44, 267, DateTimeKind.Utc).AddTicks(9755));

            migrationBuilder.UpdateData(
                table: "Options",
                keyColumn: "Id",
                keyValue: 8L,
                column: "CreatedDate",
                value: new DateTime(2021, 12, 26, 20, 7, 44, 267, DateTimeKind.Utc).AddTicks(9757));

            migrationBuilder.UpdateData(
                table: "Options",
                keyColumn: "Id",
                keyValue: 9L,
                column: "CreatedDate",
                value: new DateTime(2021, 12, 26, 20, 7, 44, 267, DateTimeKind.Utc).AddTicks(9760));

            migrationBuilder.UpdateData(
                table: "Options",
                keyColumn: "Id",
                keyValue: 10L,
                column: "CreatedDate",
                value: new DateTime(2021, 12, 26, 20, 7, 44, 267, DateTimeKind.Utc).AddTicks(9763));

            migrationBuilder.UpdateData(
                table: "Options",
                keyColumn: "Id",
                keyValue: 11L,
                column: "CreatedDate",
                value: new DateTime(2021, 12, 26, 20, 7, 44, 267, DateTimeKind.Utc).AddTicks(9765));

            migrationBuilder.UpdateData(
                table: "Options",
                keyColumn: "Id",
                keyValue: 12L,
                column: "CreatedDate",
                value: new DateTime(2021, 12, 26, 20, 7, 44, 267, DateTimeKind.Utc).AddTicks(9767));

            migrationBuilder.UpdateData(
                table: "Options",
                keyColumn: "Id",
                keyValue: 13L,
                column: "CreatedDate",
                value: new DateTime(2021, 12, 26, 20, 7, 44, 267, DateTimeKind.Utc).AddTicks(9768));

            migrationBuilder.UpdateData(
                table: "Options",
                keyColumn: "Id",
                keyValue: 14L,
                column: "CreatedDate",
                value: new DateTime(2021, 12, 26, 20, 7, 44, 267, DateTimeKind.Utc).AddTicks(9769));

            migrationBuilder.UpdateData(
                table: "Options",
                keyColumn: "Id",
                keyValue: 15L,
                column: "CreatedDate",
                value: new DateTime(2021, 12, 26, 20, 7, 44, 267, DateTimeKind.Utc).AddTicks(9771));

            migrationBuilder.UpdateData(
                table: "Options",
                keyColumn: "Id",
                keyValue: 16L,
                column: "CreatedDate",
                value: new DateTime(2021, 12, 26, 20, 7, 44, 267, DateTimeKind.Utc).AddTicks(9772));

            migrationBuilder.UpdateData(
                table: "Options",
                keyColumn: "Id",
                keyValue: 17L,
                column: "CreatedDate",
                value: new DateTime(2021, 12, 26, 20, 7, 44, 267, DateTimeKind.Utc).AddTicks(9773));

            migrationBuilder.UpdateData(
                table: "Options",
                keyColumn: "Id",
                keyValue: 18L,
                column: "CreatedDate",
                value: new DateTime(2021, 12, 26, 20, 7, 44, 267, DateTimeKind.Utc).AddTicks(9774));

            migrationBuilder.UpdateData(
                table: "Options",
                keyColumn: "Id",
                keyValue: 19L,
                column: "CreatedDate",
                value: new DateTime(2021, 12, 26, 20, 7, 44, 267, DateTimeKind.Utc).AddTicks(9776));

            migrationBuilder.UpdateData(
                table: "Options",
                keyColumn: "Id",
                keyValue: 20L,
                column: "CreatedDate",
                value: new DateTime(2021, 12, 26, 20, 7, 44, 267, DateTimeKind.Utc).AddTicks(9777));

            migrationBuilder.UpdateData(
                table: "Options",
                keyColumn: "Id",
                keyValue: 21L,
                column: "CreatedDate",
                value: new DateTime(2021, 12, 26, 20, 7, 44, 267, DateTimeKind.Utc).AddTicks(9778));

            migrationBuilder.UpdateData(
                table: "Options",
                keyColumn: "Id",
                keyValue: 22L,
                column: "CreatedDate",
                value: new DateTime(2021, 12, 26, 20, 7, 44, 267, DateTimeKind.Utc).AddTicks(9779));

            migrationBuilder.UpdateData(
                table: "Options",
                keyColumn: "Id",
                keyValue: 23L,
                column: "CreatedDate",
                value: new DateTime(2021, 12, 26, 20, 7, 44, 267, DateTimeKind.Utc).AddTicks(9781));

            migrationBuilder.UpdateData(
                table: "Options",
                keyColumn: "Id",
                keyValue: 24L,
                column: "CreatedDate",
                value: new DateTime(2021, 12, 26, 20, 7, 44, 267, DateTimeKind.Utc).AddTicks(9782));

            migrationBuilder.UpdateData(
                table: "Options",
                keyColumn: "Id",
                keyValue: 25L,
                column: "CreatedDate",
                value: new DateTime(2021, 12, 26, 20, 7, 44, 267, DateTimeKind.Utc).AddTicks(9783));

            migrationBuilder.UpdateData(
                table: "Options",
                keyColumn: "Id",
                keyValue: 26L,
                column: "CreatedDate",
                value: new DateTime(2021, 12, 26, 20, 7, 44, 267, DateTimeKind.Utc).AddTicks(9784));

            migrationBuilder.UpdateData(
                table: "Options",
                keyColumn: "Id",
                keyValue: 27L,
                column: "CreatedDate",
                value: new DateTime(2021, 12, 26, 20, 7, 44, 267, DateTimeKind.Utc).AddTicks(9786));

            migrationBuilder.UpdateData(
                table: "Options",
                keyColumn: "Id",
                keyValue: 28L,
                column: "CreatedDate",
                value: new DateTime(2021, 12, 26, 20, 7, 44, 267, DateTimeKind.Utc).AddTicks(9788));

            migrationBuilder.UpdateData(
                table: "Options",
                keyColumn: "Id",
                keyValue: 29L,
                column: "CreatedDate",
                value: new DateTime(2021, 12, 26, 20, 7, 44, 267, DateTimeKind.Utc).AddTicks(9789));

            migrationBuilder.UpdateData(
                table: "Options",
                keyColumn: "Id",
                keyValue: 30L,
                column: "CreatedDate",
                value: new DateTime(2021, 12, 26, 20, 7, 44, 267, DateTimeKind.Utc).AddTicks(9791));

            migrationBuilder.UpdateData(
                table: "Options",
                keyColumn: "Id",
                keyValue: 31L,
                column: "CreatedDate",
                value: new DateTime(2021, 12, 26, 20, 7, 44, 267, DateTimeKind.Utc).AddTicks(9792));

            migrationBuilder.UpdateData(
                table: "Options",
                keyColumn: "Id",
                keyValue: 32L,
                column: "CreatedDate",
                value: new DateTime(2021, 12, 26, 20, 7, 44, 267, DateTimeKind.Utc).AddTicks(9794));

            migrationBuilder.UpdateData(
                table: "Options",
                keyColumn: "Id",
                keyValue: 33L,
                column: "CreatedDate",
                value: new DateTime(2021, 12, 26, 20, 7, 44, 267, DateTimeKind.Utc).AddTicks(9795));

            migrationBuilder.UpdateData(
                table: "Options",
                keyColumn: "Id",
                keyValue: 34L,
                column: "CreatedDate",
                value: new DateTime(2021, 12, 26, 20, 7, 44, 267, DateTimeKind.Utc).AddTicks(9797));

            migrationBuilder.UpdateData(
                table: "Options",
                keyColumn: "Id",
                keyValue: 35L,
                column: "CreatedDate",
                value: new DateTime(2021, 12, 26, 20, 7, 44, 267, DateTimeKind.Utc).AddTicks(9798));

            migrationBuilder.UpdateData(
                table: "Options",
                keyColumn: "Id",
                keyValue: 36L,
                column: "CreatedDate",
                value: new DateTime(2021, 12, 26, 20, 7, 44, 267, DateTimeKind.Utc).AddTicks(9799));

            migrationBuilder.UpdateData(
                table: "Options",
                keyColumn: "Id",
                keyValue: 37L,
                column: "CreatedDate",
                value: new DateTime(2021, 12, 26, 20, 7, 44, 267, DateTimeKind.Utc).AddTicks(9801));

            migrationBuilder.UpdateData(
                table: "Options",
                keyColumn: "Id",
                keyValue: 38L,
                column: "CreatedDate",
                value: new DateTime(2021, 12, 26, 20, 7, 44, 267, DateTimeKind.Utc).AddTicks(9802));

            migrationBuilder.UpdateData(
                table: "Options",
                keyColumn: "Id",
                keyValue: 39L,
                column: "CreatedDate",
                value: new DateTime(2021, 12, 26, 20, 7, 44, 267, DateTimeKind.Utc).AddTicks(9803));

            migrationBuilder.UpdateData(
                table: "Options",
                keyColumn: "Id",
                keyValue: 40L,
                column: "CreatedDate",
                value: new DateTime(2021, 12, 26, 20, 7, 44, 267, DateTimeKind.Utc).AddTicks(9804));

            migrationBuilder.UpdateData(
                table: "Options",
                keyColumn: "Id",
                keyValue: 41L,
                column: "CreatedDate",
                value: new DateTime(2021, 12, 26, 20, 7, 44, 267, DateTimeKind.Utc).AddTicks(9805));

            migrationBuilder.UpdateData(
                table: "Options",
                keyColumn: "Id",
                keyValue: 42L,
                column: "CreatedDate",
                value: new DateTime(2021, 12, 26, 20, 7, 44, 267, DateTimeKind.Utc).AddTicks(9806));

            migrationBuilder.UpdateData(
                table: "Options",
                keyColumn: "Id",
                keyValue: 43L,
                column: "CreatedDate",
                value: new DateTime(2021, 12, 26, 20, 7, 44, 267, DateTimeKind.Utc).AddTicks(9807));

            migrationBuilder.UpdateData(
                table: "Options",
                keyColumn: "Id",
                keyValue: 44L,
                column: "CreatedDate",
                value: new DateTime(2021, 12, 26, 20, 7, 44, 268, DateTimeKind.Utc).AddTicks(472));

            migrationBuilder.UpdateData(
                table: "Options",
                keyColumn: "Id",
                keyValue: 45L,
                column: "CreatedDate",
                value: new DateTime(2021, 12, 26, 20, 7, 44, 268, DateTimeKind.Utc).AddTicks(489));

            migrationBuilder.UpdateData(
                table: "Program",
                keyColumn: "Id",
                keyValue: 1L,
                column: "CreatedDate",
                value: new DateTime(2021, 12, 26, 20, 7, 44, 269, DateTimeKind.Utc).AddTicks(7349));

            migrationBuilder.UpdateData(
                table: "Program",
                keyColumn: "Id",
                keyValue: 2L,
                column: "CreatedDate",
                value: new DateTime(2021, 12, 26, 20, 7, 44, 269, DateTimeKind.Utc).AddTicks(7393));

            migrationBuilder.UpdateData(
                table: "Program",
                keyColumn: "Id",
                keyValue: 3L,
                column: "CreatedDate",
                value: new DateTime(2021, 12, 26, 20, 7, 44, 269, DateTimeKind.Utc).AddTicks(7396));

            migrationBuilder.UpdateData(
                table: "Program",
                keyColumn: "Id",
                keyValue: 4L,
                column: "CreatedDate",
                value: new DateTime(2021, 12, 26, 20, 7, 44, 269, DateTimeKind.Utc).AddTicks(7397));

            migrationBuilder.UpdateData(
                table: "Program",
                keyColumn: "Id",
                keyValue: 5L,
                column: "CreatedDate",
                value: new DateTime(2021, 12, 26, 20, 7, 44, 269, DateTimeKind.Utc).AddTicks(7398));

            migrationBuilder.UpdateData(
                table: "Program",
                keyColumn: "Id",
                keyValue: 6L,
                column: "CreatedDate",
                value: new DateTime(2021, 12, 26, 20, 7, 44, 269, DateTimeKind.Utc).AddTicks(7400));

            migrationBuilder.UpdateData(
                table: "ProgramDocument",
                keyColumn: "Id",
                keyValue: 1L,
                column: "CreatedDate",
                value: new DateTime(2021, 12, 26, 20, 7, 44, 269, DateTimeKind.Utc).AddTicks(7611));

            migrationBuilder.UpdateData(
                table: "ProgramDocument",
                keyColumn: "Id",
                keyValue: 2L,
                column: "CreatedDate",
                value: new DateTime(2021, 12, 26, 20, 7, 44, 269, DateTimeKind.Utc).AddTicks(8378));

            migrationBuilder.UpdateData(
                table: "ProgramDocument",
                keyColumn: "Id",
                keyValue: 3L,
                column: "CreatedDate",
                value: new DateTime(2021, 12, 26, 20, 7, 44, 269, DateTimeKind.Utc).AddTicks(8394));

            migrationBuilder.UpdateData(
                table: "ProgramDocument",
                keyColumn: "Id",
                keyValue: 4L,
                column: "CreatedDate",
                value: new DateTime(2021, 12, 26, 20, 7, 44, 269, DateTimeKind.Utc).AddTicks(8396));

            migrationBuilder.UpdateData(
                table: "ProgramDocument",
                keyColumn: "Id",
                keyValue: 5L,
                column: "CreatedDate",
                value: new DateTime(2021, 12, 26, 20, 7, 44, 269, DateTimeKind.Utc).AddTicks(8398));

            migrationBuilder.UpdateData(
                table: "ProgramDocument",
                keyColumn: "Id",
                keyValue: 6L,
                column: "CreatedDate",
                value: new DateTime(2021, 12, 26, 20, 7, 44, 269, DateTimeKind.Utc).AddTicks(8399));

            migrationBuilder.UpdateData(
                table: "ProgramDocument",
                keyColumn: "Id",
                keyValue: 7L,
                column: "CreatedDate",
                value: new DateTime(2021, 12, 26, 20, 7, 44, 269, DateTimeKind.Utc).AddTicks(8400));

            migrationBuilder.UpdateData(
                table: "QuickAssessmentQuestions",
                keyColumn: "Id",
                keyValue: 1L,
                column: "CreatedDate",
                value: new DateTime(2021, 12, 26, 20, 7, 44, 264, DateTimeKind.Utc).AddTicks(2750));

            migrationBuilder.UpdateData(
                table: "QuickAssessmentQuestions",
                keyColumn: "Id",
                keyValue: 2L,
                column: "CreatedDate",
                value: new DateTime(2021, 12, 26, 20, 7, 44, 264, DateTimeKind.Utc).AddTicks(4213));

            migrationBuilder.UpdateData(
                table: "QuickAssessmentQuestions",
                keyColumn: "Id",
                keyValue: 3L,
                column: "CreatedDate",
                value: new DateTime(2021, 12, 26, 20, 7, 44, 264, DateTimeKind.Utc).AddTicks(5677));

            migrationBuilder.UpdateData(
                table: "QuickAssessmentQuestions",
                keyColumn: "Id",
                keyValue: 4L,
                column: "CreatedDate",
                value: new DateTime(2021, 12, 26, 20, 7, 44, 264, DateTimeKind.Utc).AddTicks(7046));

            migrationBuilder.UpdateData(
                table: "QuickAssessmentQuestions",
                keyColumn: "Id",
                keyValue: 5L,
                column: "CreatedDate",
                value: new DateTime(2021, 12, 26, 20, 7, 44, 264, DateTimeKind.Utc).AddTicks(7063));

            migrationBuilder.UpdateData(
                table: "QuickAssessmentQuestions",
                keyColumn: "Id",
                keyValue: 6L,
                column: "CreatedDate",
                value: new DateTime(2021, 12, 26, 20, 7, 44, 264, DateTimeKind.Utc).AddTicks(8622));

            migrationBuilder.UpdateData(
                table: "QuickAssessmentQuestions",
                keyColumn: "Id",
                keyValue: 7L,
                column: "CreatedDate",
                value: new DateTime(2021, 12, 26, 20, 7, 44, 265, DateTimeKind.Utc).AddTicks(253));

            migrationBuilder.UpdateData(
                table: "QuickAssessmentQuestions",
                keyColumn: "Id",
                keyValue: 8L,
                column: "CreatedDate",
                value: new DateTime(2021, 12, 26, 20, 7, 44, 265, DateTimeKind.Utc).AddTicks(257));

            migrationBuilder.UpdateData(
                table: "QuickAssessmentQuestions",
                keyColumn: "Id",
                keyValue: 9L,
                column: "CreatedDate",
                value: new DateTime(2021, 12, 26, 20, 7, 44, 265, DateTimeKind.Utc).AddTicks(1497));

            migrationBuilder.UpdateData(
                table: "QuickAssessmentQuestions",
                keyColumn: "Id",
                keyValue: 10L,
                column: "CreatedDate",
                value: new DateTime(2021, 12, 26, 20, 7, 44, 265, DateTimeKind.Utc).AddTicks(1502));

            migrationBuilder.UpdateData(
                table: "QuickAssessmentQuestions",
                keyColumn: "Id",
                keyValue: 11L,
                column: "CreatedDate",
                value: new DateTime(2021, 12, 26, 20, 7, 44, 265, DateTimeKind.Utc).AddTicks(1503));

            migrationBuilder.UpdateData(
                table: "QuickAssessmentQuestions",
                keyColumn: "Id",
                keyValue: 12L,
                column: "CreatedDate",
                value: new DateTime(2021, 12, 26, 20, 7, 44, 265, DateTimeKind.Utc).AddTicks(2723));

            migrationBuilder.UpdateData(
                table: "QuickAssessmentQuestions",
                keyColumn: "Id",
                keyValue: 13L,
                column: "CreatedDate",
                value: new DateTime(2021, 12, 26, 20, 7, 44, 265, DateTimeKind.Utc).AddTicks(2741));

            migrationBuilder.UpdateData(
                table: "QuickAssessmentQuestions",
                keyColumn: "Id",
                keyValue: 14L,
                column: "CreatedDate",
                value: new DateTime(2021, 12, 26, 20, 7, 44, 265, DateTimeKind.Utc).AddTicks(4616));

            migrationBuilder.UpdateData(
                table: "QuickAssessmentQuestions",
                keyColumn: "Id",
                keyValue: 15L,
                column: "CreatedDate",
                value: new DateTime(2021, 12, 26, 20, 7, 44, 265, DateTimeKind.Utc).AddTicks(5907));

            migrationBuilder.UpdateData(
                table: "QuickAssessmentQuestions",
                keyColumn: "Id",
                keyValue: 16L,
                column: "CreatedDate",
                value: new DateTime(2021, 12, 26, 20, 7, 44, 265, DateTimeKind.Utc).AddTicks(7062));

            migrationBuilder.UpdateData(
                table: "QuickAssessmentQuestions",
                keyColumn: "Id",
                keyValue: 17L,
                column: "CreatedDate",
                value: new DateTime(2021, 12, 26, 20, 7, 44, 265, DateTimeKind.Utc).AddTicks(8186));

            migrationBuilder.UpdateData(
                table: "QuickAssessmentQuestions",
                keyColumn: "Id",
                keyValue: 18L,
                column: "CreatedDate",
                value: new DateTime(2021, 12, 26, 20, 7, 44, 265, DateTimeKind.Utc).AddTicks(9633));

            migrationBuilder.UpdateData(
                table: "QuickAssessmentQuestions",
                keyColumn: "Id",
                keyValue: 19L,
                column: "CreatedDate",
                value: new DateTime(2021, 12, 26, 20, 7, 44, 265, DateTimeKind.Utc).AddTicks(9652));

            migrationBuilder.UpdateData(
                table: "QuickAssessmentQuestions",
                keyColumn: "Id",
                keyValue: 20L,
                column: "CreatedDate",
                value: new DateTime(2021, 12, 26, 20, 7, 44, 265, DateTimeKind.Utc).AddTicks(9654));

            migrationBuilder.UpdateData(
                table: "QuickAssessmentQuestions",
                keyColumn: "Id",
                keyValue: 21L,
                column: "CreatedDate",
                value: new DateTime(2021, 12, 26, 20, 7, 44, 266, DateTimeKind.Utc).AddTicks(1161));

            migrationBuilder.UpdateData(
                table: "QuickAssessmentQuestions",
                keyColumn: "Id",
                keyValue: 22L,
                column: "CreatedDate",
                value: new DateTime(2021, 12, 26, 20, 7, 44, 266, DateTimeKind.Utc).AddTicks(2486));

            migrationBuilder.UpdateData(
                table: "QuickAssessmentQuestions",
                keyColumn: "Id",
                keyValue: 23L,
                column: "CreatedDate",
                value: new DateTime(2021, 12, 26, 20, 7, 44, 266, DateTimeKind.Utc).AddTicks(3761));

            migrationBuilder.UpdateData(
                table: "QuickAssessmentQuestions",
                keyColumn: "Id",
                keyValue: 24L,
                column: "CreatedDate",
                value: new DateTime(2021, 12, 26, 20, 7, 44, 266, DateTimeKind.Utc).AddTicks(4913));

            migrationBuilder.UpdateData(
                table: "QuickAssessmentQuestions",
                keyColumn: "Id",
                keyValue: 25L,
                column: "CreatedDate",
                value: new DateTime(2021, 12, 26, 20, 7, 44, 266, DateTimeKind.Utc).AddTicks(6121));

            migrationBuilder.UpdateData(
                table: "QuickAssessmentQuestions",
                keyColumn: "Id",
                keyValue: 26L,
                column: "CreatedDate",
                value: new DateTime(2021, 12, 26, 20, 7, 44, 266, DateTimeKind.Utc).AddTicks(7546));

            migrationBuilder.UpdateData(
                table: "QuickAssessmentQuestions",
                keyColumn: "Id",
                keyValue: 27L,
                column: "CreatedDate",
                value: new DateTime(2021, 12, 26, 20, 7, 44, 266, DateTimeKind.Utc).AddTicks(8790));

            migrationBuilder.UpdateData(
                table: "QuickAssessmentQuestions",
                keyColumn: "Id",
                keyValue: 28L,
                column: "CreatedDate",
                value: new DateTime(2021, 12, 26, 20, 7, 44, 267, DateTimeKind.Utc).AddTicks(417));

            migrationBuilder.UpdateData(
                table: "QuickAssessmentQuestions",
                keyColumn: "Id",
                keyValue: 29L,
                column: "CreatedDate",
                value: new DateTime(2021, 12, 26, 20, 7, 44, 267, DateTimeKind.Utc).AddTicks(3140));

            migrationBuilder.UpdateData(
                table: "QuickAssessmentQuestions",
                keyColumn: "Id",
                keyValue: 30L,
                column: "CreatedDate",
                value: new DateTime(2021, 12, 26, 20, 7, 44, 267, DateTimeKind.Utc).AddTicks(4483));

            migrationBuilder.UpdateData(
                table: "QuickAssessmentQuestions",
                keyColumn: "Id",
                keyValue: 31L,
                column: "CreatedDate",
                value: new DateTime(2021, 12, 26, 20, 7, 44, 267, DateTimeKind.Utc).AddTicks(4503));

            migrationBuilder.UpdateData(
                table: "QuickAssessmentQuestions",
                keyColumn: "Id",
                keyValue: 32L,
                column: "CreatedDate",
                value: new DateTime(2021, 12, 26, 20, 7, 44, 267, DateTimeKind.Utc).AddTicks(5991));

            migrationBuilder.UpdateData(
                table: "QuickAssessmentQuestions",
                keyColumn: "Id",
                keyValue: 33L,
                column: "CreatedDate",
                value: new DateTime(2021, 12, 26, 20, 7, 44, 267, DateTimeKind.Utc).AddTicks(7375));

            migrationBuilder.UpdateData(
                table: "Validators",
                keyColumn: "Id",
                keyValue: 1L,
                column: "CreatedDate",
                value: new DateTime(2021, 12, 26, 20, 7, 44, 268, DateTimeKind.Utc).AddTicks(655));

            migrationBuilder.UpdateData(
                table: "Validators",
                keyColumn: "Id",
                keyValue: 2L,
                column: "CreatedDate",
                value: new DateTime(2021, 12, 26, 20, 7, 44, 268, DateTimeKind.Utc).AddTicks(1384));

            migrationBuilder.UpdateData(
                table: "Validators",
                keyColumn: "Id",
                keyValue: 3L,
                column: "CreatedDate",
                value: new DateTime(2021, 12, 26, 20, 7, 44, 268, DateTimeKind.Utc).AddTicks(2160));

            migrationBuilder.UpdateData(
                table: "Validators",
                keyColumn: "Id",
                keyValue: 4L,
                column: "CreatedDate",
                value: new DateTime(2021, 12, 26, 20, 7, 44, 268, DateTimeKind.Utc).AddTicks(2178));

            migrationBuilder.UpdateData(
                table: "Validators",
                keyColumn: "Id",
                keyValue: 5L,
                column: "CreatedDate",
                value: new DateTime(2021, 12, 26, 20, 7, 44, 268, DateTimeKind.Utc).AddTicks(2179));

            migrationBuilder.UpdateData(
                table: "Validators",
                keyColumn: "Id",
                keyValue: 6L,
                column: "CreatedDate",
                value: new DateTime(2021, 12, 26, 20, 7, 44, 268, DateTimeKind.Utc).AddTicks(2187));

            migrationBuilder.UpdateData(
                table: "Validators",
                keyColumn: "Id",
                keyValue: 7L,
                column: "CreatedDate",
                value: new DateTime(2021, 12, 26, 20, 7, 44, 268, DateTimeKind.Utc).AddTicks(2188));

            migrationBuilder.UpdateData(
                table: "Validators",
                keyColumn: "Id",
                keyValue: 8L,
                column: "CreatedDate",
                value: new DateTime(2021, 12, 26, 20, 7, 44, 268, DateTimeKind.Utc).AddTicks(2190));

            migrationBuilder.UpdateData(
                table: "Validators",
                keyColumn: "Id",
                keyValue: 9L,
                column: "CreatedDate",
                value: new DateTime(2021, 12, 26, 20, 7, 44, 268, DateTimeKind.Utc).AddTicks(2191));

            migrationBuilder.UpdateData(
                table: "Validators",
                keyColumn: "Id",
                keyValue: 10L,
                column: "CreatedDate",
                value: new DateTime(2021, 12, 26, 20, 7, 44, 268, DateTimeKind.Utc).AddTicks(2192));

            migrationBuilder.UpdateData(
                table: "Validators",
                keyColumn: "Id",
                keyValue: 11L,
                column: "CreatedDate",
                value: new DateTime(2021, 12, 26, 20, 7, 44, 268, DateTimeKind.Utc).AddTicks(2193));

            migrationBuilder.UpdateData(
                table: "Validators",
                keyColumn: "Id",
                keyValue: 12L,
                column: "CreatedDate",
                value: new DateTime(2021, 12, 26, 20, 7, 44, 268, DateTimeKind.Utc).AddTicks(2196));

            migrationBuilder.UpdateData(
                table: "Validators",
                keyColumn: "Id",
                keyValue: 13L,
                column: "CreatedDate",
                value: new DateTime(2021, 12, 26, 20, 7, 44, 268, DateTimeKind.Utc).AddTicks(2227));

            migrationBuilder.UpdateData(
                table: "Validators",
                keyColumn: "Id",
                keyValue: 14L,
                column: "CreatedDate",
                value: new DateTime(2021, 12, 26, 20, 7, 44, 268, DateTimeKind.Utc).AddTicks(2228));

            migrationBuilder.UpdateData(
                table: "Validators",
                keyColumn: "Id",
                keyValue: 15L,
                column: "CreatedDate",
                value: new DateTime(2021, 12, 26, 20, 7, 44, 268, DateTimeKind.Utc).AddTicks(2230));

            migrationBuilder.UpdateData(
                table: "Validators",
                keyColumn: "Id",
                keyValue: 16L,
                column: "CreatedDate",
                value: new DateTime(2021, 12, 26, 20, 7, 44, 268, DateTimeKind.Utc).AddTicks(2231));

            migrationBuilder.UpdateData(
                table: "Validators",
                keyColumn: "Id",
                keyValue: 17L,
                column: "CreatedDate",
                value: new DateTime(2021, 12, 26, 20, 7, 44, 268, DateTimeKind.Utc).AddTicks(2232));

            migrationBuilder.UpdateData(
                table: "Validators",
                keyColumn: "Id",
                keyValue: 18L,
                column: "CreatedDate",
                value: new DateTime(2021, 12, 26, 20, 7, 44, 268, DateTimeKind.Utc).AddTicks(2233));

            migrationBuilder.UpdateData(
                table: "Validators",
                keyColumn: "Id",
                keyValue: 19L,
                column: "CreatedDate",
                value: new DateTime(2021, 12, 26, 20, 7, 44, 268, DateTimeKind.Utc).AddTicks(2234));

            migrationBuilder.UpdateData(
                table: "Validators",
                keyColumn: "Id",
                keyValue: 20L,
                column: "CreatedDate",
                value: new DateTime(2021, 12, 26, 20, 7, 44, 268, DateTimeKind.Utc).AddTicks(2235));

            migrationBuilder.UpdateData(
                table: "Validators",
                keyColumn: "Id",
                keyValue: 21L,
                column: "CreatedDate",
                value: new DateTime(2021, 12, 26, 20, 7, 44, 268, DateTimeKind.Utc).AddTicks(2236));

            migrationBuilder.UpdateData(
                table: "Validators",
                keyColumn: "Id",
                keyValue: 22L,
                column: "CreatedDate",
                value: new DateTime(2021, 12, 26, 20, 7, 44, 268, DateTimeKind.Utc).AddTicks(2237));

            migrationBuilder.UpdateData(
                table: "Validators",
                keyColumn: "Id",
                keyValue: 23L,
                column: "CreatedDate",
                value: new DateTime(2021, 12, 26, 20, 7, 44, 268, DateTimeKind.Utc).AddTicks(2238));

            migrationBuilder.UpdateData(
                table: "Validators",
                keyColumn: "Id",
                keyValue: 24L,
                column: "CreatedDate",
                value: new DateTime(2021, 12, 26, 20, 7, 44, 268, DateTimeKind.Utc).AddTicks(2239));

            migrationBuilder.UpdateData(
                table: "Validators",
                keyColumn: "Id",
                keyValue: 25L,
                column: "CreatedDate",
                value: new DateTime(2021, 12, 26, 20, 7, 44, 268, DateTimeKind.Utc).AddTicks(2241));

            migrationBuilder.UpdateData(
                table: "Validators",
                keyColumn: "Id",
                keyValue: 26L,
                column: "CreatedDate",
                value: new DateTime(2021, 12, 26, 20, 7, 44, 268, DateTimeKind.Utc).AddTicks(2242));

            migrationBuilder.UpdateData(
                table: "Validators",
                keyColumn: "Id",
                keyValue: 27L,
                column: "CreatedDate",
                value: new DateTime(2021, 12, 26, 20, 7, 44, 268, DateTimeKind.Utc).AddTicks(2243));

            migrationBuilder.UpdateData(
                table: "Validators",
                keyColumn: "Id",
                keyValue: 28L,
                column: "CreatedDate",
                value: new DateTime(2021, 12, 26, 20, 7, 44, 268, DateTimeKind.Utc).AddTicks(2244));

            migrationBuilder.UpdateData(
                table: "Validators",
                keyColumn: "Id",
                keyValue: 29L,
                column: "CreatedDate",
                value: new DateTime(2021, 12, 26, 20, 7, 44, 268, DateTimeKind.Utc).AddTicks(2245));

            migrationBuilder.UpdateData(
                table: "Validators",
                keyColumn: "Id",
                keyValue: 30L,
                column: "CreatedDate",
                value: new DateTime(2021, 12, 26, 20, 7, 44, 268, DateTimeKind.Utc).AddTicks(2250));

            migrationBuilder.UpdateData(
                table: "Validators",
                keyColumn: "Id",
                keyValue: 31L,
                column: "CreatedDate",
                value: new DateTime(2021, 12, 26, 20, 7, 44, 268, DateTimeKind.Utc).AddTicks(2251));

            migrationBuilder.UpdateData(
                table: "Validators",
                keyColumn: "Id",
                keyValue: 32L,
                column: "CreatedDate",
                value: new DateTime(2021, 12, 26, 20, 7, 44, 268, DateTimeKind.Utc).AddTicks(2252));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: -1L,
                columns: new[] { "ContactDetailsId", "CountyCode", "CreatedDate", "Password" },
                values: new object[] { 1L, null, new DateTime(2021, 12, 26, 20, 7, 43, 648, DateTimeKind.Utc).AddTicks(2076), "$2a$12$7OLGnEId2NXF24hEqL5HI.KKdv.8/DdW5cImih/FfeBiq8aZ1LCHe" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "ContactDetailsId", "CountyCode", "CreatedDate", "Password" },
                values: new object[] { 2L, null, new DateTime(2021, 12, 26, 20, 7, 43, 943, DateTimeKind.Utc).AddTicks(661), "$2a$12$TDrMEgE7jzCt6MZS6nNEg.k8j378R/.YI6T8wYO7IH5/MTiRPORzq" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2L,
                columns: new[] { "ContactDetailsId", "CountyCode", "CreatedDate", "Password" },
                values: new object[] { 3L, null, new DateTime(2021, 12, 26, 20, 7, 44, 244, DateTimeKind.Utc).AddTicks(9645), "$2a$12$/gXgIEWscqgEAWkh828U6.r.vhd3ULg16s5aTanR5joyxwfrv1J2m" });

            migrationBuilder.CreateIndex(
                name: "IX_Users_ContactDetailsId",
                table: "Users",
                column: "ContactDetailsId");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_ContactDetails_ContactDetailsId",
                table: "Users",
                column: "ContactDetailsId",
                principalTable: "ContactDetails",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_ContactDetails_ContactDetailsId",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Users_ContactDetailsId",
                table: "Users");

            migrationBuilder.DeleteData(
                table: "ContactDetails",
                keyColumn: "Id",
                keyValue: 1L);

            migrationBuilder.DeleteData(
                table: "ContactDetails",
                keyColumn: "Id",
                keyValue: 2L);

            migrationBuilder.DeleteData(
                table: "ContactDetails",
                keyColumn: "Id",
                keyValue: 3L);

            migrationBuilder.DropColumn(
                name: "Max",
                table: "Validators");

            migrationBuilder.DropColumn(
                name: "Min",
                table: "Validators");

            migrationBuilder.DropColumn(
                name: "ContactDetailsId",
                table: "Users");

            migrationBuilder.AddColumn<string>(
                name: "City",
                table: "Users",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "County",
                table: "Users",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MailingAddressCell",
                table: "Users",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MailingAddressCountyCode",
                table: "Users",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "State",
                table: "Users",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "StreetAddress",
                table: "Users",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Suite",
                table: "Users",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ZipCode",
                table: "Users",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "ContactTypeMaster",
                keyColumn: "Id",
                keyValue: 7L,
                columns: new[] { "ContactType", "EntityType" },
                values: new object[] { "HouseHoldIncome", "HouseHoldIncome" });

            migrationBuilder.UpdateData(
                table: "ContactTypeMaster",
                keyColumn: "Id",
                keyValue: 9L,
                column: "ContactType",
                value: "UserProfile");

            migrationBuilder.UpdateData(
                table: "DynamicScreens",
                keyColumn: "Id",
                keyValue: 1L,
                column: "CreatedDate",
                value: new DateTime(2021, 12, 25, 5, 59, 48, 736, DateTimeKind.Utc).AddTicks(3847));

            migrationBuilder.UpdateData(
                table: "DynamicScreens",
                keyColumn: "Id",
                keyValue: 2L,
                column: "CreatedDate",
                value: new DateTime(2021, 12, 25, 5, 59, 48, 736, DateTimeKind.Utc).AddTicks(4224));

            migrationBuilder.UpdateData(
                table: "DynamicScreens",
                keyColumn: "Id",
                keyValue: 3L,
                column: "CreatedDate",
                value: new DateTime(2021, 12, 25, 5, 59, 48, 736, DateTimeKind.Utc).AddTicks(4236));

            migrationBuilder.UpdateData(
                table: "DynamicScreens",
                keyColumn: "Id",
                keyValue: 4L,
                column: "CreatedDate",
                value: new DateTime(2021, 12, 25, 5, 59, 48, 736, DateTimeKind.Utc).AddTicks(4238));

            migrationBuilder.UpdateData(
                table: "DynamicScreens",
                keyColumn: "Id",
                keyValue: 5L,
                column: "CreatedDate",
                value: new DateTime(2021, 12, 25, 5, 59, 48, 736, DateTimeKind.Utc).AddTicks(4240));

            migrationBuilder.UpdateData(
                table: "DynamicScreens",
                keyColumn: "Id",
                keyValue: 6L,
                column: "CreatedDate",
                value: new DateTime(2021, 12, 25, 5, 59, 48, 736, DateTimeKind.Utc).AddTicks(4241));

            migrationBuilder.UpdateData(
                table: "DynamicScreens",
                keyColumn: "Id",
                keyValue: 7L,
                column: "CreatedDate",
                value: new DateTime(2021, 12, 25, 5, 59, 48, 736, DateTimeKind.Utc).AddTicks(4243));

            migrationBuilder.UpdateData(
                table: "DynamicScreens",
                keyColumn: "Id",
                keyValue: 8L,
                column: "CreatedDate",
                value: new DateTime(2021, 12, 25, 5, 59, 48, 736, DateTimeKind.Utc).AddTicks(4244));

            migrationBuilder.UpdateData(
                table: "DynamicScreens",
                keyColumn: "Id",
                keyValue: 9L,
                column: "CreatedDate",
                value: new DateTime(2021, 12, 25, 5, 59, 48, 736, DateTimeKind.Utc).AddTicks(4245));

            migrationBuilder.UpdateData(
                table: "DynamicScreens",
                keyColumn: "Id",
                keyValue: 10L,
                column: "CreatedDate",
                value: new DateTime(2021, 12, 25, 5, 59, 48, 736, DateTimeKind.Utc).AddTicks(4247));

            migrationBuilder.UpdateData(
                table: "DynamicScreens",
                keyColumn: "Id",
                keyValue: 11L,
                column: "CreatedDate",
                value: new DateTime(2021, 12, 25, 5, 59, 48, 736, DateTimeKind.Utc).AddTicks(4248));

            migrationBuilder.UpdateData(
                table: "Options",
                keyColumn: "Id",
                keyValue: 1L,
                column: "CreatedDate",
                value: new DateTime(2021, 12, 25, 5, 59, 48, 739, DateTimeKind.Utc).AddTicks(2958));

            migrationBuilder.UpdateData(
                table: "Options",
                keyColumn: "Id",
                keyValue: 2L,
                column: "CreatedDate",
                value: new DateTime(2021, 12, 25, 5, 59, 48, 739, DateTimeKind.Utc).AddTicks(3502));

            migrationBuilder.UpdateData(
                table: "Options",
                keyColumn: "Id",
                keyValue: 3L,
                column: "CreatedDate",
                value: new DateTime(2021, 12, 25, 5, 59, 48, 739, DateTimeKind.Utc).AddTicks(3519));

            migrationBuilder.UpdateData(
                table: "Options",
                keyColumn: "Id",
                keyValue: 4L,
                column: "CreatedDate",
                value: new DateTime(2021, 12, 25, 5, 59, 48, 739, DateTimeKind.Utc).AddTicks(3520));

            migrationBuilder.UpdateData(
                table: "Options",
                keyColumn: "Id",
                keyValue: 5L,
                column: "CreatedDate",
                value: new DateTime(2021, 12, 25, 5, 59, 48, 739, DateTimeKind.Utc).AddTicks(3522));

            migrationBuilder.UpdateData(
                table: "Options",
                keyColumn: "Id",
                keyValue: 6L,
                column: "CreatedDate",
                value: new DateTime(2021, 12, 25, 5, 59, 48, 739, DateTimeKind.Utc).AddTicks(3524));

            migrationBuilder.UpdateData(
                table: "Options",
                keyColumn: "Id",
                keyValue: 7L,
                column: "CreatedDate",
                value: new DateTime(2021, 12, 25, 5, 59, 48, 739, DateTimeKind.Utc).AddTicks(3526));

            migrationBuilder.UpdateData(
                table: "Options",
                keyColumn: "Id",
                keyValue: 8L,
                column: "CreatedDate",
                value: new DateTime(2021, 12, 25, 5, 59, 48, 739, DateTimeKind.Utc).AddTicks(3532));

            migrationBuilder.UpdateData(
                table: "Options",
                keyColumn: "Id",
                keyValue: 9L,
                column: "CreatedDate",
                value: new DateTime(2021, 12, 25, 5, 59, 48, 739, DateTimeKind.Utc).AddTicks(3533));

            migrationBuilder.UpdateData(
                table: "Options",
                keyColumn: "Id",
                keyValue: 10L,
                column: "CreatedDate",
                value: new DateTime(2021, 12, 25, 5, 59, 48, 739, DateTimeKind.Utc).AddTicks(3535));

            migrationBuilder.UpdateData(
                table: "Options",
                keyColumn: "Id",
                keyValue: 11L,
                column: "CreatedDate",
                value: new DateTime(2021, 12, 25, 5, 59, 48, 739, DateTimeKind.Utc).AddTicks(3562));

            migrationBuilder.UpdateData(
                table: "Options",
                keyColumn: "Id",
                keyValue: 12L,
                column: "CreatedDate",
                value: new DateTime(2021, 12, 25, 5, 59, 48, 739, DateTimeKind.Utc).AddTicks(3563));

            migrationBuilder.UpdateData(
                table: "Options",
                keyColumn: "Id",
                keyValue: 13L,
                column: "CreatedDate",
                value: new DateTime(2021, 12, 25, 5, 59, 48, 739, DateTimeKind.Utc).AddTicks(3564));

            migrationBuilder.UpdateData(
                table: "Options",
                keyColumn: "Id",
                keyValue: 14L,
                column: "CreatedDate",
                value: new DateTime(2021, 12, 25, 5, 59, 48, 739, DateTimeKind.Utc).AddTicks(3565));

            migrationBuilder.UpdateData(
                table: "Options",
                keyColumn: "Id",
                keyValue: 15L,
                column: "CreatedDate",
                value: new DateTime(2021, 12, 25, 5, 59, 48, 739, DateTimeKind.Utc).AddTicks(3566));

            migrationBuilder.UpdateData(
                table: "Options",
                keyColumn: "Id",
                keyValue: 16L,
                column: "CreatedDate",
                value: new DateTime(2021, 12, 25, 5, 59, 48, 739, DateTimeKind.Utc).AddTicks(3567));

            migrationBuilder.UpdateData(
                table: "Options",
                keyColumn: "Id",
                keyValue: 17L,
                column: "CreatedDate",
                value: new DateTime(2021, 12, 25, 5, 59, 48, 739, DateTimeKind.Utc).AddTicks(3583));

            migrationBuilder.UpdateData(
                table: "Options",
                keyColumn: "Id",
                keyValue: 18L,
                column: "CreatedDate",
                value: new DateTime(2021, 12, 25, 5, 59, 48, 739, DateTimeKind.Utc).AddTicks(3584));

            migrationBuilder.UpdateData(
                table: "Options",
                keyColumn: "Id",
                keyValue: 19L,
                column: "CreatedDate",
                value: new DateTime(2021, 12, 25, 5, 59, 48, 739, DateTimeKind.Utc).AddTicks(3585));

            migrationBuilder.UpdateData(
                table: "Options",
                keyColumn: "Id",
                keyValue: 20L,
                column: "CreatedDate",
                value: new DateTime(2021, 12, 25, 5, 59, 48, 739, DateTimeKind.Utc).AddTicks(3586));

            migrationBuilder.UpdateData(
                table: "Options",
                keyColumn: "Id",
                keyValue: 21L,
                column: "CreatedDate",
                value: new DateTime(2021, 12, 25, 5, 59, 48, 739, DateTimeKind.Utc).AddTicks(3587));

            migrationBuilder.UpdateData(
                table: "Options",
                keyColumn: "Id",
                keyValue: 22L,
                column: "CreatedDate",
                value: new DateTime(2021, 12, 25, 5, 59, 48, 739, DateTimeKind.Utc).AddTicks(3589));

            migrationBuilder.UpdateData(
                table: "Options",
                keyColumn: "Id",
                keyValue: 23L,
                column: "CreatedDate",
                value: new DateTime(2021, 12, 25, 5, 59, 48, 739, DateTimeKind.Utc).AddTicks(3590));

            migrationBuilder.UpdateData(
                table: "Options",
                keyColumn: "Id",
                keyValue: 24L,
                column: "CreatedDate",
                value: new DateTime(2021, 12, 25, 5, 59, 48, 739, DateTimeKind.Utc).AddTicks(3591));

            migrationBuilder.UpdateData(
                table: "Options",
                keyColumn: "Id",
                keyValue: 25L,
                column: "CreatedDate",
                value: new DateTime(2021, 12, 25, 5, 59, 48, 739, DateTimeKind.Utc).AddTicks(3593));

            migrationBuilder.UpdateData(
                table: "Options",
                keyColumn: "Id",
                keyValue: 26L,
                column: "CreatedDate",
                value: new DateTime(2021, 12, 25, 5, 59, 48, 739, DateTimeKind.Utc).AddTicks(3594));

            migrationBuilder.UpdateData(
                table: "Options",
                keyColumn: "Id",
                keyValue: 27L,
                column: "CreatedDate",
                value: new DateTime(2021, 12, 25, 5, 59, 48, 739, DateTimeKind.Utc).AddTicks(3595));

            migrationBuilder.UpdateData(
                table: "Options",
                keyColumn: "Id",
                keyValue: 28L,
                column: "CreatedDate",
                value: new DateTime(2021, 12, 25, 5, 59, 48, 739, DateTimeKind.Utc).AddTicks(3596));

            migrationBuilder.UpdateData(
                table: "Options",
                keyColumn: "Id",
                keyValue: 29L,
                column: "CreatedDate",
                value: new DateTime(2021, 12, 25, 5, 59, 48, 739, DateTimeKind.Utc).AddTicks(3597));

            migrationBuilder.UpdateData(
                table: "Options",
                keyColumn: "Id",
                keyValue: 30L,
                column: "CreatedDate",
                value: new DateTime(2021, 12, 25, 5, 59, 48, 739, DateTimeKind.Utc).AddTicks(3598));

            migrationBuilder.UpdateData(
                table: "Options",
                keyColumn: "Id",
                keyValue: 31L,
                column: "CreatedDate",
                value: new DateTime(2021, 12, 25, 5, 59, 48, 739, DateTimeKind.Utc).AddTicks(3599));

            migrationBuilder.UpdateData(
                table: "Options",
                keyColumn: "Id",
                keyValue: 32L,
                column: "CreatedDate",
                value: new DateTime(2021, 12, 25, 5, 59, 48, 739, DateTimeKind.Utc).AddTicks(3617));

            migrationBuilder.UpdateData(
                table: "Options",
                keyColumn: "Id",
                keyValue: 33L,
                column: "CreatedDate",
                value: new DateTime(2021, 12, 25, 5, 59, 48, 739, DateTimeKind.Utc).AddTicks(3618));

            migrationBuilder.UpdateData(
                table: "Options",
                keyColumn: "Id",
                keyValue: 34L,
                column: "CreatedDate",
                value: new DateTime(2021, 12, 25, 5, 59, 48, 739, DateTimeKind.Utc).AddTicks(3619));

            migrationBuilder.UpdateData(
                table: "Options",
                keyColumn: "Id",
                keyValue: 35L,
                column: "CreatedDate",
                value: new DateTime(2021, 12, 25, 5, 59, 48, 739, DateTimeKind.Utc).AddTicks(3620));

            migrationBuilder.UpdateData(
                table: "Options",
                keyColumn: "Id",
                keyValue: 36L,
                column: "CreatedDate",
                value: new DateTime(2021, 12, 25, 5, 59, 48, 739, DateTimeKind.Utc).AddTicks(3621));

            migrationBuilder.UpdateData(
                table: "Options",
                keyColumn: "Id",
                keyValue: 37L,
                column: "CreatedDate",
                value: new DateTime(2021, 12, 25, 5, 59, 48, 739, DateTimeKind.Utc).AddTicks(3623));

            migrationBuilder.UpdateData(
                table: "Options",
                keyColumn: "Id",
                keyValue: 38L,
                column: "CreatedDate",
                value: new DateTime(2021, 12, 25, 5, 59, 48, 739, DateTimeKind.Utc).AddTicks(3624));

            migrationBuilder.UpdateData(
                table: "Options",
                keyColumn: "Id",
                keyValue: 39L,
                column: "CreatedDate",
                value: new DateTime(2021, 12, 25, 5, 59, 48, 739, DateTimeKind.Utc).AddTicks(3625));

            migrationBuilder.UpdateData(
                table: "Options",
                keyColumn: "Id",
                keyValue: 40L,
                column: "CreatedDate",
                value: new DateTime(2021, 12, 25, 5, 59, 48, 739, DateTimeKind.Utc).AddTicks(3626));

            migrationBuilder.UpdateData(
                table: "Options",
                keyColumn: "Id",
                keyValue: 41L,
                column: "CreatedDate",
                value: new DateTime(2021, 12, 25, 5, 59, 48, 739, DateTimeKind.Utc).AddTicks(3627));

            migrationBuilder.UpdateData(
                table: "Options",
                keyColumn: "Id",
                keyValue: 42L,
                column: "CreatedDate",
                value: new DateTime(2021, 12, 25, 5, 59, 48, 739, DateTimeKind.Utc).AddTicks(3628));

            migrationBuilder.UpdateData(
                table: "Options",
                keyColumn: "Id",
                keyValue: 43L,
                column: "CreatedDate",
                value: new DateTime(2021, 12, 25, 5, 59, 48, 739, DateTimeKind.Utc).AddTicks(3629));

            migrationBuilder.UpdateData(
                table: "Options",
                keyColumn: "Id",
                keyValue: 44L,
                column: "CreatedDate",
                value: new DateTime(2021, 12, 25, 5, 59, 48, 739, DateTimeKind.Utc).AddTicks(4066));

            migrationBuilder.UpdateData(
                table: "Options",
                keyColumn: "Id",
                keyValue: 45L,
                column: "CreatedDate",
                value: new DateTime(2021, 12, 25, 5, 59, 48, 739, DateTimeKind.Utc).AddTicks(4083));

            migrationBuilder.UpdateData(
                table: "Program",
                keyColumn: "Id",
                keyValue: 1L,
                column: "CreatedDate",
                value: new DateTime(2021, 12, 25, 5, 59, 48, 740, DateTimeKind.Utc).AddTicks(6594));

            migrationBuilder.UpdateData(
                table: "Program",
                keyColumn: "Id",
                keyValue: 2L,
                column: "CreatedDate",
                value: new DateTime(2021, 12, 25, 5, 59, 48, 740, DateTimeKind.Utc).AddTicks(6630));

            migrationBuilder.UpdateData(
                table: "Program",
                keyColumn: "Id",
                keyValue: 3L,
                column: "CreatedDate",
                value: new DateTime(2021, 12, 25, 5, 59, 48, 740, DateTimeKind.Utc).AddTicks(6632));

            migrationBuilder.UpdateData(
                table: "Program",
                keyColumn: "Id",
                keyValue: 4L,
                column: "CreatedDate",
                value: new DateTime(2021, 12, 25, 5, 59, 48, 740, DateTimeKind.Utc).AddTicks(6634));

            migrationBuilder.UpdateData(
                table: "Program",
                keyColumn: "Id",
                keyValue: 5L,
                column: "CreatedDate",
                value: new DateTime(2021, 12, 25, 5, 59, 48, 740, DateTimeKind.Utc).AddTicks(6635));

            migrationBuilder.UpdateData(
                table: "Program",
                keyColumn: "Id",
                keyValue: 6L,
                column: "CreatedDate",
                value: new DateTime(2021, 12, 25, 5, 59, 48, 740, DateTimeKind.Utc).AddTicks(6636));

            migrationBuilder.UpdateData(
                table: "ProgramDocument",
                keyColumn: "Id",
                keyValue: 1L,
                column: "CreatedDate",
                value: new DateTime(2021, 12, 25, 5, 59, 48, 740, DateTimeKind.Utc).AddTicks(6788));

            migrationBuilder.UpdateData(
                table: "ProgramDocument",
                keyColumn: "Id",
                keyValue: 2L,
                column: "CreatedDate",
                value: new DateTime(2021, 12, 25, 5, 59, 48, 740, DateTimeKind.Utc).AddTicks(7295));

            migrationBuilder.UpdateData(
                table: "ProgramDocument",
                keyColumn: "Id",
                keyValue: 3L,
                column: "CreatedDate",
                value: new DateTime(2021, 12, 25, 5, 59, 48, 740, DateTimeKind.Utc).AddTicks(7309));

            migrationBuilder.UpdateData(
                table: "ProgramDocument",
                keyColumn: "Id",
                keyValue: 4L,
                column: "CreatedDate",
                value: new DateTime(2021, 12, 25, 5, 59, 48, 740, DateTimeKind.Utc).AddTicks(7310));

            migrationBuilder.UpdateData(
                table: "ProgramDocument",
                keyColumn: "Id",
                keyValue: 5L,
                column: "CreatedDate",
                value: new DateTime(2021, 12, 25, 5, 59, 48, 740, DateTimeKind.Utc).AddTicks(7311));

            migrationBuilder.UpdateData(
                table: "ProgramDocument",
                keyColumn: "Id",
                keyValue: 6L,
                column: "CreatedDate",
                value: new DateTime(2021, 12, 25, 5, 59, 48, 740, DateTimeKind.Utc).AddTicks(7313));

            migrationBuilder.UpdateData(
                table: "ProgramDocument",
                keyColumn: "Id",
                keyValue: 7L,
                column: "CreatedDate",
                value: new DateTime(2021, 12, 25, 5, 59, 48, 740, DateTimeKind.Utc).AddTicks(7314));

            migrationBuilder.UpdateData(
                table: "QuickAssessmentQuestions",
                keyColumn: "Id",
                keyValue: 1L,
                column: "CreatedDate",
                value: new DateTime(2021, 12, 25, 5, 59, 48, 736, DateTimeKind.Utc).AddTicks(4971));

            migrationBuilder.UpdateData(
                table: "QuickAssessmentQuestions",
                keyColumn: "Id",
                keyValue: 2L,
                column: "CreatedDate",
                value: new DateTime(2021, 12, 25, 5, 59, 48, 736, DateTimeKind.Utc).AddTicks(6336));

            migrationBuilder.UpdateData(
                table: "QuickAssessmentQuestions",
                keyColumn: "Id",
                keyValue: 3L,
                column: "CreatedDate",
                value: new DateTime(2021, 12, 25, 5, 59, 48, 736, DateTimeKind.Utc).AddTicks(7396));

            migrationBuilder.UpdateData(
                table: "QuickAssessmentQuestions",
                keyColumn: "Id",
                keyValue: 4L,
                column: "CreatedDate",
                value: new DateTime(2021, 12, 25, 5, 59, 48, 736, DateTimeKind.Utc).AddTicks(8297));

            migrationBuilder.UpdateData(
                table: "QuickAssessmentQuestions",
                keyColumn: "Id",
                keyValue: 5L,
                column: "CreatedDate",
                value: new DateTime(2021, 12, 25, 5, 59, 48, 736, DateTimeKind.Utc).AddTicks(8315));

            migrationBuilder.UpdateData(
                table: "QuickAssessmentQuestions",
                keyColumn: "Id",
                keyValue: 6L,
                column: "CreatedDate",
                value: new DateTime(2021, 12, 25, 5, 59, 48, 736, DateTimeKind.Utc).AddTicks(9414));

            migrationBuilder.UpdateData(
                table: "QuickAssessmentQuestions",
                keyColumn: "Id",
                keyValue: 7L,
                column: "CreatedDate",
                value: new DateTime(2021, 12, 25, 5, 59, 48, 737, DateTimeKind.Utc).AddTicks(893));

            migrationBuilder.UpdateData(
                table: "QuickAssessmentQuestions",
                keyColumn: "Id",
                keyValue: 8L,
                column: "CreatedDate",
                value: new DateTime(2021, 12, 25, 5, 59, 48, 737, DateTimeKind.Utc).AddTicks(899));

            migrationBuilder.UpdateData(
                table: "QuickAssessmentQuestions",
                keyColumn: "Id",
                keyValue: 9L,
                column: "CreatedDate",
                value: new DateTime(2021, 12, 25, 5, 59, 48, 737, DateTimeKind.Utc).AddTicks(2294));

            migrationBuilder.UpdateData(
                table: "QuickAssessmentQuestions",
                keyColumn: "Id",
                keyValue: 10L,
                column: "CreatedDate",
                value: new DateTime(2021, 12, 25, 5, 59, 48, 737, DateTimeKind.Utc).AddTicks(2297));

            migrationBuilder.UpdateData(
                table: "QuickAssessmentQuestions",
                keyColumn: "Id",
                keyValue: 11L,
                column: "CreatedDate",
                value: new DateTime(2021, 12, 25, 5, 59, 48, 737, DateTimeKind.Utc).AddTicks(2300));

            migrationBuilder.UpdateData(
                table: "QuickAssessmentQuestions",
                keyColumn: "Id",
                keyValue: 12L,
                column: "CreatedDate",
                value: new DateTime(2021, 12, 25, 5, 59, 48, 737, DateTimeKind.Utc).AddTicks(3097));

            migrationBuilder.UpdateData(
                table: "QuickAssessmentQuestions",
                keyColumn: "Id",
                keyValue: 13L,
                column: "CreatedDate",
                value: new DateTime(2021, 12, 25, 5, 59, 48, 737, DateTimeKind.Utc).AddTicks(3113));

            migrationBuilder.UpdateData(
                table: "QuickAssessmentQuestions",
                keyColumn: "Id",
                keyValue: 14L,
                column: "CreatedDate",
                value: new DateTime(2021, 12, 25, 5, 59, 48, 737, DateTimeKind.Utc).AddTicks(4165));

            migrationBuilder.UpdateData(
                table: "QuickAssessmentQuestions",
                keyColumn: "Id",
                keyValue: 15L,
                column: "CreatedDate",
                value: new DateTime(2021, 12, 25, 5, 59, 48, 737, DateTimeKind.Utc).AddTicks(6669));

            migrationBuilder.UpdateData(
                table: "QuickAssessmentQuestions",
                keyColumn: "Id",
                keyValue: 16L,
                column: "CreatedDate",
                value: new DateTime(2021, 12, 25, 5, 59, 48, 737, DateTimeKind.Utc).AddTicks(7664));

            migrationBuilder.UpdateData(
                table: "QuickAssessmentQuestions",
                keyColumn: "Id",
                keyValue: 17L,
                column: "CreatedDate",
                value: new DateTime(2021, 12, 25, 5, 59, 48, 737, DateTimeKind.Utc).AddTicks(8442));

            migrationBuilder.UpdateData(
                table: "QuickAssessmentQuestions",
                keyColumn: "Id",
                keyValue: 18L,
                column: "CreatedDate",
                value: new DateTime(2021, 12, 25, 5, 59, 48, 737, DateTimeKind.Utc).AddTicks(9561));

            migrationBuilder.UpdateData(
                table: "QuickAssessmentQuestions",
                keyColumn: "Id",
                keyValue: 19L,
                column: "CreatedDate",
                value: new DateTime(2021, 12, 25, 5, 59, 48, 737, DateTimeKind.Utc).AddTicks(9578));

            migrationBuilder.UpdateData(
                table: "QuickAssessmentQuestions",
                keyColumn: "Id",
                keyValue: 20L,
                column: "CreatedDate",
                value: new DateTime(2021, 12, 25, 5, 59, 48, 737, DateTimeKind.Utc).AddTicks(9581));

            migrationBuilder.UpdateData(
                table: "QuickAssessmentQuestions",
                keyColumn: "Id",
                keyValue: 21L,
                column: "CreatedDate",
                value: new DateTime(2021, 12, 25, 5, 59, 48, 738, DateTimeKind.Utc).AddTicks(586));

            migrationBuilder.UpdateData(
                table: "QuickAssessmentQuestions",
                keyColumn: "Id",
                keyValue: 22L,
                column: "CreatedDate",
                value: new DateTime(2021, 12, 25, 5, 59, 48, 738, DateTimeKind.Utc).AddTicks(2076));

            migrationBuilder.UpdateData(
                table: "QuickAssessmentQuestions",
                keyColumn: "Id",
                keyValue: 23L,
                column: "CreatedDate",
                value: new DateTime(2021, 12, 25, 5, 59, 48, 738, DateTimeKind.Utc).AddTicks(2908));

            migrationBuilder.UpdateData(
                table: "QuickAssessmentQuestions",
                keyColumn: "Id",
                keyValue: 24L,
                column: "CreatedDate",
                value: new DateTime(2021, 12, 25, 5, 59, 48, 738, DateTimeKind.Utc).AddTicks(3708));

            migrationBuilder.UpdateData(
                table: "QuickAssessmentQuestions",
                keyColumn: "Id",
                keyValue: 25L,
                column: "CreatedDate",
                value: new DateTime(2021, 12, 25, 5, 59, 48, 738, DateTimeKind.Utc).AddTicks(5012));

            migrationBuilder.UpdateData(
                table: "QuickAssessmentQuestions",
                keyColumn: "Id",
                keyValue: 26L,
                column: "CreatedDate",
                value: new DateTime(2021, 12, 25, 5, 59, 48, 738, DateTimeKind.Utc).AddTicks(6298));

            migrationBuilder.UpdateData(
                table: "QuickAssessmentQuestions",
                keyColumn: "Id",
                keyValue: 27L,
                column: "CreatedDate",
                value: new DateTime(2021, 12, 25, 5, 59, 48, 738, DateTimeKind.Utc).AddTicks(7166));

            migrationBuilder.UpdateData(
                table: "QuickAssessmentQuestions",
                keyColumn: "Id",
                keyValue: 28L,
                column: "CreatedDate",
                value: new DateTime(2021, 12, 25, 5, 59, 48, 738, DateTimeKind.Utc).AddTicks(8355));

            migrationBuilder.UpdateData(
                table: "QuickAssessmentQuestions",
                keyColumn: "Id",
                keyValue: 29L,
                column: "CreatedDate",
                value: new DateTime(2021, 12, 25, 5, 59, 48, 738, DateTimeKind.Utc).AddTicks(9348));

            migrationBuilder.UpdateData(
                table: "QuickAssessmentQuestions",
                keyColumn: "Id",
                keyValue: 30L,
                column: "CreatedDate",
                value: new DateTime(2021, 12, 25, 5, 59, 48, 739, DateTimeKind.Utc).AddTicks(283));

            migrationBuilder.UpdateData(
                table: "QuickAssessmentQuestions",
                keyColumn: "Id",
                keyValue: 31L,
                column: "CreatedDate",
                value: new DateTime(2021, 12, 25, 5, 59, 48, 739, DateTimeKind.Utc).AddTicks(304));

            migrationBuilder.UpdateData(
                table: "QuickAssessmentQuestions",
                keyColumn: "Id",
                keyValue: 32L,
                column: "CreatedDate",
                value: new DateTime(2021, 12, 25, 5, 59, 48, 739, DateTimeKind.Utc).AddTicks(1073));

            migrationBuilder.UpdateData(
                table: "QuickAssessmentQuestions",
                keyColumn: "Id",
                keyValue: 33L,
                column: "CreatedDate",
                value: new DateTime(2021, 12, 25, 5, 59, 48, 739, DateTimeKind.Utc).AddTicks(1893));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: -1L,
                columns: new[] { "CountyCode", "CreatedDate", "Password" },
                values: new object[] { "-1", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "$2a$12$DRDUgXCFLmGaZjJFXjeiwupe6jDAHm747xqxCUSCmZkdm2GmmfWkO" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "CountyCode", "CreatedDate", "Password" },
                values: new object[] { "1", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "$2a$12$GVRA6M//QGPguvd/uP/d1ewnf7EvMhmUmxO85K2V/oKE8gjOxLSfu" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2L,
                columns: new[] { "CountyCode", "CreatedDate", "Password" },
                values: new object[] { "-1", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "$2a$12$93Hnjw2QWyBsWJ0bf92cSOdJV9ZCRnlYWmdVwnLX8CtPlY59yiE16" });

            migrationBuilder.UpdateData(
                table: "Validators",
                keyColumn: "Id",
                keyValue: 1L,
                column: "CreatedDate",
                value: new DateTime(2021, 12, 25, 5, 59, 48, 739, DateTimeKind.Utc).AddTicks(4244));

            migrationBuilder.UpdateData(
                table: "Validators",
                keyColumn: "Id",
                keyValue: 2L,
                column: "CreatedDate",
                value: new DateTime(2021, 12, 25, 5, 59, 48, 739, DateTimeKind.Utc).AddTicks(5319));

            migrationBuilder.UpdateData(
                table: "Validators",
                keyColumn: "Id",
                keyValue: 3L,
                column: "CreatedDate",
                value: new DateTime(2021, 12, 25, 5, 59, 48, 739, DateTimeKind.Utc).AddTicks(6037));

            migrationBuilder.UpdateData(
                table: "Validators",
                keyColumn: "Id",
                keyValue: 4L,
                column: "CreatedDate",
                value: new DateTime(2021, 12, 25, 5, 59, 48, 739, DateTimeKind.Utc).AddTicks(6053));

            migrationBuilder.UpdateData(
                table: "Validators",
                keyColumn: "Id",
                keyValue: 5L,
                column: "CreatedDate",
                value: new DateTime(2021, 12, 25, 5, 59, 48, 739, DateTimeKind.Utc).AddTicks(6054));

            migrationBuilder.UpdateData(
                table: "Validators",
                keyColumn: "Id",
                keyValue: 6L,
                column: "CreatedDate",
                value: new DateTime(2021, 12, 25, 5, 59, 48, 739, DateTimeKind.Utc).AddTicks(6062));

            migrationBuilder.UpdateData(
                table: "Validators",
                keyColumn: "Id",
                keyValue: 7L,
                column: "CreatedDate",
                value: new DateTime(2021, 12, 25, 5, 59, 48, 739, DateTimeKind.Utc).AddTicks(6064));

            migrationBuilder.UpdateData(
                table: "Validators",
                keyColumn: "Id",
                keyValue: 8L,
                column: "CreatedDate",
                value: new DateTime(2021, 12, 25, 5, 59, 48, 739, DateTimeKind.Utc).AddTicks(6065));

            migrationBuilder.UpdateData(
                table: "Validators",
                keyColumn: "Id",
                keyValue: 9L,
                column: "CreatedDate",
                value: new DateTime(2021, 12, 25, 5, 59, 48, 739, DateTimeKind.Utc).AddTicks(6066));

            migrationBuilder.UpdateData(
                table: "Validators",
                keyColumn: "Id",
                keyValue: 10L,
                column: "CreatedDate",
                value: new DateTime(2021, 12, 25, 5, 59, 48, 739, DateTimeKind.Utc).AddTicks(6067));

            migrationBuilder.UpdateData(
                table: "Validators",
                keyColumn: "Id",
                keyValue: 11L,
                column: "CreatedDate",
                value: new DateTime(2021, 12, 25, 5, 59, 48, 739, DateTimeKind.Utc).AddTicks(6068));

            migrationBuilder.UpdateData(
                table: "Validators",
                keyColumn: "Id",
                keyValue: 12L,
                column: "CreatedDate",
                value: new DateTime(2021, 12, 25, 5, 59, 48, 739, DateTimeKind.Utc).AddTicks(6069));

            migrationBuilder.UpdateData(
                table: "Validators",
                keyColumn: "Id",
                keyValue: 13L,
                column: "CreatedDate",
                value: new DateTime(2021, 12, 25, 5, 59, 48, 739, DateTimeKind.Utc).AddTicks(6070));

            migrationBuilder.UpdateData(
                table: "Validators",
                keyColumn: "Id",
                keyValue: 14L,
                column: "CreatedDate",
                value: new DateTime(2021, 12, 25, 5, 59, 48, 739, DateTimeKind.Utc).AddTicks(6071));

            migrationBuilder.UpdateData(
                table: "Validators",
                keyColumn: "Id",
                keyValue: 15L,
                column: "CreatedDate",
                value: new DateTime(2021, 12, 25, 5, 59, 48, 739, DateTimeKind.Utc).AddTicks(6072));

            migrationBuilder.UpdateData(
                table: "Validators",
                keyColumn: "Id",
                keyValue: 16L,
                column: "CreatedDate",
                value: new DateTime(2021, 12, 25, 5, 59, 48, 739, DateTimeKind.Utc).AddTicks(6073));

            migrationBuilder.UpdateData(
                table: "Validators",
                keyColumn: "Id",
                keyValue: 17L,
                column: "CreatedDate",
                value: new DateTime(2021, 12, 25, 5, 59, 48, 739, DateTimeKind.Utc).AddTicks(6074));

            migrationBuilder.UpdateData(
                table: "Validators",
                keyColumn: "Id",
                keyValue: 18L,
                column: "CreatedDate",
                value: new DateTime(2021, 12, 25, 5, 59, 48, 739, DateTimeKind.Utc).AddTicks(6075));

            migrationBuilder.UpdateData(
                table: "Validators",
                keyColumn: "Id",
                keyValue: 19L,
                column: "CreatedDate",
                value: new DateTime(2021, 12, 25, 5, 59, 48, 739, DateTimeKind.Utc).AddTicks(6076));

            migrationBuilder.UpdateData(
                table: "Validators",
                keyColumn: "Id",
                keyValue: 20L,
                column: "CreatedDate",
                value: new DateTime(2021, 12, 25, 5, 59, 48, 739, DateTimeKind.Utc).AddTicks(6077));

            migrationBuilder.UpdateData(
                table: "Validators",
                keyColumn: "Id",
                keyValue: 21L,
                column: "CreatedDate",
                value: new DateTime(2021, 12, 25, 5, 59, 48, 739, DateTimeKind.Utc).AddTicks(6078));

            migrationBuilder.UpdateData(
                table: "Validators",
                keyColumn: "Id",
                keyValue: 22L,
                column: "CreatedDate",
                value: new DateTime(2021, 12, 25, 5, 59, 48, 739, DateTimeKind.Utc).AddTicks(6079));

            migrationBuilder.UpdateData(
                table: "Validators",
                keyColumn: "Id",
                keyValue: 23L,
                column: "CreatedDate",
                value: new DateTime(2021, 12, 25, 5, 59, 48, 739, DateTimeKind.Utc).AddTicks(6080));

            migrationBuilder.UpdateData(
                table: "Validators",
                keyColumn: "Id",
                keyValue: 24L,
                column: "CreatedDate",
                value: new DateTime(2021, 12, 25, 5, 59, 48, 739, DateTimeKind.Utc).AddTicks(6081));

            migrationBuilder.UpdateData(
                table: "Validators",
                keyColumn: "Id",
                keyValue: 25L,
                column: "CreatedDate",
                value: new DateTime(2021, 12, 25, 5, 59, 48, 739, DateTimeKind.Utc).AddTicks(6082));

            migrationBuilder.UpdateData(
                table: "Validators",
                keyColumn: "Id",
                keyValue: 26L,
                column: "CreatedDate",
                value: new DateTime(2021, 12, 25, 5, 59, 48, 739, DateTimeKind.Utc).AddTicks(6083));

            migrationBuilder.UpdateData(
                table: "Validators",
                keyColumn: "Id",
                keyValue: 27L,
                column: "CreatedDate",
                value: new DateTime(2021, 12, 25, 5, 59, 48, 739, DateTimeKind.Utc).AddTicks(6084));

            migrationBuilder.UpdateData(
                table: "Validators",
                keyColumn: "Id",
                keyValue: 28L,
                column: "CreatedDate",
                value: new DateTime(2021, 12, 25, 5, 59, 48, 739, DateTimeKind.Utc).AddTicks(6085));

            migrationBuilder.UpdateData(
                table: "Validators",
                keyColumn: "Id",
                keyValue: 29L,
                column: "CreatedDate",
                value: new DateTime(2021, 12, 25, 5, 59, 48, 739, DateTimeKind.Utc).AddTicks(6087));

            migrationBuilder.UpdateData(
                table: "Validators",
                keyColumn: "Id",
                keyValue: 30L,
                column: "CreatedDate",
                value: new DateTime(2021, 12, 25, 5, 59, 48, 739, DateTimeKind.Utc).AddTicks(6088));

            migrationBuilder.UpdateData(
                table: "Validators",
                keyColumn: "Id",
                keyValue: 31L,
                column: "CreatedDate",
                value: new DateTime(2021, 12, 25, 5, 59, 48, 739, DateTimeKind.Utc).AddTicks(6089));

            migrationBuilder.UpdateData(
                table: "Validators",
                keyColumn: "Id",
                keyValue: 32L,
                column: "CreatedDate",
                value: new DateTime(2021, 12, 25, 5, 59, 48, 739, DateTimeKind.Utc).AddTicks(6090));
        }
    }
}
