using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace HealthWare.ActiveASSIST.Repositories.Migrations
{
    public partial class passwordPolicyAndUserLoginHistoryAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PasswordPolicy",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AttemptLimits = table.Column<int>(type: "int", nullable: false),
                    ExpireTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TenantId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedBy = table.Column<long>(type: "bigint", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedBy = table.Column<long>(type: "bigint", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PasswordPolicy", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UserLoginHistory",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NoOfAttempts = table.Column<int>(type: "int", nullable: false),
                    ExpireTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    userId = table.Column<long>(type: "bigint", nullable: true),
                    CreatedBy = table.Column<long>(type: "bigint", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedBy = table.Column<long>(type: "bigint", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserLoginHistory", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserLoginHistory_MainUser_userId",
                        column: x => x.userId,
                        principalTable: "MainUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.UpdateData(
                table: "MainUser",
                keyColumn: "Id",
                keyValue: -1L,
                column: "Password",
                value: "$2a$12$inE60xya3kMviBc94St1.OoyZe5GMf7b6/8kISL8NLfu4MbS2tdtK");

            migrationBuilder.UpdateData(
                table: "MainUser",
                keyColumn: "Id",
                keyValue: 1L,
                column: "Password",
                value: "$2a$12$P.rU9d0ut0CO1USzwM1gEOWqobAxSzILAhyN1E6J7oCr00Pa70/ju");

            migrationBuilder.UpdateData(
                table: "MainUser",
                keyColumn: "Id",
                keyValue: 2L,
                column: "Password",
                value: "$2a$12$eYT4l9MHV/WF41egSmPVbuOvvI1uGM7eOPqCcNPCCFiePvm02G58i");

            migrationBuilder.UpdateData(
                table: "MainUser",
                keyColumn: "Id",
                keyValue: 3L,
                column: "Password",
                value: "$2a$12$bpptMwDcIjGewQUJ5zc9/.v.Py4MXk76BiRIPilqmvg.isRbKQQOi");

            migrationBuilder.UpdateData(
                table: "MainUser",
                keyColumn: "Id",
                keyValue: 4L,
                column: "Password",
                value: "$2a$12$EQrGmmetHEkkfVkpvuCfteLznAywEFiNUkSOCaz0nL..ov4DCxCLq");

            migrationBuilder.UpdateData(
                table: "MainUser",
                keyColumn: "Id",
                keyValue: 5L,
                column: "Password",
                value: "$2a$12$bPw5x6LrncHLP2LllHunsO0MZ8lkOQ2BA7jkJVnVkcKNbsrV7ZNGW");

            migrationBuilder.UpdateData(
                table: "MainUser",
                keyColumn: "Id",
                keyValue: 6L,
                column: "Password",
                value: "$2a$12$SgNCBvX8IANx0pRM3FgStOtdi1L/g.8WV60axFfMNJVrjVBad1fRu");

            migrationBuilder.CreateIndex(
                name: "IX_UserLoginHistory_userId",
                table: "UserLoginHistory",
                column: "userId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PasswordPolicy");

            migrationBuilder.DropTable(
                name: "UserLoginHistory");

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
        }
    }
}
