using Microsoft.EntityFrameworkCore.Migrations;

namespace HealthWare.ActiveASSIST.Repositories.Migrations
{
    public partial class customValidationAddedForHouseholdIncome : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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
                keyValue: 26L,
                column: "CustomValidation",
                value: "Income");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "MainUser",
                keyColumn: "Id",
                keyValue: -1L,
                column: "Password",
                value: "$2a$12$ClFR1Sd3V4j.B5ty1TU7NuaHATkLPNwCWGIRtVdwEa3K7UOPTu792");

            migrationBuilder.UpdateData(
                table: "MainUser",
                keyColumn: "Id",
                keyValue: 1L,
                column: "Password",
                value: "$2a$12$r6Qa6vAc4duNzBRiLKtpH.zVnbSf.kjTAyqThA2C54ATbU9.t9W82");

            migrationBuilder.UpdateData(
                table: "MainUser",
                keyColumn: "Id",
                keyValue: 2L,
                column: "Password",
                value: "$2a$12$aD2vEMAe4ZGow9yS0rEOKuY63meckIRF/9La11Gax8tOU9JSV36Tm");

            migrationBuilder.UpdateData(
                table: "MainUser",
                keyColumn: "Id",
                keyValue: 3L,
                column: "Password",
                value: "$2a$12$KkY1lYpzD93SG5h7FNYd..wXZh9r/lu48Ng9QhdC83GmlA9XrlPW2");

            migrationBuilder.UpdateData(
                table: "MainUser",
                keyColumn: "Id",
                keyValue: 4L,
                column: "Password",
                value: "$2a$12$D8Vw/sBVOEQLetiRpErf7OspAV2ZbdGBSlTLnsNLzAB1p/5BKXUye");

            migrationBuilder.UpdateData(
                table: "MainUser",
                keyColumn: "Id",
                keyValue: 5L,
                column: "Password",
                value: "$2a$12$IxeFaohCY3gGBLUg7zCnAOnjfPF6b2bcFOPX3.wIG8NuHGkAcgAVW");

            migrationBuilder.UpdateData(
                table: "MainUser",
                keyColumn: "Id",
                keyValue: 6L,
                column: "Password",
                value: "$2a$12$1X5UL8OEIHgsXTL7B1OnMuBgO60ofefiRtWXgB88987LeiNxpJKtS");

            migrationBuilder.UpdateData(
                table: "MainUser",
                keyColumn: "Id",
                keyValue: 7L,
                column: "Password",
                value: "$2a$12$MgsZwWx1F0LiYm9aTv21nOYzm7KgcJZ5nYkM.fKExaDqSnHPMEDGK");

            migrationBuilder.UpdateData(
                table: "MainUser",
                keyColumn: "Id",
                keyValue: 8L,
                column: "Password",
                value: "$2a$12$QrI5dfHYf3srCoBOJi3KZuCescW2SOrKlr.QD2FyqVbdEHXpydmp.");

            migrationBuilder.UpdateData(
                table: "QuickAssessmentQuestions",
                keyColumn: "Id",
                keyValue: 26L,
                column: "CustomValidation",
                value: null);
        }
    }
}
