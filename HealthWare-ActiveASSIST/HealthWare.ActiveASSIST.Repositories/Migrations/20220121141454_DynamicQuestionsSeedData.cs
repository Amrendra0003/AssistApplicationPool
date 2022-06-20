using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace HealthWare.ActiveASSIST.Repositories.Migrations
{
    public partial class DynamicQuestionsSeedData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "FieldValidatorType",
                keyColumn: "Id",
                keyValue: 5L,
                column: "Type",
                value: "^[a-zA-Z0-9]+$");

            migrationBuilder.InsertData(
                table: "FieldValidatorType",
                columns: new[] { "Id", "CreatedBy", "CreatedDate", "Name", "Type", "UpdatedBy", "UpdatedDate" },
                values: new object[] { 10L, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "^(0?[1-9]|1[0-2])\\/(0?[1-9]|1\\d|2\\d|3[01])\\/(19|20)\\d{2}$", "^[a-zA-Z0-9]+$", null, null });

            migrationBuilder.UpdateData(
                table: "QuickAssessmentQuestions",
                keyColumn: "Id",
                keyValue: 1L,
                column: "Required",
                value: false);

            migrationBuilder.UpdateData(
                table: "QuickAssessmentQuestions",
                keyColumn: "Id",
                keyValue: 2L,
                column: "Class",
                value: "col-12");

            migrationBuilder.UpdateData(
                table: "QuickAssessmentQuestions",
                keyColumn: "Id",
                keyValue: 3L,
                column: "Class",
                value: "col-12");

            migrationBuilder.UpdateData(
                table: "QuickAssessmentQuestions",
                keyColumn: "Id",
                keyValue: 4L,
                column: "Class",
                value: "col-12");

            migrationBuilder.UpdateData(
                table: "QuickAssessmentQuestions",
                keyColumn: "Id",
                keyValue: 5L,
                columns: new[] { "Class", "Required" },
                values: new object[] { "col-12", false });

            migrationBuilder.UpdateData(
                table: "QuickAssessmentQuestions",
                keyColumn: "Id",
                keyValue: 6L,
                column: "Class",
                value: "col-12");

            migrationBuilder.UpdateData(
                table: "QuickAssessmentQuestions",
                keyColumn: "Id",
                keyValue: 7L,
                column: "Class",
                value: "col-12");

            migrationBuilder.UpdateData(
                table: "QuickAssessmentQuestions",
                keyColumn: "Id",
                keyValue: 8L,
                column: "Class",
                value: "col-12");

            migrationBuilder.UpdateData(
                table: "QuickAssessmentQuestions",
                keyColumn: "Id",
                keyValue: 9L,
                column: "Class",
                value: "col-12");

            migrationBuilder.UpdateData(
                table: "QuickAssessmentQuestions",
                keyColumn: "Id",
                keyValue: 10L,
                columns: new[] { "Class", "Required" },
                values: new object[] { "col-12", false });

            migrationBuilder.UpdateData(
                table: "QuickAssessmentQuestions",
                keyColumn: "Id",
                keyValue: 11L,
                column: "Class",
                value: "col-12");

            migrationBuilder.UpdateData(
                table: "QuickAssessmentQuestions",
                keyColumn: "Id",
                keyValue: 12L,
                column: "Class",
                value: "col-12");

            migrationBuilder.UpdateData(
                table: "QuickAssessmentQuestions",
                keyColumn: "Id",
                keyValue: 14L,
                columns: new[] { "Class", "ParentQuestionId" },
                values: new object[] { "col-12", 13L });

            migrationBuilder.UpdateData(
                table: "QuickAssessmentQuestions",
                keyColumn: "Id",
                keyValue: 15L,
                column: "Class",
                value: "col-12");

            migrationBuilder.UpdateData(
                table: "QuickAssessmentQuestions",
                keyColumn: "Id",
                keyValue: 16L,
                column: "Class",
                value: "col-12");

            migrationBuilder.UpdateData(
                table: "QuickAssessmentQuestions",
                keyColumn: "Id",
                keyValue: 17L,
                column: "Class",
                value: "col-12");

            migrationBuilder.UpdateData(
                table: "QuickAssessmentQuestions",
                keyColumn: "Id",
                keyValue: 18L,
                column: "Class",
                value: "col-12");

            migrationBuilder.UpdateData(
                table: "QuickAssessmentQuestions",
                keyColumn: "Id",
                keyValue: 19L,
                column: "Class",
                value: "col-12");

            migrationBuilder.UpdateData(
                table: "QuickAssessmentQuestions",
                keyColumn: "Id",
                keyValue: 24L,
                column: "FieldTypeId",
                value: 8L);

            migrationBuilder.UpdateData(
                table: "QuickAssessmentQuestions",
                keyColumn: "Id",
                keyValue: 25L,
                columns: new[] { "Class", "InlineLabel", "IsInlineLabel" },
                values: new object[] { "col-3", "$", true });

            migrationBuilder.UpdateData(
                table: "QuickAssessmentQuestions",
                keyColumn: "Id",
                keyValue: 26L,
                columns: new[] { "Class", "OthersLabel", "PatientLabel" },
                values: new object[] { "col-3", "Select Grosspay", "Select Grosspay" });

            migrationBuilder.UpdateData(
                table: "QuickAssessmentQuestions",
                keyColumn: "Id",
                keyValue: 27L,
                columns: new[] { "Class", "OthersLabel", "PatientLabel", "ScreenHeaderOthersLabel", "ScreenHeaderPatientLabel" },
                values: new object[] { "col-3", "Estimated Household Resources", "Estimated Household Resources", null, null });

            migrationBuilder.UpdateData(
                table: "QuickAssessmentQuestions",
                keyColumn: "Id",
                keyValue: 28L,
                column: "FieldTypeId",
                value: 8L);

            migrationBuilder.UpdateData(
                table: "QuickAssessmentQuestions",
                keyColumn: "Id",
                keyValue: 29L,
                column: "FieldTypeId",
                value: 8L);

            migrationBuilder.UpdateData(
                table: "QuickAssessmentQuestions",
                keyColumn: "Id",
                keyValue: 30L,
                column: "FieldTypeId",
                value: 8L);

            migrationBuilder.UpdateData(
                table: "QuickAssessmentQuestions",
                keyColumn: "Id",
                keyValue: 31L,
                columns: new[] { "OthersLabel", "PatientLabel", "ScreenHeaderOthersLabel", "ScreenHeaderPatientLabel", "UniqueKey" },
                values: new object[] { "Was a Report Filed?", "Was a Report Filed?", null, null, "crimeReportFiled" });

            migrationBuilder.UpdateData(
                table: "QuickAssessmentQuestions",
                keyColumn: "Id",
                keyValue: 32L,
                column: "FieldName",
                value: "SSN");

            migrationBuilder.InsertData(
                table: "QuickAssessmentQuestions",
                columns: new[] { "Id", "AlertInfo", "Class", "CreatedBy", "CreatedDate", "CustomValidation", "DynamicScreensId", "ErrorMessageInfo", "FieldName", "FieldTypeId", "InlineLabel", "IsInlineLabel", "MaximumDate", "MessageInfo", "OrderId", "OthersLabel", "ParentQuestionId", "PatientLabel", "Placeholder", "Required", "ScreenHeaderOthersLabel", "ScreenHeaderPatientLabel", "ScreenId", "TermAndConditionPopupMessage", "TermAndConditionsMessageLabel", "TextBoxSubLabel", "UniqueKey", "UpdatedBy", "UpdatedDate", "Value" },
                values: new object[,]
                {
                    { 34L, null, "col-5", null, new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 10L, null, "Is Report Filed", 7L, null, false, null, null, "1", "Was a Report Filed?", 30L, "Was a Report Filed?", null, false, null, null, "10", null, null, null, "motorReportFiled", null, null, null },
                    { 35L, null, "col-5", null, new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 10L, null, "Is Report Filed", 7L, null, false, null, null, "1", "Was a Report Filed?", 30L, "Was a Report Filed?", null, false, null, null, "10", null, null, null, "jobReportFiled", null, null, null }
                });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: -1L,
                column: "Password",
                value: "$2a$12$yq86EB71mzXdTwsgf.c1gefQA5pA.7k6E/IYYIR8Fvjwl.YANdoZ.");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1L,
                column: "Password",
                value: "$2a$12$Jfpf6IisHNvGQSqZGwWH7e4YIkuk410DThxOPBoz2a22DxZrgpgTy");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2L,
                column: "Password",
                value: "$2a$12$J93JkSqkjt6V.6Jo21Bmm.we04xzbotc3/fOAx9XlXNsryoh6aiyq");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3L,
                column: "Password",
                value: "$2a$12$NETouuF8stTHwpHmw7HgYuH3.2.PvhYZ.LullCUzvgqcO.dApmNG.");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 4L,
                column: "Password",
                value: "$2a$12$doMcjuzV6f9X2wSa1mpfwuIauLbEqe6p.iprdWdL2c3uy9F9Afpt6");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 5L,
                column: "Password",
                value: "$2a$12$nJ.hBQltUt2FS87TURSHj.I1f2Yc3.2tqoUmn7TAvIZlpn7Sfc.K2");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 6L,
                column: "Password",
                value: "$2a$12$eqn7SjzbCDVaswMv7i0xSe5LxiMdiZ9N3A0xAzePeO8Zz0lFzjK3K");

            migrationBuilder.UpdateData(
                table: "Validators",
                keyColumn: "Id",
                keyValue: 1L,
                column: "Required",
                value: true);

            migrationBuilder.UpdateData(
                table: "Validators",
                keyColumn: "Id",
                keyValue: 5L,
                column: "Required",
                value: true);

            migrationBuilder.UpdateData(
                table: "Validators",
                keyColumn: "Id",
                keyValue: 9L,
                column: "Required",
                value: true);

            migrationBuilder.UpdateData(
                table: "Validators",
                keyColumn: "Id",
                keyValue: 10L,
                column: "Required",
                value: true);

            migrationBuilder.UpdateData(
                table: "Validators",
                keyColumn: "Id",
                keyValue: 16L,
                column: "PatternId",
                value: 5L);

            migrationBuilder.UpdateData(
                table: "Validators",
                keyColumn: "Id",
                keyValue: 17L,
                column: "PatternId",
                value: 5L);

            migrationBuilder.UpdateData(
                table: "Validators",
                keyColumn: "Id",
                keyValue: 31L,
                column: "Required",
                value: false);

            migrationBuilder.InsertData(
                table: "Options",
                columns: new[] { "Id", "CreatedBy", "CreatedDate", "Name", "Order", "QuickAssessmentQuestionsId", "UpdatedBy", "UpdatedDate", "Value" },
                values: new object[,]
                {
                    { 47L, null, new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, 34L, null, null, "No" },
                    { 48L, null, new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, 34L, null, null, "Yes" },
                    { 49L, null, new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, 35L, null, null, "No" },
                    { 50L, null, new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, 35L, null, null, "Yes" }
                });

            migrationBuilder.UpdateData(
                table: "Validators",
                keyColumn: "Id",
                keyValue: 18L,
                columns: new[] { "MaxLength", "PatternId" },
                values: new object[] { 10, 10L });

            migrationBuilder.UpdateData(
                table: "Validators",
                keyColumn: "Id",
                keyValue: 19L,
                columns: new[] { "MaxLength", "PatternId", "Required" },
                values: new object[] { 10, 10L, false });

            migrationBuilder.InsertData(
                table: "Validators",
                columns: new[] { "Id", "CreatedBy", "CreatedDate", "Max", "MaxLength", "Min", "MinLength", "PatternId", "QuickAssessmentQuestionsId", "Required", "UpdatedBy", "UpdatedDate" },
                values: new object[,]
                {
                    { 33L, null, new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1000, null, 0, null, 34L, false, null, null },
                    { 34L, null, new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1000, null, 0, null, 35L, false, null, null }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "FieldValidatorType",
                keyColumn: "Id",
                keyValue: 10L);

            migrationBuilder.DeleteData(
                table: "Options",
                keyColumn: "Id",
                keyValue: 47L);

            migrationBuilder.DeleteData(
                table: "Options",
                keyColumn: "Id",
                keyValue: 48L);

            migrationBuilder.DeleteData(
                table: "Options",
                keyColumn: "Id",
                keyValue: 49L);

            migrationBuilder.DeleteData(
                table: "Options",
                keyColumn: "Id",
                keyValue: 50L);

            migrationBuilder.DeleteData(
                table: "Validators",
                keyColumn: "Id",
                keyValue: 33L);

            migrationBuilder.DeleteData(
                table: "Validators",
                keyColumn: "Id",
                keyValue: 34L);

            migrationBuilder.DeleteData(
                table: "QuickAssessmentQuestions",
                keyColumn: "Id",
                keyValue: 34L);

            migrationBuilder.DeleteData(
                table: "QuickAssessmentQuestions",
                keyColumn: "Id",
                keyValue: 35L);

            migrationBuilder.UpdateData(
                table: "FieldValidatorType",
                keyColumn: "Id",
                keyValue: 5L,
                column: "Type",
                value: "(?:\\s *[a - zA - Z0 - 9]\\s *)*");

            migrationBuilder.UpdateData(
                table: "QuickAssessmentQuestions",
                keyColumn: "Id",
                keyValue: 1L,
                column: "Required",
                value: true);

            migrationBuilder.UpdateData(
                table: "QuickAssessmentQuestions",
                keyColumn: "Id",
                keyValue: 2L,
                column: "Class",
                value: "col-5");

            migrationBuilder.UpdateData(
                table: "QuickAssessmentQuestions",
                keyColumn: "Id",
                keyValue: 3L,
                column: "Class",
                value: "col-5");

            migrationBuilder.UpdateData(
                table: "QuickAssessmentQuestions",
                keyColumn: "Id",
                keyValue: 4L,
                column: "Class",
                value: "col-5");

            migrationBuilder.UpdateData(
                table: "QuickAssessmentQuestions",
                keyColumn: "Id",
                keyValue: 5L,
                columns: new[] { "Class", "Required" },
                values: new object[] { "col-5", true });

            migrationBuilder.UpdateData(
                table: "QuickAssessmentQuestions",
                keyColumn: "Id",
                keyValue: 6L,
                column: "Class",
                value: "col-5");

            migrationBuilder.UpdateData(
                table: "QuickAssessmentQuestions",
                keyColumn: "Id",
                keyValue: 7L,
                column: "Class",
                value: "col-5");

            migrationBuilder.UpdateData(
                table: "QuickAssessmentQuestions",
                keyColumn: "Id",
                keyValue: 8L,
                column: "Class",
                value: "col-5");

            migrationBuilder.UpdateData(
                table: "QuickAssessmentQuestions",
                keyColumn: "Id",
                keyValue: 9L,
                column: "Class",
                value: "col-5");

            migrationBuilder.UpdateData(
                table: "QuickAssessmentQuestions",
                keyColumn: "Id",
                keyValue: 10L,
                columns: new[] { "Class", "Required" },
                values: new object[] { "col-5", true });

            migrationBuilder.UpdateData(
                table: "QuickAssessmentQuestions",
                keyColumn: "Id",
                keyValue: 11L,
                column: "Class",
                value: "col-5");

            migrationBuilder.UpdateData(
                table: "QuickAssessmentQuestions",
                keyColumn: "Id",
                keyValue: 12L,
                column: "Class",
                value: "col-5");

            migrationBuilder.UpdateData(
                table: "QuickAssessmentQuestions",
                keyColumn: "Id",
                keyValue: 14L,
                columns: new[] { "Class", "ParentQuestionId" },
                values: new object[] { "col-5", 12L });

            migrationBuilder.UpdateData(
                table: "QuickAssessmentQuestions",
                keyColumn: "Id",
                keyValue: 15L,
                column: "Class",
                value: "col-5");

            migrationBuilder.UpdateData(
                table: "QuickAssessmentQuestions",
                keyColumn: "Id",
                keyValue: 16L,
                column: "Class",
                value: "col-5");

            migrationBuilder.UpdateData(
                table: "QuickAssessmentQuestions",
                keyColumn: "Id",
                keyValue: 17L,
                column: "Class",
                value: "col-5");

            migrationBuilder.UpdateData(
                table: "QuickAssessmentQuestions",
                keyColumn: "Id",
                keyValue: 18L,
                column: "Class",
                value: "col-5");

            migrationBuilder.UpdateData(
                table: "QuickAssessmentQuestions",
                keyColumn: "Id",
                keyValue: 19L,
                column: "Class",
                value: "col-5");

            migrationBuilder.UpdateData(
                table: "QuickAssessmentQuestions",
                keyColumn: "Id",
                keyValue: 24L,
                column: "FieldTypeId",
                value: 5L);

            migrationBuilder.UpdateData(
                table: "QuickAssessmentQuestions",
                keyColumn: "Id",
                keyValue: 25L,
                columns: new[] { "Class", "InlineLabel", "IsInlineLabel" },
                values: new object[] { "col-5", null, false });

            migrationBuilder.UpdateData(
                table: "QuickAssessmentQuestions",
                keyColumn: "Id",
                keyValue: 26L,
                columns: new[] { "Class", "OthersLabel", "PatientLabel" },
                values: new object[] { "col-5", null, null });

            migrationBuilder.UpdateData(
                table: "QuickAssessmentQuestions",
                keyColumn: "Id",
                keyValue: 27L,
                columns: new[] { "Class", "OthersLabel", "PatientLabel", "ScreenHeaderOthersLabel", "ScreenHeaderPatientLabel" },
                values: new object[] { "col-5", null, null, "Estimated Household Resources", "Estimated Household Resources" });

            migrationBuilder.UpdateData(
                table: "QuickAssessmentQuestions",
                keyColumn: "Id",
                keyValue: 28L,
                column: "FieldTypeId",
                value: 5L);

            migrationBuilder.UpdateData(
                table: "QuickAssessmentQuestions",
                keyColumn: "Id",
                keyValue: 29L,
                column: "FieldTypeId",
                value: 5L);

            migrationBuilder.UpdateData(
                table: "QuickAssessmentQuestions",
                keyColumn: "Id",
                keyValue: 30L,
                column: "FieldTypeId",
                value: 5L);

            migrationBuilder.UpdateData(
                table: "QuickAssessmentQuestions",
                keyColumn: "Id",
                keyValue: 31L,
                columns: new[] { "OthersLabel", "PatientLabel", "ScreenHeaderOthersLabel", "ScreenHeaderPatientLabel", "UniqueKey" },
                values: new object[] { null, null, "Report Filed?", "Report Filed?", "reportFiled" });

            migrationBuilder.UpdateData(
                table: "QuickAssessmentQuestions",
                keyColumn: "Id",
                keyValue: 32L,
                column: "FieldName",
                value: null);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: -1L,
                column: "Password",
                value: "$2a$12$3bFvigjzdtdyrWgp5m5yjeV0PQC1cBJxSnQ2/As8oOmdzbI6cdHxG");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1L,
                column: "Password",
                value: "$2a$12$58tZ6A.QeOvl7jXMZV6FfODJAA/VgVLfFHCez0ub5vuLQYuON4pbG");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2L,
                column: "Password",
                value: "$2a$12$ETgZ7Q0VSR93SFSEyJe53.uRS797t5rEhQdXVlge1qMPiA4UV2n8i");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3L,
                column: "Password",
                value: "$2a$12$Y9bLKdutdx8j3LhgxUOMNevErd4jY18eejb0F8XsK3FKwqCnxSaY2");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 4L,
                column: "Password",
                value: "$2a$12$kUZk3NJc6qKrGgcdb5v64./LKjnQxP1hZ6EJV3vTi5U8BfxHxmnUC");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 5L,
                column: "Password",
                value: "$2a$12$ggxUIuQAZB.1iyJpZktyz.3zr1p4pgejN2oVaWSRfgL0s4/NaQ/cS");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 6L,
                column: "Password",
                value: "$2a$12$pDTFHg3HG259RNwenRdF9.RINJNUs4Fx4pMYq9es9VaexItqdh7gq");

            migrationBuilder.UpdateData(
                table: "Validators",
                keyColumn: "Id",
                keyValue: 1L,
                column: "Required",
                value: false);

            migrationBuilder.UpdateData(
                table: "Validators",
                keyColumn: "Id",
                keyValue: 5L,
                column: "Required",
                value: false);

            migrationBuilder.UpdateData(
                table: "Validators",
                keyColumn: "Id",
                keyValue: 9L,
                column: "Required",
                value: false);

            migrationBuilder.UpdateData(
                table: "Validators",
                keyColumn: "Id",
                keyValue: 10L,
                column: "Required",
                value: false);

            migrationBuilder.UpdateData(
                table: "Validators",
                keyColumn: "Id",
                keyValue: 16L,
                column: "PatternId",
                value: 1L);

            migrationBuilder.UpdateData(
                table: "Validators",
                keyColumn: "Id",
                keyValue: 17L,
                column: "PatternId",
                value: 1L);

            migrationBuilder.UpdateData(
                table: "Validators",
                keyColumn: "Id",
                keyValue: 18L,
                columns: new[] { "MaxLength", "PatternId" },
                values: new object[] { 15, null });

            migrationBuilder.UpdateData(
                table: "Validators",
                keyColumn: "Id",
                keyValue: 19L,
                columns: new[] { "MaxLength", "PatternId", "Required" },
                values: new object[] { 15, null, true });

            migrationBuilder.UpdateData(
                table: "Validators",
                keyColumn: "Id",
                keyValue: 31L,
                column: "Required",
                value: true);
        }
    }
}
