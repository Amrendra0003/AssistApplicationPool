using Microsoft.EntityFrameworkCore.Migrations;

namespace HealthWare.ActiveASSIST.Repositories.Migrations
{
    public partial class removeCustomValidationFromCitizenshipStatus : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "MainUser",
                keyColumn: "Id",
                keyValue: -1L,
                column: "Password",
                value: "$2a$12$nEBx8.oi0gyZ2pMzSp.ZVOU.jTMf7UBh0SehFuvbsGQbNcZ5FOUV.");

            migrationBuilder.UpdateData(
                table: "MainUser",
                keyColumn: "Id",
                keyValue: 1L,
                column: "Password",
                value: "$2a$12$UaA5vyh/C1MhQjXJ0gs0FOhp68H1BytkVIVsz6sqhC4v9tSrw8yU.");

            migrationBuilder.UpdateData(
                table: "MainUser",
                keyColumn: "Id",
                keyValue: 2L,
                column: "Password",
                value: "$2a$12$/P0/KyQMa3nSHumwTJka7uXeTJDsV6LcsEOJJmMfRkb47zj9N9oMO");

            migrationBuilder.UpdateData(
                table: "MainUser",
                keyColumn: "Id",
                keyValue: 3L,
                column: "Password",
                value: "$2a$12$zjLsNcCC52OxdPK10q/4ougSW0tF2QTTXd.okJkFShP7/CGdD5M3G");

            migrationBuilder.UpdateData(
                table: "MainUser",
                keyColumn: "Id",
                keyValue: 4L,
                column: "Password",
                value: "$2a$12$DCimTHfw1q1q00KqAAJIBudctAlxjXyw.gmq5bAikT.AKeN.PmUCq");

            migrationBuilder.UpdateData(
                table: "MainUser",
                keyColumn: "Id",
                keyValue: 5L,
                column: "Password",
                value: "$2a$12$7eNJ5l13CBDTuiB3Oxnuqed1c76a3EZ8rqJ4TJKCwpiqpdZR0L8Fm");

            migrationBuilder.UpdateData(
                table: "MainUser",
                keyColumn: "Id",
                keyValue: 6L,
                column: "Password",
                value: "$2a$12$gV.8dIc7K8fSmWN3id/4reb9wsHvuo.uoO3T7ZT5bJPMr6pD6bzEu");

            migrationBuilder.UpdateData(
                table: "MainUser",
                keyColumn: "Id",
                keyValue: 7L,
                column: "Password",
                value: "$2a$12$xvFFRH1jHmsqQlGyFb2HSe46nd4QTB8Gh0xjIfBmbL.K6lHrD6qLG");

            migrationBuilder.UpdateData(
                table: "MainUser",
                keyColumn: "Id",
                keyValue: 8L,
                column: "Password",
                value: "$2a$12$BL8QnixytajgI7cgoDrPVub/PlAfgYRtuWuPznV7d3tOFe9iDuY1G");

            migrationBuilder.UpdateData(
                table: "QuickAssessmentQuestions",
                keyColumn: "Id",
                keyValue: 5L,
                column: "CustomValidation",
                value: null);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "MainUser",
                keyColumn: "Id",
                keyValue: -1L,
                column: "Password",
                value: "$2a$12$l.SufGkzG2vudOpUC0382..UlEN52gWAUkD7BktC/XPUebSJ15Jmi");

            migrationBuilder.UpdateData(
                table: "MainUser",
                keyColumn: "Id",
                keyValue: 1L,
                column: "Password",
                value: "$2a$12$B1IDzloZenHUsaMG.3lGSe6jXZ4EcQeqTi6UcuFp9jOCOr/qLqNbe");

            migrationBuilder.UpdateData(
                table: "MainUser",
                keyColumn: "Id",
                keyValue: 2L,
                column: "Password",
                value: "$2a$12$swd0cbkbTLgivJwibo3hDetDIcCkxV20NvdJygxhUR63/LKzT2zBy");

            migrationBuilder.UpdateData(
                table: "MainUser",
                keyColumn: "Id",
                keyValue: 3L,
                column: "Password",
                value: "$2a$12$7qEGN80e5kgoo0V7DV1KKOXuPWpqgEUrSGKKhz8X2cg96CLuGKWja");

            migrationBuilder.UpdateData(
                table: "MainUser",
                keyColumn: "Id",
                keyValue: 4L,
                column: "Password",
                value: "$2a$12$O9vU.naCh9tTlmZpRopnjO3ERYs2.BB8WD8DTpWDMn2LTOj.A9bM6");

            migrationBuilder.UpdateData(
                table: "MainUser",
                keyColumn: "Id",
                keyValue: 5L,
                column: "Password",
                value: "$2a$12$TBhgru6GJVGK4.zaHWRTzOOi..rezYr80fl04.LozMzP2eNlmp7ia");

            migrationBuilder.UpdateData(
                table: "MainUser",
                keyColumn: "Id",
                keyValue: 6L,
                column: "Password",
                value: "$2a$12$hhXvpqkzwWdZhHJ1olCxUebPUn3O2YUQqcYORIqA.Pa93Qs0BSAjy");

            migrationBuilder.UpdateData(
                table: "MainUser",
                keyColumn: "Id",
                keyValue: 7L,
                column: "Password",
                value: "$2a$12$8NnKMDOhJT1na1PGUhHVHuIV6ggg2g5cUbR0XTSCpu8Y9FbqbMGDq");

            migrationBuilder.UpdateData(
                table: "MainUser",
                keyColumn: "Id",
                keyValue: 8L,
                column: "Password",
                value: "$2a$12$YIOGySJYP7Y6Q4sZPmniBu36L2uaKYhyYtGzBrcmrN3YlXG/NNE/2");

            migrationBuilder.UpdateData(
                table: "QuickAssessmentQuestions",
                keyColumn: "Id",
                keyValue: 5L,
                column: "CustomValidation",
                value: "Unknown");
        }
    }
}
