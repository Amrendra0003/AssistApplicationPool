using Microsoft.EntityFrameworkCore.Migrations;

namespace HealthWare.ActiveASSIST.Repositories.Migrations
{
    public partial class addNewColumnCountyCode : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CountyCode",
                table: "TenantDetails",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "MainUser",
                keyColumn: "Id",
                keyValue: -1L,
                column: "Password",
                value: "$2a$12$gkU3PlU3Vyvp4DilKovlZuF3Yb.JcWqZ1tf9HydS8AGWBo1oTqp1u");

            migrationBuilder.UpdateData(
                table: "MainUser",
                keyColumn: "Id",
                keyValue: 1L,
                column: "Password",
                value: "$2a$12$GzaaZvReWd7EK/fT.JlPu.7GfnxCCQiQDbfau.04dkxffdAt2NdCS");

            migrationBuilder.UpdateData(
                table: "MainUser",
                keyColumn: "Id",
                keyValue: 2L,
                column: "Password",
                value: "$2a$12$YLDdsHvcutRqLcmDKasdGOkXvNpH64LvQRnyC9xVWfS4Q/382Saza");

            migrationBuilder.UpdateData(
                table: "MainUser",
                keyColumn: "Id",
                keyValue: 3L,
                column: "Password",
                value: "$2a$12$.oS86uz6/omi2t/m77uE1OEBww9QW/kXKqi1dJOaQQa/qw8uSfEKe");

            migrationBuilder.UpdateData(
                table: "MainUser",
                keyColumn: "Id",
                keyValue: 4L,
                column: "Password",
                value: "$2a$12$UcNRHRfkiE4UXJmDbs5bbeTvV74mZkzGuM8roNSgMaJNMeHUsE60O");

            migrationBuilder.UpdateData(
                table: "MainUser",
                keyColumn: "Id",
                keyValue: 5L,
                column: "Password",
                value: "$2a$12$R4Hx534qDDh5U0bLMoVZC.WmXrytYDoq.U33DYf6zy2agOuJ6enYa");

            migrationBuilder.UpdateData(
                table: "MainUser",
                keyColumn: "Id",
                keyValue: 6L,
                column: "Password",
                value: "$2a$12$b3vQ8b5mUmC5swhI.apmUOf1QjcIFcWafhnwxjYo2Oe.0gDdyCyue");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CountyCode",
                table: "TenantDetails");

            migrationBuilder.UpdateData(
                table: "MainUser",
                keyColumn: "Id",
                keyValue: -1L,
                column: "Password",
                value: "$2a$12$51dCf7ghx.a6t4rfYBaEaOO8uEvksVL4jAHccfSWom0wxb/3NqtWu");

            migrationBuilder.UpdateData(
                table: "MainUser",
                keyColumn: "Id",
                keyValue: 1L,
                column: "Password",
                value: "$2a$12$i7D40VWWB.U2.qD9CbI9IOsJtsdcumUWwfTTfR0ILL1YNXx3koRcK");

            migrationBuilder.UpdateData(
                table: "MainUser",
                keyColumn: "Id",
                keyValue: 2L,
                column: "Password",
                value: "$2a$12$udOTP9eVcpjtjFQxniitE.J.kul8A29k0TR.a6Kmy6FAXGv4wmAIy");

            migrationBuilder.UpdateData(
                table: "MainUser",
                keyColumn: "Id",
                keyValue: 3L,
                column: "Password",
                value: "$2a$12$aS6.9RcopHasyl956BNYL.rixGoE45zSyYWZnyZVTSlpn8O/WP7/e");

            migrationBuilder.UpdateData(
                table: "MainUser",
                keyColumn: "Id",
                keyValue: 4L,
                column: "Password",
                value: "$2a$12$6sYjSlCElUw1x8mDoDKSoOLX9uRnNGX9WzS9BuKe.SP8VFYTaQNn2");

            migrationBuilder.UpdateData(
                table: "MainUser",
                keyColumn: "Id",
                keyValue: 5L,
                column: "Password",
                value: "$2a$12$jw7u.knBI82WysBWUCVqP.KCWMUA6WDdH3ZhDJAAKMt2FctJM9UZ2");

            migrationBuilder.UpdateData(
                table: "MainUser",
                keyColumn: "Id",
                keyValue: 6L,
                column: "Password",
                value: "$2a$12$1i6lYeydCZ2EbaGKRB1oveE13cfJAi8KwGfJVRc7C9EM9YqoGN2Cy");
        }
    }
}
