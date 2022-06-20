using Microsoft.EntityFrameworkCore.Migrations;

namespace HealthWare.ActiveASSIST.Repositories.Migrations
{
    public partial class RemovedAdvocateGQ : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Question",
                keyColumn: "Id",
                keyValue: 38L);

            migrationBuilder.DeleteData(
                table: "Question",
                keyColumn: "Id",
                keyValue: 39L);

            migrationBuilder.DeleteData(
                table: "Question",
                keyColumn: "Id",
                keyValue: 40L);

            migrationBuilder.DeleteData(
                table: "Question",
                keyColumn: "Id",
                keyValue: 41L);

            migrationBuilder.UpdateData(
                table: "MainUser",
                keyColumn: "Id",
                keyValue: -1L,
                column: "Password",
                value: "$2a$12$.jLsqqedofVj69f43Iqt8.Ng6.8BazEBKThJ7yX3Azwj4b.jd523C");

            migrationBuilder.UpdateData(
                table: "MainUser",
                keyColumn: "Id",
                keyValue: 1L,
                column: "Password",
                value: "$2a$12$IRdwUl3mxAMTQNRTaoUwcOZ91IyUORY7pgiFainLeHBAJ9075gsNq");

            migrationBuilder.UpdateData(
                table: "MainUser",
                keyColumn: "Id",
                keyValue: 2L,
                column: "Password",
                value: "$2a$12$AKb7o.SsAW/Qj.txhD.Nuu6qOnPmYMUICV..r1I3sStmJgMXr3E4i");

            migrationBuilder.UpdateData(
                table: "MainUser",
                keyColumn: "Id",
                keyValue: 3L,
                column: "Password",
                value: "$2a$12$gTWIjnK29qYlyMdcMi5psesge3Na6EBzpEPqhoQzW6zZWSZU9aFNS");

            migrationBuilder.UpdateData(
                table: "MainUser",
                keyColumn: "Id",
                keyValue: 4L,
                column: "Password",
                value: "$2a$12$j0VqIQlRal7yXIEEmwGVX.PZI6XnAzEssnAmVSDhxJXqoPtTXe0x2");

            migrationBuilder.UpdateData(
                table: "MainUser",
                keyColumn: "Id",
                keyValue: 5L,
                column: "Password",
                value: "$2a$12$OgoMQU4xQbBbrwYTyP91tuiNxjNvL9pR4U0nGZERUlKRbrGQ2sWjm");

            migrationBuilder.UpdateData(
                table: "MainUser",
                keyColumn: "Id",
                keyValue: 6L,
                column: "Password",
                value: "$2a$12$CxW85ntqGQDgTCnMeYcgNOWlDVocXULTSEiZeYJLHUH0h30aAIVYS");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "MainUser",
                keyColumn: "Id",
                keyValue: -1L,
                column: "Password",
                value: "$2a$12$nPxbQe1oxSKJ8tfUGY8IPeEGNEonOcV51wtY3IOxTRTMgiZ1ZDIVq");

            migrationBuilder.UpdateData(
                table: "MainUser",
                keyColumn: "Id",
                keyValue: 1L,
                column: "Password",
                value: "$2a$12$3bKndNxd82Vmad3Gz.tan.o.SH.4LGnEw7oHNK10aPlVZaXbgznJC");

            migrationBuilder.UpdateData(
                table: "MainUser",
                keyColumn: "Id",
                keyValue: 2L,
                column: "Password",
                value: "$2a$12$ai4HNsFZmILWAAsdUXfxA.3c6Xd5oDCfGcbEBd347yaC5dmxYAewm");

            migrationBuilder.UpdateData(
                table: "MainUser",
                keyColumn: "Id",
                keyValue: 3L,
                column: "Password",
                value: "$2a$12$NJIj2YD9qszUqREgqkFJU./c3IIUCCV4vzzd21tFtpcu3/2VFWGcG");

            migrationBuilder.UpdateData(
                table: "MainUser",
                keyColumn: "Id",
                keyValue: 4L,
                column: "Password",
                value: "$2a$12$HOTo7uMZe0ee5DMZS5A9b.Rbom/.aO.4uJksTocAH5C2pGHDzoAPW");

            migrationBuilder.UpdateData(
                table: "MainUser",
                keyColumn: "Id",
                keyValue: 5L,
                column: "Password",
                value: "$2a$12$PPR72/SGIKc3zkOvSo.YQ.iF1s7dKFLvVLnTT11Ndq48Hf4Z7X6vi");

            migrationBuilder.UpdateData(
                table: "MainUser",
                keyColumn: "Id",
                keyValue: 6L,
                column: "Password",
                value: "$2a$12$pljkvb9Akf9NIB1DhmTiWO9NjICokswxu7xAnjrmLF/5SUpp7uVhq");

            migrationBuilder.InsertData(
                table: "Question",
                columns: new[] { "Id", "ControlId", "CssStyle", "Description", "DisplayFormat", "IsRequired", "ParentId", "QuestionName", "RoleName", "Type", "UiType" },
                values: new object[,]
                {
                    { 38L, 3L, "rbn_style1", "If none of them apply, you can directly move to the next question.", "header", false, null, "Please select the options that apply to you and click on next.", "Advocate", null, null },
                    { 39L, 3L, "rbn_style1", null, "header", true, null, "Do any of the following health conditions apply to you?", "Advocate", null, null },
                    { 40L, 3L, "rbn_style1", null, "header", true, null, "Select if you have been injured", "Advocate", null, null },
                    { 41L, 8L, "tgl_style", null, "header", true, 40L, "Was a report filed?", "Advocate", null, null }
                });
        }
    }
}
