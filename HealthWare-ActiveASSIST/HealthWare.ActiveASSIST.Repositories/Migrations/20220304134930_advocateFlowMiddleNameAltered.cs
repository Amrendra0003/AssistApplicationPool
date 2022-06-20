using Microsoft.EntityFrameworkCore.Migrations;

namespace HealthWare.ActiveASSIST.Repositories.Migrations
{
    public partial class advocateFlowMiddleNameAltered : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "MainUser",
                keyColumn: "Id",
                keyValue: -1L,
                column: "Password",
                value: "$2a$12$cvJdPAw/Sjd0lfNNQ4uyAe7xo/zbJSPGx9ntUrRHT41VFhYmBDR0q");

            migrationBuilder.UpdateData(
                table: "MainUser",
                keyColumn: "Id",
                keyValue: 1L,
                column: "Password",
                value: "$2a$12$58VPyCC0KP6ElGm0pN7/J.13wpT5oNcswZCYcePf1ZyhwvD2ZY.4i");

            migrationBuilder.UpdateData(
                table: "MainUser",
                keyColumn: "Id",
                keyValue: 2L,
                column: "Password",
                value: "$2a$12$r1eZmWX6egc.sJtwmUTBIeP6xXqGmbTNrOnGW/SkFljBzqQSP8uLy");

            migrationBuilder.UpdateData(
                table: "MainUser",
                keyColumn: "Id",
                keyValue: 3L,
                column: "Password",
                value: "$2a$12$gHdeoKUP/fJw/8Jocqmyzu773Y5SzYbYChjni12mIuMu0vhjEoLtm");

            migrationBuilder.UpdateData(
                table: "MainUser",
                keyColumn: "Id",
                keyValue: 4L,
                column: "Password",
                value: "$2a$12$tKb00L.R5RFlSOv9YmMN/eaNg8qQ8T18ryLtynjsdaMiPSWWUy0A2");

            migrationBuilder.UpdateData(
                table: "MainUser",
                keyColumn: "Id",
                keyValue: 5L,
                column: "Password",
                value: "$2a$12$SXz9kaKchxkAY07/i6OEfOgO9cokXeZtv.RUB9ltoloIF5AjqkqvO");

            migrationBuilder.UpdateData(
                table: "MainUser",
                keyColumn: "Id",
                keyValue: 6L,
                column: "Password",
                value: "$2a$12$o8XMIEpY5opAToiYiE659ufe1XoTF7znBeotJ7pf/T6CZkXxcUB56");

            migrationBuilder.UpdateData(
                table: "Question",
                keyColumn: "Id",
                keyValue: 8L,
                columns: new[] { "IsRequired", "QuestionName" },
                values: new object[] { true, "Last Name" });

            migrationBuilder.UpdateData(
                table: "Question",
                keyColumn: "Id",
                keyValue: 9L,
                columns: new[] { "ControlId", "CssStyle", "IsRequired", "QuestionName" },
                values: new object[] { 6L, "dt_birth", false, "date of birth" });

            migrationBuilder.UpdateData(
                table: "Question",
                keyColumn: "Id",
                keyValue: 10L,
                columns: new[] { "ControlId", "CssStyle", "IsRequired", "QuestionName" },
                values: new object[] { 2L, "dd_gender_class", true, "Gender" });

            migrationBuilder.UpdateData(
                table: "Question",
                keyColumn: "Id",
                keyValue: 11L,
                columns: new[] { "CssStyle", "QuestionName" },
                values: new object[] { "dd_marital_class", "Marital Status" });

            migrationBuilder.UpdateData(
                table: "Question",
                keyColumn: "Id",
                keyValue: 12L,
                columns: new[] { "ControlId", "CssStyle", "DisplayFormat", "QuestionName" },
                values: new object[] { 5L, "txt_style2", "partition", "Email" });

            migrationBuilder.UpdateData(
                table: "Question",
                keyColumn: "Id",
                keyValue: 13L,
                columns: new[] { "ControlId", "CssStyle", "DisplayFormat", "QuestionName" },
                values: new object[] { 7L, "txt_style3", "inline", "Cell number" });

            migrationBuilder.UpdateData(
                table: "Question",
                keyColumn: "Id",
                keyValue: 14L,
                columns: new[] { "ControlId", "CssStyle", "DisplayFormat", "QuestionName" },
                values: new object[] { 8L, "tgl_style", "header", "Do you currently or in the last 60 days have/had health insurance?" });

            migrationBuilder.UpdateData(
                table: "Question",
                keyColumn: "Id",
                keyValue: 15L,
                columns: new[] { "ControlId", "CssStyle", "IsRequired", "ParentId", "QuestionName" },
                values: new object[] { 4L, "label", false, 14L, "Enter the following details" });

            migrationBuilder.UpdateData(
                table: "Question",
                keyColumn: "Id",
                keyValue: 16L,
                columns: new[] { "ControlId", "CssStyle", "DisplayFormat", "QuestionName" },
                values: new object[] { 5L, "txt_style1", "inline", "Payer Name" });

            migrationBuilder.UpdateData(
                table: "Question",
                keyColumn: "Id",
                keyValue: 17L,
                columns: new[] { "IsRequired", "QuestionName" },
                values: new object[] { true, "Group Name" });

            migrationBuilder.UpdateData(
                table: "Question",
                keyColumn: "Id",
                keyValue: 18L,
                columns: new[] { "ControlId", "QuestionName" },
                values: new object[] { 1L, "Group Number" });

            migrationBuilder.UpdateData(
                table: "Question",
                keyColumn: "Id",
                keyValue: 19L,
                column: "QuestionName",
                value: "Policy Number");

            migrationBuilder.UpdateData(
                table: "Question",
                keyColumn: "Id",
                keyValue: 20L,
                columns: new[] { "ControlId", "CssStyle", "QuestionName" },
                values: new object[] { 6L, "dt_birth", "Effective From" });

            migrationBuilder.UpdateData(
                table: "Question",
                keyColumn: "Id",
                keyValue: 21L,
                column: "QuestionName",
                value: "Termination");

            migrationBuilder.UpdateData(
                table: "Question",
                keyColumn: "Id",
                keyValue: 22L,
                columns: new[] { "ControlId", "CssStyle", "DisplayFormat", "IsRequired", "ParentId", "QuestionName" },
                values: new object[] { 4L, "label", "header", false, null, "Tell us about your household" });

            migrationBuilder.UpdateData(
                table: "Question",
                keyColumn: "Id",
                keyValue: 23L,
                columns: new[] { "ControlId", "CssStyle", "IsRequired", "QuestionName" },
                values: new object[] { 11L, "numeric_counter_style", true, "Total Number of members living in your household" });

            migrationBuilder.UpdateData(
                table: "Question",
                keyColumn: "Id",
                keyValue: 24L,
                column: "QuestionName",
                value: "Minor children for whom you have full custody?");

            migrationBuilder.UpdateData(
                table: "Question",
                keyColumn: "Id",
                keyValue: 25L,
                columns: new[] { "ControlId", "CssStyle", "QuestionName" },
                values: new object[] { 8L, "tgl_style", "Are you employed?" });

            migrationBuilder.UpdateData(
                table: "Question",
                keyColumn: "Id",
                keyValue: 26L,
                columns: new[] { "ParentId", "QuestionName" },
                values: new object[] { 25L, "Is anyone in your household employed?" });

            migrationBuilder.UpdateData(
                table: "Question",
                keyColumn: "Id",
                keyValue: 27L,
                columns: new[] { "ControlId", "CssStyle", "Description", "ParentId", "QuestionName" },
                values: new object[] { 3L, "rbn_style1", "If none of them apply, you can directly move to the next question.", 26L, "Do you currently receive any of the following?" });

            migrationBuilder.UpdateData(
                table: "Question",
                keyColumn: "Id",
                keyValue: 28L,
                columns: new[] { "ControlId", "CssStyle", "Description", "IsRequired", "ParentId", "QuestionName" },
                values: new object[] { 4L, "label", null, false, null, "Enter household income and resources" });

            migrationBuilder.UpdateData(
                table: "Question",
                keyColumn: "Id",
                keyValue: 29L,
                columns: new[] { "ControlId", "CssStyle", "IsRequired", "QuestionName" },
                values: new object[] { 5L, "txt_style1", true, "Estimated Household Income" });

            migrationBuilder.UpdateData(
                table: "Question",
                keyColumn: "Id",
                keyValue: 30L,
                columns: new[] { "ControlId", "CssStyle", "DisplayFormat", "QuestionName" },
                values: new object[] { 2L, "dd_income_class", "inline", "Income pay period" });

            migrationBuilder.UpdateData(
                table: "Question",
                keyColumn: "Id",
                keyValue: 31L,
                columns: new[] { "ControlId", "CssStyle", "Description", "DisplayFormat", "QuestionName" },
                values: new object[] { 5L, "txt_style1", "Please estimate the total resource value held by all the members of the household in the form  of checking & savings, retirement accounts, property (home, vehicle, etc) and any others assets.", "header", "Estimated Household Resources" });

            migrationBuilder.UpdateData(
                table: "Question",
                keyColumn: "Id",
                keyValue: 32L,
                columns: new[] { "ControlId", "CssStyle", "Description", "IsRequired", "QuestionName", "RoleName" },
                values: new object[] { 10L, "rbn_style1", "If none of them apply, you can directly move to the next question.", false, "Please select the options that apply to you and click on next.", "Patient" });

            migrationBuilder.UpdateData(
                table: "Question",
                keyColumn: "Id",
                keyValue: 33L,
                columns: new[] { "Description", "IsRequired", "QuestionName" },
                values: new object[] { null, true, "Do any of the following health conditions apply to you?" });

            migrationBuilder.UpdateData(
                table: "Question",
                keyColumn: "Id",
                keyValue: 34L,
                column: "QuestionName",
                value: "Select if you have been injured");

            migrationBuilder.UpdateData(
                table: "Question",
                keyColumn: "Id",
                keyValue: 35L,
                columns: new[] { "ControlId", "CssStyle", "ParentId", "QuestionName" },
                values: new object[] { 8L, "tgl_style", 34L, "Was a report filed?" });

            migrationBuilder.UpdateData(
                table: "Question",
                keyColumn: "Id",
                keyValue: 38L,
                columns: new[] { "ControlId", "CssStyle", "DisplayFormat", "ParentId", "QuestionName", "RoleName" },
                values: new object[] { 5L, "txt_style1", "inline", null, "Middle Name", null });

            migrationBuilder.UpdateData(
                table: "ScreenQuestionMapping",
                keyColumn: "Id",
                keyValue: 7L,
                column: "KeyName",
                value: "lastName");

            migrationBuilder.UpdateData(
                table: "ScreenQuestionMapping",
                keyColumn: "Id",
                keyValue: 8L,
                column: "KeyName",
                value: "dateOfBirth");

            migrationBuilder.UpdateData(
                table: "ScreenQuestionMapping",
                keyColumn: "Id",
                keyValue: 9L,
                column: "KeyName",
                value: "gender");

            migrationBuilder.UpdateData(
                table: "ScreenQuestionMapping",
                keyColumn: "Id",
                keyValue: 10L,
                column: "KeyName",
                value: "maritalStatus");

            migrationBuilder.UpdateData(
                table: "ScreenQuestionMapping",
                keyColumn: "Id",
                keyValue: 11L,
                column: "KeyName",
                value: "email");

            migrationBuilder.UpdateData(
                table: "ScreenQuestionMapping",
                keyColumn: "Id",
                keyValue: 12L,
                column: "KeyName",
                value: "cellNumber");

            migrationBuilder.UpdateData(
                table: "ScreenQuestionMapping",
                keyColumn: "Id",
                keyValue: 13L,
                columns: new[] { "KeyName", "ScreenId" },
                values: new object[] { "insurance", 5L });

            migrationBuilder.UpdateData(
                table: "ScreenQuestionMapping",
                keyColumn: "Id",
                keyValue: 14L,
                column: "KeyName",
                value: "policyDetails");

            migrationBuilder.UpdateData(
                table: "ScreenQuestionMapping",
                keyColumn: "Id",
                keyValue: 15L,
                column: "KeyName",
                value: "payerName");

            migrationBuilder.UpdateData(
                table: "ScreenQuestionMapping",
                keyColumn: "Id",
                keyValue: 16L,
                column: "KeyName",
                value: "groupName");

            migrationBuilder.UpdateData(
                table: "ScreenQuestionMapping",
                keyColumn: "Id",
                keyValue: 17L,
                column: "KeyName",
                value: "groupNumber");

            migrationBuilder.UpdateData(
                table: "ScreenQuestionMapping",
                keyColumn: "Id",
                keyValue: 18L,
                column: "KeyName",
                value: "policyNumber");

            migrationBuilder.UpdateData(
                table: "ScreenQuestionMapping",
                keyColumn: "Id",
                keyValue: 19L,
                column: "KeyName",
                value: "effectiveFrom");

            migrationBuilder.UpdateData(
                table: "ScreenQuestionMapping",
                keyColumn: "Id",
                keyValue: 20L,
                column: "KeyName",
                value: "termination");

            migrationBuilder.UpdateData(
                table: "ScreenQuestionMapping",
                keyColumn: "Id",
                keyValue: 21L,
                columns: new[] { "KeyName", "ScreenId" },
                values: new object[] { null, 6L });

            migrationBuilder.UpdateData(
                table: "ScreenQuestionMapping",
                keyColumn: "Id",
                keyValue: 22L,
                column: "KeyName",
                value: "noOfHousehold");

            migrationBuilder.UpdateData(
                table: "ScreenQuestionMapping",
                keyColumn: "Id",
                keyValue: 23L,
                column: "KeyName",
                value: "minorChildren");

            migrationBuilder.UpdateData(
                table: "ScreenQuestionMapping",
                keyColumn: "Id",
                keyValue: 24L,
                column: "KeyName",
                value: "isEmployed");

            migrationBuilder.UpdateData(
                table: "ScreenQuestionMapping",
                keyColumn: "Id",
                keyValue: 25L,
                column: "KeyName",
                value: "isHouseholdEmployed");

            migrationBuilder.UpdateData(
                table: "ScreenQuestionMapping",
                keyColumn: "Id",
                keyValue: 26L,
                column: "KeyName",
                value: "programServices");

            migrationBuilder.UpdateData(
                table: "ScreenQuestionMapping",
                keyColumn: "Id",
                keyValue: 27L,
                columns: new[] { "KeyName", "ScreenId" },
                values: new object[] { null, 7L });

            migrationBuilder.UpdateData(
                table: "ScreenQuestionMapping",
                keyColumn: "Id",
                keyValue: 28L,
                column: "KeyName",
                value: "householdIncome");

            migrationBuilder.UpdateData(
                table: "ScreenQuestionMapping",
                keyColumn: "Id",
                keyValue: 29L,
                column: "KeyName",
                value: "incomePayPeriod");

            migrationBuilder.UpdateData(
                table: "ScreenQuestionMapping",
                keyColumn: "Id",
                keyValue: 30L,
                column: "KeyName",
                value: "householdResources");

            migrationBuilder.UpdateData(
                table: "ScreenQuestionMapping",
                keyColumn: "Id",
                keyValue: 31L,
                columns: new[] { "KeyName", "ScreenId" },
                values: new object[] { "serviceProgram", 8L });

            migrationBuilder.UpdateData(
                table: "ScreenQuestionMapping",
                keyColumn: "Id",
                keyValue: 32L,
                column: "KeyName",
                value: "healthConditiion");

            migrationBuilder.UpdateData(
                table: "ScreenQuestionMapping",
                keyColumn: "Id",
                keyValue: 33L,
                column: "KeyName",
                value: "beenInjured");

            migrationBuilder.UpdateData(
                table: "ScreenQuestionMapping",
                keyColumn: "Id",
                keyValue: 34L,
                column: "KeyName",
                value: "reportFiledCrime");

            migrationBuilder.UpdateData(
                table: "ScreenQuestionMapping",
                keyColumn: "Id",
                keyValue: 35L,
                columns: new[] { "KeyName", "QuestionId", "ScreenId" },
                values: new object[] { "aboutYourself", 6L, 4L });

            migrationBuilder.UpdateData(
                table: "ScreenQuestionMapping",
                keyColumn: "Id",
                keyValue: 36L,
                columns: new[] { "KeyName", "QuestionId", "ScreenId" },
                values: new object[] { "reportFiledMotor", 36L, 8L });

            migrationBuilder.UpdateData(
                table: "ScreenQuestionMapping",
                keyColumn: "Id",
                keyValue: 37L,
                column: "KeyName",
                value: "reportFiledJob");

            migrationBuilder.UpdateData(
                table: "ScreenQuestionMapping",
                keyColumn: "Id",
                keyValue: 38L,
                column: "KeyName",
                value: "serviceProgram");

            migrationBuilder.UpdateData(
                table: "ScreenQuestionMapping",
                keyColumn: "Id",
                keyValue: 39L,
                column: "KeyName",
                value: "healthConditiion");

            migrationBuilder.UpdateData(
                table: "ScreenQuestionMapping",
                keyColumn: "Id",
                keyValue: 40L,
                column: "KeyName",
                value: "beenInjured");

            migrationBuilder.UpdateData(
                table: "ScreenQuestionMapping",
                keyColumn: "Id",
                keyValue: 41L,
                column: "KeyName",
                value: "reportFiledCrime");

            migrationBuilder.UpdateData(
                table: "ScreenQuestionMapping",
                keyColumn: "Id",
                keyValue: 42L,
                columns: new[] { "KeyName", "QuestionId", "ScreenId" },
                values: new object[] { "middleName", 38L, 4L });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "MainUser",
                keyColumn: "Id",
                keyValue: -1L,
                column: "Password",
                value: "$2a$12$cXEOF8H8OiN7M48wLB6SoOyhNUCgfIFdUkuHj9EfCYEJzHZOvwwkG");

            migrationBuilder.UpdateData(
                table: "MainUser",
                keyColumn: "Id",
                keyValue: 1L,
                column: "Password",
                value: "$2a$12$FbEvTTtQsG.VNC0XnVmp3edu/Q923xR2RBJWUaIZgf2wZe0.5J0fi");

            migrationBuilder.UpdateData(
                table: "MainUser",
                keyColumn: "Id",
                keyValue: 2L,
                column: "Password",
                value: "$2a$12$QsYdmAQy0JT7CPk5hBZbT.dRW5Zg7zSrKLoVaSAyfWjNkU0jPgfZ6");

            migrationBuilder.UpdateData(
                table: "MainUser",
                keyColumn: "Id",
                keyValue: 3L,
                column: "Password",
                value: "$2a$12$WNIPBWInms0hZCr/1EFfs.wH0vGv1EMX3z6eULNEfdtEpR52stQCO");

            migrationBuilder.UpdateData(
                table: "MainUser",
                keyColumn: "Id",
                keyValue: 4L,
                column: "Password",
                value: "$2a$12$wp1lLWCITT7tlSlNMPriJO678NOfkhwwwslg/uZJBdh5EX4QQfwsW");

            migrationBuilder.UpdateData(
                table: "MainUser",
                keyColumn: "Id",
                keyValue: 5L,
                column: "Password",
                value: "$2a$12$bASRHykfDrxsVVeqBWW4QeHN10d4MFGgBdTBoXsj.ePNl4ypzjQUS");

            migrationBuilder.UpdateData(
                table: "MainUser",
                keyColumn: "Id",
                keyValue: 6L,
                column: "Password",
                value: "$2a$12$yCy5bTELYSQpA2SRickvsut.PEeGxXubp8VDX5xiNVIItambq39lu");

            migrationBuilder.UpdateData(
                table: "Question",
                keyColumn: "Id",
                keyValue: 8L,
                columns: new[] { "IsRequired", "QuestionName" },
                values: new object[] { false, "Middle Name" });

            migrationBuilder.UpdateData(
                table: "Question",
                keyColumn: "Id",
                keyValue: 9L,
                columns: new[] { "ControlId", "CssStyle", "IsRequired", "QuestionName" },
                values: new object[] { 5L, "txt_style1", true, "Last Name" });

            migrationBuilder.UpdateData(
                table: "Question",
                keyColumn: "Id",
                keyValue: 10L,
                columns: new[] { "ControlId", "CssStyle", "IsRequired", "QuestionName" },
                values: new object[] { 6L, "dt_birth", false, "date of birth" });

            migrationBuilder.UpdateData(
                table: "Question",
                keyColumn: "Id",
                keyValue: 11L,
                columns: new[] { "CssStyle", "QuestionName" },
                values: new object[] { "dd_gender_class", "Gender" });

            migrationBuilder.UpdateData(
                table: "Question",
                keyColumn: "Id",
                keyValue: 12L,
                columns: new[] { "ControlId", "CssStyle", "DisplayFormat", "QuestionName" },
                values: new object[] { 2L, "dd_marital_class", "inline", "Marital Status" });

            migrationBuilder.UpdateData(
                table: "Question",
                keyColumn: "Id",
                keyValue: 13L,
                columns: new[] { "ControlId", "CssStyle", "DisplayFormat", "QuestionName" },
                values: new object[] { 5L, "txt_style2", "partition", "Email" });

            migrationBuilder.UpdateData(
                table: "Question",
                keyColumn: "Id",
                keyValue: 14L,
                columns: new[] { "ControlId", "CssStyle", "DisplayFormat", "QuestionName" },
                values: new object[] { 7L, "txt_style3", "inline", "Cell number" });

            migrationBuilder.UpdateData(
                table: "Question",
                keyColumn: "Id",
                keyValue: 15L,
                columns: new[] { "ControlId", "CssStyle", "IsRequired", "ParentId", "QuestionName" },
                values: new object[] { 8L, "tgl_style", true, null, "Do you currently or in the last 60 days have/had health insurance?" });

            migrationBuilder.UpdateData(
                table: "Question",
                keyColumn: "Id",
                keyValue: 16L,
                columns: new[] { "ControlId", "CssStyle", "DisplayFormat", "QuestionName" },
                values: new object[] { 4L, "label", "header", "Enter the following details" });

            migrationBuilder.UpdateData(
                table: "Question",
                keyColumn: "Id",
                keyValue: 17L,
                columns: new[] { "IsRequired", "QuestionName" },
                values: new object[] { false, "Payer Name" });

            migrationBuilder.UpdateData(
                table: "Question",
                keyColumn: "Id",
                keyValue: 18L,
                columns: new[] { "ControlId", "QuestionName" },
                values: new object[] { 5L, "Group Name" });

            migrationBuilder.UpdateData(
                table: "Question",
                keyColumn: "Id",
                keyValue: 19L,
                column: "QuestionName",
                value: "Group Number");

            migrationBuilder.UpdateData(
                table: "Question",
                keyColumn: "Id",
                keyValue: 20L,
                columns: new[] { "ControlId", "CssStyle", "QuestionName" },
                values: new object[] { 1L, "txt_style1", "Policy Number" });

            migrationBuilder.UpdateData(
                table: "Question",
                keyColumn: "Id",
                keyValue: 21L,
                column: "QuestionName",
                value: "Effective From");

            migrationBuilder.UpdateData(
                table: "Question",
                keyColumn: "Id",
                keyValue: 22L,
                columns: new[] { "ControlId", "CssStyle", "DisplayFormat", "IsRequired", "ParentId", "QuestionName" },
                values: new object[] { 6L, "dt_birth", "inline", true, 14L, "Termination" });

            migrationBuilder.UpdateData(
                table: "Question",
                keyColumn: "Id",
                keyValue: 23L,
                columns: new[] { "ControlId", "CssStyle", "IsRequired", "QuestionName" },
                values: new object[] { 4L, "label", false, "Tell us about your household" });

            migrationBuilder.UpdateData(
                table: "Question",
                keyColumn: "Id",
                keyValue: 24L,
                column: "QuestionName",
                value: "Total Number of members living in your household");

            migrationBuilder.UpdateData(
                table: "Question",
                keyColumn: "Id",
                keyValue: 25L,
                columns: new[] { "ControlId", "CssStyle", "QuestionName" },
                values: new object[] { 11L, "numeric_counter_style", "Minor children for whom you have full custody?" });

            migrationBuilder.UpdateData(
                table: "Question",
                keyColumn: "Id",
                keyValue: 26L,
                columns: new[] { "ParentId", "QuestionName" },
                values: new object[] { null, "Are you employed?" });

            migrationBuilder.UpdateData(
                table: "Question",
                keyColumn: "Id",
                keyValue: 27L,
                columns: new[] { "ControlId", "CssStyle", "Description", "ParentId", "QuestionName" },
                values: new object[] { 8L, "tgl_style", null, 25L, "Is anyone in your household employed?" });

            migrationBuilder.UpdateData(
                table: "Question",
                keyColumn: "Id",
                keyValue: 28L,
                columns: new[] { "ControlId", "CssStyle", "Description", "IsRequired", "ParentId", "QuestionName" },
                values: new object[] { 3L, "rbn_style1", "If none of them apply, you can directly move to the next question.", true, 26L, "Do you currently receive any of the following?" });

            migrationBuilder.UpdateData(
                table: "Question",
                keyColumn: "Id",
                keyValue: 29L,
                columns: new[] { "ControlId", "CssStyle", "IsRequired", "QuestionName" },
                values: new object[] { 4L, "label", false, "Enter household income and resources" });

            migrationBuilder.UpdateData(
                table: "Question",
                keyColumn: "Id",
                keyValue: 30L,
                columns: new[] { "ControlId", "CssStyle", "DisplayFormat", "QuestionName" },
                values: new object[] { 5L, "txt_style1", "header", "Estimated Household Income" });

            migrationBuilder.UpdateData(
                table: "Question",
                keyColumn: "Id",
                keyValue: 31L,
                columns: new[] { "ControlId", "CssStyle", "Description", "DisplayFormat", "QuestionName" },
                values: new object[] { 2L, "dd_income_class", null, "inline", "Income pay period" });

            migrationBuilder.UpdateData(
                table: "Question",
                keyColumn: "Id",
                keyValue: 32L,
                columns: new[] { "ControlId", "CssStyle", "Description", "IsRequired", "QuestionName", "RoleName" },
                values: new object[] { 5L, "txt_style1", "Please estimate the total resource value held by all the members of the household in the form  of checking & savings, retirement accounts, property (home, vehicle, etc) and any others assets.", true, "Estimated Household Resources", null });

            migrationBuilder.UpdateData(
                table: "Question",
                keyColumn: "Id",
                keyValue: 33L,
                columns: new[] { "Description", "IsRequired", "QuestionName" },
                values: new object[] { "If none of them apply, you can directly move to the next question.", false, "Please select the options that apply to you and click on next." });

            migrationBuilder.UpdateData(
                table: "Question",
                keyColumn: "Id",
                keyValue: 34L,
                column: "QuestionName",
                value: "Do any of the following health conditions apply to you?");

            migrationBuilder.UpdateData(
                table: "Question",
                keyColumn: "Id",
                keyValue: 35L,
                columns: new[] { "ControlId", "CssStyle", "ParentId", "QuestionName" },
                values: new object[] { 10L, "rbn_style1", null, "Select if you have been injured" });

            migrationBuilder.UpdateData(
                table: "Question",
                keyColumn: "Id",
                keyValue: 38L,
                columns: new[] { "ControlId", "CssStyle", "DisplayFormat", "ParentId", "QuestionName", "RoleName" },
                values: new object[] { 8L, "tgl_style", "header", 34L, "Was a report filed?", "Patient" });

            migrationBuilder.UpdateData(
                table: "ScreenQuestionMapping",
                keyColumn: "Id",
                keyValue: 7L,
                column: "KeyName",
                value: "middleName");

            migrationBuilder.UpdateData(
                table: "ScreenQuestionMapping",
                keyColumn: "Id",
                keyValue: 8L,
                column: "KeyName",
                value: "lastName");

            migrationBuilder.UpdateData(
                table: "ScreenQuestionMapping",
                keyColumn: "Id",
                keyValue: 9L,
                column: "KeyName",
                value: "dateOfBirth");

            migrationBuilder.UpdateData(
                table: "ScreenQuestionMapping",
                keyColumn: "Id",
                keyValue: 10L,
                column: "KeyName",
                value: "gender");

            migrationBuilder.UpdateData(
                table: "ScreenQuestionMapping",
                keyColumn: "Id",
                keyValue: 11L,
                column: "KeyName",
                value: "maritalStatus");

            migrationBuilder.UpdateData(
                table: "ScreenQuestionMapping",
                keyColumn: "Id",
                keyValue: 12L,
                column: "KeyName",
                value: "email");

            migrationBuilder.UpdateData(
                table: "ScreenQuestionMapping",
                keyColumn: "Id",
                keyValue: 13L,
                columns: new[] { "KeyName", "ScreenId" },
                values: new object[] { "cellNumber", 4L });

            migrationBuilder.UpdateData(
                table: "ScreenQuestionMapping",
                keyColumn: "Id",
                keyValue: 14L,
                column: "KeyName",
                value: "insurance");

            migrationBuilder.UpdateData(
                table: "ScreenQuestionMapping",
                keyColumn: "Id",
                keyValue: 15L,
                column: "KeyName",
                value: "policyDetails");

            migrationBuilder.UpdateData(
                table: "ScreenQuestionMapping",
                keyColumn: "Id",
                keyValue: 16L,
                column: "KeyName",
                value: "payerName");

            migrationBuilder.UpdateData(
                table: "ScreenQuestionMapping",
                keyColumn: "Id",
                keyValue: 17L,
                column: "KeyName",
                value: "groupName");

            migrationBuilder.UpdateData(
                table: "ScreenQuestionMapping",
                keyColumn: "Id",
                keyValue: 18L,
                column: "KeyName",
                value: "groupNumber");

            migrationBuilder.UpdateData(
                table: "ScreenQuestionMapping",
                keyColumn: "Id",
                keyValue: 19L,
                column: "KeyName",
                value: "policyNumber");

            migrationBuilder.UpdateData(
                table: "ScreenQuestionMapping",
                keyColumn: "Id",
                keyValue: 20L,
                column: "KeyName",
                value: "effectiveFrom");

            migrationBuilder.UpdateData(
                table: "ScreenQuestionMapping",
                keyColumn: "Id",
                keyValue: 21L,
                columns: new[] { "KeyName", "ScreenId" },
                values: new object[] { "termination", 5L });

            migrationBuilder.UpdateData(
                table: "ScreenQuestionMapping",
                keyColumn: "Id",
                keyValue: 22L,
                column: "KeyName",
                value: null);

            migrationBuilder.UpdateData(
                table: "ScreenQuestionMapping",
                keyColumn: "Id",
                keyValue: 23L,
                column: "KeyName",
                value: "noOfHousehold");

            migrationBuilder.UpdateData(
                table: "ScreenQuestionMapping",
                keyColumn: "Id",
                keyValue: 24L,
                column: "KeyName",
                value: "minorChildren");

            migrationBuilder.UpdateData(
                table: "ScreenQuestionMapping",
                keyColumn: "Id",
                keyValue: 25L,
                column: "KeyName",
                value: "isEmployed");

            migrationBuilder.UpdateData(
                table: "ScreenQuestionMapping",
                keyColumn: "Id",
                keyValue: 26L,
                column: "KeyName",
                value: "isHouseholdEmployed");

            migrationBuilder.UpdateData(
                table: "ScreenQuestionMapping",
                keyColumn: "Id",
                keyValue: 27L,
                columns: new[] { "KeyName", "ScreenId" },
                values: new object[] { "programServices", 6L });

            migrationBuilder.UpdateData(
                table: "ScreenQuestionMapping",
                keyColumn: "Id",
                keyValue: 28L,
                column: "KeyName",
                value: null);

            migrationBuilder.UpdateData(
                table: "ScreenQuestionMapping",
                keyColumn: "Id",
                keyValue: 29L,
                column: "KeyName",
                value: "householdIncome");

            migrationBuilder.UpdateData(
                table: "ScreenQuestionMapping",
                keyColumn: "Id",
                keyValue: 30L,
                column: "KeyName",
                value: "incomePayPeriod");

            migrationBuilder.UpdateData(
                table: "ScreenQuestionMapping",
                keyColumn: "Id",
                keyValue: 31L,
                columns: new[] { "KeyName", "ScreenId" },
                values: new object[] { "householdResources", 7L });

            migrationBuilder.UpdateData(
                table: "ScreenQuestionMapping",
                keyColumn: "Id",
                keyValue: 32L,
                column: "KeyName",
                value: "serviceProgram");

            migrationBuilder.UpdateData(
                table: "ScreenQuestionMapping",
                keyColumn: "Id",
                keyValue: 33L,
                column: "KeyName",
                value: "healthConditiion");

            migrationBuilder.UpdateData(
                table: "ScreenQuestionMapping",
                keyColumn: "Id",
                keyValue: 34L,
                column: "KeyName",
                value: "beenInjured");

            migrationBuilder.UpdateData(
                table: "ScreenQuestionMapping",
                keyColumn: "Id",
                keyValue: 35L,
                columns: new[] { "KeyName", "QuestionId", "ScreenId" },
                values: new object[] { "reportFiledCrime", 36L, 8L });

            migrationBuilder.UpdateData(
                table: "ScreenQuestionMapping",
                keyColumn: "Id",
                keyValue: 36L,
                columns: new[] { "KeyName", "QuestionId", "ScreenId" },
                values: new object[] { "aboutYourself", 6L, 4L });

            migrationBuilder.UpdateData(
                table: "ScreenQuestionMapping",
                keyColumn: "Id",
                keyValue: 37L,
                column: "KeyName",
                value: "reportFiledMotor");

            migrationBuilder.UpdateData(
                table: "ScreenQuestionMapping",
                keyColumn: "Id",
                keyValue: 38L,
                column: "KeyName",
                value: "reportFiledJob");

            migrationBuilder.UpdateData(
                table: "ScreenQuestionMapping",
                keyColumn: "Id",
                keyValue: 39L,
                column: "KeyName",
                value: "serviceProgram");

            migrationBuilder.UpdateData(
                table: "ScreenQuestionMapping",
                keyColumn: "Id",
                keyValue: 40L,
                column: "KeyName",
                value: "healthConditiion");

            migrationBuilder.UpdateData(
                table: "ScreenQuestionMapping",
                keyColumn: "Id",
                keyValue: 41L,
                column: "KeyName",
                value: "beenInjured");

            migrationBuilder.UpdateData(
                table: "ScreenQuestionMapping",
                keyColumn: "Id",
                keyValue: 42L,
                columns: new[] { "KeyName", "QuestionId", "ScreenId" },
                values: new object[] { "reportFiledCrime", 42L, 8L });
        }
    }
}
