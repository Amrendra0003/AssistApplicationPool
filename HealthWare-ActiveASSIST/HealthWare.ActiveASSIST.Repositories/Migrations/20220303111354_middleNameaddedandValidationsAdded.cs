using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace HealthWare.ActiveASSIST.Repositories.Migrations
{
    public partial class middleNameaddedandValidationsAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "MainUser",
                keyColumn: "Id",
                keyValue: -1L,
                column: "Password",
                value: "$2a$12$EAFaf6r4sLk5T9L48snsae6dRk.N/lWdL3XlD5i4JYcxYkULtPY2.");

            migrationBuilder.UpdateData(
                table: "MainUser",
                keyColumn: "Id",
                keyValue: 1L,
                column: "Password",
                value: "$2a$12$bgPaL9H/KsHb5swoPZnSn.KMG/jXOlVX7RexjHHXITTDZBcGJUT6G");

            migrationBuilder.UpdateData(
                table: "MainUser",
                keyColumn: "Id",
                keyValue: 2L,
                column: "Password",
                value: "$2a$12$BGYaOcrQ1RMA6gOr5iFgpex8dKN3m/XpccFA76Ts8/hSTme95MHgC");

            migrationBuilder.UpdateData(
                table: "MainUser",
                keyColumn: "Id",
                keyValue: 3L,
                column: "Password",
                value: "$2a$12$HCi6933ZafepupepVxgmt.Jy.MpsuItReu6jj6ijlI9QT.n6.KlzC");

            migrationBuilder.UpdateData(
                table: "MainUser",
                keyColumn: "Id",
                keyValue: 4L,
                column: "Password",
                value: "$2a$12$K.L/lhz4dxNKr1A9sfHrsuACzQY81TSzDAIMYTo5JGb4VGO6jdV0y");

            migrationBuilder.UpdateData(
                table: "MainUser",
                keyColumn: "Id",
                keyValue: 5L,
                column: "Password",
                value: "$2a$12$q.OMZlmMv7nhLWzmPsoZYus9LuwLj0gnsa15KMsbs5gp06UTMHX4.");

            migrationBuilder.UpdateData(
                table: "MainUser",
                keyColumn: "Id",
                keyValue: 6L,
                column: "Password",
                value: "$2a$12$V6z/DshhUpc79oTG1X/4RufwtYrxBWDCSSDUaMlmx9dK6esu7KY/i");

            migrationBuilder.UpdateData(
                table: "QuickAssessmentQuestions",
                keyColumn: "Id",
                keyValue: 6L,
                column: "OrderId",
                value: "1");

            migrationBuilder.UpdateData(
                table: "QuickAssessmentQuestions",
                keyColumn: "Id",
                keyValue: 7L,
                columns: new[] { "FieldName", "OrderId", "Placeholder", "Required", "UniqueKey" },
                values: new object[] { "Middle Name", "2", "Middle Name", false, "middleName" });

            migrationBuilder.UpdateData(
                table: "QuickAssessmentQuestions",
                keyColumn: "Id",
                keyValue: 8L,
                columns: new[] { "FieldName", "FieldTypeId", "MaximumDate", "OrderId", "Placeholder", "UniqueKey" },
                values: new object[] { "Last Name", 6L, null, "3", "Last Name", "lastName" });

            migrationBuilder.UpdateData(
                table: "QuickAssessmentQuestions",
                keyColumn: "Id",
                keyValue: 9L,
                columns: new[] { "FieldName", "FieldTypeId", "MaximumDate", "OrderId", "Placeholder", "UniqueKey" },
                values: new object[] { "Date of Birth", 3L, "today", "5", "mm/dd/yyyy", "dateOfBirth" });

            migrationBuilder.UpdateData(
                table: "QuickAssessmentQuestions",
                keyColumn: "Id",
                keyValue: 10L,
                columns: new[] { "FieldName", "OrderId", "Placeholder", "Required", "UniqueKey" },
                values: new object[] { "Gender", "6", "Gender", true, "gender" });

            migrationBuilder.UpdateData(
                table: "QuickAssessmentQuestions",
                keyColumn: "Id",
                keyValue: 11L,
                columns: new[] { "FieldName", "FieldTypeId", "InlineLabel", "IsInlineLabel", "OrderId", "Placeholder", "Required", "UniqueKey" },
                values: new object[] { "Marital Status", 4L, null, false, "7", "Marital Status", false, "maritalStatus" });

            migrationBuilder.UpdateData(
                table: "QuickAssessmentQuestions",
                keyColumn: "Id",
                keyValue: 12L,
                columns: new[] { "FieldName", "FieldTypeId", "InlineLabel", "OrderId", "Placeholder", "UniqueKey" },
                values: new object[] { "Email", 6L, "Email", "8", "Email", "email" });

            migrationBuilder.UpdateData(
                table: "QuickAssessmentQuestions",
                keyColumn: "Id",
                keyValue: 13L,
                columns: new[] { "AlertInfo", "CustomValidation", "DynamicScreensId", "ErrorMessageInfo", "FieldName", "FieldTypeId", "InlineLabel", "IsInlineLabel", "OrderId", "Placeholder", "ScreenHeaderOthersLabel", "ScreenHeaderPatientLabel", "ScreenId", "UniqueKey" },
                values: new object[] { null, null, 4L, null, "Cell Number", 1L, "Cell", true, "9", "Cell Number", null, null, "4", "cellNumber" });

            migrationBuilder.UpdateData(
                table: "QuickAssessmentQuestions",
                keyColumn: "Id",
                keyValue: 14L,
                columns: new[] { "AlertInfo", "CustomValidation", "ErrorMessageInfo", "FieldName", "FieldTypeId", "OrderId", "ParentQuestionId", "Placeholder", "ScreenHeaderOthersLabel", "ScreenHeaderPatientLabel", "UniqueKey" },
                values: new object[] { "Invalid policy Number", "Yes", "Your visit can be covered under your insurance. Please get in touch with your insurance provider for more information.", "Insurance", 7L, "2", null, null, "Does the patient currently or in the last 60 days have/had health insurance?", "Do you currently or in the last 60 days have/had health insurance?", "insurance" });

            migrationBuilder.UpdateData(
                table: "QuickAssessmentQuestions",
                keyColumn: "Id",
                keyValue: 15L,
                columns: new[] { "FieldName", "OrderId", "Placeholder", "ScreenHeaderOthersLabel", "ScreenHeaderPatientLabel", "UniqueKey" },
                values: new object[] { "Payer Name", "4", "Payer name", "Enter the following details", "Enter the following details", "payerName" });

            migrationBuilder.UpdateData(
                table: "QuickAssessmentQuestions",
                keyColumn: "Id",
                keyValue: 16L,
                columns: new[] { "FieldName", "InlineLabel", "IsInlineLabel", "Placeholder", "UniqueKey" },
                values: new object[] { "Group Name", null, false, "Group Name", "groupname" });

            migrationBuilder.UpdateData(
                table: "QuickAssessmentQuestions",
                keyColumn: "Id",
                keyValue: 17L,
                columns: new[] { "AlertInfo", "CustomValidation", "ErrorMessageInfo", "FieldName", "InlineLabel", "MessageInfo", "OrderId", "Placeholder", "UniqueKey" },
                values: new object[] { null, null, null, "Group Number", "Group No.", null, "5", "Group Number", "groupNo" });

            migrationBuilder.UpdateData(
                table: "QuickAssessmentQuestions",
                keyColumn: "Id",
                keyValue: 18L,
                columns: new[] { "AlertInfo", "CustomValidation", "ErrorMessageInfo", "FieldName", "FieldTypeId", "InlineLabel", "MessageInfo", "OrderId", "Placeholder", "UniqueKey" },
                values: new object[] { "Invalid policy Number", "PolicyNumber", "Your visit can be covered under your insurance. Please get in touch with your insurance provider for more information.", "Policy Number", 6L, "Policy No.", "Your visit can be covered under your insurance. Please get in touch with your insurance provider for more information.", "6", "Policy Number", "policyNo" });

            migrationBuilder.UpdateData(
                table: "QuickAssessmentQuestions",
                keyColumn: "Id",
                keyValue: 19L,
                columns: new[] { "FieldName", "InlineLabel", "OrderId", "Placeholder", "UniqueKey" },
                values: new object[] { "Effective From", "Effective From", "7", "Effective From", "effectiveFrom" });

            migrationBuilder.UpdateData(
                table: "QuickAssessmentQuestions",
                keyColumn: "Id",
                keyValue: 20L,
                columns: new[] { "Class", "DynamicScreensId", "FieldName", "FieldTypeId", "InlineLabel", "IsInlineLabel", "OrderId", "OthersLabel", "ParentQuestionId", "PatientLabel", "Placeholder", "ScreenHeaderOthersLabel", "ScreenHeaderPatientLabel", "ScreenId", "UniqueKey", "Value" },
                values: new object[] { "col-12", 5L, "Termination Date", 3L, "Termination", true, "8", null, 13L, null, "Termination", null, null, "5", "termination", null });

            migrationBuilder.UpdateData(
                table: "QuickAssessmentQuestions",
                keyColumn: "Id",
                keyValue: 21L,
                columns: new[] { "FieldName", "OrderId", "OthersLabel", "PatientLabel", "ScreenHeaderOthersLabel", "ScreenHeaderPatientLabel", "UniqueKey", "Value" },
                values: new object[] { "Household Members", "2", "Total Number of members living in patient's household", "Total Number of members living in your household", "Tell us about your household", "Tell us more about patient's household", "totalHouseholdMembers", "1" });

            migrationBuilder.UpdateData(
                table: "QuickAssessmentQuestions",
                keyColumn: "Id",
                keyValue: 22L,
                columns: new[] { "CustomValidation", "FieldName", "FieldTypeId", "OrderId", "OthersLabel", "PatientLabel", "UniqueKey", "Value" },
                values: new object[] { null, "Total Minors", 2L, "3", "Minor children for whom the patient has full custody?", "Minor children for whom you have full custody?", "totalMinors", "0" });

            migrationBuilder.UpdateData(
                table: "QuickAssessmentQuestions",
                keyColumn: "Id",
                keyValue: 23L,
                columns: new[] { "CustomValidation", "FieldName", "OrderId", "OthersLabel", "ParentQuestionId", "PatientLabel", "UniqueKey" },
                values: new object[] { "Yes/No", "Is Employed", "4", "Is the patient employed?", null, "Are you employed?", "isEmployed" });

            migrationBuilder.UpdateData(
                table: "QuickAssessmentQuestions",
                keyColumn: "Id",
                keyValue: 24L,
                columns: new[] { "Class", "CustomValidation", "ErrorMessageInfo", "FieldName", "FieldTypeId", "MessageInfo", "OthersLabel", "ParentQuestionId", "PatientLabel", "Required", "ScreenHeaderOthersLabel", "ScreenHeaderPatientLabel", "UniqueKey" },
                values: new object[] { "col-5", "Yes", null, "Is Household Employed", 7L, null, "Is anyone in your household employed?", 22L, "Is anyone in your household employed?", true, null, null, "isHouseholdEmployed" });

            migrationBuilder.UpdateData(
                table: "QuickAssessmentQuestions",
                keyColumn: "Id",
                keyValue: 25L,
                columns: new[] { "Class", "DynamicScreensId", "ErrorMessageInfo", "FieldName", "FieldTypeId", "InlineLabel", "IsInlineLabel", "MessageInfo", "OrderId", "OthersLabel", "ParentQuestionId", "PatientLabel", "Placeholder", "Required", "ScreenHeaderOthersLabel", "ScreenHeaderPatientLabel", "ScreenId", "UniqueKey" },
                values: new object[] { "col-12", 6L, "If none of them apply, you can directly move to the next question.", "Program Services", 8L, null, false, "If none of them apply, you can directly move to the next question.", "1", null, 23L, null, null, false, "Do you currently receive any of the following?", "Do you currently receive any of the following?", "6", "programServices" });

            migrationBuilder.UpdateData(
                table: "QuickAssessmentQuestions",
                keyColumn: "Id",
                keyValue: 26L,
                columns: new[] { "ErrorMessageInfo", "FieldName", "FieldTypeId", "InlineLabel", "IsInlineLabel", "MessageInfo", "OrderId", "OthersLabel", "PatientLabel", "Placeholder", "ScreenHeaderOthersLabel", "ScreenHeaderPatientLabel", "UniqueKey" },
                values: new object[] { null, "Household Income", 6L, "$", true, null, "2", "Estimated Household Income", "Estimated Household Income", "Income", "Enter patient's household income and resources", "Enter household income and resources", "householdIncome" });

            migrationBuilder.UpdateData(
                table: "QuickAssessmentQuestions",
                keyColumn: "Id",
                keyValue: 27L,
                columns: new[] { "ErrorMessageInfo", "FieldName", "FieldTypeId", "InlineLabel", "IsInlineLabel", "MessageInfo", "OrderId", "OthersLabel", "PatientLabel", "Placeholder", "UniqueKey" },
                values: new object[] { "Include income earned by all the members of the household.", "Income Pay Period", 4L, null, false, "Include income earned by all the members of the household.", "3", "Select Grosspay", "Select Grosspay", "Gross Pay", "incomePayPeriod" });

            migrationBuilder.UpdateData(
                table: "QuickAssessmentQuestions",
                keyColumn: "Id",
                keyValue: 28L,
                columns: new[] { "Class", "CustomValidation", "DynamicScreensId", "ErrorMessageInfo", "FieldName", "FieldTypeId", "InlineLabel", "IsInlineLabel", "MessageInfo", "OrderId", "OthersLabel", "PatientLabel", "Placeholder", "Required", "ScreenHeaderOthersLabel", "ScreenHeaderPatientLabel", "ScreenId", "UniqueKey" },
                values: new object[] { "col-3", null, 7L, "Please estimate the total resource value held by all the members of the household in the form of checking & savings, retirement accounts, property (home, vehicle, etc) and any others assets.", "Household Resources", 6L, "$", true, "Please estimate the total resource value held by all the members of the household in the form of checking & savings, retirement accounts, property (home, vehicle, etc) and any others assets.", "4", "Estimated Household Resources", "Estimated Household Resources", "Resources", true, null, null, "7", "householdResources" });

            migrationBuilder.UpdateData(
                table: "QuickAssessmentQuestions",
                keyColumn: "Id",
                keyValue: 29L,
                columns: new[] { "DynamicScreensId", "ErrorMessageInfo", "FieldName", "MessageInfo", "ScreenHeaderOthersLabel", "ScreenHeaderPatientLabel", "ScreenId", "UniqueKey" },
                values: new object[] { 8L, "If none of them apply, you can directly move to the next question.", "Service Program", "If none of them apply, you can directly move to the next question.", "Please select the options that apply to you and click on next.", "Please select the options that apply to you and click on next.", "8", "serviceProgram" });

            migrationBuilder.UpdateData(
                table: "QuickAssessmentQuestions",
                keyColumn: "Id",
                keyValue: 30L,
                columns: new[] { "DynamicScreensId", "FieldName", "ScreenHeaderOthersLabel", "ScreenHeaderPatientLabel", "ScreenId", "UniqueKey" },
                values: new object[] { 9L, "Health Condition", "Do any of the following health conditions apply to you?", "Do any of the following health conditions apply to you?", "9", "healthConditiion" });

            migrationBuilder.UpdateData(
                table: "QuickAssessmentQuestions",
                keyColumn: "Id",
                keyValue: 31L,
                columns: new[] { "Class", "CustomValidation", "FieldName", "FieldTypeId", "OthersLabel", "ParentQuestionId", "PatientLabel", "ScreenHeaderOthersLabel", "ScreenHeaderPatientLabel", "UniqueKey" },
                values: new object[] { "col-12", "Any", "Been Injured", 8L, null, null, null, "Select if you have been injured", "Select if you have been injured", "beenInjured" });

            migrationBuilder.UpdateData(
                table: "QuickAssessmentQuestions",
                keyColumn: "Id",
                keyValue: 32L,
                columns: new[] { "DynamicScreensId", "FieldName", "FieldTypeId", "MessageInfo", "OthersLabel", "ParentQuestionId", "PatientLabel", "Placeholder", "Required", "ScreenHeaderOthersLabel", "ScreenHeaderPatientLabel", "ScreenId", "UniqueKey" },
                values: new object[] { 10L, "Is Report Filed", 7L, null, "Was a Report Filed?", 30L, "Was a Report Filed?", null, false, null, null, "10", "crimeReportFiled" });

            migrationBuilder.UpdateData(
                table: "QuickAssessmentQuestions",
                keyColumn: "Id",
                keyValue: 33L,
                columns: new[] { "Class", "FieldName", "FieldTypeId", "MessageInfo", "OrderId", "Placeholder", "ScreenHeaderOthersLabel", "ScreenHeaderPatientLabel", "TermAndConditionPopupMessage", "TermAndConditionsMessageLabel", "UniqueKey" },
                values: new object[] { "col-5", "SSN", 9L, "Your SSN is secure with us. We ask for this information as most government agencies require this number when submitting an application for benefits.", "1", "SSN", "Last Step.Please provide patient''s SSN", "Last Step. Please provide your SSN", null, null, "ssnNumber" });

            migrationBuilder.UpdateData(
                table: "QuickAssessmentQuestions",
                keyColumn: "Id",
                keyValue: 34L,
                columns: new[] { "Class", "DynamicScreensId", "FieldName", "FieldTypeId", "OrderId", "OthersLabel", "ParentQuestionId", "PatientLabel", "Required", "ScreenId", "TermAndConditionPopupMessage", "TermAndConditionsMessageLabel", "UniqueKey" },
                values: new object[] { "col-12", 11L, null, 8L, "2", null, null, null, true, "11", "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat.Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat.Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat.Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat.Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat.Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat.", "Terms And Conditions", "agreementCheckBox" });

            migrationBuilder.UpdateData(
                table: "QuickAssessmentQuestions",
                keyColumn: "Id",
                keyValue: 35L,
                column: "UniqueKey",
                value: "motorReportFiled");

            migrationBuilder.UpdateData(
                table: "QuickAssessmentQuestions",
                keyColumn: "Id",
                keyValue: 36L,
                columns: new[] { "Class", "DynamicScreensId", "FieldName", "FieldTypeId", "OrderId", "OthersLabel", "ParentQuestionId", "PatientLabel", "Placeholder", "ScreenId", "UniqueKey" },
                values: new object[] { "col-5", 10L, "Is Report Filed", 7L, "1", "Was a Report Filed?", 30L, "Was a Report Filed?", null, "10", "jobReportFiled" });

            migrationBuilder.UpdateData(
                table: "Validators",
                keyColumn: "Id",
                keyValue: 7L,
                column: "QuickAssessmentQuestionsId",
                value: 8L);

            migrationBuilder.UpdateData(
                table: "Validators",
                keyColumn: "Id",
                keyValue: 8L,
                column: "QuickAssessmentQuestionsId",
                value: 9L);

            migrationBuilder.UpdateData(
                table: "Validators",
                keyColumn: "Id",
                keyValue: 9L,
                column: "QuickAssessmentQuestionsId",
                value: 10L);

            migrationBuilder.UpdateData(
                table: "Validators",
                keyColumn: "Id",
                keyValue: 10L,
                column: "QuickAssessmentQuestionsId",
                value: 11L);

            migrationBuilder.UpdateData(
                table: "Validators",
                keyColumn: "Id",
                keyValue: 11L,
                column: "QuickAssessmentQuestionsId",
                value: 12L);

            migrationBuilder.UpdateData(
                table: "Validators",
                keyColumn: "Id",
                keyValue: 12L,
                column: "QuickAssessmentQuestionsId",
                value: 13L);

            migrationBuilder.UpdateData(
                table: "Validators",
                keyColumn: "Id",
                keyValue: 13L,
                column: "QuickAssessmentQuestionsId",
                value: 14L);

            migrationBuilder.UpdateData(
                table: "Validators",
                keyColumn: "Id",
                keyValue: 14L,
                column: "QuickAssessmentQuestionsId",
                value: 15L);

            migrationBuilder.UpdateData(
                table: "Validators",
                keyColumn: "Id",
                keyValue: 15L,
                column: "QuickAssessmentQuestionsId",
                value: 16L);

            migrationBuilder.UpdateData(
                table: "Validators",
                keyColumn: "Id",
                keyValue: 16L,
                column: "QuickAssessmentQuestionsId",
                value: 17L);

            migrationBuilder.UpdateData(
                table: "Validators",
                keyColumn: "Id",
                keyValue: 17L,
                column: "QuickAssessmentQuestionsId",
                value: 18L);

            migrationBuilder.UpdateData(
                table: "Validators",
                keyColumn: "Id",
                keyValue: 18L,
                column: "QuickAssessmentQuestionsId",
                value: 19L);

            migrationBuilder.UpdateData(
                table: "Validators",
                keyColumn: "Id",
                keyValue: 19L,
                column: "QuickAssessmentQuestionsId",
                value: 20L);

            migrationBuilder.UpdateData(
                table: "Validators",
                keyColumn: "Id",
                keyValue: 20L,
                column: "QuickAssessmentQuestionsId",
                value: 21L);

            migrationBuilder.UpdateData(
                table: "Validators",
                keyColumn: "Id",
                keyValue: 21L,
                column: "QuickAssessmentQuestionsId",
                value: 22L);

            migrationBuilder.UpdateData(
                table: "Validators",
                keyColumn: "Id",
                keyValue: 22L,
                column: "QuickAssessmentQuestionsId",
                value: 23L);

            migrationBuilder.UpdateData(
                table: "Validators",
                keyColumn: "Id",
                keyValue: 23L,
                column: "QuickAssessmentQuestionsId",
                value: 24L);

            migrationBuilder.UpdateData(
                table: "Validators",
                keyColumn: "Id",
                keyValue: 24L,
                column: "QuickAssessmentQuestionsId",
                value: 25L);

            migrationBuilder.UpdateData(
                table: "Validators",
                keyColumn: "Id",
                keyValue: 25L,
                column: "QuickAssessmentQuestionsId",
                value: 26L);

            migrationBuilder.UpdateData(
                table: "Validators",
                keyColumn: "Id",
                keyValue: 26L,
                column: "QuickAssessmentQuestionsId",
                value: 27L);

            migrationBuilder.UpdateData(
                table: "Validators",
                keyColumn: "Id",
                keyValue: 27L,
                column: "QuickAssessmentQuestionsId",
                value: 28L);

            migrationBuilder.UpdateData(
                table: "Validators",
                keyColumn: "Id",
                keyValue: 28L,
                column: "QuickAssessmentQuestionsId",
                value: 29L);

            migrationBuilder.UpdateData(
                table: "Validators",
                keyColumn: "Id",
                keyValue: 29L,
                column: "QuickAssessmentQuestionsId",
                value: 30L);

            migrationBuilder.UpdateData(
                table: "Validators",
                keyColumn: "Id",
                keyValue: 30L,
                column: "QuickAssessmentQuestionsId",
                value: 31L);

            migrationBuilder.UpdateData(
                table: "Validators",
                keyColumn: "Id",
                keyValue: 31L,
                column: "QuickAssessmentQuestionsId",
                value: 32L);

            migrationBuilder.UpdateData(
                table: "Validators",
                keyColumn: "Id",
                keyValue: 32L,
                column: "QuickAssessmentQuestionsId",
                value: 33L);

            migrationBuilder.UpdateData(
                table: "Validators",
                keyColumn: "Id",
                keyValue: 34L,
                column: "QuickAssessmentQuestionsId",
                value: 36L);

            migrationBuilder.InsertData(
                table: "Validators",
                columns: new[] { "Id", "CreatedBy", "CreatedDate", "Max", "MaxLength", "Min", "MinLength", "PatternId", "QuickAssessmentQuestionsId", "Required", "UpdatedBy", "UpdatedDate" },
                values: new object[] { 36L, null, new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 50, null, 0, 4L, 7L, false, null, null });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Validators",
                keyColumn: "Id",
                keyValue: 36L);

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
                keyValue: 6L,
                column: "OrderId",
                value: "2");

            migrationBuilder.UpdateData(
                table: "QuickAssessmentQuestions",
                keyColumn: "Id",
                keyValue: 7L,
                columns: new[] { "FieldName", "OrderId", "Placeholder", "Required", "UniqueKey" },
                values: new object[] { "Last Name", "3", "Last Name", true, "lastName" });

            migrationBuilder.UpdateData(
                table: "QuickAssessmentQuestions",
                keyColumn: "Id",
                keyValue: 8L,
                columns: new[] { "FieldName", "FieldTypeId", "MaximumDate", "OrderId", "Placeholder", "UniqueKey" },
                values: new object[] { "Date of Birth", 3L, "today", "5", "mm/dd/yyyy", "dateOfBirth" });

            migrationBuilder.UpdateData(
                table: "QuickAssessmentQuestions",
                keyColumn: "Id",
                keyValue: 9L,
                columns: new[] { "FieldName", "FieldTypeId", "MaximumDate", "OrderId", "Placeholder", "UniqueKey" },
                values: new object[] { "Gender", 4L, null, "6", "Gender", "gender" });

            migrationBuilder.UpdateData(
                table: "QuickAssessmentQuestions",
                keyColumn: "Id",
                keyValue: 10L,
                columns: new[] { "FieldName", "OrderId", "Placeholder", "Required", "UniqueKey" },
                values: new object[] { "Marital Status", "7", "Marital Status", false, "maritalStatus" });

            migrationBuilder.UpdateData(
                table: "QuickAssessmentQuestions",
                keyColumn: "Id",
                keyValue: 11L,
                columns: new[] { "FieldName", "FieldTypeId", "InlineLabel", "IsInlineLabel", "OrderId", "Placeholder", "Required", "UniqueKey" },
                values: new object[] { "Email", 6L, "Email", true, "8", "Email", true, "email" });

            migrationBuilder.UpdateData(
                table: "QuickAssessmentQuestions",
                keyColumn: "Id",
                keyValue: 12L,
                columns: new[] { "FieldName", "FieldTypeId", "InlineLabel", "OrderId", "Placeholder", "UniqueKey" },
                values: new object[] { "Cell Number", 1L, "Cell", "9", "Cell Number", "cellNumber" });

            migrationBuilder.UpdateData(
                table: "QuickAssessmentQuestions",
                keyColumn: "Id",
                keyValue: 13L,
                columns: new[] { "AlertInfo", "CustomValidation", "DynamicScreensId", "ErrorMessageInfo", "FieldName", "FieldTypeId", "InlineLabel", "IsInlineLabel", "OrderId", "Placeholder", "ScreenHeaderOthersLabel", "ScreenHeaderPatientLabel", "ScreenId", "UniqueKey" },
                values: new object[] { "Invalid policy Number", "Yes", 5L, "Your visit can be covered under your insurance. Please get in touch with your insurance provider for more information.", "Insurance", 7L, null, false, "2", null, "Does the patient currently or in the last 60 days have/had health insurance?", "Do you currently or in the last 60 days have/had health insurance?", "5", "insurance" });

            migrationBuilder.UpdateData(
                table: "QuickAssessmentQuestions",
                keyColumn: "Id",
                keyValue: 14L,
                columns: new[] { "AlertInfo", "CustomValidation", "ErrorMessageInfo", "FieldName", "FieldTypeId", "OrderId", "ParentQuestionId", "Placeholder", "ScreenHeaderOthersLabel", "ScreenHeaderPatientLabel", "UniqueKey" },
                values: new object[] { null, null, null, "Payer Name", 6L, "4", 13L, "Payer name", "Enter the following details", "Enter the following details", "payerName" });

            migrationBuilder.UpdateData(
                table: "QuickAssessmentQuestions",
                keyColumn: "Id",
                keyValue: 15L,
                columns: new[] { "FieldName", "OrderId", "Placeholder", "ScreenHeaderOthersLabel", "ScreenHeaderPatientLabel", "UniqueKey" },
                values: new object[] { "Group Name", "5", "Group Name", null, null, "groupname" });

            migrationBuilder.UpdateData(
                table: "QuickAssessmentQuestions",
                keyColumn: "Id",
                keyValue: 16L,
                columns: new[] { "FieldName", "InlineLabel", "IsInlineLabel", "Placeholder", "UniqueKey" },
                values: new object[] { "Group Number", "Group No.", true, "Group Number", "groupNo" });

            migrationBuilder.UpdateData(
                table: "QuickAssessmentQuestions",
                keyColumn: "Id",
                keyValue: 17L,
                columns: new[] { "AlertInfo", "CustomValidation", "ErrorMessageInfo", "FieldName", "InlineLabel", "MessageInfo", "OrderId", "Placeholder", "UniqueKey" },
                values: new object[] { "Invalid policy Number", "PolicyNumber", "Your visit can be covered under your insurance. Please get in touch with your insurance provider for more information.", "Policy Number", "Policy No.", "Your visit can be covered under your insurance. Please get in touch with your insurance provider for more information.", "6", "Policy Number", "policyNo" });

            migrationBuilder.UpdateData(
                table: "QuickAssessmentQuestions",
                keyColumn: "Id",
                keyValue: 18L,
                columns: new[] { "AlertInfo", "CustomValidation", "ErrorMessageInfo", "FieldName", "FieldTypeId", "InlineLabel", "MessageInfo", "OrderId", "Placeholder", "UniqueKey" },
                values: new object[] { null, null, null, "Effective From", 3L, "Effective From", null, "7", "Effective From", "effectiveFrom" });

            migrationBuilder.UpdateData(
                table: "QuickAssessmentQuestions",
                keyColumn: "Id",
                keyValue: 19L,
                columns: new[] { "FieldName", "InlineLabel", "OrderId", "Placeholder", "UniqueKey" },
                values: new object[] { "Termination Date", "Termination", "8", "Termination", "termination" });

            migrationBuilder.UpdateData(
                table: "QuickAssessmentQuestions",
                keyColumn: "Id",
                keyValue: 20L,
                columns: new[] { "Class", "DynamicScreensId", "FieldName", "FieldTypeId", "InlineLabel", "IsInlineLabel", "OrderId", "OthersLabel", "ParentQuestionId", "PatientLabel", "Placeholder", "ScreenHeaderOthersLabel", "ScreenHeaderPatientLabel", "ScreenId", "UniqueKey", "Value" },
                values: new object[] { "col-5", 6L, "Household Members", 2L, null, false, "2", "Total Number of members living in patient's household", null, "Total Number of members living in your household", null, "Tell us about your household", "Tell us more about patient's household", "6", "totalHouseholdMembers", "1" });

            migrationBuilder.UpdateData(
                table: "QuickAssessmentQuestions",
                keyColumn: "Id",
                keyValue: 21L,
                columns: new[] { "FieldName", "OrderId", "OthersLabel", "PatientLabel", "ScreenHeaderOthersLabel", "ScreenHeaderPatientLabel", "UniqueKey", "Value" },
                values: new object[] { "Total Minors", "3", "Minor children for whom the patient has full custody?", "Minor children for whom you have full custody?", null, null, "totalMinors", "0" });

            migrationBuilder.UpdateData(
                table: "QuickAssessmentQuestions",
                keyColumn: "Id",
                keyValue: 22L,
                columns: new[] { "CustomValidation", "FieldName", "FieldTypeId", "OrderId", "OthersLabel", "PatientLabel", "UniqueKey", "Value" },
                values: new object[] { "Yes/No", "Is Employed", 7L, "4", "Is the patient employed?", "Are you employed?", "isEmployed", null });

            migrationBuilder.UpdateData(
                table: "QuickAssessmentQuestions",
                keyColumn: "Id",
                keyValue: 23L,
                columns: new[] { "CustomValidation", "FieldName", "OrderId", "OthersLabel", "ParentQuestionId", "PatientLabel", "UniqueKey" },
                values: new object[] { "Yes", "Is Household Employed", "1", "Is anyone in your household employed?", 22L, "Is anyone in your household employed?", "isHouseholdEmployed" });

            migrationBuilder.UpdateData(
                table: "QuickAssessmentQuestions",
                keyColumn: "Id",
                keyValue: 24L,
                columns: new[] { "Class", "CustomValidation", "ErrorMessageInfo", "FieldName", "FieldTypeId", "MessageInfo", "OthersLabel", "ParentQuestionId", "PatientLabel", "Required", "ScreenHeaderOthersLabel", "ScreenHeaderPatientLabel", "UniqueKey" },
                values: new object[] { "col-12", null, "If none of them apply, you can directly move to the next question.", "Program Services", 8L, "If none of them apply, you can directly move to the next question.", null, 23L, null, false, "Do you currently receive any of the following?", "Do you currently receive any of the following?", "programServices" });

            migrationBuilder.UpdateData(
                table: "QuickAssessmentQuestions",
                keyColumn: "Id",
                keyValue: 25L,
                columns: new[] { "Class", "DynamicScreensId", "ErrorMessageInfo", "FieldName", "FieldTypeId", "InlineLabel", "IsInlineLabel", "MessageInfo", "OrderId", "OthersLabel", "ParentQuestionId", "PatientLabel", "Placeholder", "Required", "ScreenHeaderOthersLabel", "ScreenHeaderPatientLabel", "ScreenId", "UniqueKey" },
                values: new object[] { "col-3", 7L, null, "Household Income", 6L, "$", true, null, "2", "Estimated Household Income", null, "Estimated Household Income", "Income", true, "Enter patient's household income and resources", "Enter household income and resources", "7", "householdIncome" });

            migrationBuilder.UpdateData(
                table: "QuickAssessmentQuestions",
                keyColumn: "Id",
                keyValue: 26L,
                columns: new[] { "ErrorMessageInfo", "FieldName", "FieldTypeId", "InlineLabel", "IsInlineLabel", "MessageInfo", "OrderId", "OthersLabel", "PatientLabel", "Placeholder", "ScreenHeaderOthersLabel", "ScreenHeaderPatientLabel", "UniqueKey" },
                values: new object[] { "Include income earned by all the members of the household.", "Income Pay Period", 4L, null, false, "Include income earned by all the members of the household.", "3", "Select Grosspay", "Select Grosspay", "Gross Pay", null, null, "incomePayPeriod" });

            migrationBuilder.UpdateData(
                table: "QuickAssessmentQuestions",
                keyColumn: "Id",
                keyValue: 27L,
                columns: new[] { "ErrorMessageInfo", "FieldName", "FieldTypeId", "InlineLabel", "IsInlineLabel", "MessageInfo", "OrderId", "OthersLabel", "PatientLabel", "Placeholder", "UniqueKey" },
                values: new object[] { "Please estimate the total resource value held by all the members of the household in the form of checking & savings, retirement accounts, property (home, vehicle, etc) and any others assets.", "Household Resources", 6L, "$", true, "Please estimate the total resource value held by all the members of the household in the form of checking & savings, retirement accounts, property (home, vehicle, etc) and any others assets.", "4", "Estimated Household Resources", "Estimated Household Resources", "Resources", "householdResources" });

            migrationBuilder.UpdateData(
                table: "QuickAssessmentQuestions",
                keyColumn: "Id",
                keyValue: 28L,
                columns: new[] { "Class", "CustomValidation", "DynamicScreensId", "ErrorMessageInfo", "FieldName", "FieldTypeId", "InlineLabel", "IsInlineLabel", "MessageInfo", "OrderId", "OthersLabel", "PatientLabel", "Placeholder", "Required", "ScreenHeaderOthersLabel", "ScreenHeaderPatientLabel", "ScreenId", "UniqueKey" },
                values: new object[] { "col-12", "Any", 8L, "If none of them apply, you can directly move to the next question.", "Service Program", 8L, null, false, "If none of them apply, you can directly move to the next question.", "1", null, null, null, false, "Please select the options that apply to you and click on next.", "Please select the options that apply to you and click on next.", "8", "serviceProgram" });

            migrationBuilder.UpdateData(
                table: "QuickAssessmentQuestions",
                keyColumn: "Id",
                keyValue: 29L,
                columns: new[] { "DynamicScreensId", "ErrorMessageInfo", "FieldName", "MessageInfo", "ScreenHeaderOthersLabel", "ScreenHeaderPatientLabel", "ScreenId", "UniqueKey" },
                values: new object[] { 9L, null, "Health Condition", null, "Do any of the following health conditions apply to you?", "Do any of the following health conditions apply to you?", "9", "healthConditiion" });

            migrationBuilder.UpdateData(
                table: "QuickAssessmentQuestions",
                keyColumn: "Id",
                keyValue: 30L,
                columns: new[] { "DynamicScreensId", "FieldName", "ScreenHeaderOthersLabel", "ScreenHeaderPatientLabel", "ScreenId", "UniqueKey" },
                values: new object[] { 10L, "Been Injured", "Select if you have been injured", "Select if you have been injured", "10", "beenInjured" });

            migrationBuilder.UpdateData(
                table: "QuickAssessmentQuestions",
                keyColumn: "Id",
                keyValue: 31L,
                columns: new[] { "Class", "CustomValidation", "FieldName", "FieldTypeId", "OthersLabel", "ParentQuestionId", "PatientLabel", "ScreenHeaderOthersLabel", "ScreenHeaderPatientLabel", "UniqueKey" },
                values: new object[] { "col-5", null, "Is Report Filed", 7L, "Was a Report Filed?", 30L, "Was a Report Filed?", null, null, "crimeReportFiled" });

            migrationBuilder.UpdateData(
                table: "QuickAssessmentQuestions",
                keyColumn: "Id",
                keyValue: 32L,
                columns: new[] { "DynamicScreensId", "FieldName", "FieldTypeId", "MessageInfo", "OthersLabel", "ParentQuestionId", "PatientLabel", "Placeholder", "Required", "ScreenHeaderOthersLabel", "ScreenHeaderPatientLabel", "ScreenId", "UniqueKey" },
                values: new object[] { 11L, "SSN", 9L, "Your SSN is secure with us. We ask for this information as most government agencies require this number when submitting an application for benefits.", null, null, null, "SSN", true, "Last Step.Please provide patient''s SSN", "Last Step. Please provide your SSN", "11", "ssnNumber" });

            migrationBuilder.UpdateData(
                table: "QuickAssessmentQuestions",
                keyColumn: "Id",
                keyValue: 33L,
                columns: new[] { "Class", "FieldName", "FieldTypeId", "MessageInfo", "OrderId", "Placeholder", "ScreenHeaderOthersLabel", "ScreenHeaderPatientLabel", "TermAndConditionPopupMessage", "TermAndConditionsMessageLabel", "UniqueKey" },
                values: new object[] { "col-12", null, 8L, null, "2", null, null, null, "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat.Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat.Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat.Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat.Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat.Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat.", "Terms And Conditions", "agreementCheckBox" });

            migrationBuilder.UpdateData(
                table: "QuickAssessmentQuestions",
                keyColumn: "Id",
                keyValue: 34L,
                columns: new[] { "Class", "DynamicScreensId", "FieldName", "FieldTypeId", "OrderId", "OthersLabel", "ParentQuestionId", "PatientLabel", "Required", "ScreenId", "TermAndConditionPopupMessage", "TermAndConditionsMessageLabel", "UniqueKey" },
                values: new object[] { "col-5", 10L, "Is Report Filed", 7L, "1", "Was a Report Filed?", 30L, "Was a Report Filed?", false, "10", null, null, "motorReportFiled" });

            migrationBuilder.UpdateData(
                table: "QuickAssessmentQuestions",
                keyColumn: "Id",
                keyValue: 35L,
                column: "UniqueKey",
                value: "jobReportFiled");

            migrationBuilder.UpdateData(
                table: "QuickAssessmentQuestions",
                keyColumn: "Id",
                keyValue: 36L,
                columns: new[] { "Class", "DynamicScreensId", "FieldName", "FieldTypeId", "OrderId", "OthersLabel", "ParentQuestionId", "PatientLabel", "Placeholder", "ScreenId", "UniqueKey" },
                values: new object[] { "col-12", 4L, "Middle Name", 6L, "2", null, null, null, "Middle Name", "4", "middleName" });

            migrationBuilder.UpdateData(
                table: "Validators",
                keyColumn: "Id",
                keyValue: 7L,
                column: "QuickAssessmentQuestionsId",
                value: 7L);

            migrationBuilder.UpdateData(
                table: "Validators",
                keyColumn: "Id",
                keyValue: 8L,
                column: "QuickAssessmentQuestionsId",
                value: 8L);

            migrationBuilder.UpdateData(
                table: "Validators",
                keyColumn: "Id",
                keyValue: 9L,
                column: "QuickAssessmentQuestionsId",
                value: 9L);

            migrationBuilder.UpdateData(
                table: "Validators",
                keyColumn: "Id",
                keyValue: 10L,
                column: "QuickAssessmentQuestionsId",
                value: 10L);

            migrationBuilder.UpdateData(
                table: "Validators",
                keyColumn: "Id",
                keyValue: 11L,
                column: "QuickAssessmentQuestionsId",
                value: 11L);

            migrationBuilder.UpdateData(
                table: "Validators",
                keyColumn: "Id",
                keyValue: 12L,
                column: "QuickAssessmentQuestionsId",
                value: 12L);

            migrationBuilder.UpdateData(
                table: "Validators",
                keyColumn: "Id",
                keyValue: 13L,
                column: "QuickAssessmentQuestionsId",
                value: 13L);

            migrationBuilder.UpdateData(
                table: "Validators",
                keyColumn: "Id",
                keyValue: 14L,
                column: "QuickAssessmentQuestionsId",
                value: 14L);

            migrationBuilder.UpdateData(
                table: "Validators",
                keyColumn: "Id",
                keyValue: 15L,
                column: "QuickAssessmentQuestionsId",
                value: 15L);

            migrationBuilder.UpdateData(
                table: "Validators",
                keyColumn: "Id",
                keyValue: 16L,
                column: "QuickAssessmentQuestionsId",
                value: 16L);

            migrationBuilder.UpdateData(
                table: "Validators",
                keyColumn: "Id",
                keyValue: 17L,
                column: "QuickAssessmentQuestionsId",
                value: 17L);

            migrationBuilder.UpdateData(
                table: "Validators",
                keyColumn: "Id",
                keyValue: 18L,
                column: "QuickAssessmentQuestionsId",
                value: 18L);

            migrationBuilder.UpdateData(
                table: "Validators",
                keyColumn: "Id",
                keyValue: 19L,
                column: "QuickAssessmentQuestionsId",
                value: 19L);

            migrationBuilder.UpdateData(
                table: "Validators",
                keyColumn: "Id",
                keyValue: 20L,
                column: "QuickAssessmentQuestionsId",
                value: 20L);

            migrationBuilder.UpdateData(
                table: "Validators",
                keyColumn: "Id",
                keyValue: 21L,
                column: "QuickAssessmentQuestionsId",
                value: 21L);

            migrationBuilder.UpdateData(
                table: "Validators",
                keyColumn: "Id",
                keyValue: 22L,
                column: "QuickAssessmentQuestionsId",
                value: 22L);

            migrationBuilder.UpdateData(
                table: "Validators",
                keyColumn: "Id",
                keyValue: 23L,
                column: "QuickAssessmentQuestionsId",
                value: 23L);

            migrationBuilder.UpdateData(
                table: "Validators",
                keyColumn: "Id",
                keyValue: 24L,
                column: "QuickAssessmentQuestionsId",
                value: 24L);

            migrationBuilder.UpdateData(
                table: "Validators",
                keyColumn: "Id",
                keyValue: 25L,
                column: "QuickAssessmentQuestionsId",
                value: 25L);

            migrationBuilder.UpdateData(
                table: "Validators",
                keyColumn: "Id",
                keyValue: 26L,
                column: "QuickAssessmentQuestionsId",
                value: 26L);

            migrationBuilder.UpdateData(
                table: "Validators",
                keyColumn: "Id",
                keyValue: 27L,
                column: "QuickAssessmentQuestionsId",
                value: 27L);

            migrationBuilder.UpdateData(
                table: "Validators",
                keyColumn: "Id",
                keyValue: 28L,
                column: "QuickAssessmentQuestionsId",
                value: 28L);

            migrationBuilder.UpdateData(
                table: "Validators",
                keyColumn: "Id",
                keyValue: 29L,
                column: "QuickAssessmentQuestionsId",
                value: 29L);

            migrationBuilder.UpdateData(
                table: "Validators",
                keyColumn: "Id",
                keyValue: 30L,
                column: "QuickAssessmentQuestionsId",
                value: 30L);

            migrationBuilder.UpdateData(
                table: "Validators",
                keyColumn: "Id",
                keyValue: 31L,
                column: "QuickAssessmentQuestionsId",
                value: 31L);

            migrationBuilder.UpdateData(
                table: "Validators",
                keyColumn: "Id",
                keyValue: 32L,
                column: "QuickAssessmentQuestionsId",
                value: 32L);

            migrationBuilder.UpdateData(
                table: "Validators",
                keyColumn: "Id",
                keyValue: 34L,
                column: "QuickAssessmentQuestionsId",
                value: 35L);
        }
    }
}
