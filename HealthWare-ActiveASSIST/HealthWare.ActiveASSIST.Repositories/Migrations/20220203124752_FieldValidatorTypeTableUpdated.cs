using Microsoft.EntityFrameworkCore.Migrations;

namespace HealthWare.ActiveASSIST.Repositories.Migrations
{
    public partial class FieldValidatorTypeTableUpdated : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "FieldValidatorType",
                keyColumn: "Id",
                keyValue: 10L,
                columns: new[] { "Name", "Type" },
                values: new object[] { "Date", "^(0?[1-9]|1[0-2])\\/(0?[1-9]|1\\d|2\\d|3[01])\\/(19|20)\\d{2}$" });

            migrationBuilder.UpdateData(
                table: "MainUser",
                keyColumn: "Id",
                keyValue: -1L,
                column: "Password",
                value: "$2a$12$nofBZ.Iv/lHPMST3U1RzUeWX5LSvpo981wgtz21GDN1UlNGCsE24u");

            migrationBuilder.UpdateData(
                table: "MainUser",
                keyColumn: "Id",
                keyValue: 1L,
                column: "Password",
                value: "$2a$12$5s45pXB6HMlCdYdl5UT.0OB1/UJrdJB77KM2pe0.XM1mkb5Tz83Jm");

            migrationBuilder.UpdateData(
                table: "MainUser",
                keyColumn: "Id",
                keyValue: 2L,
                column: "Password",
                value: "$2a$12$qrvhIgEzj0umjAx8.cuptucIkj5nZVU5tzXs73.f4wZDTZA0sBNPy");

            migrationBuilder.UpdateData(
                table: "MainUser",
                keyColumn: "Id",
                keyValue: 3L,
                column: "Password",
                value: "$2a$12$WCvPlm6/va09Nx41HFSoGeVuXXEeJumEA1eEKDygqk9BwrROeyYqK");

            migrationBuilder.UpdateData(
                table: "MainUser",
                keyColumn: "Id",
                keyValue: 4L,
                column: "Password",
                value: "$2a$12$w/edUduru6MHc8WelqM4duhLx1PYDmK2JlkWaor2WYw1EVCPT2/Ja");

            migrationBuilder.UpdateData(
                table: "MainUser",
                keyColumn: "Id",
                keyValue: 5L,
                column: "Password",
                value: "$2a$12$ZL06NomgbdsLZ/I3bv1lyedwSfSYMXpscTIc9T4wPhO90bt0xDT7i");

            migrationBuilder.UpdateData(
                table: "MainUser",
                keyColumn: "Id",
                keyValue: 6L,
                column: "Password",
                value: "$2a$12$z00kK/Kilg3KOgmkDQlANuDxtzp/Qw5GFrH5FMFX2AGlcvOJwJ0Tu");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "FieldValidatorType",
                keyColumn: "Id",
                keyValue: 10L,
                columns: new[] { "Name", "Type" },
                values: new object[] { "^(0?[1-9]|1[0-2])\\/(0?[1-9]|1\\d|2\\d|3[01])\\/(19|20)\\d{2}$", "^[a-zA-Z0-9]+$" });

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
        }
    }
}
