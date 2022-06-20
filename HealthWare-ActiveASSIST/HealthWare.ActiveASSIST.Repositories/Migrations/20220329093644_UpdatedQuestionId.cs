using Microsoft.EntityFrameworkCore.Migrations;

namespace HealthWare.ActiveASSIST.Repositories.Migrations
{
    public partial class UpdatedQuestionId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "MainUser",
                keyColumn: "Id",
                keyValue: -1L,
                column: "Password",
                value: "$2a$12$ClFR1Sd3V4j.B5ty1TU7NuaHATkLPNwCWGIRtVdwEa3K7UOPTu792");

            migrationBuilder.UpdateData(
                table: "MainUser",
                keyColumn: "Id",
                keyValue: 1L,
                column: "Password",
                value: "$2a$12$r6Qa6vAc4duNzBRiLKtpH.zVnbSf.kjTAyqThA2C54ATbU9.t9W82");

            migrationBuilder.UpdateData(
                table: "MainUser",
                keyColumn: "Id",
                keyValue: 2L,
                column: "Password",
                value: "$2a$12$aD2vEMAe4ZGow9yS0rEOKuY63meckIRF/9La11Gax8tOU9JSV36Tm");

            migrationBuilder.UpdateData(
                table: "MainUser",
                keyColumn: "Id",
                keyValue: 3L,
                column: "Password",
                value: "$2a$12$KkY1lYpzD93SG5h7FNYd..wXZh9r/lu48Ng9QhdC83GmlA9XrlPW2");

            migrationBuilder.UpdateData(
                table: "MainUser",
                keyColumn: "Id",
                keyValue: 4L,
                column: "Password",
                value: "$2a$12$D8Vw/sBVOEQLetiRpErf7OspAV2ZbdGBSlTLnsNLzAB1p/5BKXUye");

            migrationBuilder.UpdateData(
                table: "MainUser",
                keyColumn: "Id",
                keyValue: 5L,
                column: "Password",
                value: "$2a$12$IxeFaohCY3gGBLUg7zCnAOnjfPF6b2bcFOPX3.wIG8NuHGkAcgAVW");

            migrationBuilder.UpdateData(
                table: "MainUser",
                keyColumn: "Id",
                keyValue: 6L,
                column: "Password",
                value: "$2a$12$1X5UL8OEIHgsXTL7B1OnMuBgO60ofefiRtWXgB88987LeiNxpJKtS");

            migrationBuilder.UpdateData(
                table: "MainUser",
                keyColumn: "Id",
                keyValue: 7L,
                column: "Password",
                value: "$2a$12$MgsZwWx1F0LiYm9aTv21nOYzm7KgcJZ5nYkM.fKExaDqSnHPMEDGK");

            migrationBuilder.UpdateData(
                table: "MainUser",
                keyColumn: "Id",
                keyValue: 8L,
                column: "Password",
                value: "$2a$12$QrI5dfHYf3srCoBOJi3KZuCescW2SOrKlr.QD2FyqVbdEHXpydmp.");

            migrationBuilder.UpdateData(
                table: "Options",
                keyColumn: "Id",
                keyValue: 45L,
                column: "QuickAssessmentQuestionsId",
                value: 35L);

            migrationBuilder.UpdateData(
                table: "Options",
                keyColumn: "Id",
                keyValue: 47L,
                column: "QuickAssessmentQuestionsId",
                value: 36L);

            migrationBuilder.UpdateData(
                table: "Options",
                keyColumn: "Id",
                keyValue: 48L,
                column: "QuickAssessmentQuestionsId",
                value: 36L);

            migrationBuilder.UpdateData(
                table: "Options",
                keyColumn: "Id",
                keyValue: 49L,
                column: "QuickAssessmentQuestionsId",
                value: 37L);

            migrationBuilder.UpdateData(
                table: "Options",
                keyColumn: "Id",
                keyValue: 50L,
                column: "QuickAssessmentQuestionsId",
                value: 37L);

            migrationBuilder.UpdateData(
                table: "Options",
                keyColumn: "Id",
                keyValue: 51L,
                column: "QuickAssessmentQuestionsId",
                value: 34L);

            migrationBuilder.UpdateData(
                table: "Options",
                keyColumn: "Id",
                keyValue: 52L,
                column: "QuickAssessmentQuestionsId",
                value: 34L);

            migrationBuilder.UpdateData(
                table: "Options",
                keyColumn: "Id",
                keyValue: 53L,
                column: "QuickAssessmentQuestionsId",
                value: 34L);

            migrationBuilder.UpdateData(
                table: "QuickAssessmentQuestions",
                keyColumn: "Id",
                keyValue: 33L,
                column: "MessageInfo",
                value: null);

            migrationBuilder.UpdateData(
                table: "QuickAssessmentQuestions",
                keyColumn: "Id",
                keyValue: 34L,
                columns: new[] { "Class", "FieldName", "FieldTypeId", "MessageInfo", "OrderId", "Placeholder", "Required", "TermAndConditionPopupMessage", "TermAndConditionsMessageLabel", "UniqueKey" },
                values: new object[] { "col-5", "Reason no SSN", 4L, "Your SSN is secure with us. We ask for this information as most government agencies require this number when submitting an application for benefits.", "2", "Reason No SSN", false, null, null, "reasonNoSSN" });

            migrationBuilder.UpdateData(
                table: "QuickAssessmentQuestions",
                keyColumn: "Id",
                keyValue: 35L,
                columns: new[] { "Class", "DynamicScreensId", "FieldName", "FieldTypeId", "OrderId", "OthersLabel", "ParentQuestionId", "PatientLabel", "Required", "ScreenId", "TermAndConditionPopupMessage", "TermAndConditionsMessageLabel", "UniqueKey" },
                values: new object[] { "col-12", 11L, null, 8L, "3", null, null, null, true, "11", "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat.Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat.Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat.Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat.Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat.Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat.", "Terms And Conditions", "agreementCheckBox" });

            migrationBuilder.UpdateData(
                table: "QuickAssessmentQuestions",
                keyColumn: "Id",
                keyValue: 36L,
                column: "UniqueKey",
                value: "motorReportFiled");

            migrationBuilder.UpdateData(
                table: "QuickAssessmentQuestions",
                keyColumn: "Id",
                keyValue: 37L,
                columns: new[] { "DynamicScreensId", "FieldName", "FieldTypeId", "OrderId", "OthersLabel", "ParentQuestionId", "PatientLabel", "Placeholder", "ScreenId", "UniqueKey" },
                values: new object[] { 10L, "Is Report Filed", 7L, "1", "Was a Report Filed?", 31L, "Was a Report Filed?", null, "10", "jobReportFiled" });

            migrationBuilder.UpdateData(
                table: "Validators",
                keyColumn: "Id",
                keyValue: 33L,
                column: "QuickAssessmentQuestionsId",
                value: 35L);

            migrationBuilder.UpdateData(
                table: "Validators",
                keyColumn: "Id",
                keyValue: 34L,
                column: "QuickAssessmentQuestionsId",
                value: 36L);

            migrationBuilder.UpdateData(
                table: "Validators",
                keyColumn: "Id",
                keyValue: 35L,
                column: "QuickAssessmentQuestionsId",
                value: 37L);

            migrationBuilder.UpdateData(
                table: "Validators",
                keyColumn: "Id",
                keyValue: 37L,
                column: "QuickAssessmentQuestionsId",
                value: 34L);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "MainUser",
                keyColumn: "Id",
                keyValue: -1L,
                column: "Password",
                value: "$2a$12$jUNQZW64cwWVO.f7NHuL7uHxgG/6mFvjpANvv25a/dGBj9iF2FUjG");

            migrationBuilder.UpdateData(
                table: "MainUser",
                keyColumn: "Id",
                keyValue: 1L,
                column: "Password",
                value: "$2a$12$DWvJFeogot.Yll8XdL5v..sPPyd563BoAKn/caKSsPYn5J069yl1q");

            migrationBuilder.UpdateData(
                table: "MainUser",
                keyColumn: "Id",
                keyValue: 2L,
                column: "Password",
                value: "$2a$12$P/czZVF7UaJhTyYonsGwruXxcIezCUDQ5gQKS6jY.9cojjHd.MKP6");

            migrationBuilder.UpdateData(
                table: "MainUser",
                keyColumn: "Id",
                keyValue: 3L,
                column: "Password",
                value: "$2a$12$swMoUfdGDy4tUTLBXhtlV.LcjCXaUInA4ZeaFk53yB0gGOQCE4FIm");

            migrationBuilder.UpdateData(
                table: "MainUser",
                keyColumn: "Id",
                keyValue: 4L,
                column: "Password",
                value: "$2a$12$zEn6P9yml2WHyQmsHqEb3ec6mmXytrG58vaCoOSrAZhqOSceqi6P6");

            migrationBuilder.UpdateData(
                table: "MainUser",
                keyColumn: "Id",
                keyValue: 5L,
                column: "Password",
                value: "$2a$12$ze9UPZoXvDM3nfzfqYtuo.mFV06a8vrPPj73J2t52d3R6VYPZmHFu");

            migrationBuilder.UpdateData(
                table: "MainUser",
                keyColumn: "Id",
                keyValue: 6L,
                column: "Password",
                value: "$2a$12$.B9m7j0iO4UoKcjj66bsUuurh/xr7Knv8VGPSWzcpOr/OKRr5KIhC");

            migrationBuilder.UpdateData(
                table: "MainUser",
                keyColumn: "Id",
                keyValue: 7L,
                column: "Password",
                value: "$2a$12$eutGhDyM2X2KQZ/f/WDeduleTqZqQF8lIMFNa047RtNUxjVIkTJgu");

            migrationBuilder.UpdateData(
                table: "MainUser",
                keyColumn: "Id",
                keyValue: 8L,
                column: "Password",
                value: "$2a$12$lHILNL24z0qWqa6cbBIQPOzMZxs9RYHwcEHdg3IwLZrlY.J7KsmdS");

            migrationBuilder.UpdateData(
                table: "Options",
                keyColumn: "Id",
                keyValue: 45L,
                column: "QuickAssessmentQuestionsId",
                value: 34L);

            migrationBuilder.UpdateData(
                table: "Options",
                keyColumn: "Id",
                keyValue: 47L,
                column: "QuickAssessmentQuestionsId",
                value: 35L);

            migrationBuilder.UpdateData(
                table: "Options",
                keyColumn: "Id",
                keyValue: 48L,
                column: "QuickAssessmentQuestionsId",
                value: 35L);

            migrationBuilder.UpdateData(
                table: "Options",
                keyColumn: "Id",
                keyValue: 49L,
                column: "QuickAssessmentQuestionsId",
                value: 36L);

            migrationBuilder.UpdateData(
                table: "Options",
                keyColumn: "Id",
                keyValue: 50L,
                column: "QuickAssessmentQuestionsId",
                value: 36L);

            migrationBuilder.UpdateData(
                table: "Options",
                keyColumn: "Id",
                keyValue: 51L,
                column: "QuickAssessmentQuestionsId",
                value: 37L);

            migrationBuilder.UpdateData(
                table: "Options",
                keyColumn: "Id",
                keyValue: 52L,
                column: "QuickAssessmentQuestionsId",
                value: 37L);

            migrationBuilder.UpdateData(
                table: "Options",
                keyColumn: "Id",
                keyValue: 53L,
                column: "QuickAssessmentQuestionsId",
                value: 37L);

            migrationBuilder.UpdateData(
                table: "QuickAssessmentQuestions",
                keyColumn: "Id",
                keyValue: 33L,
                column: "MessageInfo",
                value: "Your SSN is secure with us. We ask for this information as most government agencies require this number when submitting an application for benefits.");

            migrationBuilder.UpdateData(
                table: "QuickAssessmentQuestions",
                keyColumn: "Id",
                keyValue: 34L,
                columns: new[] { "Class", "FieldName", "FieldTypeId", "MessageInfo", "OrderId", "Placeholder", "Required", "TermAndConditionPopupMessage", "TermAndConditionsMessageLabel", "UniqueKey" },
                values: new object[] { "col-12", null, 8L, null, "3", null, true, "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat.Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat.Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat.Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat.Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat.Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat.", "Terms And Conditions", "agreementCheckBox" });

            migrationBuilder.UpdateData(
                table: "QuickAssessmentQuestions",
                keyColumn: "Id",
                keyValue: 35L,
                columns: new[] { "Class", "DynamicScreensId", "FieldName", "FieldTypeId", "OrderId", "OthersLabel", "ParentQuestionId", "PatientLabel", "Required", "ScreenId", "TermAndConditionPopupMessage", "TermAndConditionsMessageLabel", "UniqueKey" },
                values: new object[] { "col-5", 10L, "Is Report Filed", 7L, "1", "Was a Report Filed?", 31L, "Was a Report Filed?", false, "10", null, null, "motorReportFiled" });

            migrationBuilder.UpdateData(
                table: "QuickAssessmentQuestions",
                keyColumn: "Id",
                keyValue: 36L,
                column: "UniqueKey",
                value: "jobReportFiled");

            migrationBuilder.UpdateData(
                table: "QuickAssessmentQuestions",
                keyColumn: "Id",
                keyValue: 37L,
                columns: new[] { "DynamicScreensId", "FieldName", "FieldTypeId", "OrderId", "OthersLabel", "ParentQuestionId", "PatientLabel", "Placeholder", "ScreenId", "UniqueKey" },
                values: new object[] { 11L, "Reason no SSN", 4L, "2", null, null, null, "Reason No SSN", "11", "reasonNoSSN" });

            migrationBuilder.UpdateData(
                table: "Validators",
                keyColumn: "Id",
                keyValue: 33L,
                column: "QuickAssessmentQuestionsId",
                value: 34L);

            migrationBuilder.UpdateData(
                table: "Validators",
                keyColumn: "Id",
                keyValue: 34L,
                column: "QuickAssessmentQuestionsId",
                value: 35L);

            migrationBuilder.UpdateData(
                table: "Validators",
                keyColumn: "Id",
                keyValue: 35L,
                column: "QuickAssessmentQuestionsId",
                value: 36L);

            migrationBuilder.UpdateData(
                table: "Validators",
                keyColumn: "Id",
                keyValue: 37L,
                column: "QuickAssessmentQuestionsId",
                value: 37L);
        }
    }
}
