using Microsoft.EntityFrameworkCore.Migrations;

namespace HealthWare.ActiveASSIST.Repositories.Migrations
{
    public partial class insuranceCoverageParentQuestionIdAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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
                keyValue: 15L,
                column: "ParentQuestionId",
                value: 14L);

            migrationBuilder.UpdateData(
                table: "QuickAssessmentQuestions",
                keyColumn: "Id",
                keyValue: 16L,
                column: "ParentQuestionId",
                value: 14L);

            migrationBuilder.UpdateData(
                table: "QuickAssessmentQuestions",
                keyColumn: "Id",
                keyValue: 17L,
                column: "ParentQuestionId",
                value: 14L);

            migrationBuilder.UpdateData(
                table: "QuickAssessmentQuestions",
                keyColumn: "Id",
                keyValue: 18L,
                column: "ParentQuestionId",
                value: 14L);

            migrationBuilder.UpdateData(
                table: "QuickAssessmentQuestions",
                keyColumn: "Id",
                keyValue: 19L,
                column: "ParentQuestionId",
                value: 14L);

            migrationBuilder.UpdateData(
                table: "QuickAssessmentQuestions",
                keyColumn: "Id",
                keyValue: 20L,
                column: "ParentQuestionId",
                value: 14L);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "MainUser",
                keyColumn: "Id",
                keyValue: -1L,
                column: "Password",
                value: "$2a$12$pCQlHt4gmkL7B.Src34b.eQr2gihjrslFFthdMHHR.GMVA5MPh.4q");

            migrationBuilder.UpdateData(
                table: "MainUser",
                keyColumn: "Id",
                keyValue: 1L,
                column: "Password",
                value: "$2a$12$NDLH4gIiNwmoNEmvB.tXW.4P863noXsDw0IMuZi7nCnAO9xrW/lCy");

            migrationBuilder.UpdateData(
                table: "MainUser",
                keyColumn: "Id",
                keyValue: 2L,
                column: "Password",
                value: "$2a$12$preALnCEchcVYuiZPgZN1OMIHTRfIwHiC3ytVHjAVwt29dxbUObe.");

            migrationBuilder.UpdateData(
                table: "MainUser",
                keyColumn: "Id",
                keyValue: 3L,
                column: "Password",
                value: "$2a$12$aISnrZHNROVaVpvlcVFUqu6XRSdhe/Pzttwp3avYVgplmwiI1oRMm");

            migrationBuilder.UpdateData(
                table: "MainUser",
                keyColumn: "Id",
                keyValue: 4L,
                column: "Password",
                value: "$2a$12$fX/2.ceObVHq04VT6OTiWeSsENL.eSKa4o4cmNqgL8RzOPdXhpydO");

            migrationBuilder.UpdateData(
                table: "MainUser",
                keyColumn: "Id",
                keyValue: 5L,
                column: "Password",
                value: "$2a$12$xTq70rDQio6F9/4koAC8r.bi4GDBGSHWSThwMXn4JEMb1M972.NoS");

            migrationBuilder.UpdateData(
                table: "MainUser",
                keyColumn: "Id",
                keyValue: 6L,
                column: "Password",
                value: "$2a$12$2qmnkMQ8NwZ9TcHdemc7dONzBr.LxexpgR0C8aMc7tUnqcOcpcDd6");

            migrationBuilder.UpdateData(
                table: "QuickAssessmentQuestions",
                keyColumn: "Id",
                keyValue: 15L,
                column: "ParentQuestionId",
                value: 13L);

            migrationBuilder.UpdateData(
                table: "QuickAssessmentQuestions",
                keyColumn: "Id",
                keyValue: 16L,
                column: "ParentQuestionId",
                value: 13L);

            migrationBuilder.UpdateData(
                table: "QuickAssessmentQuestions",
                keyColumn: "Id",
                keyValue: 17L,
                column: "ParentQuestionId",
                value: 13L);

            migrationBuilder.UpdateData(
                table: "QuickAssessmentQuestions",
                keyColumn: "Id",
                keyValue: 18L,
                column: "ParentQuestionId",
                value: 13L);

            migrationBuilder.UpdateData(
                table: "QuickAssessmentQuestions",
                keyColumn: "Id",
                keyValue: 19L,
                column: "ParentQuestionId",
                value: 13L);

            migrationBuilder.UpdateData(
                table: "QuickAssessmentQuestions",
                keyColumn: "Id",
                keyValue: 20L,
                column: "ParentQuestionId",
                value: 13L);
        }
    }
}
