using Microsoft.EntityFrameworkCore.Migrations;

namespace HealthWare.ActiveASSIST.Repositories.Migrations
{
    public partial class RemovedADvocateFlowRolebasedDataRemovedFromScreenMappingID : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ScreenQuestionMapping",
                keyColumn: "Id",
                keyValue: 39L);

            migrationBuilder.DeleteData(
                table: "ScreenQuestionMapping",
                keyColumn: "Id",
                keyValue: 40L);

            migrationBuilder.DeleteData(
                table: "ScreenQuestionMapping",
                keyColumn: "Id",
                keyValue: 41L);

            migrationBuilder.DeleteData(
                table: "ScreenQuestionMapping",
                keyColumn: "Id",
                keyValue: 42L);

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

            migrationBuilder.UpdateData(
                table: "ScreenQuestionMapping",
                keyColumn: "Id",
                keyValue: 38L,
                columns: new[] { "KeyName", "ScreenId" },
                values: new object[] { "middleName", 4L });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "MainUser",
                keyColumn: "Id",
                keyValue: -1L,
                column: "Password",
                value: "$2a$12$FRfWiAn2Q8mAnSkW6VmywOJ12Z/xBUJRB048nHmBTPq85G.3ysfai");

            migrationBuilder.UpdateData(
                table: "MainUser",
                keyColumn: "Id",
                keyValue: 1L,
                column: "Password",
                value: "$2a$12$zjkqouVGnze3K/St0pqtFuCfAzcUy1m5UWiZ3h6Bl8kA7H6Yll0je");

            migrationBuilder.UpdateData(
                table: "MainUser",
                keyColumn: "Id",
                keyValue: 2L,
                column: "Password",
                value: "$2a$12$JJ2eFLX9np23NIubJru6Qeup5mk3OIRa35fLX4tS/SbcpTNppzZXq");

            migrationBuilder.UpdateData(
                table: "MainUser",
                keyColumn: "Id",
                keyValue: 3L,
                column: "Password",
                value: "$2a$12$FPPSqZHO.6VCxw4G9SbZ6.YmQ43oNov3YnySnQ8vfChXuKMnlwOmq");

            migrationBuilder.UpdateData(
                table: "MainUser",
                keyColumn: "Id",
                keyValue: 4L,
                column: "Password",
                value: "$2a$12$RiCTTQ0SBpT.udVlGkMYh.MDbzUZ0xCsIFtPEGNBb2knD46yO5C7C");

            migrationBuilder.UpdateData(
                table: "MainUser",
                keyColumn: "Id",
                keyValue: 5L,
                column: "Password",
                value: "$2a$12$zO5fij5awvuxqufTC.dlI.iGN/sbBqtT8DkeGqkypCbWi7HjGkDvS");

            migrationBuilder.UpdateData(
                table: "MainUser",
                keyColumn: "Id",
                keyValue: 6L,
                column: "Password",
                value: "$2a$12$a1hJ932O4y3mLsKPVEtgs.WmSkYsMW4hnMUi2HTqfOK08CGbA0/vO");

            migrationBuilder.UpdateData(
                table: "ScreenQuestionMapping",
                keyColumn: "Id",
                keyValue: 38L,
                columns: new[] { "KeyName", "ScreenId" },
                values: new object[] { "serviceProgram", 8L });

            migrationBuilder.InsertData(
                table: "ScreenQuestionMapping",
                columns: new[] { "Id", "KeyName", "QuestionId", "ScreenId" },
                values: new object[,]
                {
                    { 39L, "healthConditiion", 39L, 8L },
                    { 40L, "beenInjured", 40L, 8L },
                    { 41L, "reportFiledCrime", 41L, 8L },
                    { 42L, "middleName", 38L, 4L }
                });
        }
    }
}
