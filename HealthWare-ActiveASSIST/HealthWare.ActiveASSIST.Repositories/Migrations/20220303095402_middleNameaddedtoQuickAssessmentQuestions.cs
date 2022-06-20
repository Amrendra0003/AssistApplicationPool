using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace HealthWare.ActiveASSIST.Repositories.Migrations
{
    public partial class middleNameaddedtoQuickAssessmentQuestions : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "MainUser",
                keyColumn: "Id",
                keyValue: -1L,
                column: "Password",
                value: "$2a$12$QaWacYWp32oNzZcf7l9t0ecpxVz7.bONuO5hBC/npnbEwZYzyp.X.");

            migrationBuilder.UpdateData(
                table: "MainUser",
                keyColumn: "Id",
                keyValue: 1L,
                column: "Password",
                value: "$2a$12$gMpX8FjoQldADTIsHGdrZuU9s/Z0n4YWGWyxoNvucM25mfH.p18I6");

            migrationBuilder.UpdateData(
                table: "MainUser",
                keyColumn: "Id",
                keyValue: 2L,
                column: "Password",
                value: "$2a$12$QDnwlv9REndbTy6a5wuQvuIkhdLg0tDfMh4DSLNxTotKI55GFEWRS");

            migrationBuilder.UpdateData(
                table: "MainUser",
                keyColumn: "Id",
                keyValue: 3L,
                column: "Password",
                value: "$2a$12$FOCZFXjuGsM2Sr7QbJK0ouZc2HYO3DVx/IaFnm2pSR1D2roDQlnwi");

            migrationBuilder.UpdateData(
                table: "MainUser",
                keyColumn: "Id",
                keyValue: 4L,
                column: "Password",
                value: "$2a$12$CzE2bVhkKKFbS90P58Ue7.jRKH3W1ObDlF3AIwxH68a21qTzOTkRe");

            migrationBuilder.UpdateData(
                table: "MainUser",
                keyColumn: "Id",
                keyValue: 5L,
                column: "Password",
                value: "$2a$12$XSApi32O9fEsTvQzoqo1UOKMTiELOwUQY7zmn597B7NEJvx//FP7a");

            migrationBuilder.UpdateData(
                table: "MainUser",
                keyColumn: "Id",
                keyValue: 6L,
                column: "Password",
                value: "$2a$12$zSZTtu3ZbG2EPlWDFtk6se0gBZxwS.Kw/iIV4hnARhlbahvud.UhW");

            migrationBuilder.UpdateData(
                table: "QuickAssessmentQuestions",
                keyColumn: "Id",
                keyValue: 8L,
                column: "OrderId",
                value: "5");

            migrationBuilder.UpdateData(
                table: "QuickAssessmentQuestions",
                keyColumn: "Id",
                keyValue: 9L,
                column: "OrderId",
                value: "6");

            migrationBuilder.UpdateData(
                table: "QuickAssessmentQuestions",
                keyColumn: "Id",
                keyValue: 10L,
                column: "OrderId",
                value: "7");

            migrationBuilder.UpdateData(
                table: "QuickAssessmentQuestions",
                keyColumn: "Id",
                keyValue: 11L,
                column: "OrderId",
                value: "8");

            migrationBuilder.UpdateData(
                table: "QuickAssessmentQuestions",
                keyColumn: "Id",
                keyValue: 12L,
                column: "OrderId",
                value: "9");

            migrationBuilder.InsertData(
                table: "QuickAssessmentQuestions",
                columns: new[] { "Id", "AlertInfo", "Class", "CreatedBy", "CreatedDate", "CustomValidation", "DynamicScreensId", "ErrorMessageInfo", "FieldName", "FieldTypeId", "InlineLabel", "IsInlineLabel", "MaximumDate", "MessageInfo", "OrderId", "OthersLabel", "ParentQuestionId", "PatientLabel", "Placeholder", "Required", "ScreenHeaderOthersLabel", "ScreenHeaderPatientLabel", "ScreenId", "TermAndConditionPopupMessage", "TermAndConditionsMessageLabel", "TextBoxSubLabel", "UniqueKey", "UpdatedBy", "UpdatedDate", "Value" },
                values: new object[] { 36L, null, "col-12", null, new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 4L, null, "Middle Name", 6L, null, false, null, null, "2", null, null, null, "Middle Name", false, null, null, "4", null, null, null, "middleName", null, null, null });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "QuickAssessmentQuestions",
                keyColumn: "Id",
                keyValue: 36L);

            migrationBuilder.UpdateData(
                table: "MainUser",
                keyColumn: "Id",
                keyValue: -1L,
                column: "Password",
                value: "$2a$12$.jLsqqedofVj69f43Iqt8.Ng6.8BazEBKThJ7yX3Azwj4b.jd523C");

            migrationBuilder.UpdateData(
                table: "MainUser",
                keyColumn: "Id",
                keyValue: 1L,
                column: "Password",
                value: "$2a$12$IRdwUl3mxAMTQNRTaoUwcOZ91IyUORY7pgiFainLeHBAJ9075gsNq");

            migrationBuilder.UpdateData(
                table: "MainUser",
                keyColumn: "Id",
                keyValue: 2L,
                column: "Password",
                value: "$2a$12$AKb7o.SsAW/Qj.txhD.Nuu6qOnPmYMUICV..r1I3sStmJgMXr3E4i");

            migrationBuilder.UpdateData(
                table: "MainUser",
                keyColumn: "Id",
                keyValue: 3L,
                column: "Password",
                value: "$2a$12$gTWIjnK29qYlyMdcMi5psesge3Na6EBzpEPqhoQzW6zZWSZU9aFNS");

            migrationBuilder.UpdateData(
                table: "MainUser",
                keyColumn: "Id",
                keyValue: 4L,
                column: "Password",
                value: "$2a$12$j0VqIQlRal7yXIEEmwGVX.PZI6XnAzEssnAmVSDhxJXqoPtTXe0x2");

            migrationBuilder.UpdateData(
                table: "MainUser",
                keyColumn: "Id",
                keyValue: 5L,
                column: "Password",
                value: "$2a$12$OgoMQU4xQbBbrwYTyP91tuiNxjNvL9pR4U0nGZERUlKRbrGQ2sWjm");

            migrationBuilder.UpdateData(
                table: "MainUser",
                keyColumn: "Id",
                keyValue: 6L,
                column: "Password",
                value: "$2a$12$CxW85ntqGQDgTCnMeYcgNOWlDVocXULTSEiZeYJLHUH0h30aAIVYS");

            migrationBuilder.UpdateData(
                table: "QuickAssessmentQuestions",
                keyColumn: "Id",
                keyValue: 8L,
                column: "OrderId",
                value: "4");

            migrationBuilder.UpdateData(
                table: "QuickAssessmentQuestions",
                keyColumn: "Id",
                keyValue: 9L,
                column: "OrderId",
                value: "5");

            migrationBuilder.UpdateData(
                table: "QuickAssessmentQuestions",
                keyColumn: "Id",
                keyValue: 10L,
                column: "OrderId",
                value: "6");

            migrationBuilder.UpdateData(
                table: "QuickAssessmentQuestions",
                keyColumn: "Id",
                keyValue: 11L,
                column: "OrderId",
                value: "6");

            migrationBuilder.UpdateData(
                table: "QuickAssessmentQuestions",
                keyColumn: "Id",
                keyValue: 12L,
                column: "OrderId",
                value: "6");
        }
    }
}
