using Microsoft.EntityFrameworkCore.Migrations;

namespace HealthWare.ActiveASSIST.Repositories.Migrations
{
    public partial class CanDeleteHouseholdAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "CanDeleteHousehold",
                table: "HouseHoldMember",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.UpdateData(
                table: "MainUser",
                keyColumn: "Id",
                keyValue: -1L,
                column: "Password",
                value: "$2a$12$V14xjGRzUQHQjIjxEI5Vue1m/Uk9Xz/U3dC8UGNSlkbgFxfhxr3YW");

            migrationBuilder.UpdateData(
                table: "MainUser",
                keyColumn: "Id",
                keyValue: 1L,
                column: "Password",
                value: "$2a$12$.7X1Ibq.Gd8BXoHe7PWTv.xCI2lzc3xsPXbjcUtj5URe0XZ39lzzi");

            migrationBuilder.UpdateData(
                table: "MainUser",
                keyColumn: "Id",
                keyValue: 2L,
                column: "Password",
                value: "$2a$12$bMViCzQOjBZmXxbIUnjnwOFl4CWu4KY83c5ws.UkMDsAT4mNNT9xy");

            migrationBuilder.UpdateData(
                table: "MainUser",
                keyColumn: "Id",
                keyValue: 3L,
                column: "Password",
                value: "$2a$12$X0f3WWq90CQRExJacWyVzOALOJc4UeFJucukwG9bOoHjkUfJGE/gu");

            migrationBuilder.UpdateData(
                table: "MainUser",
                keyColumn: "Id",
                keyValue: 4L,
                column: "Password",
                value: "$2a$12$nUGHnUNmFjNGCpLMhrPEs.mDRtf1Pffo2EuIXoxNA5XvilwHsnLIS");

            migrationBuilder.UpdateData(
                table: "MainUser",
                keyColumn: "Id",
                keyValue: 5L,
                column: "Password",
                value: "$2a$12$0aeP1zhuwIj4m4Bclb86ZuZL9/LBJ7BVdknaihEU1wk2c/GKp6mDa");

            migrationBuilder.UpdateData(
                table: "MainUser",
                keyColumn: "Id",
                keyValue: 6L,
                column: "Password",
                value: "$2a$12$MWlq8MgWoPzXBJLzrPRdBeS.umvD9jOmcjr49BE.oKTQNSy8egpOi");

            migrationBuilder.UpdateData(
                table: "MainUser",
                keyColumn: "Id",
                keyValue: 7L,
                column: "Password",
                value: "$2a$12$BPDA.O3xFpzH0473V5j2zu/xcL4W0mhCLERgSH.yCH6nzr5g611d6");

            migrationBuilder.UpdateData(
                table: "MainUser",
                keyColumn: "Id",
                keyValue: 8L,
                column: "Password",
                value: "$2a$12$.0JdZcmHsoqGsprFK3ICwu0.QNVarFNoo/TUi2QQiNQQwBMoQilj6");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CanDeleteHousehold",
                table: "HouseHoldMember");

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
        }
    }
}
