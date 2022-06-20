using Microsoft.EntityFrameworkCore.Migrations;

namespace HealthWare.ActiveASSIST.Repositories.Migrations
{
    public partial class householdScreenHeaderLabelSwaped : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "MainUser",
                keyColumn: "Id",
                keyValue: -1L,
                column: "Password",
                value: "$2a$12$mG4CqXuaHgNy6HhRLDZ3vO5TU5C8V8aZz1ZnaCzDEILf5Xwc6TBZy");

            migrationBuilder.UpdateData(
                table: "MainUser",
                keyColumn: "Id",
                keyValue: 1L,
                column: "Password",
                value: "$2a$12$TWAuQUUZzVaCkh0fT9tYaOSQjLK07vUhdyEi7798PinQYstzGTjta");

            migrationBuilder.UpdateData(
                table: "MainUser",
                keyColumn: "Id",
                keyValue: 2L,
                column: "Password",
                value: "$2a$12$/.7n2UAWMli82gaaQrhpr.VkuUqNqRNKEv/z6zM4QYIY4k7NzSo8q");

            migrationBuilder.UpdateData(
                table: "MainUser",
                keyColumn: "Id",
                keyValue: 3L,
                column: "Password",
                value: "$2a$12$Ouf3s3K2Xk5rq8efrXh2PumlflPNJdc2OaLJ8WGw5HDHDAdyetXjW");

            migrationBuilder.UpdateData(
                table: "MainUser",
                keyColumn: "Id",
                keyValue: 4L,
                column: "Password",
                value: "$2a$12$u.TakbC.swHB4./Y5EZXoeieXJvZyuQAIyktQu1aiDT99wY/mucBK");

            migrationBuilder.UpdateData(
                table: "MainUser",
                keyColumn: "Id",
                keyValue: 5L,
                column: "Password",
                value: "$2a$12$gkjWC4X2ilF.U5l0Due6oOfIgxTNze0LNo971AaYgmMdk0CEphKLW");

            migrationBuilder.UpdateData(
                table: "MainUser",
                keyColumn: "Id",
                keyValue: 6L,
                column: "Password",
                value: "$2a$12$l8Z2iWfjTe1ORZFHxkxUv./U4MOIRI9hePpu4qsf25LjWjm3du/9e");

            migrationBuilder.UpdateData(
                table: "QuickAssessmentQuestions",
                keyColumn: "Id",
                keyValue: 21L,
                columns: new[] { "ScreenHeaderOthersLabel", "ScreenHeaderPatientLabel" },
                values: new object[] { "Tell us more about patient's household", "Tell us about your household" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
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
                table: "QuickAssessmentQuestions",
                keyColumn: "Id",
                keyValue: 21L,
                columns: new[] { "ScreenHeaderOthersLabel", "ScreenHeaderPatientLabel" },
                values: new object[] { "Tell us about your household", "Tell us more about patient's household" });
        }
    }
}
