using Microsoft.EntityFrameworkCore.Migrations;

namespace HealthWare.ActiveASSIST.Repositories.Migrations
{
    public partial class UpdatedPermissionsSeedData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Permission",
                keyColumn: "Id",
                keyValue: 1L,
                column: "Name",
                value: "ViewAddress");

            migrationBuilder.UpdateData(
                table: "Permission",
                keyColumn: "Id",
                keyValue: 5L,
                column: "Name",
                value: "ViewUser");

            migrationBuilder.UpdateData(
                table: "Permission",
                keyColumn: "Id",
                keyValue: 7L,
                column: "Name",
                value: "ViewPatientDashboard");

            migrationBuilder.UpdateData(
                table: "Permission",
                keyColumn: "Id",
                keyValue: 8L,
                column: "Name",
                value: "ViewAdvocateDashboard");

            migrationBuilder.UpdateData(
                table: "Permission",
                keyColumn: "Id",
                keyValue: 11L,
                column: "Name",
                value: "ViewReviewNotes");

            migrationBuilder.UpdateData(
                table: "Permission",
                keyColumn: "Id",
                keyValue: 13L,
                column: "Name",
                value: "ViewPatient");

            migrationBuilder.UpdateData(
                table: "Permission",
                keyColumn: "Id",
                keyValue: 16L,
                column: "Name",
                value: "ViewGuarantor");

            migrationBuilder.UpdateData(
                table: "Permission",
                keyColumn: "Id",
                keyValue: 19L,
                column: "Name",
                value: "ViewContactPreference");

            migrationBuilder.UpdateData(
                table: "Permission",
                keyColumn: "Id",
                keyValue: 22L,
                column: "Name",
                value: "CreateAssessmentByAdvocate");

            migrationBuilder.UpdateData(
                table: "Permission",
                keyColumn: "Id",
                keyValue: 23L,
                column: "Name",
                value: "ViewAssessment");

            migrationBuilder.UpdateData(
                table: "Permission",
                keyColumn: "Id",
                keyValue: 24L,
                column: "Name",
                value: "CreateAssessment");

            migrationBuilder.UpdateData(
                table: "Permission",
                keyColumn: "Id",
                keyValue: 25L,
                column: "Name",
                value: "UpdateAssessment");

            migrationBuilder.UpdateData(
                table: "Permission",
                keyColumn: "Id",
                keyValue: 26L,
                column: "Name",
                value: "DeleteAssessment");

            migrationBuilder.UpdateData(
                table: "Permission",
                keyColumn: "Id",
                keyValue: 27L,
                column: "Name",
                value: "CreateAccount");

            migrationBuilder.UpdateData(
                table: "Permission",
                keyColumn: "Id",
                keyValue: 28L,
                column: "Name",
                value: "ViewAccount");

            migrationBuilder.UpdateData(
                table: "Permission",
                keyColumn: "Id",
                keyValue: 29L,
                column: "Name",
                value: "ViewProgram");

            migrationBuilder.UpdateData(
                table: "Permission",
                keyColumn: "Id",
                keyValue: 30L,
                column: "Name",
                value: "CreateProgram");

            migrationBuilder.UpdateData(
                table: "Permission",
                keyColumn: "Id",
                keyValue: 31L,
                column: "Name",
                value: "DeleteProgram");

            migrationBuilder.UpdateData(
                table: "Permission",
                keyColumn: "Id",
                keyValue: 32L,
                column: "Name",
                value: "UpdateProgram");

            migrationBuilder.UpdateData(
                table: "Permission",
                keyColumn: "Id",
                keyValue: 33L,
                column: "Name",
                value: "UpdateProfile");

            migrationBuilder.UpdateData(
                table: "Permission",
                keyColumn: "Id",
                keyValue: 34L,
                column: "Name",
                value: "ViewProfile");

            migrationBuilder.UpdateData(
                table: "Permission",
                keyColumn: "Id",
                keyValue: 35L,
                column: "Name",
                value: "CreateProfile");

            migrationBuilder.UpdateData(
                table: "Permission",
                keyColumn: "Id",
                keyValue: 36L,
                column: "Name",
                value: "DeleteProfile");

            migrationBuilder.UpdateData(
                table: "Permission",
                keyColumn: "Id",
                keyValue: 37L,
                column: "Name",
                value: "ViewPatientSSN");

            migrationBuilder.UpdateData(
                table: "Permission",
                keyColumn: "Id",
                keyValue: 38L,
                column: "Name",
                value: "ViewPaymentOptions");

            migrationBuilder.UpdateData(
                table: "Permission",
                keyColumn: "Id",
                keyValue: 39L,
                column: "Name",
                value: "ViewGeneralInformation");

            migrationBuilder.UpdateData(
                table: "Permission",
                keyColumn: "Id",
                keyValue: 40L,
                column: "Name",
                value: "ViewInsuranceCoverage");

            migrationBuilder.UpdateData(
                table: "Permission",
                keyColumn: "Id",
                keyValue: 41L,
                column: "Name",
                value: "ViewPatientDemographics");

            migrationBuilder.UpdateData(
                table: "Permission",
                keyColumn: "Id",
                keyValue: 42L,
                column: "Name",
                value: "ViewCitizenshipStatus");

            migrationBuilder.UpdateData(
                table: "Permission",
                keyColumn: "Id",
                keyValue: 43L,
                column: "Name",
                value: "ViewResidentialInformation");

            migrationBuilder.UpdateData(
                table: "Permission",
                keyColumn: "Id",
                keyValue: 44L,
                column: "Name",
                value: "ViewHouseHoldMember");

            migrationBuilder.UpdateData(
                table: "Permission",
                keyColumn: "Id",
                keyValue: 45L,
                column: "Name",
                value: "ViewHouseholdIncomeResource");

            migrationBuilder.UpdateData(
                table: "Permission",
                keyColumn: "Id",
                keyValue: 46L,
                column: "Name",
                value: "AdvocateQuickAssessment");

            migrationBuilder.UpdateData(
                table: "Permission",
                keyColumn: "Id",
                keyValue: 47L,
                column: "Name",
                value: "CreateDynamicAssessment");

            migrationBuilder.UpdateData(
                table: "Permission",
                keyColumn: "Id",
                keyValue: 48L,
                column: "Name",
                value: "CreatePatientAccount");

            migrationBuilder.UpdateData(
                table: "Permission",
                keyColumn: "Id",
                keyValue: 49L,
                column: "Name",
                value: "ViewComponentQuickAssessment");

            migrationBuilder.UpdateData(
                table: "Permission",
                keyColumn: "Id",
                keyValue: 50L,
                column: "Name",
                value: "ViewComponentPersonal");

            migrationBuilder.UpdateData(
                table: "Permission",
                keyColumn: "Id",
                keyValue: 51L,
                column: "Name",
                value: "ViewComponentGuarantor");

            migrationBuilder.UpdateData(
                table: "Permission",
                keyColumn: "Id",
                keyValue: 52L,
                column: "Name",
                value: "ViewComponentContactPreference");

            migrationBuilder.UpdateData(
                table: "Permission",
                keyColumn: "Id",
                keyValue: 53L,
                column: "Name",
                value: "ViewComponentHouseHold");

            migrationBuilder.UpdateData(
                table: "Permission",
                keyColumn: "Id",
                keyValue: 54L,
                column: "Name",
                value: "ViewComponentPrograms");

            migrationBuilder.UpdateData(
                table: "Permission",
                keyColumn: "Id",
                keyValue: 55L,
                column: "Name",
                value: "ViewComponentForms");

            migrationBuilder.UpdateData(
                table: "Permission",
                keyColumn: "Id",
                keyValue: 56L,
                column: "Name",
                value: "ViewComponentVerification");

            migrationBuilder.UpdateData(
                table: "Permission",
                keyColumn: "Id",
                keyValue: 57L,
                column: "Name",
                value: "ViewComponentApplicationForms");

            migrationBuilder.UpdateData(
                table: "Permission",
                keyColumn: "Id",
                keyValue: 58L,
                column: "Name",
                value: "ViewComponentPersonalBasicInfo");

            migrationBuilder.UpdateData(
                table: "Permission",
                keyColumn: "Id",
                keyValue: 59L,
                column: "Name",
                value: "ViewComponentPersonalHomeAddress");

            migrationBuilder.UpdateData(
                table: "Permission",
                keyColumn: "Id",
                keyValue: 60L,
                column: "Name",
                value: "ViewComponentPersonalWorkAddress");

            migrationBuilder.UpdateData(
                table: "Permission",
                keyColumn: "Id",
                keyValue: 61L,
                column: "Name",
                value: "ViewComponentGuarantorBasicInfo");

            migrationBuilder.UpdateData(
                table: "Permission",
                keyColumn: "Id",
                keyValue: 62L,
                column: "Name",
                value: "ViewComponentGuarantorHomeAddress");

            migrationBuilder.UpdateData(
                table: "Permission",
                keyColumn: "Id",
                keyValue: 63L,
                column: "Name",
                value: "ViewComponentGuarantorWorkAddress");

            migrationBuilder.UpdateData(
                table: "Permission",
                keyColumn: "Id",
                keyValue: 64L,
                column: "Name",
                value: "ViewComponentHouseHoldMemberList");

            migrationBuilder.UpdateData(
                table: "Permission",
                keyColumn: "Id",
                keyValue: 65L,
                column: "Name",
                value: "ViewComponentEditHouseHoldMember");

            migrationBuilder.UpdateData(
                table: "Permission",
                keyColumn: "Id",
                keyValue: 66L,
                column: "Name",
                value: "ViewProgramsInformation");

            migrationBuilder.UpdateData(
                table: "Permission",
                keyColumn: "Id",
                keyValue: 67L,
                column: "Name",
                value: "ViewComponentReviewNotes");

            migrationBuilder.UpdateData(
                table: "Permission",
                keyColumn: "Id",
                keyValue: 68L,
                column: "Name",
                value: "ViewComponentEmailVerification");

            migrationBuilder.UpdateData(
                table: "Permission",
                keyColumn: "Id",
                keyValue: 69L,
                column: "Name",
                value: "ViewComponentCellVerification");

            migrationBuilder.UpdateData(
                table: "Permission",
                keyColumn: "Id",
                keyValue: 70L,
                column: "Name",
                value: "ViewComponentIdVerification");

            migrationBuilder.UpdateData(
                table: "Permission",
                keyColumn: "Id",
                keyValue: 71L,
                column: "Name",
                value: "ViewComponentAddressVerification");

            migrationBuilder.UpdateData(
                table: "Permission",
                keyColumn: "Id",
                keyValue: 72L,
                column: "Name",
                value: "ViewComponentIncomeVerification");

            migrationBuilder.UpdateData(
                table: "Permission",
                keyColumn: "Id",
                keyValue: 73L,
                column: "Name",
                value: "ViewComponentOtherDocumentation");

            migrationBuilder.UpdateData(
                table: "Permission",
                keyColumn: "Id",
                keyValue: 74L,
                column: "Name",
                value: "EditQuickAssessmentResult");

            migrationBuilder.UpdateData(
                table: "Permission",
                keyColumn: "Id",
                keyValue: 75L,
                column: "Name",
                value: "ViewEsignAssessment");

            migrationBuilder.UpdateData(
                table: "Permission",
                keyColumn: "Id",
                keyValue: 76L,
                column: "Name",
                value: "ViewShareAssessment");

            migrationBuilder.UpdateData(
                table: "Permission",
                keyColumn: "Id",
                keyValue: 77L,
                column: "Name",
                value: "ViewDownloadAssessment");

            migrationBuilder.UpdateData(
                table: "Permission",
                keyColumn: "Id",
                keyValue: 78L,
                column: "Name",
                value: "ViewUploadAssessment");

            migrationBuilder.UpdateData(
                table: "Permission",
                keyColumn: "Id",
                keyValue: 79L,
                column: "Name",
                value: "EditTheme");

            migrationBuilder.InsertData(
                table: "Permission",
                columns: new[] { "Id", "Name" },
                values: new object[] { 80L, "UpdatePassword" });

            migrationBuilder.UpdateData(
                table: "RolesPermissions",
                keyColumn: "Id",
                keyValue: 32L,
                column: "RoleId",
                value: 2L);

            migrationBuilder.InsertData(
                table: "RolesPermissions",
                columns: new[] { "Id", "PermissionId", "RoleId" },
                values: new object[,]
                {
                    { 115L, 34L, 2L },
                    { 114L, 34L, 1L },
                    { 113L, 22L, 2L }
                });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: -1L,
                column: "Password",
                value: "$2a$12$DxoIJE0jbEhRqWPN6tAOM.BDGEbOZenIF76EZDhOs1jG1HJ1ucDzi");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1L,
                column: "Password",
                value: "$2a$12$SBMDw9FafF8GFGnjOaO0CuwJ23DDKbV6B8F06Utn3KMtkCW1xhgy.");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2L,
                column: "Password",
                value: "$2a$12$SH.Uj8bAKX7gejcwZlZQkebWceUMEb8T5bSmGFERgwE9j5.XRnlYG");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3L,
                column: "Password",
                value: "$2a$12$DIDHRG9jMfibuxTV3xZQIOc5fMfLHwa/1KPTtOwCE.MXUsi9rHAGS");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 4L,
                column: "Password",
                value: "$2a$12$Je/OZauQA1qgO/RY4jGclOmTSU04TCG9J/7f6c8KeZCmt.bcK6pMS");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 5L,
                column: "Password",
                value: "$2a$12$4CCDbKqBkIBsRO6JGvUmjuSIT786Dct1tsebqqTqh.5BVf10KeGWO");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 6L,
                column: "Password",
                value: "$2a$12$xmGuQntSaZoT6bsmw20BBewpxxQHw2iiv09SUGkNYUMYTOncLe4g2");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Permission",
                keyColumn: "Id",
                keyValue: 80L);

            migrationBuilder.DeleteData(
                table: "RolesPermissions",
                keyColumn: "Id",
                keyValue: 113L);

            migrationBuilder.DeleteData(
                table: "RolesPermissions",
                keyColumn: "Id",
                keyValue: 114L);

            migrationBuilder.DeleteData(
                table: "RolesPermissions",
                keyColumn: "Id",
                keyValue: 115L);

            migrationBuilder.UpdateData(
                table: "Permission",
                keyColumn: "Id",
                keyValue: 1L,
                column: "Name",
                value: "ReadAddress");

            migrationBuilder.UpdateData(
                table: "Permission",
                keyColumn: "Id",
                keyValue: 5L,
                column: "Name",
                value: "ReadUser");

            migrationBuilder.UpdateData(
                table: "Permission",
                keyColumn: "Id",
                keyValue: 7L,
                column: "Name",
                value: "ReadPatientDashboard");

            migrationBuilder.UpdateData(
                table: "Permission",
                keyColumn: "Id",
                keyValue: 8L,
                column: "Name",
                value: "ReadAdvocateDashboard");

            migrationBuilder.UpdateData(
                table: "Permission",
                keyColumn: "Id",
                keyValue: 11L,
                column: "Name",
                value: "ReadReviewNotes");

            migrationBuilder.UpdateData(
                table: "Permission",
                keyColumn: "Id",
                keyValue: 13L,
                column: "Name",
                value: "ReadPatient");

            migrationBuilder.UpdateData(
                table: "Permission",
                keyColumn: "Id",
                keyValue: 16L,
                column: "Name",
                value: "ReadGuarantor");

            migrationBuilder.UpdateData(
                table: "Permission",
                keyColumn: "Id",
                keyValue: 19L,
                column: "Name",
                value: "ReadContactPreference");

            migrationBuilder.UpdateData(
                table: "Permission",
                keyColumn: "Id",
                keyValue: 22L,
                column: "Name",
                value: "ReadAssessment");

            migrationBuilder.UpdateData(
                table: "Permission",
                keyColumn: "Id",
                keyValue: 23L,
                column: "Name",
                value: "CreateAssessment");

            migrationBuilder.UpdateData(
                table: "Permission",
                keyColumn: "Id",
                keyValue: 24L,
                column: "Name",
                value: "UpdateAssessment");

            migrationBuilder.UpdateData(
                table: "Permission",
                keyColumn: "Id",
                keyValue: 25L,
                column: "Name",
                value: "DeleteAssessment");

            migrationBuilder.UpdateData(
                table: "Permission",
                keyColumn: "Id",
                keyValue: 26L,
                column: "Name",
                value: "CreateAccount");

            migrationBuilder.UpdateData(
                table: "Permission",
                keyColumn: "Id",
                keyValue: 27L,
                column: "Name",
                value: "ViewAccount");

            migrationBuilder.UpdateData(
                table: "Permission",
                keyColumn: "Id",
                keyValue: 28L,
                column: "Name",
                value: "ViewProgram");

            migrationBuilder.UpdateData(
                table: "Permission",
                keyColumn: "Id",
                keyValue: 29L,
                column: "Name",
                value: "CreateProgram");

            migrationBuilder.UpdateData(
                table: "Permission",
                keyColumn: "Id",
                keyValue: 30L,
                column: "Name",
                value: "DeleteProgram");

            migrationBuilder.UpdateData(
                table: "Permission",
                keyColumn: "Id",
                keyValue: 31L,
                column: "Name",
                value: "UpdateProgram");

            migrationBuilder.UpdateData(
                table: "Permission",
                keyColumn: "Id",
                keyValue: 32L,
                column: "Name",
                value: "UpdateProfile");

            migrationBuilder.UpdateData(
                table: "Permission",
                keyColumn: "Id",
                keyValue: 33L,
                column: "Name",
                value: "ViewProfile");

            migrationBuilder.UpdateData(
                table: "Permission",
                keyColumn: "Id",
                keyValue: 34L,
                column: "Name",
                value: "CreateProfile");

            migrationBuilder.UpdateData(
                table: "Permission",
                keyColumn: "Id",
                keyValue: 35L,
                column: "Name",
                value: "DeleteProfile");

            migrationBuilder.UpdateData(
                table: "Permission",
                keyColumn: "Id",
                keyValue: 36L,
                column: "Name",
                value: "ViewPatientSSN");

            migrationBuilder.UpdateData(
                table: "Permission",
                keyColumn: "Id",
                keyValue: 37L,
                column: "Name",
                value: "ViewPaymentOptions");

            migrationBuilder.UpdateData(
                table: "Permission",
                keyColumn: "Id",
                keyValue: 38L,
                column: "Name",
                value: "ViewGeneralInformation");

            migrationBuilder.UpdateData(
                table: "Permission",
                keyColumn: "Id",
                keyValue: 39L,
                column: "Name",
                value: "ViewInsuranceCoverage");

            migrationBuilder.UpdateData(
                table: "Permission",
                keyColumn: "Id",
                keyValue: 40L,
                column: "Name",
                value: "ViewPatientDemographics");

            migrationBuilder.UpdateData(
                table: "Permission",
                keyColumn: "Id",
                keyValue: 41L,
                column: "Name",
                value: "ViewCitizenshipStatus");

            migrationBuilder.UpdateData(
                table: "Permission",
                keyColumn: "Id",
                keyValue: 42L,
                column: "Name",
                value: "ViewResidentialInformation");

            migrationBuilder.UpdateData(
                table: "Permission",
                keyColumn: "Id",
                keyValue: 43L,
                column: "Name",
                value: "ViewHouseHoldMember");

            migrationBuilder.UpdateData(
                table: "Permission",
                keyColumn: "Id",
                keyValue: 44L,
                column: "Name",
                value: "ViewHouseholdIncomeResource");

            migrationBuilder.UpdateData(
                table: "Permission",
                keyColumn: "Id",
                keyValue: 45L,
                column: "Name",
                value: "AdvocateQuickAssessment");

            migrationBuilder.UpdateData(
                table: "Permission",
                keyColumn: "Id",
                keyValue: 46L,
                column: "Name",
                value: "CreateDynamicAssessment");

            migrationBuilder.UpdateData(
                table: "Permission",
                keyColumn: "Id",
                keyValue: 47L,
                column: "Name",
                value: "CreatePatientAccount");

            migrationBuilder.UpdateData(
                table: "Permission",
                keyColumn: "Id",
                keyValue: 48L,
                column: "Name",
                value: "ViewComponentQuickAssessment");

            migrationBuilder.UpdateData(
                table: "Permission",
                keyColumn: "Id",
                keyValue: 49L,
                column: "Name",
                value: "ViewComponentPersonal");

            migrationBuilder.UpdateData(
                table: "Permission",
                keyColumn: "Id",
                keyValue: 50L,
                column: "Name",
                value: "ViewComponentGuarantor");

            migrationBuilder.UpdateData(
                table: "Permission",
                keyColumn: "Id",
                keyValue: 51L,
                column: "Name",
                value: "ViewComponentContactPreference");

            migrationBuilder.UpdateData(
                table: "Permission",
                keyColumn: "Id",
                keyValue: 52L,
                column: "Name",
                value: "ViewComponentHouseHold");

            migrationBuilder.UpdateData(
                table: "Permission",
                keyColumn: "Id",
                keyValue: 53L,
                column: "Name",
                value: "ViewComponentPrograms");

            migrationBuilder.UpdateData(
                table: "Permission",
                keyColumn: "Id",
                keyValue: 54L,
                column: "Name",
                value: "ViewComponentForms");

            migrationBuilder.UpdateData(
                table: "Permission",
                keyColumn: "Id",
                keyValue: 55L,
                column: "Name",
                value: "ViewComponentVerification");

            migrationBuilder.UpdateData(
                table: "Permission",
                keyColumn: "Id",
                keyValue: 56L,
                column: "Name",
                value: "ViewComponentApplicationForms");

            migrationBuilder.UpdateData(
                table: "Permission",
                keyColumn: "Id",
                keyValue: 57L,
                column: "Name",
                value: "ViewComponentPersonalBasicInfo");

            migrationBuilder.UpdateData(
                table: "Permission",
                keyColumn: "Id",
                keyValue: 58L,
                column: "Name",
                value: "ViewComponentPersonalHomeAddress");

            migrationBuilder.UpdateData(
                table: "Permission",
                keyColumn: "Id",
                keyValue: 59L,
                column: "Name",
                value: "ViewComponentPersonalWorkAddress");

            migrationBuilder.UpdateData(
                table: "Permission",
                keyColumn: "Id",
                keyValue: 60L,
                column: "Name",
                value: "ViewComponentGuarantorBasicInfo");

            migrationBuilder.UpdateData(
                table: "Permission",
                keyColumn: "Id",
                keyValue: 61L,
                column: "Name",
                value: "ViewComponentGuarantorHomeAddress");

            migrationBuilder.UpdateData(
                table: "Permission",
                keyColumn: "Id",
                keyValue: 62L,
                column: "Name",
                value: "ViewComponentGuarantorWorkAddress");

            migrationBuilder.UpdateData(
                table: "Permission",
                keyColumn: "Id",
                keyValue: 63L,
                column: "Name",
                value: "ViewComponentHouseHoldMemberList");

            migrationBuilder.UpdateData(
                table: "Permission",
                keyColumn: "Id",
                keyValue: 64L,
                column: "Name",
                value: "ViewComponentEditHouseHoldMember");

            migrationBuilder.UpdateData(
                table: "Permission",
                keyColumn: "Id",
                keyValue: 65L,
                column: "Name",
                value: "ViewProgramsInformation");

            migrationBuilder.UpdateData(
                table: "Permission",
                keyColumn: "Id",
                keyValue: 66L,
                column: "Name",
                value: "ViewComponentReviewNotes");

            migrationBuilder.UpdateData(
                table: "Permission",
                keyColumn: "Id",
                keyValue: 67L,
                column: "Name",
                value: "ViewComponentEmailVerification");

            migrationBuilder.UpdateData(
                table: "Permission",
                keyColumn: "Id",
                keyValue: 68L,
                column: "Name",
                value: "ViewComponentCellVerification");

            migrationBuilder.UpdateData(
                table: "Permission",
                keyColumn: "Id",
                keyValue: 69L,
                column: "Name",
                value: "ViewComponentIdVerification");

            migrationBuilder.UpdateData(
                table: "Permission",
                keyColumn: "Id",
                keyValue: 70L,
                column: "Name",
                value: "ViewComponentAddressVerification");

            migrationBuilder.UpdateData(
                table: "Permission",
                keyColumn: "Id",
                keyValue: 71L,
                column: "Name",
                value: "ViewComponentIncomeVerification");

            migrationBuilder.UpdateData(
                table: "Permission",
                keyColumn: "Id",
                keyValue: 72L,
                column: "Name",
                value: "ViewComponentOtherDocumentation");

            migrationBuilder.UpdateData(
                table: "Permission",
                keyColumn: "Id",
                keyValue: 73L,
                column: "Name",
                value: "EditQuickAssessmentResult");

            migrationBuilder.UpdateData(
                table: "Permission",
                keyColumn: "Id",
                keyValue: 74L,
                column: "Name",
                value: "ViewEsignAssessment");

            migrationBuilder.UpdateData(
                table: "Permission",
                keyColumn: "Id",
                keyValue: 75L,
                column: "Name",
                value: "ViewShareAssessment");

            migrationBuilder.UpdateData(
                table: "Permission",
                keyColumn: "Id",
                keyValue: 76L,
                column: "Name",
                value: "ViewDownloadAssessment");

            migrationBuilder.UpdateData(
                table: "Permission",
                keyColumn: "Id",
                keyValue: 77L,
                column: "Name",
                value: "ViewUploadAssessment");

            migrationBuilder.UpdateData(
                table: "Permission",
                keyColumn: "Id",
                keyValue: 78L,
                column: "Name",
                value: "EditTheme");

            migrationBuilder.UpdateData(
                table: "Permission",
                keyColumn: "Id",
                keyValue: 79L,
                column: "Name",
                value: "UpdatePassword");

            migrationBuilder.UpdateData(
                table: "RolesPermissions",
                keyColumn: "Id",
                keyValue: 32L,
                column: "RoleId",
                value: 1L);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: -1L,
                column: "Password",
                value: "$2a$12$avTc7PB0x2jE.cWRe5m.dOz0jmTMV/cLCEFOYnywpKimLc1hfQQVm");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1L,
                column: "Password",
                value: "$2a$12$2BdY1UQcT30LjDNLytzYE.GUJjwQgLSBXKsmT47m4fJNounUoYK1u");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2L,
                column: "Password",
                value: "$2a$12$1jT7PbuUvXda.6YxqvkqVuL6..7nlx2BYv.SuLDdnVj7l6uG35TAG");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3L,
                column: "Password",
                value: "$2a$12$A9SuGaDn3OPSNFQLHi.b/usePJTre1zdmwyaQtQlDszmNRCISVVHy");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 4L,
                column: "Password",
                value: "$2a$12$aqW8LBQqzXXbbp3nU5LoH.x32oO51jBtH6gGjw4Gf3MWvIIVEEjFO");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 5L,
                column: "Password",
                value: "$2a$12$3zAJAY5dkTPCOeDSD/pD5uX2kt355dpOhmLRK1nD4JnNXAfvN6P7u");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 6L,
                column: "Password",
                value: "$2a$12$Ignrti/oNTh.EdAox.gDoOZQZflbu7Zge6aWj8n2fGeZ2w5G.wtSu");
        }
    }
}
