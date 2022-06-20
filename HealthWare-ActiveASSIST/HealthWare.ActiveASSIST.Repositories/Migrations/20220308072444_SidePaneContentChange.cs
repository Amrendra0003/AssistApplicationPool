using Microsoft.EntityFrameworkCore.Migrations;

namespace HealthWare.ActiveASSIST.Repositories.Migrations
{
    public partial class SidePaneContentChange : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "DynamicScreens",
                keyColumn: "Id",
                keyValue: 1L,
                column: "LeftContent",
                value: "Please tell us who received services for this financial assisstance application.");

            migrationBuilder.UpdateData(
                table: "MainUser",
                keyColumn: "Id",
                keyValue: -1L,
                column: "Password",
                value: "$2a$12$UThyHXUABR/94/mpMzMAgebdBIAtdZ9Px3nDXwPRaEnZY5PUESWaO");

            migrationBuilder.UpdateData(
                table: "MainUser",
                keyColumn: "Id",
                keyValue: 1L,
                column: "Password",
                value: "$2a$12$n0FtCa6SRTb4LTXmo6YiVeBgvttKb/TTVd.ienO5cAmjT9NB.YtiS");

            migrationBuilder.UpdateData(
                table: "MainUser",
                keyColumn: "Id",
                keyValue: 2L,
                column: "Password",
                value: "$2a$12$euDwdT53JoxVHQ3pCSKmZuZBF.LeihmrK3eAtvKFKOAEYHvWA/FGG");

            migrationBuilder.UpdateData(
                table: "MainUser",
                keyColumn: "Id",
                keyValue: 3L,
                column: "Password",
                value: "$2a$12$XHF5XuaTgro4jNJPWZnJFepVYxzT7.fG111mlFFRSlt2FhTf6W0XO");

            migrationBuilder.UpdateData(
                table: "MainUser",
                keyColumn: "Id",
                keyValue: 4L,
                column: "Password",
                value: "$2a$12$zfEhmolrl9d21CDtbc3JxuBusP.24jooUQN8jR1CN49CYUmzWsk7u");

            migrationBuilder.UpdateData(
                table: "MainUser",
                keyColumn: "Id",
                keyValue: 5L,
                column: "Password",
                value: "$2a$12$B9vReqlSY70GLGMcSaAUDOMSqYa0zHuHvzLXLWsM9fc6Y/Pgrn25u");

            migrationBuilder.UpdateData(
                table: "MainUser",
                keyColumn: "Id",
                keyValue: 6L,
                column: "Password",
                value: "$2a$12$LBjvb6F38hP4c2WqJGvcCOY9tXdriquUoBZMWBU.sD7b/GC66zGeS");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "DynamicScreens",
                keyColumn: "Id",
                keyValue: 1L,
                column: "LeftContent",
                value: "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat.");

            migrationBuilder.UpdateData(
                table: "MainUser",
                keyColumn: "Id",
                keyValue: -1L,
                column: "Password",
                value: "$2a$12$SpEkotTSgPfiyTvONbZ7Z.4dN4xkVRwCKUFO8Gc.UxsyI0d04bZ8a");

            migrationBuilder.UpdateData(
                table: "MainUser",
                keyColumn: "Id",
                keyValue: 1L,
                column: "Password",
                value: "$2a$12$pxpn3AryKqFgi8Ns3V89gOEtpUoyh2pmOskXObU99KdC.ZE8TZLTW");

            migrationBuilder.UpdateData(
                table: "MainUser",
                keyColumn: "Id",
                keyValue: 2L,
                column: "Password",
                value: "$2a$12$qSOfMJGaviYRyprQFF26b.ZXo8RxyxR.ukJXnaB7ee1X74KCB3ZJ6");

            migrationBuilder.UpdateData(
                table: "MainUser",
                keyColumn: "Id",
                keyValue: 3L,
                column: "Password",
                value: "$2a$12$Aesyd60zGRLF9nwgPP1kOekAQ9PjqpeoBhYI1.U5WuTnucYoOWdam");

            migrationBuilder.UpdateData(
                table: "MainUser",
                keyColumn: "Id",
                keyValue: 4L,
                column: "Password",
                value: "$2a$12$w/R4/9A5u3KTS6R4O1VvbeohdA4ZHguk5qyWFqxw8gflHAer2I9Za");

            migrationBuilder.UpdateData(
                table: "MainUser",
                keyColumn: "Id",
                keyValue: 5L,
                column: "Password",
                value: "$2a$12$PHH3g88zd288/nA9yVFKQu.PqB6Goq/Vgyqf.LmHNhe.4ZgBZVCVm");

            migrationBuilder.UpdateData(
                table: "MainUser",
                keyColumn: "Id",
                keyValue: 6L,
                column: "Password",
                value: "$2a$12$0zB0/pE/8oKuIHp3D4y4DehamqmXUYigbEzcqjRXaT5fXQOvHkcUK");
        }
    }
}
