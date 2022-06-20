using Microsoft.EntityFrameworkCore.Migrations;

namespace HealthWare.ActiveASSIST.Repositories.Migrations
{
    public partial class countyCodeValueadded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "MainUser",
                keyColumn: "Id",
                keyValue: -1L,
                column: "Password",
                value: "$2a$12$Q/e.k7GHOR3xwKkW6UJ3ket1PvrVbJjt/w98PPdB9BOI4tbIdVyD2");

            migrationBuilder.UpdateData(
                table: "MainUser",
                keyColumn: "Id",
                keyValue: 1L,
                column: "Password",
                value: "$2a$12$/nAG11PPJh3AMbJPSvfN4uip9ve2MvHnYEMpnQVHZHIeY7CI9nZ8y");

            migrationBuilder.UpdateData(
                table: "MainUser",
                keyColumn: "Id",
                keyValue: 2L,
                column: "Password",
                value: "$2a$12$z/iUyGo04X99AZypBvrNRu/AVASlj1lQ4BgpTPod74cwSN1RyIab6");

            migrationBuilder.UpdateData(
                table: "MainUser",
                keyColumn: "Id",
                keyValue: 3L,
                column: "Password",
                value: "$2a$12$Gcor0O4Mnnbe.BJ1Af1yjOKVyrerMIDSip08xDQIQpjr2CxUIIAVm");

            migrationBuilder.UpdateData(
                table: "MainUser",
                keyColumn: "Id",
                keyValue: 4L,
                column: "Password",
                value: "$2a$12$lx6P3gdg64SZ3HZjfy32/uqB4MI29IWPYf/ZHwF7.APPlA9XK4Piy");

            migrationBuilder.UpdateData(
                table: "MainUser",
                keyColumn: "Id",
                keyValue: 5L,
                column: "Password",
                value: "$2a$12$5w5JkAMCFvl4I7kv3aFQdeUxzBlxKFDa5Is6j2haZcDbiUseXR67C");

            migrationBuilder.UpdateData(
                table: "MainUser",
                keyColumn: "Id",
                keyValue: 6L,
                column: "Password",
                value: "$2a$12$dNLJ8zzdoGMP3dUCn3nn4OOjJXCl6kDJDG19KeZYuVO.lomQvdVka");

            migrationBuilder.UpdateData(
                table: "TenantDetails",
                keyColumn: "Id",
                keyValue: 1L,
                column: "CountyCode",
                value: "1");

            migrationBuilder.UpdateData(
                table: "TenantDetails",
                keyColumn: "Id",
                keyValue: 2L,
                column: "CountyCode",
                value: "1");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.UpdateData(
                table: "TenantDetails",
                keyColumn: "Id",
                keyValue: 1L,
                column: "CountyCode",
                value: null);

            migrationBuilder.UpdateData(
                table: "TenantDetails",
                keyColumn: "Id",
                keyValue: 2L,
                column: "CountyCode",
                value: null);
        }
    }
}
