using Microsoft.EntityFrameworkCore.Migrations;

namespace HealthWare.ActiveASSIST.Repositories.Migrations
{
    public partial class ReasonNoSSNFieldAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ReasonNoSsn",
                table: "HouseHoldMember",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ReasonNoSsn",
                table: "Guarantor",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ReasonNoSsn",
                table: "BasicInfo",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "MainUser",
                keyColumn: "Id",
                keyValue: -1L,
                column: "Password",
                value: "$2a$12$0xo19XHns7ZUnO54oaIiYuvnhMCPuLhKmmDHDSlTC6r6u9V2nkKAW");

            migrationBuilder.UpdateData(
                table: "MainUser",
                keyColumn: "Id",
                keyValue: 1L,
                column: "Password",
                value: "$2a$12$JkNjk3ZPxoiKNpn9ZpTnX.Yns5nLDYhbdCwp0a8u7Fp/kS0FFMOyu");

            migrationBuilder.UpdateData(
                table: "MainUser",
                keyColumn: "Id",
                keyValue: 2L,
                column: "Password",
                value: "$2a$12$7/yFgGILecp8BOdFM5RUVe4VWQ/AHRebQf.Xab.vRL.Kv6JGzSzDW");

            migrationBuilder.UpdateData(
                table: "MainUser",
                keyColumn: "Id",
                keyValue: 3L,
                column: "Password",
                value: "$2a$12$1dzV72qzF4jf34iujhj79eMV9AjyCRwscnVx1znSKXORwHSyJMoGq");

            migrationBuilder.UpdateData(
                table: "MainUser",
                keyColumn: "Id",
                keyValue: 4L,
                column: "Password",
                value: "$2a$12$FzbMkaZovXEkpNYdJGqbr.C2./H0C32IeBvSVQ.FPYn2QHag9S0o6");

            migrationBuilder.UpdateData(
                table: "MainUser",
                keyColumn: "Id",
                keyValue: 5L,
                column: "Password",
                value: "$2a$12$RYHXzwdtS/I68sv7.SuJ4u2I5h/zGdKW8K.W2Ej275r4VVw9jioQ2");

            migrationBuilder.UpdateData(
                table: "MainUser",
                keyColumn: "Id",
                keyValue: 6L,
                column: "Password",
                value: "$2a$12$zUh1QJ2AslakeqnOXz6Py.vRjl19qViMil9Ezg53AJj450HrYIUUO");

            migrationBuilder.UpdateData(
                table: "Validators",
                keyColumn: "Id",
                keyValue: 35L,
                column: "Required",
                value: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ReasonNoSsn",
                table: "HouseHoldMember");

            migrationBuilder.DropColumn(
                name: "ReasonNoSsn",
                table: "Guarantor");

            migrationBuilder.DropColumn(
                name: "ReasonNoSsn",
                table: "BasicInfo");

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

            migrationBuilder.UpdateData(
                table: "Validators",
                keyColumn: "Id",
                keyValue: 35L,
                column: "Required",
                value: true);
        }
    }
}
