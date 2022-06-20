using Microsoft.EntityFrameworkCore.Migrations;

namespace HealthWare.ActiveASSIST.Repositories.Migrations
{
    public partial class UpdatedQuickAssessQuestion : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "MainUser",
                keyColumn: "Id",
                keyValue: -1L,
                column: "Password",
                value: "$2a$12$.vMHvY.lM2EMyWUS.3q6uuDUnehNLGqf.TZedFKp/wlsCPHbl.yh6");

            migrationBuilder.UpdateData(
                table: "MainUser",
                keyColumn: "Id",
                keyValue: 1L,
                column: "Password",
                value: "$2a$12$v0f6sh0OnRCaEFdF5z9mp.nsHiVpWzqywVIksbGBnbNZBIZyw9N6O");

            migrationBuilder.UpdateData(
                table: "MainUser",
                keyColumn: "Id",
                keyValue: 2L,
                column: "Password",
                value: "$2a$12$.laB7VSpny4V5uCriT3pYekw9zvZCvh2SA.Hzqaao4VHBCoZAB4ti");

            migrationBuilder.UpdateData(
                table: "MainUser",
                keyColumn: "Id",
                keyValue: 3L,
                column: "Password",
                value: "$2a$12$XLZbjd0ZPOWXPH.mChgzNucs8zNsEl4i5Rx9Gl7R/7L4aMoYx7wJm");

            migrationBuilder.UpdateData(
                table: "MainUser",
                keyColumn: "Id",
                keyValue: 4L,
                column: "Password",
                value: "$2a$12$vstgGGJRP4DI.pCCtsAj6e3a6kIJ5JeFYKeBbR5gDtZ3meuaBzrfa");

            migrationBuilder.UpdateData(
                table: "MainUser",
                keyColumn: "Id",
                keyValue: 5L,
                column: "Password",
                value: "$2a$12$k.XZLlFa0Akhehwn6HEHTeaR6oLyG/oBw1.7oWeDkiw4.CLKn6whC");

            migrationBuilder.UpdateData(
                table: "MainUser",
                keyColumn: "Id",
                keyValue: 6L,
                column: "Password",
                value: "$2a$12$KwBwxOw/ir7uTpw5hSdP/uMxrdNDeUAN3pGoEJur86d9O2I3F3/ZS");

            migrationBuilder.UpdateData(
                table: "MainUser",
                keyColumn: "Id",
                keyValue: 7L,
                column: "Password",
                value: "$2a$12$UxIARIcAvHI3atNe/009ze9XN2pwAd2ZV4UWmBStFNylyYDQyUtZm");

            migrationBuilder.UpdateData(
                table: "MainUser",
                keyColumn: "Id",
                keyValue: 8L,
                column: "Password",
                value: "$2a$12$rCJlw514bdwGy2UtWu6dFOaVVK.HGpdWvDnoNuBjEOQtq1c9kIgcK");

            migrationBuilder.UpdateData(
                table: "QuickAssessmentQuestions",
                keyColumn: "Id",
                keyValue: 5L,
                column: "ErrorMessageInfo",
                value: "There may be other programs that you potentially qualify for. Please continue with the screening.");

            migrationBuilder.UpdateData(
                table: "QuickAssessmentQuestions",
                keyColumn: "Id",
                keyValue: 26L,
                column: "Value",
                value: "0");

            migrationBuilder.UpdateData(
                table: "QuickAssessmentQuestions",
                keyColumn: "Id",
                keyValue: 27L,
                column: "Value",
                value: "Yearly");

            migrationBuilder.UpdateData(
                table: "QuickAssessmentQuestions",
                keyColumn: "Id",
                keyValue: 28L,
                column: "Value",
                value: "0");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "MainUser",
                keyColumn: "Id",
                keyValue: -1L,
                column: "Password",
                value: "$2a$12$fI6O93COiQbSwpNjLLBHuuOxY/TjB8DBdM4ztvsWsBj.PgSYlQEEC");

            migrationBuilder.UpdateData(
                table: "MainUser",
                keyColumn: "Id",
                keyValue: 1L,
                column: "Password",
                value: "$2a$12$6m4Sgl3MWRlh7A0ACyUuWeVS6dKr0Xsq3CFy9iMH8imi3HbMqmapa");

            migrationBuilder.UpdateData(
                table: "MainUser",
                keyColumn: "Id",
                keyValue: 2L,
                column: "Password",
                value: "$2a$12$gOikRQDtEHFYW0WCd08hReb5gd9BihPeIu7.OQz6yoeFlGeGdkHlS");

            migrationBuilder.UpdateData(
                table: "MainUser",
                keyColumn: "Id",
                keyValue: 3L,
                column: "Password",
                value: "$2a$12$nUcBkg8scyerr4C2D67onOVWuwXpyMWDADuMl8LX1mhrpAoo6WGRi");

            migrationBuilder.UpdateData(
                table: "MainUser",
                keyColumn: "Id",
                keyValue: 4L,
                column: "Password",
                value: "$2a$12$yaG2Cgy6Wnv.bmrgVog1u.xAxUt8evgzI6XUWwTGycFROeqCV.YAO");

            migrationBuilder.UpdateData(
                table: "MainUser",
                keyColumn: "Id",
                keyValue: 5L,
                column: "Password",
                value: "$2a$12$vGh9YvVEU8hox8/kZk7gCu2ZSE0GBRTglDqQs0o0.Olq6dtSMeCiO");

            migrationBuilder.UpdateData(
                table: "MainUser",
                keyColumn: "Id",
                keyValue: 6L,
                column: "Password",
                value: "$2a$12$cmisrdi/wc1tcrBrrM7QYOXfiMa3xqY57gUast8jD08RRQvrlCoTa");

            migrationBuilder.UpdateData(
                table: "MainUser",
                keyColumn: "Id",
                keyValue: 7L,
                column: "Password",
                value: "$2a$12$MbivJuHamV5CrwKOLKZztuarA/kDqH2WHL4jgyJoMivUayUgHx0.6");

            migrationBuilder.UpdateData(
                table: "MainUser",
                keyColumn: "Id",
                keyValue: 8L,
                column: "Password",
                value: "$2a$12$jAAxa8C3uL.ameoL5BElFuFWcGRCkSKkkIy3XjRtKyqWHsrlV9j7u");

            migrationBuilder.UpdateData(
                table: "QuickAssessmentQuestions",
                keyColumn: "Id",
                keyValue: 5L,
                column: "ErrorMessageInfo",
                value: "Any further assistance message (if applicable) goes here. Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore");

            migrationBuilder.UpdateData(
                table: "QuickAssessmentQuestions",
                keyColumn: "Id",
                keyValue: 26L,
                column: "Value",
                value: null);

            migrationBuilder.UpdateData(
                table: "QuickAssessmentQuestions",
                keyColumn: "Id",
                keyValue: 27L,
                column: "Value",
                value: null);

            migrationBuilder.UpdateData(
                table: "QuickAssessmentQuestions",
                keyColumn: "Id",
                keyValue: 28L,
                column: "Value",
                value: null);
        }
    }
}
