using Microsoft.EntityFrameworkCore.Migrations;

namespace HealthWare.ActiveASSIST.Repositories.Migrations
{
    public partial class SecondaryEmailContactDetailAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "SecondaryEmailContactDetailsId",
                table: "MainUser",
                type: "bigint",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "MainUser",
                keyColumn: "Id",
                keyValue: -1L,
                column: "Password",
                value: "$2a$12$1iiAG9h33ups/tes/sj22.wEA02rT1MZWBjHhXYqRXhi5kbwuezmm");

            migrationBuilder.UpdateData(
                table: "MainUser",
                keyColumn: "Id",
                keyValue: 1L,
                column: "Password",
                value: "$2a$12$B3GEhm12I4sa7zhiSNyS8..snFYu1/VKhHxW0UWtKqr2KkJ.0NrQG");

            migrationBuilder.UpdateData(
                table: "MainUser",
                keyColumn: "Id",
                keyValue: 2L,
                column: "Password",
                value: "$2a$12$yF6x7LB1HRXxjWIR/FaWKuUn0crHTnqS8uwK/Uf4CW.6cQ5umW/K2");

            migrationBuilder.UpdateData(
                table: "MainUser",
                keyColumn: "Id",
                keyValue: 3L,
                column: "Password",
                value: "$2a$12$ri2Legap75Y94GAcTQsWSejKEgZaXOWcaK2QkTaobZBDxGB5TqXZa");

            migrationBuilder.UpdateData(
                table: "MainUser",
                keyColumn: "Id",
                keyValue: 4L,
                column: "Password",
                value: "$2a$12$4bk9B3R6cW9qythwP7SC2ushQhUqPRGPg3W68e/BQNe60uew7Uii2");

            migrationBuilder.UpdateData(
                table: "MainUser",
                keyColumn: "Id",
                keyValue: 5L,
                column: "Password",
                value: "$2a$12$PF6HMYLN.97V7gpZdGSSa.owi277mEn8atdLC7ha3R0OMKFN.RH92");

            migrationBuilder.UpdateData(
                table: "MainUser",
                keyColumn: "Id",
                keyValue: 6L,
                column: "Password",
                value: "$2a$12$tKC6fx.uv/EbFXWJAIyPv.jJv7Siylv67Ur5riyKOR2lPIAruHW0y");

            migrationBuilder.UpdateData(
                table: "MainUser",
                keyColumn: "Id",
                keyValue: 7L,
                column: "Password",
                value: "$2a$12$.IHScIswQ.98Bot0.3NxkektBt5givSXlDUoiAlVk8BdnMn6oVnZO");

            migrationBuilder.UpdateData(
                table: "MainUser",
                keyColumn: "Id",
                keyValue: 8L,
                column: "Password",
                value: "$2a$12$zUpQozuiyE00uNNwS9Kvq.p40qgEeQUg3hfcdT9mKqL.w41NNQ3be");

            migrationBuilder.CreateIndex(
                name: "IX_MainUser_SecondaryEmailContactDetailsId",
                table: "MainUser",
                column: "SecondaryEmailContactDetailsId");

            migrationBuilder.AddForeignKey(
                name: "FK_MainUser_ContactDetails_SecondaryEmailContactDetailsId",
                table: "MainUser",
                column: "SecondaryEmailContactDetailsId",
                principalTable: "ContactDetails",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MainUser_ContactDetails_SecondaryEmailContactDetailsId",
                table: "MainUser");

            migrationBuilder.DropIndex(
                name: "IX_MainUser_SecondaryEmailContactDetailsId",
                table: "MainUser");

            migrationBuilder.DropColumn(
                name: "SecondaryEmailContactDetailsId",
                table: "MainUser");

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
