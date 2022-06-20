using Microsoft.EntityFrameworkCore.Migrations;

namespace HealthWare.ActiveASSIST.Repositories.Migrations
{
    public partial class middleNameRequiredFalseAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "MainUser",
                keyColumn: "Id",
                keyValue: -1L,
                column: "Password",
                value: "$2a$12$FRfWiAn2Q8mAnSkW6VmywOJ12Z/xBUJRB048nHmBTPq85G.3ysfai");

            migrationBuilder.UpdateData(
                table: "MainUser",
                keyColumn: "Id",
                keyValue: 1L,
                column: "Password",
                value: "$2a$12$zjkqouVGnze3K/St0pqtFuCfAzcUy1m5UWiZ3h6Bl8kA7H6Yll0je");

            migrationBuilder.UpdateData(
                table: "MainUser",
                keyColumn: "Id",
                keyValue: 2L,
                column: "Password",
                value: "$2a$12$JJ2eFLX9np23NIubJru6Qeup5mk3OIRa35fLX4tS/SbcpTNppzZXq");

            migrationBuilder.UpdateData(
                table: "MainUser",
                keyColumn: "Id",
                keyValue: 3L,
                column: "Password",
                value: "$2a$12$FPPSqZHO.6VCxw4G9SbZ6.YmQ43oNov3YnySnQ8vfChXuKMnlwOmq");

            migrationBuilder.UpdateData(
                table: "MainUser",
                keyColumn: "Id",
                keyValue: 4L,
                column: "Password",
                value: "$2a$12$RiCTTQ0SBpT.udVlGkMYh.MDbzUZ0xCsIFtPEGNBb2knD46yO5C7C");

            migrationBuilder.UpdateData(
                table: "MainUser",
                keyColumn: "Id",
                keyValue: 5L,
                column: "Password",
                value: "$2a$12$zO5fij5awvuxqufTC.dlI.iGN/sbBqtT8DkeGqkypCbWi7HjGkDvS");

            migrationBuilder.UpdateData(
                table: "MainUser",
                keyColumn: "Id",
                keyValue: 6L,
                column: "Password",
                value: "$2a$12$a1hJ932O4y3mLsKPVEtgs.WmSkYsMW4hnMUi2HTqfOK08CGbA0/vO");

            migrationBuilder.UpdateData(
                table: "Question",
                keyColumn: "Id",
                keyValue: 38L,
                column: "IsRequired",
                value: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "MainUser",
                keyColumn: "Id",
                keyValue: -1L,
                column: "Password",
                value: "$2a$12$cvJdPAw/Sjd0lfNNQ4uyAe7xo/zbJSPGx9ntUrRHT41VFhYmBDR0q");

            migrationBuilder.UpdateData(
                table: "MainUser",
                keyColumn: "Id",
                keyValue: 1L,
                column: "Password",
                value: "$2a$12$58VPyCC0KP6ElGm0pN7/J.13wpT5oNcswZCYcePf1ZyhwvD2ZY.4i");

            migrationBuilder.UpdateData(
                table: "MainUser",
                keyColumn: "Id",
                keyValue: 2L,
                column: "Password",
                value: "$2a$12$r1eZmWX6egc.sJtwmUTBIeP6xXqGmbTNrOnGW/SkFljBzqQSP8uLy");

            migrationBuilder.UpdateData(
                table: "MainUser",
                keyColumn: "Id",
                keyValue: 3L,
                column: "Password",
                value: "$2a$12$gHdeoKUP/fJw/8Jocqmyzu773Y5SzYbYChjni12mIuMu0vhjEoLtm");

            migrationBuilder.UpdateData(
                table: "MainUser",
                keyColumn: "Id",
                keyValue: 4L,
                column: "Password",
                value: "$2a$12$tKb00L.R5RFlSOv9YmMN/eaNg8qQ8T18ryLtynjsdaMiPSWWUy0A2");

            migrationBuilder.UpdateData(
                table: "MainUser",
                keyColumn: "Id",
                keyValue: 5L,
                column: "Password",
                value: "$2a$12$SXz9kaKchxkAY07/i6OEfOgO9cokXeZtv.RUB9ltoloIF5AjqkqvO");

            migrationBuilder.UpdateData(
                table: "MainUser",
                keyColumn: "Id",
                keyValue: 6L,
                column: "Password",
                value: "$2a$12$o8XMIEpY5opAToiYiE659ufe1XoTF7znBeotJ7pf/T6CZkXxcUB56");

            migrationBuilder.UpdateData(
                table: "Question",
                keyColumn: "Id",
                keyValue: 38L,
                column: "IsRequired",
                value: true);
        }
    }
}
