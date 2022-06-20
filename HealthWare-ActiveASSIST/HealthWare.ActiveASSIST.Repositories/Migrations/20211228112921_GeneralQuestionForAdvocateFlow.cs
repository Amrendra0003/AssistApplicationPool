using Microsoft.EntityFrameworkCore.Migrations;

namespace HealthWare.ActiveASSIST.Repositories.Migrations
{
    public partial class GeneralQuestionForAdvocateFlow : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "RoleName",
                table: "Question",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.InsertData(
                table: "AnswerOption",
                columns: new[] { "Id", "Content", "Name", "Order", "QuestionId", "Value" },
                values: new object[,]
                {
                    { 51L, null, "pregnantNow", 1, 38L, "Pregnant now / in past 6 months" },
                    { 52L, null, "veteran", 2, 38L, "Veteran" },
                    { 53L, null, "memberOfIndianTribe", 3, 38L, "Member of Indian tribe" },
                    { 54L, null, "formerFosterYouth", 4, 38L, "Former Foster Youth" },
                    { 55L, null, "deemed", 1, 39L, "Deemed as disabled for 12 months or longer" },
                    { 56L, null, "you/member", 2, 39L, "You/member of your family been declared legally blind" },
                    { 57L, null, "inCrime", 1, 40L, "In crime related violence (as a victim)" },
                    { 58L, null, "inMotorVehicle", 2, 40L, "In motor vehicle accident" },
                    { 59L, null, "onTheJob", 3, 40L, "On the job" },
                    { 60L, null, null, 1, 41L, "No" },
                    { 61L, null, null, 2, 41L, "Yes" }
                });

            migrationBuilder.UpdateData(
                table: "Question",
                keyColumn: "Id",
                keyValue: 32L,
                column: "RoleName",
                value: "Patient");

            migrationBuilder.UpdateData(
                table: "Question",
                keyColumn: "Id",
                keyValue: 33L,
                column: "RoleName",
                value: "Patient");

            migrationBuilder.UpdateData(
                table: "Question",
                keyColumn: "Id",
                keyValue: 34L,
                column: "RoleName",
                value: "Patient");

            migrationBuilder.UpdateData(
                table: "Question",
                keyColumn: "Id",
                keyValue: 35L,
                column: "RoleName",
                value: "Patient");

            migrationBuilder.UpdateData(
                table: "Question",
                keyColumn: "Id",
                keyValue: 36L,
                column: "RoleName",
                value: "Patient");

            migrationBuilder.UpdateData(
                table: "Question",
                keyColumn: "Id",
                keyValue: 37L,
                column: "RoleName",
                value: "Patient");

            migrationBuilder.InsertData(
                table: "Question",
                columns: new[] { "Id", "ControlId", "CssStyle", "Description", "DisplayFormat", "IsRequired", "ParentId", "QuestionName", "RoleName", "Type", "UiType" },
                values: new object[,]
                {
                    { 41L, 8L, "tgl_style", null, "header", true, 40L, "Was a report filed?", "Advocate", null, null },
                    { 39L, 3L, "rbn_style1", null, "header", true, null, "Do any of the following health conditions apply to you?", "Advocate", null, null },
                    { 38L, 3L, "rbn_style1", "If none of them apply, you can directly move to the next question.", "header", false, null, "Please select the options that apply to you and click on next.", "Advocate", null, null },
                    { 40L, 3L, "rbn_style1", null, "header", true, null, "Select if you have been injured", "Advocate", null, null }
                });

            migrationBuilder.InsertData(
                table: "ScreenQuestionMapping",
                columns: new[] { "Id", "KeyName", "QuestionId", "ScreenId" },
                values: new object[,]
                {
                    { 40L, "beenInjured", 40L, 8L },
                    { 41L, "reportFiledCrime", 41L, 8L },
                    { 38L, "serviceProgram", 38L, 8L },
                    { 39L, "healthConditiion", 39L, 8L }
                });

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
                column: "Password",
                value: "$2a$12$bG1CSkTzMa9ZxRvuaTSehO87OuATtLlhi6XbC0JzX6eL.YRV6X1Pm");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2L,
                column: "Password",
                value: "$2a$12$shzWINP5YBb9NUO9hICks.HXZ1ewRSLJ1RAO1mbD/o7ysiO028ZwG");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AnswerOption",
                keyColumn: "Id",
                keyValue: 51L);

            migrationBuilder.DeleteData(
                table: "AnswerOption",
                keyColumn: "Id",
                keyValue: 52L);

            migrationBuilder.DeleteData(
                table: "AnswerOption",
                keyColumn: "Id",
                keyValue: 53L);

            migrationBuilder.DeleteData(
                table: "AnswerOption",
                keyColumn: "Id",
                keyValue: 54L);

            migrationBuilder.DeleteData(
                table: "AnswerOption",
                keyColumn: "Id",
                keyValue: 55L);

            migrationBuilder.DeleteData(
                table: "AnswerOption",
                keyColumn: "Id",
                keyValue: 56L);

            migrationBuilder.DeleteData(
                table: "AnswerOption",
                keyColumn: "Id",
                keyValue: 57L);

            migrationBuilder.DeleteData(
                table: "AnswerOption",
                keyColumn: "Id",
                keyValue: 58L);

            migrationBuilder.DeleteData(
                table: "AnswerOption",
                keyColumn: "Id",
                keyValue: 59L);

            migrationBuilder.DeleteData(
                table: "AnswerOption",
                keyColumn: "Id",
                keyValue: 60L);

            migrationBuilder.DeleteData(
                table: "AnswerOption",
                keyColumn: "Id",
                keyValue: 61L);

            migrationBuilder.DeleteData(
                table: "Question",
                keyColumn: "Id",
                keyValue: 38L);

            migrationBuilder.DeleteData(
                table: "Question",
                keyColumn: "Id",
                keyValue: 39L);

            migrationBuilder.DeleteData(
                table: "Question",
                keyColumn: "Id",
                keyValue: 40L);

            migrationBuilder.DeleteData(
                table: "Question",
                keyColumn: "Id",
                keyValue: 41L);

            migrationBuilder.DeleteData(
                table: "ScreenQuestionMapping",
                keyColumn: "Id",
                keyValue: 38L);

            migrationBuilder.DeleteData(
                table: "ScreenQuestionMapping",
                keyColumn: "Id",
                keyValue: 39L);

            migrationBuilder.DeleteData(
                table: "ScreenQuestionMapping",
                keyColumn: "Id",
                keyValue: 40L);

            migrationBuilder.DeleteData(
                table: "ScreenQuestionMapping",
                keyColumn: "Id",
                keyValue: 41L);

            migrationBuilder.DropColumn(
                name: "RoleName",
                table: "Question");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: -1L,
                column: "Password",
                value: "$2a$12$Kl4bFsuJWwICc.AHbcGO9uIsXGccnaeT1B6VOPEf4EhWXDRK.p.Mi");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1L,
                column: "Password",
                value: "$2a$12$HdwVlWh5xfNJuA9aoftJfukq/Ld.d95tsxAjFdPgZnUGXnoPEkHDO");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2L,
                column: "Password",
                value: "$2a$12$wo.5VPdQL6eNTq521PoM3.zuQiYv8aDD3s4UrTLE9gF4wOYCJ9bgW");
        }
    }
}
