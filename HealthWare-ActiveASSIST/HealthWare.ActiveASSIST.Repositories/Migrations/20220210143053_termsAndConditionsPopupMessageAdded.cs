using Microsoft.EntityFrameworkCore.Migrations;

namespace HealthWare.ActiveASSIST.Repositories.Migrations
{
    public partial class termsAndConditionsPopupMessageAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "MainUser",
                keyColumn: "Id",
                keyValue: -1L,
                column: "Password",
                value: "$2a$12$Thr3PFdabhakfNCn3opCO.j33DWeRttqR9n6DNNm1gvgAGm2fvgNO");

            migrationBuilder.UpdateData(
                table: "MainUser",
                keyColumn: "Id",
                keyValue: 1L,
                column: "Password",
                value: "$2a$12$5UMKS7crfOyWJVCnMj5MiuyJDt7LcSz05XmjjmoMXr/ZXXJ3lnt0q");

            migrationBuilder.UpdateData(
                table: "MainUser",
                keyColumn: "Id",
                keyValue: 2L,
                column: "Password",
                value: "$2a$12$uAp.Dmky/04CxblVwzeNOuV.Zzw72BogO3Mxy4GQ91BR.ZqTnhhr6");

            migrationBuilder.UpdateData(
                table: "MainUser",
                keyColumn: "Id",
                keyValue: 3L,
                column: "Password",
                value: "$2a$12$PrT2d.z4aKl3vOgVJofnPuUz6hzZ5X8FKPKHNoRofR8GSk9oG/tZK");

            migrationBuilder.UpdateData(
                table: "MainUser",
                keyColumn: "Id",
                keyValue: 4L,
                column: "Password",
                value: "$2a$12$fFCqZ9ZXUOvoLim4ukbn9O4800t5MZCQzBjRISnXkqmiN5B7mXg0O");

            migrationBuilder.UpdateData(
                table: "MainUser",
                keyColumn: "Id",
                keyValue: 5L,
                column: "Password",
                value: "$2a$12$RiATvD4Jt.9JpnWXSOYqFepxuVkAyQwahKkW49jmJB/EviQRIg4oe");

            migrationBuilder.UpdateData(
                table: "MainUser",
                keyColumn: "Id",
                keyValue: 6L,
                column: "Password",
                value: "$2a$12$qhU31kp62Ohhcn2NvOU9zeaW8OUmCn8f7R6tA7yXiQBj9NrmSN9B2");

            migrationBuilder.UpdateData(
                table: "QuickAssessmentQuestions",
                keyColumn: "Id",
                keyValue: 33L,
                column: "TermAndConditionPopupMessage",
                value: "{\"termsAndConditionsHeader\":\"Terms of Use\",\"termsAndConditionsContent\":\"Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat.Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat.Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.\",\"privacyPolicyHeader\":\"Privacy Statement\",\"privacyPolicyContent\":\"Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat.Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat.Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.\",\"eSignatureDisclosureHeader\":\"E-Signature Disclosure\",\"eSignatureDisclosureContent\":\"Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat.Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat.Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.\"}");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
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
                table: "QuickAssessmentQuestions",
                keyColumn: "Id",
                keyValue: 33L,
                column: "TermAndConditionPopupMessage",
                value: null);
        }
    }
}
