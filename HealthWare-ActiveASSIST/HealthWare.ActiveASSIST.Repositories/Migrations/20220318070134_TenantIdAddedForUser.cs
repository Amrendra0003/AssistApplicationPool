using Microsoft.EntityFrameworkCore.Migrations;

namespace HealthWare.ActiveASSIST.Repositories.Migrations
{
    public partial class TenantIdAddedForUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "MainUser",
                keyColumn: "Id",
                keyValue: -1L,
                column: "Password",
                value: "$2a$12$fI6O93COiQbSwpNjLLBHuuOxY/TjB8DBdM4ztvsWsBj.PgSYlQEEC");

            migrationBuilder.UpdateData(
                table: "MainUser",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "Password", "TenantId" },
                values: new object[] { "$2a$12$6m4Sgl3MWRlh7A0ACyUuWeVS6dKr0Xsq3CFy9iMH8imi3HbMqmapa", "1" });

            migrationBuilder.UpdateData(
                table: "MainUser",
                keyColumn: "Id",
                keyValue: 2L,
                columns: new[] { "Password", "TenantId" },
                values: new object[] { "$2a$12$gOikRQDtEHFYW0WCd08hReb5gd9BihPeIu7.OQz6yoeFlGeGdkHlS", "1" });

            migrationBuilder.UpdateData(
                table: "MainUser",
                keyColumn: "Id",
                keyValue: 3L,
                columns: new[] { "Password", "TenantId" },
                values: new object[] { "$2a$12$nUcBkg8scyerr4C2D67onOVWuwXpyMWDADuMl8LX1mhrpAoo6WGRi", "1" });

            migrationBuilder.UpdateData(
                table: "MainUser",
                keyColumn: "Id",
                keyValue: 4L,
                columns: new[] { "Password", "TenantId" },
                values: new object[] { "$2a$12$yaG2Cgy6Wnv.bmrgVog1u.xAxUt8evgzI6XUWwTGycFROeqCV.YAO", "1" });

            migrationBuilder.UpdateData(
                table: "MainUser",
                keyColumn: "Id",
                keyValue: 5L,
                columns: new[] { "Password", "TenantId" },
                values: new object[] { "$2a$12$vGh9YvVEU8hox8/kZk7gCu2ZSE0GBRTglDqQs0o0.Olq6dtSMeCiO", "1" });

            migrationBuilder.UpdateData(
                table: "MainUser",
                keyColumn: "Id",
                keyValue: 6L,
                columns: new[] { "Password", "TenantId" },
                values: new object[] { "$2a$12$cmisrdi/wc1tcrBrrM7QYOXfiMa3xqY57gUast8jD08RRQvrlCoTa", "1" });

            migrationBuilder.UpdateData(
                table: "MainUser",
                keyColumn: "Id",
                keyValue: 7L,
                columns: new[] { "Password", "TenantId" },
                values: new object[] { "$2a$12$MbivJuHamV5CrwKOLKZztuarA/kDqH2WHL4jgyJoMivUayUgHx0.6", "3" });

            migrationBuilder.UpdateData(
                table: "MainUser",
                keyColumn: "Id",
                keyValue: 8L,
                columns: new[] { "Password", "TenantId" },
                values: new object[] { "$2a$12$jAAxa8C3uL.ameoL5BElFuFWcGRCkSKkkIy3XjRtKyqWHsrlV9j7u", "3" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "MainUser",
                keyColumn: "Id",
                keyValue: -1L,
                column: "Password",
                value: "$2a$12$ykMKtsIXRYTR6r6DEbk8AOprJjXf1Kbsj8vfKSCNOH0z4WNXHGkqC");

            migrationBuilder.UpdateData(
                table: "MainUser",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "Password", "TenantId" },
                values: new object[] { "$2a$12$jrxy7hJAQu4Nakbz/Tu9eOCotx8DaJgwguhQjKdHrhBUiykXlnGvG", null });

            migrationBuilder.UpdateData(
                table: "MainUser",
                keyColumn: "Id",
                keyValue: 2L,
                columns: new[] { "Password", "TenantId" },
                values: new object[] { "$2a$12$lqG0uKh7QKnr32WipUTFvuJuv6oh154qhtEv1nFxFkGAq6s28bDqS", null });

            migrationBuilder.UpdateData(
                table: "MainUser",
                keyColumn: "Id",
                keyValue: 3L,
                columns: new[] { "Password", "TenantId" },
                values: new object[] { "$2a$12$Bn3IBX/1kwcm8pqnjHgG6.IipF.KUkLjCHkCJkwvktBd9o9lKV6WK", null });

            migrationBuilder.UpdateData(
                table: "MainUser",
                keyColumn: "Id",
                keyValue: 4L,
                columns: new[] { "Password", "TenantId" },
                values: new object[] { "$2a$12$MA2/FG.rnpGHtWL0QUxB3u2sjZ4vZ3yw3pEYDYROdz2ZAyzOp9Ove", null });

            migrationBuilder.UpdateData(
                table: "MainUser",
                keyColumn: "Id",
                keyValue: 5L,
                columns: new[] { "Password", "TenantId" },
                values: new object[] { "$2a$12$ObMDMUfat46..49hiMR67OLW6UUS5q242QiTUSRyJ5gFV1S2MSs/.", null });

            migrationBuilder.UpdateData(
                table: "MainUser",
                keyColumn: "Id",
                keyValue: 6L,
                columns: new[] { "Password", "TenantId" },
                values: new object[] { "$2a$12$fPImBtkUfmHqiMayLY.zmOcwuMdLpyRYOEPowNHI.7/XSfx4x1/iS", null });

            migrationBuilder.UpdateData(
                table: "MainUser",
                keyColumn: "Id",
                keyValue: 7L,
                columns: new[] { "Password", "TenantId" },
                values: new object[] { "$2a$12$4zx.8ATdP8DHOk/vNAeW0OtrLKCs0n8ACaRZMp6zMyfjPywSn.Svq", null });

            migrationBuilder.UpdateData(
                table: "MainUser",
                keyColumn: "Id",
                keyValue: 8L,
                columns: new[] { "Password", "TenantId" },
                values: new object[] { "$2a$12$hQRLjkxQfz.Ydq5JlC9Zq.4dGSxjLCoAR4KwZlBvecA.2gq/4PwNu", null });
        }
    }
}
