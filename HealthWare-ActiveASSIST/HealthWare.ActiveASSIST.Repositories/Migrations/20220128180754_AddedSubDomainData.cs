using Microsoft.EntityFrameworkCore.Migrations;

namespace HealthWare.ActiveASSIST.Repositories.Migrations
{
    public partial class AddedSubDomainData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "MainUser",
                keyColumn: "Id",
                keyValue: -1L,
                column: "Password",
                value: "$2a$12$YL7SmSXzZ7blEWiYyCkHb.CZjSbKRf5Li1m0wjLl8REWTJp7BYC2u");

            migrationBuilder.UpdateData(
                table: "MainUser",
                keyColumn: "Id",
                keyValue: 1L,
                column: "Password",
                value: "$2a$12$LdSqKIpPdttP1l1.QQQpGenTfEAx1QtDxKMKkVv6vuLgkphHoo4ZS");

            migrationBuilder.UpdateData(
                table: "MainUser",
                keyColumn: "Id",
                keyValue: 2L,
                column: "Password",
                value: "$2a$12$nfTTYRxRSQiCTTPdRKi6HOq8Ki/jpksJZSVrkk6NPkBpiGPBCyudi");

            migrationBuilder.UpdateData(
                table: "MainUser",
                keyColumn: "Id",
                keyValue: 3L,
                column: "Password",
                value: "$2a$12$204AXXR.NO.CXkmsS/q55uDL68SOf8PVDZmCDViDggaq5QZk2ONOa");

            migrationBuilder.UpdateData(
                table: "MainUser",
                keyColumn: "Id",
                keyValue: 4L,
                column: "Password",
                value: "$2a$12$C8wTAfRshcWhQUvxZhTVJe6BBYuBvYa5G7NhSmJsRvY12bNuUiUj.");

            migrationBuilder.UpdateData(
                table: "MainUser",
                keyColumn: "Id",
                keyValue: 5L,
                column: "Password",
                value: "$2a$12$W.PKuNdWisYL3XxXYj1mL.8NxgOhoFwsZvFOAde1cGvPDW2zVATne");

            migrationBuilder.UpdateData(
                table: "MainUser",
                keyColumn: "Id",
                keyValue: 6L,
                column: "Password",
                value: "$2a$12$fCmy5FCpk5NO2TmraVyZE.0lTzHsScLWNkj55koqD9AgLwwINEAla");

            migrationBuilder.UpdateData(
                table: "SubDomainMaster",
                keyColumn: "Id",
                keyValue: 1L,
                column: "SubDomain",
                value: "activeassist-qa.zucisystems.com:8090");

            migrationBuilder.InsertData(
                table: "SubDomainMaster",
                columns: new[] { "Id", "SubDomain", "TenantId" },
                values: new object[] { 2L, "localhost:4200", "2" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "SubDomainMaster",
                keyColumn: "Id",
                keyValue: 2L);

            migrationBuilder.UpdateData(
                table: "MainUser",
                keyColumn: "Id",
                keyValue: -1L,
                column: "Password",
                value: "$2a$12$XH0nQFMWL/F1ETeiLjuk2.R6wj1yxwYpNY1kwVz.WKUMClXBh5ZCK");

            migrationBuilder.UpdateData(
                table: "MainUser",
                keyColumn: "Id",
                keyValue: 1L,
                column: "Password",
                value: "$2a$12$HSltrVDHFyD31ahQJKb1B.ZV0XmDSZ/KO8JCehOLR7.4ZsNaode/y");

            migrationBuilder.UpdateData(
                table: "MainUser",
                keyColumn: "Id",
                keyValue: 2L,
                column: "Password",
                value: "$2a$12$2OETMDmiYtxUQ7rMQSF9F.PmgObQdM7RhxApZR1DBV9U/JJarY5CS");

            migrationBuilder.UpdateData(
                table: "MainUser",
                keyColumn: "Id",
                keyValue: 3L,
                column: "Password",
                value: "$2a$12$K3eDalC.OuQOgfyGPpniuebHZPifd12pdu9nBzsKTn5Icn40mpua.");

            migrationBuilder.UpdateData(
                table: "MainUser",
                keyColumn: "Id",
                keyValue: 4L,
                column: "Password",
                value: "$2a$12$KkrV9IQ.znILhQ89Xc4PjeDppfyDvknlPN6WESWEakIGL.Ot0LjeS");

            migrationBuilder.UpdateData(
                table: "MainUser",
                keyColumn: "Id",
                keyValue: 5L,
                column: "Password",
                value: "$2a$12$CKU3yyI6tdRKwta2GgEnQu8LcsBSW8PBbbXbMdehcAH.xm/tT.0ui");

            migrationBuilder.UpdateData(
                table: "MainUser",
                keyColumn: "Id",
                keyValue: 6L,
                column: "Password",
                value: "$2a$12$yTbiuUIgg3blsOtD.vTnluMtbltS8NAMt/D5dTBvOvnmSJTaA10uG");

            migrationBuilder.UpdateData(
                table: "SubDomainMaster",
                keyColumn: "Id",
                keyValue: 1L,
                column: "SubDomain",
                value: "localhost:4200");
        }
    }
}
