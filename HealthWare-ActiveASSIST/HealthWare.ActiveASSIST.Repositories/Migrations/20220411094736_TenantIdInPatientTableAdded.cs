using Microsoft.EntityFrameworkCore.Migrations;

namespace HealthWare.ActiveASSIST.Repositories.Migrations
{
    public partial class TenantIdInPatientTableAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "TenantId",
                table: "Patient",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "MainUser",
                keyColumn: "Id",
                keyValue: -1L,
                column: "Password",
                value: "$2a$12$CDdVp2vRJbSBpt6gBoUz8OIdjhQ7fz8bOe36gPMuvBm5aEKayQFWy");

            migrationBuilder.UpdateData(
                table: "MainUser",
                keyColumn: "Id",
                keyValue: 1L,
                column: "Password",
                value: "$2a$12$bjUuobuv23nK/LXOGOgCku/ByUsO90dDbOgPT2wu5Qji/GpOjbNNu");

            migrationBuilder.UpdateData(
                table: "MainUser",
                keyColumn: "Id",
                keyValue: 2L,
                column: "Password",
                value: "$2a$12$c1XJX0g47qnPeeXdoPek.Owl04yrZnQuaE2ARIjjtTZpQnpE.W3jK");

            migrationBuilder.UpdateData(
                table: "MainUser",
                keyColumn: "Id",
                keyValue: 3L,
                column: "Password",
                value: "$2a$12$.orfCni8RWvmpun72L.pFuLxElN7l5ML1DgB3OdKBT8FFNReLT0ki");

            migrationBuilder.UpdateData(
                table: "MainUser",
                keyColumn: "Id",
                keyValue: 4L,
                column: "Password",
                value: "$2a$12$znokUhLbWivlS8rOGm5Na.9HJh/KDEnx17Xu.4toKQ/yNNq3bO0mG");

            migrationBuilder.UpdateData(
                table: "MainUser",
                keyColumn: "Id",
                keyValue: 5L,
                column: "Password",
                value: "$2a$12$itxq/zxNqq3.XW34YL0a6uJ6CGYR9fA9d1aYyX5JrYdA3uSJHqSN.");

            migrationBuilder.UpdateData(
                table: "MainUser",
                keyColumn: "Id",
                keyValue: 6L,
                column: "Password",
                value: "$2a$12$T7HJQZ7M2tl8EmzQSHp3be8AHQYwznQUNjf4qpIis0ABrMUA0QZBe");

            migrationBuilder.UpdateData(
                table: "MainUser",
                keyColumn: "Id",
                keyValue: 7L,
                column: "Password",
                value: "$2a$12$UM3Qlgf7qMdGxwBu3WhjgeS3IVdKKfpRQStL1oPblgxtibzYcbZ0G");

            migrationBuilder.UpdateData(
                table: "MainUser",
                keyColumn: "Id",
                keyValue: 8L,
                column: "Password",
                value: "$2a$12$OeXzP1bLkvrs56bSusFyxe/DKCNSkiNk/mbdNEa6cXtjHKwP7B5w.");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TenantId",
                table: "Patient");

            migrationBuilder.UpdateData(
                table: "MainUser",
                keyColumn: "Id",
                keyValue: -1L,
                column: "Password",
                value: "$2a$12$CAjyTO2CuVLAM8ynyLjp7.aA5sWl4svhbmt6Sgtgl2lvDsP8HDXSS");

            migrationBuilder.UpdateData(
                table: "MainUser",
                keyColumn: "Id",
                keyValue: 1L,
                column: "Password",
                value: "$2a$12$WBZ0Aucmr7NR3BaVtPm07uuj0BQX1faP0R06al8ua1RKHpq3HJdzm");

            migrationBuilder.UpdateData(
                table: "MainUser",
                keyColumn: "Id",
                keyValue: 2L,
                column: "Password",
                value: "$2a$12$N8Bdf0hE8HYbRVNtu4fxqOrzy.pzYh3HqCy8jFwVlcIKMs/KANtN6");

            migrationBuilder.UpdateData(
                table: "MainUser",
                keyColumn: "Id",
                keyValue: 3L,
                column: "Password",
                value: "$2a$12$vAgj.j6w8qZHaVyD9IzM/u6MHO.CCtpz.Tjwc01sSUkYZqU5VLyom");

            migrationBuilder.UpdateData(
                table: "MainUser",
                keyColumn: "Id",
                keyValue: 4L,
                column: "Password",
                value: "$2a$12$2iMC1sv4PT05UtRLkpWjceFQ8jvns5LtXUaxb6pXf7V2cKLsSn2W6");

            migrationBuilder.UpdateData(
                table: "MainUser",
                keyColumn: "Id",
                keyValue: 5L,
                column: "Password",
                value: "$2a$12$gQfrkt1bey9uC9sYyZU2se7jH5TwCeIU3tg0I9QLLChl.qm9rqnEe");

            migrationBuilder.UpdateData(
                table: "MainUser",
                keyColumn: "Id",
                keyValue: 6L,
                column: "Password",
                value: "$2a$12$5VSzkLNdKGGob1DTcFEJkeKJh47oBTZoEZ9rSzqqRFKoe2OO2pQGq");

            migrationBuilder.UpdateData(
                table: "MainUser",
                keyColumn: "Id",
                keyValue: 7L,
                column: "Password",
                value: "$2a$12$amv.Br2wf2dgOwVST0.KTOua1zcMkQpnQ8ELKjiJseQgrF1MxEjD2");

            migrationBuilder.UpdateData(
                table: "MainUser",
                keyColumn: "Id",
                keyValue: 8L,
                column: "Password",
                value: "$2a$12$IuUazaLOKkXiX4cgWw5ce.uIBRFjUNspig1.7ToMmmMULhXtXHb0S");
        }
    }
}
