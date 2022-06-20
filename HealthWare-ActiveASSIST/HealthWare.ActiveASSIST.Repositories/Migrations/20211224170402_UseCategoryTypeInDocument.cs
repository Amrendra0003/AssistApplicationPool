using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace HealthWare.ActiveASSIST.Repositories.Migrations
{
    public partial class UseCategoryTypeInDocument : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Document_DocumentCategoryDocumentTypeMapping_DocumentCategoryDocumentTypeMappingId",
                table: "Document");

            migrationBuilder.RenameColumn(
                name: "DocumentCategoryDocumentTypeMappingId",
                table: "Document",
                newName: "DocumentTypeMasterId");

            migrationBuilder.RenameIndex(
                name: "IX_Document_DocumentCategoryDocumentTypeMappingId",
                table: "Document",
                newName: "IX_Document_DocumentTypeMasterId");

            migrationBuilder.AddColumn<string>(
                name: "Cell",
                table: "AssessmentInPatientDashboard",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CountyCode",
                table: "AssessmentInPatientDashboard",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "DynamicScreens",
                keyColumn: "Id",
                keyValue: 1L,
                column: "CreatedDate",
                value: new DateTime(2021, 12, 24, 17, 4, 0, 988, DateTimeKind.Utc).AddTicks(3325));

            migrationBuilder.UpdateData(
                table: "DynamicScreens",
                keyColumn: "Id",
                keyValue: 2L,
                column: "CreatedDate",
                value: new DateTime(2021, 12, 24, 17, 4, 0, 988, DateTimeKind.Utc).AddTicks(3674));

            migrationBuilder.UpdateData(
                table: "DynamicScreens",
                keyColumn: "Id",
                keyValue: 3L,
                column: "CreatedDate",
                value: new DateTime(2021, 12, 24, 17, 4, 0, 988, DateTimeKind.Utc).AddTicks(3685));

            migrationBuilder.UpdateData(
                table: "DynamicScreens",
                keyColumn: "Id",
                keyValue: 4L,
                column: "CreatedDate",
                value: new DateTime(2021, 12, 24, 17, 4, 0, 988, DateTimeKind.Utc).AddTicks(3687));

            migrationBuilder.UpdateData(
                table: "DynamicScreens",
                keyColumn: "Id",
                keyValue: 5L,
                column: "CreatedDate",
                value: new DateTime(2021, 12, 24, 17, 4, 0, 988, DateTimeKind.Utc).AddTicks(3689));

            migrationBuilder.UpdateData(
                table: "DynamicScreens",
                keyColumn: "Id",
                keyValue: 6L,
                column: "CreatedDate",
                value: new DateTime(2021, 12, 24, 17, 4, 0, 988, DateTimeKind.Utc).AddTicks(3691));

            migrationBuilder.UpdateData(
                table: "DynamicScreens",
                keyColumn: "Id",
                keyValue: 7L,
                column: "CreatedDate",
                value: new DateTime(2021, 12, 24, 17, 4, 0, 988, DateTimeKind.Utc).AddTicks(3692));

            migrationBuilder.UpdateData(
                table: "DynamicScreens",
                keyColumn: "Id",
                keyValue: 8L,
                column: "CreatedDate",
                value: new DateTime(2021, 12, 24, 17, 4, 0, 988, DateTimeKind.Utc).AddTicks(3694));

            migrationBuilder.UpdateData(
                table: "DynamicScreens",
                keyColumn: "Id",
                keyValue: 9L,
                column: "CreatedDate",
                value: new DateTime(2021, 12, 24, 17, 4, 0, 988, DateTimeKind.Utc).AddTicks(3695));

            migrationBuilder.UpdateData(
                table: "DynamicScreens",
                keyColumn: "Id",
                keyValue: 10L,
                column: "CreatedDate",
                value: new DateTime(2021, 12, 24, 17, 4, 0, 988, DateTimeKind.Utc).AddTicks(3697));

            migrationBuilder.UpdateData(
                table: "DynamicScreens",
                keyColumn: "Id",
                keyValue: 11L,
                column: "CreatedDate",
                value: new DateTime(2021, 12, 24, 17, 4, 0, 988, DateTimeKind.Utc).AddTicks(3698));

            migrationBuilder.UpdateData(
                table: "Options",
                keyColumn: "Id",
                keyValue: 1L,
                column: "CreatedDate",
                value: new DateTime(2021, 12, 24, 17, 4, 0, 991, DateTimeKind.Utc).AddTicks(1075));

            migrationBuilder.UpdateData(
                table: "Options",
                keyColumn: "Id",
                keyValue: 2L,
                column: "CreatedDate",
                value: new DateTime(2021, 12, 24, 17, 4, 0, 991, DateTimeKind.Utc).AddTicks(1582));

            migrationBuilder.UpdateData(
                table: "Options",
                keyColumn: "Id",
                keyValue: 3L,
                column: "CreatedDate",
                value: new DateTime(2021, 12, 24, 17, 4, 0, 991, DateTimeKind.Utc).AddTicks(1598));

            migrationBuilder.UpdateData(
                table: "Options",
                keyColumn: "Id",
                keyValue: 4L,
                column: "CreatedDate",
                value: new DateTime(2021, 12, 24, 17, 4, 0, 991, DateTimeKind.Utc).AddTicks(1599));

            migrationBuilder.UpdateData(
                table: "Options",
                keyColumn: "Id",
                keyValue: 5L,
                column: "CreatedDate",
                value: new DateTime(2021, 12, 24, 17, 4, 0, 991, DateTimeKind.Utc).AddTicks(1600));

            migrationBuilder.UpdateData(
                table: "Options",
                keyColumn: "Id",
                keyValue: 6L,
                column: "CreatedDate",
                value: new DateTime(2021, 12, 24, 17, 4, 0, 991, DateTimeKind.Utc).AddTicks(1602));

            migrationBuilder.UpdateData(
                table: "Options",
                keyColumn: "Id",
                keyValue: 7L,
                column: "CreatedDate",
                value: new DateTime(2021, 12, 24, 17, 4, 0, 991, DateTimeKind.Utc).AddTicks(1605));

            migrationBuilder.UpdateData(
                table: "Options",
                keyColumn: "Id",
                keyValue: 8L,
                column: "CreatedDate",
                value: new DateTime(2021, 12, 24, 17, 4, 0, 991, DateTimeKind.Utc).AddTicks(1607));

            migrationBuilder.UpdateData(
                table: "Options",
                keyColumn: "Id",
                keyValue: 9L,
                column: "CreatedDate",
                value: new DateTime(2021, 12, 24, 17, 4, 0, 991, DateTimeKind.Utc).AddTicks(1609));

            migrationBuilder.UpdateData(
                table: "Options",
                keyColumn: "Id",
                keyValue: 10L,
                column: "CreatedDate",
                value: new DateTime(2021, 12, 24, 17, 4, 0, 991, DateTimeKind.Utc).AddTicks(1610));

            migrationBuilder.UpdateData(
                table: "Options",
                keyColumn: "Id",
                keyValue: 11L,
                column: "CreatedDate",
                value: new DateTime(2021, 12, 24, 17, 4, 0, 991, DateTimeKind.Utc).AddTicks(1612));

            migrationBuilder.UpdateData(
                table: "Options",
                keyColumn: "Id",
                keyValue: 12L,
                column: "CreatedDate",
                value: new DateTime(2021, 12, 24, 17, 4, 0, 991, DateTimeKind.Utc).AddTicks(1614));

            migrationBuilder.UpdateData(
                table: "Options",
                keyColumn: "Id",
                keyValue: 13L,
                column: "CreatedDate",
                value: new DateTime(2021, 12, 24, 17, 4, 0, 991, DateTimeKind.Utc).AddTicks(1615));

            migrationBuilder.UpdateData(
                table: "Options",
                keyColumn: "Id",
                keyValue: 14L,
                column: "CreatedDate",
                value: new DateTime(2021, 12, 24, 17, 4, 0, 991, DateTimeKind.Utc).AddTicks(1616));

            migrationBuilder.UpdateData(
                table: "Options",
                keyColumn: "Id",
                keyValue: 15L,
                column: "CreatedDate",
                value: new DateTime(2021, 12, 24, 17, 4, 0, 991, DateTimeKind.Utc).AddTicks(1617));

            migrationBuilder.UpdateData(
                table: "Options",
                keyColumn: "Id",
                keyValue: 16L,
                column: "CreatedDate",
                value: new DateTime(2021, 12, 24, 17, 4, 0, 991, DateTimeKind.Utc).AddTicks(1622));

            migrationBuilder.UpdateData(
                table: "Options",
                keyColumn: "Id",
                keyValue: 17L,
                column: "CreatedDate",
                value: new DateTime(2021, 12, 24, 17, 4, 0, 991, DateTimeKind.Utc).AddTicks(1623));

            migrationBuilder.UpdateData(
                table: "Options",
                keyColumn: "Id",
                keyValue: 18L,
                column: "CreatedDate",
                value: new DateTime(2021, 12, 24, 17, 4, 0, 991, DateTimeKind.Utc).AddTicks(1624));

            migrationBuilder.UpdateData(
                table: "Options",
                keyColumn: "Id",
                keyValue: 19L,
                column: "CreatedDate",
                value: new DateTime(2021, 12, 24, 17, 4, 0, 991, DateTimeKind.Utc).AddTicks(1625));

            migrationBuilder.UpdateData(
                table: "Options",
                keyColumn: "Id",
                keyValue: 20L,
                column: "CreatedDate",
                value: new DateTime(2021, 12, 24, 17, 4, 0, 991, DateTimeKind.Utc).AddTicks(1626));

            migrationBuilder.UpdateData(
                table: "Options",
                keyColumn: "Id",
                keyValue: 21L,
                column: "CreatedDate",
                value: new DateTime(2021, 12, 24, 17, 4, 0, 991, DateTimeKind.Utc).AddTicks(1627));

            migrationBuilder.UpdateData(
                table: "Options",
                keyColumn: "Id",
                keyValue: 22L,
                column: "CreatedDate",
                value: new DateTime(2021, 12, 24, 17, 4, 0, 991, DateTimeKind.Utc).AddTicks(1628));

            migrationBuilder.UpdateData(
                table: "Options",
                keyColumn: "Id",
                keyValue: 23L,
                column: "CreatedDate",
                value: new DateTime(2021, 12, 24, 17, 4, 0, 991, DateTimeKind.Utc).AddTicks(1630));

            migrationBuilder.UpdateData(
                table: "Options",
                keyColumn: "Id",
                keyValue: 24L,
                column: "CreatedDate",
                value: new DateTime(2021, 12, 24, 17, 4, 0, 991, DateTimeKind.Utc).AddTicks(1631));

            migrationBuilder.UpdateData(
                table: "Options",
                keyColumn: "Id",
                keyValue: 25L,
                column: "CreatedDate",
                value: new DateTime(2021, 12, 24, 17, 4, 0, 991, DateTimeKind.Utc).AddTicks(1632));

            migrationBuilder.UpdateData(
                table: "Options",
                keyColumn: "Id",
                keyValue: 26L,
                column: "CreatedDate",
                value: new DateTime(2021, 12, 24, 17, 4, 0, 991, DateTimeKind.Utc).AddTicks(1633));

            migrationBuilder.UpdateData(
                table: "Options",
                keyColumn: "Id",
                keyValue: 27L,
                column: "CreatedDate",
                value: new DateTime(2021, 12, 24, 17, 4, 0, 991, DateTimeKind.Utc).AddTicks(1634));

            migrationBuilder.UpdateData(
                table: "Options",
                keyColumn: "Id",
                keyValue: 28L,
                column: "CreatedDate",
                value: new DateTime(2021, 12, 24, 17, 4, 0, 991, DateTimeKind.Utc).AddTicks(1637));

            migrationBuilder.UpdateData(
                table: "Options",
                keyColumn: "Id",
                keyValue: 29L,
                column: "CreatedDate",
                value: new DateTime(2021, 12, 24, 17, 4, 0, 991, DateTimeKind.Utc).AddTicks(1638));

            migrationBuilder.UpdateData(
                table: "Options",
                keyColumn: "Id",
                keyValue: 30L,
                column: "CreatedDate",
                value: new DateTime(2021, 12, 24, 17, 4, 0, 991, DateTimeKind.Utc).AddTicks(1639));

            migrationBuilder.UpdateData(
                table: "Options",
                keyColumn: "Id",
                keyValue: 31L,
                column: "CreatedDate",
                value: new DateTime(2021, 12, 24, 17, 4, 0, 991, DateTimeKind.Utc).AddTicks(1640));

            migrationBuilder.UpdateData(
                table: "Options",
                keyColumn: "Id",
                keyValue: 32L,
                column: "CreatedDate",
                value: new DateTime(2021, 12, 24, 17, 4, 0, 991, DateTimeKind.Utc).AddTicks(1641));

            migrationBuilder.UpdateData(
                table: "Options",
                keyColumn: "Id",
                keyValue: 33L,
                column: "CreatedDate",
                value: new DateTime(2021, 12, 24, 17, 4, 0, 991, DateTimeKind.Utc).AddTicks(1642));

            migrationBuilder.UpdateData(
                table: "Options",
                keyColumn: "Id",
                keyValue: 34L,
                column: "CreatedDate",
                value: new DateTime(2021, 12, 24, 17, 4, 0, 991, DateTimeKind.Utc).AddTicks(1643));

            migrationBuilder.UpdateData(
                table: "Options",
                keyColumn: "Id",
                keyValue: 35L,
                column: "CreatedDate",
                value: new DateTime(2021, 12, 24, 17, 4, 0, 991, DateTimeKind.Utc).AddTicks(1645));

            migrationBuilder.UpdateData(
                table: "Options",
                keyColumn: "Id",
                keyValue: 36L,
                column: "CreatedDate",
                value: new DateTime(2021, 12, 24, 17, 4, 0, 991, DateTimeKind.Utc).AddTicks(1646));

            migrationBuilder.UpdateData(
                table: "Options",
                keyColumn: "Id",
                keyValue: 37L,
                column: "CreatedDate",
                value: new DateTime(2021, 12, 24, 17, 4, 0, 991, DateTimeKind.Utc).AddTicks(1648));

            migrationBuilder.UpdateData(
                table: "Options",
                keyColumn: "Id",
                keyValue: 38L,
                column: "CreatedDate",
                value: new DateTime(2021, 12, 24, 17, 4, 0, 991, DateTimeKind.Utc).AddTicks(1649));

            migrationBuilder.UpdateData(
                table: "Options",
                keyColumn: "Id",
                keyValue: 39L,
                column: "CreatedDate",
                value: new DateTime(2021, 12, 24, 17, 4, 0, 991, DateTimeKind.Utc).AddTicks(1650));

            migrationBuilder.UpdateData(
                table: "Options",
                keyColumn: "Id",
                keyValue: 40L,
                column: "CreatedDate",
                value: new DateTime(2021, 12, 24, 17, 4, 0, 991, DateTimeKind.Utc).AddTicks(1651));

            migrationBuilder.UpdateData(
                table: "Options",
                keyColumn: "Id",
                keyValue: 41L,
                column: "CreatedDate",
                value: new DateTime(2021, 12, 24, 17, 4, 0, 991, DateTimeKind.Utc).AddTicks(1652));

            migrationBuilder.UpdateData(
                table: "Options",
                keyColumn: "Id",
                keyValue: 42L,
                column: "CreatedDate",
                value: new DateTime(2021, 12, 24, 17, 4, 0, 991, DateTimeKind.Utc).AddTicks(1652));

            migrationBuilder.UpdateData(
                table: "Options",
                keyColumn: "Id",
                keyValue: 43L,
                column: "CreatedDate",
                value: new DateTime(2021, 12, 24, 17, 4, 0, 991, DateTimeKind.Utc).AddTicks(1653));

            migrationBuilder.UpdateData(
                table: "Options",
                keyColumn: "Id",
                keyValue: 44L,
                column: "CreatedDate",
                value: new DateTime(2021, 12, 24, 17, 4, 0, 991, DateTimeKind.Utc).AddTicks(2058));

            migrationBuilder.UpdateData(
                table: "Options",
                keyColumn: "Id",
                keyValue: 45L,
                column: "CreatedDate",
                value: new DateTime(2021, 12, 24, 17, 4, 0, 991, DateTimeKind.Utc).AddTicks(2073));

            migrationBuilder.UpdateData(
                table: "Program",
                keyColumn: "Id",
                keyValue: 1L,
                column: "CreatedDate",
                value: new DateTime(2021, 12, 24, 17, 4, 0, 992, DateTimeKind.Utc).AddTicks(2117));

            migrationBuilder.UpdateData(
                table: "Program",
                keyColumn: "Id",
                keyValue: 2L,
                column: "CreatedDate",
                value: new DateTime(2021, 12, 24, 17, 4, 0, 992, DateTimeKind.Utc).AddTicks(2152));

            migrationBuilder.UpdateData(
                table: "Program",
                keyColumn: "Id",
                keyValue: 3L,
                column: "CreatedDate",
                value: new DateTime(2021, 12, 24, 17, 4, 0, 992, DateTimeKind.Utc).AddTicks(2154));

            migrationBuilder.UpdateData(
                table: "Program",
                keyColumn: "Id",
                keyValue: 4L,
                column: "CreatedDate",
                value: new DateTime(2021, 12, 24, 17, 4, 0, 992, DateTimeKind.Utc).AddTicks(2155));

            migrationBuilder.UpdateData(
                table: "Program",
                keyColumn: "Id",
                keyValue: 5L,
                column: "CreatedDate",
                value: new DateTime(2021, 12, 24, 17, 4, 0, 992, DateTimeKind.Utc).AddTicks(2157));

            migrationBuilder.UpdateData(
                table: "Program",
                keyColumn: "Id",
                keyValue: 6L,
                column: "CreatedDate",
                value: new DateTime(2021, 12, 24, 17, 4, 0, 992, DateTimeKind.Utc).AddTicks(2158));

            migrationBuilder.UpdateData(
                table: "ProgramDocument",
                keyColumn: "Id",
                keyValue: 1L,
                column: "CreatedDate",
                value: new DateTime(2021, 12, 24, 17, 4, 0, 992, DateTimeKind.Utc).AddTicks(2306));

            migrationBuilder.UpdateData(
                table: "ProgramDocument",
                keyColumn: "Id",
                keyValue: 2L,
                column: "CreatedDate",
                value: new DateTime(2021, 12, 24, 17, 4, 0, 992, DateTimeKind.Utc).AddTicks(2827));

            migrationBuilder.UpdateData(
                table: "ProgramDocument",
                keyColumn: "Id",
                keyValue: 3L,
                column: "CreatedDate",
                value: new DateTime(2021, 12, 24, 17, 4, 0, 992, DateTimeKind.Utc).AddTicks(2842));

            migrationBuilder.UpdateData(
                table: "ProgramDocument",
                keyColumn: "Id",
                keyValue: 4L,
                column: "CreatedDate",
                value: new DateTime(2021, 12, 24, 17, 4, 0, 992, DateTimeKind.Utc).AddTicks(2843));

            migrationBuilder.UpdateData(
                table: "ProgramDocument",
                keyColumn: "Id",
                keyValue: 5L,
                column: "CreatedDate",
                value: new DateTime(2021, 12, 24, 17, 4, 0, 992, DateTimeKind.Utc).AddTicks(2844));

            migrationBuilder.UpdateData(
                table: "ProgramDocument",
                keyColumn: "Id",
                keyValue: 6L,
                column: "CreatedDate",
                value: new DateTime(2021, 12, 24, 17, 4, 0, 992, DateTimeKind.Utc).AddTicks(2845));

            migrationBuilder.UpdateData(
                table: "ProgramDocument",
                keyColumn: "Id",
                keyValue: 7L,
                column: "CreatedDate",
                value: new DateTime(2021, 12, 24, 17, 4, 0, 992, DateTimeKind.Utc).AddTicks(2846));

            migrationBuilder.UpdateData(
                table: "QuickAssessmentQuestions",
                keyColumn: "Id",
                keyValue: 1L,
                column: "CreatedDate",
                value: new DateTime(2021, 12, 24, 17, 4, 0, 988, DateTimeKind.Utc).AddTicks(3953));

            migrationBuilder.UpdateData(
                table: "QuickAssessmentQuestions",
                keyColumn: "Id",
                keyValue: 2L,
                column: "CreatedDate",
                value: new DateTime(2021, 12, 24, 17, 4, 0, 988, DateTimeKind.Utc).AddTicks(5109));

            migrationBuilder.UpdateData(
                table: "QuickAssessmentQuestions",
                keyColumn: "Id",
                keyValue: 3L,
                column: "CreatedDate",
                value: new DateTime(2021, 12, 24, 17, 4, 0, 988, DateTimeKind.Utc).AddTicks(6194));

            migrationBuilder.UpdateData(
                table: "QuickAssessmentQuestions",
                keyColumn: "Id",
                keyValue: 4L,
                column: "CreatedDate",
                value: new DateTime(2021, 12, 24, 17, 4, 0, 988, DateTimeKind.Utc).AddTicks(7228));

            migrationBuilder.UpdateData(
                table: "QuickAssessmentQuestions",
                keyColumn: "Id",
                keyValue: 5L,
                column: "CreatedDate",
                value: new DateTime(2021, 12, 24, 17, 4, 0, 988, DateTimeKind.Utc).AddTicks(7246));

            migrationBuilder.UpdateData(
                table: "QuickAssessmentQuestions",
                keyColumn: "Id",
                keyValue: 6L,
                column: "CreatedDate",
                value: new DateTime(2021, 12, 24, 17, 4, 0, 988, DateTimeKind.Utc).AddTicks(8400));

            migrationBuilder.UpdateData(
                table: "QuickAssessmentQuestions",
                keyColumn: "Id",
                keyValue: 7L,
                column: "CreatedDate",
                value: new DateTime(2021, 12, 24, 17, 4, 0, 988, DateTimeKind.Utc).AddTicks(9510));

            migrationBuilder.UpdateData(
                table: "QuickAssessmentQuestions",
                keyColumn: "Id",
                keyValue: 8L,
                column: "CreatedDate",
                value: new DateTime(2021, 12, 24, 17, 4, 0, 988, DateTimeKind.Utc).AddTicks(9513));

            migrationBuilder.UpdateData(
                table: "QuickAssessmentQuestions",
                keyColumn: "Id",
                keyValue: 9L,
                column: "CreatedDate",
                value: new DateTime(2021, 12, 24, 17, 4, 0, 989, DateTimeKind.Utc).AddTicks(1322));

            migrationBuilder.UpdateData(
                table: "QuickAssessmentQuestions",
                keyColumn: "Id",
                keyValue: 10L,
                column: "CreatedDate",
                value: new DateTime(2021, 12, 24, 17, 4, 0, 989, DateTimeKind.Utc).AddTicks(1330));

            migrationBuilder.UpdateData(
                table: "QuickAssessmentQuestions",
                keyColumn: "Id",
                keyValue: 11L,
                column: "CreatedDate",
                value: new DateTime(2021, 12, 24, 17, 4, 0, 989, DateTimeKind.Utc).AddTicks(1332));

            migrationBuilder.UpdateData(
                table: "QuickAssessmentQuestions",
                keyColumn: "Id",
                keyValue: 12L,
                column: "CreatedDate",
                value: new DateTime(2021, 12, 24, 17, 4, 0, 989, DateTimeKind.Utc).AddTicks(2597));

            migrationBuilder.UpdateData(
                table: "QuickAssessmentQuestions",
                keyColumn: "Id",
                keyValue: 13L,
                column: "CreatedDate",
                value: new DateTime(2021, 12, 24, 17, 4, 0, 989, DateTimeKind.Utc).AddTicks(2617));

            migrationBuilder.UpdateData(
                table: "QuickAssessmentQuestions",
                keyColumn: "Id",
                keyValue: 14L,
                column: "CreatedDate",
                value: new DateTime(2021, 12, 24, 17, 4, 0, 989, DateTimeKind.Utc).AddTicks(3737));

            migrationBuilder.UpdateData(
                table: "QuickAssessmentQuestions",
                keyColumn: "Id",
                keyValue: 15L,
                column: "CreatedDate",
                value: new DateTime(2021, 12, 24, 17, 4, 0, 989, DateTimeKind.Utc).AddTicks(4590));

            migrationBuilder.UpdateData(
                table: "QuickAssessmentQuestions",
                keyColumn: "Id",
                keyValue: 16L,
                column: "CreatedDate",
                value: new DateTime(2021, 12, 24, 17, 4, 0, 989, DateTimeKind.Utc).AddTicks(5288));

            migrationBuilder.UpdateData(
                table: "QuickAssessmentQuestions",
                keyColumn: "Id",
                keyValue: 17L,
                column: "CreatedDate",
                value: new DateTime(2021, 12, 24, 17, 4, 0, 989, DateTimeKind.Utc).AddTicks(6015));

            migrationBuilder.UpdateData(
                table: "QuickAssessmentQuestions",
                keyColumn: "Id",
                keyValue: 18L,
                column: "CreatedDate",
                value: new DateTime(2021, 12, 24, 17, 4, 0, 989, DateTimeKind.Utc).AddTicks(7018));

            migrationBuilder.UpdateData(
                table: "QuickAssessmentQuestions",
                keyColumn: "Id",
                keyValue: 19L,
                column: "CreatedDate",
                value: new DateTime(2021, 12, 24, 17, 4, 0, 989, DateTimeKind.Utc).AddTicks(7034));

            migrationBuilder.UpdateData(
                table: "QuickAssessmentQuestions",
                keyColumn: "Id",
                keyValue: 20L,
                column: "CreatedDate",
                value: new DateTime(2021, 12, 24, 17, 4, 0, 989, DateTimeKind.Utc).AddTicks(7045));

            migrationBuilder.UpdateData(
                table: "QuickAssessmentQuestions",
                keyColumn: "Id",
                keyValue: 21L,
                column: "CreatedDate",
                value: new DateTime(2021, 12, 24, 17, 4, 0, 989, DateTimeKind.Utc).AddTicks(7997));

            migrationBuilder.UpdateData(
                table: "QuickAssessmentQuestions",
                keyColumn: "Id",
                keyValue: 22L,
                column: "CreatedDate",
                value: new DateTime(2021, 12, 24, 17, 4, 0, 989, DateTimeKind.Utc).AddTicks(8906));

            migrationBuilder.UpdateData(
                table: "QuickAssessmentQuestions",
                keyColumn: "Id",
                keyValue: 23L,
                column: "CreatedDate",
                value: new DateTime(2021, 12, 24, 17, 4, 0, 989, DateTimeKind.Utc).AddTicks(9727));

            migrationBuilder.UpdateData(
                table: "QuickAssessmentQuestions",
                keyColumn: "Id",
                keyValue: 24L,
                column: "CreatedDate",
                value: new DateTime(2021, 12, 24, 17, 4, 0, 990, DateTimeKind.Utc).AddTicks(537));

            migrationBuilder.UpdateData(
                table: "QuickAssessmentQuestions",
                keyColumn: "Id",
                keyValue: 25L,
                column: "CreatedDate",
                value: new DateTime(2021, 12, 24, 17, 4, 0, 990, DateTimeKind.Utc).AddTicks(1711));

            migrationBuilder.UpdateData(
                table: "QuickAssessmentQuestions",
                keyColumn: "Id",
                keyValue: 26L,
                column: "CreatedDate",
                value: new DateTime(2021, 12, 24, 17, 4, 0, 990, DateTimeKind.Utc).AddTicks(2986));

            migrationBuilder.UpdateData(
                table: "QuickAssessmentQuestions",
                keyColumn: "Id",
                keyValue: 27L,
                column: "CreatedDate",
                value: new DateTime(2021, 12, 24, 17, 4, 0, 990, DateTimeKind.Utc).AddTicks(4426));

            migrationBuilder.UpdateData(
                table: "QuickAssessmentQuestions",
                keyColumn: "Id",
                keyValue: 28L,
                column: "CreatedDate",
                value: new DateTime(2021, 12, 24, 17, 4, 0, 990, DateTimeKind.Utc).AddTicks(6553));

            migrationBuilder.UpdateData(
                table: "QuickAssessmentQuestions",
                keyColumn: "Id",
                keyValue: 29L,
                column: "CreatedDate",
                value: new DateTime(2021, 12, 24, 17, 4, 0, 990, DateTimeKind.Utc).AddTicks(7504));

            migrationBuilder.UpdateData(
                table: "QuickAssessmentQuestions",
                keyColumn: "Id",
                keyValue: 30L,
                column: "CreatedDate",
                value: new DateTime(2021, 12, 24, 17, 4, 0, 990, DateTimeKind.Utc).AddTicks(8509));

            migrationBuilder.UpdateData(
                table: "QuickAssessmentQuestions",
                keyColumn: "Id",
                keyValue: 31L,
                column: "CreatedDate",
                value: new DateTime(2021, 12, 24, 17, 4, 0, 990, DateTimeKind.Utc).AddTicks(8528));

            migrationBuilder.UpdateData(
                table: "QuickAssessmentQuestions",
                keyColumn: "Id",
                keyValue: 32L,
                column: "CreatedDate",
                value: new DateTime(2021, 12, 24, 17, 4, 0, 990, DateTimeKind.Utc).AddTicks(9279));

            migrationBuilder.UpdateData(
                table: "QuickAssessmentQuestions",
                keyColumn: "Id",
                keyValue: 33L,
                column: "CreatedDate",
                value: new DateTime(2021, 12, 24, 17, 4, 0, 991, DateTimeKind.Utc).AddTicks(102));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: -1L,
                column: "Password",
                value: "$2a$12$56001hoxpwjvc7QgCp8RluFj.UZY3KfG73HmdjSfFLsA6cLuijsZW");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1L,
                column: "Password",
                value: "$2a$12$uzgfualvAgOGgj3OTEj2Kuco7gZYM06M1ZNY65SThMGtNkZ484W/K");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2L,
                column: "Password",
                value: "$2a$12$t1BYD4oYDcX9mPVhsmXmWOknUYYujT.n68ceD7zJ91aaALtglLTGK");

            migrationBuilder.UpdateData(
                table: "Validators",
                keyColumn: "Id",
                keyValue: 1L,
                column: "CreatedDate",
                value: new DateTime(2021, 12, 24, 17, 4, 0, 991, DateTimeKind.Utc).AddTicks(2230));

            migrationBuilder.UpdateData(
                table: "Validators",
                keyColumn: "Id",
                keyValue: 2L,
                column: "CreatedDate",
                value: new DateTime(2021, 12, 24, 17, 4, 0, 991, DateTimeKind.Utc).AddTicks(2758));

            migrationBuilder.UpdateData(
                table: "Validators",
                keyColumn: "Id",
                keyValue: 3L,
                column: "CreatedDate",
                value: new DateTime(2021, 12, 24, 17, 4, 0, 991, DateTimeKind.Utc).AddTicks(3643));

            migrationBuilder.UpdateData(
                table: "Validators",
                keyColumn: "Id",
                keyValue: 4L,
                column: "CreatedDate",
                value: new DateTime(2021, 12, 24, 17, 4, 0, 991, DateTimeKind.Utc).AddTicks(3657));

            migrationBuilder.UpdateData(
                table: "Validators",
                keyColumn: "Id",
                keyValue: 5L,
                column: "CreatedDate",
                value: new DateTime(2021, 12, 24, 17, 4, 0, 991, DateTimeKind.Utc).AddTicks(3659));

            migrationBuilder.UpdateData(
                table: "Validators",
                keyColumn: "Id",
                keyValue: 6L,
                column: "CreatedDate",
                value: new DateTime(2021, 12, 24, 17, 4, 0, 991, DateTimeKind.Utc).AddTicks(3668));

            migrationBuilder.UpdateData(
                table: "Validators",
                keyColumn: "Id",
                keyValue: 7L,
                column: "CreatedDate",
                value: new DateTime(2021, 12, 24, 17, 4, 0, 991, DateTimeKind.Utc).AddTicks(3669));

            migrationBuilder.UpdateData(
                table: "Validators",
                keyColumn: "Id",
                keyValue: 8L,
                column: "CreatedDate",
                value: new DateTime(2021, 12, 24, 17, 4, 0, 991, DateTimeKind.Utc).AddTicks(3670));

            migrationBuilder.UpdateData(
                table: "Validators",
                keyColumn: "Id",
                keyValue: 9L,
                column: "CreatedDate",
                value: new DateTime(2021, 12, 24, 17, 4, 0, 991, DateTimeKind.Utc).AddTicks(3671));

            migrationBuilder.UpdateData(
                table: "Validators",
                keyColumn: "Id",
                keyValue: 10L,
                column: "CreatedDate",
                value: new DateTime(2021, 12, 24, 17, 4, 0, 991, DateTimeKind.Utc).AddTicks(3674));

            migrationBuilder.UpdateData(
                table: "Validators",
                keyColumn: "Id",
                keyValue: 11L,
                column: "CreatedDate",
                value: new DateTime(2021, 12, 24, 17, 4, 0, 991, DateTimeKind.Utc).AddTicks(3675));

            migrationBuilder.UpdateData(
                table: "Validators",
                keyColumn: "Id",
                keyValue: 12L,
                column: "CreatedDate",
                value: new DateTime(2021, 12, 24, 17, 4, 0, 991, DateTimeKind.Utc).AddTicks(3676));

            migrationBuilder.UpdateData(
                table: "Validators",
                keyColumn: "Id",
                keyValue: 13L,
                column: "CreatedDate",
                value: new DateTime(2021, 12, 24, 17, 4, 0, 991, DateTimeKind.Utc).AddTicks(3677));

            migrationBuilder.UpdateData(
                table: "Validators",
                keyColumn: "Id",
                keyValue: 14L,
                column: "CreatedDate",
                value: new DateTime(2021, 12, 24, 17, 4, 0, 991, DateTimeKind.Utc).AddTicks(3678));

            migrationBuilder.UpdateData(
                table: "Validators",
                keyColumn: "Id",
                keyValue: 15L,
                column: "CreatedDate",
                value: new DateTime(2021, 12, 24, 17, 4, 0, 991, DateTimeKind.Utc).AddTicks(3679));

            migrationBuilder.UpdateData(
                table: "Validators",
                keyColumn: "Id",
                keyValue: 16L,
                column: "CreatedDate",
                value: new DateTime(2021, 12, 24, 17, 4, 0, 991, DateTimeKind.Utc).AddTicks(3680));

            migrationBuilder.UpdateData(
                table: "Validators",
                keyColumn: "Id",
                keyValue: 17L,
                column: "CreatedDate",
                value: new DateTime(2021, 12, 24, 17, 4, 0, 991, DateTimeKind.Utc).AddTicks(3682));

            migrationBuilder.UpdateData(
                table: "Validators",
                keyColumn: "Id",
                keyValue: 18L,
                column: "CreatedDate",
                value: new DateTime(2021, 12, 24, 17, 4, 0, 991, DateTimeKind.Utc).AddTicks(3683));

            migrationBuilder.UpdateData(
                table: "Validators",
                keyColumn: "Id",
                keyValue: 19L,
                column: "CreatedDate",
                value: new DateTime(2021, 12, 24, 17, 4, 0, 991, DateTimeKind.Utc).AddTicks(3684));

            migrationBuilder.UpdateData(
                table: "Validators",
                keyColumn: "Id",
                keyValue: 20L,
                column: "CreatedDate",
                value: new DateTime(2021, 12, 24, 17, 4, 0, 991, DateTimeKind.Utc).AddTicks(3685));

            migrationBuilder.UpdateData(
                table: "Validators",
                keyColumn: "Id",
                keyValue: 21L,
                column: "CreatedDate",
                value: new DateTime(2021, 12, 24, 17, 4, 0, 991, DateTimeKind.Utc).AddTicks(3686));

            migrationBuilder.UpdateData(
                table: "Validators",
                keyColumn: "Id",
                keyValue: 22L,
                column: "CreatedDate",
                value: new DateTime(2021, 12, 24, 17, 4, 0, 991, DateTimeKind.Utc).AddTicks(3687));

            migrationBuilder.UpdateData(
                table: "Validators",
                keyColumn: "Id",
                keyValue: 23L,
                column: "CreatedDate",
                value: new DateTime(2021, 12, 24, 17, 4, 0, 991, DateTimeKind.Utc).AddTicks(3688));

            migrationBuilder.UpdateData(
                table: "Validators",
                keyColumn: "Id",
                keyValue: 24L,
                column: "CreatedDate",
                value: new DateTime(2021, 12, 24, 17, 4, 0, 991, DateTimeKind.Utc).AddTicks(3689));

            migrationBuilder.UpdateData(
                table: "Validators",
                keyColumn: "Id",
                keyValue: 25L,
                column: "CreatedDate",
                value: new DateTime(2021, 12, 24, 17, 4, 0, 991, DateTimeKind.Utc).AddTicks(3690));

            migrationBuilder.UpdateData(
                table: "Validators",
                keyColumn: "Id",
                keyValue: 26L,
                column: "CreatedDate",
                value: new DateTime(2021, 12, 24, 17, 4, 0, 991, DateTimeKind.Utc).AddTicks(3691));

            migrationBuilder.UpdateData(
                table: "Validators",
                keyColumn: "Id",
                keyValue: 27L,
                column: "CreatedDate",
                value: new DateTime(2021, 12, 24, 17, 4, 0, 991, DateTimeKind.Utc).AddTicks(3692));

            migrationBuilder.UpdateData(
                table: "Validators",
                keyColumn: "Id",
                keyValue: 28L,
                column: "CreatedDate",
                value: new DateTime(2021, 12, 24, 17, 4, 0, 991, DateTimeKind.Utc).AddTicks(3693));

            migrationBuilder.UpdateData(
                table: "Validators",
                keyColumn: "Id",
                keyValue: 29L,
                column: "CreatedDate",
                value: new DateTime(2021, 12, 24, 17, 4, 0, 991, DateTimeKind.Utc).AddTicks(3694));

            migrationBuilder.UpdateData(
                table: "Validators",
                keyColumn: "Id",
                keyValue: 30L,
                column: "CreatedDate",
                value: new DateTime(2021, 12, 24, 17, 4, 0, 991, DateTimeKind.Utc).AddTicks(3695));

            migrationBuilder.UpdateData(
                table: "Validators",
                keyColumn: "Id",
                keyValue: 31L,
                column: "CreatedDate",
                value: new DateTime(2021, 12, 24, 17, 4, 0, 991, DateTimeKind.Utc).AddTicks(3696));

            migrationBuilder.UpdateData(
                table: "Validators",
                keyColumn: "Id",
                keyValue: 32L,
                column: "CreatedDate",
                value: new DateTime(2021, 12, 24, 17, 4, 0, 991, DateTimeKind.Utc).AddTicks(3697));

            migrationBuilder.AddForeignKey(
                name: "FK_Document_DocumentTypeMaster_DocumentTypeMasterId",
                table: "Document",
                column: "DocumentTypeMasterId",
                principalTable: "DocumentTypeMaster",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Document_DocumentTypeMaster_DocumentTypeMasterId",
                table: "Document");

            migrationBuilder.DropColumn(
                name: "Cell",
                table: "AssessmentInPatientDashboard");

            migrationBuilder.DropColumn(
                name: "CountyCode",
                table: "AssessmentInPatientDashboard");

            migrationBuilder.RenameColumn(
                name: "DocumentTypeMasterId",
                table: "Document",
                newName: "DocumentCategoryDocumentTypeMappingId");

            migrationBuilder.RenameIndex(
                name: "IX_Document_DocumentTypeMasterId",
                table: "Document",
                newName: "IX_Document_DocumentCategoryDocumentTypeMappingId");

            migrationBuilder.UpdateData(
                table: "DynamicScreens",
                keyColumn: "Id",
                keyValue: 1L,
                column: "CreatedDate",
                value: new DateTime(2021, 12, 23, 10, 21, 20, 688, DateTimeKind.Utc).AddTicks(395));

            migrationBuilder.UpdateData(
                table: "DynamicScreens",
                keyColumn: "Id",
                keyValue: 2L,
                column: "CreatedDate",
                value: new DateTime(2021, 12, 23, 10, 21, 20, 688, DateTimeKind.Utc).AddTicks(719));

            migrationBuilder.UpdateData(
                table: "DynamicScreens",
                keyColumn: "Id",
                keyValue: 3L,
                column: "CreatedDate",
                value: new DateTime(2021, 12, 23, 10, 21, 20, 688, DateTimeKind.Utc).AddTicks(737));

            migrationBuilder.UpdateData(
                table: "DynamicScreens",
                keyColumn: "Id",
                keyValue: 4L,
                column: "CreatedDate",
                value: new DateTime(2021, 12, 23, 10, 21, 20, 688, DateTimeKind.Utc).AddTicks(739));

            migrationBuilder.UpdateData(
                table: "DynamicScreens",
                keyColumn: "Id",
                keyValue: 5L,
                column: "CreatedDate",
                value: new DateTime(2021, 12, 23, 10, 21, 20, 688, DateTimeKind.Utc).AddTicks(741));

            migrationBuilder.UpdateData(
                table: "DynamicScreens",
                keyColumn: "Id",
                keyValue: 6L,
                column: "CreatedDate",
                value: new DateTime(2021, 12, 23, 10, 21, 20, 688, DateTimeKind.Utc).AddTicks(742));

            migrationBuilder.UpdateData(
                table: "DynamicScreens",
                keyColumn: "Id",
                keyValue: 7L,
                column: "CreatedDate",
                value: new DateTime(2021, 12, 23, 10, 21, 20, 688, DateTimeKind.Utc).AddTicks(743));

            migrationBuilder.UpdateData(
                table: "DynamicScreens",
                keyColumn: "Id",
                keyValue: 8L,
                column: "CreatedDate",
                value: new DateTime(2021, 12, 23, 10, 21, 20, 688, DateTimeKind.Utc).AddTicks(745));

            migrationBuilder.UpdateData(
                table: "DynamicScreens",
                keyColumn: "Id",
                keyValue: 9L,
                column: "CreatedDate",
                value: new DateTime(2021, 12, 23, 10, 21, 20, 688, DateTimeKind.Utc).AddTicks(746));

            migrationBuilder.UpdateData(
                table: "DynamicScreens",
                keyColumn: "Id",
                keyValue: 10L,
                column: "CreatedDate",
                value: new DateTime(2021, 12, 23, 10, 21, 20, 688, DateTimeKind.Utc).AddTicks(747));

            migrationBuilder.UpdateData(
                table: "DynamicScreens",
                keyColumn: "Id",
                keyValue: 11L,
                column: "CreatedDate",
                value: new DateTime(2021, 12, 23, 10, 21, 20, 688, DateTimeKind.Utc).AddTicks(748));

            migrationBuilder.UpdateData(
                table: "Options",
                keyColumn: "Id",
                keyValue: 1L,
                column: "CreatedDate",
                value: new DateTime(2021, 12, 23, 10, 21, 20, 690, DateTimeKind.Utc).AddTicks(3139));

            migrationBuilder.UpdateData(
                table: "Options",
                keyColumn: "Id",
                keyValue: 2L,
                column: "CreatedDate",
                value: new DateTime(2021, 12, 23, 10, 21, 20, 690, DateTimeKind.Utc).AddTicks(3599));

            migrationBuilder.UpdateData(
                table: "Options",
                keyColumn: "Id",
                keyValue: 3L,
                column: "CreatedDate",
                value: new DateTime(2021, 12, 23, 10, 21, 20, 690, DateTimeKind.Utc).AddTicks(3612));

            migrationBuilder.UpdateData(
                table: "Options",
                keyColumn: "Id",
                keyValue: 4L,
                column: "CreatedDate",
                value: new DateTime(2021, 12, 23, 10, 21, 20, 690, DateTimeKind.Utc).AddTicks(3614));

            migrationBuilder.UpdateData(
                table: "Options",
                keyColumn: "Id",
                keyValue: 5L,
                column: "CreatedDate",
                value: new DateTime(2021, 12, 23, 10, 21, 20, 690, DateTimeKind.Utc).AddTicks(3615));

            migrationBuilder.UpdateData(
                table: "Options",
                keyColumn: "Id",
                keyValue: 6L,
                column: "CreatedDate",
                value: new DateTime(2021, 12, 23, 10, 21, 20, 690, DateTimeKind.Utc).AddTicks(3616));

            migrationBuilder.UpdateData(
                table: "Options",
                keyColumn: "Id",
                keyValue: 7L,
                column: "CreatedDate",
                value: new DateTime(2021, 12, 23, 10, 21, 20, 690, DateTimeKind.Utc).AddTicks(3617));

            migrationBuilder.UpdateData(
                table: "Options",
                keyColumn: "Id",
                keyValue: 8L,
                column: "CreatedDate",
                value: new DateTime(2021, 12, 23, 10, 21, 20, 690, DateTimeKind.Utc).AddTicks(3618));

            migrationBuilder.UpdateData(
                table: "Options",
                keyColumn: "Id",
                keyValue: 9L,
                column: "CreatedDate",
                value: new DateTime(2021, 12, 23, 10, 21, 20, 690, DateTimeKind.Utc).AddTicks(3619));

            migrationBuilder.UpdateData(
                table: "Options",
                keyColumn: "Id",
                keyValue: 10L,
                column: "CreatedDate",
                value: new DateTime(2021, 12, 23, 10, 21, 20, 690, DateTimeKind.Utc).AddTicks(3621));

            migrationBuilder.UpdateData(
                table: "Options",
                keyColumn: "Id",
                keyValue: 11L,
                column: "CreatedDate",
                value: new DateTime(2021, 12, 23, 10, 21, 20, 690, DateTimeKind.Utc).AddTicks(3623));

            migrationBuilder.UpdateData(
                table: "Options",
                keyColumn: "Id",
                keyValue: 12L,
                column: "CreatedDate",
                value: new DateTime(2021, 12, 23, 10, 21, 20, 690, DateTimeKind.Utc).AddTicks(3624));

            migrationBuilder.UpdateData(
                table: "Options",
                keyColumn: "Id",
                keyValue: 13L,
                column: "CreatedDate",
                value: new DateTime(2021, 12, 23, 10, 21, 20, 690, DateTimeKind.Utc).AddTicks(3625));

            migrationBuilder.UpdateData(
                table: "Options",
                keyColumn: "Id",
                keyValue: 14L,
                column: "CreatedDate",
                value: new DateTime(2021, 12, 23, 10, 21, 20, 690, DateTimeKind.Utc).AddTicks(3626));

            migrationBuilder.UpdateData(
                table: "Options",
                keyColumn: "Id",
                keyValue: 15L,
                column: "CreatedDate",
                value: new DateTime(2021, 12, 23, 10, 21, 20, 690, DateTimeKind.Utc).AddTicks(3628));

            migrationBuilder.UpdateData(
                table: "Options",
                keyColumn: "Id",
                keyValue: 16L,
                column: "CreatedDate",
                value: new DateTime(2021, 12, 23, 10, 21, 20, 690, DateTimeKind.Utc).AddTicks(3629));

            migrationBuilder.UpdateData(
                table: "Options",
                keyColumn: "Id",
                keyValue: 17L,
                column: "CreatedDate",
                value: new DateTime(2021, 12, 23, 10, 21, 20, 690, DateTimeKind.Utc).AddTicks(3630));

            migrationBuilder.UpdateData(
                table: "Options",
                keyColumn: "Id",
                keyValue: 18L,
                column: "CreatedDate",
                value: new DateTime(2021, 12, 23, 10, 21, 20, 690, DateTimeKind.Utc).AddTicks(3631));

            migrationBuilder.UpdateData(
                table: "Options",
                keyColumn: "Id",
                keyValue: 19L,
                column: "CreatedDate",
                value: new DateTime(2021, 12, 23, 10, 21, 20, 690, DateTimeKind.Utc).AddTicks(3633));

            migrationBuilder.UpdateData(
                table: "Options",
                keyColumn: "Id",
                keyValue: 20L,
                column: "CreatedDate",
                value: new DateTime(2021, 12, 23, 10, 21, 20, 690, DateTimeKind.Utc).AddTicks(3634));

            migrationBuilder.UpdateData(
                table: "Options",
                keyColumn: "Id",
                keyValue: 21L,
                column: "CreatedDate",
                value: new DateTime(2021, 12, 23, 10, 21, 20, 690, DateTimeKind.Utc).AddTicks(3636));

            migrationBuilder.UpdateData(
                table: "Options",
                keyColumn: "Id",
                keyValue: 22L,
                column: "CreatedDate",
                value: new DateTime(2021, 12, 23, 10, 21, 20, 690, DateTimeKind.Utc).AddTicks(3638));

            migrationBuilder.UpdateData(
                table: "Options",
                keyColumn: "Id",
                keyValue: 23L,
                column: "CreatedDate",
                value: new DateTime(2021, 12, 23, 10, 21, 20, 690, DateTimeKind.Utc).AddTicks(3639));

            migrationBuilder.UpdateData(
                table: "Options",
                keyColumn: "Id",
                keyValue: 24L,
                column: "CreatedDate",
                value: new DateTime(2021, 12, 23, 10, 21, 20, 690, DateTimeKind.Utc).AddTicks(3640));

            migrationBuilder.UpdateData(
                table: "Options",
                keyColumn: "Id",
                keyValue: 25L,
                column: "CreatedDate",
                value: new DateTime(2021, 12, 23, 10, 21, 20, 690, DateTimeKind.Utc).AddTicks(3641));

            migrationBuilder.UpdateData(
                table: "Options",
                keyColumn: "Id",
                keyValue: 26L,
                column: "CreatedDate",
                value: new DateTime(2021, 12, 23, 10, 21, 20, 690, DateTimeKind.Utc).AddTicks(3642));

            migrationBuilder.UpdateData(
                table: "Options",
                keyColumn: "Id",
                keyValue: 27L,
                column: "CreatedDate",
                value: new DateTime(2021, 12, 23, 10, 21, 20, 690, DateTimeKind.Utc).AddTicks(3643));

            migrationBuilder.UpdateData(
                table: "Options",
                keyColumn: "Id",
                keyValue: 28L,
                column: "CreatedDate",
                value: new DateTime(2021, 12, 23, 10, 21, 20, 690, DateTimeKind.Utc).AddTicks(3644));

            migrationBuilder.UpdateData(
                table: "Options",
                keyColumn: "Id",
                keyValue: 29L,
                column: "CreatedDate",
                value: new DateTime(2021, 12, 23, 10, 21, 20, 690, DateTimeKind.Utc).AddTicks(3645));

            migrationBuilder.UpdateData(
                table: "Options",
                keyColumn: "Id",
                keyValue: 30L,
                column: "CreatedDate",
                value: new DateTime(2021, 12, 23, 10, 21, 20, 690, DateTimeKind.Utc).AddTicks(3646));

            migrationBuilder.UpdateData(
                table: "Options",
                keyColumn: "Id",
                keyValue: 31L,
                column: "CreatedDate",
                value: new DateTime(2021, 12, 23, 10, 21, 20, 690, DateTimeKind.Utc).AddTicks(3647));

            migrationBuilder.UpdateData(
                table: "Options",
                keyColumn: "Id",
                keyValue: 32L,
                column: "CreatedDate",
                value: new DateTime(2021, 12, 23, 10, 21, 20, 690, DateTimeKind.Utc).AddTicks(3648));

            migrationBuilder.UpdateData(
                table: "Options",
                keyColumn: "Id",
                keyValue: 33L,
                column: "CreatedDate",
                value: new DateTime(2021, 12, 23, 10, 21, 20, 690, DateTimeKind.Utc).AddTicks(3649));

            migrationBuilder.UpdateData(
                table: "Options",
                keyColumn: "Id",
                keyValue: 34L,
                column: "CreatedDate",
                value: new DateTime(2021, 12, 23, 10, 21, 20, 690, DateTimeKind.Utc).AddTicks(3651));

            migrationBuilder.UpdateData(
                table: "Options",
                keyColumn: "Id",
                keyValue: 35L,
                column: "CreatedDate",
                value: new DateTime(2021, 12, 23, 10, 21, 20, 690, DateTimeKind.Utc).AddTicks(3651));

            migrationBuilder.UpdateData(
                table: "Options",
                keyColumn: "Id",
                keyValue: 36L,
                column: "CreatedDate",
                value: new DateTime(2021, 12, 23, 10, 21, 20, 690, DateTimeKind.Utc).AddTicks(3652));

            migrationBuilder.UpdateData(
                table: "Options",
                keyColumn: "Id",
                keyValue: 37L,
                column: "CreatedDate",
                value: new DateTime(2021, 12, 23, 10, 21, 20, 690, DateTimeKind.Utc).AddTicks(3654));

            migrationBuilder.UpdateData(
                table: "Options",
                keyColumn: "Id",
                keyValue: 38L,
                column: "CreatedDate",
                value: new DateTime(2021, 12, 23, 10, 21, 20, 690, DateTimeKind.Utc).AddTicks(3655));

            migrationBuilder.UpdateData(
                table: "Options",
                keyColumn: "Id",
                keyValue: 39L,
                column: "CreatedDate",
                value: new DateTime(2021, 12, 23, 10, 21, 20, 690, DateTimeKind.Utc).AddTicks(3656));

            migrationBuilder.UpdateData(
                table: "Options",
                keyColumn: "Id",
                keyValue: 40L,
                column: "CreatedDate",
                value: new DateTime(2021, 12, 23, 10, 21, 20, 690, DateTimeKind.Utc).AddTicks(3657));

            migrationBuilder.UpdateData(
                table: "Options",
                keyColumn: "Id",
                keyValue: 41L,
                column: "CreatedDate",
                value: new DateTime(2021, 12, 23, 10, 21, 20, 690, DateTimeKind.Utc).AddTicks(3658));

            migrationBuilder.UpdateData(
                table: "Options",
                keyColumn: "Id",
                keyValue: 42L,
                column: "CreatedDate",
                value: new DateTime(2021, 12, 23, 10, 21, 20, 690, DateTimeKind.Utc).AddTicks(3659));

            migrationBuilder.UpdateData(
                table: "Options",
                keyColumn: "Id",
                keyValue: 43L,
                column: "CreatedDate",
                value: new DateTime(2021, 12, 23, 10, 21, 20, 690, DateTimeKind.Utc).AddTicks(3659));

            migrationBuilder.UpdateData(
                table: "Options",
                keyColumn: "Id",
                keyValue: 44L,
                column: "CreatedDate",
                value: new DateTime(2021, 12, 23, 10, 21, 20, 690, DateTimeKind.Utc).AddTicks(4026));

            migrationBuilder.UpdateData(
                table: "Options",
                keyColumn: "Id",
                keyValue: 45L,
                column: "CreatedDate",
                value: new DateTime(2021, 12, 23, 10, 21, 20, 690, DateTimeKind.Utc).AddTicks(4037));

            migrationBuilder.UpdateData(
                table: "Program",
                keyColumn: "Id",
                keyValue: 1L,
                column: "CreatedDate",
                value: new DateTime(2021, 12, 23, 10, 21, 20, 691, DateTimeKind.Utc).AddTicks(2705));

            migrationBuilder.UpdateData(
                table: "Program",
                keyColumn: "Id",
                keyValue: 2L,
                column: "CreatedDate",
                value: new DateTime(2021, 12, 23, 10, 21, 20, 691, DateTimeKind.Utc).AddTicks(2736));

            migrationBuilder.UpdateData(
                table: "Program",
                keyColumn: "Id",
                keyValue: 3L,
                column: "CreatedDate",
                value: new DateTime(2021, 12, 23, 10, 21, 20, 691, DateTimeKind.Utc).AddTicks(2738));

            migrationBuilder.UpdateData(
                table: "Program",
                keyColumn: "Id",
                keyValue: 4L,
                column: "CreatedDate",
                value: new DateTime(2021, 12, 23, 10, 21, 20, 691, DateTimeKind.Utc).AddTicks(2739));

            migrationBuilder.UpdateData(
                table: "Program",
                keyColumn: "Id",
                keyValue: 5L,
                column: "CreatedDate",
                value: new DateTime(2021, 12, 23, 10, 21, 20, 691, DateTimeKind.Utc).AddTicks(2740));

            migrationBuilder.UpdateData(
                table: "Program",
                keyColumn: "Id",
                keyValue: 6L,
                column: "CreatedDate",
                value: new DateTime(2021, 12, 23, 10, 21, 20, 691, DateTimeKind.Utc).AddTicks(2741));

            migrationBuilder.UpdateData(
                table: "ProgramDocument",
                keyColumn: "Id",
                keyValue: 1L,
                column: "CreatedDate",
                value: new DateTime(2021, 12, 23, 10, 21, 20, 691, DateTimeKind.Utc).AddTicks(2906));

            migrationBuilder.UpdateData(
                table: "ProgramDocument",
                keyColumn: "Id",
                keyValue: 2L,
                column: "CreatedDate",
                value: new DateTime(2021, 12, 23, 10, 21, 20, 691, DateTimeKind.Utc).AddTicks(3363));

            migrationBuilder.UpdateData(
                table: "ProgramDocument",
                keyColumn: "Id",
                keyValue: 3L,
                column: "CreatedDate",
                value: new DateTime(2021, 12, 23, 10, 21, 20, 691, DateTimeKind.Utc).AddTicks(3375));

            migrationBuilder.UpdateData(
                table: "ProgramDocument",
                keyColumn: "Id",
                keyValue: 4L,
                column: "CreatedDate",
                value: new DateTime(2021, 12, 23, 10, 21, 20, 691, DateTimeKind.Utc).AddTicks(3376));

            migrationBuilder.UpdateData(
                table: "ProgramDocument",
                keyColumn: "Id",
                keyValue: 5L,
                column: "CreatedDate",
                value: new DateTime(2021, 12, 23, 10, 21, 20, 691, DateTimeKind.Utc).AddTicks(3377));

            migrationBuilder.UpdateData(
                table: "ProgramDocument",
                keyColumn: "Id",
                keyValue: 6L,
                column: "CreatedDate",
                value: new DateTime(2021, 12, 23, 10, 21, 20, 691, DateTimeKind.Utc).AddTicks(3378));

            migrationBuilder.UpdateData(
                table: "ProgramDocument",
                keyColumn: "Id",
                keyValue: 7L,
                column: "CreatedDate",
                value: new DateTime(2021, 12, 23, 10, 21, 20, 691, DateTimeKind.Utc).AddTicks(3379));

            migrationBuilder.UpdateData(
                table: "QuickAssessmentQuestions",
                keyColumn: "Id",
                keyValue: 1L,
                column: "CreatedDate",
                value: new DateTime(2021, 12, 23, 10, 21, 20, 688, DateTimeKind.Utc).AddTicks(983));

            migrationBuilder.UpdateData(
                table: "QuickAssessmentQuestions",
                keyColumn: "Id",
                keyValue: 2L,
                column: "CreatedDate",
                value: new DateTime(2021, 12, 23, 10, 21, 20, 688, DateTimeKind.Utc).AddTicks(2356));

            migrationBuilder.UpdateData(
                table: "QuickAssessmentQuestions",
                keyColumn: "Id",
                keyValue: 3L,
                column: "CreatedDate",
                value: new DateTime(2021, 12, 23, 10, 21, 20, 688, DateTimeKind.Utc).AddTicks(3292));

            migrationBuilder.UpdateData(
                table: "QuickAssessmentQuestions",
                keyColumn: "Id",
                keyValue: 4L,
                column: "CreatedDate",
                value: new DateTime(2021, 12, 23, 10, 21, 20, 688, DateTimeKind.Utc).AddTicks(4113));

            migrationBuilder.UpdateData(
                table: "QuickAssessmentQuestions",
                keyColumn: "Id",
                keyValue: 5L,
                column: "CreatedDate",
                value: new DateTime(2021, 12, 23, 10, 21, 20, 688, DateTimeKind.Utc).AddTicks(4129));

            migrationBuilder.UpdateData(
                table: "QuickAssessmentQuestions",
                keyColumn: "Id",
                keyValue: 6L,
                column: "CreatedDate",
                value: new DateTime(2021, 12, 23, 10, 21, 20, 688, DateTimeKind.Utc).AddTicks(5091));

            migrationBuilder.UpdateData(
                table: "QuickAssessmentQuestions",
                keyColumn: "Id",
                keyValue: 7L,
                column: "CreatedDate",
                value: new DateTime(2021, 12, 23, 10, 21, 20, 688, DateTimeKind.Utc).AddTicks(6014));

            migrationBuilder.UpdateData(
                table: "QuickAssessmentQuestions",
                keyColumn: "Id",
                keyValue: 8L,
                column: "CreatedDate",
                value: new DateTime(2021, 12, 23, 10, 21, 20, 688, DateTimeKind.Utc).AddTicks(6016));

            migrationBuilder.UpdateData(
                table: "QuickAssessmentQuestions",
                keyColumn: "Id",
                keyValue: 9L,
                column: "CreatedDate",
                value: new DateTime(2021, 12, 23, 10, 21, 20, 688, DateTimeKind.Utc).AddTicks(7351));

            migrationBuilder.UpdateData(
                table: "QuickAssessmentQuestions",
                keyColumn: "Id",
                keyValue: 10L,
                column: "CreatedDate",
                value: new DateTime(2021, 12, 23, 10, 21, 20, 688, DateTimeKind.Utc).AddTicks(7356));

            migrationBuilder.UpdateData(
                table: "QuickAssessmentQuestions",
                keyColumn: "Id",
                keyValue: 11L,
                column: "CreatedDate",
                value: new DateTime(2021, 12, 23, 10, 21, 20, 688, DateTimeKind.Utc).AddTicks(7357));

            migrationBuilder.UpdateData(
                table: "QuickAssessmentQuestions",
                keyColumn: "Id",
                keyValue: 12L,
                column: "CreatedDate",
                value: new DateTime(2021, 12, 23, 10, 21, 20, 688, DateTimeKind.Utc).AddTicks(8166));

            migrationBuilder.UpdateData(
                table: "QuickAssessmentQuestions",
                keyColumn: "Id",
                keyValue: 13L,
                column: "CreatedDate",
                value: new DateTime(2021, 12, 23, 10, 21, 20, 688, DateTimeKind.Utc).AddTicks(8183));

            migrationBuilder.UpdateData(
                table: "QuickAssessmentQuestions",
                keyColumn: "Id",
                keyValue: 14L,
                column: "CreatedDate",
                value: new DateTime(2021, 12, 23, 10, 21, 20, 688, DateTimeKind.Utc).AddTicks(9129));

            migrationBuilder.UpdateData(
                table: "QuickAssessmentQuestions",
                keyColumn: "Id",
                keyValue: 15L,
                column: "CreatedDate",
                value: new DateTime(2021, 12, 23, 10, 21, 20, 688, DateTimeKind.Utc).AddTicks(9885));

            migrationBuilder.UpdateData(
                table: "QuickAssessmentQuestions",
                keyColumn: "Id",
                keyValue: 16L,
                column: "CreatedDate",
                value: new DateTime(2021, 12, 23, 10, 21, 20, 689, DateTimeKind.Utc).AddTicks(525));

            migrationBuilder.UpdateData(
                table: "QuickAssessmentQuestions",
                keyColumn: "Id",
                keyValue: 17L,
                column: "CreatedDate",
                value: new DateTime(2021, 12, 23, 10, 21, 20, 689, DateTimeKind.Utc).AddTicks(1193));

            migrationBuilder.UpdateData(
                table: "QuickAssessmentQuestions",
                keyColumn: "Id",
                keyValue: 18L,
                column: "CreatedDate",
                value: new DateTime(2021, 12, 23, 10, 21, 20, 689, DateTimeKind.Utc).AddTicks(2122));

            migrationBuilder.UpdateData(
                table: "QuickAssessmentQuestions",
                keyColumn: "Id",
                keyValue: 19L,
                column: "CreatedDate",
                value: new DateTime(2021, 12, 23, 10, 21, 20, 689, DateTimeKind.Utc).AddTicks(2136));

            migrationBuilder.UpdateData(
                table: "QuickAssessmentQuestions",
                keyColumn: "Id",
                keyValue: 20L,
                column: "CreatedDate",
                value: new DateTime(2021, 12, 23, 10, 21, 20, 689, DateTimeKind.Utc).AddTicks(2138));

            migrationBuilder.UpdateData(
                table: "QuickAssessmentQuestions",
                keyColumn: "Id",
                keyValue: 21L,
                column: "CreatedDate",
                value: new DateTime(2021, 12, 23, 10, 21, 20, 689, DateTimeKind.Utc).AddTicks(3072));

            migrationBuilder.UpdateData(
                table: "QuickAssessmentQuestions",
                keyColumn: "Id",
                keyValue: 22L,
                column: "CreatedDate",
                value: new DateTime(2021, 12, 23, 10, 21, 20, 689, DateTimeKind.Utc).AddTicks(3885));

            migrationBuilder.UpdateData(
                table: "QuickAssessmentQuestions",
                keyColumn: "Id",
                keyValue: 23L,
                column: "CreatedDate",
                value: new DateTime(2021, 12, 23, 10, 21, 20, 689, DateTimeKind.Utc).AddTicks(4620));

            migrationBuilder.UpdateData(
                table: "QuickAssessmentQuestions",
                keyColumn: "Id",
                keyValue: 24L,
                column: "CreatedDate",
                value: new DateTime(2021, 12, 23, 10, 21, 20, 689, DateTimeKind.Utc).AddTicks(5306));

            migrationBuilder.UpdateData(
                table: "QuickAssessmentQuestions",
                keyColumn: "Id",
                keyValue: 25L,
                column: "CreatedDate",
                value: new DateTime(2021, 12, 23, 10, 21, 20, 689, DateTimeKind.Utc).AddTicks(6091));

            migrationBuilder.UpdateData(
                table: "QuickAssessmentQuestions",
                keyColumn: "Id",
                keyValue: 26L,
                column: "CreatedDate",
                value: new DateTime(2021, 12, 23, 10, 21, 20, 689, DateTimeKind.Utc).AddTicks(7312));

            migrationBuilder.UpdateData(
                table: "QuickAssessmentQuestions",
                keyColumn: "Id",
                keyValue: 27L,
                column: "CreatedDate",
                value: new DateTime(2021, 12, 23, 10, 21, 20, 689, DateTimeKind.Utc).AddTicks(8167));

            migrationBuilder.UpdateData(
                table: "QuickAssessmentQuestions",
                keyColumn: "Id",
                keyValue: 28L,
                column: "CreatedDate",
                value: new DateTime(2021, 12, 23, 10, 21, 20, 689, DateTimeKind.Utc).AddTicks(9157));

            migrationBuilder.UpdateData(
                table: "QuickAssessmentQuestions",
                keyColumn: "Id",
                keyValue: 29L,
                column: "CreatedDate",
                value: new DateTime(2021, 12, 23, 10, 21, 20, 690, DateTimeKind.Utc).AddTicks(40));

            migrationBuilder.UpdateData(
                table: "QuickAssessmentQuestions",
                keyColumn: "Id",
                keyValue: 30L,
                column: "CreatedDate",
                value: new DateTime(2021, 12, 23, 10, 21, 20, 690, DateTimeKind.Utc).AddTicks(873));

            migrationBuilder.UpdateData(
                table: "QuickAssessmentQuestions",
                keyColumn: "Id",
                keyValue: 31L,
                column: "CreatedDate",
                value: new DateTime(2021, 12, 23, 10, 21, 20, 690, DateTimeKind.Utc).AddTicks(889));

            migrationBuilder.UpdateData(
                table: "QuickAssessmentQuestions",
                keyColumn: "Id",
                keyValue: 32L,
                column: "CreatedDate",
                value: new DateTime(2021, 12, 23, 10, 21, 20, 690, DateTimeKind.Utc).AddTicks(1552));

            migrationBuilder.UpdateData(
                table: "QuickAssessmentQuestions",
                keyColumn: "Id",
                keyValue: 33L,
                column: "CreatedDate",
                value: new DateTime(2021, 12, 23, 10, 21, 20, 690, DateTimeKind.Utc).AddTicks(2332));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: -1L,
                column: "Password",
                value: "$2a$12$lYPQ11G3kqTyKFCblVTsZuZJb.eGZng8ckPnBbgdcRh8nxfbx6Q7i");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1L,
                column: "Password",
                value: "$2a$12$KYskHILvBX9gMlaH/wU7TOd0/nX31kDej7G5cby7WfRxNLoafgOVa");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2L,
                column: "Password",
                value: "$2a$12$OKmS5A9yAfXJznotGyboFeV9W9YB2/3vGGQk8owAOyBZ/WK7Hip5C");

            migrationBuilder.UpdateData(
                table: "Validators",
                keyColumn: "Id",
                keyValue: 1L,
                column: "CreatedDate",
                value: new DateTime(2021, 12, 23, 10, 21, 20, 690, DateTimeKind.Utc).AddTicks(4182));

            migrationBuilder.UpdateData(
                table: "Validators",
                keyColumn: "Id",
                keyValue: 2L,
                column: "CreatedDate",
                value: new DateTime(2021, 12, 23, 10, 21, 20, 690, DateTimeKind.Utc).AddTicks(4657));

            migrationBuilder.UpdateData(
                table: "Validators",
                keyColumn: "Id",
                keyValue: 3L,
                column: "CreatedDate",
                value: new DateTime(2021, 12, 23, 10, 21, 20, 690, DateTimeKind.Utc).AddTicks(5048));

            migrationBuilder.UpdateData(
                table: "Validators",
                keyColumn: "Id",
                keyValue: 4L,
                column: "CreatedDate",
                value: new DateTime(2021, 12, 23, 10, 21, 20, 690, DateTimeKind.Utc).AddTicks(5061));

            migrationBuilder.UpdateData(
                table: "Validators",
                keyColumn: "Id",
                keyValue: 5L,
                column: "CreatedDate",
                value: new DateTime(2021, 12, 23, 10, 21, 20, 690, DateTimeKind.Utc).AddTicks(5063));

            migrationBuilder.UpdateData(
                table: "Validators",
                keyColumn: "Id",
                keyValue: 6L,
                column: "CreatedDate",
                value: new DateTime(2021, 12, 23, 10, 21, 20, 690, DateTimeKind.Utc).AddTicks(5072));

            migrationBuilder.UpdateData(
                table: "Validators",
                keyColumn: "Id",
                keyValue: 7L,
                column: "CreatedDate",
                value: new DateTime(2021, 12, 23, 10, 21, 20, 690, DateTimeKind.Utc).AddTicks(5073));

            migrationBuilder.UpdateData(
                table: "Validators",
                keyColumn: "Id",
                keyValue: 8L,
                column: "CreatedDate",
                value: new DateTime(2021, 12, 23, 10, 21, 20, 690, DateTimeKind.Utc).AddTicks(5074));

            migrationBuilder.UpdateData(
                table: "Validators",
                keyColumn: "Id",
                keyValue: 9L,
                column: "CreatedDate",
                value: new DateTime(2021, 12, 23, 10, 21, 20, 690, DateTimeKind.Utc).AddTicks(5075));

            migrationBuilder.UpdateData(
                table: "Validators",
                keyColumn: "Id",
                keyValue: 10L,
                column: "CreatedDate",
                value: new DateTime(2021, 12, 23, 10, 21, 20, 690, DateTimeKind.Utc).AddTicks(5076));

            migrationBuilder.UpdateData(
                table: "Validators",
                keyColumn: "Id",
                keyValue: 11L,
                column: "CreatedDate",
                value: new DateTime(2021, 12, 23, 10, 21, 20, 690, DateTimeKind.Utc).AddTicks(5077));

            migrationBuilder.UpdateData(
                table: "Validators",
                keyColumn: "Id",
                keyValue: 12L,
                column: "CreatedDate",
                value: new DateTime(2021, 12, 23, 10, 21, 20, 690, DateTimeKind.Utc).AddTicks(5078));

            migrationBuilder.UpdateData(
                table: "Validators",
                keyColumn: "Id",
                keyValue: 13L,
                column: "CreatedDate",
                value: new DateTime(2021, 12, 23, 10, 21, 20, 690, DateTimeKind.Utc).AddTicks(5079));

            migrationBuilder.UpdateData(
                table: "Validators",
                keyColumn: "Id",
                keyValue: 14L,
                column: "CreatedDate",
                value: new DateTime(2021, 12, 23, 10, 21, 20, 690, DateTimeKind.Utc).AddTicks(5079));

            migrationBuilder.UpdateData(
                table: "Validators",
                keyColumn: "Id",
                keyValue: 15L,
                column: "CreatedDate",
                value: new DateTime(2021, 12, 23, 10, 21, 20, 690, DateTimeKind.Utc).AddTicks(5081));

            migrationBuilder.UpdateData(
                table: "Validators",
                keyColumn: "Id",
                keyValue: 16L,
                column: "CreatedDate",
                value: new DateTime(2021, 12, 23, 10, 21, 20, 690, DateTimeKind.Utc).AddTicks(5081));

            migrationBuilder.UpdateData(
                table: "Validators",
                keyColumn: "Id",
                keyValue: 17L,
                column: "CreatedDate",
                value: new DateTime(2021, 12, 23, 10, 21, 20, 690, DateTimeKind.Utc).AddTicks(5082));

            migrationBuilder.UpdateData(
                table: "Validators",
                keyColumn: "Id",
                keyValue: 18L,
                column: "CreatedDate",
                value: new DateTime(2021, 12, 23, 10, 21, 20, 690, DateTimeKind.Utc).AddTicks(5083));

            migrationBuilder.UpdateData(
                table: "Validators",
                keyColumn: "Id",
                keyValue: 19L,
                column: "CreatedDate",
                value: new DateTime(2021, 12, 23, 10, 21, 20, 690, DateTimeKind.Utc).AddTicks(5084));

            migrationBuilder.UpdateData(
                table: "Validators",
                keyColumn: "Id",
                keyValue: 20L,
                column: "CreatedDate",
                value: new DateTime(2021, 12, 23, 10, 21, 20, 690, DateTimeKind.Utc).AddTicks(5086));

            migrationBuilder.UpdateData(
                table: "Validators",
                keyColumn: "Id",
                keyValue: 21L,
                column: "CreatedDate",
                value: new DateTime(2021, 12, 23, 10, 21, 20, 690, DateTimeKind.Utc).AddTicks(5087));

            migrationBuilder.UpdateData(
                table: "Validators",
                keyColumn: "Id",
                keyValue: 22L,
                column: "CreatedDate",
                value: new DateTime(2021, 12, 23, 10, 21, 20, 690, DateTimeKind.Utc).AddTicks(5088));

            migrationBuilder.UpdateData(
                table: "Validators",
                keyColumn: "Id",
                keyValue: 23L,
                column: "CreatedDate",
                value: new DateTime(2021, 12, 23, 10, 21, 20, 690, DateTimeKind.Utc).AddTicks(5089));

            migrationBuilder.UpdateData(
                table: "Validators",
                keyColumn: "Id",
                keyValue: 24L,
                column: "CreatedDate",
                value: new DateTime(2021, 12, 23, 10, 21, 20, 690, DateTimeKind.Utc).AddTicks(5090));

            migrationBuilder.UpdateData(
                table: "Validators",
                keyColumn: "Id",
                keyValue: 25L,
                column: "CreatedDate",
                value: new DateTime(2021, 12, 23, 10, 21, 20, 690, DateTimeKind.Utc).AddTicks(5091));

            migrationBuilder.UpdateData(
                table: "Validators",
                keyColumn: "Id",
                keyValue: 26L,
                column: "CreatedDate",
                value: new DateTime(2021, 12, 23, 10, 21, 20, 690, DateTimeKind.Utc).AddTicks(5092));

            migrationBuilder.UpdateData(
                table: "Validators",
                keyColumn: "Id",
                keyValue: 27L,
                column: "CreatedDate",
                value: new DateTime(2021, 12, 23, 10, 21, 20, 690, DateTimeKind.Utc).AddTicks(5093));

            migrationBuilder.UpdateData(
                table: "Validators",
                keyColumn: "Id",
                keyValue: 28L,
                column: "CreatedDate",
                value: new DateTime(2021, 12, 23, 10, 21, 20, 690, DateTimeKind.Utc).AddTicks(5094));

            migrationBuilder.UpdateData(
                table: "Validators",
                keyColumn: "Id",
                keyValue: 29L,
                column: "CreatedDate",
                value: new DateTime(2021, 12, 23, 10, 21, 20, 690, DateTimeKind.Utc).AddTicks(5095));

            migrationBuilder.UpdateData(
                table: "Validators",
                keyColumn: "Id",
                keyValue: 30L,
                column: "CreatedDate",
                value: new DateTime(2021, 12, 23, 10, 21, 20, 690, DateTimeKind.Utc).AddTicks(5095));

            migrationBuilder.UpdateData(
                table: "Validators",
                keyColumn: "Id",
                keyValue: 31L,
                column: "CreatedDate",
                value: new DateTime(2021, 12, 23, 10, 21, 20, 690, DateTimeKind.Utc).AddTicks(5097));

            migrationBuilder.UpdateData(
                table: "Validators",
                keyColumn: "Id",
                keyValue: 32L,
                column: "CreatedDate",
                value: new DateTime(2021, 12, 23, 10, 21, 20, 690, DateTimeKind.Utc).AddTicks(5098));

            migrationBuilder.AddForeignKey(
                name: "FK_Document_DocumentCategoryDocumentTypeMapping_DocumentCategoryDocumentTypeMappingId",
                table: "Document",
                column: "DocumentCategoryDocumentTypeMappingId",
                principalTable: "DocumentCategoryDocumentTypeMapping",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
