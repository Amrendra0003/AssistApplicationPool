using Microsoft.EntityFrameworkCore.Migrations;

namespace HealthWare.ActiveASSIST.Repositories.Migrations
{
    public partial class ssnscreenHeaderLabelchanged : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "MainUser",
                keyColumn: "Id",
                keyValue: -1L,
                column: "Password",
                value: "$2a$12$Uwa4nB1l1mIiA2tVzJw1G.93JQk4ozLpU2IoAIXmiwGFJ9jqdz0kG");

            migrationBuilder.UpdateData(
                table: "MainUser",
                keyColumn: "Id",
                keyValue: 1L,
                column: "Password",
                value: "$2a$12$1CUfOvZ2LOcNwDPDvHV4O.7kr4s4dJvFbQmo6/zdaOfCVbWR6mK9u");

            migrationBuilder.UpdateData(
                table: "MainUser",
                keyColumn: "Id",
                keyValue: 2L,
                column: "Password",
                value: "$2a$12$YYJQEfkv1mWURzJkV.TIhu.kSUlmf4MTScgu0AzhkXokxmbKYeHom");

            migrationBuilder.UpdateData(
                table: "MainUser",
                keyColumn: "Id",
                keyValue: 3L,
                column: "Password",
                value: "$2a$12$/MUkBNWc6XPN6wOD/m3uJu9U5cGiDaF/f7JFpQd16gFf1SZdhf3Oy");

            migrationBuilder.UpdateData(
                table: "MainUser",
                keyColumn: "Id",
                keyValue: 4L,
                column: "Password",
                value: "$2a$12$95SCjFC2H45gFCMzCgGzlOfJAC4dtdLv2u3TGDwUSFHXyeDf5qyna");

            migrationBuilder.UpdateData(
                table: "MainUser",
                keyColumn: "Id",
                keyValue: 5L,
                column: "Password",
                value: "$2a$12$Wx3ZAwm/7n5540FgQdSnguYpGbmw0Mus41gPgdbmyzD/QaKB1hqb2");

            migrationBuilder.UpdateData(
                table: "MainUser",
                keyColumn: "Id",
                keyValue: 6L,
                column: "Password",
                value: "$2a$12$RunZ55pJGktrDyfwoH3E2OxIDyoONq.GLPD4oojsSqzBFDxpZUmPu");

            migrationBuilder.UpdateData(
                table: "QuickAssessmentQuestions",
                keyColumn: "Id",
                keyValue: 32L,
                column: "ScreenHeaderOthersLabel",
                value: "Last Step.Please provide patient''s SSN");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "MainUser",
                keyColumn: "Id",
                keyValue: -1L,
                column: "Password",
                value: "$2a$12$NSR592clDk7oEBDz2MYEU.xEdN/uVHWfIN91VI.TSPwRgi3piT9CW");

            migrationBuilder.UpdateData(
                table: "MainUser",
                keyColumn: "Id",
                keyValue: 1L,
                column: "Password",
                value: "$2a$12$8p/7urKMiH5h1lwvjzylkeTbNWRLrvAY75Q65MMrJAwK3gJq.5E0C");

            migrationBuilder.UpdateData(
                table: "MainUser",
                keyColumn: "Id",
                keyValue: 2L,
                column: "Password",
                value: "$2a$12$/IqOzttJ1xLGWYNURK/rVeNYhAquBJJvjQofhmpRRisMHETkTw0vG");

            migrationBuilder.UpdateData(
                table: "MainUser",
                keyColumn: "Id",
                keyValue: 3L,
                column: "Password",
                value: "$2a$12$EwShq8C9U8.JGithmgyGV.G/cpXj0xJp6tp7XOc89n50PeWLNwHmG");

            migrationBuilder.UpdateData(
                table: "MainUser",
                keyColumn: "Id",
                keyValue: 4L,
                column: "Password",
                value: "$2a$12$5AijkqBo.pEeDeiAMVIxouzh0tqUDHfV6AaIHWvCH75TRvTuhmJNG");

            migrationBuilder.UpdateData(
                table: "MainUser",
                keyColumn: "Id",
                keyValue: 5L,
                column: "Password",
                value: "$2a$12$/BpZguJCSY9FeaIY.I4wS.S44lSai.JgUsIgJ152w8T31m5701H12");

            migrationBuilder.UpdateData(
                table: "MainUser",
                keyColumn: "Id",
                keyValue: 6L,
                column: "Password",
                value: "$2a$12$rcHiiqsESEeWgUzSaDRJ5O8SdPXZsA3.ZrDAnrPNhatyj9qAXAE3G");

            migrationBuilder.UpdateData(
                table: "QuickAssessmentQuestions",
                keyColumn: "Id",
                keyValue: 32L,
                column: "ScreenHeaderOthersLabel",
                value: "Last Step. Please provide patient''s SSN', N'Last Step. Please provide your SSN");
        }
    }
}
