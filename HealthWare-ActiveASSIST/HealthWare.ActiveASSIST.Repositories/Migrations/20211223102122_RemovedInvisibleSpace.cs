using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace HealthWare.ActiveASSIST.Repositories.Migrations
{
    public partial class RemovedInvisibleSpace : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                table: "IncomeType",
                keyColumn: "Id",
                keyValue: 2L,
                column: "Value",
                value: "Wages, Salaries, Tips, and Commission Income from Work");

            migrationBuilder.UpdateData(
                table: "IncomeType",
                keyColumn: "Id",
                keyValue: 3L,
                column: "Value",
                value: "Self-Employment and Business Income");

            migrationBuilder.UpdateData(
                table: "IncomeType",
                keyColumn: "Id",
                keyValue: 5L,
                column: "Value",
                value: "In-Kind Support");

            migrationBuilder.UpdateData(
                table: "IncomeType",
                keyColumn: "Id",
                keyValue: 8L,
                column: "Value",
                value: "Dividends");

            migrationBuilder.UpdateData(
                table: "IncomeType",
                keyColumn: "Id",
                keyValue: 12L,
                column: "Value",
                value: "Royalties");

            migrationBuilder.UpdateData(
                table: "IncomeType",
                keyColumn: "Id",
                keyValue: 16L,
                column: "Value",
                value: "Retirement Account Income");

            migrationBuilder.UpdateData(
                table: "IncomeType",
                keyColumn: "Id",
                keyValue: 17L,
                column: "Value",
                value: "Alimony");

            migrationBuilder.UpdateData(
                table: "IncomeType",
                keyColumn: "Id",
                keyValue: 18L,
                column: "Value",
                value: "Net Rental Income");

            migrationBuilder.UpdateData(
                table: "IncomeType",
                keyColumn: "Id",
                keyValue: 19L,
                column: "Value",
                value: "Net Gaming/Fishing Income");

            migrationBuilder.UpdateData(
                table: "IncomeType",
                keyColumn: "Id",
                keyValue: 21L,
                column: "Value",
                value: "Court Awards and Damages");

            migrationBuilder.UpdateData(
                table: "IncomeType",
                keyColumn: "Id",
                keyValue: 24L,
                column: "Value",
                value: "Gambling Income");

            migrationBuilder.UpdateData(
                table: "IncomeType",
                keyColumn: "Id",
                keyValue: 25L,
                column: "Value",
                value: "Government Cost of Living Allowance");

            migrationBuilder.UpdateData(
                table: "IncomeType",
                keyColumn: "Id",
                keyValue: 27L,
                column: "Value",
                value: "Do Not Want to Provide");

            migrationBuilder.UpdateData(
                table: "IncomeType",
                keyColumn: "Id",
                keyValue: 28L,
                column: "Value",
                value: "Other");

            migrationBuilder.UpdateData(
                table: "IncomeType",
                keyColumn: "Id",
                keyValue: 30L,
                column: "Value",
                value: "Tax Refunds");

            migrationBuilder.UpdateData(
                table: "IncomeType",
                keyColumn: "Id",
                keyValue: 32L,
                column: "Value",
                value: "VA Benefits");

            migrationBuilder.UpdateData(
                table: "IncomeType",
                keyColumn: "Id",
                keyValue: 33L,
                column: "Value",
                value: "Workers Comp Benefits");

            migrationBuilder.UpdateData(
                table: "IncomeType",
                keyColumn: "Id",
                keyValue: 34L,
                column: "Value",
                value: "Educational Grants");

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
                table: "RelationshipToPatient",
                keyColumn: "Id",
                keyValue: 3L,
                column: "Value",
                value: "Care giver");

            migrationBuilder.UpdateData(
                table: "RelationshipToPatient",
                keyColumn: "Id",
                keyValue: 5L,
                column: "Value",
                value: "Handicapped dependent");

            migrationBuilder.UpdateData(
                table: "RelationshipToPatient",
                keyColumn: "Id",
                keyValue: 8L,
                column: "Value",
                value: "Employee");

            migrationBuilder.UpdateData(
                table: "RelationshipToPatient",
                keyColumn: "Id",
                keyValue: 13L,
                column: "Value",
                value: "Father");

            migrationBuilder.UpdateData(
                table: "RelationshipToPatient",
                keyColumn: "Id",
                keyValue: 17L,
                column: "Value",
                value: "Manager");

            migrationBuilder.UpdateData(
                table: "RelationshipToPatient",
                keyColumn: "Id",
                keyValue: 18L,
                column: "Value",
                value: "Mother");

            migrationBuilder.UpdateData(
                table: "RelationshipToPatient",
                keyColumn: "Id",
                keyValue: 20L,
                column: "Value",
                value: "Other adult");

            migrationBuilder.UpdateData(
                table: "RelationshipToPatient",
                keyColumn: "Id",
                keyValue: 22L,
                column: "Value",
                value: "Owner");

            migrationBuilder.UpdateData(
                table: "RelationshipToPatient",
                keyColumn: "Id",
                keyValue: 26L,
                column: "Value",
                value: "Sibling");

            migrationBuilder.UpdateData(
                table: "RelationshipToPatient",
                keyColumn: "Id",
                keyValue: 28L,
                column: "Value",
                value: "Spouse");

            migrationBuilder.UpdateData(
                table: "RelationshipToPatient",
                keyColumn: "Id",
                keyValue: 29L,
                column: "Value",
                value: "Trainer");

            migrationBuilder.UpdateData(
                table: "RelationshipToPatient",
                keyColumn: "Id",
                keyValue: 31L,
                column: "Value",
                value: "Ward of court");

            migrationBuilder.UpdateData(
                table: "ResourceType",
                keyColumn: "Id",
                keyValue: 2L,
                column: "Value",
                value: "IRA/401K");

            migrationBuilder.UpdateData(
                table: "ResourceType",
                keyColumn: "Id",
                keyValue: 3L,
                column: "Value",
                value: "Vehicle, Primary");

            migrationBuilder.UpdateData(
                table: "ResourceType",
                keyColumn: "Id",
                keyValue: 5L,
                column: "Value",
                value: "Real Property, Home");

            migrationBuilder.UpdateData(
                table: "ResourceType",
                keyColumn: "Id",
                keyValue: 6L,
                column: "Value",
                value: "Real Property, Building");

            migrationBuilder.UpdateData(
                table: "ResourceType",
                keyColumn: "Id",
                keyValue: 8L,
                column: "Value",
                value: "Real Property, Life Estates");

            migrationBuilder.UpdateData(
                table: "ResourceType",
                keyColumn: "Id",
                keyValue: 12L,
                column: "Value",
                value: "Contracts for Care");

            migrationBuilder.UpdateData(
                table: "ResourceType",
                keyColumn: "Id",
                keyValue: 13L,
                column: "Value",
                value: "Escrow Accounts");

            migrationBuilder.UpdateData(
                table: "ResourceType",
                keyColumn: "Id",
                keyValue: 15L,
                column: "Value",
                value: "Home Sale Proceeds");

            migrationBuilder.UpdateData(
                table: "ResourceType",
                keyColumn: "Id",
                keyValue: 16L,
                column: "Value",
                value: "Income Producing Property");

            migrationBuilder.UpdateData(
                table: "ResourceType",
                keyColumn: "Id",
                keyValue: 17L,
                column: "Value",
                value: "Individual Development Accounts");

            migrationBuilder.UpdateData(
                table: "ResourceType",
                keyColumn: "Id",
                keyValue: 18L,
                column: "Value",
                value: "Life Insurance");

            migrationBuilder.UpdateData(
                table: "ResourceType",
                keyColumn: "Id",
                keyValue: 20L,
                column: "Value",
                value: "Pension Plans");

            migrationBuilder.UpdateData(
                table: "ResourceType",
                keyColumn: "Id",
                keyValue: 22L,
                column: "Value",
                value: "Do Not Want to Provide");

            migrationBuilder.UpdateData(
                table: "ResourceTypeCurrentStatus",
                keyColumn: "Id",
                keyValue: 1L,
                column: "Value",
                value: "Currently Owned");

            migrationBuilder.UpdateData(
                table: "ResourceTypeCurrentStatus",
                keyColumn: "Id",
                keyValue: 2L,
                column: "Value",
                value: "Sold Less Than 1 Year Ago");

            migrationBuilder.UpdateData(
                table: "ResourceTypeCurrentStatus",
                keyColumn: "Id",
                keyValue: 3L,
                column: "Value",
                value: "Sold More Than 1 Year Ago");

            migrationBuilder.UpdateData(
                table: "ResourceTypeCurrentStatus",
                keyColumn: "Id",
                keyValue: 5L,
                column: "Value",
                value: "Transferred More Than 5 Years Ago");

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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "DynamicScreens",
                keyColumn: "Id",
                keyValue: 1L,
                column: "CreatedDate",
                value: new DateTime(2021, 12, 22, 13, 54, 44, 869, DateTimeKind.Utc).AddTicks(6402));

            migrationBuilder.UpdateData(
                table: "DynamicScreens",
                keyColumn: "Id",
                keyValue: 2L,
                column: "CreatedDate",
                value: new DateTime(2021, 12, 22, 13, 54, 44, 869, DateTimeKind.Utc).AddTicks(6696));

            migrationBuilder.UpdateData(
                table: "DynamicScreens",
                keyColumn: "Id",
                keyValue: 3L,
                column: "CreatedDate",
                value: new DateTime(2021, 12, 22, 13, 54, 44, 869, DateTimeKind.Utc).AddTicks(6705));

            migrationBuilder.UpdateData(
                table: "DynamicScreens",
                keyColumn: "Id",
                keyValue: 4L,
                column: "CreatedDate",
                value: new DateTime(2021, 12, 22, 13, 54, 44, 869, DateTimeKind.Utc).AddTicks(6706));

            migrationBuilder.UpdateData(
                table: "DynamicScreens",
                keyColumn: "Id",
                keyValue: 5L,
                column: "CreatedDate",
                value: new DateTime(2021, 12, 22, 13, 54, 44, 869, DateTimeKind.Utc).AddTicks(6707));

            migrationBuilder.UpdateData(
                table: "DynamicScreens",
                keyColumn: "Id",
                keyValue: 6L,
                column: "CreatedDate",
                value: new DateTime(2021, 12, 22, 13, 54, 44, 869, DateTimeKind.Utc).AddTicks(6710));

            migrationBuilder.UpdateData(
                table: "DynamicScreens",
                keyColumn: "Id",
                keyValue: 7L,
                column: "CreatedDate",
                value: new DateTime(2021, 12, 22, 13, 54, 44, 869, DateTimeKind.Utc).AddTicks(6711));

            migrationBuilder.UpdateData(
                table: "DynamicScreens",
                keyColumn: "Id",
                keyValue: 8L,
                column: "CreatedDate",
                value: new DateTime(2021, 12, 22, 13, 54, 44, 869, DateTimeKind.Utc).AddTicks(6713));

            migrationBuilder.UpdateData(
                table: "DynamicScreens",
                keyColumn: "Id",
                keyValue: 9L,
                column: "CreatedDate",
                value: new DateTime(2021, 12, 22, 13, 54, 44, 869, DateTimeKind.Utc).AddTicks(6714));

            migrationBuilder.UpdateData(
                table: "DynamicScreens",
                keyColumn: "Id",
                keyValue: 10L,
                column: "CreatedDate",
                value: new DateTime(2021, 12, 22, 13, 54, 44, 869, DateTimeKind.Utc).AddTicks(6716));

            migrationBuilder.UpdateData(
                table: "DynamicScreens",
                keyColumn: "Id",
                keyValue: 11L,
                column: "CreatedDate",
                value: new DateTime(2021, 12, 22, 13, 54, 44, 869, DateTimeKind.Utc).AddTicks(6717));

            migrationBuilder.UpdateData(
                table: "IncomeType",
                keyColumn: "Id",
                keyValue: 2L,
                column: "Value",
                value: "Wages, Salaries, Tips, and Commission Income from Work​");

            migrationBuilder.UpdateData(
                table: "IncomeType",
                keyColumn: "Id",
                keyValue: 3L,
                column: "Value",
                value: "Self-Employment and Business Income​");

            migrationBuilder.UpdateData(
                table: "IncomeType",
                keyColumn: "Id",
                keyValue: 5L,
                column: "Value",
                value: "In-Kind Support​");

            migrationBuilder.UpdateData(
                table: "IncomeType",
                keyColumn: "Id",
                keyValue: 8L,
                column: "Value",
                value: "Dividends​");

            migrationBuilder.UpdateData(
                table: "IncomeType",
                keyColumn: "Id",
                keyValue: 12L,
                column: "Value",
                value: "Royalties​");

            migrationBuilder.UpdateData(
                table: "IncomeType",
                keyColumn: "Id",
                keyValue: 16L,
                column: "Value",
                value: "Retirement Account Income​");

            migrationBuilder.UpdateData(
                table: "IncomeType",
                keyColumn: "Id",
                keyValue: 17L,
                column: "Value",
                value: "Alimony​");

            migrationBuilder.UpdateData(
                table: "IncomeType",
                keyColumn: "Id",
                keyValue: 18L,
                column: "Value",
                value: "Net Rental Income​");

            migrationBuilder.UpdateData(
                table: "IncomeType",
                keyColumn: "Id",
                keyValue: 19L,
                column: "Value",
                value: "Net Gaming/Fishing Income​");

            migrationBuilder.UpdateData(
                table: "IncomeType",
                keyColumn: "Id",
                keyValue: 21L,
                column: "Value",
                value: "Court Awards and Damages​​");

            migrationBuilder.UpdateData(
                table: "IncomeType",
                keyColumn: "Id",
                keyValue: 24L,
                column: "Value",
                value: "Gambling Income​​");

            migrationBuilder.UpdateData(
                table: "IncomeType",
                keyColumn: "Id",
                keyValue: 25L,
                column: "Value",
                value: "Government Cost of Living Allowance​");

            migrationBuilder.UpdateData(
                table: "IncomeType",
                keyColumn: "Id",
                keyValue: 27L,
                column: "Value",
                value: "Do Not Want to Provide​");

            migrationBuilder.UpdateData(
                table: "IncomeType",
                keyColumn: "Id",
                keyValue: 28L,
                column: "Value",
                value: "Other​​");

            migrationBuilder.UpdateData(
                table: "IncomeType",
                keyColumn: "Id",
                keyValue: 30L,
                column: "Value",
                value: "Tax Refunds​");

            migrationBuilder.UpdateData(
                table: "IncomeType",
                keyColumn: "Id",
                keyValue: 32L,
                column: "Value",
                value: "VA Benefits​​");

            migrationBuilder.UpdateData(
                table: "IncomeType",
                keyColumn: "Id",
                keyValue: 33L,
                column: "Value",
                value: "Workers Comp Benefits​​");

            migrationBuilder.UpdateData(
                table: "IncomeType",
                keyColumn: "Id",
                keyValue: 34L,
                column: "Value",
                value: "Educational Grants​​");

            migrationBuilder.UpdateData(
                table: "Options",
                keyColumn: "Id",
                keyValue: 1L,
                column: "CreatedDate",
                value: new DateTime(2021, 12, 22, 13, 54, 44, 873, DateTimeKind.Utc).AddTicks(807));

            migrationBuilder.UpdateData(
                table: "Options",
                keyColumn: "Id",
                keyValue: 2L,
                column: "CreatedDate",
                value: new DateTime(2021, 12, 22, 13, 54, 44, 873, DateTimeKind.Utc).AddTicks(1589));

            migrationBuilder.UpdateData(
                table: "Options",
                keyColumn: "Id",
                keyValue: 3L,
                column: "CreatedDate",
                value: new DateTime(2021, 12, 22, 13, 54, 44, 873, DateTimeKind.Utc).AddTicks(1612));

            migrationBuilder.UpdateData(
                table: "Options",
                keyColumn: "Id",
                keyValue: 4L,
                column: "CreatedDate",
                value: new DateTime(2021, 12, 22, 13, 54, 44, 873, DateTimeKind.Utc).AddTicks(1613));

            migrationBuilder.UpdateData(
                table: "Options",
                keyColumn: "Id",
                keyValue: 5L,
                column: "CreatedDate",
                value: new DateTime(2021, 12, 22, 13, 54, 44, 873, DateTimeKind.Utc).AddTicks(1615));

            migrationBuilder.UpdateData(
                table: "Options",
                keyColumn: "Id",
                keyValue: 6L,
                column: "CreatedDate",
                value: new DateTime(2021, 12, 22, 13, 54, 44, 873, DateTimeKind.Utc).AddTicks(1617));

            migrationBuilder.UpdateData(
                table: "Options",
                keyColumn: "Id",
                keyValue: 7L,
                column: "CreatedDate",
                value: new DateTime(2021, 12, 22, 13, 54, 44, 873, DateTimeKind.Utc).AddTicks(1619));

            migrationBuilder.UpdateData(
                table: "Options",
                keyColumn: "Id",
                keyValue: 8L,
                column: "CreatedDate",
                value: new DateTime(2021, 12, 22, 13, 54, 44, 873, DateTimeKind.Utc).AddTicks(1621));

            migrationBuilder.UpdateData(
                table: "Options",
                keyColumn: "Id",
                keyValue: 9L,
                column: "CreatedDate",
                value: new DateTime(2021, 12, 22, 13, 54, 44, 873, DateTimeKind.Utc).AddTicks(1623));

            migrationBuilder.UpdateData(
                table: "Options",
                keyColumn: "Id",
                keyValue: 10L,
                column: "CreatedDate",
                value: new DateTime(2021, 12, 22, 13, 54, 44, 873, DateTimeKind.Utc).AddTicks(1626));

            migrationBuilder.UpdateData(
                table: "Options",
                keyColumn: "Id",
                keyValue: 11L,
                column: "CreatedDate",
                value: new DateTime(2021, 12, 22, 13, 54, 44, 873, DateTimeKind.Utc).AddTicks(1628));

            migrationBuilder.UpdateData(
                table: "Options",
                keyColumn: "Id",
                keyValue: 12L,
                column: "CreatedDate",
                value: new DateTime(2021, 12, 22, 13, 54, 44, 873, DateTimeKind.Utc).AddTicks(1629));

            migrationBuilder.UpdateData(
                table: "Options",
                keyColumn: "Id",
                keyValue: 13L,
                column: "CreatedDate",
                value: new DateTime(2021, 12, 22, 13, 54, 44, 873, DateTimeKind.Utc).AddTicks(1632));

            migrationBuilder.UpdateData(
                table: "Options",
                keyColumn: "Id",
                keyValue: 14L,
                column: "CreatedDate",
                value: new DateTime(2021, 12, 22, 13, 54, 44, 873, DateTimeKind.Utc).AddTicks(1633));

            migrationBuilder.UpdateData(
                table: "Options",
                keyColumn: "Id",
                keyValue: 15L,
                column: "CreatedDate",
                value: new DateTime(2021, 12, 22, 13, 54, 44, 873, DateTimeKind.Utc).AddTicks(1634));

            migrationBuilder.UpdateData(
                table: "Options",
                keyColumn: "Id",
                keyValue: 16L,
                column: "CreatedDate",
                value: new DateTime(2021, 12, 22, 13, 54, 44, 873, DateTimeKind.Utc).AddTicks(1636));

            migrationBuilder.UpdateData(
                table: "Options",
                keyColumn: "Id",
                keyValue: 17L,
                column: "CreatedDate",
                value: new DateTime(2021, 12, 22, 13, 54, 44, 873, DateTimeKind.Utc).AddTicks(1637));

            migrationBuilder.UpdateData(
                table: "Options",
                keyColumn: "Id",
                keyValue: 18L,
                column: "CreatedDate",
                value: new DateTime(2021, 12, 22, 13, 54, 44, 873, DateTimeKind.Utc).AddTicks(1638));

            migrationBuilder.UpdateData(
                table: "Options",
                keyColumn: "Id",
                keyValue: 19L,
                column: "CreatedDate",
                value: new DateTime(2021, 12, 22, 13, 54, 44, 873, DateTimeKind.Utc).AddTicks(1639));

            migrationBuilder.UpdateData(
                table: "Options",
                keyColumn: "Id",
                keyValue: 20L,
                column: "CreatedDate",
                value: new DateTime(2021, 12, 22, 13, 54, 44, 873, DateTimeKind.Utc).AddTicks(1641));

            migrationBuilder.UpdateData(
                table: "Options",
                keyColumn: "Id",
                keyValue: 21L,
                column: "CreatedDate",
                value: new DateTime(2021, 12, 22, 13, 54, 44, 873, DateTimeKind.Utc).AddTicks(1643));

            migrationBuilder.UpdateData(
                table: "Options",
                keyColumn: "Id",
                keyValue: 22L,
                column: "CreatedDate",
                value: new DateTime(2021, 12, 22, 13, 54, 44, 873, DateTimeKind.Utc).AddTicks(1644));

            migrationBuilder.UpdateData(
                table: "Options",
                keyColumn: "Id",
                keyValue: 23L,
                column: "CreatedDate",
                value: new DateTime(2021, 12, 22, 13, 54, 44, 873, DateTimeKind.Utc).AddTicks(1646));

            migrationBuilder.UpdateData(
                table: "Options",
                keyColumn: "Id",
                keyValue: 24L,
                column: "CreatedDate",
                value: new DateTime(2021, 12, 22, 13, 54, 44, 873, DateTimeKind.Utc).AddTicks(1647));

            migrationBuilder.UpdateData(
                table: "Options",
                keyColumn: "Id",
                keyValue: 25L,
                column: "CreatedDate",
                value: new DateTime(2021, 12, 22, 13, 54, 44, 873, DateTimeKind.Utc).AddTicks(1651));

            migrationBuilder.UpdateData(
                table: "Options",
                keyColumn: "Id",
                keyValue: 26L,
                column: "CreatedDate",
                value: new DateTime(2021, 12, 22, 13, 54, 44, 873, DateTimeKind.Utc).AddTicks(1652));

            migrationBuilder.UpdateData(
                table: "Options",
                keyColumn: "Id",
                keyValue: 27L,
                column: "CreatedDate",
                value: new DateTime(2021, 12, 22, 13, 54, 44, 873, DateTimeKind.Utc).AddTicks(1654));

            migrationBuilder.UpdateData(
                table: "Options",
                keyColumn: "Id",
                keyValue: 28L,
                column: "CreatedDate",
                value: new DateTime(2021, 12, 22, 13, 54, 44, 873, DateTimeKind.Utc).AddTicks(1656));

            migrationBuilder.UpdateData(
                table: "Options",
                keyColumn: "Id",
                keyValue: 29L,
                column: "CreatedDate",
                value: new DateTime(2021, 12, 22, 13, 54, 44, 873, DateTimeKind.Utc).AddTicks(1658));

            migrationBuilder.UpdateData(
                table: "Options",
                keyColumn: "Id",
                keyValue: 30L,
                column: "CreatedDate",
                value: new DateTime(2021, 12, 22, 13, 54, 44, 873, DateTimeKind.Utc).AddTicks(1659));

            migrationBuilder.UpdateData(
                table: "Options",
                keyColumn: "Id",
                keyValue: 31L,
                column: "CreatedDate",
                value: new DateTime(2021, 12, 22, 13, 54, 44, 873, DateTimeKind.Utc).AddTicks(1661));

            migrationBuilder.UpdateData(
                table: "Options",
                keyColumn: "Id",
                keyValue: 32L,
                column: "CreatedDate",
                value: new DateTime(2021, 12, 22, 13, 54, 44, 873, DateTimeKind.Utc).AddTicks(1662));

            migrationBuilder.UpdateData(
                table: "Options",
                keyColumn: "Id",
                keyValue: 33L,
                column: "CreatedDate",
                value: new DateTime(2021, 12, 22, 13, 54, 44, 873, DateTimeKind.Utc).AddTicks(1664));

            migrationBuilder.UpdateData(
                table: "Options",
                keyColumn: "Id",
                keyValue: 34L,
                column: "CreatedDate",
                value: new DateTime(2021, 12, 22, 13, 54, 44, 873, DateTimeKind.Utc).AddTicks(1665));

            migrationBuilder.UpdateData(
                table: "Options",
                keyColumn: "Id",
                keyValue: 35L,
                column: "CreatedDate",
                value: new DateTime(2021, 12, 22, 13, 54, 44, 873, DateTimeKind.Utc).AddTicks(1667));

            migrationBuilder.UpdateData(
                table: "Options",
                keyColumn: "Id",
                keyValue: 36L,
                column: "CreatedDate",
                value: new DateTime(2021, 12, 22, 13, 54, 44, 873, DateTimeKind.Utc).AddTicks(1668));

            migrationBuilder.UpdateData(
                table: "Options",
                keyColumn: "Id",
                keyValue: 37L,
                column: "CreatedDate",
                value: new DateTime(2021, 12, 22, 13, 54, 44, 873, DateTimeKind.Utc).AddTicks(1670));

            migrationBuilder.UpdateData(
                table: "Options",
                keyColumn: "Id",
                keyValue: 38L,
                column: "CreatedDate",
                value: new DateTime(2021, 12, 22, 13, 54, 44, 873, DateTimeKind.Utc).AddTicks(1672));

            migrationBuilder.UpdateData(
                table: "Options",
                keyColumn: "Id",
                keyValue: 39L,
                column: "CreatedDate",
                value: new DateTime(2021, 12, 22, 13, 54, 44, 873, DateTimeKind.Utc).AddTicks(1673));

            migrationBuilder.UpdateData(
                table: "Options",
                keyColumn: "Id",
                keyValue: 40L,
                column: "CreatedDate",
                value: new DateTime(2021, 12, 22, 13, 54, 44, 873, DateTimeKind.Utc).AddTicks(1675));

            migrationBuilder.UpdateData(
                table: "Options",
                keyColumn: "Id",
                keyValue: 41L,
                column: "CreatedDate",
                value: new DateTime(2021, 12, 22, 13, 54, 44, 873, DateTimeKind.Utc).AddTicks(1676));

            migrationBuilder.UpdateData(
                table: "Options",
                keyColumn: "Id",
                keyValue: 42L,
                column: "CreatedDate",
                value: new DateTime(2021, 12, 22, 13, 54, 44, 873, DateTimeKind.Utc).AddTicks(1678));

            migrationBuilder.UpdateData(
                table: "Options",
                keyColumn: "Id",
                keyValue: 43L,
                column: "CreatedDate",
                value: new DateTime(2021, 12, 22, 13, 54, 44, 873, DateTimeKind.Utc).AddTicks(1679));

            migrationBuilder.UpdateData(
                table: "Options",
                keyColumn: "Id",
                keyValue: 44L,
                column: "CreatedDate",
                value: new DateTime(2021, 12, 22, 13, 54, 44, 873, DateTimeKind.Utc).AddTicks(2297));

            migrationBuilder.UpdateData(
                table: "Options",
                keyColumn: "Id",
                keyValue: 45L,
                column: "CreatedDate",
                value: new DateTime(2021, 12, 22, 13, 54, 44, 873, DateTimeKind.Utc).AddTicks(2316));

            migrationBuilder.UpdateData(
                table: "Program",
                keyColumn: "Id",
                keyValue: 1L,
                column: "CreatedDate",
                value: new DateTime(2021, 12, 22, 13, 54, 44, 874, DateTimeKind.Utc).AddTicks(7476));

            migrationBuilder.UpdateData(
                table: "Program",
                keyColumn: "Id",
                keyValue: 2L,
                column: "CreatedDate",
                value: new DateTime(2021, 12, 22, 13, 54, 44, 874, DateTimeKind.Utc).AddTicks(7527));

            migrationBuilder.UpdateData(
                table: "Program",
                keyColumn: "Id",
                keyValue: 3L,
                column: "CreatedDate",
                value: new DateTime(2021, 12, 22, 13, 54, 44, 874, DateTimeKind.Utc).AddTicks(7530));

            migrationBuilder.UpdateData(
                table: "Program",
                keyColumn: "Id",
                keyValue: 4L,
                column: "CreatedDate",
                value: new DateTime(2021, 12, 22, 13, 54, 44, 874, DateTimeKind.Utc).AddTicks(7531));

            migrationBuilder.UpdateData(
                table: "Program",
                keyColumn: "Id",
                keyValue: 5L,
                column: "CreatedDate",
                value: new DateTime(2021, 12, 22, 13, 54, 44, 874, DateTimeKind.Utc).AddTicks(7533));

            migrationBuilder.UpdateData(
                table: "Program",
                keyColumn: "Id",
                keyValue: 6L,
                column: "CreatedDate",
                value: new DateTime(2021, 12, 22, 13, 54, 44, 874, DateTimeKind.Utc).AddTicks(7535));

            migrationBuilder.UpdateData(
                table: "ProgramDocument",
                keyColumn: "Id",
                keyValue: 1L,
                column: "CreatedDate",
                value: new DateTime(2021, 12, 22, 13, 54, 44, 874, DateTimeKind.Utc).AddTicks(7813));

            migrationBuilder.UpdateData(
                table: "ProgramDocument",
                keyColumn: "Id",
                keyValue: 2L,
                column: "CreatedDate",
                value: new DateTime(2021, 12, 22, 13, 54, 44, 874, DateTimeKind.Utc).AddTicks(8527));

            migrationBuilder.UpdateData(
                table: "ProgramDocument",
                keyColumn: "Id",
                keyValue: 3L,
                column: "CreatedDate",
                value: new DateTime(2021, 12, 22, 13, 54, 44, 874, DateTimeKind.Utc).AddTicks(8547));

            migrationBuilder.UpdateData(
                table: "ProgramDocument",
                keyColumn: "Id",
                keyValue: 4L,
                column: "CreatedDate",
                value: new DateTime(2021, 12, 22, 13, 54, 44, 874, DateTimeKind.Utc).AddTicks(8551));

            migrationBuilder.UpdateData(
                table: "ProgramDocument",
                keyColumn: "Id",
                keyValue: 5L,
                column: "CreatedDate",
                value: new DateTime(2021, 12, 22, 13, 54, 44, 874, DateTimeKind.Utc).AddTicks(8552));

            migrationBuilder.UpdateData(
                table: "ProgramDocument",
                keyColumn: "Id",
                keyValue: 6L,
                column: "CreatedDate",
                value: new DateTime(2021, 12, 22, 13, 54, 44, 874, DateTimeKind.Utc).AddTicks(8553));

            migrationBuilder.UpdateData(
                table: "ProgramDocument",
                keyColumn: "Id",
                keyValue: 7L,
                column: "CreatedDate",
                value: new DateTime(2021, 12, 22, 13, 54, 44, 874, DateTimeKind.Utc).AddTicks(8555));

            migrationBuilder.UpdateData(
                table: "QuickAssessmentQuestions",
                keyColumn: "Id",
                keyValue: 1L,
                column: "CreatedDate",
                value: new DateTime(2021, 12, 22, 13, 54, 44, 869, DateTimeKind.Utc).AddTicks(6990));

            migrationBuilder.UpdateData(
                table: "QuickAssessmentQuestions",
                keyColumn: "Id",
                keyValue: 2L,
                column: "CreatedDate",
                value: new DateTime(2021, 12, 22, 13, 54, 44, 869, DateTimeKind.Utc).AddTicks(7981));

            migrationBuilder.UpdateData(
                table: "QuickAssessmentQuestions",
                keyColumn: "Id",
                keyValue: 3L,
                column: "CreatedDate",
                value: new DateTime(2021, 12, 22, 13, 54, 44, 869, DateTimeKind.Utc).AddTicks(9755));

            migrationBuilder.UpdateData(
                table: "QuickAssessmentQuestions",
                keyColumn: "Id",
                keyValue: 4L,
                column: "CreatedDate",
                value: new DateTime(2021, 12, 22, 13, 54, 44, 870, DateTimeKind.Utc).AddTicks(880));

            migrationBuilder.UpdateData(
                table: "QuickAssessmentQuestions",
                keyColumn: "Id",
                keyValue: 5L,
                column: "CreatedDate",
                value: new DateTime(2021, 12, 22, 13, 54, 44, 870, DateTimeKind.Utc).AddTicks(903));

            migrationBuilder.UpdateData(
                table: "QuickAssessmentQuestions",
                keyColumn: "Id",
                keyValue: 6L,
                column: "CreatedDate",
                value: new DateTime(2021, 12, 22, 13, 54, 44, 870, DateTimeKind.Utc).AddTicks(2394));

            migrationBuilder.UpdateData(
                table: "QuickAssessmentQuestions",
                keyColumn: "Id",
                keyValue: 7L,
                column: "CreatedDate",
                value: new DateTime(2021, 12, 22, 13, 54, 44, 870, DateTimeKind.Utc).AddTicks(3790));

            migrationBuilder.UpdateData(
                table: "QuickAssessmentQuestions",
                keyColumn: "Id",
                keyValue: 8L,
                column: "CreatedDate",
                value: new DateTime(2021, 12, 22, 13, 54, 44, 870, DateTimeKind.Utc).AddTicks(3799));

            migrationBuilder.UpdateData(
                table: "QuickAssessmentQuestions",
                keyColumn: "Id",
                keyValue: 9L,
                column: "CreatedDate",
                value: new DateTime(2021, 12, 22, 13, 54, 44, 870, DateTimeKind.Utc).AddTicks(4832));

            migrationBuilder.UpdateData(
                table: "QuickAssessmentQuestions",
                keyColumn: "Id",
                keyValue: 10L,
                column: "CreatedDate",
                value: new DateTime(2021, 12, 22, 13, 54, 44, 870, DateTimeKind.Utc).AddTicks(4838));

            migrationBuilder.UpdateData(
                table: "QuickAssessmentQuestions",
                keyColumn: "Id",
                keyValue: 11L,
                column: "CreatedDate",
                value: new DateTime(2021, 12, 22, 13, 54, 44, 870, DateTimeKind.Utc).AddTicks(4840));

            migrationBuilder.UpdateData(
                table: "QuickAssessmentQuestions",
                keyColumn: "Id",
                keyValue: 12L,
                column: "CreatedDate",
                value: new DateTime(2021, 12, 22, 13, 54, 44, 870, DateTimeKind.Utc).AddTicks(5945));

            migrationBuilder.UpdateData(
                table: "QuickAssessmentQuestions",
                keyColumn: "Id",
                keyValue: 13L,
                column: "CreatedDate",
                value: new DateTime(2021, 12, 22, 13, 54, 44, 870, DateTimeKind.Utc).AddTicks(5972));

            migrationBuilder.UpdateData(
                table: "QuickAssessmentQuestions",
                keyColumn: "Id",
                keyValue: 14L,
                column: "CreatedDate",
                value: new DateTime(2021, 12, 22, 13, 54, 44, 870, DateTimeKind.Utc).AddTicks(7499));

            migrationBuilder.UpdateData(
                table: "QuickAssessmentQuestions",
                keyColumn: "Id",
                keyValue: 15L,
                column: "CreatedDate",
                value: new DateTime(2021, 12, 22, 13, 54, 44, 870, DateTimeKind.Utc).AddTicks(8612));

            migrationBuilder.UpdateData(
                table: "QuickAssessmentQuestions",
                keyColumn: "Id",
                keyValue: 16L,
                column: "CreatedDate",
                value: new DateTime(2021, 12, 22, 13, 54, 44, 870, DateTimeKind.Utc).AddTicks(9499));

            migrationBuilder.UpdateData(
                table: "QuickAssessmentQuestions",
                keyColumn: "Id",
                keyValue: 17L,
                column: "CreatedDate",
                value: new DateTime(2021, 12, 22, 13, 54, 44, 871, DateTimeKind.Utc).AddTicks(422));

            migrationBuilder.UpdateData(
                table: "QuickAssessmentQuestions",
                keyColumn: "Id",
                keyValue: 18L,
                column: "CreatedDate",
                value: new DateTime(2021, 12, 22, 13, 54, 44, 871, DateTimeKind.Utc).AddTicks(1882));

            migrationBuilder.UpdateData(
                table: "QuickAssessmentQuestions",
                keyColumn: "Id",
                keyValue: 19L,
                column: "CreatedDate",
                value: new DateTime(2021, 12, 22, 13, 54, 44, 871, DateTimeKind.Utc).AddTicks(1928));

            migrationBuilder.UpdateData(
                table: "QuickAssessmentQuestions",
                keyColumn: "Id",
                keyValue: 20L,
                column: "CreatedDate",
                value: new DateTime(2021, 12, 22, 13, 54, 44, 871, DateTimeKind.Utc).AddTicks(1931));

            migrationBuilder.UpdateData(
                table: "QuickAssessmentQuestions",
                keyColumn: "Id",
                keyValue: 21L,
                column: "CreatedDate",
                value: new DateTime(2021, 12, 22, 13, 54, 44, 871, DateTimeKind.Utc).AddTicks(3233));

            migrationBuilder.UpdateData(
                table: "QuickAssessmentQuestions",
                keyColumn: "Id",
                keyValue: 22L,
                column: "CreatedDate",
                value: new DateTime(2021, 12, 22, 13, 54, 44, 871, DateTimeKind.Utc).AddTicks(4572));

            migrationBuilder.UpdateData(
                table: "QuickAssessmentQuestions",
                keyColumn: "Id",
                keyValue: 23L,
                column: "CreatedDate",
                value: new DateTime(2021, 12, 22, 13, 54, 44, 871, DateTimeKind.Utc).AddTicks(6776));

            migrationBuilder.UpdateData(
                table: "QuickAssessmentQuestions",
                keyColumn: "Id",
                keyValue: 24L,
                column: "CreatedDate",
                value: new DateTime(2021, 12, 22, 13, 54, 44, 871, DateTimeKind.Utc).AddTicks(8055));

            migrationBuilder.UpdateData(
                table: "QuickAssessmentQuestions",
                keyColumn: "Id",
                keyValue: 25L,
                column: "CreatedDate",
                value: new DateTime(2021, 12, 22, 13, 54, 44, 871, DateTimeKind.Utc).AddTicks(9459));

            migrationBuilder.UpdateData(
                table: "QuickAssessmentQuestions",
                keyColumn: "Id",
                keyValue: 26L,
                column: "CreatedDate",
                value: new DateTime(2021, 12, 22, 13, 54, 44, 872, DateTimeKind.Utc).AddTicks(913));

            migrationBuilder.UpdateData(
                table: "QuickAssessmentQuestions",
                keyColumn: "Id",
                keyValue: 27L,
                column: "CreatedDate",
                value: new DateTime(2021, 12, 22, 13, 54, 44, 872, DateTimeKind.Utc).AddTicks(2245));

            migrationBuilder.UpdateData(
                table: "QuickAssessmentQuestions",
                keyColumn: "Id",
                keyValue: 28L,
                column: "CreatedDate",
                value: new DateTime(2021, 12, 22, 13, 54, 44, 872, DateTimeKind.Utc).AddTicks(3888));

            migrationBuilder.UpdateData(
                table: "QuickAssessmentQuestions",
                keyColumn: "Id",
                keyValue: 29L,
                column: "CreatedDate",
                value: new DateTime(2021, 12, 22, 13, 54, 44, 872, DateTimeKind.Utc).AddTicks(5348));

            migrationBuilder.UpdateData(
                table: "QuickAssessmentQuestions",
                keyColumn: "Id",
                keyValue: 30L,
                column: "CreatedDate",
                value: new DateTime(2021, 12, 22, 13, 54, 44, 872, DateTimeKind.Utc).AddTicks(6715));

            migrationBuilder.UpdateData(
                table: "QuickAssessmentQuestions",
                keyColumn: "Id",
                keyValue: 31L,
                column: "CreatedDate",
                value: new DateTime(2021, 12, 22, 13, 54, 44, 872, DateTimeKind.Utc).AddTicks(6749));

            migrationBuilder.UpdateData(
                table: "QuickAssessmentQuestions",
                keyColumn: "Id",
                keyValue: 32L,
                column: "CreatedDate",
                value: new DateTime(2021, 12, 22, 13, 54, 44, 872, DateTimeKind.Utc).AddTicks(7897));

            migrationBuilder.UpdateData(
                table: "QuickAssessmentQuestions",
                keyColumn: "Id",
                keyValue: 33L,
                column: "CreatedDate",
                value: new DateTime(2021, 12, 22, 13, 54, 44, 872, DateTimeKind.Utc).AddTicks(9121));

            migrationBuilder.UpdateData(
                table: "RelationshipToPatient",
                keyColumn: "Id",
                keyValue: 3L,
                column: "Value",
                value: "Care giver​");

            migrationBuilder.UpdateData(
                table: "RelationshipToPatient",
                keyColumn: "Id",
                keyValue: 5L,
                column: "Value",
                value: "Handicapped dependent​");

            migrationBuilder.UpdateData(
                table: "RelationshipToPatient",
                keyColumn: "Id",
                keyValue: 8L,
                column: "Value",
                value: "Employee​");

            migrationBuilder.UpdateData(
                table: "RelationshipToPatient",
                keyColumn: "Id",
                keyValue: 13L,
                column: "Value",
                value: "Father​");

            migrationBuilder.UpdateData(
                table: "RelationshipToPatient",
                keyColumn: "Id",
                keyValue: 17L,
                column: "Value",
                value: "Manager​");

            migrationBuilder.UpdateData(
                table: "RelationshipToPatient",
                keyColumn: "Id",
                keyValue: 18L,
                column: "Value",
                value: "Mother​");

            migrationBuilder.UpdateData(
                table: "RelationshipToPatient",
                keyColumn: "Id",
                keyValue: 20L,
                column: "Value",
                value: "Other adult​");

            migrationBuilder.UpdateData(
                table: "RelationshipToPatient",
                keyColumn: "Id",
                keyValue: 22L,
                column: "Value",
                value: "Owner​​");

            migrationBuilder.UpdateData(
                table: "RelationshipToPatient",
                keyColumn: "Id",
                keyValue: 26L,
                column: "Value",
                value: "Sibling​");

            migrationBuilder.UpdateData(
                table: "RelationshipToPatient",
                keyColumn: "Id",
                keyValue: 28L,
                column: "Value",
                value: "Spouse​");

            migrationBuilder.UpdateData(
                table: "RelationshipToPatient",
                keyColumn: "Id",
                keyValue: 29L,
                column: "Value",
                value: "Trainer​​");

            migrationBuilder.UpdateData(
                table: "RelationshipToPatient",
                keyColumn: "Id",
                keyValue: 31L,
                column: "Value",
                value: "Ward of court​");

            migrationBuilder.UpdateData(
                table: "ResourceType",
                keyColumn: "Id",
                keyValue: 2L,
                column: "Value",
                value: "IRA/401K​");

            migrationBuilder.UpdateData(
                table: "ResourceType",
                keyColumn: "Id",
                keyValue: 3L,
                column: "Value",
                value: "Vehicle, Primary​");

            migrationBuilder.UpdateData(
                table: "ResourceType",
                keyColumn: "Id",
                keyValue: 5L,
                column: "Value",
                value: "Real Property, Home​");

            migrationBuilder.UpdateData(
                table: "ResourceType",
                keyColumn: "Id",
                keyValue: 6L,
                column: "Value",
                value: "Real Property, Building​");

            migrationBuilder.UpdateData(
                table: "ResourceType",
                keyColumn: "Id",
                keyValue: 8L,
                column: "Value",
                value: "Real Property, Life Estates​");

            migrationBuilder.UpdateData(
                table: "ResourceType",
                keyColumn: "Id",
                keyValue: 12L,
                column: "Value",
                value: "Contracts for Care​");

            migrationBuilder.UpdateData(
                table: "ResourceType",
                keyColumn: "Id",
                keyValue: 13L,
                column: "Value",
                value: "Escrow Accounts​");

            migrationBuilder.UpdateData(
                table: "ResourceType",
                keyColumn: "Id",
                keyValue: 15L,
                column: "Value",
                value: "Home Sale Proceeds​");

            migrationBuilder.UpdateData(
                table: "ResourceType",
                keyColumn: "Id",
                keyValue: 16L,
                column: "Value",
                value: "Income Producing Property​");

            migrationBuilder.UpdateData(
                table: "ResourceType",
                keyColumn: "Id",
                keyValue: 17L,
                column: "Value",
                value: "Individual Development Accounts​");

            migrationBuilder.UpdateData(
                table: "ResourceType",
                keyColumn: "Id",
                keyValue: 18L,
                column: "Value",
                value: "Life Insurance​​");

            migrationBuilder.UpdateData(
                table: "ResourceType",
                keyColumn: "Id",
                keyValue: 20L,
                column: "Value",
                value: "Pension Plans​");

            migrationBuilder.UpdateData(
                table: "ResourceType",
                keyColumn: "Id",
                keyValue: 22L,
                column: "Value",
                value: "Do Not Want to Provide​​​");

            migrationBuilder.UpdateData(
                table: "ResourceTypeCurrentStatus",
                keyColumn: "Id",
                keyValue: 1L,
                column: "Value",
                value: "Currently Owned​");

            migrationBuilder.UpdateData(
                table: "ResourceTypeCurrentStatus",
                keyColumn: "Id",
                keyValue: 2L,
                column: "Value",
                value: "Sold Less Than 1 Year Ago​");

            migrationBuilder.UpdateData(
                table: "ResourceTypeCurrentStatus",
                keyColumn: "Id",
                keyValue: 3L,
                column: "Value",
                value: "Sold More Than 1 Year Ago​");

            migrationBuilder.UpdateData(
                table: "ResourceTypeCurrentStatus",
                keyColumn: "Id",
                keyValue: 5L,
                column: "Value",
                value: "Transferred More Than 5 Years Ago​");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: -1L,
                column: "Password",
                value: "$2a$12$vuNov/KtFIDTj/lJSVz66.iAb3a5EioWh5dIBkkrgBLuMqiQXpZHm");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1L,
                column: "Password",
                value: "$2a$12$kyMDjg2sgeQC8oLbJ5t3s.ckkpHIBjPQc/l13QrIWdsxD.tbWKF92");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2L,
                column: "Password",
                value: "$2a$12$bOyYuvFtbE4buOKluJ8Ph.6r/fwctd3qF.xRhR4rzM5gREdR/5d3y");

            migrationBuilder.UpdateData(
                table: "Validators",
                keyColumn: "Id",
                keyValue: 1L,
                column: "CreatedDate",
                value: new DateTime(2021, 12, 22, 13, 54, 44, 873, DateTimeKind.Utc).AddTicks(2651));

            migrationBuilder.UpdateData(
                table: "Validators",
                keyColumn: "Id",
                keyValue: 2L,
                column: "CreatedDate",
                value: new DateTime(2021, 12, 22, 13, 54, 44, 873, DateTimeKind.Utc).AddTicks(3511));

            migrationBuilder.UpdateData(
                table: "Validators",
                keyColumn: "Id",
                keyValue: 3L,
                column: "CreatedDate",
                value: new DateTime(2021, 12, 22, 13, 54, 44, 873, DateTimeKind.Utc).AddTicks(4203));

            migrationBuilder.UpdateData(
                table: "Validators",
                keyColumn: "Id",
                keyValue: 4L,
                column: "CreatedDate",
                value: new DateTime(2021, 12, 22, 13, 54, 44, 873, DateTimeKind.Utc).AddTicks(4226));

            migrationBuilder.UpdateData(
                table: "Validators",
                keyColumn: "Id",
                keyValue: 5L,
                column: "CreatedDate",
                value: new DateTime(2021, 12, 22, 13, 54, 44, 873, DateTimeKind.Utc).AddTicks(4228));

            migrationBuilder.UpdateData(
                table: "Validators",
                keyColumn: "Id",
                keyValue: 6L,
                column: "CreatedDate",
                value: new DateTime(2021, 12, 22, 13, 54, 44, 873, DateTimeKind.Utc).AddTicks(4239));

            migrationBuilder.UpdateData(
                table: "Validators",
                keyColumn: "Id",
                keyValue: 7L,
                column: "CreatedDate",
                value: new DateTime(2021, 12, 22, 13, 54, 44, 873, DateTimeKind.Utc).AddTicks(4240));

            migrationBuilder.UpdateData(
                table: "Validators",
                keyColumn: "Id",
                keyValue: 8L,
                column: "CreatedDate",
                value: new DateTime(2021, 12, 22, 13, 54, 44, 873, DateTimeKind.Utc).AddTicks(4242));

            migrationBuilder.UpdateData(
                table: "Validators",
                keyColumn: "Id",
                keyValue: 9L,
                column: "CreatedDate",
                value: new DateTime(2021, 12, 22, 13, 54, 44, 873, DateTimeKind.Utc).AddTicks(4243));

            migrationBuilder.UpdateData(
                table: "Validators",
                keyColumn: "Id",
                keyValue: 10L,
                column: "CreatedDate",
                value: new DateTime(2021, 12, 22, 13, 54, 44, 873, DateTimeKind.Utc).AddTicks(4245));

            migrationBuilder.UpdateData(
                table: "Validators",
                keyColumn: "Id",
                keyValue: 11L,
                column: "CreatedDate",
                value: new DateTime(2021, 12, 22, 13, 54, 44, 873, DateTimeKind.Utc).AddTicks(4246));

            migrationBuilder.UpdateData(
                table: "Validators",
                keyColumn: "Id",
                keyValue: 12L,
                column: "CreatedDate",
                value: new DateTime(2021, 12, 22, 13, 54, 44, 873, DateTimeKind.Utc).AddTicks(4247));

            migrationBuilder.UpdateData(
                table: "Validators",
                keyColumn: "Id",
                keyValue: 13L,
                column: "CreatedDate",
                value: new DateTime(2021, 12, 22, 13, 54, 44, 873, DateTimeKind.Utc).AddTicks(4249));

            migrationBuilder.UpdateData(
                table: "Validators",
                keyColumn: "Id",
                keyValue: 14L,
                column: "CreatedDate",
                value: new DateTime(2021, 12, 22, 13, 54, 44, 873, DateTimeKind.Utc).AddTicks(4250));

            migrationBuilder.UpdateData(
                table: "Validators",
                keyColumn: "Id",
                keyValue: 15L,
                column: "CreatedDate",
                value: new DateTime(2021, 12, 22, 13, 54, 44, 873, DateTimeKind.Utc).AddTicks(4251));

            migrationBuilder.UpdateData(
                table: "Validators",
                keyColumn: "Id",
                keyValue: 16L,
                column: "CreatedDate",
                value: new DateTime(2021, 12, 22, 13, 54, 44, 873, DateTimeKind.Utc).AddTicks(4253));

            migrationBuilder.UpdateData(
                table: "Validators",
                keyColumn: "Id",
                keyValue: 17L,
                column: "CreatedDate",
                value: new DateTime(2021, 12, 22, 13, 54, 44, 873, DateTimeKind.Utc).AddTicks(4254));

            migrationBuilder.UpdateData(
                table: "Validators",
                keyColumn: "Id",
                keyValue: 18L,
                column: "CreatedDate",
                value: new DateTime(2021, 12, 22, 13, 54, 44, 873, DateTimeKind.Utc).AddTicks(4255));

            migrationBuilder.UpdateData(
                table: "Validators",
                keyColumn: "Id",
                keyValue: 19L,
                column: "CreatedDate",
                value: new DateTime(2021, 12, 22, 13, 54, 44, 873, DateTimeKind.Utc).AddTicks(4256));

            migrationBuilder.UpdateData(
                table: "Validators",
                keyColumn: "Id",
                keyValue: 20L,
                column: "CreatedDate",
                value: new DateTime(2021, 12, 22, 13, 54, 44, 873, DateTimeKind.Utc).AddTicks(4257));

            migrationBuilder.UpdateData(
                table: "Validators",
                keyColumn: "Id",
                keyValue: 21L,
                column: "CreatedDate",
                value: new DateTime(2021, 12, 22, 13, 54, 44, 873, DateTimeKind.Utc).AddTicks(4259));

            migrationBuilder.UpdateData(
                table: "Validators",
                keyColumn: "Id",
                keyValue: 22L,
                column: "CreatedDate",
                value: new DateTime(2021, 12, 22, 13, 54, 44, 873, DateTimeKind.Utc).AddTicks(4260));

            migrationBuilder.UpdateData(
                table: "Validators",
                keyColumn: "Id",
                keyValue: 23L,
                column: "CreatedDate",
                value: new DateTime(2021, 12, 22, 13, 54, 44, 873, DateTimeKind.Utc).AddTicks(4261));

            migrationBuilder.UpdateData(
                table: "Validators",
                keyColumn: "Id",
                keyValue: 24L,
                column: "CreatedDate",
                value: new DateTime(2021, 12, 22, 13, 54, 44, 873, DateTimeKind.Utc).AddTicks(4263));

            migrationBuilder.UpdateData(
                table: "Validators",
                keyColumn: "Id",
                keyValue: 25L,
                column: "CreatedDate",
                value: new DateTime(2021, 12, 22, 13, 54, 44, 873, DateTimeKind.Utc).AddTicks(4264));

            migrationBuilder.UpdateData(
                table: "Validators",
                keyColumn: "Id",
                keyValue: 26L,
                column: "CreatedDate",
                value: new DateTime(2021, 12, 22, 13, 54, 44, 873, DateTimeKind.Utc).AddTicks(4266));

            migrationBuilder.UpdateData(
                table: "Validators",
                keyColumn: "Id",
                keyValue: 27L,
                column: "CreatedDate",
                value: new DateTime(2021, 12, 22, 13, 54, 44, 873, DateTimeKind.Utc).AddTicks(4267));

            migrationBuilder.UpdateData(
                table: "Validators",
                keyColumn: "Id",
                keyValue: 28L,
                column: "CreatedDate",
                value: new DateTime(2021, 12, 22, 13, 54, 44, 873, DateTimeKind.Utc).AddTicks(4268));

            migrationBuilder.UpdateData(
                table: "Validators",
                keyColumn: "Id",
                keyValue: 29L,
                column: "CreatedDate",
                value: new DateTime(2021, 12, 22, 13, 54, 44, 873, DateTimeKind.Utc).AddTicks(4269));

            migrationBuilder.UpdateData(
                table: "Validators",
                keyColumn: "Id",
                keyValue: 30L,
                column: "CreatedDate",
                value: new DateTime(2021, 12, 22, 13, 54, 44, 873, DateTimeKind.Utc).AddTicks(4271));

            migrationBuilder.UpdateData(
                table: "Validators",
                keyColumn: "Id",
                keyValue: 31L,
                column: "CreatedDate",
                value: new DateTime(2021, 12, 22, 13, 54, 44, 873, DateTimeKind.Utc).AddTicks(4272));

            migrationBuilder.UpdateData(
                table: "Validators",
                keyColumn: "Id",
                keyValue: 32L,
                column: "CreatedDate",
                value: new DateTime(2021, 12, 22, 13, 54, 44, 873, DateTimeKind.Utc).AddTicks(4273));
        }
    }
}
