using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace HealthWare.ActiveASSIST.Repositories.Migrations
{
    public partial class AddedRowsToTenantDetailsTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TenantId",
                table: "TenantDetails");

            migrationBuilder.InsertData(
                table: "TenantDetails",
                columns: new[] { "Id", "CreatedBy", "CreatedDate", "TenantName", "UpdatedBy", "UpdatedDate" },
                values: new object[,]
                {
                    { 1L, null, new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Tenant 1", null, null },
                    { 2L, null, new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Tenant 2", null, null }
                });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: -1L,
                column: "Password",
                value: "$2a$12$dSrTJVs.D.y7TXrS.eUxDuliIkh1jbK4HEUI8hczzHLCymEpWRwy2");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1L,
                column: "Password",
                value: "$2a$12$cFk5nEZbp4uhJXvtSHIxBOOs4mwJEq3GjT/kvbgCGdpPrGBH.skeO");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2L,
                column: "Password",
                value: "$2a$12$B0nGBcUIPmKqwHRZ88CspOVnK8mIcxFCjS9.1A1uA.pL.etz/R34y");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3L,
                column: "Password",
                value: "$2a$12$FjTVksE87s0Z8I3XdJSQkeee/mNYPTf/Xf5n86pDgWzCf07lnooSq");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 4L,
                column: "Password",
                value: "$2a$12$XMMvO6cP95rknHRaQ9N/X.e9t/KvwSsIqRp3epfs/YIQIyRJQuskO");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 5L,
                column: "Password",
                value: "$2a$12$uCbtkVhX71TJV41nMhnMeub3b6xOZI9ka1wrxNE7a/65iPLVjv0s.");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 6L,
                column: "Password",
                value: "$2a$12$KXSFawV4aXJBSLlU2Pp4o.kJ5tmTNEuurGQGAvj9fXKTDKPN0DsDW");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "TenantDetails",
                keyColumn: "Id",
                keyValue: 1L);

            migrationBuilder.DeleteData(
                table: "TenantDetails",
                keyColumn: "Id",
                keyValue: 2L);

            migrationBuilder.AddColumn<long>(
                name: "TenantId",
                table: "TenantDetails",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

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
        }
    }
}
