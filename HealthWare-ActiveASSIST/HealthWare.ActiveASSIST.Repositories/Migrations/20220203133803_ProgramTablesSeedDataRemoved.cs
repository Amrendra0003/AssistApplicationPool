using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace HealthWare.ActiveASSIST.Repositories.Migrations
{
    public partial class ProgramTablesSeedDataRemoved : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Program",
                keyColumn: "Id",
                keyValue: 5L);

            migrationBuilder.DeleteData(
                table: "Program",
                keyColumn: "Id",
                keyValue: 6L);

            migrationBuilder.DeleteData(
                table: "ProgramDocument",
                keyColumn: "Id",
                keyValue: 1L);

            migrationBuilder.DeleteData(
                table: "ProgramDocument",
                keyColumn: "Id",
                keyValue: 2L);

            migrationBuilder.DeleteData(
                table: "ProgramDocument",
                keyColumn: "Id",
                keyValue: 3L);

            migrationBuilder.DeleteData(
                table: "ProgramDocument",
                keyColumn: "Id",
                keyValue: 4L);

            migrationBuilder.DeleteData(
                table: "ProgramDocument",
                keyColumn: "Id",
                keyValue: 5L);

            migrationBuilder.DeleteData(
                table: "ProgramDocument",
                keyColumn: "Id",
                keyValue: 6L);

            migrationBuilder.DeleteData(
                table: "ProgramDocument",
                keyColumn: "Id",
                keyValue: 7L);

            migrationBuilder.DeleteData(
                table: "Program",
                keyColumn: "Id",
                keyValue: 1L);

            migrationBuilder.DeleteData(
                table: "Program",
                keyColumn: "Id",
                keyValue: 2L);

            migrationBuilder.DeleteData(
                table: "Program",
                keyColumn: "Id",
                keyValue: 3L);

            migrationBuilder.DeleteData(
                table: "Program",
                keyColumn: "Id",
                keyValue: 4L);

            migrationBuilder.DropColumn(
                name: "DocumentPath",
                table: "ProgramDocument");

            migrationBuilder.DropColumn(
                name: "ProgramSummary",
                table: "PatientProgramMapping");

            migrationBuilder.RenameColumn(
                name: "DocumentSize",
                table: "ProgramDocument",
                newName: "FormLocation");

            migrationBuilder.AddColumn<bool>(
                name: "ESignFlag",
                table: "ProgramDocument",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "BenefitsDescriptionUrl",
                table: "Program",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsEvaluated",
                table: "PatientProgramMapping",
                type: "bit",
                nullable: false,
                defaultValue: false);

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ESignFlag",
                table: "ProgramDocument");

            migrationBuilder.DropColumn(
                name: "BenefitsDescriptionUrl",
                table: "Program");

            migrationBuilder.DropColumn(
                name: "IsEvaluated",
                table: "PatientProgramMapping");

            migrationBuilder.RenameColumn(
                name: "FormLocation",
                table: "ProgramDocument",
                newName: "DocumentSize");

            migrationBuilder.AddColumn<string>(
                name: "DocumentPath",
                table: "ProgramDocument",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ProgramSummary",
                table: "PatientProgramMapping",
                type: "nvarchar(max)",
                nullable: true);

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

            migrationBuilder.InsertData(
                table: "Program",
                columns: new[] { "Id", "CreatedBy", "CreatedDate", "Details", "Name", "UpdatedBy", "UpdatedDate" },
                values: new object[,]
                {
                    { 1L, null, new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur", "Veteran Administration (VA)", null, null },
                    { 2L, null, new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur", "Memorial Hospital Financial Assistance", null, null },
                    { 3L, null, new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur", "Senior Citizens Assistance", null, null },
                    { 4L, null, new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur", "TX Crime Victim", null, null },
                    { 5L, null, new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur", "Aid and Attendance", null, null },
                    { 6L, null, new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur", "Program 1", null, null }
                });

            migrationBuilder.InsertData(
                table: "ProgramDocument",
                columns: new[] { "Id", "CreatedBy", "CreatedDate", "DocumentDescription", "DocumentName", "DocumentPath", "DocumentSize", "ProgramId", "UpdatedBy", "UpdatedDate" },
                values: new object[,]
                {
                    { 1L, null, new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur", "147 Form VA Form 9 Veterans Appeals", "C:\\inetpub\\wwwroot\\Healthware_ProgramFiles\\1\\147_Form_VA_Form_9_Veterans_Appeals.pdf", null, 1L, null, null },
                    { 2L, null, new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur", "140 Form MO Crime Victim Application", "C:\\inetpub\\wwwroot\\Healthware_ProgramFiles\\2\\4\\147_Form_VA_Form_9_Veterans_Appeals.pdf", null, 2L, null, null },
                    { 3L, null, new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur", "134 Form MO IM60A Doctor Medical Statement", "C:\\inetpub\\wwwroot\\Healthware_ProgramFiles\\2\\5\\147_Form_VA_Form_9_Veterans_Appeals.pdf", null, 2L, null, null },
                    { 4L, null, new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur", "138 Form MO IM60A Doctor Medical Statement", "C:\\inetpub\\wwwroot\\Healthware_ProgramFiles\\3\\6\\147_Form_VA_Form_9_Veterans_Appeals.pdf", null, 3L, null, null },
                    { 5L, null, new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur", "137 Form MO IM60A Doctor Medical Statement", "C:\\inetpub\\wwwroot\\Healthware_ProgramFiles\\7\\3\\147_Form_VA_Form_9_Veterans_Appeals.pdf", null, 3L, null, null },
                    { 6L, null, new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur", "136 Form MO IM60A Doctor Medical Statement", "C:\\inetpub\\wwwroot\\Healthware_ProgramFiles\\4\\8\\147_Form_VA_Form_9_Veterans_Appeals.pdf", null, 4L, null, null },
                    { 7L, null, new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur", "135 Form MO IM60A Doctor Medical Statement", "C:\\inetpub\\wwwroot\\Healthware_ProgramFiles\\4\\9\\147_Form_VA_Form_9_Veterans_Appeals.pdf", null, 4L, null, null }
                });
        }
    }
}
