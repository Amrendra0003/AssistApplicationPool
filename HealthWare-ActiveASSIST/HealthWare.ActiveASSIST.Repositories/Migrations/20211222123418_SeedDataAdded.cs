using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace HealthWare.ActiveASSIST.Repositories.Migrations
{
    public partial class SeedDataAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Answer",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    QuestionId = table.Column<long>(type: "bigint", nullable: false),
                    AnswerOptionId = table.Column<long>(type: "bigint", nullable: true),
                    ScreenQuestionMappingId = table.Column<long>(type: "bigint", nullable: false),
                    AssessmentId = table.Column<long>(type: "bigint", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Answer", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AnswerOption",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    QuestionId = table.Column<long>(type: "bigint", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Order = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AnswerOption", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AssessmentInPatientDashboard",
                columns: table => new
                {
                    FullName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Gender = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Age = table.Column<int>(type: "int", nullable: false),
                    AssessmentId = table.Column<long>(type: "bigint", nullable: false),
                    AssessmentStatus = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Programs = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PatientId = table.Column<long>(type: "bigint", nullable: false),
                    ProfileImageData = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SubmittedByName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SubmittedOn = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    HospitalName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CellNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CountryCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EmailAddress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    State = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsEditable = table.Column<bool>(type: "bit", nullable: false),
                    StatusDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "AssessmentResult",
                columns: table => new
                {
                    ScreenId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    QuestionId = table.Column<int>(type: "int", nullable: false),
                    QuestionName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ParentId = table.Column<int>(type: "int", nullable: false),
                    QuestionKeyName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ControlType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsRequired = table.Column<bool>(type: "bit", nullable: false),
                    ScreenQuestionMappingId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OptionId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    KeyName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DisplayFormat = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ControlId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Order = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "AssessmentStatusMaster",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AssessmentStatus = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AssessmentStatusMaster", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AssessmentSummaryResult",
                columns: table => new
                {
                    KeyName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AnswerOptionValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "ContactPreference",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AssessmentId = table.Column<long>(type: "bigint", nullable: false),
                    ContactPhoneId = table.Column<long>(type: "bigint", nullable: false),
                    ContactAddressId = table.Column<long>(type: "bigint", nullable: false),
                    ContactEmailId = table.Column<long>(type: "bigint", nullable: false),
                    OtherContactId = table.Column<long>(type: "bigint", nullable: false),
                    TimeOfCalling = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModeOfCommunication = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedBy = table.Column<long>(type: "bigint", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedBy = table.Column<long>(type: "bigint", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContactPreference", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ContactTypeMaster",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EntityType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ContactType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedBy = table.Column<long>(type: "bigint", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedBy = table.Column<long>(type: "bigint", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContactTypeMaster", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Control",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Label = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ControlType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HelpText = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ContextHelp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Control", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DashboardAssessment",
                columns: table => new
                {
                    AssessmentId = table.Column<long>(type: "bigint", nullable: false),
                    AssessmentPatientId = table.Column<long>(type: "bigint", nullable: false),
                    AssessmentStatus = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PatientProfileImage = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PatientName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Gender = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Age = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StateCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SubmittedOn = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Programs = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsEditable = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "DocumentCategoryMaster",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoryName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DocumentCategoryMaster", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DocumentTypeMaster",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DocumentTypeName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DocumentTypeMaster", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DynamicScreens",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LeftHeader = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LeftContent = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedBy = table.Column<long>(type: "bigint", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedBy = table.Column<long>(type: "bigint", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DynamicScreens", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "EntityMaster",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EntityType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedBy = table.Column<long>(type: "bigint", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedBy = table.Column<long>(type: "bigint", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EntityMaster", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FieldType",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedBy = table.Column<long>(type: "bigint", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedBy = table.Column<long>(type: "bigint", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FieldType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FieldValidatorType",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedBy = table.Column<long>(type: "bigint", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedBy = table.Column<long>(type: "bigint", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FieldValidatorType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Gender",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    KeyName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Gender", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "IncomeType",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    KeyName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IncomeType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "IncomeTypeCurrentStatus",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    KeyName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IncomeTypeCurrentStatus", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "JournalEntries",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EntityId = table.Column<long>(type: "bigint", nullable: false),
                    EntityName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EntityProperty = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CurrentValue = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PreviousValue = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedBy = table.Column<long>(type: "bigint", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedBy = table.Column<long>(type: "bigint", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JournalEntries", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MaritalStatus",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    KeyName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MaritalStatus", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PayPeriod",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    KeyName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PayPeriod", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Permission",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Permission", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Program",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Details = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedBy = table.Column<long>(type: "bigint", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedBy = table.Column<long>(type: "bigint", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Program", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RelationshipToPatient",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    KeyName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RelationshipToPatient", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ResourceType",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    KeyName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ResourceType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ResourceTypeCurrentStatus",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    KeyName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ResourceTypeCurrentStatus", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Screen",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Order = table.Column<long>(type: "bigint", nullable: false),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsRequired = table.Column<bool>(type: "bit", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Screen", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ScreenQuestionMapping",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ScreenId = table.Column<long>(type: "bigint", nullable: false),
                    QuestionId = table.Column<long>(type: "bigint", nullable: false),
                    KeyName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ScreenQuestionMapping", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ServiceAuditTrails",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Action = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Method = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Request = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Response = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedBy = table.Column<long>(type: "bigint", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedBy = table.Column<long>(type: "bigint", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ServiceAuditTrails", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
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
                    StreetAddress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Suite = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    State = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ZipCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MailingAddressCountyCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MailingAddressCell = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    County = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedBy = table.Column<long>(type: "bigint", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedBy = table.Column<long>(type: "bigint", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Verification",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    KeyName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Verification", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Assessment",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AssessmentStatusMasterId = table.Column<long>(type: "bigint", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    ExternalPatientId = table.Column<long>(type: "bigint", nullable: false),
                    CreatedBy = table.Column<long>(type: "bigint", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedBy = table.Column<long>(type: "bigint", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Assessment", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Assessment_AssessmentStatusMaster_AssessmentStatusMasterId",
                        column: x => x.AssessmentStatusMasterId,
                        principalTable: "AssessmentStatusMaster",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ContactDetails",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StreetAddress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ContactTypeDetailsId = table.Column<long>(type: "bigint", nullable: true),
                    Suite = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    State = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Zip = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    County = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Cell = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Fax = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CountyCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StateCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedBy = table.Column<long>(type: "bigint", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedBy = table.Column<long>(type: "bigint", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContactDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ContactDetails_ContactTypeMaster_ContactTypeDetailsId",
                        column: x => x.ContactTypeDetailsId,
                        principalTable: "ContactTypeMaster",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Question",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    QuestionName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ControlId = table.Column<long>(type: "bigint", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ParentId = table.Column<long>(type: "bigint", nullable: true),
                    UiType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DisplayFormat = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CssStyle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsRequired = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Question", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Question_Control_ControlId",
                        column: x => x.ControlId,
                        principalTable: "Control",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "DocumentCategoryDocumentTypeMapping",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DocumentCategoryMasterId = table.Column<long>(type: "bigint", nullable: true),
                    DocumentTypeMasterId = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DocumentCategoryDocumentTypeMapping", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DocumentCategoryDocumentTypeMapping_DocumentCategoryMaster_DocumentCategoryMasterId",
                        column: x => x.DocumentCategoryMasterId,
                        principalTable: "DocumentCategoryMaster",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DocumentCategoryDocumentTypeMapping_DocumentTypeMaster_DocumentTypeMasterId",
                        column: x => x.DocumentTypeMasterId,
                        principalTable: "DocumentTypeMaster",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "QuickAssessmentQuestions",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FieldTypeId = table.Column<long>(type: "bigint", nullable: true),
                    ScreenHeaderPatientLabel = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ScreenHeaderOthersLabel = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PatientLabel = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OthersLabel = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TextBoxSubLabel = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UniqueKey = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FieldName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Class = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ScreenId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OrderId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Placeholder = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Required = table.Column<bool>(type: "bit", nullable: false),
                    CustomValidation = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AlertInfo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MessageInfo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ErrorMessageInfo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MaximumDate = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsInlineLabel = table.Column<bool>(type: "bit", nullable: false),
                    InlineLabel = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TermAndConditionsMessageLabel = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TermAndConditionPopupMessage = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ParentQuestionId = table.Column<long>(type: "bigint", nullable: true),
                    DynamicScreensId = table.Column<long>(type: "bigint", nullable: true),
                    CreatedBy = table.Column<long>(type: "bigint", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedBy = table.Column<long>(type: "bigint", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QuickAssessmentQuestions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_QuickAssessmentQuestions_DynamicScreens_DynamicScreensId",
                        column: x => x.DynamicScreensId,
                        principalTable: "DynamicScreens",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_QuickAssessmentQuestions_FieldType_FieldTypeId",
                        column: x => x.FieldTypeId,
                        principalTable: "FieldType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ProgramDocument",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProgramId = table.Column<long>(type: "bigint", nullable: true),
                    DocumentName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DocumentPath = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DocumentSize = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DocumentDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedBy = table.Column<long>(type: "bigint", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedBy = table.Column<long>(type: "bigint", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProgramDocument", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProgramDocument_Program_ProgramId",
                        column: x => x.ProgramId,
                        principalTable: "Program",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "RolesPermissions",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<long>(type: "bigint", nullable: true),
                    PermissionId = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RolesPermissions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RolesPermissions_Permission_PermissionId",
                        column: x => x.PermissionId,
                        principalTable: "Permission",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_RolesPermissions_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SessionActivity",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<long>(type: "bigint", nullable: true),
                    SessionStartDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastLoggedInDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Active = table.Column<bool>(type: "bit", nullable: false),
                    CreatedBy = table.Column<long>(type: "bigint", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedBy = table.Column<long>(type: "bigint", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SessionActivity", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SessionActivity_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "UserHasRoles",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<long>(type: "bigint", nullable: true),
                    RoleId = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserHasRoles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserHasRoles_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_UserHasRoles_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AssessmentVerification",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AssessmentId = table.Column<long>(type: "bigint", nullable: true),
                    EmailVerificationToken = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CellNumberOTP = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CellNumberOTPUpdatedTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsCellNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    IsEmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    CreatedBy = table.Column<long>(type: "bigint", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedBy = table.Column<long>(type: "bigint", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AssessmentVerification", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AssessmentVerification_Assessment_AssessmentId",
                        column: x => x.AssessmentId,
                        principalTable: "Assessment",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "BasicInfo",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MiddleName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AssessmentId = table.Column<long>(type: "bigint", nullable: true),
                    Suffix = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MaidenName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateOfBirth = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Gender = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MaritalStatus = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EmailAddress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SSNNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CountyCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CellNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BasicContactId = table.Column<long>(type: "bigint", nullable: false),
                    HomeContactId = table.Column<long>(type: "bigint", nullable: false),
                    WorkContactId = table.Column<long>(type: "bigint", nullable: false),
                    CreatedBy = table.Column<long>(type: "bigint", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedBy = table.Column<long>(type: "bigint", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BasicInfo", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BasicInfo_Assessment_AssessmentId",
                        column: x => x.AssessmentId,
                        principalTable: "Assessment",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Guarantor",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AssessmentId = table.Column<long>(type: "bigint", nullable: true),
                    RelationShipWithPatient = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MiddleName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Suffix = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EmailAddress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Cell = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CountyCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SSNNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateOfBirth = table.Column<DateTime>(type: "datetime2", nullable: true),
                    BasicContactId = table.Column<long>(type: "bigint", nullable: false),
                    HomeContactId = table.Column<long>(type: "bigint", nullable: false),
                    WorkContactId = table.Column<long>(type: "bigint", nullable: false),
                    CreatedBy = table.Column<long>(type: "bigint", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedBy = table.Column<long>(type: "bigint", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Guarantor", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Guarantor_Assessment_AssessmentId",
                        column: x => x.AssessmentId,
                        principalTable: "Assessment",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "HouseHoldMember",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AssessmentId = table.Column<long>(type: "bigint", nullable: true),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MiddleName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Suffix = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Relationship = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateOfBirth = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Gender = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MaritalStatus = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SSNNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsMedicAidAvailable = table.Column<bool>(type: "bit", nullable: true),
                    IsInsuranceAvailable = table.Column<bool>(type: "bit", nullable: true),
                    IsDependent = table.Column<bool>(type: "bit", nullable: true),
                    CreatedBy = table.Column<long>(type: "bigint", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedBy = table.Column<long>(type: "bigint", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HouseHoldMember", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HouseHoldMember_Assessment_AssessmentId",
                        column: x => x.AssessmentId,
                        principalTable: "Assessment",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PatientProgramMapping",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AssessmentId = table.Column<long>(type: "bigint", nullable: true),
                    ProgramId = table.Column<long>(type: "bigint", nullable: true),
                    ProgramSummary = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedBy = table.Column<long>(type: "bigint", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedBy = table.Column<long>(type: "bigint", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PatientProgramMapping", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PatientProgramMapping_Assessment_AssessmentId",
                        column: x => x.AssessmentId,
                        principalTable: "Assessment",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PatientProgramMapping_Program_ProgramId",
                        column: x => x.ProgramId,
                        principalTable: "Program",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "QuickAssessmentResult",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AssessmentId = table.Column<long>(type: "bigint", nullable: true),
                    QuestionAnswerJson = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedBy = table.Column<long>(type: "bigint", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedBy = table.Column<long>(type: "bigint", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QuickAssessmentResult", x => x.Id);
                    table.ForeignKey(
                        name: "FK_QuickAssessmentResult_Assessment_AssessmentId",
                        column: x => x.AssessmentId,
                        principalTable: "Assessment",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ReviewNotes",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AssessmentId = table.Column<long>(type: "bigint", nullable: true),
                    Notes = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedBy = table.Column<long>(type: "bigint", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedBy = table.Column<long>(type: "bigint", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReviewNotes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ReviewNotes_Assessment_AssessmentId",
                        column: x => x.AssessmentId,
                        principalTable: "Assessment",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TabCompletionStatus",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AssessmentId = table.Column<long>(type: "bigint", nullable: true),
                    IsQuickAssessmentComplete = table.Column<bool>(type: "bit", nullable: true),
                    IsPersonalBasicInfoComplete = table.Column<bool>(type: "bit", nullable: true),
                    IsPersonalHomeComplete = table.Column<bool>(type: "bit", nullable: true),
                    IsPersonalWorkComplete = table.Column<bool>(type: "bit", nullable: true),
                    IsGuarantorBasicInfoComplete = table.Column<bool>(type: "bit", nullable: true),
                    IsGuarantorHomeComplete = table.Column<bool>(type: "bit", nullable: true),
                    IsGuarantorWorkComplete = table.Column<bool>(type: "bit", nullable: true),
                    IsContactPreferenceComplete = table.Column<bool>(type: "bit", nullable: true),
                    IsHouseholdComplete = table.Column<bool>(type: "bit", nullable: true),
                    IsApplicationFormsComplete = table.Column<bool>(type: "bit", nullable: true),
                    IsProgramsComplete = table.Column<bool>(type: "bit", nullable: true),
                    IsEmailVerificationComplete = table.Column<bool>(type: "bit", nullable: true),
                    IsCellVerificationComplete = table.Column<bool>(type: "bit", nullable: true),
                    IsIdVerificationComplete = table.Column<bool>(type: "bit", nullable: true),
                    IsAddressVerificationComplete = table.Column<bool>(type: "bit", nullable: true),
                    IsIncomeVerificationComplete = table.Column<bool>(type: "bit", nullable: true),
                    IsOtherVerificationComplete = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TabCompletionStatus", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TabCompletionStatus_Assessment_AssessmentId",
                        column: x => x.AssessmentId,
                        principalTable: "Assessment",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Document",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AssessmentId = table.Column<long>(type: "bigint", nullable: true),
                    DocumentCategoryDocumentTypeMappingId = table.Column<long>(type: "bigint", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Path = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Checksum = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedBy = table.Column<long>(type: "bigint", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedBy = table.Column<long>(type: "bigint", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Document", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Document_Assessment_AssessmentId",
                        column: x => x.AssessmentId,
                        principalTable: "Assessment",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Document_DocumentCategoryDocumentTypeMapping_DocumentCategoryDocumentTypeMappingId",
                        column: x => x.DocumentCategoryDocumentTypeMappingId,
                        principalTable: "DocumentCategoryDocumentTypeMapping",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Options",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Order = table.Column<int>(type: "int", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    QuickAssessmentQuestionsId = table.Column<long>(type: "bigint", nullable: true),
                    CreatedBy = table.Column<long>(type: "bigint", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedBy = table.Column<long>(type: "bigint", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Options", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Options_QuickAssessmentQuestions_QuickAssessmentQuestionsId",
                        column: x => x.QuickAssessmentQuestionsId,
                        principalTable: "QuickAssessmentQuestions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Validators",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Required = table.Column<bool>(type: "bit", nullable: false),
                    MinLength = table.Column<int>(type: "int", nullable: false),
                    MaxLength = table.Column<int>(type: "int", nullable: false),
                    PatternId = table.Column<long>(type: "bigint", nullable: true),
                    QuickAssessmentQuestionsId = table.Column<long>(type: "bigint", nullable: true),
                    CreatedBy = table.Column<long>(type: "bigint", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedBy = table.Column<long>(type: "bigint", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Validators", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Validators_FieldValidatorType_PatternId",
                        column: x => x.PatternId,
                        principalTable: "FieldValidatorType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Validators_QuickAssessmentQuestions_QuickAssessmentQuestionsId",
                        column: x => x.QuickAssessmentQuestionsId,
                        principalTable: "QuickAssessmentQuestions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "HouseHoldMemberIncome",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HouseHoldMemberId = table.Column<long>(type: "bigint", nullable: true),
                    IncomeType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CurrentStatus = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Verification = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GrossPay = table.Column<decimal>(type: "decimal(16,2)", precision: 16, scale: 2, nullable: true),
                    GrossPayPeriod = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CalculatedMonthlyIncome = table.Column<decimal>(type: "decimal(16,2)", precision: 16, scale: 2, nullable: true),
                    ContactName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ContactDetailsId = table.Column<long>(type: "bigint", nullable: true),
                    CreatedBy = table.Column<long>(type: "bigint", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedBy = table.Column<long>(type: "bigint", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HouseHoldMemberIncome", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HouseHoldMemberIncome_ContactDetails_ContactDetailsId",
                        column: x => x.ContactDetailsId,
                        principalTable: "ContactDetails",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_HouseHoldMemberIncome_HouseHoldMember_HouseHoldMemberId",
                        column: x => x.HouseHoldMemberId,
                        principalTable: "HouseHoldMember",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "HouseHoldMemberResource",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HouseHoldMemberId = table.Column<long>(type: "bigint", nullable: true),
                    ResourceType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CurrentStatus = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Verification = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CurrentMarketValue = table.Column<decimal>(type: "decimal(16,2)", precision: 16, scale: 2, nullable: true),
                    Ownership = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CalculatedValue = table.Column<decimal>(type: "decimal(16,2)", precision: 16, scale: 2, nullable: true),
                    PropertyLocation = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedBy = table.Column<long>(type: "bigint", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedBy = table.Column<long>(type: "bigint", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HouseHoldMemberResource", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HouseHoldMemberResource_HouseHoldMember_HouseHoldMemberId",
                        column: x => x.HouseHoldMemberId,
                        principalTable: "HouseHoldMember",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "DocumentProgramMapping",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DocumentId = table.Column<long>(type: "bigint", nullable: true),
                    ProgramDocumentId = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DocumentProgramMapping", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DocumentProgramMapping_Document_DocumentId",
                        column: x => x.DocumentId,
                        principalTable: "Document",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DocumentProgramMapping_ProgramDocument_ProgramDocumentId",
                        column: x => x.ProgramDocumentId,
                        principalTable: "ProgramDocument",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "HouseholdMemberDocument",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HouseholdMemberId = table.Column<long>(type: "bigint", nullable: true),
                    DocumentId = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HouseholdMemberDocument", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HouseholdMemberDocument_Document_DocumentId",
                        column: x => x.DocumentId,
                        principalTable: "Document",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_HouseholdMemberDocument_HouseHoldMember_HouseholdMemberId",
                        column: x => x.HouseholdMemberId,
                        principalTable: "HouseHoldMember",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "AnswerOption",
                columns: new[] { "Id", "Content", "Name", "Order", "QuestionId", "Value" },
                values: new object[,]
                {
                    { 1L, null, "myself", 1, 1L, "Myself" },
                    { 29L, null, "refugeeAssisstance", 4, 27L, "Refugee Assistance" },
                    { 30L, null, "allOfTheAbove", 5, 27L, "All of the above" },
                    { 31L, null, "yearly", 1, 30L, "Yearly" },
                    { 32L, null, "monthly", 2, 30L, "Monthly" },
                    { 33L, null, "bimonthly", 3, 30L, "Bimonthly" },
                    { 34L, null, "biweekly", 4, 30L, "Biweekly" },
                    { 35L, null, "weekly", 5, 30L, "Weekly" },
                    { 36L, null, "pregnantNow", 1, 32L, "Pregnant now / in past 6 months" },
                    { 37L, null, "veteran", 2, 32L, "Veteran" },
                    { 38L, null, "memberOfIndianTribe", 3, 32L, "Member of Indian tribe" },
                    { 28L, null, "calWorks", 3, 27L, "CalWorks" },
                    { 39L, null, "formerFosterYouth", 4, 32L, "Former Foster Youth" },
                    { 41L, null, "you/member", 2, 33L, "You/member of your family been declared legally blind" },
                    { 42L, null, "inCrime", 1, 34L, "In crime related violence (as a victim)" },
                    { 43L, null, "inMotorVehicle", 2, 34L, "In motor vehicle accident" },
                    { 44L, null, "onTheJob", 3, 34L, "On the job" },
                    { 45L, null, null, 1, 35L, "No" },
                    { 46L, null, null, 2, 35L, "Yes" },
                    { 47L, null, null, 1, 36L, "No" },
                    { 48L, null, null, 2, 36L, "Yes" },
                    { 49L, null, null, 1, 37L, "No" },
                    { 50L, null, null, 2, 37L, "Yes" },
                    { 40L, null, "deemed", 1, 33L, "Deemed as disabled for 12 months or longer" },
                    { 27L, null, "ssi", 2, 27L, "SSI / SSP" },
                    { 26L, null, "calFresh", 1, 27L, "CalFresh (Food Stamps)" },
                    { 25L, null, null, 2, 26L, "Yes" },
                    { 2L, null, "other", 2, 1L, "Relative/Friend/Other" },
                    { 3L, null, "usCitizen", 1, 5L, "U.S. Citizen" },
                    { 4L, null, "legalResident", 2, 5L, "Legal Resident" },
                    { 5L, null, "undocumented", 3, 5L, "Undocumented" },
                    { 6L, null, "unknown", 4, 5L, "Unknown" },
                    { 7L, null, "M", 1, 10L, "Male" },
                    { 8L, null, "F", 2, 10L, "Female" },
                    { 9L, null, "U", 3, 10L, "Unreported or Unknown" },
                    { 10L, null, "A", 1, 11L, "Separated" },
                    { 11L, null, "D", 2, 11L, "Divorced" },
                    { 12L, null, "M", 3, 11L, "Married" },
                    { 13L, null, "P", 4, 11L, "Domestic partner" },
                    { 14L, null, "S", 5, 11L, "Single" },
                    { 15L, null, "T", 6, 11L, "Unreported" },
                    { 16L, null, "U", 7, 11L, "Unknown" }
                });

            migrationBuilder.InsertData(
                table: "AnswerOption",
                columns: new[] { "Id", "Content", "Name", "Order", "QuestionId", "Value" },
                values: new object[,]
                {
                    { 17L, null, "W", 8, 11L, "Widowed" },
                    { 18L, null, "+1", 1, 13L, "United States" },
                    { 19L, null, "+91", 2, 13L, "India" },
                    { 20L, null, null, 1, 14L, "No" },
                    { 21L, null, null, 2, 14L, "Yes" },
                    { 22L, null, null, 1, 25L, "No" },
                    { 23L, null, null, 2, 25L, "Yes" },
                    { 24L, null, null, 1, 26L, "No" }
                });

            migrationBuilder.InsertData(
                table: "AssessmentStatusMaster",
                columns: new[] { "Id", "AssessmentStatus" },
                values: new object[,]
                {
                    { 4L, "Completed" },
                    { 3L, "Verification Pending" },
                    { 1L, "Incomplete" },
                    { 2L, "Documentation Incomplete" }
                });

            migrationBuilder.InsertData(
                table: "ContactTypeMaster",
                columns: new[] { "Id", "ContactType", "CreatedBy", "CreatedDate", "EntityType", "UpdatedBy", "UpdatedDate" },
                values: new object[,]
                {
                    { 1L, "Basic", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Self", null, null },
                    { 2L, "Home", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Self", null, null },
                    { 3L, "Work", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Self", null, null },
                    { 4L, "Basic", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Guarantor", null, null },
                    { 5L, "Home", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Guarantor", null, null },
                    { 6L, "Work", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Guarantor", null, null },
                    { 7L, "HouseHoldIncome", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "HouseHoldIncome", null, null },
                    { 8L, "Other", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Other", null, null },
                    { 9L, "UserProfile", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "UserProfile", null, null }
                });

            migrationBuilder.InsertData(
                table: "Control",
                columns: new[] { "Id", "ContextHelp", "ControlType", "Description", "HelpText", "Label" },
                values: new object[,]
                {
                    { 11L, null, "countButton", null, null, null },
                    { 10L, null, "checkbox", null, null, null },
                    { 9L, null, "button", null, null, null },
                    { 8L, null, "toggle", null, null, null },
                    { 7L, null, "cell", null, null, null },
                    { 2L, null, "dropdown", null, null, null },
                    { 5L, null, "textbox", null, null, null },
                    { 4L, null, "label", null, null, null },
                    { 3L, null, "radio", null, null, null },
                    { 1L, null, "numerictextbox", null, null, null },
                    { 6L, null, "date", null, null, null }
                });

            migrationBuilder.InsertData(
                table: "DocumentCategoryMaster",
                columns: new[] { "Id", "CategoryName" },
                values: new object[,]
                {
                    { 5L, "Other" },
                    { 4L, "Eforms" },
                    { 1L, "Identification" },
                    { 2L, "Address" },
                    { 3L, "Income" }
                });

            migrationBuilder.InsertData(
                table: "DocumentTypeMaster",
                columns: new[] { "Id", "DocumentTypeName" },
                values: new object[,]
                {
                    { 14L, "ConsenttoTreat" },
                    { 13L, "HIPAAandPrivacyConsent" },
                    { 12L, "Eforms" },
                    { 11L, "Others" },
                    { 10L, "Salary Report" }
                });

            migrationBuilder.InsertData(
                table: "DocumentTypeMaster",
                columns: new[] { "Id", "DocumentTypeName" },
                values: new object[,]
                {
                    { 9L, "Bank Statement" },
                    { 8L, "Pan Card" },
                    { 6L, "MilitaryIdentificationCard" },
                    { 5L, "SocialSecurityCard" },
                    { 4L, "StudentIdentificationCard" },
                    { 3L, "StateissuedIdentificationCard" },
                    { 2L, "BirthCertificate" },
                    { 1L, "ValidDriversLicense" },
                    { 7L, "PassportorPassportCard" }
                });

            migrationBuilder.InsertData(
                table: "DynamicScreens",
                columns: new[] { "Id", "CreatedBy", "CreatedDate", "LeftContent", "LeftHeader", "UpdatedBy", "UpdatedDate" },
                values: new object[,]
                {
                    { 8L, -1L, new DateTime(2021, 12, 22, 12, 34, 17, 658, DateTimeKind.Utc).AddTicks(9919), "Kindly answer few questions to help you better. The questions includes on your health conditions.", "General Information", null, null },
                    { 9L, -1L, new DateTime(2021, 12, 22, 12, 34, 17, 658, DateTimeKind.Utc).AddTicks(9920), "Kindly answer few questions to help you better. The questions includes on your health conditions.", "General Information", null, null },
                    { 7L, -1L, new DateTime(2021, 12, 22, 12, 34, 17, 658, DateTimeKind.Utc).AddTicks(9917), "Let us know the total income & resources of your household. It includes the income & resources of your & your household members also.", "Household Income & Resources", null, null },
                    { 10L, -1L, new DateTime(2021, 12, 22, 12, 34, 17, 658, DateTimeKind.Utc).AddTicks(9922), "Kindly answer few questions to help you better. The questions includes on your health conditions.", "General Information", null, null },
                    { 5L, -1L, new DateTime(2021, 12, 22, 12, 34, 17, 658, DateTimeKind.Utc).AddTicks(9915), "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat.", "Insurance Coverage", null, null },
                    { 4L, -1L, new DateTime(2021, 12, 22, 12, 34, 17, 658, DateTimeKind.Utc).AddTicks(9913), "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat.", "Patient Demographics", null, null },
                    { 3L, -1L, new DateTime(2021, 12, 22, 12, 34, 17, 658, DateTimeKind.Utc).AddTicks(9912), "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat.", "Citizenship Status", null, null },
                    { 6L, -1L, new DateTime(2021, 12, 22, 12, 34, 17, 658, DateTimeKind.Utc).AddTicks(9916), "Let us know the total number of members in your household.", "Household Members", null, null },
                    { 11L, -1L, new DateTime(2021, 12, 22, 12, 34, 17, 658, DateTimeKind.Utc).AddTicks(9923), "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat.", "Social Security Number", null, null },
                    { 1L, -1L, new DateTime(2021, 12, 22, 12, 34, 17, 658, DateTimeKind.Utc).AddTicks(9586), "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat.", "Lets get you started", null, null },
                    { 2L, -1L, new DateTime(2021, 12, 22, 12, 34, 17, 658, DateTimeKind.Utc).AddTicks(9900), "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat.", "Residential Zip Code", null, null }
                });

            migrationBuilder.InsertData(
                table: "FieldType",
                columns: new[] { "Id", "CreatedBy", "CreatedDate", "Type", "UpdatedBy", "UpdatedDate" },
                values: new object[,]
                {
                    { 7L, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "toggle", null, null },
                    { 6L, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "textfield", null, null },
                    { 5L, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "radio", null, null },
                    { 3L, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "date", null, null },
                    { 2L, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "countButton", null, null },
                    { 1L, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "cell", null, null },
                    { 8L, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "checkbox", null, null },
                    { 4L, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "dropdown", null, null },
                    { 9L, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "ssn", null, null }
                });

            migrationBuilder.InsertData(
                table: "FieldValidatorType",
                columns: new[] { "Id", "CreatedBy", "CreatedDate", "Name", "Type", "UpdatedBy", "UpdatedDate" },
                values: new object[,]
                {
                    { 3L, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Email", "^[a-z0-9._%+-]+@[a-z0-9.-]+\\.com$", null, null },
                    { 4L, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Alphabets", "^[a-zA-Z ]*$", null, null },
                    { 5L, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Alphanumeric", "(?:\\s *[a - zA - Z0 - 9]\\s *)*", null, null },
                    { 1L, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Numeric", "^[0-9]*$", null, null },
                    { 2L, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Decimal", "^[0-9]+([,.][0-9]+)?$", null, null }
                });

            migrationBuilder.InsertData(
                table: "Gender",
                columns: new[] { "Id", "KeyName", "Value" },
                values: new object[,]
                {
                    { 3L, "U", "Unreported or Unknown" },
                    { 2L, "F", "Female" },
                    { 1L, "M", "Male" }
                });

            migrationBuilder.InsertData(
                table: "IncomeType",
                columns: new[] { "Id", "KeyName", "Value" },
                values: new object[,]
                {
                    { 7L, "NG", "National Guard Wages" },
                    { 8L, "DIV", "Dividends​" },
                    { 5L, "IK", "In-Kind Support​" },
                    { 4L, "UE", "Unemployment Benefits" },
                    { 3L, "SE", "Self-Employment and Business Income​" }
                });

            migrationBuilder.InsertData(
                table: "IncomeType",
                columns: new[] { "Id", "KeyName", "Value" },
                values: new object[,]
                {
                    { 2L, "I", "Wages, Salaries, Tips, and Commission Income from Work​" },
                    { 1L, "DK", "Don’t Know" },
                    { 36L, "CSUP", "Child Support" },
                    { 35L, "FC", "Foster Care Payments" },
                    { 6L, "PA", "Pensions and Annuitiesnnuities" },
                    { 33L, "WC", "Workers Comp Benefits​​" },
                    { 13L, "DPP", "Disability Pension Plans" },
                    { 14L, "SSDI", "Social Security Disability Income" },
                    { 15L, "SSDSI", "Social Security Disability Supplemental Income" },
                    { 16L, "RA", "Retirement Account Income​" },
                    { 17L, "AL", "Alimony​" },
                    { 18L, "RI", "Net Rental Income​" },
                    { 19L, "GF", "Net Gaming/Fishing Income​" },
                    { 20L, "A", "Awards" },
                    { 32L, "VA", "VA Benefits​​" },
                    { 21L, "CA", "Court Awards and Damages​​" },
                    { 23L, "AC", "Americorp" },
                    { 24L, "GI", "Gambling Income​​" },
                    { 25L, "COLA", "Government Cost of Living Allowance​" },
                    { 34L, "EDU", "Educational Grants​​" },
                    { 26L, "RR", "Railroad Retirement Benefits" },
                    { 27L, "DNP", "Do Not Want to Provide​" },
                    { 28L, "OTH", "Other​​" },
                    { 29L, "STP", "Strike Payments" },
                    { 22L, "CLG", "Earnings for Clergy" },
                    { 30L, "TAX", "Tax Refunds​" },
                    { 12L, "ROY", "Royalties​" },
                    { 10L, "INT", "Interest Income" },
                    { 11L, "SP", "Severance Pay" },
                    { 31L, "TEA", "TEA Cash" },
                    { 9L, "B", "Bonuses" }
                });

            migrationBuilder.InsertData(
                table: "IncomeTypeCurrentStatus",
                columns: new[] { "Id", "KeyName", "Value" },
                values: new object[,]
                {
                    { 1L, "C", "Current" },
                    { 2L, "NCM", "Not Current, but in month of patient care" },
                    { 3L, "NLT6", "Not Current, but from 6 months or less ago" },
                    { 4L, "NGT6", "Not Current, but from 6 or more months ago" }
                });

            migrationBuilder.InsertData(
                table: "MaritalStatus",
                columns: new[] { "Id", "KeyName", "Value" },
                values: new object[,]
                {
                    { 4L, "P", "Domestic partner" },
                    { 1L, "A", "Separated" },
                    { 2L, "D", "Divorced" },
                    { 3L, "M", "Married" },
                    { 5L, "S", "Single" },
                    { 6L, "T", "Unreported" },
                    { 7L, "U", "Unknown" }
                });

            migrationBuilder.InsertData(
                table: "MaritalStatus",
                columns: new[] { "Id", "KeyName", "Value" },
                values: new object[] { 8L, "W", "Widowed" });

            migrationBuilder.InsertData(
                table: "PayPeriod",
                columns: new[] { "Id", "KeyName", "Value" },
                values: new object[,]
                {
                    { 1L, "4.33", "Weekly" },
                    { 2L, "2.17", "Biweekly" },
                    { 3L, "2", "Bimonthly" },
                    { 5L, "0.833", "Yearly" },
                    { 4L, "1", "Monthly" }
                });

            migrationBuilder.InsertData(
                table: "Permission",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 6L, "UserChange" },
                    { 11L, "ReviewNotesCreate" },
                    { 24L, "AssessmentDelete" },
                    { 23L, "AssessmentUpdate" },
                    { 22L, "AssessmentCreate" },
                    { 21L, "AssessmentRead" },
                    { 19L, "ContactPreferenceCreate" },
                    { 18L, "ContactPreferenceRead" },
                    { 17L, "GuarantorUpdate" },
                    { 16L, "GuarantorCreate" },
                    { 15L, "GuarantorRead" },
                    { 14L, "PatientUpdate" },
                    { 13L, "PatientCreate" },
                    { 12L, "PatientRead" },
                    { 20L, "ContactPreferenceUpdate" },
                    { 9L, "AssessmentSummaryRead" },
                    { 8L, "AdvocateDashboardRead" },
                    { 7L, "PatientDashboardRead" },
                    { 5L, "UserRead" },
                    { 4L, "AddressDelete" },
                    { 3L, "AddressUpdate" },
                    { 2L, "AddressCreate" },
                    { 1L, "AddressRead" },
                    { 10L, "ReviewNotesRead" }
                });

            migrationBuilder.InsertData(
                table: "Program",
                columns: new[] { "Id", "CreatedBy", "CreatedDate", "Details", "Name", "UpdatedBy", "UpdatedDate" },
                values: new object[,]
                {
                    { 5L, null, new DateTime(2021, 12, 22, 12, 34, 17, 662, DateTimeKind.Utc).AddTicks(2627), "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur", "Aid and Attendance", null, null },
                    { 6L, null, new DateTime(2021, 12, 22, 12, 34, 17, 662, DateTimeKind.Utc).AddTicks(2628), "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur", "Program 1", null, null },
                    { 1L, null, new DateTime(2021, 12, 22, 12, 34, 17, 662, DateTimeKind.Utc).AddTicks(2584), "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur", "Veteran Administration (VA)", null, null },
                    { 2L, null, new DateTime(2021, 12, 22, 12, 34, 17, 662, DateTimeKind.Utc).AddTicks(2624), "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur", "Memorial Hospital Financial Assistance", null, null },
                    { 3L, null, new DateTime(2021, 12, 22, 12, 34, 17, 662, DateTimeKind.Utc).AddTicks(2625), "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur", "Senior Citizens Assistance", null, null },
                    { 4L, null, new DateTime(2021, 12, 22, 12, 34, 17, 662, DateTimeKind.Utc).AddTicks(2626), "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur", "TX Crime Victim", null, null }
                });

            migrationBuilder.InsertData(
                table: "RelationshipToPatient",
                columns: new[] { "Id", "KeyName", "Value" },
                values: new object[,]
                {
                    { 9L, "EMR", "Employer" },
                    { 25L, "SEL", "Self" },
                    { 30L, "UNK", "Unknown" },
                    { 29L, "TRA", "Trainer​​" },
                    { 28L, "SPO", "Spouse​" },
                    { 27L, "SIS", "Sister" }
                });

            migrationBuilder.InsertData(
                table: "RelationshipToPatient",
                columns: new[] { "Id", "KeyName", "Value" },
                values: new object[,]
                {
                    { 26L, "SIB", "Sibling​" },
                    { 19L, "NCH", "Natural child" },
                    { 18L, "MTH", "Mother​" },
                    { 17L, "MGR", "Manager​" },
                    { 16L, "GRP", "Grandparent" },
                    { 15L, "GRD", "Guardian" },
                    { 14L, "GCH", "Grandchild" },
                    { 13L, "FTH", "Father​" },
                    { 12L, "FND", "Friend" },
                    { 3L, "CGV", "Care giver​" },
                    { 4L, "CHD", "Child" },
                    { 5L, "DEP", "Handicapped dependent​" },
                    { 6L, "DOM", "Life partner" },
                    { 7L, "EMC", "Emergency contact" },
                    { 8L, "EME", "Employee​" },
                    { 31L, "WRD", "Ward of court​" },
                    { 10L, "EXF", "Extended family" },
                    { 11L, "FCH", "Foster child" },
                    { 24L, "SCH", "Stepchild" },
                    { 23L, "PAR", "Parent" },
                    { 22L, "OWN", "Owner​​" },
                    { 1L, "ASC", "Associate" },
                    { 2L, "BRO", "Brother" },
                    { 21L, "OTH", "Other" },
                    { 20L, "OAD", "Other adult​" }
                });

            migrationBuilder.InsertData(
                table: "ResourceType",
                columns: new[] { "Id", "KeyName", "Value" },
                values: new object[,]
                {
                    { 7L, "RPL", "Real Property, Land" },
                    { 22L, "DNP", "Do Not Want to Provide​​​" },
                    { 21L, "DK", "Don’t Know" },
                    { 20L, "PPP", "Pension Plans​" },
                    { 19L, "PESP", "Educational Saving Plan" },
                    { 18L, "PI", "Life Insurance​​" },
                    { 8L, "RPLS", "Real Property, Life Estates​" },
                    { 17L, "PIDA", "Individual Development Accounts​" },
                    { 15L, "PHS", "Home Sale Proceeds​" },
                    { 14L, "PFA", "Funeral Agreements" },
                    { 13L, "PEA", "Escrow Accounts​" },
                    { 12L, "PCC", "Contracts for Care​" },
                    { 11L, "PCF", "Commingled Funds" },
                    { 10L, "PBS", "Burial Spaces" },
                    { 1L, "PCA", "Cash Assets" },
                    { 2L, "IRA", "IRA/401K​" },
                    { 3L, "PV", "Vehicle, Primary​" }
                });

            migrationBuilder.InsertData(
                table: "ResourceType",
                columns: new[] { "Id", "KeyName", "Value" },
                values: new object[,]
                {
                    { 9L, "PBF", "Burial Funds" },
                    { 5L, "RPH", "Real Property, Home​" },
                    { 6L, "RPB", "Real Property, Building​" },
                    { 16L, "PIP", "Income Producing Property​" },
                    { 4L, "NPV", "Vehicle, Non-Primary" }
                });

            migrationBuilder.InsertData(
                table: "ResourceTypeCurrentStatus",
                columns: new[] { "Id", "KeyName", "Value" },
                values: new object[,]
                {
                    { 3L, "SMT1", "Sold More Than 1 Year Ago​" },
                    { 4L, "TLT1", "Transferred Less Than 5 Years Ago" },
                    { 2L, "SLT1", "Sold Less Than 1 Year Ago​" },
                    { 5L, "TMT1", "Transferred More Than 5 Years Ago​" },
                    { 1L, "CO", "Currently Owned​" }
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "RoleName" },
                values: new object[,]
                {
                    { 2L, "Advocate" },
                    { 1L, "Patient" }
                });

            migrationBuilder.InsertData(
                table: "Screen",
                columns: new[] { "Id", "Content", "Description", "IsActive", "IsRequired", "Name", "Order" },
                values: new object[,]
                {
                    { 8L, "General Information", "Kindly answer few questions to help you better. The questions includes on your health conditions.", false, false, "General Information screen", 0L },
                    { 7L, "Household Income & Resources", "Let us know the total income & resources of your household. It includes the income & resources of your & your household members also.", false, false, "Household Income & Resource screen", 0L },
                    { 2L, "Residential Zip Code", "Enter the Zip code to let us know your location to help you.", false, false, "Zip code screen", 0L },
                    { 3L, "Citizenship Status", "Let us know your citizenship", false, false, "Citizenship screen", 0L },
                    { 4L, "Patient Demographics", "Kindly fill your legal name and other demographic details.", false, false, "Patient Demographics screen", 0L },
                    { 5L, "Insurance Coverage", "Do you have/had any health insurance? If yes, let us know your insurance details.", false, false, "Insurance screen", 0L },
                    { 6L, "Household Members", "Let us know the total number of members in your household.", false, false, "Household Members screen", 0L },
                    { 1L, "Let's get you started", "Select the patient type to proceed quick assessment.", false, false, "Start screen", 0L }
                });

            migrationBuilder.InsertData(
                table: "ScreenQuestionMapping",
                columns: new[] { "Id", "KeyName", "QuestionId", "ScreenId" },
                values: new object[,]
                {
                    { 32L, "healthConditiion", 33L, 8L },
                    { 37L, "reportFiledJob", 37L, 8L },
                    { 36L, "reportFiledMotor", 36L, 8L },
                    { 35L, "aboutYourself", 6L, 4L },
                    { 34L, "reportFiledCrime", 35L, 8L },
                    { 33L, "beenInjured", 34L, 8L },
                    { 31L, "serviceProgram", 32L, 8L },
                    { 11L, "email", 12L, 4L },
                    { 29L, "incomePayPeriod", 30L, 7L },
                    { 1L, "patient", 1L, 1L },
                    { 2L, "zipCode", 2L, 2L },
                    { 3L, "city", 3L, 2L },
                    { 4L, "state", 4L, 2L },
                    { 5L, "citizenshipStatus", 5L, 3L },
                    { 6L, "firstName", 7L, 4L },
                    { 7L, "lastName", 8L, 4L },
                    { 8L, "dateOfBirth", 9L, 4L },
                    { 9L, "gender", 10L, 4L },
                    { 10L, "maritalStatus", 11L, 4L },
                    { 30L, "householdResources", 31L, 7L },
                    { 13L, "insurance", 14L, 5L },
                    { 14L, "policyDetails", 15L, 5L }
                });

            migrationBuilder.InsertData(
                table: "ScreenQuestionMapping",
                columns: new[] { "Id", "KeyName", "QuestionId", "ScreenId" },
                values: new object[,]
                {
                    { 12L, "cellNumber", 13L, 4L },
                    { 16L, "groupName", 17L, 5L },
                    { 28L, "householdIncome", 29L, 7L },
                    { 27L, null, 28L, 7L },
                    { 26L, "programServices", 27L, 6L },
                    { 15L, "payerName", 16L, 5L },
                    { 24L, "isEmployed", 25L, 6L },
                    { 23L, "minorChildren", 24L, 6L },
                    { 25L, "isHouseholdEmployed", 26L, 6L },
                    { 22L, "noOfHousehold", 23L, 6L },
                    { 21L, null, 22L, 6L },
                    { 20L, "termination", 21L, 5L },
                    { 19L, "effectiveFrom", 20L, 5L },
                    { 18L, "policyNumber", 19L, 5L },
                    { 17L, "groupNumber", 18L, 5L }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CanChangePassword", "Cell", "City", "County", "CountyCode", "CreatedBy", "CreatedDate", "DateOfBirth", "EmailAddress", "FirstName", "Gender", "IsActive", "IsAuthenticated", "IsTokenConsumed", "IsTwoFactorEnabled", "LastName", "LoginOTPUpdatedTime", "MailingAddressCell", "MailingAddressCountyCode", "MaritalStatus", "MiddleName", "OtpNumber", "Password", "SSNNumber", "State", "StreetAddress", "Suite", "UpdatedBy", "UpdatedDate", "ZipCode" },
                values: new object[,]
                {
                    { -1L, false, "1111111111", null, null, "-1", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "dummy", null, null, true, false, false, null, null, null, null, null, null, null, null, "$2a$12$p31SUhN7u4/N00.HVQJBGeT7c6HDaCmgUUqn3fPqwcySL2WD9P2cq", null, null, null, null, null, null, null },
                    { 1L, false, "2222222222", null, null, "1", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1996, 11, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "naresh.k@zucisystems.com", "Naresh", "Male", true, false, false, null, "Kumar", null, null, null, "Single", null, null, "$2a$12$GsroJZ1ipRFMg6blXPK8UOHu0INC2baFUzjmbzcOtEECD3cuKQ502", "2121288888", null, null, null, null, null, null },
                    { 2L, false, "3333333333", null, null, "-1", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1996, 11, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "iniya.j@zucisystems.com", "Iniya", "Female", true, false, false, null, "J", null, null, null, "Married", null, null, "$2a$12$LpqBpHjP2jW6CBVeHPP.TORmauJMLHk3ECwP32pq.YY4CuQSTbi82", "2121277777", null, null, null, null, null, null }
                });

            migrationBuilder.InsertData(
                table: "Verification",
                columns: new[] { "Id", "KeyName", "Value" },
                values: new object[,]
                {
                    { 4L, "ANV", "Accepted, Not Verified" },
                    { 3L, "UV", "Unable to Verify" },
                    { 2L, "V", "Verified" },
                    { 1L, "NV", "Not Yet Verified" }
                });

            migrationBuilder.InsertData(
                table: "DocumentCategoryDocumentTypeMapping",
                columns: new[] { "Id", "DocumentCategoryMasterId", "DocumentTypeMasterId" },
                values: new object[,]
                {
                    { 11L, 3L, 8L },
                    { 8L, 2L, 1L },
                    { 2L, 1L, 2L },
                    { 3L, 1L, 3L },
                    { 4L, 1L, 4L },
                    { 5L, 1L, 5L },
                    { 9L, 2L, 5L },
                    { 6L, 1L, 6L },
                    { 7L, 1L, 7L },
                    { 10L, 2L, 7L },
                    { 12L, 3L, 9L },
                    { 1L, 1L, 1L },
                    { 13L, 3L, 10L },
                    { 15L, 4L, 12L },
                    { 16L, 5L, 13L },
                    { 17L, 5L, 14L },
                    { 14L, 3L, 11L }
                });

            migrationBuilder.InsertData(
                table: "ProgramDocument",
                columns: new[] { "Id", "CreatedBy", "CreatedDate", "DocumentDescription", "DocumentName", "DocumentPath", "DocumentSize", "ProgramId", "UpdatedBy", "UpdatedDate" },
                values: new object[,]
                {
                    { 7L, null, new DateTime(2021, 12, 22, 12, 34, 17, 662, DateTimeKind.Utc).AddTicks(4429), "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur", "135 Form MO IM60A Doctor Medical Statement", "C:\\inetpub\\wwwroot\\Healthware_ProgramFiles\\4\\9\\147_Form_VA_Form_9_Veterans_Appeals.pdf", null, 4L, null, null },
                    { 6L, null, new DateTime(2021, 12, 22, 12, 34, 17, 662, DateTimeKind.Utc).AddTicks(4428), "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur", "136 Form MO IM60A Doctor Medical Statement", "C:\\inetpub\\wwwroot\\Healthware_ProgramFiles\\4\\8\\147_Form_VA_Form_9_Veterans_Appeals.pdf", null, 4L, null, null },
                    { 5L, null, new DateTime(2021, 12, 22, 12, 34, 17, 662, DateTimeKind.Utc).AddTicks(4425), "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur", "137 Form MO IM60A Doctor Medical Statement", "C:\\inetpub\\wwwroot\\Healthware_ProgramFiles\\7\\3\\147_Form_VA_Form_9_Veterans_Appeals.pdf", null, 3L, null, null },
                    { 4L, null, new DateTime(2021, 12, 22, 12, 34, 17, 662, DateTimeKind.Utc).AddTicks(4423), "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur", "138 Form MO IM60A Doctor Medical Statement", "C:\\inetpub\\wwwroot\\Healthware_ProgramFiles\\3\\6\\147_Form_VA_Form_9_Veterans_Appeals.pdf", null, 3L, null, null },
                    { 3L, null, new DateTime(2021, 12, 22, 12, 34, 17, 662, DateTimeKind.Utc).AddTicks(4421), "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur", "134 Form MO IM60A Doctor Medical Statement", "C:\\inetpub\\wwwroot\\Healthware_ProgramFiles\\2\\5\\147_Form_VA_Form_9_Veterans_Appeals.pdf", null, 2L, null, null },
                    { 2L, null, new DateTime(2021, 12, 22, 12, 34, 17, 662, DateTimeKind.Utc).AddTicks(4367), "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur", "140 Form MO Crime Victim Application", "C:\\inetpub\\wwwroot\\Healthware_ProgramFiles\\2\\4\\147_Form_VA_Form_9_Veterans_Appeals.pdf", null, 2L, null, null },
                    { 1L, null, new DateTime(2021, 12, 22, 12, 34, 17, 662, DateTimeKind.Utc).AddTicks(2788), "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur", "147 Form VA Form 9 Veterans Appeals", "C:\\inetpub\\wwwroot\\Healthware_ProgramFiles\\1\\147_Form_VA_Form_9_Veterans_Appeals.pdf", null, 1L, null, null }
                });

            migrationBuilder.InsertData(
                table: "Question",
                columns: new[] { "Id", "ControlId", "CssStyle", "Description", "DisplayFormat", "IsRequired", "ParentId", "QuestionName", "Type", "UiType" },
                values: new object[,]
                {
                    { 36L, 8L, "tgl_style", null, "header", true, 34L, "Was a report filed?", null, null },
                    { 37L, 8L, "tgl_style", null, "header", true, 34L, "Was a report filed?", null, null },
                    { 2L, 1L, "txt_zip_style1", null, "header", true, null, "Please enter your Zip code", null, null },
                    { 35L, 8L, "tgl_style", null, "header", true, 34L, "Was a report filed?", null, null },
                    { 23L, 11L, "numeric_counter_style", null, "header", true, null, "Total Number of members living in your household", null, null },
                    { 26L, 8L, "tgl_style", null, "header", true, 25L, "Is anyone in your household employed?", null, null },
                    { 24L, 11L, "numeric_counter_style", null, "header", true, null, "Minor children for whom you have full custody?", null, null },
                    { 14L, 8L, "tgl_style", null, "header", true, null, "Do you currently or in the last 60 days have/had health insurance?", null, null },
                    { 18L, 1L, "txt_style1", null, "inline", true, 14L, "Group Number", null, null },
                    { 19L, 1L, "txt_style1", null, "inline", true, 14L, "Policy Number", null, null },
                    { 10L, 2L, "dd_gender_class", null, "inline", true, null, "Gender", null, null },
                    { 11L, 2L, "dd_marital_class", null, "inline", true, null, "Marital Status", null, null },
                    { 30L, 2L, "dd_income_class", null, "inline", true, null, "Income pay period", null, null },
                    { 1L, 3L, "rbn_style1", null, "header", true, null, "Let us know who the patient is.", null, null },
                    { 5L, 3L, "rbn_style1", null, "header", true, null, "Confirm your citizenship status", null, null },
                    { 27L, 3L, "rbn_style1", "If none of them apply, you can directly move to the next question.", "header", true, 26L, "Do you currently receive any of the following?", null, null },
                    { 25L, 8L, "tgl_style", null, "header", true, null, "Are you employed?", null, null },
                    { 33L, 3L, "rbn_style1", null, "header", true, null, "Do any of the following health conditions apply to you?", null, null }
                });

            migrationBuilder.InsertData(
                table: "Question",
                columns: new[] { "Id", "ControlId", "CssStyle", "Description", "DisplayFormat", "IsRequired", "ParentId", "QuestionName", "Type", "UiType" },
                values: new object[,]
                {
                    { 34L, 3L, "rbn_style1", null, "header", true, null, "Select if you have been injured", null, null },
                    { 6L, 4L, "label", null, "header", false, null, "Tell us about yourself", null, null },
                    { 15L, 4L, "label", null, "header", false, 14L, "Enter the following details", null, null },
                    { 22L, 4L, "label", null, "header", false, null, "Tell us about your household", null, null },
                    { 32L, 3L, "rbn_style1", "If none of them apply, you can directly move to the next question.", "header", false, null, "Please select the options that apply to you and click on next.", null, null },
                    { 3L, 5L, "txt_style1", "Please enter your city", "inline", true, null, "City", null, null },
                    { 28L, 4L, "label", null, "header", false, null, "Enter household income and resources", null, null },
                    { 21L, 6L, "dt_birth", null, "inline", true, 14L, "Termination", null, null },
                    { 20L, 6L, "dt_birth", null, "inline", true, 14L, "Effective From", null, null },
                    { 9L, 6L, "dt_birth", null, "inline", false, null, "date of birth", null, null },
                    { 31L, 5L, "txt_style1", "Please estimate the total resource value held by all the members of the household in the form  of checking & savings, retirement accounts, property (home, vehicle, etc) and any others assets.", "header", true, null, "Estimated Household Resources", null, null },
                    { 29L, 5L, "txt_style1", null, "header", true, null, "Estimated Household Income", null, null },
                    { 13L, 7L, "txt_style3", null, "inline", true, null, "Cell number", null, null },
                    { 16L, 5L, "txt_style1", null, "inline", false, 14L, "Payer Name", null, null },
                    { 12L, 5L, "txt_style2", null, "partition", true, null, "Email", null, null },
                    { 8L, 5L, "txt_style1", null, "inline", true, null, "Last Name", null, null },
                    { 7L, 5L, "txt_style1", null, "inline", true, null, "First Name", null, null },
                    { 4L, 5L, "txt_style1", null, "inline", true, null, "State", null, null },
                    { 17L, 5L, "txt_style1", null, "inline", true, 14L, "Group Name", null, null }
                });

            migrationBuilder.InsertData(
                table: "QuickAssessmentQuestions",
                columns: new[] { "Id", "AlertInfo", "Class", "CreatedBy", "CreatedDate", "CustomValidation", "DynamicScreensId", "ErrorMessageInfo", "FieldName", "FieldTypeId", "InlineLabel", "IsInlineLabel", "MaximumDate", "MessageInfo", "OrderId", "OthersLabel", "ParentQuestionId", "PatientLabel", "Placeholder", "Required", "ScreenHeaderOthersLabel", "ScreenHeaderPatientLabel", "ScreenId", "TermAndConditionPopupMessage", "TermAndConditionsMessageLabel", "TextBoxSubLabel", "UniqueKey", "UpdatedBy", "UpdatedDate", "Value" },
                values: new object[,]
                {
                    { 15L, null, "col-5", null, new DateTime(2021, 12, 22, 12, 34, 17, 659, DateTimeKind.Utc).AddTicks(9514), null, 5L, null, "Group Name", 6L, null, false, null, null, "5", null, 13L, null, "Group Name", true, null, null, "5", null, null, null, "groupname", null, null, null },
                    { 16L, null, "col-5", null, new DateTime(2021, 12, 22, 12, 34, 17, 660, DateTimeKind.Utc).AddTicks(130), null, 5L, null, "Group Number", 6L, "Group No.", true, null, null, "5", null, 13L, null, "Group Number", true, null, null, "5", null, null, null, "groupNo", null, null, null },
                    { 17L, "Invalid policy Number", "col-5", null, new DateTime(2021, 12, 22, 12, 34, 17, 660, DateTimeKind.Utc).AddTicks(779), "PolicyNumber", 5L, "Your visit can be covered under your insurance. Please get in touch with your insurance provider for more information.", "Policy Number", 6L, "Policy No.", true, null, "Your visit can be covered under your insurance. Please get in touch with your insurance provider for more information.", "6", null, 13L, null, "Policy Number", true, null, null, "5", null, null, null, "policyNo", null, null, null },
                    { 25L, null, "col-5", null, new DateTime(2021, 12, 22, 12, 34, 17, 660, DateTimeKind.Utc).AddTicks(6514), null, 7L, null, "Household Income", 6L, null, false, null, null, "2", "Estimated Household Income", null, "Estimated Household Income", "Income", true, "Enter patient's household income and resources", "Enter household income and resources", "7", null, null, null, "householdIncome", null, null, null },
                    { 27L, null, "col-5", null, new DateTime(2021, 12, 22, 12, 34, 17, 660, DateTimeKind.Utc).AddTicks(8094), null, 7L, "Please estimate the total resource value held by all the members of the household in the form of checking & savings, retirement accounts, property (home, vehicle, etc) and any others assets.", "Household Resources", 6L, "$", true, null, "Please estimate the total resource value held by all the members of the household in the form of checking & savings, retirement accounts, property (home, vehicle, etc) and any others assets.", "4", null, null, null, "Resources", true, "Estimated Household Resources", "Estimated Household Resources", "7", null, null, null, "householdResources", null, null, null },
                    { 23L, null, "col-5", null, new DateTime(2021, 12, 22, 12, 34, 17, 660, DateTimeKind.Utc).AddTicks(4985), "Yes", 6L, null, "Is Household Employed", 7L, null, false, null, null, "1", "Is anyone in your household employed?", 22L, "Is anyone in your household employed?", null, true, null, null, "6", null, null, null, "isHouseholdEmployed", null, null, null },
                    { 22L, null, "col-5", null, new DateTime(2021, 12, 22, 12, 34, 17, 660, DateTimeKind.Utc).AddTicks(4233), "Yes/No", 6L, null, "Is Employed", 7L, null, false, null, null, "4", "Is the patient employed?", null, "Are you employed?", null, true, null, null, "6", null, null, null, "isEmployed", null, null, null },
                    { 31L, null, "col-5", null, new DateTime(2021, 12, 22, 12, 34, 17, 661, DateTimeKind.Utc).AddTicks(661), null, 10L, null, "Is Report Filed", 7L, null, false, null, null, "1", null, 30L, null, null, false, "Report Filed?", "Report Filed?", "10", null, null, null, "reportFiled", null, null, null },
                    { 33L, null, "col-12", null, new DateTime(2021, 12, 22, 12, 34, 17, 661, DateTimeKind.Utc).AddTicks(2031), null, 11L, null, null, 8L, null, false, null, null, "2", null, null, null, null, true, null, null, "11", null, null, null, "agreementCheckBox", null, null, null },
                    { 32L, null, "col-5", null, new DateTime(2021, 12, 22, 12, 34, 17, 661, DateTimeKind.Utc).AddTicks(1318), null, 11L, null, null, 9L, null, false, null, "Your SSN is secure with us. We ask for this information as most government agencies require this number when submitting an application for benefits.", "1", null, null, null, "SSN", true, "Last Step. Please provide patient''s SSN', N'Last Step. Please provide your SSN", "Last Step. Please provide your SSN", "11", null, null, null, "ssnNumber", null, null, null },
                    { 14L, null, "col-5", null, new DateTime(2021, 12, 22, 12, 34, 17, 659, DateTimeKind.Utc).AddTicks(8795), null, 5L, null, "Payer Name", 6L, null, false, null, null, "4", null, 12L, null, "Payer name", true, "Enter the following details", "Enter the following details", "5", null, null, null, "payerName", null, null, null },
                    { 13L, "Invalid policy Number", "col-12", null, new DateTime(2021, 12, 22, 12, 34, 17, 659, DateTimeKind.Utc).AddTicks(7863), "Yes", 5L, "Your visit can be covered under your insurance. Please get in touch with your insurance provider for more information.", "Insurance", 7L, null, false, null, null, "2", null, null, null, null, true, "Does the patient currently or in the last 60 days have/had health insurance?", "Do you currently or in the last 60 days have/had health insurance?", "5", null, null, null, "insurance", null, null, null },
                    { 11L, null, "col-5", null, new DateTime(2021, 12, 22, 12, 34, 17, 659, DateTimeKind.Utc).AddTicks(7133), null, 4L, null, "Email", 6L, "Email", true, null, null, "6", null, null, null, "Email", true, null, null, "4", null, null, null, "email", null, null, null },
                    { 1L, null, "col-12", null, new DateTime(2021, 12, 22, 12, 34, 17, 659, DateTimeKind.Utc).AddTicks(174), null, 1L, null, "Patient", 5L, null, false, null, null, "2", null, null, null, "Select Patient Type", true, null, "Let us know who the patient is.", "1", null, null, null, "patient", null, null, null },
                    { 6L, null, "col-5", null, new DateTime(2021, 12, 22, 12, 34, 17, 659, DateTimeKind.Utc).AddTicks(5386), null, 4L, null, "First Name", 6L, null, false, null, null, "2", null, null, null, "First Name", true, "Tell us more about the patient.", "Tell us about yourself", "4", null, null, "Please enter the legal name.", "firstName", null, null, null },
                    { 7L, null, "col-5", null, new DateTime(2021, 12, 22, 12, 34, 17, 659, DateTimeKind.Utc).AddTicks(6359), null, 4L, null, "Last Name", 6L, null, false, null, null, "3", null, null, null, "Last Name", true, null, null, "4", null, null, null, "lastName", null, null, null },
                    { 12L, null, "col-5", null, new DateTime(2021, 12, 22, 12, 34, 17, 659, DateTimeKind.Utc).AddTicks(7850), null, 4L, null, "Cell Number", 1L, "Cell", true, null, null, "6", null, null, null, "Cell Number", true, null, null, "4", null, null, null, "cellNumber", null, null, null },
                    { 20L, null, "col-5", null, new DateTime(2021, 12, 22, 12, 34, 17, 660, DateTimeKind.Utc).AddTicks(1684), null, 6L, null, "Household Members", 2L, null, false, null, null, "2", "Total Number of members living in patient's household", null, "Total Number of members living in your household", null, true, "Tell us about your household", "Tell us more about patient's household", "6", null, null, null, "totalHouseholdMembers", null, null, "1" },
                    { 8L, null, "col-5", null, new DateTime(2021, 12, 22, 12, 34, 17, 659, DateTimeKind.Utc).AddTicks(6361), null, 4L, null, "Date of Birth", 3L, null, false, "today", null, "4", null, null, null, "mm/dd/yyyy", true, null, null, "4", null, null, null, "dateOfBirth", null, null, null },
                    { 18L, null, "col-5", null, new DateTime(2021, 12, 22, 12, 34, 17, 660, DateTimeKind.Utc).AddTicks(1668), null, 5L, null, "Effective From", 3L, "Effective From", true, null, null, "7", null, 13L, null, "Effective From", true, null, null, "5", null, null, null, "effectiveFrom", null, null, null },
                    { 19L, null, "col-5", null, new DateTime(2021, 12, 22, 12, 34, 17, 660, DateTimeKind.Utc).AddTicks(1683), null, 5L, null, "Termination Date", 3L, "Termination", true, null, null, "8", null, 13L, null, "Termination", true, null, null, "5", null, null, null, "termination", null, null, null },
                    { 9L, null, "col-5", null, new DateTime(2021, 12, 22, 12, 34, 17, 659, DateTimeKind.Utc).AddTicks(7129), null, 4L, null, "Gender", 4L, null, false, null, null, "5", null, null, null, "Gender", true, null, null, "4", null, null, null, "gender", null, null, null },
                    { 10L, null, "col-5", null, new DateTime(2021, 12, 22, 12, 34, 17, 659, DateTimeKind.Utc).AddTicks(7131), null, 4L, null, "Marital Status", 4L, null, false, null, null, "6", null, null, null, "Marital Status", true, null, null, "4", null, null, null, "maritalStatus", null, null, null }
                });

            migrationBuilder.InsertData(
                table: "QuickAssessmentQuestions",
                columns: new[] { "Id", "AlertInfo", "Class", "CreatedBy", "CreatedDate", "CustomValidation", "DynamicScreensId", "ErrorMessageInfo", "FieldName", "FieldTypeId", "InlineLabel", "IsInlineLabel", "MaximumDate", "MessageInfo", "OrderId", "OthersLabel", "ParentQuestionId", "PatientLabel", "Placeholder", "Required", "ScreenHeaderOthersLabel", "ScreenHeaderPatientLabel", "ScreenId", "TermAndConditionPopupMessage", "TermAndConditionsMessageLabel", "TextBoxSubLabel", "UniqueKey", "UpdatedBy", "UpdatedDate", "Value" },
                values: new object[,]
                {
                    { 26L, null, "col-5", null, new DateTime(2021, 12, 22, 12, 34, 17, 660, DateTimeKind.Utc).AddTicks(7346), null, 7L, "Include income earned by all the members of the household.", "Income Pay Period", 4L, null, false, null, "Include income earned by all the members of the household.", "3", null, null, null, "Gross Pay", true, null, null, "7", null, null, null, "incomePayPeriod", null, null, null },
                    { 21L, null, "col-5", null, new DateTime(2021, 12, 22, 12, 34, 17, 660, DateTimeKind.Utc).AddTicks(2955), null, 6L, null, "Total Minors", 2L, null, false, null, null, "3", "Minor children for whom the patient has full custody?", null, "Minor children for whom you have full custody?", null, true, null, null, "6", null, null, null, "totalMinors", null, null, "0" },
                    { 5L, "Your state does not provide financial assistance to patients with unknown citizenship status.", "col-5", null, new DateTime(2021, 12, 22, 12, 34, 17, 659, DateTimeKind.Utc).AddTicks(4446), "Unknown", 3L, "Any further assistance message (if applicable) goes here. Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore", "Citizenship", 5L, null, false, null, null, "2", null, null, null, "Select Citizenship", true, "Confirm patient's citizenship status", "Confirm your citizenship status.", "3", null, null, null, "citizenship", null, null, null },
                    { 24L, null, "col-12", null, new DateTime(2021, 12, 22, 12, 34, 17, 660, DateTimeKind.Utc).AddTicks(5707), null, 6L, "If none of them apply, you can directly move to the next question.", "Program Services", 5L, null, false, null, "If none of them apply, you can directly move to the next question.", "1", null, 23L, null, null, false, "Do you currently receive any of the following?", "Do you currently receive any of the following?", "6", null, null, null, "programServices", null, null, null },
                    { 28L, null, "col-12", null, new DateTime(2021, 12, 22, 12, 34, 17, 660, DateTimeKind.Utc).AddTicks(9023), "Any", 8L, "If none of them apply, you can directly move to the next question.", "Service Program", 5L, null, false, null, "If none of them apply, you can directly move to the next question.", "1", null, null, null, null, false, "Please select the options that apply to you and click on next.", "Please select the options that apply to you and click on next.", "8", null, null, null, "serviceProgram", null, null, null },
                    { 29L, null, "col-12", null, new DateTime(2021, 12, 22, 12, 34, 17, 660, DateTimeKind.Utc).AddTicks(9847), "Any", 9L, null, "Health Condition", 5L, null, false, null, null, "1", null, null, null, null, false, "Do any of the following health conditions apply to you?", "Do any of the following health conditions apply to you?", "9", null, null, null, "healthConditiion", null, null, null },
                    { 30L, null, "col-12", null, new DateTime(2021, 12, 22, 12, 34, 17, 661, DateTimeKind.Utc).AddTicks(646), "Any", 10L, null, "Been Injured", 5L, null, false, null, null, "1", null, null, null, null, false, "Select if you have been injured", "Select if you have been injured", "10", null, null, null, "beenInjured", null, null, null },
                    { 2L, null, "col-5", null, new DateTime(2021, 12, 22, 12, 34, 17, 659, DateTimeKind.Utc).AddTicks(1861), "Zipcode", 2L, null, "Zip Code", 6L, null, false, null, null, "2", null, null, null, "Zip Code", false, "Please enter patients Zip code.", "Please enter your Zip code.", "2", null, null, null, "zipCode", null, null, null },
                    { 3L, null, "col-5", null, new DateTime(2021, 12, 22, 12, 34, 17, 659, DateTimeKind.Utc).AddTicks(3205), null, 2L, null, "City", 6L, null, false, null, null, "3", null, null, null, "City", false, null, null, "2", null, null, null, "city", null, null, null },
                    { 4L, null, "col-5", null, new DateTime(2021, 12, 22, 12, 34, 17, 659, DateTimeKind.Utc).AddTicks(4388), null, 2L, null, "State", 6L, null, false, null, null, "3", null, null, null, "State", false, null, null, "2", null, null, null, "state", null, null, null }
                });

            migrationBuilder.InsertData(
                table: "RolesPermissions",
                columns: new[] { "Id", "PermissionId", "RoleId" },
                values: new object[,]
                {
                    { 19L, 12L, 2L },
                    { 20L, 13L, 2L },
                    { 21L, 14L, 2L },
                    { 22L, 15L, 2L },
                    { 23L, 16L, 2L },
                    { 24L, 17L, 2L },
                    { 27L, 20L, 2L },
                    { 26L, 19L, 2L },
                    { 31L, 3L, 2L },
                    { 28L, 24L, 2L },
                    { 29L, 1L, 2L },
                    { 30L, 2L, 2L },
                    { 18L, 11L, 2L },
                    { 25L, 18L, 2L },
                    { 17L, 10L, 2L },
                    { 7L, 17L, 1L },
                    { 15L, 8L, 2L },
                    { 1L, 7L, 1L },
                    { 2L, 12L, 1L },
                    { 3L, 13L, 1L },
                    { 4L, 14L, 1L },
                    { 5L, 15L, 1L },
                    { 16L, 9L, 2L },
                    { 6L, 16L, 1L },
                    { 9L, 19L, 1L },
                    { 10L, 20L, 1L },
                    { 11L, 24L, 1L },
                    { 12L, 1L, 1L },
                    { 13L, 2L, 1L },
                    { 14L, 3L, 1L },
                    { 8L, 18L, 1L }
                });

            migrationBuilder.InsertData(
                table: "UserHasRoles",
                columns: new[] { "Id", "RoleId", "UserId" },
                values: new object[] { 1L, 1L, 1L });

            migrationBuilder.InsertData(
                table: "UserHasRoles",
                columns: new[] { "Id", "RoleId", "UserId" },
                values: new object[] { 2L, 2L, 2L });

            migrationBuilder.InsertData(
                table: "Options",
                columns: new[] { "Id", "CreatedBy", "CreatedDate", "Name", "Order", "QuickAssessmentQuestionsId", "UpdatedBy", "UpdatedDate", "Value" },
                values: new object[,]
                {
                    { 39L, null, new DateTime(2021, 12, 22, 12, 34, 17, 661, DateTimeKind.Utc).AddTicks(3398), "No", 1, 22L, null, null, "No" },
                    { 2L, null, new DateTime(2021, 12, 22, 12, 34, 17, 661, DateTimeKind.Utc).AddTicks(3344), "other", 2, 1L, null, null, "Relative/Friend/Other" },
                    { 3L, null, new DateTime(2021, 12, 22, 12, 34, 17, 661, DateTimeKind.Utc).AddTicks(3358), "usCitizen", 1, 5L, null, null, "U.S. Citizen" },
                    { 4L, null, new DateTime(2021, 12, 22, 12, 34, 17, 661, DateTimeKind.Utc).AddTicks(3359), "legalResident", 2, 5L, null, null, "Legal Resident" },
                    { 5L, null, new DateTime(2021, 12, 22, 12, 34, 17, 661, DateTimeKind.Utc).AddTicks(3360), "undocumented", 3, 5L, null, null, "Undocumented" },
                    { 6L, null, new DateTime(2021, 12, 22, 12, 34, 17, 661, DateTimeKind.Utc).AddTicks(3362), "unknown", 4, 5L, null, null, "Unknown" },
                    { 36L, null, new DateTime(2021, 12, 22, 12, 34, 17, 661, DateTimeKind.Utc).AddTicks(3394), "onTheJob", 2, 30L, null, null, "On the job" },
                    { 18L, null, new DateTime(2021, 12, 22, 12, 34, 17, 661, DateTimeKind.Utc).AddTicks(3377), "calFresh", 1, 24L, null, null, "CalFresh (Food Stamps)" },
                    { 19L, null, new DateTime(2021, 12, 22, 12, 34, 17, 661, DateTimeKind.Utc).AddTicks(3378), "ssi", 2, 24L, null, null, "SSI / SSP" },
                    { 20L, null, new DateTime(2021, 12, 22, 12, 34, 17, 661, DateTimeKind.Utc).AddTicks(3379), "calWorks", 3, 24L, null, null, "CalWorks" },
                    { 1L, null, new DateTime(2021, 12, 22, 12, 34, 17, 661, DateTimeKind.Utc).AddTicks(2883), "myself", 1, 1L, null, null, "Myself" },
                    { 21L, null, new DateTime(2021, 12, 22, 12, 34, 17, 661, DateTimeKind.Utc).AddTicks(3380), "refugeeAssisstance", 4, 24L, null, null, "Refugee Assistance" },
                    { 45L, null, new DateTime(2021, 12, 22, 12, 34, 17, 661, DateTimeKind.Utc).AddTicks(4125), null, 1, 33L, null, null, "By clicking this box you acknowledge that you have received, reviewed and agree to the terms of use, privacy statement, e-signature disclosure and consent." },
                    { 28L, null, new DateTime(2021, 12, 22, 12, 34, 17, 661, DateTimeKind.Utc).AddTicks(3387), "pregnantNow", 1, 28L, null, null, "Pregnant now / in past 6 months" },
                    { 29L, null, new DateTime(2021, 12, 22, 12, 34, 17, 661, DateTimeKind.Utc).AddTicks(3388), "veteran", 2, 28L, null, null, "Veteran" },
                    { 30L, null, new DateTime(2021, 12, 22, 12, 34, 17, 661, DateTimeKind.Utc).AddTicks(3389), "memberOfIndianTribe", 3, 28L, null, null, "Member of Indian tribe" },
                    { 31L, null, new DateTime(2021, 12, 22, 12, 34, 17, 661, DateTimeKind.Utc).AddTicks(3390), "formerFosterYouth", 4, 28L, null, null, "Former Foster Youth" },
                    { 38L, null, new DateTime(2021, 12, 22, 12, 34, 17, 661, DateTimeKind.Utc).AddTicks(3397), "yes", 2, 13L, null, null, "Yes" },
                    { 32L, null, new DateTime(2021, 12, 22, 12, 34, 17, 661, DateTimeKind.Utc).AddTicks(3391), "deemed", 1, 29L, null, null, "Deemed as disabled for 12 months or longer" },
                    { 33L, null, new DateTime(2021, 12, 22, 12, 34, 17, 661, DateTimeKind.Utc).AddTicks(3392), "you/member", 2, 29L, null, null, "You/member of your family been declared legally blind" },
                    { 37L, null, new DateTime(2021, 12, 22, 12, 34, 17, 661, DateTimeKind.Utc).AddTicks(3396), "no", 1, 13L, null, null, "No" },
                    { 22L, null, new DateTime(2021, 12, 22, 12, 34, 17, 661, DateTimeKind.Utc).AddTicks(3381), "allOfTheAbove", 5, 24L, null, null, "All of the above" },
                    { 34L, null, new DateTime(2021, 12, 22, 12, 34, 17, 661, DateTimeKind.Utc).AddTicks(3392), "inCrime", 1, 30L, null, null, "In crime related violence (as a victim)" },
                    { 40L, null, new DateTime(2021, 12, 22, 12, 34, 17, 661, DateTimeKind.Utc).AddTicks(3399), "Yes", 2, 22L, null, null, "Yes" },
                    { 26L, null, new DateTime(2021, 12, 22, 12, 34, 17, 661, DateTimeKind.Utc).AddTicks(3385), "biweekly", 4, 26L, null, null, "Biweekly" },
                    { 17L, null, new DateTime(2021, 12, 22, 12, 34, 17, 661, DateTimeKind.Utc).AddTicks(3376), "W", 8, 21L, null, null, "Widowed" },
                    { 44L, null, new DateTime(2021, 12, 22, 12, 34, 17, 661, DateTimeKind.Utc).AddTicks(4111), null, 1, 31L, null, null, "Yes" },
                    { 43L, null, new DateTime(2021, 12, 22, 12, 34, 17, 661, DateTimeKind.Utc).AddTicks(3401), null, 1, 31L, null, null, "No" },
                    { 42L, null, new DateTime(2021, 12, 22, 12, 34, 17, 661, DateTimeKind.Utc).AddTicks(3400), "Yes", 2, 23L, null, null, "Yes" },
                    { 7L, null, new DateTime(2021, 12, 22, 12, 34, 17, 661, DateTimeKind.Utc).AddTicks(3364), "M", 1, 9L, null, null, "Male" },
                    { 8L, null, new DateTime(2021, 12, 22, 12, 34, 17, 661, DateTimeKind.Utc).AddTicks(3366), "F", 2, 9L, null, null, "Female" },
                    { 9L, null, new DateTime(2021, 12, 22, 12, 34, 17, 661, DateTimeKind.Utc).AddTicks(3367), "U", 3, 9L, null, null, "Unreported or Unknown" },
                    { 41L, null, new DateTime(2021, 12, 22, 12, 34, 17, 661, DateTimeKind.Utc).AddTicks(3399), "No", 1, 23L, null, null, "No" },
                    { 27L, null, new DateTime(2021, 12, 22, 12, 34, 17, 661, DateTimeKind.Utc).AddTicks(3386), "weekly", 5, 26L, null, null, "Weekly" },
                    { 11L, null, new DateTime(2021, 12, 22, 12, 34, 17, 661, DateTimeKind.Utc).AddTicks(3371), "D", 2, 10L, null, null, "Divorced" },
                    { 10L, null, new DateTime(2021, 12, 22, 12, 34, 17, 661, DateTimeKind.Utc).AddTicks(3369), "A", 1, 10L, null, null, "Separated" },
                    { 13L, null, new DateTime(2021, 12, 22, 12, 34, 17, 661, DateTimeKind.Utc).AddTicks(3372), "P", 4, 10L, null, null, "Domestic partner" },
                    { 14L, null, new DateTime(2021, 12, 22, 12, 34, 17, 661, DateTimeKind.Utc).AddTicks(3373), "S", 5, 10L, null, null, "Single" },
                    { 15L, null, new DateTime(2021, 12, 22, 12, 34, 17, 661, DateTimeKind.Utc).AddTicks(3374), "T", 6, 10L, null, null, "Unreported" },
                    { 16L, null, new DateTime(2021, 12, 22, 12, 34, 17, 661, DateTimeKind.Utc).AddTicks(3375), "U", 7, 10L, null, null, "Unknown" },
                    { 23L, null, new DateTime(2021, 12, 22, 12, 34, 17, 661, DateTimeKind.Utc).AddTicks(3382), "yearly", 1, 26L, null, null, "Yearly" },
                    { 24L, null, new DateTime(2021, 12, 22, 12, 34, 17, 661, DateTimeKind.Utc).AddTicks(3383), "monthly", 2, 26L, null, null, "Monthly" }
                });

            migrationBuilder.InsertData(
                table: "Options",
                columns: new[] { "Id", "CreatedBy", "CreatedDate", "Name", "Order", "QuickAssessmentQuestionsId", "UpdatedBy", "UpdatedDate", "Value" },
                values: new object[,]
                {
                    { 25L, null, new DateTime(2021, 12, 22, 12, 34, 17, 661, DateTimeKind.Utc).AddTicks(3384), "bimonthly", 3, 26L, null, null, "Bimonthly" },
                    { 12L, null, new DateTime(2021, 12, 22, 12, 34, 17, 661, DateTimeKind.Utc).AddTicks(3371), "M", 3, 10L, null, null, "Married" },
                    { 35L, null, new DateTime(2021, 12, 22, 12, 34, 17, 661, DateTimeKind.Utc).AddTicks(3393), "inMotorVehicle", 2, 30L, null, null, "In motor vehicle accident" }
                });

            migrationBuilder.InsertData(
                table: "Validators",
                columns: new[] { "Id", "CreatedBy", "CreatedDate", "MaxLength", "MinLength", "PatternId", "QuickAssessmentQuestionsId", "Required", "UpdatedBy", "UpdatedDate" },
                values: new object[,]
                {
                    { 25L, null, new DateTime(2021, 12, 22, 12, 34, 17, 661, DateTimeKind.Utc).AddTicks(5544), 1000, 0, 2L, 25L, true, null, null },
                    { 17L, null, new DateTime(2021, 12, 22, 12, 34, 17, 661, DateTimeKind.Utc).AddTicks(5535), 15, 10, 1L, 17L, true, null, null },
                    { 27L, null, new DateTime(2021, 12, 22, 12, 34, 17, 661, DateTimeKind.Utc).AddTicks(5546), 1000, 0, 2L, 27L, true, null, null },
                    { 16L, null, new DateTime(2021, 12, 22, 12, 34, 17, 661, DateTimeKind.Utc).AddTicks(5534), 25, 10, 1L, 16L, true, null, null },
                    { 12L, null, new DateTime(2021, 12, 22, 12, 34, 17, 661, DateTimeKind.Utc).AddTicks(5530), 50, 10, null, 12L, true, null, null },
                    { 15L, null, new DateTime(2021, 12, 22, 12, 34, 17, 661, DateTimeKind.Utc).AddTicks(5533), 50, 2, 4L, 15L, true, null, null },
                    { 22L, null, new DateTime(2021, 12, 22, 12, 34, 17, 661, DateTimeKind.Utc).AddTicks(5541), 1000, 0, null, 22L, true, null, null },
                    { 23L, null, new DateTime(2021, 12, 22, 12, 34, 17, 661, DateTimeKind.Utc).AddTicks(5542), 1000, 0, null, 23L, true, null, null },
                    { 31L, null, new DateTime(2021, 12, 22, 12, 34, 17, 661, DateTimeKind.Utc).AddTicks(5556), 1000, 0, null, 31L, true, null, null },
                    { 13L, null, new DateTime(2021, 12, 22, 12, 34, 17, 661, DateTimeKind.Utc).AddTicks(5531), 50, 2, null, 13L, true, null, null },
                    { 14L, null, new DateTime(2021, 12, 22, 12, 34, 17, 661, DateTimeKind.Utc).AddTicks(5532), 50, 2, 4L, 14L, true, null, null },
                    { 24L, null, new DateTime(2021, 12, 22, 12, 34, 17, 661, DateTimeKind.Utc).AddTicks(5543), 1000, 0, null, 24L, false, null, null },
                    { 7L, null, new DateTime(2021, 12, 22, 12, 34, 17, 661, DateTimeKind.Utc).AddTicks(5524), 50, 0, 4L, 7L, true, null, null },
                    { 20L, null, new DateTime(2021, 12, 22, 12, 34, 17, 661, DateTimeKind.Utc).AddTicks(5538), 1000, 0, null, 20L, true, null, null },
                    { 21L, null, new DateTime(2021, 12, 22, 12, 34, 17, 661, DateTimeKind.Utc).AddTicks(5539), 1000, 0, null, 21L, true, null, null },
                    { 8L, null, new DateTime(2021, 12, 22, 12, 34, 17, 661, DateTimeKind.Utc).AddTicks(5525), 10, 10, null, 8L, true, null, null },
                    { 18L, null, new DateTime(2021, 12, 22, 12, 34, 17, 661, DateTimeKind.Utc).AddTicks(5536), 15, 10, null, 18L, true, null, null },
                    { 19L, null, new DateTime(2021, 12, 22, 12, 34, 17, 661, DateTimeKind.Utc).AddTicks(5537), 15, 10, null, 19L, true, null, null },
                    { 9L, null, new DateTime(2021, 12, 22, 12, 34, 17, 661, DateTimeKind.Utc).AddTicks(5527), 1000, 0, null, 9L, false, null, null },
                    { 10L, null, new DateTime(2021, 12, 22, 12, 34, 17, 661, DateTimeKind.Utc).AddTicks(5528), 1000, 0, null, 10L, false, null, null },
                    { 26L, null, new DateTime(2021, 12, 22, 12, 34, 17, 661, DateTimeKind.Utc).AddTicks(5545), 1000, 0, null, 26L, true, null, null },
                    { 1L, null, new DateTime(2021, 12, 22, 12, 34, 17, 661, DateTimeKind.Utc).AddTicks(4323), 5000, 2, null, 1L, false, null, null },
                    { 5L, null, new DateTime(2021, 12, 22, 12, 34, 17, 661, DateTimeKind.Utc).AddTicks(5514), 500, 0, null, 5L, false, null, null },
                    { 28L, null, new DateTime(2021, 12, 22, 12, 34, 17, 661, DateTimeKind.Utc).AddTicks(5547), 1000, 0, null, 28L, false, null, null },
                    { 29L, null, new DateTime(2021, 12, 22, 12, 34, 17, 661, DateTimeKind.Utc).AddTicks(5548), 1000, 0, null, 29L, false, null, null },
                    { 30L, null, new DateTime(2021, 12, 22, 12, 34, 17, 661, DateTimeKind.Utc).AddTicks(5555), 1000, 0, null, 30L, false, null, null },
                    { 2L, null, new DateTime(2021, 12, 22, 12, 34, 17, 661, DateTimeKind.Utc).AddTicks(4877), 5, 5, 1L, 2L, true, null, null },
                    { 3L, null, new DateTime(2021, 12, 22, 12, 34, 17, 661, DateTimeKind.Utc).AddTicks(5501), 1000, 0, 4L, 3L, false, null, null },
                    { 4L, null, new DateTime(2021, 12, 22, 12, 34, 17, 661, DateTimeKind.Utc).AddTicks(5513), 1000, 0, 4L, 4L, false, null, null },
                    { 6L, null, new DateTime(2021, 12, 22, 12, 34, 17, 661, DateTimeKind.Utc).AddTicks(5523), 50, 2, 4L, 6L, true, null, null },
                    { 11L, null, new DateTime(2021, 12, 22, 12, 34, 17, 661, DateTimeKind.Utc).AddTicks(5529), 100, 0, 3L, 11L, true, null, null },
                    { 32L, null, new DateTime(2021, 12, 22, 12, 34, 17, 661, DateTimeKind.Utc).AddTicks(5557), 9, 9, null, 32L, true, null, null }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Assessment_AssessmentStatusMasterId",
                table: "Assessment",
                column: "AssessmentStatusMasterId");

            migrationBuilder.CreateIndex(
                name: "IX_AssessmentVerification_AssessmentId",
                table: "AssessmentVerification",
                column: "AssessmentId");

            migrationBuilder.CreateIndex(
                name: "IX_BasicInfo_AssessmentId",
                table: "BasicInfo",
                column: "AssessmentId");

            migrationBuilder.CreateIndex(
                name: "IX_ContactDetails_ContactTypeDetailsId",
                table: "ContactDetails",
                column: "ContactTypeDetailsId");

            migrationBuilder.CreateIndex(
                name: "IX_Document_AssessmentId",
                table: "Document",
                column: "AssessmentId");

            migrationBuilder.CreateIndex(
                name: "IX_Document_DocumentCategoryDocumentTypeMappingId",
                table: "Document",
                column: "DocumentCategoryDocumentTypeMappingId");

            migrationBuilder.CreateIndex(
                name: "IX_DocumentCategoryDocumentTypeMapping_DocumentCategoryMasterId",
                table: "DocumentCategoryDocumentTypeMapping",
                column: "DocumentCategoryMasterId");

            migrationBuilder.CreateIndex(
                name: "IX_DocumentCategoryDocumentTypeMapping_DocumentTypeMasterId",
                table: "DocumentCategoryDocumentTypeMapping",
                column: "DocumentTypeMasterId");

            migrationBuilder.CreateIndex(
                name: "IX_DocumentProgramMapping_DocumentId",
                table: "DocumentProgramMapping",
                column: "DocumentId");

            migrationBuilder.CreateIndex(
                name: "IX_DocumentProgramMapping_ProgramDocumentId",
                table: "DocumentProgramMapping",
                column: "ProgramDocumentId");

            migrationBuilder.CreateIndex(
                name: "IX_Guarantor_AssessmentId",
                table: "Guarantor",
                column: "AssessmentId");

            migrationBuilder.CreateIndex(
                name: "IX_HouseHoldMember_AssessmentId",
                table: "HouseHoldMember",
                column: "AssessmentId");

            migrationBuilder.CreateIndex(
                name: "IX_HouseholdMemberDocument_DocumentId",
                table: "HouseholdMemberDocument",
                column: "DocumentId");

            migrationBuilder.CreateIndex(
                name: "IX_HouseholdMemberDocument_HouseholdMemberId",
                table: "HouseholdMemberDocument",
                column: "HouseholdMemberId");

            migrationBuilder.CreateIndex(
                name: "IX_HouseHoldMemberIncome_ContactDetailsId",
                table: "HouseHoldMemberIncome",
                column: "ContactDetailsId");

            migrationBuilder.CreateIndex(
                name: "IX_HouseHoldMemberIncome_HouseHoldMemberId",
                table: "HouseHoldMemberIncome",
                column: "HouseHoldMemberId");

            migrationBuilder.CreateIndex(
                name: "IX_HouseHoldMemberResource_HouseHoldMemberId",
                table: "HouseHoldMemberResource",
                column: "HouseHoldMemberId");

            migrationBuilder.CreateIndex(
                name: "IX_Options_QuickAssessmentQuestionsId",
                table: "Options",
                column: "QuickAssessmentQuestionsId");

            migrationBuilder.CreateIndex(
                name: "IX_PatientProgramMapping_AssessmentId",
                table: "PatientProgramMapping",
                column: "AssessmentId");

            migrationBuilder.CreateIndex(
                name: "IX_PatientProgramMapping_ProgramId",
                table: "PatientProgramMapping",
                column: "ProgramId");

            migrationBuilder.CreateIndex(
                name: "IX_ProgramDocument_ProgramId",
                table: "ProgramDocument",
                column: "ProgramId");

            migrationBuilder.CreateIndex(
                name: "IX_Question_ControlId",
                table: "Question",
                column: "ControlId");

            migrationBuilder.CreateIndex(
                name: "IX_QuickAssessmentQuestions_DynamicScreensId",
                table: "QuickAssessmentQuestions",
                column: "DynamicScreensId");

            migrationBuilder.CreateIndex(
                name: "IX_QuickAssessmentQuestions_FieldTypeId",
                table: "QuickAssessmentQuestions",
                column: "FieldTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_QuickAssessmentResult_AssessmentId",
                table: "QuickAssessmentResult",
                column: "AssessmentId");

            migrationBuilder.CreateIndex(
                name: "IX_ReviewNotes_AssessmentId",
                table: "ReviewNotes",
                column: "AssessmentId");

            migrationBuilder.CreateIndex(
                name: "IX_RolesPermissions_PermissionId",
                table: "RolesPermissions",
                column: "PermissionId");

            migrationBuilder.CreateIndex(
                name: "IX_RolesPermissions_RoleId",
                table: "RolesPermissions",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_SessionActivity_UserId",
                table: "SessionActivity",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_TabCompletionStatus_AssessmentId",
                table: "TabCompletionStatus",
                column: "AssessmentId");

            migrationBuilder.CreateIndex(
                name: "IX_UserHasRoles_RoleId",
                table: "UserHasRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_UserHasRoles_UserId",
                table: "UserHasRoles",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Validators_PatternId",
                table: "Validators",
                column: "PatternId");

            migrationBuilder.CreateIndex(
                name: "IX_Validators_QuickAssessmentQuestionsId",
                table: "Validators",
                column: "QuickAssessmentQuestionsId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Answer");

            migrationBuilder.DropTable(
                name: "AnswerOption");

            migrationBuilder.DropTable(
                name: "AssessmentInPatientDashboard");

            migrationBuilder.DropTable(
                name: "AssessmentResult");

            migrationBuilder.DropTable(
                name: "AssessmentSummaryResult");

            migrationBuilder.DropTable(
                name: "AssessmentVerification");

            migrationBuilder.DropTable(
                name: "BasicInfo");

            migrationBuilder.DropTable(
                name: "ContactPreference");

            migrationBuilder.DropTable(
                name: "DashboardAssessment");

            migrationBuilder.DropTable(
                name: "DocumentProgramMapping");

            migrationBuilder.DropTable(
                name: "EntityMaster");

            migrationBuilder.DropTable(
                name: "Gender");

            migrationBuilder.DropTable(
                name: "Guarantor");

            migrationBuilder.DropTable(
                name: "HouseholdMemberDocument");

            migrationBuilder.DropTable(
                name: "HouseHoldMemberIncome");

            migrationBuilder.DropTable(
                name: "HouseHoldMemberResource");

            migrationBuilder.DropTable(
                name: "IncomeType");

            migrationBuilder.DropTable(
                name: "IncomeTypeCurrentStatus");

            migrationBuilder.DropTable(
                name: "JournalEntries");

            migrationBuilder.DropTable(
                name: "MaritalStatus");

            migrationBuilder.DropTable(
                name: "Options");

            migrationBuilder.DropTable(
                name: "PatientProgramMapping");

            migrationBuilder.DropTable(
                name: "PayPeriod");

            migrationBuilder.DropTable(
                name: "Question");

            migrationBuilder.DropTable(
                name: "QuickAssessmentResult");

            migrationBuilder.DropTable(
                name: "RelationshipToPatient");

            migrationBuilder.DropTable(
                name: "ResourceType");

            migrationBuilder.DropTable(
                name: "ResourceTypeCurrentStatus");

            migrationBuilder.DropTable(
                name: "ReviewNotes");

            migrationBuilder.DropTable(
                name: "RolesPermissions");

            migrationBuilder.DropTable(
                name: "Screen");

            migrationBuilder.DropTable(
                name: "ScreenQuestionMapping");

            migrationBuilder.DropTable(
                name: "ServiceAuditTrails");

            migrationBuilder.DropTable(
                name: "SessionActivity");

            migrationBuilder.DropTable(
                name: "TabCompletionStatus");

            migrationBuilder.DropTable(
                name: "UserHasRoles");

            migrationBuilder.DropTable(
                name: "Validators");

            migrationBuilder.DropTable(
                name: "Verification");

            migrationBuilder.DropTable(
                name: "ProgramDocument");

            migrationBuilder.DropTable(
                name: "Document");

            migrationBuilder.DropTable(
                name: "ContactDetails");

            migrationBuilder.DropTable(
                name: "HouseHoldMember");

            migrationBuilder.DropTable(
                name: "Control");

            migrationBuilder.DropTable(
                name: "Permission");

            migrationBuilder.DropTable(
                name: "Roles");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "FieldValidatorType");

            migrationBuilder.DropTable(
                name: "QuickAssessmentQuestions");

            migrationBuilder.DropTable(
                name: "Program");

            migrationBuilder.DropTable(
                name: "DocumentCategoryDocumentTypeMapping");

            migrationBuilder.DropTable(
                name: "ContactTypeMaster");

            migrationBuilder.DropTable(
                name: "Assessment");

            migrationBuilder.DropTable(
                name: "DynamicScreens");

            migrationBuilder.DropTable(
                name: "FieldType");

            migrationBuilder.DropTable(
                name: "DocumentCategoryMaster");

            migrationBuilder.DropTable(
                name: "DocumentTypeMaster");

            migrationBuilder.DropTable(
                name: "AssessmentStatusMaster");
        }
    }
}
