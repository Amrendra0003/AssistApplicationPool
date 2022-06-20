using Microsoft.EntityFrameworkCore.Migrations;

namespace HealthWare.ActiveASSIST.Repositories.Migrations
{
    public partial class quickAssessmentQuestions : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "MainUser",
                keyColumn: "Id",
                keyValue: -1L,
                column: "Password",
                value: "$2a$12$3Jsj/hh5beYeLVHlVIjNhuiPQRyqarxGVm4cXYC7AbHRKYIft.kVG");

            migrationBuilder.UpdateData(
                table: "MainUser",
                keyColumn: "Id",
                keyValue: 1L,
                column: "Password",
                value: "$2a$12$X7mf1Zs0HrFrV71FQ4oymeLRkfWcSwBPBesjjORPo4fVAOaeVLR8e");

            migrationBuilder.UpdateData(
                table: "MainUser",
                keyColumn: "Id",
                keyValue: 2L,
                column: "Password",
                value: "$2a$12$ho7iGGy0pKgJVrGa05HYIOKHxXOnXKWGviC0/boAwigV4Lmwo.HxW");

            migrationBuilder.UpdateData(
                table: "MainUser",
                keyColumn: "Id",
                keyValue: 3L,
                column: "Password",
                value: "$2a$12$ABWVDwu.gPmOmQh1K5BA8eVQ5YzfVF4ZebKR/YwdJIWp47DAUv3R6");

            migrationBuilder.UpdateData(
                table: "MainUser",
                keyColumn: "Id",
                keyValue: 4L,
                column: "Password",
                value: "$2a$12$pSWBmM31.V7zlp8BepiQwOiN0ap48ECh9v3DV2Wo2sB4gCv.zQst6");

            migrationBuilder.UpdateData(
                table: "MainUser",
                keyColumn: "Id",
                keyValue: 5L,
                column: "Password",
                value: "$2a$12$eT.BHrBqf6iqg7evHX1asOVkcilAwL.Phhzocqb3cxPlP/KKgU316");

            migrationBuilder.UpdateData(
                table: "MainUser",
                keyColumn: "Id",
                keyValue: 6L,
                column: "Password",
                value: "$2a$12$PxoUyYyy44UkYINfKqXPQ.5zPat4ZHAEauRZjwrgZDNCJHnUaFSfq");

            migrationBuilder.UpdateData(
                table: "QuickAssessmentQuestions",
                keyColumn: "Id",
                keyValue: 2L,
                column: "ScreenHeaderOthersLabel",
                value: "Please enter patient's Zip code.");

            migrationBuilder.UpdateData(
                table: "QuickAssessmentQuestions",
                keyColumn: "Id",
                keyValue: 24L,
                column: "OthersLabel",
                value: "Is anyone in patient's household employed?");

            migrationBuilder.UpdateData(
                table: "QuickAssessmentQuestions",
                keyColumn: "Id",
                keyValue: 25L,
                column: "ScreenHeaderOthersLabel",
                value: "Does the patient currently receive any of the following?");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
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
                keyValue: 2L,
                column: "ScreenHeaderOthersLabel",
                value: "Please enter patients Zip code.");

            migrationBuilder.UpdateData(
                table: "QuickAssessmentQuestions",
                keyColumn: "Id",
                keyValue: 24L,
                column: "OthersLabel",
                value: "Is anyone in your household employed?");

            migrationBuilder.UpdateData(
                table: "QuickAssessmentQuestions",
                keyColumn: "Id",
                keyValue: 25L,
                column: "ScreenHeaderOthersLabel",
                value: "Do you currently receive any of the following?");
        }
    }
}
