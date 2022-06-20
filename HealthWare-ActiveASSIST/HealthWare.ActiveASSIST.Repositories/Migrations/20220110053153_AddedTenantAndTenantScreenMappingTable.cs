using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace HealthWare.ActiveASSIST.Repositories.Migrations
{
    public partial class AddedTenantAndTenantScreenMappingTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "NextScreenId",
                table: "DynamicScreens",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "PreviousScreenId",
                table: "DynamicScreens",
                type: "bigint",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "TenantDetails",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenantId = table.Column<long>(type: "bigint", nullable: false),
                    TenantName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedBy = table.Column<long>(type: "bigint", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedBy = table.Column<long>(type: "bigint", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TenantDetails", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ScreenTenantMapping",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenantId = table.Column<long>(type: "bigint", nullable: true),
                    ScreenId = table.Column<long>(type: "bigint", nullable: true),
                    Order = table.Column<int>(type: "int", nullable: false),
                    RecordStatus = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ScreenTenantMapping", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ScreenTenantMapping_DynamicScreens_ScreenId",
                        column: x => x.ScreenId,
                        principalTable: "DynamicScreens",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ScreenTenantMapping_TenantDetails_TenantId",
                        column: x => x.TenantId,
                        principalTable: "TenantDetails",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: -1L,
                column: "Password",
                value: "$2a$12$JILmgvZqdplGDSaAhCb9Z.oW43Zn/QCtY2MI2JipxC448hg2n0JGG");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1L,
                column: "Password",
                value: "$2a$12$gq0FIHVGtbTbGc3pVFnO9.2/8ml5SlB0kbzolyFL3H3CQzE8a.I9O");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2L,
                column: "Password",
                value: "$2a$12$tYPl1sbD19Xmj8oNJ4cgvO9UcmSDgN/Pghx9i0B4nx3jxzhg.aN0G");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3L,
                column: "Password",
                value: "$2a$12$XFr7kSU4S20BFRHpJDmuq.1vqjk4hQs0EevsXNPNFqdiG6Or8g5fi");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 4L,
                column: "Password",
                value: "$2a$12$uMz.HbnBfkIghXL03TusB.KPbnhMD475dnIGtt0KLe09LLUssBSze");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 5L,
                column: "Password",
                value: "$2a$12$pDnpPtKPIcdPN2BxrXyAWOLMqya3uk0fvUsxRvmcdst.tlGMUVby2");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 6L,
                column: "Password",
                value: "$2a$12$nTNNdDmRuY54vdI5BIfYZeuEPmz2yDLL3WFs6PV1LiKXmPEC2A.oG");

            migrationBuilder.CreateIndex(
                name: "IX_ScreenTenantMapping_ScreenId",
                table: "ScreenTenantMapping",
                column: "ScreenId");

            migrationBuilder.CreateIndex(
                name: "IX_ScreenTenantMapping_TenantId",
                table: "ScreenTenantMapping",
                column: "TenantId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ScreenTenantMapping");

            migrationBuilder.DropTable(
                name: "TenantDetails");

            migrationBuilder.DropColumn(
                name: "NextScreenId",
                table: "DynamicScreens");

            migrationBuilder.DropColumn(
                name: "PreviousScreenId",
                table: "DynamicScreens");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: -1L,
                column: "Password",
                value: "$2a$12$A5sZFEaAgAoZ/HecXe.0fO8fOq0RAB9C.gjqFOMvbIRgB72GoNy9q");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1L,
                column: "Password",
                value: "$2a$12$Yo1zPlMB4BHZTCsAI.bcte0VvDId5EoGoSN9eKW55ZCPt2VBHbWPO");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2L,
                column: "Password",
                value: "$2a$12$Mhf72xAzLUw8O0WXTcS3T.K9agut7x4XPyoqxE2GjoG8xPy8.CBqi");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3L,
                column: "Password",
                value: "$2a$12$dAzNXzhyPXCxfu4eRUIhWO2EE4HtFo3k7WSpN13GyNkXRD.bjVIa.");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 4L,
                column: "Password",
                value: "$2a$12$quHpokBv52eQm3znBFWI8.UrJzfjtogahmmFTd4SfwmvkIeEnp/q2");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 5L,
                column: "Password",
                value: "$2a$12$CHc6PWm4R.CuMNh5ZDI0lO4v9FWlkABv2HOCSXYe04nitaapFKvKO");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 6L,
                column: "Password",
                value: "$2a$12$2L93m61FPQa8QdAyS4E43eAh3tUyNkKgeG0.QngLp20o8QTUKsfEe");
        }
    }
}
