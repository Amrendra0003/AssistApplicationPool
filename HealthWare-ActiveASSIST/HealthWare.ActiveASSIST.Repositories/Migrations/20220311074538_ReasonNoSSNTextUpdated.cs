using Microsoft.EntityFrameworkCore.Migrations;

namespace HealthWare.ActiveASSIST.Repositories.Migrations
{
    public partial class ReasonNoSSNTextUpdated : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "MainUser",
                keyColumn: "Id",
                keyValue: -1L,
                column: "Password",
                value: "$2a$12$qaDE4Px3voEr5XIq8D404OZSRTNkegbCoilVXsohoJPKDiF61DuFe");

            migrationBuilder.UpdateData(
                table: "MainUser",
                keyColumn: "Id",
                keyValue: 1L,
                column: "Password",
                value: "$2a$12$jLz7Vim5AKaV1t.HhERKfef0ckKQaqoxMnKE1E1UQKmvxZFDbYSSC");

            migrationBuilder.UpdateData(
                table: "MainUser",
                keyColumn: "Id",
                keyValue: 2L,
                column: "Password",
                value: "$2a$12$1aNwEYEC1JFLICSe2c4lLenOXHkbN8jQw02ZHMNpjABQHpk9UGeI.");

            migrationBuilder.UpdateData(
                table: "MainUser",
                keyColumn: "Id",
                keyValue: 3L,
                column: "Password",
                value: "$2a$12$nULZBsMikEbRj/gwyb/BweMlh5x.LPCQc8RkfBPAgglpQYGyn1ucq");

            migrationBuilder.UpdateData(
                table: "MainUser",
                keyColumn: "Id",
                keyValue: 4L,
                column: "Password",
                value: "$2a$12$5jKSLDUXgL4AaJVtOiLZ4..M/2.ua3d/RdPWISJdYzponJ8JhnYzW");

            migrationBuilder.UpdateData(
                table: "MainUser",
                keyColumn: "Id",
                keyValue: 5L,
                column: "Password",
                value: "$2a$12$rHTbNcij90fD.zw/ke7V3Oye8a9KXXXM3wpxwCip9j8zBC1UuWRCK");

            migrationBuilder.UpdateData(
                table: "MainUser",
                keyColumn: "Id",
                keyValue: 6L,
                column: "Password",
                value: "$2a$12$wKzP2CJvhPGglAO6C0jsAeWnZGd8CROmmlqsAzU8uEwRrn7h7DVXO");

            migrationBuilder.UpdateData(
                table: "QuickAssessmentQuestions",
                keyColumn: "Id",
                keyValue: 37L,
                column: "Placeholder",
                value: "Reason No SSN");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "MainUser",
                keyColumn: "Id",
                keyValue: -1L,
                column: "Password",
                value: "$2a$12$iyaIHvJpObHRlGOu297.Lu3cIE.ARwDABZaTV.e9lT0voAINC4J0.");

            migrationBuilder.UpdateData(
                table: "MainUser",
                keyColumn: "Id",
                keyValue: 1L,
                column: "Password",
                value: "$2a$12$.UFTmlVyLImbToSicWX3GOUgwQ0Apucf9tWBkxK4PjIrPyTF3EWlS");

            migrationBuilder.UpdateData(
                table: "MainUser",
                keyColumn: "Id",
                keyValue: 2L,
                column: "Password",
                value: "$2a$12$XVDVdr4aJoq7kKy994ZWKOAlhjyDuCZ.sH7WPanWSXfLk.SEvoNWu");

            migrationBuilder.UpdateData(
                table: "MainUser",
                keyColumn: "Id",
                keyValue: 3L,
                column: "Password",
                value: "$2a$12$PwWjP/VRsjvkTAGAgUFcReBpHz6qHeW5imKgn.JdMhH9oBxjSkxh.");

            migrationBuilder.UpdateData(
                table: "MainUser",
                keyColumn: "Id",
                keyValue: 4L,
                column: "Password",
                value: "$2a$12$anGxhsC65c5nikHnmfCBS.gII.502vpQOW76lMpsSKwXT8MKMuwge");

            migrationBuilder.UpdateData(
                table: "MainUser",
                keyColumn: "Id",
                keyValue: 5L,
                column: "Password",
                value: "$2a$12$uihUNcEsNVeNFP.kdUyyMudJRu21hPsZjATD.PpZOwlGNOVkhEJry");

            migrationBuilder.UpdateData(
                table: "MainUser",
                keyColumn: "Id",
                keyValue: 6L,
                column: "Password",
                value: "$2a$12$y.eFLfYkh3vu8/N8rMiG2.fbdE3d1dDx8stg9vnB.idZSASd4EquG");

            migrationBuilder.UpdateData(
                table: "QuickAssessmentQuestions",
                keyColumn: "Id",
                keyValue: 37L,
                column: "Placeholder",
                value: "Reason no SSN");
        }
    }
}
