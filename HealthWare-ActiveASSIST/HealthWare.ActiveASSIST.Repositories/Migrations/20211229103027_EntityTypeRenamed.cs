using Microsoft.EntityFrameworkCore.Migrations;

namespace HealthWare.ActiveASSIST.Repositories.Migrations
{
    public partial class EntityTypeRenamed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "ContactTypeMaster",
                keyColumn: "Id",
                keyValue: 7L,
                column: "EntityType",
                value: "Household Member");

            migrationBuilder.UpdateData(
                table: "ContactTypeMaster",
                keyColumn: "Id",
                keyValue: 9L,
                column: "EntityType",
                value: "User Profile");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: -1L,
                column: "Password",
                value: "$2a$12$CzjXGGvEtr8CS5rlVWNS7.vN/j7KgoASYR0JH..ftLoAsyFI9S4oC");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1L,
                column: "Password",
                value: "$2a$12$0py/F59VWnYxZNDelrXjtuTBSumUClEsPaZp2jyNzXTnSLT4NZiQC");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2L,
                column: "Password",
                value: "$2a$12$dDIhJsBrRwnHXO9tCV4n.umuH02n.q/VsJApM6gnwxrBM8e7okVIO");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3L,
                column: "Password",
                value: "$2a$12$304oa4/tr/vgq4JdDTKRYuiwBHguGGPU8Ok2B5wVmeyC5NvFZQoaG");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 4L,
                column: "Password",
                value: "$2a$12$27BZoBtbZ.qzCTq6KuFkCey/4wdeaDFdQ7lhKzPiSk8XWIutr5l46");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 5L,
                column: "Password",
                value: "$2a$12$SFPnpbryu4ShfFVxEsA/5eEBw4cPpFZBdMWfbRWcDhrXVK37eTn2m");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 6L,
                column: "Password",
                value: "$2a$12$HU69HYycfBC2T0atWOOlROs/3c2WhyxAqnj0kaEDM0n1c/Fi3Meum");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "ContactTypeMaster",
                keyColumn: "Id",
                keyValue: 7L,
                column: "EntityType",
                value: "HouseHoldMember");

            migrationBuilder.UpdateData(
                table: "ContactTypeMaster",
                keyColumn: "Id",
                keyValue: 9L,
                column: "EntityType",
                value: "UserProfile");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: -1L,
                column: "Password",
                value: "$2a$12$CJ9lkR.MbnwOqGcDQ.qNu.xLGxylavVqsRszedOCYGVAWlL2ggXVG");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1L,
                column: "Password",
                value: "$2a$12$lMrhEkDQJOFw4BEfG0mCtO12WtIZiMbSixFyMnbkhdmPT1hnODGGC");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2L,
                column: "Password",
                value: "$2a$12$eEvQhkiJxeS2tZS1S060yeB1Dlpzpm.e/qOSpJDDOfW7uTemMf7VS");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3L,
                column: "Password",
                value: "$2a$12$AwObjAP.ofpDnefuZ9wwBOROu1Q7I1f.wWdg4NCSctiS6xvF/vAIm");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 4L,
                column: "Password",
                value: "$2a$12$LtJLALh8WHtif./3.zcmFedeE.P1JhRg3NW.EoUdLqQtbodVQQlyG");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 5L,
                column: "Password",
                value: "$2a$12$p52oxbz6AJOfMKqIdDa8u.bK17xic3xEMAIwA2Pa6bWF8qhUhSisu");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 6L,
                column: "Password",
                value: "$2a$12$1JWC.dpRqjaYuuP2NY5MTO3DvhoLDiOp605LiNh74b/Mzu5xxPvFi");
        }
    }
}
