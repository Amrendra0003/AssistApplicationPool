using Microsoft.EntityFrameworkCore.Migrations;

namespace HealthWare.ActiveASSIST.Repositories.Migrations
{
    public partial class householdSubQuestionsParentIdUpdated : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "MainUser",
                keyColumn: "Id",
                keyValue: -1L,
                column: "Password",
                value: "$2a$12$rpe0T/f8QuoZzlLUoja8LexUmsV9xTC7k1iLeZ51N2ZROzhnNyz0C");

            migrationBuilder.UpdateData(
                table: "MainUser",
                keyColumn: "Id",
                keyValue: 1L,
                column: "Password",
                value: "$2a$12$QD1.tjzT2ARr6gYTtvkA7uCot.byUgXygZmiq/VJU6q5lybnRDvxS");

            migrationBuilder.UpdateData(
                table: "MainUser",
                keyColumn: "Id",
                keyValue: 2L,
                column: "Password",
                value: "$2a$12$fyjEUjy06yiaYY5cWUOXkeo2eXpl6s.iHqdpMt23gFZvpAxEZ08BK");

            migrationBuilder.UpdateData(
                table: "MainUser",
                keyColumn: "Id",
                keyValue: 3L,
                column: "Password",
                value: "$2a$12$3pyJ4Mq6QMQgLtMhqfBZ4uLCJaYsGg7Pr/89RLV0JJfC7aLZXZgZ2");

            migrationBuilder.UpdateData(
                table: "MainUser",
                keyColumn: "Id",
                keyValue: 4L,
                column: "Password",
                value: "$2a$12$L.TPQHdc3.DUfGlrviNrYurZMS6K0Dbt2enmHdR50jvWOpNG8ujRi");

            migrationBuilder.UpdateData(
                table: "MainUser",
                keyColumn: "Id",
                keyValue: 5L,
                column: "Password",
                value: "$2a$12$hyVD.mRRSI4IBeULdhAWzOizaZH/4F4dCtMvdOiB.3kXEvlipvT42");

            migrationBuilder.UpdateData(
                table: "MainUser",
                keyColumn: "Id",
                keyValue: 6L,
                column: "Password",
                value: "$2a$12$i1.D3SV734hf/tJJYJgYA.AKNOVBK3Es9iE3sMqW8DTLcqX08AKFC");

            migrationBuilder.UpdateData(
                table: "QuickAssessmentQuestions",
                keyColumn: "Id",
                keyValue: 24L,
                column: "ParentQuestionId",
                value: 23L);

            migrationBuilder.UpdateData(
                table: "QuickAssessmentQuestions",
                keyColumn: "Id",
                keyValue: 25L,
                column: "ParentQuestionId",
                value: 24L);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "MainUser",
                keyColumn: "Id",
                keyValue: -1L,
                column: "Password",
                value: "$2a$12$WhIN8CszkbwtXAGo9D9btuwThayT9gKpabW0k79soT9cknkCF4THq");

            migrationBuilder.UpdateData(
                table: "MainUser",
                keyColumn: "Id",
                keyValue: 1L,
                column: "Password",
                value: "$2a$12$PyeMJZ9Gko81ecmegLlPO.1Lf/H3aLO8UxtT/iYL3ucp.QW06uQGi");

            migrationBuilder.UpdateData(
                table: "MainUser",
                keyColumn: "Id",
                keyValue: 2L,
                column: "Password",
                value: "$2a$12$/wsXru.p9D1r8/bRVK7zWO5PryExC/B6KN8IBezcwfc9wS54Kshe6");

            migrationBuilder.UpdateData(
                table: "MainUser",
                keyColumn: "Id",
                keyValue: 3L,
                column: "Password",
                value: "$2a$12$PsxqZHkojGnm7AjbBvZ7BOBXdoBfSJK82dPhrVOUBBc6JRaPWnR2e");

            migrationBuilder.UpdateData(
                table: "MainUser",
                keyColumn: "Id",
                keyValue: 4L,
                column: "Password",
                value: "$2a$12$8eceBEyhsiuijfXxufvhh.SGNd57EYiagd8D7iezcBhMhAKyOCM5e");

            migrationBuilder.UpdateData(
                table: "MainUser",
                keyColumn: "Id",
                keyValue: 5L,
                column: "Password",
                value: "$2a$12$HbGHncHfVFvp6dj/yOApzukrBGkWlZyAKttLdr5P/f7gNc2dqDsQa");

            migrationBuilder.UpdateData(
                table: "MainUser",
                keyColumn: "Id",
                keyValue: 6L,
                column: "Password",
                value: "$2a$12$6eVWBrm2MEqV2SFG8ZM0w.YoVTOjD.zEhhORqN21L.GiQ4u6Lac3e");

            migrationBuilder.UpdateData(
                table: "QuickAssessmentQuestions",
                keyColumn: "Id",
                keyValue: 24L,
                column: "ParentQuestionId",
                value: 22L);

            migrationBuilder.UpdateData(
                table: "QuickAssessmentQuestions",
                keyColumn: "Id",
                keyValue: 25L,
                column: "ParentQuestionId",
                value: 23L);
        }
    }
}
