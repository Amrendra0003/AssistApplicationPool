using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace HealthWare.ActiveASSIST.Repositories.Migrations
{
    public partial class langingaPageUrl : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "UserVerification",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Token = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TokenCreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TokenExpirationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    NoOfClicks = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<long>(type: "bigint", nullable: true),
                    CreatedBy = table.Column<long>(type: "bigint", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedBy = table.Column<long>(type: "bigint", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserVerification", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserVerification_MainUser_UserId",
                        column: x => x.UserId,
                        principalTable: "MainUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.UpdateData(
                table: "MainUser",
                keyColumn: "Id",
                keyValue: -1L,
                column: "Password",
                value: "$2a$12$51dCf7ghx.a6t4rfYBaEaOO8uEvksVL4jAHccfSWom0wxb/3NqtWu");

            migrationBuilder.UpdateData(
                table: "MainUser",
                keyColumn: "Id",
                keyValue: 1L,
                column: "Password",
                value: "$2a$12$i7D40VWWB.U2.qD9CbI9IOsJtsdcumUWwfTTfR0ILL1YNXx3koRcK");

            migrationBuilder.UpdateData(
                table: "MainUser",
                keyColumn: "Id",
                keyValue: 2L,
                column: "Password",
                value: "$2a$12$udOTP9eVcpjtjFQxniitE.J.kul8A29k0TR.a6Kmy6FAXGv4wmAIy");

            migrationBuilder.UpdateData(
                table: "MainUser",
                keyColumn: "Id",
                keyValue: 3L,
                column: "Password",
                value: "$2a$12$aS6.9RcopHasyl956BNYL.rixGoE45zSyYWZnyZVTSlpn8O/WP7/e");

            migrationBuilder.UpdateData(
                table: "MainUser",
                keyColumn: "Id",
                keyValue: 4L,
                column: "Password",
                value: "$2a$12$6sYjSlCElUw1x8mDoDKSoOLX9uRnNGX9WzS9BuKe.SP8VFYTaQNn2");

            migrationBuilder.UpdateData(
                table: "MainUser",
                keyColumn: "Id",
                keyValue: 5L,
                column: "Password",
                value: "$2a$12$jw7u.knBI82WysBWUCVqP.KCWMUA6WDdH3ZhDJAAKMt2FctJM9UZ2");

            migrationBuilder.UpdateData(
                table: "MainUser",
                keyColumn: "Id",
                keyValue: 6L,
                column: "Password",
                value: "$2a$12$1i6lYeydCZ2EbaGKRB1oveE13cfJAi8KwGfJVRc7C9EM9YqoGN2Cy");

            migrationBuilder.CreateIndex(
                name: "IX_UserVerification_UserId",
                table: "UserVerification",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserVerification");

            migrationBuilder.UpdateData(
                table: "MainUser",
                keyColumn: "Id",
                keyValue: -1L,
                column: "Password",
                value: "$2a$12$lIQ.8DlULmP0WG4NrL3HnOIgZD/3bUIjn3VfR7bRPci.JgEhH7Qv2");

            migrationBuilder.UpdateData(
                table: "MainUser",
                keyColumn: "Id",
                keyValue: 1L,
                column: "Password",
                value: "$2a$12$sMQ1PmtVfzX.UI.VfYkPK.qTYgoSUn.qvRdlhliByfSUnqDvl.m/y");

            migrationBuilder.UpdateData(
                table: "MainUser",
                keyColumn: "Id",
                keyValue: 2L,
                column: "Password",
                value: "$2a$12$KJMN.oQnm4ITU.re4ZRfHetoCeYxNsjOLrDIGd/hKExQb6ktBz0xK");

            migrationBuilder.UpdateData(
                table: "MainUser",
                keyColumn: "Id",
                keyValue: 3L,
                column: "Password",
                value: "$2a$12$6U6B184w1Pqj3Vt/GoGOi.QtGsh8BuJJx.jwC3DK.gH5FCrd5kaIK");

            migrationBuilder.UpdateData(
                table: "MainUser",
                keyColumn: "Id",
                keyValue: 4L,
                column: "Password",
                value: "$2a$12$oSeUQ/DyX0uuNIAhZP0MjOhw0rC0wmqwv6SyC7pvyo/WGbT8m3guC");

            migrationBuilder.UpdateData(
                table: "MainUser",
                keyColumn: "Id",
                keyValue: 5L,
                column: "Password",
                value: "$2a$12$VGDCet9COgz5KygMnbPg.ekUhtoDTtRky0ljaPt2ruQX3I/oVcaBy");

            migrationBuilder.UpdateData(
                table: "MainUser",
                keyColumn: "Id",
                keyValue: 6L,
                column: "Password",
                value: "$2a$12$uW/b5hVq8cATpo34kY8DHOusrbPmbVfFUaGdXrPHjZxYK2WW74SPy");
        }
    }
}
