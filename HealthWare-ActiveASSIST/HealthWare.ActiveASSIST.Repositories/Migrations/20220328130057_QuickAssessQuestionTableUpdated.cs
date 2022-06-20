using Microsoft.EntityFrameworkCore.Migrations;

namespace HealthWare.ActiveASSIST.Repositories.Migrations
{
    public partial class QuickAssessQuestionTableUpdated : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "MainUser",
                keyColumn: "Id",
                keyValue: -1L,
                column: "Password",
                value: "$2a$12$jUNQZW64cwWVO.f7NHuL7uHxgG/6mFvjpANvv25a/dGBj9iF2FUjG");

            migrationBuilder.UpdateData(
                table: "MainUser",
                keyColumn: "Id",
                keyValue: 1L,
                column: "Password",
                value: "$2a$12$DWvJFeogot.Yll8XdL5v..sPPyd563BoAKn/caKSsPYn5J069yl1q");

            migrationBuilder.UpdateData(
                table: "MainUser",
                keyColumn: "Id",
                keyValue: 2L,
                column: "Password",
                value: "$2a$12$P/czZVF7UaJhTyYonsGwruXxcIezCUDQ5gQKS6jY.9cojjHd.MKP6");

            migrationBuilder.UpdateData(
                table: "MainUser",
                keyColumn: "Id",
                keyValue: 3L,
                column: "Password",
                value: "$2a$12$swMoUfdGDy4tUTLBXhtlV.LcjCXaUInA4ZeaFk53yB0gGOQCE4FIm");

            migrationBuilder.UpdateData(
                table: "MainUser",
                keyColumn: "Id",
                keyValue: 4L,
                column: "Password",
                value: "$2a$12$zEn6P9yml2WHyQmsHqEb3ec6mmXytrG58vaCoOSrAZhqOSceqi6P6");

            migrationBuilder.UpdateData(
                table: "MainUser",
                keyColumn: "Id",
                keyValue: 5L,
                column: "Password",
                value: "$2a$12$ze9UPZoXvDM3nfzfqYtuo.mFV06a8vrPPj73J2t52d3R6VYPZmHFu");

            migrationBuilder.UpdateData(
                table: "MainUser",
                keyColumn: "Id",
                keyValue: 6L,
                column: "Password",
                value: "$2a$12$.B9m7j0iO4UoKcjj66bsUuurh/xr7Knv8VGPSWzcpOr/OKRr5KIhC");

            migrationBuilder.UpdateData(
                table: "MainUser",
                keyColumn: "Id",
                keyValue: 7L,
                column: "Password",
                value: "$2a$12$eutGhDyM2X2KQZ/f/WDeduleTqZqQF8lIMFNa047RtNUxjVIkTJgu");

            migrationBuilder.UpdateData(
                table: "MainUser",
                keyColumn: "Id",
                keyValue: 8L,
                column: "Password",
                value: "$2a$12$lHILNL24z0qWqa6cbBIQPOzMZxs9RYHwcEHdg3IwLZrlY.J7KsmdS");

            migrationBuilder.UpdateData(
                table: "QuickAssessmentQuestions",
                keyColumn: "Id",
                keyValue: 23L,
                column: "CustomValidation",
                value: null);

            migrationBuilder.UpdateData(
                table: "QuickAssessmentQuestions",
                keyColumn: "Id",
                keyValue: 24L,
                columns: new[] { "CustomValidation", "ParentQuestionId" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "QuickAssessmentQuestions",
                keyColumn: "Id",
                keyValue: 25L,
                column: "ParentQuestionId",
                value: null);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "MainUser",
                keyColumn: "Id",
                keyValue: -1L,
                column: "Password",
                value: "$2a$12$sB63ioD.99vIurpj12nKduA/J36bpACZYGuDzXWKzwSbIfOcF/kDa");

            migrationBuilder.UpdateData(
                table: "MainUser",
                keyColumn: "Id",
                keyValue: 1L,
                column: "Password",
                value: "$2a$12$qwkoHPvtA2o7HY.h2UFLvOMCCDKBS3.oiSIs8w85LeTXIloAVzrmm");

            migrationBuilder.UpdateData(
                table: "MainUser",
                keyColumn: "Id",
                keyValue: 2L,
                column: "Password",
                value: "$2a$12$foV1/IXTS64tJXSiz6Wc6.aFcWgKOuEiFM0pi/SRsRauHWR8a0RnS");

            migrationBuilder.UpdateData(
                table: "MainUser",
                keyColumn: "Id",
                keyValue: 3L,
                column: "Password",
                value: "$2a$12$hjIEkC/VDIh/sOeBPEsMqe0FKA1nwIyxWEKwbQ2MYmtY9dbx2UutG");

            migrationBuilder.UpdateData(
                table: "MainUser",
                keyColumn: "Id",
                keyValue: 4L,
                column: "Password",
                value: "$2a$12$SuyQLb248XwgCyqL0APLjuY/MzFt.fze7MIulUj0R9z1odKx5es0a");

            migrationBuilder.UpdateData(
                table: "MainUser",
                keyColumn: "Id",
                keyValue: 5L,
                column: "Password",
                value: "$2a$12$orjYYk68lzccBQvuMOlR2eVdWPrX6I0la5N3Ez4JHyYnYgBfMFlya");

            migrationBuilder.UpdateData(
                table: "MainUser",
                keyColumn: "Id",
                keyValue: 6L,
                column: "Password",
                value: "$2a$12$Flwza1mBe8ERXZ28zajXluF2YeRvVuEXnGN7J2EcGyi66uyKuc7Oq");

            migrationBuilder.UpdateData(
                table: "MainUser",
                keyColumn: "Id",
                keyValue: 7L,
                column: "Password",
                value: "$2a$12$rSewdU1OzPSTGt/w95J8E.4mVZXSL12XFtaqk64VqXUpakLm797M2");

            migrationBuilder.UpdateData(
                table: "MainUser",
                keyColumn: "Id",
                keyValue: 8L,
                column: "Password",
                value: "$2a$12$09AQjp0DxHfB5tL.aViGauUSTMSWYWNZpF.ToveE35DF2cxAkatqu");

            migrationBuilder.UpdateData(
                table: "QuickAssessmentQuestions",
                keyColumn: "Id",
                keyValue: 23L,
                column: "CustomValidation",
                value: "Yes/No");

            migrationBuilder.UpdateData(
                table: "QuickAssessmentQuestions",
                keyColumn: "Id",
                keyValue: 24L,
                columns: new[] { "CustomValidation", "ParentQuestionId" },
                values: new object[] { "Yes", 23L });

            migrationBuilder.UpdateData(
                table: "QuickAssessmentQuestions",
                keyColumn: "Id",
                keyValue: 25L,
                column: "ParentQuestionId",
                value: 24L);
        }
    }
}
