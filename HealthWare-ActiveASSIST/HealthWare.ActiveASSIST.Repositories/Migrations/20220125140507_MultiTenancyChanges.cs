using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace HealthWare.ActiveASSIST.Repositories.Migrations
{
    public partial class MultiTenancyChanges : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SessionActivity_Users_UserId",
                table: "SessionActivity");

            migrationBuilder.DropForeignKey(
                name: "FK_UserHasRoles_Users_UserId",
                table: "UserHasRoles");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.CreateTable(
                name: "MainUser",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MiddleName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateOfBirth = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Gender = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EmailAddress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Cell = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    OtpNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CanChangePassword = table.Column<bool>(type: "bit", nullable: false),
                    IsTokenConsumed = table.Column<bool>(type: "bit", nullable: false),
                    IsAuthenticated = table.Column<bool>(type: "bit", nullable: false),
                    CountyCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LoginOTPUpdatedTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsTwoFactorEnabled = table.Column<bool>(type: "bit", nullable: true),
                    MaritalStatus = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SSNNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ContactDetailsId = table.Column<long>(type: "bigint", nullable: true),
                    Discriminator = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TenantId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedBy = table.Column<long>(type: "bigint", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedBy = table.Column<long>(type: "bigint", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MainUser", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MainUser_ContactDetails_ContactDetailsId",
                        column: x => x.ContactDetailsId,
                        principalTable: "ContactDetails",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SubDomainMaster",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SubDomain = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TenantId = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubDomainMaster", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "MainUser",
                columns: new[] { "Id", "CanChangePassword", "Cell", "ContactDetailsId", "CountyCode", "CreatedBy", "CreatedDate", "DateOfBirth", "Discriminator", "EmailAddress", "FirstName", "Gender", "IsActive", "IsAuthenticated", "IsTokenConsumed", "IsTwoFactorEnabled", "LastName", "LoginOTPUpdatedTime", "MaritalStatus", "MiddleName", "OtpNumber", "Password", "SSNNumber", "TenantId", "UpdatedBy", "UpdatedDate" },
                values: new object[,]
                {
                    { -1L, false, "1111111111", 1L, null, null, new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "User", "dummy", null, null, true, false, false, null, null, null, null, null, null, "$2a$12$XH0nQFMWL/F1ETeiLjuk2.R6wj1yxwYpNY1kwVz.WKUMClXBh5ZCK", null, null, null, null },
                    { 1L, false, "2222222222", 2L, "1", null, new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1996, 11, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "User", "naresh.k@zucisystems.com", "Naresh", "Male", true, false, false, null, "Kumar", null, "Single", null, null, "$2a$12$HSltrVDHFyD31ahQJKb1B.ZV0XmDSZ/KO8JCehOLR7.4ZsNaode/y", "212128812", null, null, null },
                    { 2L, false, "3333333333", 3L, "1", null, new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1996, 11, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "User", "iniya.j@zucisystems.com", "Iniya", "Female", true, false, false, null, "J", null, "Married", null, null, "$2a$12$2OETMDmiYtxUQ7rMQSF9F.PmgObQdM7RhxApZR1DBV9U/JJarY5CS", "212127744", null, null, null },
                    { 3L, false, "9998789876", 4L, "1", null, new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1996, 11, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "User", "dkucherina@healthwaresystems.com", "Dimitriy", "Male", true, false, false, null, "Kucherina", null, "Single", null, null, "$2a$12$K3eDalC.OuQOgfyGPpniuebHZPifd12pdu9nBzsKTn5Icn40mpua.", "212127766", null, null, null },
                    { 4L, false, "9998789876", 5L, "1", null, new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1996, 11, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "User", "psubbaraman@healthwaresystems.com", "Subba", "Male", true, false, false, null, "Raman", null, "Single", null, null, "$2a$12$KkrV9IQ.znILhQ89Xc4PjeDppfyDvknlPN6WESWEakIGL.Ot0LjeS", "212127788", null, null, null },
                    { 5L, false, "9998789876", 6L, "1", null, new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1996, 11, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "User", "jkunwar@healthwaresystems.com", "Jay", "Male", true, false, false, null, "Kunwar", null, "Single", null, null, "$2a$12$CKU3yyI6tdRKwta2GgEnQu8LcsBSW8PBbbXbMdehcAH.xm/tT.0ui", "212127724", null, null, null },
                    { 6L, false, "9998789876", 7L, "1", null, new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1996, 11, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "User", "sgruner@healthwaresystems.com", "Stephen", "Male", true, false, false, null, "Gruner", null, "Single", null, null, "$2a$12$yTbiuUIgg3blsOtD.vTnluMtbltS8NAMt/D5dTBvOvnmSJTaA10uG", "212126682", null, null, null }
                });

            migrationBuilder.InsertData(
                table: "SubDomainMaster",
                columns: new[] { "Id", "SubDomain", "TenantId" },
                values: new object[] { 1L, "localhost:4200", "1" });

            migrationBuilder.CreateIndex(
                name: "IX_MainUser_ContactDetailsId",
                table: "MainUser",
                column: "ContactDetailsId");

            migrationBuilder.AddForeignKey(
                name: "FK_SessionActivity_MainUser_UserId",
                table: "SessionActivity",
                column: "UserId",
                principalTable: "MainUser",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_UserHasRoles_MainUser_UserId",
                table: "UserHasRoles",
                column: "UserId",
                principalTable: "MainUser",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SessionActivity_MainUser_UserId",
                table: "SessionActivity");

            migrationBuilder.DropForeignKey(
                name: "FK_UserHasRoles_MainUser_UserId",
                table: "UserHasRoles");

            migrationBuilder.DropTable(
                name: "MainUser");

            migrationBuilder.DropTable(
                name: "SubDomainMaster");

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CanChangePassword = table.Column<bool>(type: "bit", nullable: false),
                    Cell = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ContactDetailsId = table.Column<long>(type: "bigint", nullable: true),
                    CountyCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedBy = table.Column<long>(type: "bigint", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateOfBirth = table.Column<DateTime>(type: "datetime2", nullable: true),
                    EmailAddress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Gender = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsAuthenticated = table.Column<bool>(type: "bit", nullable: false),
                    IsTokenConsumed = table.Column<bool>(type: "bit", nullable: false),
                    IsTwoFactorEnabled = table.Column<bool>(type: "bit", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LoginOTPUpdatedTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    MaritalStatus = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MiddleName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OtpNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SSNNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedBy = table.Column<long>(type: "bigint", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Users_ContactDetails_ContactDetailsId",
                        column: x => x.ContactDetailsId,
                        principalTable: "ContactDetails",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CanChangePassword", "Cell", "ContactDetailsId", "CountyCode", "CreatedBy", "CreatedDate", "DateOfBirth", "EmailAddress", "FirstName", "Gender", "IsActive", "IsAuthenticated", "IsTokenConsumed", "IsTwoFactorEnabled", "LastName", "LoginOTPUpdatedTime", "MaritalStatus", "MiddleName", "OtpNumber", "Password", "SSNNumber", "UpdatedBy", "UpdatedDate" },
                values: new object[,]
                {
                    { -1L, false, "1111111111", 1L, null, null, new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "dummy", null, null, true, false, false, null, null, null, null, null, null, "$2a$12$yq86EB71mzXdTwsgf.c1gefQA5pA.7k6E/IYYIR8Fvjwl.YANdoZ.", null, null, null },
                    { 1L, false, "2222222222", 2L, "1", null, new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1996, 11, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "naresh.k@zucisystems.com", "Naresh", "Male", true, false, false, null, "Kumar", null, "Single", null, null, "$2a$12$Jfpf6IisHNvGQSqZGwWH7e4YIkuk410DThxOPBoz2a22DxZrgpgTy", "212128812", null, null },
                    { 2L, false, "3333333333", 3L, "1", null, new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1996, 11, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "iniya.j@zucisystems.com", "Iniya", "Female", true, false, false, null, "J", null, "Married", null, null, "$2a$12$J93JkSqkjt6V.6Jo21Bmm.we04xzbotc3/fOAx9XlXNsryoh6aiyq", "212127744", null, null },
                    { 3L, false, "9998789876", 4L, "1", null, new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1996, 11, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "dkucherina@healthwaresystems.com", "Dimitriy", "Male", true, false, false, null, "Kucherina", null, "Single", null, null, "$2a$12$NETouuF8stTHwpHmw7HgYuH3.2.PvhYZ.LullCUzvgqcO.dApmNG.", "212127766", null, null },
                    { 4L, false, "9998789876", 5L, "1", null, new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1996, 11, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "psubbaraman@healthwaresystems.com", "Subba", "Male", true, false, false, null, "Raman", null, "Single", null, null, "$2a$12$doMcjuzV6f9X2wSa1mpfwuIauLbEqe6p.iprdWdL2c3uy9F9Afpt6", "212127788", null, null },
                    { 5L, false, "9998789876", 6L, "1", null, new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1996, 11, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "jkunwar@healthwaresystems.com", "Jay", "Male", true, false, false, null, "Kunwar", null, "Single", null, null, "$2a$12$nJ.hBQltUt2FS87TURSHj.I1f2Yc3.2tqoUmn7TAvIZlpn7Sfc.K2", "212127724", null, null },
                    { 6L, false, "9998789876", 7L, "1", null, new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1996, 11, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "sgruner@healthwaresystems.com", "Stephen", "Male", true, false, false, null, "Gruner", null, "Single", null, null, "$2a$12$eqn7SjzbCDVaswMv7i0xSe5LxiMdiZ9N3A0xAzePeO8Zz0lFzjK3K", "212126682", null, null }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Users_ContactDetailsId",
                table: "Users",
                column: "ContactDetailsId");

            migrationBuilder.AddForeignKey(
                name: "FK_SessionActivity_Users_UserId",
                table: "SessionActivity",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_UserHasRoles_Users_UserId",
                table: "UserHasRoles",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
