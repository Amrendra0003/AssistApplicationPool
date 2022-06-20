using Microsoft.EntityFrameworkCore.Migrations;

namespace HealthWare.ActiveASSIST.Repositories.Migrations
{
    public partial class ScreenTextUpdated : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "DynamicScreens",
                keyColumn: "Id",
                keyValue: 7L,
                column: "LeftContent",
                value: "Let us know the total income & resources of your household.  Please include all sources of income and the frequency that you receive the income.");

            migrationBuilder.UpdateData(
                table: "MainUser",
                keyColumn: "Id",
                keyValue: -1L,
                column: "Password",
                value: "$2a$12$Zm4ivUjZ3bkMFb3WTDM50.J8H4JkmjrOw518qtLqhW/EtVu6fZh4G");

            migrationBuilder.UpdateData(
                table: "MainUser",
                keyColumn: "Id",
                keyValue: 1L,
                column: "Password",
                value: "$2a$12$j4PwAI/3fLVvDz169cy1DuC.UMNQi7sIzxIMn4S66157rWLNvdrze");

            migrationBuilder.UpdateData(
                table: "MainUser",
                keyColumn: "Id",
                keyValue: 2L,
                column: "Password",
                value: "$2a$12$bbQ6.ZAie0wyNiMdrSg2eORXiahtGKckp.LHx2PHHc0qSoz9aBNoW");

            migrationBuilder.UpdateData(
                table: "MainUser",
                keyColumn: "Id",
                keyValue: 3L,
                column: "Password",
                value: "$2a$12$7pEh0jqnXdwNenQaUTcD7u39Myt.d9Stbe3Ws8Q8QYJT8SBFTmvCi");

            migrationBuilder.UpdateData(
                table: "MainUser",
                keyColumn: "Id",
                keyValue: 4L,
                column: "Password",
                value: "$2a$12$hgT8uyvIdrl45evEv4WVqOaF0UTpht6bnC4a303xO22OaQnXn2E36");

            migrationBuilder.UpdateData(
                table: "MainUser",
                keyColumn: "Id",
                keyValue: 5L,
                column: "Password",
                value: "$2a$12$UdukUVJ1xhKJoOacSFXTQ.Uipu3k9XIHt/4On8Srt2Yi6o64ahI8G");

            migrationBuilder.UpdateData(
                table: "MainUser",
                keyColumn: "Id",
                keyValue: 6L,
                column: "Password",
                value: "$2a$12$DU2ggRGZ6658msYZm7J2te8bWXWga4R8mjA1LXWuJyHGIZ.ZW16Ue");

            migrationBuilder.UpdateData(
                table: "MainUser",
                keyColumn: "Id",
                keyValue: 7L,
                column: "Password",
                value: "$2a$12$7IYmGQG.YS1nHiZ82Uq/T.aZunisOYY1Bjxhc.PhtUA2rtIXX0e7q");

            migrationBuilder.UpdateData(
                table: "MainUser",
                keyColumn: "Id",
                keyValue: 8L,
                column: "Password",
                value: "$2a$12$oQXNmC5oF9JbSJACEk9ZtuScDPj2.cwdgbd3dJsB8r4hel70nKcdG");

            migrationBuilder.UpdateData(
                table: "QuickAssessmentQuestions",
                keyColumn: "Id",
                keyValue: 24L,
                columns: new[] { "OthersLabel", "PatientLabel" },
                values: new object[] { "Is anyone else in patient's household employed?", "Is anyone else in your household employed?" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "DynamicScreens",
                keyColumn: "Id",
                keyValue: 7L,
                column: "LeftContent",
                value: "Let us know the total income & resources of your household.  Please includes all sources of income and the frequency that you receive the income.");

            migrationBuilder.UpdateData(
                table: "MainUser",
                keyColumn: "Id",
                keyValue: -1L,
                column: "Password",
                value: "$2a$12$ykMKtsIXRYTR6r6DEbk8AOprJjXf1Kbsj8vfKSCNOH0z4WNXHGkqC");

            migrationBuilder.UpdateData(
                table: "MainUser",
                keyColumn: "Id",
                keyValue: 1L,
                column: "Password",
                value: "$2a$12$jrxy7hJAQu4Nakbz/Tu9eOCotx8DaJgwguhQjKdHrhBUiykXlnGvG");

            migrationBuilder.UpdateData(
                table: "MainUser",
                keyColumn: "Id",
                keyValue: 2L,
                column: "Password",
                value: "$2a$12$lqG0uKh7QKnr32WipUTFvuJuv6oh154qhtEv1nFxFkGAq6s28bDqS");

            migrationBuilder.UpdateData(
                table: "MainUser",
                keyColumn: "Id",
                keyValue: 3L,
                column: "Password",
                value: "$2a$12$Bn3IBX/1kwcm8pqnjHgG6.IipF.KUkLjCHkCJkwvktBd9o9lKV6WK");

            migrationBuilder.UpdateData(
                table: "MainUser",
                keyColumn: "Id",
                keyValue: 4L,
                column: "Password",
                value: "$2a$12$MA2/FG.rnpGHtWL0QUxB3u2sjZ4vZ3yw3pEYDYROdz2ZAyzOp9Ove");

            migrationBuilder.UpdateData(
                table: "MainUser",
                keyColumn: "Id",
                keyValue: 5L,
                column: "Password",
                value: "$2a$12$ObMDMUfat46..49hiMR67OLW6UUS5q242QiTUSRyJ5gFV1S2MSs/.");

            migrationBuilder.UpdateData(
                table: "MainUser",
                keyColumn: "Id",
                keyValue: 6L,
                column: "Password",
                value: "$2a$12$fPImBtkUfmHqiMayLY.zmOcwuMdLpyRYOEPowNHI.7/XSfx4x1/iS");

            migrationBuilder.UpdateData(
                table: "MainUser",
                keyColumn: "Id",
                keyValue: 7L,
                column: "Password",
                value: "$2a$12$4zx.8ATdP8DHOk/vNAeW0OtrLKCs0n8ACaRZMp6zMyfjPywSn.Svq");

            migrationBuilder.UpdateData(
                table: "MainUser",
                keyColumn: "Id",
                keyValue: 8L,
                column: "Password",
                value: "$2a$12$hQRLjkxQfz.Ydq5JlC9Zq.4dGSxjLCoAR4KwZlBvecA.2gq/4PwNu");

            migrationBuilder.UpdateData(
                table: "QuickAssessmentQuestions",
                keyColumn: "Id",
                keyValue: 24L,
                columns: new[] { "OthersLabel", "PatientLabel" },
                values: new object[] { "Is anyone in patient's household employed?", "Is anyone in your household employed?" });
        }
    }
}
