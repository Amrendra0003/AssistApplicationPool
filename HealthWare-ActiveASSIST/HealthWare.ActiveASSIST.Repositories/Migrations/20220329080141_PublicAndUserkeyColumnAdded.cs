using Microsoft.EntityFrameworkCore.Migrations;

namespace HealthWare.ActiveASSIST.Repositories.Migrations
{
    public partial class PublicAndUserkeyColumnAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "PublicKey",
                table: "TenantDetails",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserKey",
                table: "TenantDetails",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "MainUser",
                keyColumn: "Id",
                keyValue: -1L,
                column: "Password",
                value: "$2a$12$6vjSSBLBGz.weDdBMInxpOcQyLKly0sdlJSrHE6zmdEw.fDnW2eOC");

            migrationBuilder.UpdateData(
                table: "MainUser",
                keyColumn: "Id",
                keyValue: 1L,
                column: "Password",
                value: "$2a$12$eCei4PzxHe5T.IhOU4QNL.co05bH5AxwqDuO2qbhiQVjuXLmyVz9a");

            migrationBuilder.UpdateData(
                table: "MainUser",
                keyColumn: "Id",
                keyValue: 2L,
                column: "Password",
                value: "$2a$12$1j7Z7iFFqSg3f2LfTUbGr.p3ujS7j7XJJRt8gsDC9kAVVLPkyadBW");

            migrationBuilder.UpdateData(
                table: "MainUser",
                keyColumn: "Id",
                keyValue: 3L,
                column: "Password",
                value: "$2a$12$BsavKq5zOuIuVp3KcfD6UO5yqaX0TP4yr/P2cwHOQZWtECE40IdOq");

            migrationBuilder.UpdateData(
                table: "MainUser",
                keyColumn: "Id",
                keyValue: 4L,
                column: "Password",
                value: "$2a$12$N6ZIB1tugZnlJRd8PQs6B.VYa.FChD5W2PmuT/F2uL3dCBYL5qC8m");

            migrationBuilder.UpdateData(
                table: "MainUser",
                keyColumn: "Id",
                keyValue: 5L,
                column: "Password",
                value: "$2a$12$dBH/4PYz/V0fLNHENQgyjuUBKD9wIOwNM.J4IT/bG4dsMQ33Yu1CC");

            migrationBuilder.UpdateData(
                table: "MainUser",
                keyColumn: "Id",
                keyValue: 6L,
                column: "Password",
                value: "$2a$12$eIP8.EwjoBzfI4BItlHoCuSN3yPCHs5PCYGkpMAdJl4Ebp3k4Egqa");

            migrationBuilder.UpdateData(
                table: "MainUser",
                keyColumn: "Id",
                keyValue: 7L,
                column: "Password",
                value: "$2a$12$vhXD.eZxsJZAOMjloZuCtOlqJ4GodiWwRZhdxytOSAB6MH5X.wKuG");

            migrationBuilder.UpdateData(
                table: "MainUser",
                keyColumn: "Id",
                keyValue: 8L,
                column: "Password",
                value: "$2a$12$v8S4jegj0FWPYXA9N9qwG..kjCsbJ9RJT3hq.AUnzAHWwAfO//GgK");

            migrationBuilder.UpdateData(
                table: "TenantDetails",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "PublicKey", "UserKey" },
                values: new object[] { "b14ca5898a4e4142aace2ea2143a2410", "activeassistzuci" });

            migrationBuilder.UpdateData(
                table: "TenantDetails",
                keyColumn: "Id",
                keyValue: 2L,
                columns: new[] { "PublicKey", "UserKey" },
                values: new object[] { "b14ca5898a4e4142aace2ea2143a2410", "activeassistzuci" });

            migrationBuilder.UpdateData(
                table: "TenantDetails",
                keyColumn: "Id",
                keyValue: 3L,
                columns: new[] { "PublicKey", "UserKey" },
                values: new object[] { "b14ca5898a4e4142aace2ea2143a2410", "activeassistzuci" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PublicKey",
                table: "TenantDetails");

            migrationBuilder.DropColumn(
                name: "UserKey",
                table: "TenantDetails");

            migrationBuilder.UpdateData(
                table: "MainUser",
                keyColumn: "Id",
                keyValue: -1L,
                column: "Password",
                value: "$2a$12$V14xjGRzUQHQjIjxEI5Vue1m/Uk9Xz/U3dC8UGNSlkbgFxfhxr3YW");

            migrationBuilder.UpdateData(
                table: "MainUser",
                keyColumn: "Id",
                keyValue: 1L,
                column: "Password",
                value: "$2a$12$.7X1Ibq.Gd8BXoHe7PWTv.xCI2lzc3xsPXbjcUtj5URe0XZ39lzzi");

            migrationBuilder.UpdateData(
                table: "MainUser",
                keyColumn: "Id",
                keyValue: 2L,
                column: "Password",
                value: "$2a$12$bMViCzQOjBZmXxbIUnjnwOFl4CWu4KY83c5ws.UkMDsAT4mNNT9xy");

            migrationBuilder.UpdateData(
                table: "MainUser",
                keyColumn: "Id",
                keyValue: 3L,
                column: "Password",
                value: "$2a$12$X0f3WWq90CQRExJacWyVzOALOJc4UeFJucukwG9bOoHjkUfJGE/gu");

            migrationBuilder.UpdateData(
                table: "MainUser",
                keyColumn: "Id",
                keyValue: 4L,
                column: "Password",
                value: "$2a$12$nUGHnUNmFjNGCpLMhrPEs.mDRtf1Pffo2EuIXoxNA5XvilwHsnLIS");

            migrationBuilder.UpdateData(
                table: "MainUser",
                keyColumn: "Id",
                keyValue: 5L,
                column: "Password",
                value: "$2a$12$0aeP1zhuwIj4m4Bclb86ZuZL9/LBJ7BVdknaihEU1wk2c/GKp6mDa");

            migrationBuilder.UpdateData(
                table: "MainUser",
                keyColumn: "Id",
                keyValue: 6L,
                column: "Password",
                value: "$2a$12$MWlq8MgWoPzXBJLzrPRdBeS.umvD9jOmcjr49BE.oKTQNSy8egpOi");

            migrationBuilder.UpdateData(
                table: "MainUser",
                keyColumn: "Id",
                keyValue: 7L,
                column: "Password",
                value: "$2a$12$BPDA.O3xFpzH0473V5j2zu/xcL4W0mhCLERgSH.yCH6nzr5g611d6");

            migrationBuilder.UpdateData(
                table: "MainUser",
                keyColumn: "Id",
                keyValue: 8L,
                column: "Password",
                value: "$2a$12$.0JdZcmHsoqGsprFK3ICwu0.QNVarFNoo/TUi2QQiNQQwBMoQilj6");
        }
    }
}
