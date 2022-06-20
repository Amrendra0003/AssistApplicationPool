using Microsoft.EntityFrameworkCore.Migrations;

namespace HealthWare.ActiveASSIST.Repositories.Migrations
{
    public partial class baseEntityAddedForPasswordPolicyTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "MainUser",
                keyColumn: "Id",
                keyValue: -1L,
                column: "Password",
                value: "$2a$12$oYI58KMPyoRZ0n3kwRcaP.0Uq4k1C/L4AQ1gIq2gewA5iEH41NtQa");

            migrationBuilder.UpdateData(
                table: "MainUser",
                keyColumn: "Id",
                keyValue: 1L,
                column: "Password",
                value: "$2a$12$FsmffG.rCvHhr6QXf43Xcu4Ny3LsQkwCrS0Hl08JwNr4dcNQAR8.m");

            migrationBuilder.UpdateData(
                table: "MainUser",
                keyColumn: "Id",
                keyValue: 2L,
                column: "Password",
                value: "$2a$12$B/pvZqWaU1WUB.YsbZDCdOwZtADuTqn6D7WOEv.cuLC54dmSwng6C");

            migrationBuilder.UpdateData(
                table: "MainUser",
                keyColumn: "Id",
                keyValue: 3L,
                column: "Password",
                value: "$2a$12$l93KS/jIVlXs3ThssIjBouu4J5tTsuY7QC2/Y0LUKSl/lcObpUpru");

            migrationBuilder.UpdateData(
                table: "MainUser",
                keyColumn: "Id",
                keyValue: 4L,
                column: "Password",
                value: "$2a$12$yy1jCZvWUBvWY6Q5YJ2a4O0E3RWcDhae2oXRlYHFNFefKGm7LRoom");

            migrationBuilder.UpdateData(
                table: "MainUser",
                keyColumn: "Id",
                keyValue: 5L,
                column: "Password",
                value: "$2a$12$cfPiVZYrzkIzAsGMAVhp8OAEkHAxWQGOttbIfY8iqHQk.6f4YMZrq");

            migrationBuilder.UpdateData(
                table: "MainUser",
                keyColumn: "Id",
                keyValue: 6L,
                column: "Password",
                value: "$2a$12$D9FkOm3azsLJ33KxM/xAV.2WWajGhRM7zb5d1FXirjmaom835lTJC");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
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
        }
    }
}
