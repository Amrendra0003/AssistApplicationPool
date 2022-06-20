using Microsoft.EntityFrameworkCore.Migrations;

namespace HealthWare.ActiveASSIST.Repositories.Migrations
{
    public partial class validatorsQuickAssessemntIDChanged : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "MainUser",
                keyColumn: "Id",
                keyValue: -1L,
                column: "Password",
                value: "$2a$12$9mdhq172JKpFJ4irK2ypzuAKS6EqW7v2F1PhqojR4kBoARR4TYZCa");

            migrationBuilder.UpdateData(
                table: "MainUser",
                keyColumn: "Id",
                keyValue: 1L,
                column: "Password",
                value: "$2a$12$bW/SjtgTGovIlpjyLeOAU.OFQe0a/aWuzPYLeWA25hNojsHZAeubq");

            migrationBuilder.UpdateData(
                table: "MainUser",
                keyColumn: "Id",
                keyValue: 2L,
                column: "Password",
                value: "$2a$12$56ogH4jPhFDfS8TmJHjTV.27pdz2ozJ.38Cj9Ti9rDSRib8s4fg7K");

            migrationBuilder.UpdateData(
                table: "MainUser",
                keyColumn: "Id",
                keyValue: 3L,
                column: "Password",
                value: "$2a$12$iGd4whF8MgaMgRzsHawyC.NTYlHTgmxfzs7JK7E.AYu9zOCq8oNiK");

            migrationBuilder.UpdateData(
                table: "MainUser",
                keyColumn: "Id",
                keyValue: 4L,
                column: "Password",
                value: "$2a$12$6vMsbZn4gGK56ozwZD4SyuXURjc/zSBQ7F82I.rXYVlrEO/599Cme");

            migrationBuilder.UpdateData(
                table: "MainUser",
                keyColumn: "Id",
                keyValue: 5L,
                column: "Password",
                value: "$2a$12$K3Wz0x6Gu2CSWe5So4Kzee0lh6xDMAPhOBI.6kgipp932ewVi9Tve");

            migrationBuilder.UpdateData(
                table: "MainUser",
                keyColumn: "Id",
                keyValue: 6L,
                column: "Password",
                value: "$2a$12$Nu7jnkRXvhlRs.NvWiDmTOdR5CPhTW12cSNCMUhPZJxBq3iTeXfZ2");

            migrationBuilder.UpdateData(
                table: "Validators",
                keyColumn: "Id",
                keyValue: 34L,
                column: "QuickAssessmentQuestionsId",
                value: 35L);

            migrationBuilder.UpdateData(
                table: "Validators",
                keyColumn: "Id",
                keyValue: 35L,
                column: "QuickAssessmentQuestionsId",
                value: 36L);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "MainUser",
                keyColumn: "Id",
                keyValue: -1L,
                column: "Password",
                value: "$2a$12$sXa8d8L/U5YaM9CZ89FQhOddRuSSx36k3cdtjDgMY/5c1M94NCShu");

            migrationBuilder.UpdateData(
                table: "MainUser",
                keyColumn: "Id",
                keyValue: 1L,
                column: "Password",
                value: "$2a$12$uc5QP7Kt7KWarIN2hI2w2eeaJW3ApmnX7yDyxqf6XpPkIi8h004hm");

            migrationBuilder.UpdateData(
                table: "MainUser",
                keyColumn: "Id",
                keyValue: 2L,
                column: "Password",
                value: "$2a$12$I2i7zmrgR8j4Ju1fjzEVluX3vd3GKjC2aZyrtg3e7LgPjWk6U8d2q");

            migrationBuilder.UpdateData(
                table: "MainUser",
                keyColumn: "Id",
                keyValue: 3L,
                column: "Password",
                value: "$2a$12$Fp1LBnGNaiTkeKEgyfNb/eyqkP4V2wCIWQDxGjq7kgGdZDiNbs5.G");

            migrationBuilder.UpdateData(
                table: "MainUser",
                keyColumn: "Id",
                keyValue: 4L,
                column: "Password",
                value: "$2a$12$Y06mkKChTiYWYR/2updHKOCm8u.6JIZ0.m.i6pZuNSBC5RxEE3sBm");

            migrationBuilder.UpdateData(
                table: "MainUser",
                keyColumn: "Id",
                keyValue: 5L,
                column: "Password",
                value: "$2a$12$bSitp1Un4Epia4zUwW3zkO9khXA2MJeU183Arwa7xfBSXROMtikjO");

            migrationBuilder.UpdateData(
                table: "MainUser",
                keyColumn: "Id",
                keyValue: 6L,
                column: "Password",
                value: "$2a$12$kyEmU9hZWAp5GFvGGH22PuqrLoCx1G7poGriOlMCZwZh0IXsdqxia");

            migrationBuilder.UpdateData(
                table: "Validators",
                keyColumn: "Id",
                keyValue: 34L,
                column: "QuickAssessmentQuestionsId",
                value: 36L);

            migrationBuilder.UpdateData(
                table: "Validators",
                keyColumn: "Id",
                keyValue: 35L,
                column: "QuickAssessmentQuestionsId",
                value: 33L);
        }
    }
}
