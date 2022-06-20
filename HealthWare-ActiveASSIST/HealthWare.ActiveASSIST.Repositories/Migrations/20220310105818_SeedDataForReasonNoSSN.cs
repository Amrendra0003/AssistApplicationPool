using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace HealthWare.ActiveASSIST.Repositories.Migrations
{
    public partial class SeedDataForReasonNoSSN : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "MainUser",
                keyColumn: "Id",
                keyValue: -1L,
                column: "Password",
                value: "$2a$12$iyaIHvJpObHRlGOu297.Lu3cIE.ARwDABZaTV.e9lT0voAINC4J0.");

            migrationBuilder.UpdateData(
                table: "MainUser",
                keyColumn: "Id",
                keyValue: 1L,
                column: "Password",
                value: "$2a$12$.UFTmlVyLImbToSicWX3GOUgwQ0Apucf9tWBkxK4PjIrPyTF3EWlS");

            migrationBuilder.UpdateData(
                table: "MainUser",
                keyColumn: "Id",
                keyValue: 2L,
                column: "Password",
                value: "$2a$12$XVDVdr4aJoq7kKy994ZWKOAlhjyDuCZ.sH7WPanWSXfLk.SEvoNWu");

            migrationBuilder.UpdateData(
                table: "MainUser",
                keyColumn: "Id",
                keyValue: 3L,
                column: "Password",
                value: "$2a$12$PwWjP/VRsjvkTAGAgUFcReBpHz6qHeW5imKgn.JdMhH9oBxjSkxh.");

            migrationBuilder.UpdateData(
                table: "MainUser",
                keyColumn: "Id",
                keyValue: 4L,
                column: "Password",
                value: "$2a$12$anGxhsC65c5nikHnmfCBS.gII.502vpQOW76lMpsSKwXT8MKMuwge");

            migrationBuilder.UpdateData(
                table: "MainUser",
                keyColumn: "Id",
                keyValue: 5L,
                column: "Password",
                value: "$2a$12$uihUNcEsNVeNFP.kdUyyMudJRu21hPsZjATD.PpZOwlGNOVkhEJry");

            migrationBuilder.UpdateData(
                table: "MainUser",
                keyColumn: "Id",
                keyValue: 6L,
                column: "Password",
                value: "$2a$12$y.eFLfYkh3vu8/N8rMiG2.fbdE3d1dDx8stg9vnB.idZSASd4EquG");

            migrationBuilder.UpdateData(
                table: "QuickAssessmentQuestions",
                keyColumn: "Id",
                keyValue: 34L,
                column: "OrderId",
                value: "3");

            migrationBuilder.InsertData(
                table: "QuickAssessmentQuestions",
                columns: new[] { "Id", "AlertInfo", "Class", "CreatedBy", "CreatedDate", "CustomValidation", "DynamicScreensId", "ErrorMessageInfo", "FieldName", "FieldTypeId", "InlineLabel", "IsInlineLabel", "MaximumDate", "MessageInfo", "OrderId", "OthersLabel", "ParentQuestionId", "PatientLabel", "Placeholder", "Required", "ScreenHeaderOthersLabel", "ScreenHeaderPatientLabel", "ScreenId", "TermAndConditionPopupMessage", "TermAndConditionsMessageLabel", "TextBoxSubLabel", "UniqueKey", "UpdatedBy", "UpdatedDate", "Value" },
                values: new object[] { 37L, null, "col-5", null, new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 11L, null, "Reason no SSN", 4L, null, false, null, null, "2", null, null, null, "Reason no SSN", false, null, null, "11", null, null, null, "reasonNoSSN", null, null, null });

            migrationBuilder.UpdateData(
                table: "Validators",
                keyColumn: "Id",
                keyValue: 32L,
                column: "Required",
                value: false);

            migrationBuilder.InsertData(
                table: "Options",
                columns: new[] { "Id", "CreatedBy", "CreatedDate", "Name", "Order", "QuickAssessmentQuestionsId", "UpdatedBy", "UpdatedDate", "Value" },
                values: new object[,]
                {
                    { 51L, null, new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "doesNotHaveOne", 1, 37L, null, null, "Does Not Have One" },
                    { 52L, null, new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "unconcious-CouldNotProvide", 2, 37L, null, null, "Unconcious - Could Not Provide" },
                    { 53L, null, new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "other", 3, 37L, null, null, "Other" }
                });

            migrationBuilder.InsertData(
                table: "Validators",
                columns: new[] { "Id", "CreatedBy", "CreatedDate", "Max", "MaxLength", "Min", "MinLength", "PatternId", "QuickAssessmentQuestionsId", "Required", "UpdatedBy", "UpdatedDate" },
                values: new object[] { 37L, null, new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1000, null, 0, null, 37L, false, null, null });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Options",
                keyColumn: "Id",
                keyValue: 51L);

            migrationBuilder.DeleteData(
                table: "Options",
                keyColumn: "Id",
                keyValue: 52L);

            migrationBuilder.DeleteData(
                table: "Options",
                keyColumn: "Id",
                keyValue: 53L);

            migrationBuilder.DeleteData(
                table: "Validators",
                keyColumn: "Id",
                keyValue: 37L);

            migrationBuilder.DeleteData(
                table: "QuickAssessmentQuestions",
                keyColumn: "Id",
                keyValue: 37L);

            migrationBuilder.UpdateData(
                table: "MainUser",
                keyColumn: "Id",
                keyValue: -1L,
                column: "Password",
                value: "$2a$12$2jpXKn8RrnjbxzDOFE8sduVsu.BOXD3HH3ylqaQvkpV0yQqzh38Xy");

            migrationBuilder.UpdateData(
                table: "MainUser",
                keyColumn: "Id",
                keyValue: 1L,
                column: "Password",
                value: "$2a$12$6nYs3Cm12fMZb5tZnzbCG.VIezUa0e6yeVrCpG3vlynY.7aQwbWR2");

            migrationBuilder.UpdateData(
                table: "MainUser",
                keyColumn: "Id",
                keyValue: 2L,
                column: "Password",
                value: "$2a$12$bV8GQOSET7e1fDwiMPsyuOVZzhO5kc1YvtqAQfy5euP28/XWHytK6");

            migrationBuilder.UpdateData(
                table: "MainUser",
                keyColumn: "Id",
                keyValue: 3L,
                column: "Password",
                value: "$2a$12$BNHJ/1Odi.B1EPey3KdL5udntMrWE25982uHLx5CkHI0r/vNlKtua");

            migrationBuilder.UpdateData(
                table: "MainUser",
                keyColumn: "Id",
                keyValue: 4L,
                column: "Password",
                value: "$2a$12$5YAS98gvwyfa8hhO08CpLuNILYdI84igzzE2sdlr9sh0EPZoqv57G");

            migrationBuilder.UpdateData(
                table: "MainUser",
                keyColumn: "Id",
                keyValue: 5L,
                column: "Password",
                value: "$2a$12$lUFWHbGIAnlbaTdT3f17ke.ckH77CiksAhTDdoLVmiY.A7p3SPRfO");

            migrationBuilder.UpdateData(
                table: "MainUser",
                keyColumn: "Id",
                keyValue: 6L,
                column: "Password",
                value: "$2a$12$Os0Ul/T7dDu9JCFoAX7HV.sbNSkVp/068rTvDGVriJXcL28acvipu");

            migrationBuilder.UpdateData(
                table: "QuickAssessmentQuestions",
                keyColumn: "Id",
                keyValue: 34L,
                column: "OrderId",
                value: "2");

            migrationBuilder.UpdateData(
                table: "Validators",
                keyColumn: "Id",
                keyValue: 32L,
                column: "Required",
                value: true);
        }
    }
}
