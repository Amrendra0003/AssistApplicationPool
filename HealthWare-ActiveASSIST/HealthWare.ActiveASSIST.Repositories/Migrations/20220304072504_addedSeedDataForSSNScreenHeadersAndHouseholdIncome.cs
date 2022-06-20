using Microsoft.EntityFrameworkCore.Migrations;

namespace HealthWare.ActiveASSIST.Repositories.Migrations
{
    public partial class addedSeedDataForSSNScreenHeadersAndHouseholdIncome : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "MainUser",
                keyColumn: "Id",
                keyValue: -1L,
                column: "Password",
                value: "$2a$12$/ZtmKzJtn/Ug/Fwf4wNqyuZeoJFwyE2C26ImIOoDqMkOrsjjV6MgW");

            migrationBuilder.UpdateData(
                table: "MainUser",
                keyColumn: "Id",
                keyValue: 1L,
                column: "Password",
                value: "$2a$12$lzdPeznVDSv.ydnyb2R7PeZqNRKTvxXlZRLaKXp2iKTC3pvv0vY1.");

            migrationBuilder.UpdateData(
                table: "MainUser",
                keyColumn: "Id",
                keyValue: 2L,
                column: "Password",
                value: "$2a$12$PuDLHbK3p3aydsd3QrpFIeN3FiUa.YECNDeGvOFTteKXDIqWY8bku");

            migrationBuilder.UpdateData(
                table: "MainUser",
                keyColumn: "Id",
                keyValue: 3L,
                column: "Password",
                value: "$2a$12$3zGrZB.fAVcZt69/1TvPV.cAUMPWYhqlDT999Tae8LiAkp1RbeS0.");

            migrationBuilder.UpdateData(
                table: "MainUser",
                keyColumn: "Id",
                keyValue: 4L,
                column: "Password",
                value: "$2a$12$EsbybSpHK3EDyiT5PDLUd.GJEuIBrBnLvcDVkeyitTmERh.UgtTTq");

            migrationBuilder.UpdateData(
                table: "MainUser",
                keyColumn: "Id",
                keyValue: 5L,
                column: "Password",
                value: "$2a$12$QnbmxuY/DpVa0I0NOMHYEep6sVQpw2S1yw3iycKnhYeEsUED1GZn2");

            migrationBuilder.UpdateData(
                table: "MainUser",
                keyColumn: "Id",
                keyValue: 6L,
                column: "Password",
                value: "$2a$12$4GUnmytw4Q1NCpg7FBbFDOWxUe2CdT1XPf6Z1reDcIxuV27SsKiLa");

            migrationBuilder.UpdateData(
                table: "QuickAssessmentQuestions",
                keyColumn: "Id",
                keyValue: 26L,
                columns: new[] { "PatientLabel", "ScreenHeaderPatientLabel" },
                values: new object[] { "Estimated  Household Income", "Enter your household income and resources" });

            migrationBuilder.UpdateData(
                table: "QuickAssessmentQuestions",
                keyColumn: "Id",
                keyValue: 29L,
                column: "ScreenHeaderOthersLabel",
                value: "Please select the options that apply to patient and click on next.");

            migrationBuilder.UpdateData(
                table: "QuickAssessmentQuestions",
                keyColumn: "Id",
                keyValue: 30L,
                column: "ScreenHeaderOthersLabel",
                value: "Do any of the following health conditions apply to patient?");

            migrationBuilder.UpdateData(
                table: "QuickAssessmentQuestions",
                keyColumn: "Id",
                keyValue: 31L,
                column: "ScreenHeaderOthersLabel",
                value: "Select if patient have been injured");

            migrationBuilder.UpdateData(
                table: "QuickAssessmentQuestions",
                keyColumn: "Id",
                keyValue: 33L,
                columns: new[] { "Placeholder", "ScreenHeaderOthersLabel" },
                values: new object[] { "000-00-0000", "Last Step.Please provide patient's SSN" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "MainUser",
                keyColumn: "Id",
                keyValue: -1L,
                column: "Password",
                value: "$2a$12$mG4CqXuaHgNy6HhRLDZ3vO5TU5C8V8aZz1ZnaCzDEILf5Xwc6TBZy");

            migrationBuilder.UpdateData(
                table: "MainUser",
                keyColumn: "Id",
                keyValue: 1L,
                column: "Password",
                value: "$2a$12$TWAuQUUZzVaCkh0fT9tYaOSQjLK07vUhdyEi7798PinQYstzGTjta");

            migrationBuilder.UpdateData(
                table: "MainUser",
                keyColumn: "Id",
                keyValue: 2L,
                column: "Password",
                value: "$2a$12$/.7n2UAWMli82gaaQrhpr.VkuUqNqRNKEv/z6zM4QYIY4k7NzSo8q");

            migrationBuilder.UpdateData(
                table: "MainUser",
                keyColumn: "Id",
                keyValue: 3L,
                column: "Password",
                value: "$2a$12$Ouf3s3K2Xk5rq8efrXh2PumlflPNJdc2OaLJ8WGw5HDHDAdyetXjW");

            migrationBuilder.UpdateData(
                table: "MainUser",
                keyColumn: "Id",
                keyValue: 4L,
                column: "Password",
                value: "$2a$12$u.TakbC.swHB4./Y5EZXoeieXJvZyuQAIyktQu1aiDT99wY/mucBK");

            migrationBuilder.UpdateData(
                table: "MainUser",
                keyColumn: "Id",
                keyValue: 5L,
                column: "Password",
                value: "$2a$12$gkjWC4X2ilF.U5l0Due6oOfIgxTNze0LNo971AaYgmMdk0CEphKLW");

            migrationBuilder.UpdateData(
                table: "MainUser",
                keyColumn: "Id",
                keyValue: 6L,
                column: "Password",
                value: "$2a$12$l8Z2iWfjTe1ORZFHxkxUv./U4MOIRI9hePpu4qsf25LjWjm3du/9e");

            migrationBuilder.UpdateData(
                table: "QuickAssessmentQuestions",
                keyColumn: "Id",
                keyValue: 26L,
                columns: new[] { "PatientLabel", "ScreenHeaderPatientLabel" },
                values: new object[] { "Estimated Household Income", "Enter household income and resources" });

            migrationBuilder.UpdateData(
                table: "QuickAssessmentQuestions",
                keyColumn: "Id",
                keyValue: 29L,
                column: "ScreenHeaderOthersLabel",
                value: "Please select the options that apply to you and click on next.");

            migrationBuilder.UpdateData(
                table: "QuickAssessmentQuestions",
                keyColumn: "Id",
                keyValue: 30L,
                column: "ScreenHeaderOthersLabel",
                value: "Do any of the following health conditions apply to you?");

            migrationBuilder.UpdateData(
                table: "QuickAssessmentQuestions",
                keyColumn: "Id",
                keyValue: 31L,
                column: "ScreenHeaderOthersLabel",
                value: "Select if you have been injured");

            migrationBuilder.UpdateData(
                table: "QuickAssessmentQuestions",
                keyColumn: "Id",
                keyValue: 33L,
                columns: new[] { "Placeholder", "ScreenHeaderOthersLabel" },
                values: new object[] { "SSN", "Last Step.Please provide patient''s SSN" });
        }
    }
}
