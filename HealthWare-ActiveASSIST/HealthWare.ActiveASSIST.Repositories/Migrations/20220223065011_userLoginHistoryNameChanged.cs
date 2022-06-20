using Microsoft.EntityFrameworkCore.Migrations;

namespace HealthWare.ActiveASSIST.Repositories.Migrations
{
    public partial class userLoginHistoryNameChanged : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserLoginHistory_MainUser_userId",
                table: "UserLoginHistory");

            migrationBuilder.RenameColumn(
                name: "userId",
                table: "UserLoginHistory",
                newName: "UserId");

            migrationBuilder.RenameIndex(
                name: "IX_UserLoginHistory_userId",
                table: "UserLoginHistory",
                newName: "IX_UserLoginHistory_UserId");

            migrationBuilder.UpdateData(
                table: "MainUser",
                keyColumn: "Id",
                keyValue: -1L,
                column: "Password",
                value: "$2a$12$N0AwCxVAsQJCDdMJ1JhLUu..NLLZt.Jt44aog2G5Gq41G/iLbxKL2");

            migrationBuilder.UpdateData(
                table: "MainUser",
                keyColumn: "Id",
                keyValue: 1L,
                column: "Password",
                value: "$2a$12$ytbVsQUVOuKcwurjnovNguf6oKhrJGnZm0O.0qjkUhd5/aSJJnzMu");

            migrationBuilder.UpdateData(
                table: "MainUser",
                keyColumn: "Id",
                keyValue: 2L,
                column: "Password",
                value: "$2a$12$qkLTFUxuvhrEGC78uHwnquFmyfCJysqj8NkK0t/GjLC1sJyfAx.WG");

            migrationBuilder.UpdateData(
                table: "MainUser",
                keyColumn: "Id",
                keyValue: 3L,
                column: "Password",
                value: "$2a$12$vCo6tuEhskbAHKrz0CCWJuq.5og0IH4MMRVjnqQmtJVfBDQTgLyJ6");

            migrationBuilder.UpdateData(
                table: "MainUser",
                keyColumn: "Id",
                keyValue: 4L,
                column: "Password",
                value: "$2a$12$0U1Ww4v5kgyYleK7wXULV.6w7E7YVh91rYuQQqY3DoAsiq5.PcD6u");

            migrationBuilder.UpdateData(
                table: "MainUser",
                keyColumn: "Id",
                keyValue: 5L,
                column: "Password",
                value: "$2a$12$Mix6lEOLjp7/vr8ZHr6c0u.TVs5jcmNOcFbZZ5nbFOwSr.RCTqioC");

            migrationBuilder.UpdateData(
                table: "MainUser",
                keyColumn: "Id",
                keyValue: 6L,
                column: "Password",
                value: "$2a$12$uosTd6egyZB7iiJfli0ZOOE.drTU7AmncfhgL7/In5l4raUxij/0u");

            migrationBuilder.AddForeignKey(
                name: "FK_UserLoginHistory_MainUser_UserId",
                table: "UserLoginHistory",
                column: "UserId",
                principalTable: "MainUser",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserLoginHistory_MainUser_UserId",
                table: "UserLoginHistory");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "UserLoginHistory",
                newName: "userId");

            migrationBuilder.RenameIndex(
                name: "IX_UserLoginHistory_UserId",
                table: "UserLoginHistory",
                newName: "IX_UserLoginHistory_userId");

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

            migrationBuilder.AddForeignKey(
                name: "FK_UserLoginHistory_MainUser_userId",
                table: "UserLoginHistory",
                column: "userId",
                principalTable: "MainUser",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
