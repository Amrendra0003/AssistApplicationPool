using Microsoft.EntityFrameworkCore.Migrations;

namespace HealthWare.ActiveASSIST.Repositories.Migrations
{
    public partial class TenantPhonenumberAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "PhoneNumber",
                table: "TenantDetails",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "TenantDetails",
                keyColumn: "Id",
                keyValue: 1L,
                column: "PhoneNumber",
                value: "5554442341");

            migrationBuilder.UpdateData(
                table: "TenantDetails",
                keyColumn: "Id",
                keyValue: 2L,
                column: "PhoneNumber",
                value: "6663432341");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: -1L,
                column: "Password",
                value: "$2a$12$3bFvigjzdtdyrWgp5m5yjeV0PQC1cBJxSnQ2/As8oOmdzbI6cdHxG");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1L,
                column: "Password",
                value: "$2a$12$58tZ6A.QeOvl7jXMZV6FfODJAA/VgVLfFHCez0ub5vuLQYuON4pbG");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2L,
                column: "Password",
                value: "$2a$12$ETgZ7Q0VSR93SFSEyJe53.uRS797t5rEhQdXVlge1qMPiA4UV2n8i");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3L,
                column: "Password",
                value: "$2a$12$Y9bLKdutdx8j3LhgxUOMNevErd4jY18eejb0F8XsK3FKwqCnxSaY2");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 4L,
                column: "Password",
                value: "$2a$12$kUZk3NJc6qKrGgcdb5v64./LKjnQxP1hZ6EJV3vTi5U8BfxHxmnUC");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 5L,
                column: "Password",
                value: "$2a$12$ggxUIuQAZB.1iyJpZktyz.3zr1p4pgejN2oVaWSRfgL0s4/NaQ/cS");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 6L,
                column: "Password",
                value: "$2a$12$pDTFHg3HG259RNwenRdF9.RINJNUs4Fx4pMYq9es9VaexItqdh7gq");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PhoneNumber",
                table: "TenantDetails");

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
    }
}
