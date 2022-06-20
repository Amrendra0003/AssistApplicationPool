using Microsoft.EntityFrameworkCore.Migrations;

namespace HealthWare.ActiveASSIST.Repositories.Migrations
{
    public partial class AssessmentIsEvaluated : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsEvaluated",
                table: "Assessment",
                type: "bit",
                nullable: false,
                defaultValue: false);

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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsEvaluated",
                table: "Assessment");

            migrationBuilder.UpdateData(
                table: "MainUser",
                keyColumn: "Id",
                keyValue: -1L,
                column: "Password",
                value: "$2a$12$82TJbVDKTQEJDKDJonZkSuY5TKpI10QsiEXS5h5qq0zmDeQbMIFeO");

            migrationBuilder.UpdateData(
                table: "MainUser",
                keyColumn: "Id",
                keyValue: 1L,
                column: "Password",
                value: "$2a$12$8EeA0WMeLZgjiH7zvqhDyeP5FChEyE2sfaFXGBEri2FawP9DkXtUO");

            migrationBuilder.UpdateData(
                table: "MainUser",
                keyColumn: "Id",
                keyValue: 2L,
                column: "Password",
                value: "$2a$12$2/S28mTRud5tbkZ5N5G14eKrgrpgP2KkY1N7H5Qp8ARB80.YrYw0K");

            migrationBuilder.UpdateData(
                table: "MainUser",
                keyColumn: "Id",
                keyValue: 3L,
                column: "Password",
                value: "$2a$12$xQwAm85lM6WaNwt.PwgWnONYpCbyfPYjnp.eXGH6INmhatbjBE1RS");

            migrationBuilder.UpdateData(
                table: "MainUser",
                keyColumn: "Id",
                keyValue: 4L,
                column: "Password",
                value: "$2a$12$C/G2Pxbf6R6cmHXvElGjDOGUwVmoNXVHJGwmiuKdwjM18EDTqRj5q");

            migrationBuilder.UpdateData(
                table: "MainUser",
                keyColumn: "Id",
                keyValue: 5L,
                column: "Password",
                value: "$2a$12$V4faenm1ozMcdVyFHVBLUO/cZreQJGq/ELzH26WlqRNPmwHJ7S39C");

            migrationBuilder.UpdateData(
                table: "MainUser",
                keyColumn: "Id",
                keyValue: 6L,
                column: "Password",
                value: "$2a$12$EAnl2ITVuCK76juKRLVY1uhW0yGGQTztmaYsS7BuFqJbqNd9Zocva");
        }
    }
}
