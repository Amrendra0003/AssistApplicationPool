using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace HealthWare.ActiveASSIST.Repositories.Migrations
{
    public partial class AddVerificationDocumentTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "VerificationDocument",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AssessmentId = table.Column<long>(type: "bigint", nullable: true),
                    IdVerification = table.Column<long>(type: "bigint", nullable: true),
                    AddressVerification = table.Column<long>(type: "bigint", nullable: true),
                    OtherVerification = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VerificationDocument", x => x.Id);
                    table.ForeignKey(
                        name: "FK_VerificationDocument_Assessment_AssessmentId",
                        column: x => x.AssessmentId,
                        principalTable: "Assessment",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

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
                column: "Password",
                value: "$2a$12$DRDUgXCFLmGaZjJFXjeiwupe6jDAHm747xqxCUSCmZkdm2GmmfWkO");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1L,
                column: "Password",
                value: "$2a$12$GVRA6M//QGPguvd/uP/d1ewnf7EvMhmUmxO85K2V/oKE8gjOxLSfu");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2L,
                column: "Password",
                value: "$2a$12$93Hnjw2QWyBsWJ0bf92cSOdJV9ZCRnlYWmdVwnLX8CtPlY59yiE16");

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

            migrationBuilder.CreateIndex(
                name: "IX_VerificationDocument_AssessmentId",
                table: "VerificationDocument",
                column: "AssessmentId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "VerificationDocument");

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
        }
    }
}
