using Microsoft.EntityFrameworkCore.Migrations;

namespace HealthWare.ActiveASSIST.Repositories.Migrations
{
    public partial class hasBeenInjuredSubQuestionsParentIdChanged : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "MainUser",
                keyColumn: "Id",
                keyValue: -1L,
                column: "Password",
                value: "$2a$12$sXa8d8L/U5YaM9CZ89FQhOddRuSSx36k3cdtjDgMY/5c1M94NCShu");

            migrationBuilder.UpdateData(
                table: "MainUser",
                keyColumn: "Id",
                keyValue: 1L,
                column: "Password",
                value: "$2a$12$uc5QP7Kt7KWarIN2hI2w2eeaJW3ApmnX7yDyxqf6XpPkIi8h004hm");

            migrationBuilder.UpdateData(
                table: "MainUser",
                keyColumn: "Id",
                keyValue: 2L,
                column: "Password",
                value: "$2a$12$I2i7zmrgR8j4Ju1fjzEVluX3vd3GKjC2aZyrtg3e7LgPjWk6U8d2q");

            migrationBuilder.UpdateData(
                table: "MainUser",
                keyColumn: "Id",
                keyValue: 3L,
                column: "Password",
                value: "$2a$12$Fp1LBnGNaiTkeKEgyfNb/eyqkP4V2wCIWQDxGjq7kgGdZDiNbs5.G");

            migrationBuilder.UpdateData(
                table: "MainUser",
                keyColumn: "Id",
                keyValue: 4L,
                column: "Password",
                value: "$2a$12$Y06mkKChTiYWYR/2updHKOCm8u.6JIZ0.m.i6pZuNSBC5RxEE3sBm");

            migrationBuilder.UpdateData(
                table: "MainUser",
                keyColumn: "Id",
                keyValue: 5L,
                column: "Password",
                value: "$2a$12$bSitp1Un4Epia4zUwW3zkO9khXA2MJeU183Arwa7xfBSXROMtikjO");

            migrationBuilder.UpdateData(
                table: "MainUser",
                keyColumn: "Id",
                keyValue: 6L,
                column: "Password",
                value: "$2a$12$kyEmU9hZWAp5GFvGGH22PuqrLoCx1G7poGriOlMCZwZh0IXsdqxia");

            migrationBuilder.UpdateData(
                table: "QuickAssessmentQuestions",
                keyColumn: "Id",
                keyValue: 32L,
                column: "ParentQuestionId",
                value: 31L);

            migrationBuilder.UpdateData(
                table: "QuickAssessmentQuestions",
                keyColumn: "Id",
                keyValue: 35L,
                column: "ParentQuestionId",
                value: 31L);

            migrationBuilder.UpdateData(
                table: "QuickAssessmentQuestions",
                keyColumn: "Id",
                keyValue: 36L,
                column: "ParentQuestionId",
                value: 31L);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
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
                keyValue: 32L,
                column: "ParentQuestionId",
                value: 30L);

            migrationBuilder.UpdateData(
                table: "QuickAssessmentQuestions",
                keyColumn: "Id",
                keyValue: 35L,
                column: "ParentQuestionId",
                value: 30L);

            migrationBuilder.UpdateData(
                table: "QuickAssessmentQuestions",
                keyColumn: "Id",
                keyValue: 36L,
                column: "ParentQuestionId",
                value: 30L);
        }
    }
}
