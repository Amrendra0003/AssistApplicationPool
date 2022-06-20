using Microsoft.EntityFrameworkCore.Migrations;

namespace HealthWare.ActiveASSIST.Repositories.Migrations
{
    public partial class AddedSeedDataForVerification : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "RolesPermissions",
                columns: new[] { "Id", "PermissionId", "RoleId" },
                values: new object[] { 126L, 56L, 2L });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: -1L,
                column: "Password",
                value: "$2a$12$TbCBHMKr4qFLd41QRENvYeh5iK92NfdpnnX.CFyR5SYSa/tv8Zpwi");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1L,
                column: "Password",
                value: "$2a$12$tA9GyHEmTkTloHesO9YcveKw3Qw7sIEJIEXmrvGaJas6b/hafbbG2");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2L,
                column: "Password",
                value: "$2a$12$grna8yU46CSQ5Zibg6KfyOF2Qm/j60ckl3avl.xAYDygl3eK8bshS");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3L,
                column: "Password",
                value: "$2a$12$vzsTd.IYdw7LApxVjDeEy.3tl62BL5OjYjhlprZ2Am8yxM1irqIpq");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 4L,
                column: "Password",
                value: "$2a$12$qZRP2DeB0Q2.E4RXxIBKYOsccsMJLy295mnJZ1npVuzJLMjNNamJu");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 5L,
                column: "Password",
                value: "$2a$12$acd./zUorSEExGWnskHiP.8WLXeclbv8nWOqiQ50DraEExLHxa25K");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 6L,
                column: "Password",
                value: "$2a$12$dsJn4uOENlbBbAYUATjDmOk7G2bEv811S0DVVBWwJ8YcxYsj6J8rW");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "RolesPermissions",
                keyColumn: "Id",
                keyValue: 126L);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: -1L,
                column: "Password",
                value: "$2a$12$BbLn4y2DH6yRvTNnL/h7Pep60cTyxgDHVxyUQT/HBqlGdmRdLzMvO");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1L,
                column: "Password",
                value: "$2a$12$x0by7G8xQqCAZHYhhhSkueKkj04Oz4qHncxZuRmcdt5Aq.Io0Yntq");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2L,
                column: "Password",
                value: "$2a$12$DXFe9GT7SvpZ0XLhCU7W3OMMmQg/Ah9AhF/NbzzkRWMwDU3pHdsVG");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3L,
                column: "Password",
                value: "$2a$12$DtKYWVj9cUoMSstUch9DjOGk9G1UBLACUe8TdY80NXpqprHJ8wysu");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 4L,
                column: "Password",
                value: "$2a$12$6oL4wP/kgMrs4uXdJV4Bleoqwp3iJae2i6F0Aw3tjXWla0ZTVSPGO");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 5L,
                column: "Password",
                value: "$2a$12$BeYW31FqqwlDe/ZFqoan9etznpJSn/je3DR5dugIgOHlhD7AZSOhK");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 6L,
                column: "Password",
                value: "$2a$12$qzO1Sumwl.4HJ1uVzT6vDOuanXHgmDTU1ixSLuXECaPn2PCqVMy3K");
        }
    }
}
