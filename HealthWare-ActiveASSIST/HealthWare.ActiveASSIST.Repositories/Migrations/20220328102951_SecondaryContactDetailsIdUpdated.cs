using Microsoft.EntityFrameworkCore.Migrations;

namespace HealthWare.ActiveASSIST.Repositories.Migrations
{
    public partial class SecondaryContactDetailsIdUpdated : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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
                columns: new[] { "Password", "SecondaryEmailContactDetailsId" },
                values: new object[] { "$2a$12$qwkoHPvtA2o7HY.h2UFLvOMCCDKBS3.oiSIs8w85LeTXIloAVzrmm", 3L });

            migrationBuilder.UpdateData(
                table: "MainUser",
                keyColumn: "Id",
                keyValue: 2L,
                columns: new[] { "ContactDetailsId", "Password", "SecondaryEmailContactDetailsId" },
                values: new object[] { 4L, "$2a$12$foV1/IXTS64tJXSiz6Wc6.aFcWgKOuEiFM0pi/SRsRauHWR8a0RnS", 5L });

            migrationBuilder.UpdateData(
                table: "MainUser",
                keyColumn: "Id",
                keyValue: 3L,
                columns: new[] { "ContactDetailsId", "Password", "SecondaryEmailContactDetailsId" },
                values: new object[] { 6L, "$2a$12$hjIEkC/VDIh/sOeBPEsMqe0FKA1nwIyxWEKwbQ2MYmtY9dbx2UutG", 7L });

            migrationBuilder.UpdateData(
                table: "MainUser",
                keyColumn: "Id",
                keyValue: 4L,
                columns: new[] { "ContactDetailsId", "Password", "SecondaryEmailContactDetailsId" },
                values: new object[] { 8L, "$2a$12$SuyQLb248XwgCyqL0APLjuY/MzFt.fze7MIulUj0R9z1odKx5es0a", 9L });

            migrationBuilder.UpdateData(
                table: "MainUser",
                keyColumn: "Id",
                keyValue: 5L,
                columns: new[] { "ContactDetailsId", "Password", "SecondaryEmailContactDetailsId" },
                values: new object[] { 10L, "$2a$12$orjYYk68lzccBQvuMOlR2eVdWPrX6I0la5N3Ez4JHyYnYgBfMFlya", 11L });

            migrationBuilder.UpdateData(
                table: "MainUser",
                keyColumn: "Id",
                keyValue: 6L,
                columns: new[] { "ContactDetailsId", "Password", "SecondaryEmailContactDetailsId" },
                values: new object[] { 12L, "$2a$12$Flwza1mBe8ERXZ28zajXluF2YeRvVuEXnGN7J2EcGyi66uyKuc7Oq", 13L });

            migrationBuilder.UpdateData(
                table: "MainUser",
                keyColumn: "Id",
                keyValue: 7L,
                columns: new[] { "ContactDetailsId", "Password", "SecondaryEmailContactDetailsId" },
                values: new object[] { 14L, "$2a$12$rSewdU1OzPSTGt/w95J8E.4mVZXSL12XFtaqk64VqXUpakLm797M2", 15L });

            migrationBuilder.UpdateData(
                table: "MainUser",
                keyColumn: "Id",
                keyValue: 8L,
                columns: new[] { "ContactDetailsId", "Password", "SecondaryEmailContactDetailsId" },
                values: new object[] { 16L, "$2a$12$09AQjp0DxHfB5tL.aViGauUSTMSWYWNZpF.ToveE35DF2cxAkatqu", 17L });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "MainUser",
                keyColumn: "Id",
                keyValue: -1L,
                column: "Password",
                value: "$2a$12$Gycq4zhPuq7Hzi6PlmrnLeCk9FE8mACErnmA5V1ZOb4X7DmB0Bi1i");

            migrationBuilder.UpdateData(
                table: "MainUser",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "Password", "SecondaryEmailContactDetailsId" },
                values: new object[] { "$2a$12$Uw6zH.f3KRjh1no59umMSOB2tfCBeUObeIh1/RmlvmIAvjrf7SWd2", null });

            migrationBuilder.UpdateData(
                table: "MainUser",
                keyColumn: "Id",
                keyValue: 2L,
                columns: new[] { "ContactDetailsId", "Password", "SecondaryEmailContactDetailsId" },
                values: new object[] { 3L, "$2a$12$Yxlq.UByq.76TEIjjgdsuOMz3dwdkp4RdOruMlSjpRErSUzatGnAG", null });

            migrationBuilder.UpdateData(
                table: "MainUser",
                keyColumn: "Id",
                keyValue: 3L,
                columns: new[] { "ContactDetailsId", "Password", "SecondaryEmailContactDetailsId" },
                values: new object[] { 4L, "$2a$12$90R58oTvw59I9G25nJPwEetvyMpnEF6vUhrzGZD3sO965e.2F7GFG", null });

            migrationBuilder.UpdateData(
                table: "MainUser",
                keyColumn: "Id",
                keyValue: 4L,
                columns: new[] { "ContactDetailsId", "Password", "SecondaryEmailContactDetailsId" },
                values: new object[] { 5L, "$2a$12$83UCWmmFeeN/Z4Wv2k7aPejkZkq94X8O72J86pktKYm6B.siBkng.", null });

            migrationBuilder.UpdateData(
                table: "MainUser",
                keyColumn: "Id",
                keyValue: 5L,
                columns: new[] { "ContactDetailsId", "Password", "SecondaryEmailContactDetailsId" },
                values: new object[] { 6L, "$2a$12$xuHhyckdUAQpWvWBKm.fQef2WxSryk7h0C.yaRiymQEpG30L8/a/K", null });

            migrationBuilder.UpdateData(
                table: "MainUser",
                keyColumn: "Id",
                keyValue: 6L,
                columns: new[] { "ContactDetailsId", "Password", "SecondaryEmailContactDetailsId" },
                values: new object[] { 7L, "$2a$12$d0Wwd3kqe7dsuszbHl8Qk.MvfQbCZZrPjKzv0L4kQmhtLk6J6gUla", null });

            migrationBuilder.UpdateData(
                table: "MainUser",
                keyColumn: "Id",
                keyValue: 7L,
                columns: new[] { "ContactDetailsId", "Password", "SecondaryEmailContactDetailsId" },
                values: new object[] { 8L, "$2a$12$9sll62li40jumd5rr9rfIu6pMDfFTZw0zNOh7t6EEIIdwDZGGjonG", null });

            migrationBuilder.UpdateData(
                table: "MainUser",
                keyColumn: "Id",
                keyValue: 8L,
                columns: new[] { "ContactDetailsId", "Password", "SecondaryEmailContactDetailsId" },
                values: new object[] { 9L, "$2a$12$2aKhWoikoBdpEiC58451I.K1bh8bowbwDYxTNtrMNdVM3UR/tRtVy", null });
        }
    }
}
