using Microsoft.EntityFrameworkCore.Migrations;

namespace HealthWare.ActiveASSIST.Repositories.Migrations
{
    public partial class ReasonNoSsnAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ReasonNoSsn",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CodeData = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CodeType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CodeDescription = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReasonNoSsn", x => x.Id);
                });

            migrationBuilder.UpdateData(
                table: "MainUser",
                keyColumn: "Id",
                keyValue: -1L,
                column: "Password",
                value: "$2a$12$XWzR2kCxOfpNbY/498NN9eFbpeJsb8z4gWUrHB5vdpaERHQnwOGJa");

            migrationBuilder.UpdateData(
                table: "MainUser",
                keyColumn: "Id",
                keyValue: 1L,
                column: "Password",
                value: "$2a$12$tyR4FKClf9ZZJyGWN4BhD.C2t2CqBtZC3PklJEg8jXQ7tn4rO.smC");

            migrationBuilder.UpdateData(
                table: "MainUser",
                keyColumn: "Id",
                keyValue: 2L,
                column: "Password",
                value: "$2a$12$DMrqibukEjCRGAnGcjm38OvVDNLXmnXxIu6IoKFikB5Kf/wLK4zta");

            migrationBuilder.UpdateData(
                table: "MainUser",
                keyColumn: "Id",
                keyValue: 3L,
                column: "Password",
                value: "$2a$12$hIdE/G1sXqEDkcK1rZybBO8wP0DYO6ncyo20hig1pQ.hxJbSmb/2e");

            migrationBuilder.UpdateData(
                table: "MainUser",
                keyColumn: "Id",
                keyValue: 4L,
                column: "Password",
                value: "$2a$12$WWBnpZY23zZZed3WdRybKutDMDO6sfokJOrYu6RhX6V0OzzcQj6zu");

            migrationBuilder.UpdateData(
                table: "MainUser",
                keyColumn: "Id",
                keyValue: 5L,
                column: "Password",
                value: "$2a$12$kjIeW0ff.HEiaFdgd0z78e7QSaX4KJ4xFSzt35ZQThhfy4PCkzhcO");

            migrationBuilder.UpdateData(
                table: "MainUser",
                keyColumn: "Id",
                keyValue: 6L,
                column: "Password",
                value: "$2a$12$roeba/M8TxO4ZqKnp/.uquEMv5HvdzG4bww65EmbVvnalTcNu9jZe");

            migrationBuilder.InsertData(
                table: "ReasonNoSsn",
                columns: new[] { "Id", "CodeData", "CodeDescription", "CodeType" },
                values: new object[,]
                {
                    { 1L, "NA", "Does Not Have One", "NoSSNReason" },
                    { 2L, "UNC", "Unconcious - Could Not Provide", "NoSSNReason" },
                    { 3L, "OTH", "Other", "NoSSNReason" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ReasonNoSsn");

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
