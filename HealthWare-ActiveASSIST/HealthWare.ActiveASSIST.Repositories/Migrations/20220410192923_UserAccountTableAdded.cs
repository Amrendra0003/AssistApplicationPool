using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace HealthWare.ActiveASSIST.Repositories.Migrations
{
    public partial class UserAccountTableAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "PatientId",
                table: "MainUser",
                type: "bigint",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Patient",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EmailAddress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CountyCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Cell = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateOfService = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedBy = table.Column<long>(type: "bigint", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedBy = table.Column<long>(type: "bigint", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Patient", x => x.Id);
                });

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

            migrationBuilder.CreateIndex(
                name: "IX_MainUser_PatientId",
                table: "MainUser",
                column: "PatientId");

            migrationBuilder.AddForeignKey(
                name: "FK_MainUser_Patient_PatientId",
                table: "MainUser",
                column: "PatientId",
                principalTable: "Patient",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MainUser_Patient_PatientId",
                table: "MainUser");

            migrationBuilder.DropTable(
                name: "Patient");

            migrationBuilder.DropIndex(
                name: "IX_MainUser_PatientId",
                table: "MainUser");

            migrationBuilder.DropColumn(
                name: "PatientId",
                table: "MainUser");

            migrationBuilder.UpdateData(
                table: "MainUser",
                keyColumn: "Id",
                keyValue: -1L,
                column: "Password",
                value: "$2a$12$nEBx8.oi0gyZ2pMzSp.ZVOU.jTMf7UBh0SehFuvbsGQbNcZ5FOUV.");

            migrationBuilder.UpdateData(
                table: "MainUser",
                keyColumn: "Id",
                keyValue: 1L,
                column: "Password",
                value: "$2a$12$UaA5vyh/C1MhQjXJ0gs0FOhp68H1BytkVIVsz6sqhC4v9tSrw8yU.");

            migrationBuilder.UpdateData(
                table: "MainUser",
                keyColumn: "Id",
                keyValue: 2L,
                column: "Password",
                value: "$2a$12$/P0/KyQMa3nSHumwTJka7uXeTJDsV6LcsEOJJmMfRkb47zj9N9oMO");

            migrationBuilder.UpdateData(
                table: "MainUser",
                keyColumn: "Id",
                keyValue: 3L,
                column: "Password",
                value: "$2a$12$zjLsNcCC52OxdPK10q/4ougSW0tF2QTTXd.okJkFShP7/CGdD5M3G");

            migrationBuilder.UpdateData(
                table: "MainUser",
                keyColumn: "Id",
                keyValue: 4L,
                column: "Password",
                value: "$2a$12$DCimTHfw1q1q00KqAAJIBudctAlxjXyw.gmq5bAikT.AKeN.PmUCq");

            migrationBuilder.UpdateData(
                table: "MainUser",
                keyColumn: "Id",
                keyValue: 5L,
                column: "Password",
                value: "$2a$12$7eNJ5l13CBDTuiB3Oxnuqed1c76a3EZ8rqJ4TJKCwpiqpdZR0L8Fm");

            migrationBuilder.UpdateData(
                table: "MainUser",
                keyColumn: "Id",
                keyValue: 6L,
                column: "Password",
                value: "$2a$12$gV.8dIc7K8fSmWN3id/4reb9wsHvuo.uoO3T7ZT5bJPMr6pD6bzEu");

            migrationBuilder.UpdateData(
                table: "MainUser",
                keyColumn: "Id",
                keyValue: 7L,
                column: "Password",
                value: "$2a$12$xvFFRH1jHmsqQlGyFb2HSe46nd4QTB8Gh0xjIfBmbL.K6lHrD6qLG");

            migrationBuilder.UpdateData(
                table: "MainUser",
                keyColumn: "Id",
                keyValue: 8L,
                column: "Password",
                value: "$2a$12$BL8QnixytajgI7cgoDrPVub/PlAfgYRtuWuPznV7d3tOFe9iDuY1G");
        }
    }
}
