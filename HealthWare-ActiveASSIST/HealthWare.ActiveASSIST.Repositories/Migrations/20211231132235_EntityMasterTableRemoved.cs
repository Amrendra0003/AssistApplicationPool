using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace HealthWare.ActiveASSIST.Repositories.Migrations
{
    public partial class EntityMasterTableRemoved : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EntityMaster");

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "EntityMaster",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedBy = table.Column<long>(type: "bigint", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EntityType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedBy = table.Column<long>(type: "bigint", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EntityMaster", x => x.Id);
                });

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
    }
}
