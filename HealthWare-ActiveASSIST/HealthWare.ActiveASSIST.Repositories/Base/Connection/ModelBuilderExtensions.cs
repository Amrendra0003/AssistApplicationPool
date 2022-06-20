using HealthWare.ActiveASSIST.Entities;
using HealthWare.ActiveASSIST.Entities.DropDown;
using HealthWare.ActiveASSIST.Entities.Master;
using Microsoft.EntityFrameworkCore;
using IncomeTypeCurrentStatus = HealthWare.ActiveASSIST.Entities.DropDown.IncomeTypeCurrentStatus;
using Option = HealthWare.ActiveASSIST.Entities.Option;
using ResourceTypeCurrentStatus = HealthWare.ActiveASSIST.Entities.DropDown.ResourceTypeCurrentStatus;

namespace HealthWare.ActiveASSIST.Repositories.Base.Connection
{
    public static class ModelBuilderExtensions
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Gender>().HasData(
                new Gender()
                {
                    Id = 1,
                    KeyName = "M",
                    Value = "Male"
                },
                new Gender()
                {
                    Id = 2,
                    KeyName = "F",
                    Value = "Female"
                },
                new Gender()
                {
                    Id = 3,
                    KeyName = "U",
                    Value = "Unreported or Unknown"
                }
            );

            modelBuilder.Entity<Entities.DropDown.IncomeType>().HasData(
                new Entities.DropDown.IncomeType()
                {
                    Id = 1,
                    KeyName = "DK",
                    Value = "Don’t Know"
                },
                new Entities.DropDown.IncomeType()
                {
                    Id = 2,
                    KeyName = "I",
                    Value = "Wages, Salaries, Tips, and Commission Income from Work"
                },
                new Entities.DropDown.IncomeType()
                {
                    Id = 3,
                    KeyName = "SE",
                    Value = "Self-Employment and Business Income"
                },
                new Entities.DropDown.IncomeType()
                {
                    Id = 4,
                    KeyName = "UE",
                    Value = "Unemployment Benefits"
                },
                new Entities.DropDown.IncomeType()
                {
                    Id = 5,
                    KeyName = "IK",
                    Value = "In-Kind Support"
                },
                new Entities.DropDown.IncomeType()
                {
                    Id = 6,
                    KeyName = "PA",
                    Value = "Pensions and Annuitiesnnuities"
                },
                new Entities.DropDown.IncomeType()
                {
                    Id = 7,
                    KeyName = "NG",
                    Value = "National Guard Wages"
                },
                new Entities.DropDown.IncomeType()
                {
                    Id = 8,
                    KeyName = "DIV",
                    Value = "Dividends"
                },
                new Entities.DropDown.IncomeType()
                {
                    Id = 9,
                    KeyName = "B",
                    Value = "Bonuses"
                },
                new Entities.DropDown.IncomeType()
                {
                    Id = 10,
                    KeyName = "INT",
                    Value = "Interest Income"
                },
                new Entities.DropDown.IncomeType()
                {
                    Id = 11,
                    KeyName = "SP",
                    Value = "Severance Pay"
                },
                new Entities.DropDown.IncomeType()
                {
                    Id = 12,
                    KeyName = "ROY",
                    Value = "Royalties"
                },
                new Entities.DropDown.IncomeType()
                {
                    Id = 13,
                    KeyName = "DPP",
                    Value = "Disability Pension Plans"
                },
                new Entities.DropDown.IncomeType()
                {
                    Id = 14,
                    KeyName = "SSDI",
                    Value = "Social Security Disability Income"
                },
                new Entities.DropDown.IncomeType()
                {
                    Id = 15,
                    KeyName = "SSDSI",
                    Value = "Social Security Disability Supplemental Income"
                },
                new Entities.DropDown.IncomeType()
                {
                    Id = 16,
                    KeyName = "RA",
                    Value = "Retirement Account Income"
                },
                new Entities.DropDown.IncomeType()
                {
                    Id = 17,
                    KeyName = "AL",
                    Value = "Alimony"
                },
                new Entities.DropDown.IncomeType()
                {
                    Id = 18,
                    KeyName = "RI",
                    Value = "Net Rental Income"
                },
                new Entities.DropDown.IncomeType()
                {
                    Id = 19,
                    KeyName = "GF",
                    Value = "Net Gaming/Fishing Income"
                },
                new Entities.DropDown.IncomeType()
                {
                    Id = 20,
                    KeyName = "A",
                    Value = "Awards"
                },
                new Entities.DropDown.IncomeType()
                {
                    Id = 21,
                    KeyName = "CA",
                    Value = "Court Awards and Damages"
                },
                new Entities.DropDown.IncomeType()
                {
                    Id = 22,
                    KeyName = "CLG",
                    Value = "Earnings for Clergy"
                },
                new Entities.DropDown.IncomeType()
                {
                    Id = 23,
                    KeyName = "AC",
                    Value = "Americorp"
                },
                new Entities.DropDown.IncomeType()
                {
                    Id = 24,
                    KeyName = "GI",
                    Value = "Gambling Income"
                },
                new Entities.DropDown.IncomeType()
                {
                    Id = 25,
                    KeyName = "COLA",
                    Value = "Government Cost of Living Allowance"
                },
                new Entities.DropDown.IncomeType()
                {
                    Id = 26,
                    KeyName = "RR",
                    Value = "Railroad Retirement Benefits"
                },
                new Entities.DropDown.IncomeType()
                {
                    Id = 27,
                    KeyName = "DNP",
                    Value = "Do Not Want to Provide"
                },
                new Entities.DropDown.IncomeType()
                {
                    Id = 28,
                    KeyName = "OTH",
                    Value = "Other"
                },
                new Entities.DropDown.IncomeType()
                {
                    Id = 29,
                    KeyName = "STP",
                    Value = "Strike Payments"
                },
                new Entities.DropDown.IncomeType()
                {
                    Id = 30,
                    KeyName = "TAX",
                    Value = "Tax Refunds"
                },
                new Entities.DropDown.IncomeType()
                {
                    Id = 31,
                    KeyName = "TEA",
                    Value = "TEA Cash"
                },
                new Entities.DropDown.IncomeType()
                {
                    Id = 32,
                    KeyName = "VA",
                    Value = "VA Benefits"
                },
                new Entities.DropDown.IncomeType()
                {
                    Id = 33,
                    KeyName = "WC",
                    Value = "Workers Comp Benefits"
                },
                new Entities.DropDown.IncomeType()
                {
                    Id = 34,
                    KeyName = "EDU",
                    Value = "Educational Grants"
                },
                new Entities.DropDown.IncomeType()
                {
                    Id = 35,
                    KeyName = "FC",
                    Value = "Foster Care Payments"
                },
                new Entities.DropDown.IncomeType()
                {
                    Id = 36,
                    KeyName = "CSUP",
                    Value = "Child Support"
                }
            );

            modelBuilder.Entity<IncomeTypeCurrentStatus>().HasData(
                new IncomeTypeCurrentStatus()
                {
                    Id = 1,
                    KeyName = "C",
                    Value = "Current"
                },
                new IncomeTypeCurrentStatus()
                {
                    Id = 2,
                    KeyName = "NCM",
                    Value = "Not Current, but in month of patient care"
                },
                new IncomeTypeCurrentStatus()
                {
                    Id = 3,
                    KeyName = "NLT6",
                    Value = "Not Current, but from 6 months or less ago"
                },
                new IncomeTypeCurrentStatus()
                {
                    Id = 4,
                    KeyName = "NGT6",
                    Value = "Not Current, but from 6 or more months ago"
                }
            );

            modelBuilder.Entity<Verification>().HasData(
                new Verification()
                {
                    Id = 1,
                    KeyName = "NV",
                    Value = "Not Yet Verified"
                },
                new Verification()
                {
                    Id = 2,
                    KeyName = "V",
                    Value = "Verified"
                },
                new Verification()
                {
                    Id = 3,
                    KeyName = "UV",
                    Value = "Unable to Verify"
                },
                new Verification()
                {
                    Id = 4,
                    KeyName = "ANV",
                    Value = "Accepted, Not Verified"
                }
            );
            modelBuilder.Entity<MaritalStatus>().HasData(
                new MaritalStatus()
                {
                    Id = 1,
                    KeyName = "A",
                    Value = "Separated"
                },
                new MaritalStatus()
                {
                    Id = 2,
                    KeyName = "D",
                    Value = "Divorced"
                },
                new MaritalStatus()
                {
                    Id = 3,
                    KeyName = "M",
                    Value = "Married"
                },
                new MaritalStatus()
                {
                    Id = 4,
                    KeyName = "P",
                    Value = "Domestic partner"
                },
                new MaritalStatus()
                {
                    Id = 5,
                    KeyName = "S",
                    Value = "Single"
                },
                new MaritalStatus()
                {
                    Id = 6,
                    KeyName = "T",
                    Value = "Unreported"
                },
                new MaritalStatus()
                {
                    Id = 7,
                    KeyName = "U",
                    Value = "Unknown"
                },
                new MaritalStatus()
                {
                    Id = 8,
                    KeyName = "W",
                    Value = "Widowed"
                }
            );

            modelBuilder.Entity<Entities.DropDown.RelationshipToPatient>().HasData(
                new Entities.DropDown.RelationshipToPatient()
                {
                    Id = 1,
                    KeyName = "ASC",
                    Value = "Associate"
                },
                new Entities.DropDown.RelationshipToPatient()
                {
                    Id = 2,
                    KeyName = "BRO",
                    Value = "Brother"
                },
                new Entities.DropDown.RelationshipToPatient()
                {
                    Id = 3,
                    KeyName = "CGV",
                    Value = "Care giver"
                },
                new Entities.DropDown.RelationshipToPatient()
                {
                    Id = 4,
                    KeyName = "CHD",
                    Value = "Child"
                },
                new Entities.DropDown.RelationshipToPatient()
                {
                    Id = 5,
                    KeyName = "DEP",
                    Value = "Handicapped dependent"
                },
                new Entities.DropDown.RelationshipToPatient()
                {
                    Id = 6,
                    KeyName = "DOM",
                    Value = "Life partner"
                },
                new Entities.DropDown.RelationshipToPatient()
                {
                    Id = 7,
                    KeyName = "EMC",
                    Value = "Emergency contact"
                },
                new Entities.DropDown.RelationshipToPatient()
                {
                    Id = 8,
                    KeyName = "EME",
                    Value = "Employee"
                },
                new Entities.DropDown.RelationshipToPatient()
                {
                    Id = 9,
                    KeyName = "EMR",
                    Value = "Employer"
                },
                new Entities.DropDown.RelationshipToPatient()
                {
                    Id = 10,
                    KeyName = "EXF",
                    Value = "Extended family"
                },
                new Entities.DropDown.RelationshipToPatient()
                {
                    Id = 11,
                    KeyName = "FCH",
                    Value = "Foster child"
                },
                new Entities.DropDown.RelationshipToPatient()
                {
                    Id = 12,
                    KeyName = "FND",
                    Value = "Friend"
                },
                new Entities.DropDown.RelationshipToPatient()
                {
                    Id = 13,
                    KeyName = "FTH",
                    Value = "Father"
                },
                new Entities.DropDown.RelationshipToPatient()
                {
                    Id = 14,
                    KeyName = "GCH",
                    Value = "Grandchild"
                },
                new Entities.DropDown.RelationshipToPatient()
                {
                    Id = 15,
                    KeyName = "GRD",
                    Value = "Guardian"
                },
                new Entities.DropDown.RelationshipToPatient()
                {
                    Id = 16,
                    KeyName = "GRP",
                    Value = "Grandparent"
                },
                new Entities.DropDown.RelationshipToPatient()
                {
                    Id = 17,
                    KeyName = "MGR",
                    Value = "Manager"
                },
                new Entities.DropDown.RelationshipToPatient()
                {
                    Id = 18,
                    KeyName = "MTH",
                    Value = "Mother"
                },
                new Entities.DropDown.RelationshipToPatient()
                {
                    Id = 19,
                    KeyName = "NCH",
                    Value = "Natural child"
                },
                new Entities.DropDown.RelationshipToPatient()
                {
                    Id = 20,
                    KeyName = "OAD",
                    Value = "Other adult"
                },
                new Entities.DropDown.RelationshipToPatient()
                {
                    Id = 21,
                    KeyName = "OTH",
                    Value = "Other"
                },
                new Entities.DropDown.RelationshipToPatient()
                {
                    Id = 22,
                    KeyName = "OWN",
                    Value = "Owner"
                },
                new Entities.DropDown.RelationshipToPatient()
                {
                    Id = 23,
                    KeyName = "PAR",
                    Value = "Parent"
                },
                new Entities.DropDown.RelationshipToPatient()
                {
                    Id = 24,
                    KeyName = "SCH",
                    Value = "Stepchild"
                },
                new Entities.DropDown.RelationshipToPatient()
                {
                    Id = 25,
                    KeyName = "SEL",
                    Value = "Self"
                },
                new Entities.DropDown.RelationshipToPatient()
                {
                    Id = 26,
                    KeyName = "SIB",
                    Value = "Sibling"
                },
                new Entities.DropDown.RelationshipToPatient()
                {
                    Id = 27,
                    KeyName = "SIS",
                    Value = "Sister"
                },
                new Entities.DropDown.RelationshipToPatient()
                {
                    Id = 28,
                    KeyName = "SPO",
                    Value = "Spouse"
                },
                new Entities.DropDown.RelationshipToPatient()
                {
                    Id = 29,
                    KeyName = "TRA",
                    Value = "Trainer"
                },
                new Entities.DropDown.RelationshipToPatient()
                {
                    Id = 30,
                    KeyName = "UNK",
                    Value = "Unknown"
                },
                new Entities.DropDown.RelationshipToPatient()
                {
                    Id = 31,
                    KeyName = "WRD",
                    Value = "Ward of court"
                }
            );

            modelBuilder.Entity<Entities.DropDown.ResourceType>().HasData(
                new Entities.DropDown.ResourceType()
                {
                    Id = 1,
                    KeyName = "PCA",
                    Value = "Cash Assets"
                },
                new Entities.DropDown.ResourceType()
                {
                    Id = 2,
                    KeyName = "IRA",
                    Value = "IRA/401K"
                },
                new Entities.DropDown.ResourceType()
                {
                    Id = 3,
                    KeyName = "PV",
                    Value = "Vehicle, Primary"
                },
                new Entities.DropDown.ResourceType()
                {
                    Id = 4,
                    KeyName = "NPV",
                    Value = "Vehicle, Non-Primary"
                },
                new Entities.DropDown.ResourceType()
                {
                    Id = 5,
                    KeyName = "RPH",
                    Value = "Real Property, Home"
                },
                new Entities.DropDown.ResourceType()
                {
                    Id = 6,
                    KeyName = "RPB",
                    Value = "Real Property, Building"
                },
                new Entities.DropDown.ResourceType()
                {
                    Id = 7,
                    KeyName = "RPL",
                    Value = "Real Property, Land"
                },
                new Entities.DropDown.ResourceType()
                {
                    Id = 8,
                    KeyName = "RPLS",
                    Value = "Real Property, Life Estates"
                },
                new Entities.DropDown.ResourceType()
                {
                    Id = 9,
                    KeyName = "PBF",
                    Value = "Burial Funds"
                },
                new Entities.DropDown.ResourceType()
                {
                    Id = 10,
                    KeyName = "PBS",
                    Value = "Burial Spaces"
                },
                new Entities.DropDown.ResourceType()
                {
                    Id = 11,
                    KeyName = "PCF",
                    Value = "Commingled Funds"
                },
                new Entities.DropDown.ResourceType()
                {
                    Id = 12,
                    KeyName = "PCC",
                    Value = "Contracts for Care"
                },
                new Entities.DropDown.ResourceType()
                {
                    Id = 13,
                    KeyName = "PEA",
                    Value = "Escrow Accounts"
                },
                new Entities.DropDown.ResourceType()
                {
                    Id = 14,
                    KeyName = "PFA",
                    Value = "Funeral Agreements"
                },
                new Entities.DropDown.ResourceType()
                {
                    Id = 15,
                    KeyName = "PHS",
                    Value = "Home Sale Proceeds"
                },
                new Entities.DropDown.ResourceType()
                {
                    Id = 16,
                    KeyName = "PIP",
                    Value = "Income Producing Property"
                },
                new Entities.DropDown.ResourceType()
                {
                    Id = 17,
                    KeyName = "PIDA",
                    Value = "Individual Development Accounts"
                },
                new Entities.DropDown.ResourceType()
                {
                    Id = 18,
                    KeyName = "PI",
                    Value = "Life Insurance"
                },
                new Entities.DropDown.ResourceType()
                {
                    Id = 19,
                    KeyName = "PESP",
                    Value = "Educational Saving Plan"
                },
                new Entities.DropDown.ResourceType()
                {
                    Id = 20,
                    KeyName = "PPP",
                    Value = "Pension Plans"
                },
                new Entities.DropDown.ResourceType()
                {
                    Id = 21,
                    KeyName = "DK",
                    Value = "Don’t Know"
                },
                new Entities.DropDown.ResourceType()
                {
                    Id = 22,
                    KeyName = "DNP",
                    Value = "Do Not Want to Provide"
                }
            );

            modelBuilder.Entity<ResourceTypeCurrentStatus>().HasData(
                new ResourceTypeCurrentStatus()
                {
                    Id = 1,
                    KeyName = "CO",
                    Value = "Currently Owned"
                },
                new ResourceTypeCurrentStatus()
                {
                    Id = 2,
                    KeyName = "SLT1",
                    Value = "Sold Less Than 1 Year Ago"
                },
                new ResourceTypeCurrentStatus()
                {
                    Id = 3,
                    KeyName = "SMT1",
                    Value = "Sold More Than 1 Year Ago"
                },
                new ResourceTypeCurrentStatus()
                {
                    Id = 4,
                    KeyName = "TLT1",
                    Value = "Transferred Less Than 5 Years Ago"
                },
                new ResourceTypeCurrentStatus()
                {
                    Id = 5,
                    KeyName = "TMT1",
                    Value = "Transferred More Than 5 Years Ago"
                }
            );

            modelBuilder.Entity<PayPeriod>().HasData(
                new PayPeriod()
                {
                    Id = 1,
                    KeyName = "4.33",
                    Value = "Weekly"
                },
                new PayPeriod()
                {
                    Id = 2,
                    KeyName = "2.17",
                    Value = "Biweekly"
                },
                new PayPeriod()
                {
                    Id = 3,
                    KeyName = "2",
                    Value = "Bimonthly"
                },
                new PayPeriod()
                {
                    Id = 4,
                    KeyName = "1",
                    Value = "Monthly"
                },
                new PayPeriod()
                {
                    Id = 5,
                    KeyName = "0.833",
                    Value = "Yearly"
                }
            );
            modelBuilder.Entity<AssessmentStatusMaster>().HasData(
                new AssessmentStatusMaster()
                {
                    Id = 1,
                    AssessmentStatus = AssessmentStatus.Incomplete
                },
                new AssessmentStatusMaster()
                {
                    Id = 2,
                    AssessmentStatus = AssessmentStatus.DocumentationIncomplete
                },
                new AssessmentStatusMaster()
                {
                    Id = 3,
                    AssessmentStatus = AssessmentStatus.Pending
                },
                new AssessmentStatusMaster()
                {
                    Id = 4,
                    AssessmentStatus = AssessmentStatus.Completed
                }
            );

            modelBuilder.Entity<DocumentCategoryMaster>().HasData(
                new DocumentCategoryMaster()
                {
                    Id = 1,
                    CategoryName = "Identification"
                },
                new DocumentCategoryMaster()
                {
                    Id = 2,
                    CategoryName = "Address"
                },
                new DocumentCategoryMaster()
                {
                    Id = 3,
                    CategoryName = "Income"
                },
                new DocumentCategoryMaster()
                {
                    Id = 4,
                    CategoryName = "Eforms"
                },
                new DocumentCategoryMaster()
                {
                    Id = 5,
                    CategoryName = "Other"
                }
            );

            modelBuilder.Entity<DocumentTypeMaster>().HasData(
                new DocumentTypeMaster()
                {
                    Id = 1,
                    DocumentTypeName = "ValidDriversLicense"
                },
                new DocumentTypeMaster()
                {
                    Id = 2,
                    DocumentTypeName = "BirthCertificate"
                },
                new DocumentTypeMaster()
                {
                    Id = 3,
                    DocumentTypeName = "StateissuedIdentificationCard"
                },
                new DocumentTypeMaster()
                {
                    Id = 4,
                    DocumentTypeName = "StudentIdentificationCard"
                },
                new DocumentTypeMaster()
                {
                    Id = 5,
                    DocumentTypeName = "SocialSecurityCard"
                },
                new DocumentTypeMaster()
                {
                    Id = 6,
                    DocumentTypeName = "MilitaryIdentificationCard"
                },
                new DocumentTypeMaster()
                {
                    Id = 7,
                    DocumentTypeName = "PassportorPassportCard"
                },
                new DocumentTypeMaster()
                {
                    Id = 8,
                    DocumentTypeName = "Pan Card"
                },
                new DocumentTypeMaster()
                {
                    Id = 9,
                    DocumentTypeName = "Bank Statement"
                },
                new DocumentTypeMaster()
                {
                    Id = 10,
                    DocumentTypeName = "Salary Report"
                },
                new DocumentTypeMaster()
                {
                    Id = 11,
                    DocumentTypeName = "Others"
                },
                new DocumentTypeMaster()
                {
                    Id = 12,
                    DocumentTypeName = "Eforms"
                },
                new DocumentTypeMaster()
                {
                    Id = 13,
                    DocumentTypeName = "HIPAAandPrivacyConsent"
                },
                new DocumentTypeMaster()
                {
                    Id = 14,
                    DocumentTypeName = "ConsenttoTreat"
                }
            );

            modelBuilder.Entity<PasswordPolicy>().HasData(
                new PasswordPolicy()
                {
                    Id = (long)1,
                    AttemptLimits = 4,
                    ExpireTime = "24",
                    Pattern = "^(?=.*[A-Za-z])(?=.*\\d)(?=.*[@$!%*#?&])[A-Za-z\\d@$!%*#?&]{8,}$",
                    TenantId = "1",
                    MaximumLength = 15,
                    MinimumLength = 8
                },
                new PasswordPolicy()
                {
                    Id = (long)2,
                    AttemptLimits = 4,
                    ExpireTime = "24",
                    Pattern = "^(?=.*[A-Za-z])(?=.*\\d)(?=.*[@$!%*#?&])[A-Za-z\\d@$!%*#?&]{8,}$",
                    TenantId = "2",
                    MaximumLength = 15,
                    MinimumLength = 8
                }
            );
            modelBuilder.Entity<Control>().HasData(
                new Control()
                {
                    Id = 1,
                    ControlType = "numerictextbox",
                },
                new Control()
                {
                    Id = 2,
                    ControlType = "dropdown",
                },
                new Control()
                {
                    Id = 3,
                    ControlType = "radio",
                },
                new Control()
                {
                    Id = 4,
                    ControlType = "label",
                },
                new Control()
                {
                    Id = 5,
                    ControlType = "textbox",
                },
                new Control()
                {
                    Id = 6,
                    ControlType = "date",
                },
                new Control()
                {
                    Id = 7,
                    ControlType = "cell",
                },
                new Control()
                {
                    Id = 8,
                    ControlType = "toggle",
                },
                new Control()
                {
                    Id = 9,
                    ControlType = "button",
                },
                new Control()
                {
                    Id = 10,
                    ControlType = "checkbox",
                },
                new Control()
                {
                    Id = 11,
                    ControlType = "countButton",
                }
            );
            modelBuilder.Entity<DocumentCategoryDocumentTypeMapping>().HasData(
                new
                {
                    Id = (long)1,
                    DocumentCategoryMasterId = (long)1,
                    DocumentTypeMasterId = (long)1
                },
                new
                {
                    Id = (long)2,
                    DocumentCategoryMasterId = (long)1,
                    DocumentTypeMasterId = (long)2
                },
                new
                {
                    Id = (long)3,
                    DocumentCategoryMasterId = (long)1,
                    DocumentTypeMasterId = (long)3
                },
                new
                {
                    Id = (long)4,
                    DocumentCategoryMasterId = (long)1,
                    DocumentTypeMasterId = (long)4
                },
                new
                {
                    Id = (long)5,
                    DocumentCategoryMasterId = (long)1,
                    DocumentTypeMasterId = (long)5
                },
                new
                {
                    Id = (long)6,
                    DocumentCategoryMasterId = (long)1,
                    DocumentTypeMasterId = (long)6
                },
                new
                {
                    Id = (long)7,
                    DocumentCategoryMasterId = (long)1,
                    DocumentTypeMasterId = (long)7
                },
                new
                {
                    Id = (long)8,
                    DocumentCategoryMasterId = (long)2,
                    DocumentTypeMasterId = (long)1
                },
                new
                {
                    Id = (long)9,
                    DocumentCategoryMasterId = (long)2,
                    DocumentTypeMasterId = (long)5
                },
                new
                {
                    Id = (long)10,
                    DocumentCategoryMasterId = (long)2,
                    DocumentTypeMasterId = (long)7
                },
                new
                {
                    Id = (long)11,
                    DocumentCategoryMasterId = (long)3,
                    DocumentTypeMasterId = (long)8
                },
                new
                {
                    Id = (long)12,
                    DocumentCategoryMasterId = (long)3,
                    DocumentTypeMasterId = (long)9
                },
                new
                {
                    Id = (long)13,
                    DocumentCategoryMasterId = (long)3,
                    DocumentTypeMasterId = (long)10
                },
                new
                {
                    Id = (long)14,
                    DocumentCategoryMasterId = (long)3,
                    DocumentTypeMasterId = (long)11
                },
                new
                {
                    Id = (long)15,
                    DocumentCategoryMasterId = (long)4,
                    DocumentTypeMasterId = (long)12
                },
                new
                {
                    Id = (long)16,
                    DocumentCategoryMasterId = (long)5,
                    DocumentTypeMasterId = (long)13
                },
                new
                {
                    Id = (long)17,
                    DocumentCategoryMasterId = (long)5,
                    DocumentTypeMasterId = (long)14
                }
            );

            modelBuilder.Entity<DynamicScreens>().HasData(
                new DynamicScreens()
                {
                    Id = 1,
                    LeftHeader = "Lets get you started",
                    LeftContent = "Please tell us who received services for this financial assisstance application.",
                    CreatedBy = (long)-1,
                    CreatedDate = Constants.CreatedDateTime,
                },
                new DynamicScreens()
                {
                    Id = 2,
                    LeftHeader = "Residential Zip Code",
                    LeftContent = "Please enter your 5 digit zip code.",
                    CreatedBy = (long)-1,
                    CreatedDate = Constants.CreatedDateTime,
                },
                new DynamicScreens()
                {
                    Id = 3,
                    LeftHeader = "Citizenship Status",
                    LeftContent = "Please tell us about your citizenship status. This will assist in determining potential programs that may be eligible for.",
                    CreatedBy = (long)-1,
                    CreatedDate = Constants.CreatedDateTime,
                },
                new DynamicScreens()
                {
                    Id = 4,
                    LeftHeader = "Patient Demographics",
                    LeftContent = "Please tell us more about the patient. Verify that the information displayed is correct and make any necessary corrections.",
                    CreatedBy = (long)-1,
                    CreatedDate = Constants.CreatedDateTime,
                },
                new DynamicScreens()
                {
                    Id = 5,
                    LeftHeader = "Insurance Coverage",
                    LeftContent = "Please tell us if you are currently covered by health insurance or if you were covered in the last 60 days, either as a subscriber or as a dependent. If Yes, please provide information from your insurance card.",
                    CreatedBy = (long)-1,
                    CreatedDate = Constants.CreatedDateTime,
                },
                new DynamicScreens()
                {
                    Id = 6,
                    LeftHeader = "Household Members",
                    LeftContent = "Please tell us about your household. Enter the total number of members that reside in your household.Please include the number of children under the age of 18 that are under your custody. Please indicate if you or anyone in your household is currently employed. Please check any of the listed benefits that you are currently receiving.If none apply, simply click NEXT to move to the next question",
                    CreatedBy = (long)-1,
                    CreatedDate = Constants.CreatedDateTime,
                },
                new DynamicScreens()
                {
                    Id = 7,
                    LeftHeader = "Household Income & Resources",
                    LeftContent = "Let us know the total income & resources of your household.  Please include all sources of income and the frequency that you receive the income.",
                    CreatedBy = (long)-1,
                    CreatedDate = Constants.CreatedDateTime,
                },
                new DynamicScreens()
                {
                    Id = 8,
                    LeftHeader = "General Information",
                    LeftContent = "Please let us know if any of the following apply to you  This includes health conditions and circumstances related to your illness / injury.",
                    CreatedBy = (long)-1,
                    CreatedDate = Constants.CreatedDateTime,
                },
                new DynamicScreens()
                {
                    Id = 9,
                    LeftHeader = "General Information",
                    LeftContent = "Please let us know if any of the following apply to you  This includes health conditions and circumstances related to your illness / injury.",
                    CreatedBy = (long)-1,
                    CreatedDate = Constants.CreatedDateTime,
                },
                new DynamicScreens()
                {
                    Id = 10,
                    LeftHeader = "General Information",
                    LeftContent = "Please let us know if any of the following apply to you  This includes health conditions and circumstances related to your illness / injury.",
                    CreatedBy = (long)-1,
                    CreatedDate = Constants.CreatedDateTime,
                },
                new DynamicScreens()
                {
                    Id = 11,
                    LeftHeader = "Social Security Number",
                    LeftContent = "Please provide the Social Security Number of the person applying for assistance. If the person applying does not have a Social Security Number, enter reason for no SSN.",
                    CreatedBy = (long)-1,
                    CreatedDate = Constants.CreatedDateTime,
                }
            );

            modelBuilder.Entity<QuickAssessmentQuestions>().HasData(
                new
                {
                    Id = (long)1,
                    UniqueKey = "patient",
                    Class = "col-12",
                    ScreenId = "1",
                    OrderId = "2",
                    Placeholder = "Select Patient Type",
                    Required = false,
                    IsInlineLabel = false,
                    DynamicScreensId = (long)1,
                    CreatedDate = Constants.CreatedDateTime,
                    ParentQuestionId = (long?)null,
                    ScreenHeaderPatientLabel = "Let us know who the patient is.",
                    FieldName = "Patient",
                    FieldTypeId = (long)5
                },
                new
                {
                    Id = (long)2,
                    UniqueKey = "zipCode",
                    Class = "col-12",
                    ScreenId = "2",
                    OrderId = "2",
                    Placeholder = "Zip Code",
                    Required = false,
                    CustomValidation = "Zipcode",
                    IsInlineLabel = false,
                    DynamicScreensId = (long)2,
                    CreatedDate = Constants.CreatedDateTime,
                    ParentQuestionId = (long?)null,
                    ScreenHeaderOthersLabel = "Please enter patient's Zip code.",
                    ScreenHeaderPatientLabel = "Please enter your Zip code.",
                    FieldName = "Zip Code",
                    FieldTypeId = (long)6
                },
                new
                {
                    Id = (long)3,
                    UniqueKey = "city",
                    Class = "col-12",
                    ScreenId = "2",
                    OrderId = "3",
                    Placeholder = "City",
                    Required = false,
                    IsInlineLabel = false,
                    DynamicScreensId = (long)2,
                    CreatedDate = Constants.CreatedDateTime,
                    ParentQuestionId = (long?)null,
                    FieldName = "City",
                    FieldTypeId = (long)6
                },
                new
                {
                    Id = (long)4,
                    UniqueKey = "state",
                    Class = "col-12",
                    ScreenId = "2",
                    OrderId = "3",
                    Placeholder = "State",
                    Required = false,
                    IsInlineLabel = false,
                    DynamicScreensId = (long)2,
                    CreatedDate = Constants.CreatedDateTime,
                    ParentQuestionId = (long?)null,
                    FieldName = "State",
                    FieldTypeId = (long)6
                },
                new
                {
                    Id = (long)5,
                    UniqueKey = "citizenship",
                    Class = "col-12",
                    ScreenId = "3",
                    OrderId = "2",
                    Placeholder = "Select Citizenship",
                    Required = false,
                    AlertInfo = "Your state does not provide financial assistance to patients with unknown citizenship status.",
                    IsInlineLabel = false,
                    DynamicScreensId = (long)3,
                    CreatedDate = Constants.CreatedDateTime,
                    ParentQuestionId = (long?)null,
                    ScreenHeaderOthersLabel = "Confirm patient's citizenship status",
                    ScreenHeaderPatientLabel = "Confirm your citizenship status.",
                    FieldName = "Citizenship",
                    FieldTypeId = (long)5,
                    ErrorMessageInfo = "There may be other programs that you potentially qualify for. Please continue with the screening."
                },
                new
                {
                    Id = (long)6,
                    TextBoxSubLabel = "Please enter the legal name.",
                    UniqueKey = "firstName",
                    Class = "col-12",
                    ScreenId = "4",
                    OrderId = "1",
                    Placeholder = "First Name",
                    Required = true,
                    IsInlineLabel = false,
                    DynamicScreensId = (long)4,
                    CreatedDate = Constants.CreatedDateTime,
                    ParentQuestionId = (long?)null,
                    ScreenHeaderOthersLabel = "Tell us more about the patient.",
                    ScreenHeaderPatientLabel = "Tell us about yourself",
                    FieldName = "First Name",
                    FieldTypeId = (long)6
                },
                new
                {
                    Id = (long)7,
                    UniqueKey = "middleName",
                    Class = "col-12",
                    ScreenId = "4",
                    OrderId = "2",
                    Placeholder = "Middle Name",
                    Required = false,
                    IsInlineLabel = false,
                    DynamicScreensId = (long)4,
                    CreatedDate = Constants.CreatedDateTime,
                    ParentQuestionId = (long?)null,
                    FieldName = "Middle Name",
                    FieldTypeId = (long)6
                },
                new
                {
                    Id = (long)8,
                    UniqueKey = "lastName",
                    Class = "col-12",
                    ScreenId = "4",
                    OrderId = "3",
                    Placeholder = "Last Name",
                    Required = true,
                    IsInlineLabel = false,
                    DynamicScreensId = (long)4,
                    CreatedDate = Constants.CreatedDateTime,
                    ParentQuestionId = (long?)null,
                    FieldName = "Last Name",
                    FieldTypeId = (long)6
                },
                new
                {
                    Id = (long)9,
                    UniqueKey = "dateOfBirth",
                    Class = "col-12",
                    ScreenId = "4",
                    OrderId = "5",
                    Placeholder = "mm/dd/yyyy",
                    Required = true,
                    MaximumDate = "today",
                    IsInlineLabel = false,
                    DynamicScreensId = (long)4,
                    CreatedDate = Constants.CreatedDateTime,
                    ParentQuestionId = (long?)null,
                    FieldName = "Date of Birth",
                    FieldTypeId = (long)3
                },
                new
                {
                    Id = (long)10,
                    UniqueKey = "gender",
                    Class = "col-12",
                    ScreenId = "4",
                    OrderId = "6",
                    Placeholder = "Gender",
                    Required = true,
                    IsInlineLabel = false,
                    DynamicScreensId = (long)4,
                    CreatedDate = Constants.CreatedDateTime,
                    ParentQuestionId = (long?)null,
                    FieldName = "Gender",
                    FieldTypeId = (long)4
                },
                new
                {
                    Id = (long)11,
                    UniqueKey = "maritalStatus",
                    Class = "col-12",
                    ScreenId = "4",
                    OrderId = "7",
                    Placeholder = "Marital Status",
                    Required = false,
                    IsInlineLabel = false,
                    DynamicScreensId = (long)4,
                    CreatedDate = Constants.CreatedDateTime,
                    ParentQuestionId = (long?)null,
                    FieldName = "Marital Status",
                    FieldTypeId = (long)4
                },
                new
                {
                    Id = (long)12,
                    UniqueKey = "email",
                    Class = "col-12",
                    ScreenId = "4",
                    OrderId = "8",
                    Placeholder = "Email",
                    Required = true,
                    IsInlineLabel = true,
                    InlineLabel = "Email",
                    DynamicScreensId = (long)4,
                    CreatedDate = Constants.CreatedDateTime,
                    ParentQuestionId = (long?)null,
                    FieldName = "Email",
                    FieldTypeId = (long)6
                },
                new
                {
                    Id = (long)13,
                    UniqueKey = "cellNumber",
                    Class = "col-12",
                    ScreenId = "4",
                    OrderId = "9",
                    Placeholder = "Cell Number",
                    Required = true,
                    IsInlineLabel = true,
                    InlineLabel = "Cell",
                    DynamicScreensId = (long)4,
                    CreatedDate = Constants.CreatedDateTime,
                    ParentQuestionId = (long?)null,
                    FieldName = "Cell Number",
                    FieldTypeId = (long)1
                },
                new
                {
                    Id = (long)14,
                    UniqueKey = "insurance",
                    Class = "col-12",
                    ScreenId = "5",
                    OrderId = "2",
                    Required = true,
                    CustomValidation = "Yes",
                    AlertInfo = "Invalid policy Number",
                    IsInlineLabel = false,
                    DynamicScreensId = (long)5,
                    CreatedDate = Constants.CreatedDateTime,
                    ParentQuestionId = (long?)null,
                    ScreenHeaderOthersLabel = "Does the patient currently or in the last 60 days have/had health insurance?",
                    ScreenHeaderPatientLabel = "Do you currently or in the last 60 days have/had health insurance?",
                    FieldName = "Insurance",
                    FieldTypeId = (long)7,
                    ErrorMessageInfo = "Your visit can be covered under your insurance. Please get in touch with your insurance provider for more information."
                },
                new
                {
                    Id = (long)15,
                    UniqueKey = "payerName",
                    Class = "col-12",
                    ScreenId = "5",
                    OrderId = "4",
                    Placeholder = "Payer name",
                    Required = true,
                    IsInlineLabel = false,
                    DynamicScreensId = (long)5,
                    CreatedDate = Constants.CreatedDateTime,
                    ParentQuestionId = (long)14,
                    ScreenHeaderOthersLabel = "Enter the following details",
                    ScreenHeaderPatientLabel = "Enter the following details",
                    FieldName = "Payer Name",
                    FieldTypeId = (long)6,
                },
                new
                {
                    Id = (long)16,
                    UniqueKey = "groupname",
                    Class = "col-12",
                    ScreenId = "5",
                    OrderId = "5",
                    Placeholder = "Group Name",
                    Required = true,
                    IsInlineLabel = false,
                    DynamicScreensId = (long)5,
                    CreatedDate = Constants.CreatedDateTime,
                    ParentQuestionId = (long)14,
                    FieldName = "Group Name",
                    FieldTypeId = (long)6,
                },
                new
                {
                    Id = (long)17,
                    UniqueKey = "groupNo",
                    Class = "col-12",
                    ScreenId = "5",
                    OrderId = "5",
                    Placeholder = "Group Number",
                    Required = true,
                    IsInlineLabel = true,
                    InlineLabel = "Group No.",
                    DynamicScreensId = (long)5,
                    CreatedDate = Constants.CreatedDateTime,
                    ParentQuestionId = (long)14,
                    FieldName = "Group Number",
                    FieldTypeId = (long)6,
                },
                new
                {
                    Id = (long)18,
                    UniqueKey = "policyNo",
                    Class = "col-12",
                    ScreenId = "5",
                    OrderId = "6",
                    Placeholder = "Policy Number",
                    Required = true,
                    CustomValidation = "PolicyNumber",
                    AlertInfo = "Invalid policy Number",
                    MessageInfo = "Your visit can be covered under your insurance. Please get in touch with your insurance provider for more information.",
                    IsInlineLabel = true,
                    InlineLabel = "Policy No.",
                    DynamicScreensId = (long)5,
                    CreatedDate = Constants.CreatedDateTime,
                    ParentQuestionId = (long)14,
                    FieldName = "Policy Number",
                    FieldTypeId = (long)6,
                    ErrorMessageInfo = "Your visit can be covered under your insurance. Please get in touch with your insurance provider for more information."
                },
                new
                {
                    Id = (long)19,
                    UniqueKey = "effectiveFrom",
                    Class = "col-12",
                    ScreenId = "5",
                    OrderId = "7",
                    Placeholder = "Effective From",
                    Required = true,
                    IsInlineLabel = true,
                    InlineLabel = "Effective From",
                    DynamicScreensId = (long)5,
                    CreatedDate = Constants.CreatedDateTime,
                    ParentQuestionId = (long)14,
                    FieldName = "Effective From",
                    FieldTypeId = (long)3,
                },
                new
                {
                    Id = (long)20,
                    UniqueKey = "termination",
                    Class = "col-12",
                    ScreenId = "5",
                    OrderId = "8",
                    Placeholder = "Termination",
                    Required = true,
                    IsInlineLabel = true,
                    InlineLabel = "Termination",
                    DynamicScreensId = (long)5,
                    CreatedDate = Constants.CreatedDateTime,
                    ParentQuestionId = (long)14,
                    FieldName = "Termination Date",
                    FieldTypeId = (long)3,
                },
                new
                {
                    Id = (long)21,
                    PatientLabel = "Total Number of members living in your household",
                    OthersLabel = "Total Number of members living in patient's household",
                    UniqueKey = "totalHouseholdMembers",
                    Value = "1",
                    Class = "col-5",
                    ScreenId = "6",
                    OrderId = "2",
                    Required = true,
                    IsInlineLabel = false,
                    DynamicScreensId = (long)6,
                    CreatedDate = Constants.CreatedDateTime,
                    ParentQuestionId = (long?)null,
                    ScreenHeaderOthersLabel = "Tell us more about patient's household",
                    ScreenHeaderPatientLabel = "Tell us about your household",
                    FieldName = "Household Members",
                    FieldTypeId = (long)2,
                },
                new
                {
                    Id = (long)22,
                    PatientLabel = "Minor children for whom you have full custody?",
                    OthersLabel = "Minor children for whom the patient has full custody?",
                    UniqueKey = "totalMinors",
                    Value = "0",
                    Class = "col-5",
                    ScreenId = "6",
                    OrderId = "3",
                    Required = true,
                    IsInlineLabel = false,
                    DynamicScreensId = (long)6,
                    CreatedDate = Constants.CreatedDateTime,
                    ParentQuestionId = (long?)null,
                    FieldName = "Total Minors",
                    FieldTypeId = (long)2,
                },
                new
                {
                    Id = (long)23,
                    PatientLabel = "Are you employed?",
                    OthersLabel = "Is the patient employed?",
                    UniqueKey = "isEmployed",
                    Class = "col-5",
                    ScreenId = "6",
                    OrderId = "4",
                    Required = true,
                    CustomValidation = (string)null,
                    IsInlineLabel = false,
                    DynamicScreensId = (long)6,
                    CreatedDate = Constants.CreatedDateTime,
                    ParentQuestionId = (long?)null,
                    FieldName = "Is Employed",
                    FieldTypeId = (long)7,
                },
                new
                {
                    Id = (long)24,
                    PatientLabel = "Is anyone else in your household employed?",
                    OthersLabel = "Is anyone else in patient's household employed?",
                    UniqueKey = "isHouseholdEmployed",
                    Class = "col-5",
                    ScreenId = "6",
                    OrderId = "1",
                    Required = true,
                    CustomValidation = (string)null,
                    IsInlineLabel = false,
                    DynamicScreensId = (long)6,
                    CreatedDate = Constants.CreatedDateTime,
                    ParentQuestionId = (long?)null,
                    FieldName = "Is Household Employed",
                    FieldTypeId = (long)7,
                },
                new
                {
                    Id = (long)25,
                    UniqueKey = "programServices",
                    Class = "col-12",
                    ScreenId = "6",
                    OrderId = "1",
                    Required = false,
                    MessageInfo = "If none of them apply, you can directly move to the next question.",
                    IsInlineLabel = false,
                    DynamicScreensId = (long)6,
                    CreatedDate = Constants.CreatedDateTime,
                    ParentQuestionId = (long?)null,
                    ScreenHeaderOthersLabel = "Does the patient currently receive any of the following?",
                    ScreenHeaderPatientLabel = "Do you currently receive any of the following?",
                    FieldName = "Program Services",
                    FieldTypeId = (long)8,
                    ErrorMessageInfo = "If none of them apply, you can directly move to the next question."
                },
                new
                {
                    Id = (long)26,
                    PatientLabel = "Estimated  Household Income",
                    OthersLabel = "Estimated Household Income",
                    UniqueKey = "householdIncome",
                    Class = "col-3",
                    ScreenId = "7",
                    OrderId = "2",
                    Placeholder = "Income",
                    CustomValidation = "Income",
                    Required = true,
                    IsInlineLabel = true,
                    InlineLabel = "$",
                    DynamicScreensId = (long)7,
                    CreatedDate = Constants.CreatedDateTime,
                    ParentQuestionId = (long?)null,
                    ScreenHeaderOthersLabel = "Enter patient's household income and resources",
                    ScreenHeaderPatientLabel = "Enter your household income and resources",
                    FieldName = "Household Income",
                    Value = "0",
                    FieldTypeId = (long)6,
                },
                new
                {
                    Id = (long)27,
                    PatientLabel = "Select Grosspay",
                    OthersLabel = "Select Grosspay",
                    UniqueKey = "incomePayPeriod",
                    Class = "col-3",
                    ScreenId = "7",
                    OrderId = "3",
                    Placeholder = "Gross Pay",
                    Required = true,
                    MessageInfo = "Include income earned by all the members of the household.",
                    IsInlineLabel = false,
                    DynamicScreensId = (long)7,
                    CreatedDate = Constants.CreatedDateTime,
                    ParentQuestionId = (long?)null,
                    FieldName = "Income Pay Period",
                    FieldTypeId = (long)4,
                    Value = "Yearly",
                    ErrorMessageInfo = "Include income earned by all the members of the household."
                },
                new
                {
                    Id = (long)28,
                    PatientLabel = "Estimated Household Resources",
                    OthersLabel = "Estimated Household Resources",
                    UniqueKey = "householdResources",
                    Class = "col-3",
                    ScreenId = "7",
                    OrderId = "4",
                    Placeholder = "Resources",
                    Required = true,
                    MessageInfo = "Please estimate the total resource value held by all the members of the household in the form of checking & savings, retirement accounts, property (home, vehicle, etc) and any others assets.",
                    IsInlineLabel = true,
                    InlineLabel = "$",
                    DynamicScreensId = (long)7,
                    CreatedDate = Constants.CreatedDateTime,
                    ParentQuestionId = (long?)null,
                    FieldName = "Household Resources",
                    FieldTypeId = (long)6,
                    Value = "0",
                    ErrorMessageInfo = "Please estimate the total resource value held by all the members of the household in the form of checking & savings, retirement accounts, property (home, vehicle, etc) and any others assets."
                },
                new
                {
                    Id = (long)29,
                    UniqueKey = "serviceProgram",
                    Class = "col-12",
                    ScreenId = "8",
                    OrderId = "1",
                    Required = false,
                    CustomValidation = "Any",
                    MessageInfo = "If none of them apply, you can directly move to the next question.",
                    IsInlineLabel = false,
                    DynamicScreensId = (long)8,
                    CreatedDate = Constants.CreatedDateTime,
                    ParentQuestionId = (long?)null,
                    ScreenHeaderOthersLabel = "Please select the options that apply to patient and click on next.",
                    ScreenHeaderPatientLabel = "Please select the options that apply to you and click on next.",
                    FieldName = "Service Program",
                    FieldTypeId = (long)8,
                    ErrorMessageInfo = "If none of them apply, you can directly move to the next question."
                },
                new
                {
                    Id = (long)30,
                    UniqueKey = "healthConditiion",
                    Class = "col-12",
                    ScreenId = "9",
                    OrderId = "1",
                    Required = false,
                    CustomValidation = "Any",
                    IsInlineLabel = false,
                    DynamicScreensId = (long)9,
                    CreatedDate = Constants.CreatedDateTime,
                    ParentQuestionId = (long?)null,
                    ScreenHeaderOthersLabel = "Do any of the following health conditions apply to patient?",
                    ScreenHeaderPatientLabel = "Do any of the following health conditions apply to you?",
                    FieldName = "Health Condition",
                    FieldTypeId = (long)8,
                },
                new
                {
                    Id = (long)31,
                    UniqueKey = "beenInjured",
                    Class = "col-12",
                    ScreenId = "10",
                    OrderId = "1",
                    Required = false,
                    CustomValidation = "Any",
                    IsInlineLabel = false,
                    DynamicScreensId = (long)10,
                    CreatedDate = Constants.CreatedDateTime,
                    ParentQuestionId = (long?)null,
                    ScreenHeaderOthersLabel = "Select if patient have been injured",
                    ScreenHeaderPatientLabel = "Select if you have been injured",
                    FieldName = "Been Injured",
                    FieldTypeId = (long)8,
                },
                new
                {
                    Id = (long)32,
                    UniqueKey = "crimeReportFiled",
                    PatientLabel = "Was a Report Filed?",
                    OthersLabel = "Was a Report Filed?",
                    Class = "col-5",
                    ScreenId = "10",
                    OrderId = "1",
                    Required = false,
                    IsInlineLabel = false,
                    DynamicScreensId = (long)10,
                    CreatedDate = Constants.CreatedDateTime,
                    ParentQuestionId = (long)31,
                    FieldName = "Is Report Filed",
                    FieldTypeId = (long)7,
                },
                new
                {
                    Id = (long)33,
                    UniqueKey = "ssnNumber",
                    Class = "col-5",
                    ScreenId = "11",
                    OrderId = "1",
                    Placeholder = "000-00-0000",
                    Required = true,
                    IsInlineLabel = false,
                    DynamicScreensId = (long)11,
                    CreatedDate = Constants.CreatedDateTime,
                    ScreenHeaderPatientLabel = "Last Step. Please provide your SSN",
                    ScreenHeaderOthersLabel = "Last Step.Please provide patient's SSN",
                    FieldName = "SSN",
                    FieldTypeId = (long)9,
                },
                new
                {
                    Id = (long)34,
                    FieldTypeId = (long)4,
                    UniqueKey = "reasonNoSSN",
                    FieldName = "Reason no SSN",
                    Class = "col-5",
                    ScreenId = "11",
                    OrderId = "2",
                    Placeholder = "Reason No SSN",
                    Required = false,
                    IsInlineLabel = false,
                    MessageInfo = "Your SSN is secure with us. We ask for this information as most government agencies require this number when submitting an application for benefits.",
                    DynamicScreensId = (long)11,
                    CreatedDate = Constants.CreatedDateTime,
                },
                new
                {
                    Id = (long)35,
                    UniqueKey = "agreementCheckBox",
                    Class = "col-12",
                    ScreenId = "11",
                    OrderId = "3",
                    Required = true,
                    IsInlineLabel = false,
                    DynamicScreensId = (long)11,
                    CreatedDate = Constants.CreatedDateTime,
                    TermAndConditionsMessageLabel = "Terms And Conditions",
                    TermAndConditionPopupMessage = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat.Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat.Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat.Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat.Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat.Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat.",
                    FieldTypeId = (long)8,
                },
                 new
                 {
                     Id = (long)36,
                     UniqueKey = "motorReportFiled",
                     PatientLabel = "Was a Report Filed?",
                     OthersLabel = "Was a Report Filed?",
                     Class = "col-5",
                     ScreenId = "10",
                     OrderId = "1",
                     Required = false,
                     IsInlineLabel = false,
                     DynamicScreensId = (long)10,
                     CreatedDate = Constants.CreatedDateTime,
                     ParentQuestionId = (long)31,
                     FieldName = "Is Report Filed",
                     FieldTypeId = (long)7,
                 },
                  new
                  {
                      Id = (long)37,
                      UniqueKey = "jobReportFiled",
                      PatientLabel = "Was a Report Filed?",
                      OthersLabel = "Was a Report Filed?",
                      Class = "col-5",
                      ScreenId = "10",
                      OrderId = "1",
                      Required = false,
                      IsInlineLabel = false,
                      DynamicScreensId = (long)10,
                      CreatedDate = Constants.CreatedDateTime,
                      ParentQuestionId = (long)31,
                      FieldName = "Is Report Filed",
                      FieldTypeId = (long)7,
                  }
            );

            modelBuilder.Entity<Option>().HasData(
                new
                {
                    Id = (long)1,
                    Name = "myself",
                    Order = 1,
                    Value = "Myself",
                    QuickAssessmentQuestionsId = (long)1,
                    CreatedDate = Constants.CreatedDateTime
                },
                new
                {
                    Id = (long)2,
                    Name = "other",
                    Order = 2,
                    Value = "Relative/Friend/Other",
                    QuickAssessmentQuestionsId = (long)1,
                    CreatedDate = Constants.CreatedDateTime
                },
                new
                {
                    Id = (long)3,
                    Name = "usCitizen",
                    Order = 1,
                    Value = "U.S. Citizen",
                    QuickAssessmentQuestionsId = (long)5,
                    CreatedDate = Constants.CreatedDateTime
                },
                new
                {
                    Id = (long)4,
                    Name = "legalResident",
                    Order = 2,
                    Value = "Legal Resident",
                    QuickAssessmentQuestionsId = (long)5,
                    CreatedDate = Constants.CreatedDateTime
                },
                new
                {
                    Id = (long)5,
                    Name = "undocumented",
                    Order = 3,
                    Value = "Undocumented",
                    QuickAssessmentQuestionsId = (long)5,
                    CreatedDate = Constants.CreatedDateTime
                },
                new
                {
                    Id = (long)6,
                    Name = "unknown",
                    Order = 4,
                    Value = "Unknown",
                    QuickAssessmentQuestionsId = (long)5,
                    CreatedDate = Constants.CreatedDateTime
                },
                new
                {
                    Id = (long)7,
                    Name = "M",
                    Order = 1,
                    Value = "Male",
                    QuickAssessmentQuestionsId = (long)10,
                    CreatedDate = Constants.CreatedDateTime
                },
                new
                {
                    Id = (long)8,
                    Name = "F",
                    Order = 2,
                    Value = "Female",
                    QuickAssessmentQuestionsId = (long)10,
                    CreatedDate = Constants.CreatedDateTime
                },
                new
                {
                    Id = (long)9,
                    Name = "U",
                    Order = 3,
                    Value = "Unreported or Unknown",
                    QuickAssessmentQuestionsId = (long)10,
                    CreatedDate = Constants.CreatedDateTime
                },
                new
                {
                    Id = (long)10,
                    Name = "A",
                    Order = 1,
                    Value = "Separated",
                    QuickAssessmentQuestionsId = (long)11,
                    CreatedDate = Constants.CreatedDateTime
                },
                new
                {
                    Id = (long)11,
                    Name = "D",
                    Order = 2,
                    Value = "Divorced",
                    QuickAssessmentQuestionsId = (long)11,
                    CreatedDate = Constants.CreatedDateTime
                },
                new
                {
                    Id = (long)12,
                    Name = "M",
                    Order = 3,
                    Value = "Married",
                    QuickAssessmentQuestionsId = (long)11,
                    CreatedDate = Constants.CreatedDateTime
                },
                new
                {
                    Id = (long)13,
                    Name = "P",
                    Order = 4,
                    Value = "Domestic partner",
                    QuickAssessmentQuestionsId = (long)11,
                    CreatedDate = Constants.CreatedDateTime
                },
                new
                {
                    Id = (long)14,
                    Name = "S",
                    Order = 5,
                    Value = "Single",
                    QuickAssessmentQuestionsId = (long)11,
                    CreatedDate = Constants.CreatedDateTime
                },
                new
                {
                    Id = (long)15,
                    Name = "T",
                    Order = 6,
                    Value = "Unreported",
                    QuickAssessmentQuestionsId = (long)11,
                    CreatedDate = Constants.CreatedDateTime
                },
                new
                {
                    Id = (long)16,
                    Name = "U",
                    Order = 7,
                    Value = "Unknown",
                    QuickAssessmentQuestionsId = (long)11,
                    CreatedDate = Constants.CreatedDateTime
                },
                new
                {
                    Id = (long)17,
                    Name = "W",
                    Order = 8,
                    Value = "Widowed",
                    QuickAssessmentQuestionsId = (long)11,
                    CreatedDate = Constants.CreatedDateTime
                },
                new
                {
                    Id = (long)18,
                    Name = "calFresh",
                    Order = 1,
                    Value = "CalFresh (Food Stamps)",
                    QuickAssessmentQuestionsId = (long)25,
                    CreatedDate = Constants.CreatedDateTime
                },
                new
                {
                    Id = (long)19,
                    Name = "ssi",
                    Order = 2,
                    Value = "SSI / SSP",
                    QuickAssessmentQuestionsId = (long)25,
                    CreatedDate = Constants.CreatedDateTime
                },
                new
                {
                    Id = (long)20,
                    Name = "calWorks",
                    Order = 3,
                    Value = "CalWorks",
                    QuickAssessmentQuestionsId = (long)25,
                    CreatedDate = Constants.CreatedDateTime
                },
                new
                {
                    Id = (long)21,
                    Name = "refugeeAssisstance",
                    Order = 4,
                    Value = "Refugee Assistance",
                    QuickAssessmentQuestionsId = (long)25,
                    CreatedDate = Constants.CreatedDateTime
                },
                new
                {
                    Id = (long)22,
                    Name = "allOfTheAbove",
                    Order = 5,
                    Value = "All of the above",
                    QuickAssessmentQuestionsId = (long)25,
                    CreatedDate = Constants.CreatedDateTime
                },
                new
                {
                    Id = (long)23,
                    Name = "yearly",
                    Order = 1,
                    Value = "Yearly",
                    QuickAssessmentQuestionsId = (long)27,
                    CreatedDate = Constants.CreatedDateTime
                },
                new
                {
                    Id = (long)24,
                    Name = "monthly",
                    Order = 2,
                    Value = "Monthly",
                    QuickAssessmentQuestionsId = (long)27,
                    CreatedDate = Constants.CreatedDateTime
                },
                new
                {
                    Id = (long)25,
                    Name = "bimonthly",
                    Order = 3,
                    Value = "Bimonthly",
                    QuickAssessmentQuestionsId = (long)27,
                    CreatedDate = Constants.CreatedDateTime
                },
                new
                {
                    Id = (long)26,
                    Name = "biweekly",
                    Order = 4,
                    Value = "Biweekly",
                    QuickAssessmentQuestionsId = (long)27,
                    CreatedDate = Constants.CreatedDateTime
                },
                new
                {
                    Id = (long)27,
                    Name = "weekly",
                    Order = 5,
                    Value = "Weekly",
                    QuickAssessmentQuestionsId = (long)27,
                    CreatedDate = Constants.CreatedDateTime
                },
                new
                {
                    Id = (long)28,
                    Name = "pregnantNow",
                    Order = 1,
                    Value = "Pregnant now / in past 6 months",
                    QuickAssessmentQuestionsId = (long)29,
                    CreatedDate = Constants.CreatedDateTime
                },
                new
                {
                    Id = (long)29,
                    Name = "veteran",
                    Order = 2,
                    Value = "Veteran",
                    QuickAssessmentQuestionsId = (long)29,
                    CreatedDate = Constants.CreatedDateTime
                },
                new
                {
                    Id = (long)30,
                    Name = "memberOfIndianTribe",
                    Order = 3,
                    Value = "Member of Indian tribe",
                    QuickAssessmentQuestionsId = (long)29,
                    CreatedDate = Constants.CreatedDateTime
                },
                new
                {
                    Id = (long)31,
                    Name = "formerFosterYouth",
                    Order = 4,
                    Value = "Former Foster Youth",
                    QuickAssessmentQuestionsId = (long)29,
                    CreatedDate = Constants.CreatedDateTime
                },
                new
                {
                    Id = (long)32,
                    Name = "deemed",
                    Order = 1,
                    Value = "Deemed as disabled for 12 months or longer",
                    QuickAssessmentQuestionsId = (long)30,
                    CreatedDate = Constants.CreatedDateTime
                },
                new
                {
                    Id = (long)33,
                    Name = "you/member",
                    Order = 2,
                    Value = "You/member of your family been declared legally blind",
                    QuickAssessmentQuestionsId = (long)30,
                    CreatedDate = Constants.CreatedDateTime
                },
                new
                {
                    Id = (long)34,
                    Name = "inCrime",
                    Order = 1,
                    Value = "In crime related violence (as a victim)",
                    QuickAssessmentQuestionsId = (long)31,
                    CreatedDate = Constants.CreatedDateTime
                },
                new
                {
                    Id = (long)35,
                    Name = "inMotorVehicle",
                    Order = 2,
                    Value = "In motor vehicle accident",
                    QuickAssessmentQuestionsId = (long)31,
                    CreatedDate = Constants.CreatedDateTime
                },
                new
                {
                    Id = (long)36,
                    Name = "onTheJob",
                    Order = 2,
                    Value = "On the job",
                    QuickAssessmentQuestionsId = (long)31,
                    CreatedDate = Constants.CreatedDateTime
                },
                new
                {
                    Id = (long)37,
                    Name = "no",
                    Order = 1,
                    Value = "No",
                    QuickAssessmentQuestionsId = (long)14,
                    CreatedDate = Constants.CreatedDateTime
                },
                new
                {
                    Id = (long)38,
                    Name = "yes",
                    Order = 2,
                    Value = "Yes",
                    QuickAssessmentQuestionsId = (long)14,
                    CreatedDate = Constants.CreatedDateTime
                },
                new
                {
                    Id = (long)39,
                    Name = "No",
                    Order = 1,
                    Value = "No",
                    QuickAssessmentQuestionsId = (long)23,
                    CreatedDate = Constants.CreatedDateTime
                },
                new
                {
                    Id = (long)40,
                    Name = "Yes",
                    Order = 2,
                    Value = "Yes",
                    QuickAssessmentQuestionsId = (long)23,
                    CreatedDate = Constants.CreatedDateTime
                },
                new
                {
                    Id = (long)41,
                    Name = "No",
                    Order = 1,
                    Value = "No",
                    QuickAssessmentQuestionsId = (long)24,
                    CreatedDate = Constants.CreatedDateTime
                },
                new
                {
                    Id = (long)42,
                    Name = "Yes",
                    Order = 2,
                    Value = "Yes",
                    QuickAssessmentQuestionsId = (long)24,
                    CreatedDate = Constants.CreatedDateTime
                },
                new
                {
                    Id = (long)43,
                    Order = 1,
                    Value = "No",
                    QuickAssessmentQuestionsId = (long)32,
                    CreatedDate = Constants.CreatedDateTime
                },
                new
                {
                    Id = (long)44,
                    Order = 1,
                    Value = "Yes",
                    QuickAssessmentQuestionsId = (long)32,
                    CreatedDate = Constants.CreatedDateTime
                },
                new
                {
                    Id = (long)45,
                    Order = 1,
                    Value = "By clicking this box you acknowledge that you have received, reviewed and agree to the terms of use, privacy statement, e-signature disclosure and consent.",
                    QuickAssessmentQuestionsId = (long)35,
                    CreatedDate = Constants.CreatedDateTime
                },
                 new
                 {
                     Id = (long)47,
                     Order = 1,
                     Value = "No",
                     QuickAssessmentQuestionsId = (long)36,
                     CreatedDate = Constants.CreatedDateTime
                 },
                 new
                 {
                     Id = (long)48,
                     Order = 1,
                     Value = "Yes",
                     QuickAssessmentQuestionsId = (long)36,
                     CreatedDate = Constants.CreatedDateTime
                 },
                 new
                 {
                     Id = (long)49,
                     Order = 1,
                     Value = "No",
                     QuickAssessmentQuestionsId = (long)37,
                     CreatedDate = Constants.CreatedDateTime
                 },
                 new
                 {
                     Id = (long)50,
                     Order = 1,
                     Value = "Yes",
                     QuickAssessmentQuestionsId = (long)37,
                     CreatedDate = Constants.CreatedDateTime
                 },
                new
                {
                    Id = (long)51,
                    Name = "doesNotHaveOne",
                    Order = 1,
                    Value = "Does Not Have One",
                    QuickAssessmentQuestionsId = (long)34,
                    CreatedDate = Constants.CreatedDateTime
                },
                new
                {
                    Id = (long)52,
                    Name = "unconcious-CouldNotProvide",
                    Order = 2,
                    Value = "Unconcious - Could Not Provide",
                    QuickAssessmentQuestionsId = (long)34,
                    CreatedDate = Constants.CreatedDateTime
                },
                new
                {
                    Id = (long)53,
                    Name = "other",
                    Order = 3,
                    Value = "Other",
                    QuickAssessmentQuestionsId = (long)34,
                    CreatedDate = Constants.CreatedDateTime
                }
            );

            modelBuilder.Entity<Validators>().HasData(
                new
                {
                    Id = (long)1,
                    Required = true,
                    MinLength = 2,
                    MaxLength = 5000,
                    CreatedDate = Constants.CreatedDateTime,
                    QuickAssessmentQuestionsId = (long)1
                },
                new
                {
                    Id = (long)2,
                    Required = true,
                    MinLength = 5,
                    MaxLength = 5,
                    CreatedDate = Constants.CreatedDateTime,
                    QuickAssessmentQuestionsId = (long)2,
                    PatternId = (long)1
                },
                new
                {
                    Id = (long)3,
                    Required = false,
                    MinLength = 0,
                    MaxLength = 1000,
                    CreatedDate = Constants.CreatedDateTime,
                    QuickAssessmentQuestionsId = (long)3,
                    PatternId = (long)4
                },
                new
                {
                    Id = (long)4,
                    Required = false,
                    MinLength = 0,
                    MaxLength = 1000,
                    CreatedDate = Constants.CreatedDateTime,
                    QuickAssessmentQuestionsId = (long)4,
                    PatternId = (long)4
                },
                new
                {
                    Id = (long)5,
                    Required = true,
                    MinLength = 0,
                    MaxLength = 500,
                    CreatedDate = Constants.CreatedDateTime,
                    QuickAssessmentQuestionsId = (long)5
                },
                new
                {
                    Id = (long)6,
                    Required = true,
                    MinLength = 2,
                    MaxLength = 50,
                    CreatedDate = Constants.CreatedDateTime,
                    QuickAssessmentQuestionsId = (long)6,
                    PatternId = (long)4
                },
                new
                {
                    Id = (long)7,
                    Required = true,
                    MinLength = 0,
                    MaxLength = 50,
                    CreatedDate = Constants.CreatedDateTime,
                    QuickAssessmentQuestionsId = (long)8,
                    PatternId = (long)4
                },
                new
                {
                    Id = (long)8,
                    Required = true,
                    MinLength = 10,
                    MaxLength = 10,
                    CreatedDate = Constants.CreatedDateTime,
                    QuickAssessmentQuestionsId = (long)9
                },
                new
                {
                    Id = (long)9,
                    Required = true,
                    MinLength = 0,
                    MaxLength = 1000,
                    CreatedDate = Constants.CreatedDateTime,
                    QuickAssessmentQuestionsId = (long)10
                },
                new
                {
                    Id = (long)10,
                    Required = true,
                    MinLength = 0,
                    MaxLength = 1000,
                    CreatedDate = Constants.CreatedDateTime,
                    QuickAssessmentQuestionsId = (long)11
                },
                new
                {
                    Id = (long)11,
                    Required = true,
                    MinLength = 0,
                    MaxLength = 100,
                    CreatedDate = Constants.CreatedDateTime,
                    QuickAssessmentQuestionsId = (long)12,
                    PatternId = (long)3
                },
                new
                {
                    Id = (long)12,
                    Required = true,
                    MinLength = 10,
                    MaxLength = 50,
                    CreatedDate = Constants.CreatedDateTime,
                    QuickAssessmentQuestionsId = (long)13
                },
                new
                {
                    Id = (long)13,
                    Required = true,
                    MinLength = 2,
                    MaxLength = 50,
                    CreatedDate = Constants.CreatedDateTime,
                    QuickAssessmentQuestionsId = (long)14
                },
                new
                {
                    Id = (long)14,
                    Required = true,
                    MinLength = 2,
                    MaxLength = 50,
                    CreatedDate = Constants.CreatedDateTime,
                    QuickAssessmentQuestionsId = (long)15,
                    PatternId = (long)4
                },
                new
                {
                    Id = (long)15,
                    Required = true,
                    MinLength = 2,
                    MaxLength = 50,
                    CreatedDate = Constants.CreatedDateTime,
                    QuickAssessmentQuestionsId = (long)16,
                    PatternId = (long)4
                },
                new
                {
                    Id = (long)16,
                    Required = true,
                    MinLength = 10,
                    MaxLength = 25,
                    CreatedDate = Constants.CreatedDateTime,
                    QuickAssessmentQuestionsId = (long)17,
                    PatternId = (long)5
                },
                new
                {
                    Id = (long)17,
                    Required = true,
                    MinLength = 10,
                    MaxLength = 15,
                    CreatedDate = Constants.CreatedDateTime,
                    QuickAssessmentQuestionsId = (long)18,
                    PatternId = (long)5
                },
                new
                {
                    Id = (long)18,
                    Required = true,
                    MinLength = 10,
                    MaxLength = 10,
                    CreatedDate = Constants.CreatedDateTime,
                    QuickAssessmentQuestionsId = (long)19,
                    PatternId = (long)10
                },
                new
                {
                    Id = (long)19,
                    Required = false,
                    MinLength = 10,
                    MaxLength = 10,
                    CreatedDate = Constants.CreatedDateTime,
                    QuickAssessmentQuestionsId = (long)20,
                    PatternId = (long)10
                },
                new
                {
                    Id = (long)20,
                    Required = true,
                    MinLength = 0,
                    MaxLength = 1000,
                    CreatedDate = Constants.CreatedDateTime,
                    QuickAssessmentQuestionsId = (long)21
                },
                new
                {
                    Id = (long)21,
                    Required = true,
                    MinLength = 0,
                    MaxLength = 1000,
                    CreatedDate = Constants.CreatedDateTime,
                    QuickAssessmentQuestionsId = (long)22
                },
                new
                {
                    Id = (long)22,
                    Required = true,
                    MinLength = 0,
                    MaxLength = 1000,
                    CreatedDate = Constants.CreatedDateTime,
                    QuickAssessmentQuestionsId = (long)23
                },
                new
                {
                    Id = (long)23,
                    Required = true,
                    MinLength = 0,
                    MaxLength = 1000,
                    CreatedDate = Constants.CreatedDateTime,
                    QuickAssessmentQuestionsId = (long)24
                },
                new
                {
                    Id = (long)24,
                    Required = false,
                    MinLength = 0,
                    MaxLength = 1000,
                    CreatedDate = Constants.CreatedDateTime,
                    QuickAssessmentQuestionsId = (long)25
                },
                new
                {
                    Id = (long)25,
                    Required = true,
                    MinLength = 0,
                    MaxLength = 1000,
                    CreatedDate = Constants.CreatedDateTime,
                    QuickAssessmentQuestionsId = (long)26,
                    PatternId = (long)2,
                    Max = 50000
                },
                new
                {
                    Id = (long)26,
                    Required = true,
                    MinLength = 0,
                    MaxLength = 1000,
                    CreatedDate = Constants.CreatedDateTime,
                    QuickAssessmentQuestionsId = (long)27
                },
                new
                {
                    Id = (long)27,
                    Required = true,
                    MinLength = 0,
                    MaxLength = 1000,
                    CreatedDate = Constants.CreatedDateTime,
                    QuickAssessmentQuestionsId = (long)28,
                    PatternId = (long)2,
                    Max = 50000
                },
                new
                {
                    Id = (long)28,
                    Required = false,
                    MinLength = 0,
                    MaxLength = 1000,
                    CreatedDate = Constants.CreatedDateTime,
                    QuickAssessmentQuestionsId = (long)29
                },
                new
                {
                    Id = (long)29,
                    Required = false,
                    MinLength = 0,
                    MaxLength = 1000,
                    CreatedDate = Constants.CreatedDateTime,
                    QuickAssessmentQuestionsId = (long)30
                },
                new
                {
                    Id = (long)30,
                    Required = false,
                    MinLength = 0,
                    MaxLength = 1000,
                    CreatedDate = Constants.CreatedDateTime,
                    QuickAssessmentQuestionsId = (long)31
                },
                new
                {
                    Id = (long)31,
                    Required = false,
                    MinLength = 0,
                    MaxLength = 1000,
                    CreatedDate = Constants.CreatedDateTime,
                    QuickAssessmentQuestionsId = (long)32
                },
                new
                {
                    Id = (long)32,
                    Required = false,
                    MinLength = 9,
                    MaxLength = 9,
                    CreatedDate = Constants.CreatedDateTime,
                    QuickAssessmentQuestionsId = (long)33
                },
                new
                {
                    Id = (long)33,
                    Required = false,
                    MinLength = 0,
                    MaxLength = 1000,
                    CreatedDate = Constants.CreatedDateTime,
                    QuickAssessmentQuestionsId = (long)35
                },
                new
                {
                    Id = (long)34,
                    Required = false,
                    MinLength = 0,
                    MaxLength = 1000,
                    CreatedDate = Constants.CreatedDateTime,
                    QuickAssessmentQuestionsId = (long)36
                },
                new
                {
                    Id = (long)35,
                    Required = false,
                    MinLength = 0,
                    MaxLength = 1000,
                    CreatedDate = Constants.CreatedDateTime,
                    QuickAssessmentQuestionsId = (long)37
                },
                 new
                 {
                     Id = (long)36,
                     Required = false,
                     MinLength = 0,
                     MaxLength = 50,
                     CreatedDate = Constants.CreatedDateTime,
                     QuickAssessmentQuestionsId = (long)7,
                     PatternId = (long)4
                 },
                new
                {
                    Id = (long)37,
                    Required = false,
                    MinLength = 0,
                    MaxLength = 1000,
                    QuickAssessmentQuestionsId = (long)34,
                    CreatedDate = Constants.CreatedDateTime,
                }

            );

            modelBuilder.Entity<FieldType>().HasData(
                new FieldType()
                {
                    Id = 1,
                    Type = "cell"
                },
                new FieldType()
                {
                    Id = 2,
                    Type = "countButton"
                },
                new FieldType()
                {
                    Id = 3,
                    Type = "date"
                },
                new FieldType()
                {
                    Id = 4,
                    Type = "dropdown"
                },
                new FieldType()
                {
                    Id = 5,
                    Type = "radio"
                },
                new FieldType()
                {
                    Id = 6,
                    Type = "textfield"
                },
                new FieldType()
                {
                    Id = 7,
                    Type = "toggle"
                },
                new FieldType()
                {
                    Id = 8,
                    Type = "checkbox"
                },
                new FieldType()
                {
                    Id = 9,
                    Type = "ssn"
                }
            );

            modelBuilder.Entity<FieldValidatorType>().HasData(
                new FieldValidatorType()
                {
                    Id = 1,
                    Type = "^[0-9]*$",
                    Name = "Numeric"
                },
                new FieldValidatorType()
                {
                    Id = 2,
                    Type = "^[0-9]+([,.][0-9]+)?$",
                    Name = "Decimal"
                },
                new FieldValidatorType()
                {
                    Id = 3,
                    Type = "^[a-z0-9._%+-]+@[a-z0-9.-]+\\.com$",
                    Name = "Email"
                },
                new FieldValidatorType()
                {
                    Id = 4,
                    Type = "^[a-zA-Z ]*$",
                    Name = "Alphabets"
                },
                new FieldValidatorType()
                {
                    Id = 5,
                    Type = "^[a-zA-Z0-9]+$",
                    Name = "Alphanumeric"
                },
                new FieldValidatorType()
                {
                    Id = 10,
                    Type = @"^(0?[1-9]|1[0-2])\/(0?[1-9]|1\d|2\d|3[01])\/(19|20)\d{2}$",
                    Name = "Date"
                }
            );

            modelBuilder.Entity<Screen>().HasData(
                new Screen()
                {
                    Id = 1,
                    Name = "Start screen",
                    Description = "Select the patient type to proceed quick assessment.",
                    Order = (long)0,
                    Content = "Let's get you started",
                    IsRequired = false,
                    IsActive = false
                },
                new Screen()
                {
                    Id = 2,
                    Name = "Zip code screen",
                    Description = "Enter the Zip code to let us know your location to help you.",
                    Order = (long)0,
                    Content = "Residential Zip Code",
                    IsRequired = false,
                    IsActive = false
                },
                new Screen()
                {
                    Id = 3,
                    Name = "Citizenship screen",
                    Description = "Let us know your citizenship",
                    Order = (long)0,
                    Content = "Citizenship Status",
                    IsRequired = false,
                    IsActive = false
                },
                new Screen()
                {
                    Id = 4,
                    Name = "Patient Demographics screen",
                    Description = "Kindly fill your legal name and other demographic details.",
                    Order = (long)0,
                    Content = "Patient Demographics",
                    IsRequired = false,
                    IsActive = false
                },
                new Screen()
                {
                    Id = 5,
                    Name = "Insurance screen",
                    Description = "Do you have/had any health insurance? If yes, let us know your insurance details.",
                    Order = (long)0,
                    Content = "Insurance Coverage",
                    IsRequired = false,
                    IsActive = false
                },
                new Screen()
                {
                    Id = 6,
                    Name = "Household Members screen",
                    Description = "Let us know the total number of members in your household.",
                    Order = (long)0,
                    Content = "Household Members",
                    IsRequired = false,
                    IsActive = false
                },
                new Screen()
                {
                    Id = 7,
                    Name = "Household Income & Resource screen",
                    Description = "Let us know the total income & resources of your household. It includes the income & resources of your & your household members also.",
                    Order = (long)0,
                    Content = "Household Income & Resources",
                    IsRequired = false,
                    IsActive = false
                },
                new Screen()
                {
                    Id = 8,
                    Name = "General Information screen",
                    Description = "Kindly answer few questions to help you better. The questions includes on your health conditions.",
                    Order = (long)0,
                    Content = "General Information",
                    IsRequired = false,
                    IsActive = false
                }
            );

            modelBuilder.Entity<Question>().HasData(
                 new
                 {
                     Id = (long)1,
                     QuestionName = "Let us know who the patient is.",
                     ControlId = (long)3,
                     ParentId = (long?)null,
                     DisplayFormat = "header",
                     CssStyle = "rbn_style1",
                     IsRequired = true,
                     RoleName = (long?)null
                 },
                new
                {
                    Id = (long)2,
                    QuestionName = "Please enter your Zip code",
                    ControlId = (long)1,
                    ParentId = (long?)null,
                    DisplayFormat = "header",
                    CssStyle = "txt_zip_style1",
                    IsRequired = true,
                    RoleName = (long?)null
                },
                new
                {
                    Id = (long)3,
                    QuestionName = "City",
                    ControlId = (long)5,
                    ParentId = (long?)null,
                    Description = "Please enter your city",
                    DisplayFormat = "inline",
                    CssStyle = "txt_style1",
                    IsRequired = true,
                    RoleName = (long?)null
                },
                new
                {
                    Id = (long)4,
                    QuestionName = "State",
                    ControlId = (long)5,
                    ParentId = (long?)null,
                    DisplayFormat = "inline",
                    CssStyle = "txt_style1",
                    IsRequired = true,
                    RoleName = (long?)null
                },
                new
                {
                    Id = (long)5,
                    QuestionName = "Confirm your citizenship status",
                    ControlId = (long)3,
                    ParentId = (long?)null,
                    DisplayFormat = "header",
                    CssStyle = "rbn_style1",
                    IsRequired = true,
                    RoleName = (long?)null
                },
                new
                {
                    Id = (long)6,
                    QuestionName = "Tell us about yourself",
                    ControlId = (long)4,
                    ParentId = (long?)null,
                    DisplayFormat = "header",
                    CssStyle = "label",
                    IsRequired = false,
                    RoleName = (long?)null
                },
                new
                {
                    Id = (long)7,
                    QuestionName = "First Name",
                    ControlId = (long)5,
                    ParentId = (long?)null,
                    DisplayFormat = "inline",
                    CssStyle = "txt_style1",
                    IsRequired = true,
                    RoleName = (long?)null
                },
                new
                {
                    Id = (long)8,
                    QuestionName = "Last Name",
                    ControlId = (long)5,
                    ParentId = (long?)null,
                    DisplayFormat = "inline",
                    CssStyle = "txt_style1",
                    IsRequired = true,
                    RoleName = (long?)null
                },
                new
                {
                    Id = (long)9,
                    QuestionName = "date of birth",
                    ControlId = (long)6,
                    ParentId = (long?)null,
                    DisplayFormat = "inline",
                    CssStyle = "dt_birth",
                    IsRequired = false,
                    RoleName = (long?)null
                },
                new
                {
                    Id = (long)10,
                    QuestionName = "Gender",
                    ControlId = (long)2,
                    ParentId = (long?)null,
                    DisplayFormat = "inline",
                    CssStyle = "dd_gender_class",
                    IsRequired = true,
                    RoleName = (long?)null
                },
                new
                {
                    Id = (long)11,
                    QuestionName = "Marital Status",
                    ControlId = (long)2,
                    ParentId = (long?)null,
                    DisplayFormat = "inline",
                    CssStyle = "dd_marital_class",
                    IsRequired = true,
                    RoleName = (long?)null
                },
                new
                {
                    Id = (long)12,
                    QuestionName = "Email",
                    ControlId = (long)5,
                    ParentId = (long?)null,
                    DisplayFormat = "partition",
                    CssStyle = "txt_style2",
                    IsRequired = true,
                    RoleName = (long?)null
                },
                new
                {
                    Id = (long)13,
                    QuestionName = "Cell number",
                    ControlId = (long)7,
                    ParentId = (long?)null,
                    DisplayFormat = "inline",
                    CssStyle = "txt_style3",
                    IsRequired = true,
                    RoleName = (long?)null
                },
                new
                {
                    Id = (long)14,
                    QuestionName = "Do you currently or in the last 60 days have/had health insurance?",
                    ControlId = (long)8,
                    ParentId = (long?)null,
                    DisplayFormat = "header",
                    CssStyle = "tgl_style",
                    IsRequired = true,
                    RoleName = (long?)null
                },
                new
                {
                    Id = (long)15,
                    QuestionName = "Enter the following details",
                    ControlId = (long)4,
                    ParentId = (long)14,
                    DisplayFormat = "header",
                    CssStyle = "label",
                    IsRequired = false,
                    RoleName = (long?)null
                },
                new
                {
                    Id = (long)16,
                    QuestionName = "Payer Name",
                    ControlId = (long)5,
                    //Change THIS, do external cast on every parentId value
                    ParentId = (long)14,
                    DisplayFormat = "inline",
                    CssStyle = "txt_style1",
                    IsRequired = false,
                    RoleName = (long?)null
                },
                new
                {
                    Id = (long)17,
                    QuestionName = "Group Name",
                    ControlId = (long)5,
                    ParentId = (long)14,
                    DisplayFormat = "inline",
                    CssStyle = "txt_style1",
                    IsRequired = true,
                    RoleName = (long?)null
                },
                new
                {
                    Id = (long)18,
                    QuestionName = "Group Number",
                    ControlId = (long)1,
                    ParentId = (long)14,
                    DisplayFormat = "inline",
                    CssStyle = "txt_style1",
                    IsRequired = true,
                    RoleName = (long?)null
                },
                new
                {
                    Id = (long)19,
                    QuestionName = "Policy Number",
                    ControlId = (long)1,
                    ParentId = (long)14,
                    DisplayFormat = "inline",
                    CssStyle = "txt_style1",
                    IsRequired = true,
                    RoleName = (long?)null
                },
                new
                {
                    Id = (long)20,
                    QuestionName = "Effective From",
                    ControlId = (long)6,
                    ParentId = (long)14,
                    DisplayFormat = "inline",
                    CssStyle = "dt_birth",
                    IsRequired = true,
                    RoleName = (long?)null
                },
                new
                {
                    Id = (long)21,
                    QuestionName = "Termination",
                    ControlId = (long)6,
                    ParentId = (long)14,
                    DisplayFormat = "inline",
                    CssStyle = "dt_birth",
                    IsRequired = true,
                    RoleName = (long?)null
                },
                new
                {
                    Id = (long)22,
                    QuestionName = "Tell us about your household",
                    ControlId = (long)4,
                    ParentId = (long?)null,
                    DisplayFormat = "header",
                    CssStyle = "label",
                    IsRequired = false,
                    RoleName = (long?)null
                },
                new
                {
                    Id = (long)23,
                    QuestionName = "Total Number of members living in your household",
                    ControlId = (long)11,
                    ParentId = (long?)null,
                    DisplayFormat = "header",
                    CssStyle = "numeric_counter_style",
                    IsRequired = true,
                    RoleName = (long?)null
                },
                new
                {
                    Id = (long)24,
                    QuestionName = "Minor children for whom you have full custody?",
                    ControlId = (long)11,
                    ParentId = (long?)null,
                    DisplayFormat = "header",
                    CssStyle = "numeric_counter_style",
                    IsRequired = true,
                    RoleName = (long?)null
                },
                new
                {
                    Id = (long)25,
                    QuestionName = "Are you employed?",
                    ControlId = (long)8,
                    ParentId = (long?)null,
                    DisplayFormat = "header",
                    CssStyle = "tgl_style",
                    IsRequired = true,
                    RoleName = (long?)null
                },
                new
                {
                    Id = (long)26,
                    QuestionName = "Is anyone in your household employed?",
                    ControlId = (long)8,
                    ParentId = (long)25,
                    DisplayFormat = "header",
                    CssStyle = "tgl_style",
                    IsRequired = true,
                    RoleName = (long?)null
                },
                new
                {
                    Id = (long)27,
                    QuestionName = "Do you currently receive any of the following?",
                    ControlId = (long)3,
                    Description = "If none of them apply, you can directly move to the next question.",
                    ParentId = (long)26,
                    DisplayFormat = "header",
                    CssStyle = "rbn_style1",
                    IsRequired = true,
                    RoleName = (long?)null
                },
                new
                {
                    Id = (long)28,
                    QuestionName = "Enter household income and resources",
                    ControlId = (long)4,
                    ParentId = (long?)null,
                    DisplayFormat = "header",
                    CssStyle = "label",
                    IsRequired = false,
                    RoleName = (long?)null
                },
                new
                {
                    Id = (long)29,
                    QuestionName = "Estimated Household Income",
                    ControlId = (long)5,
                    ParentId = (long?)null,
                    DisplayFormat = "header",
                    CssStyle = "txt_style1",
                    IsRequired = true,
                    RoleName = (long?)null
                },
                new
                {
                    Id = (long)30,
                    QuestionName = "Income pay period",
                    ControlId = (long)2,
                    ParentId = (long?)null,
                    DisplayFormat = "inline",
                    CssStyle = "dd_income_class",
                    IsRequired = true,
                    RoleName = (long?)null
                },
                new
                {
                    Id = (long)31,
                    QuestionName = "Estimated Household Resources",
                    ControlId = (long)5,
                    ParentId = (long?)null,
                    Description = "Please estimate the total resource value held by all the members of the household in the form  of checking & savings, retirement accounts, property (home, vehicle, etc) and any others assets.",
                    DisplayFormat = "header",
                    CssStyle = "txt_style1",
                    IsRequired = true,
                    RoleName = (long?)null
                },
                new
                {
                    Id = (long)32,
                    QuestionName = "Please select the options that apply to you and click on next.",
                    ControlId = (long)10,
                    ParentId = (long?)null,
                    Description = "If none of them apply, you can directly move to the next question.",
                    DisplayFormat = "header",
                    CssStyle = "rbn_style1",
                    IsRequired = false,
                    RoleName = "Patient"
                },
                new
                {
                    Id = (long)33,
                    QuestionName = "Do any of the following health conditions apply to you?",
                    ControlId = (long)10,
                    ParentId = (long?)null,
                    DisplayFormat = "header",
                    CssStyle = "rbn_style1",
                    IsRequired = true,
                    RoleName = "Patient"
                },
                new
                {
                    Id = (long)34,
                    QuestionName = "Select if you have been injured",
                    ControlId = (long)10,
                    ParentId = (long?)null,
                    DisplayFormat = "header",
                    CssStyle = "rbn_style1",
                    IsRequired = true,
                    RoleName = "Patient"
                },
                new
                {
                    Id = (long)35,
                    QuestionName = "Was a report filed?",
                    ControlId = (long)8,
                    ParentId = (long)34,
                    DisplayFormat = "header",
                    CssStyle = "tgl_style",
                    IsRequired = true,
                    RoleName = "Patient"
                },
                new
                {
                    Id = (long)36,
                    QuestionName = "Was a report filed?",
                    ControlId = (long)8,
                    ParentId = (long)34,
                    DisplayFormat = "header",
                    CssStyle = "tgl_style",
                    IsRequired = true,
                    RoleName = "Patient"
                },
                new
                {
                    Id = (long)37,
                    QuestionName = "Was a report filed?",
                    ControlId = (long)8,
                    ParentId = (long)34,
                    DisplayFormat = "header",
                    CssStyle = "tgl_style",
                    IsRequired = true,
                    RoleName = "Patient"
                },
                 new
                 {
                     Id = (long)38,
                     QuestionName = "Middle Name",
                     ControlId = (long)5,
                     ParentId = (long?)null,
                     DisplayFormat = "inline",
                     CssStyle = "txt_style1",
                     IsRequired = false,
                     RoleName = (long?)null
                 }
            );

            modelBuilder.Entity<ScreenQuestionMapping>().HasData(
                  new
                  {
                      Id = (long)1,
                      ScreenId = (long)1,
                      QuestionId = (long)1,
                      KeyName = "patient",
                  },
                  new
                  {
                      Id = (long)2,
                      ScreenId = (long)2,
                      QuestionId = (long)2,
                      KeyName = "zipCode",
                  },
                  new
                  {
                      Id = (long)3,
                      ScreenId = (long)2,
                      QuestionId = (long)3,
                      KeyName = "city"
                  },
                  new
                  {
                      Id = (long)4,
                      ScreenId = (long)2,
                      QuestionId = (long)4,
                      KeyName = "state"
                  },
                  new
                  {
                      Id = (long)5,
                      ScreenId = (long)3,
                      QuestionId = (long)5,
                      KeyName = "citizenshipStatus"
                  },
                  new
                  {
                      Id = (long)6,
                      ScreenId = (long)4,
                      QuestionId = (long)7,
                      KeyName = "firstName"
                  },
                  new
                  {
                      Id = (long)7,
                      ScreenId = (long)4,
                      QuestionId = (long)8,
                      KeyName = "lastName"
                  },
                  new
                  {
                      Id = (long)8,
                      ScreenId = (long)4,
                      QuestionId = (long)9,
                      KeyName = "dateOfBirth"
                  },
                  new
                  {
                      Id = (long)9,
                      ScreenId = (long)4,
                      QuestionId = (long)10,
                      KeyName = "gender"
                  },
                  new
                  {
                      Id = (long)10,
                      ScreenId = (long)4,
                      QuestionId = (long)11,
                      KeyName = "maritalStatus"
                  },
                  new
                  {
                      Id = (long)11,
                      ScreenId = (long)4,
                      QuestionId = (long)12,
                      KeyName = "email"
                  },
                  new
                  {
                      Id = (long)12,
                      ScreenId = (long)4,
                      QuestionId = (long)13,
                      KeyName = "cellNumber"
                  },
                  new
                  {
                      Id = (long)13,
                      ScreenId = (long)5,
                      QuestionId = (long)14,
                      KeyName = "insurance"
                  },
                  new
                  {
                      Id = (long)14,
                      ScreenId = (long)5,
                      QuestionId = (long)15,
                      KeyName = "policyDetails"
                  },
                  new
                  {
                      Id = (long)15,
                      ScreenId = (long)5,
                      QuestionId = (long)16,
                      KeyName = "payerName"
                  },
                  new
                  {
                      Id = (long)16,
                      ScreenId = (long)5,
                      QuestionId = (long)17,
                      KeyName = "groupName"
                  },
                  new
                  {
                      Id = (long)17,
                      ScreenId = (long)5,
                      QuestionId = (long)18,
                      KeyName = "groupNumber"
                  },
                  new
                  {
                      Id = (long)18,
                      ScreenId = (long)5,
                      QuestionId = (long)19,
                      KeyName = "policyNumber"
                  },
                  new
                  {
                      Id = (long)19,
                      ScreenId = (long)5,
                      QuestionId = (long)20,
                      KeyName = "effectiveFrom"
                  },
                  new
                  {
                      Id = (long)20,
                      ScreenId = (long)5,
                      QuestionId = (long)21,
                      KeyName = "termination"
                  },
                  new
                  {
                      Id = (long)21,
                      ScreenId = (long)6,
                      QuestionId = (long)22,
                  },
                  new
                  {
                      Id = (long)22,
                      ScreenId = (long)6,
                      QuestionId = (long)23,
                      KeyName = "noOfHousehold"
                  },
                  new
                  {
                      Id = (long)23,
                      ScreenId = (long)6,
                      QuestionId = (long)24,
                      KeyName = "minorChildren"
                  },
                  new
                  {
                      Id = (long)24,
                      ScreenId = (long)6,
                      QuestionId = (long)25,
                      KeyName = "isEmployed"
                  },
                  new
                  {
                      Id = (long)25,
                      ScreenId = (long)6,
                      QuestionId = (long)26,
                      KeyName = "isHouseholdEmployed"
                  },
                  new
                  {
                      Id = (long)26,
                      ScreenId = (long)6,
                      QuestionId = (long)27,
                      KeyName = "programServices"
                  },
                  new
                  {
                      Id = (long)27,
                      ScreenId = (long)7,
                      QuestionId = (long)28,
                  },
                  new
                  {
                      Id = (long)28,
                      ScreenId = (long)7,
                      QuestionId = (long)29,
                      KeyName = "householdIncome"
                  },
                  new
                  {
                      Id = (long)29,
                      ScreenId = (long)7,
                      QuestionId = (long)30,
                      KeyName = "incomePayPeriod"
                  },
                  new
                  {
                      Id = (long)30,
                      ScreenId = (long)7,
                      QuestionId = (long)31,
                      KeyName = "householdResources"
                  },
                  new
                  {
                      Id = (long)31,
                      ScreenId = (long)8,
                      QuestionId = (long)32,
                      KeyName = "serviceProgram"
                  },
                  new
                  {
                      Id = (long)32,
                      ScreenId = (long)8,
                      QuestionId = (long)33,
                      KeyName = "healthConditiion"
                  },
                  new
                  {
                      Id = (long)33,
                      ScreenId = (long)8,
                      QuestionId = (long)34,
                      KeyName = "beenInjured"
                  },
                  new
                  {
                      Id = (long)34,
                      ScreenId = (long)8,
                      QuestionId = (long)35,
                      KeyName = "reportFiledCrime"
                  },
                  new
                  {
                      Id = (long)35,
                      ScreenId = (long)4,
                      QuestionId = (long)6,
                      KeyName = "aboutYourself"
                  },
                  new
                  {
                      Id = (long)36,
                      ScreenId = (long)8,
                      QuestionId = (long)36,
                      KeyName = "reportFiledMotor"
                  },
                  new
                  {
                      Id = (long)37,
                      ScreenId = (long)8,
                      QuestionId = (long)37,
                      KeyName = "reportFiledJob"
                  },
                  //new
                  //{
                  //    Id = (long)38,
                  //    ScreenId = (long)8,
                  //    QuestionId = (long)38,
                  //    KeyName = "serviceProgram"
                  //},
                  //new
                  //{
                  //    Id = (long)39,
                  //    ScreenId = (long)8,
                  //    QuestionId = (long)39,
                  //    KeyName = "healthConditiion"
                  //},
                  //new
                  //{
                  //    Id = (long)40,
                  //    ScreenId = (long)8,
                  //    QuestionId = (long)40,
                  //    KeyName = "beenInjured"
                  //},
                  //new
                  //{
                  //    Id = (long)41,
                  //    ScreenId = (long)8,
                  //    QuestionId = (long)41,
                  //    KeyName = "reportFiledCrime"
                  //},
                  new
                  {
                      Id=(long)38,
                      ScreenId = (long)4,
                      QuestionId =(long)38,
                      KeyName = "middleName"
                  }
              );

            modelBuilder.Entity<AnswerOption>().HasData(
                new
                {
                    Id = (long)1,
                    QuestionId = (long)1,
                    Value = "Myself",
                    Name = "myself",
                    Order = 1
                },
                new
                {
                    Id = (long)2,
                    QuestionId = (long)1,
                    Value = "Relative/Friend/Other",
                    Name = "other",
                    Order = 2
                },
                new
                {
                    Id = (long)3,
                    QuestionId = (long)5,
                    Value = "U.S. Citizen",
                    Name = "usCitizen",
                    Order = 1
                },
                new
                {
                    Id = (long)4,
                    QuestionId = (long)5,
                    Value = "Legal Resident",
                    Name = "legalResident",
                    Order = 2
                },
                new
                {
                    Id = (long)5,
                    QuestionId = (long)5,
                    Value = "Undocumented",
                    Name = "undocumented",
                    Order = 3
                },
                new
                {
                    Id = (long)6,
                    QuestionId = (long)5,
                    Value = "Unknown",
                    Name = "unknown",
                    Order = 4
                },
                new
                {
                    Id = (long)7,
                    QuestionId = (long)10,
                    Value = "Male",
                    Name = "M",
                    Order = 1
                },
                new
                {
                    Id = (long)8,
                    QuestionId = (long)10,
                    Value = "Female",
                    Name = "F",
                    Order = 2
                },
                new
                {
                    Id = (long)9,
                    QuestionId = (long)10,
                    Value = "Unreported or Unknown",
                    Name = "U",
                    Order = 3
                },
                new
                {
                    Id = (long)10,
                    QuestionId = (long)11,
                    Value = "Separated",
                    Name = "A",
                    Order = 1
                },
                new
                {
                    Id = (long)11,
                    QuestionId = (long)11,
                    Value = "Divorced",
                    Name = "D",
                    Order = 2
                },
                new
                {
                    Id = (long)12,
                    QuestionId = (long)11,
                    Value = "Married",
                    Name = "M",
                    Order = 3
                },
                new
                {
                    Id = (long)13,
                    QuestionId = (long)11,
                    Value = "Domestic partner",
                    Name = "P",
                    Order = 4
                },
                new
                {
                    Id = (long)14,
                    QuestionId = (long)11,
                    Value = "Single",
                    Name = "S",
                    Order = 5
                },
                new
                {
                    Id = (long)15,
                    QuestionId = (long)11,
                    Value = "Unreported",
                    Name = "T",
                    Order = 6
                },
                new
                {
                    Id = (long)16,
                    QuestionId = (long)11,
                    Value = "Unknown",
                    Name = "U",
                    Order = 7
                },
                new
                {
                    Id = (long)17,
                    QuestionId = (long)11,
                    Value = "Widowed",
                    Name = "W",
                    Order = 8
                },
                new
                {
                    Id = (long)18,
                    QuestionId = (long)13,
                    Value = "United States",
                    Name = "+1",
                    Order = 1
                },
                new
                {
                    Id = (long)19,
                    QuestionId = (long)13,
                    Value = "India",
                    Name = "+91",
                    Order = 2
                },
                new
                {
                    Id = (long)20,
                    QuestionId = (long)14,
                    Value = "No",
                    Order = 1
                },
                new
                {
                    Id = (long)21,
                    QuestionId = (long)14,
                    Value = "Yes",
                    Order = 2
                },
                new
                {
                    Id = (long)22,
                    QuestionId = (long)25,
                    Value = "No",
                    Order = 1
                },
                new
                {
                    Id = (long)23,
                    QuestionId = (long)25,
                    Value = "Yes",
                    Order = 2
                },
                new
                {
                    Id = (long)24,
                    QuestionId = (long)26,
                    Value = "No",
                    Order = 1
                },
                new
                {
                    Id = (long)25,
                    QuestionId = (long)26,
                    Value = "Yes",
                    Order = 2
                },
                new
                {
                    Id = (long)26,
                    QuestionId = (long)27,
                    Value = "CalFresh (Food Stamps)",
                    Name = "calFresh",
                    Order = 1
                },
                new
                {
                    Id = (long)27,
                    QuestionId = (long)27,
                    Value = "SSI / SSP",
                    Name = "ssi",
                    Order = 2
                },
                new
                {
                    Id = (long)28,
                    QuestionId = (long)27,
                    Value = "CalWorks",
                    Name = "calWorks",
                    Order = 3
                },
                new
                {
                    Id = (long)29,
                    QuestionId = (long)27,
                    Value = "Refugee Assistance",
                    Name = "refugeeAssisstance",
                    Order = 4
                },
                new
                {
                    Id = (long)30,
                    QuestionId = (long)27,
                    Value = "All of the above",
                    Name = "allOfTheAbove",
                    Order = 5
                },
                new
                {
                    Id = (long)31,
                    QuestionId = (long)30,
                    Value = "Yearly",
                    Name = "yearly",
                    Order = 1
                },
                new
                {
                    Id = (long)32,
                    QuestionId = (long)30,
                    Value = "Monthly",
                    Name = "monthly",
                    Order = 2
                },
                new
                {
                    Id = (long)33,
                    QuestionId = (long)30,
                    Value = "Bimonthly",
                    Name = "bimonthly",
                    Order = 3
                },
                new
                {
                    Id = (long)34,
                    QuestionId = (long)30,
                    Value = "Biweekly",
                    Name = "biweekly",
                    Order = 4
                },
                new
                {
                    Id = (long)35,
                    QuestionId = (long)30,
                    Value = "Weekly",
                    Name = "weekly",
                    Order = 5
                },
                new
                {
                    Id = (long)36,
                    QuestionId = (long)32,
                    Value = "Pregnant now / in past 6 months",
                    Name = "pregnantNow",
                    Order = 1
                },
                new
                {
                    Id = (long)37,
                    QuestionId = (long)32,
                    Value = "Veteran",
                    Name = "veteran",
                    Order = 2
                },
                new
                {
                    Id = (long)38,
                    QuestionId = (long)32,
                    Value = "Member of Indian tribe",
                    Name = "memberOfIndianTribe",
                    Order = 3
                },
                new
                {
                    Id = (long)39,
                    QuestionId = (long)32,
                    Value = "Former Foster Youth",
                    Name = "formerFosterYouth",
                    Order = 4
                },
                new
                {
                    Id = (long)40,
                    QuestionId = (long)33,
                    Value = "Deemed as disabled for 12 months or longer",
                    Name = "deemed",
                    Order = 1
                },
                new
                {
                    Id = (long)41,
                    QuestionId = (long)33,
                    Value = "You/member of your family been declared legally blind",
                    Name = "you/member",
                    Order = 2
                },
                new
                {
                    Id = (long)42,
                    QuestionId = (long)34,
                    Value = "In crime related violence (as a victim)",
                    Name = "inCrime",
                    Order = 1
                },
                new
                {
                    Id = (long)43,
                    QuestionId = (long)34,
                    Value = "In motor vehicle accident",
                    Name = "inMotorVehicle",
                    Order = 2
                },
                new
                {
                    Id = (long)44,
                    QuestionId = (long)34,
                    Value = "On the job",
                    Name = "onTheJob",
                    Order = 3
                },
                new
                {
                    Id = (long)45,
                    QuestionId = (long)35,
                    Value = "No",
                    Order = 1
                },
                new
                {
                    Id = (long)46,
                    QuestionId = (long)35,
                    Value = "Yes",
                    Order = 2
                },
                new
                {
                    Id = (long)47,
                    QuestionId = (long)36,
                    Value = "No",
                    Order = 1
                },
                new
                {
                    Id = (long)48,
                    QuestionId = (long)36,
                    Value = "Yes",
                    Order = 2
                },
                new
                {
                    Id = (long)49,
                    QuestionId = (long)37,
                    Value = "No",
                    Order = 1
                },
                new
                {
                    Id = (long)50,
                    QuestionId = (long)37,
                    Value = "Yes",
                    Order = 2
                },
                new
                {
                    Id = (long)51,
                    QuestionId = (long)38,
                    Value = "Pregnant now / in past 6 months",
                    Name = "pregnantNow",
                    Order = 1
                },
                new
                {
                    Id = (long)52,
                    QuestionId = (long)38,
                    Value = "Veteran",
                    Name = "veteran",
                    Order = 2
                },
                new
                {
                    Id = (long)53,
                    QuestionId = (long)38,
                    Value = "Member of Indian tribe",
                    Name = "memberOfIndianTribe",
                    Order = 3
                },
                new
                {
                    Id = (long)54,
                    QuestionId = (long)38,
                    Value = "Former Foster Youth",
                    Name = "formerFosterYouth",
                    Order = 4
                },
                new
                {
                    Id = (long)55,
                    QuestionId = (long)39,
                    Value = "Deemed as disabled for 12 months or longer",
                    Name = "deemed",
                    Order = 1
                },
                new
                {
                    Id = (long)56,
                    QuestionId = (long)39,
                    Value = "You/member of your family been declared legally blind",
                    Name = "you/member",
                    Order = 2
                },
                new
                {
                    Id = (long)57,
                    QuestionId = (long)40,
                    Value = "In crime related violence (as a victim)",
                    Name = "inCrime",
                    Order = 1
                },
                new
                {
                    Id = (long)58,
                    QuestionId = (long)40,
                    Value = "In motor vehicle accident",
                    Name = "inMotorVehicle",
                    Order = 2
                },
                new
                {
                    Id = (long)59,
                    QuestionId = (long)40,
                    Value = "On the job",
                    Name = "onTheJob",
                    Order = 3
                },
                new
                {
                    Id = (long)60,
                    QuestionId = (long)41,
                    Value = "No",
                    Order = 1
                },
                new
                {
                    Id = (long)61,
                    QuestionId = (long)41,
                    Value = "Yes",
                    Order = 2
                }
            );

            modelBuilder.Entity<Healthware.Core.Entities.RolesPermission>().HasData(
                new
                {
                    Id = (long)1,
                    RoleId = (long)1,
                    PermissionId = (long)7,
                },
                new
                {
                    Id = (long)2,
                    RoleId = (long)1,
                    PermissionId = (long)12,
                },
                new
                {
                    Id = (long)3,
                    RoleId = (long)1,
                    PermissionId = (long)13,
                },
                new
                {
                    Id = (long)4,
                    RoleId = (long)1,
                    PermissionId = (long)14,
                },
                new
                {
                    Id = (long)5,
                    RoleId = (long)1,
                    PermissionId = (long)15,
                },
                new
                {
                    Id = (long)6,
                    RoleId = (long)1,
                    PermissionId = (long)16,
                },
                new
                {
                    Id = (long)7,
                    RoleId = (long)1,
                    PermissionId = (long)17,
                },
                new
                {
                    Id = (long)8,
                    RoleId = (long)1,
                    PermissionId = (long)18,
                },
                new
                {
                    Id = (long)9,
                    RoleId = (long)1,
                    PermissionId = (long)19,
                },
                new
                {
                    Id = (long)10,
                    RoleId = (long)1,
                    PermissionId = (long)20,
                },
                new
                {
                    Id = (long)11,
                    RoleId = (long)1,
                    PermissionId = (long)24,
                },
                new
                {
                    Id = (long)12,
                    RoleId = (long)1,
                    PermissionId = (long)1,
                },
                new
                {
                    Id = (long)13,
                    RoleId = (long)1,
                    PermissionId = (long)2,
                },
                new
                {
                    Id = (long)14,
                    RoleId = (long)1,
                    PermissionId = (long)3,
                },
                new
                {
                    Id = (long)15,
                    RoleId = (long)2,
                    PermissionId = (long)8,
                },
                new
                {
                    Id = (long)16,
                    RoleId = (long)2,
                    PermissionId = (long)9,
                },
                new
                {
                    Id = (long)17,
                    RoleId = (long)2,
                    PermissionId = (long)10,
                },
                new
                {
                    Id = (long)18,
                    RoleId = (long)2,
                    PermissionId = (long)11,
                },
                new
                {
                    Id = (long)19,
                    RoleId = (long)2,
                    PermissionId = (long)12,
                },
                new
                {
                    Id = (long)20,
                    RoleId = (long)2,
                    PermissionId = (long)13,
                },
                new
                {
                    Id = (long)21,
                    RoleId = (long)2,
                    PermissionId = (long)14,
                },
                new
                {
                    Id = (long)22,
                    RoleId = (long)2,
                    PermissionId = (long)15,
                },
                new
                {
                    Id = (long)23,
                    RoleId = (long)2,
                    PermissionId = (long)16,
                },
                new
                {
                    Id = (long)24,
                    RoleId = (long)2,
                    PermissionId = (long)17,
                },
                new
                {
                    Id = (long)25,
                    RoleId = (long)2,
                    PermissionId = (long)18,
                },
                new
                {
                    Id = (long)26,
                    RoleId = (long)2,
                    PermissionId = (long)19,
                },
                new
                {
                    Id = (long)27,
                    RoleId = (long)2,
                    PermissionId = (long)20,
                },
                new
                {
                    Id = (long)28,
                    RoleId = (long)2,
                    PermissionId = (long)24,
                },
                new
                {
                    Id = (long)29,
                    RoleId = (long)2,
                    PermissionId = (long)1,
                },
                new
                {
                    Id = (long)30,
                    RoleId = (long)2,
                    PermissionId = (long)2,
                },
                new
                {
                    Id = (long)31,
                    RoleId = (long)2,
                    PermissionId = (long)3,
                },
                new
                {
                    Id = (long)32,
                    RoleId = (long)2,
                    PermissionId = (long)46,
                },
                new
                {
                    Id = (long)33,
                    RoleId = (long)1,
                    PermissionId = (long)10,
                },
                new
                {
                    Id = (long)34,
                    RoleId = (long)1,
                    PermissionId = (long)39,
                },
                new
                {
                    Id = (long)35,
                    RoleId = (long)1,
                    PermissionId = (long)40,
                },
                new
                {
                    Id = (long)36,
                    RoleId = (long)1,
                    PermissionId = (long)41,
                },
                new
                {
                    Id = (long)37,
                    RoleId = (long)1,
                    PermissionId = (long)42,
                },
                new
                {
                    Id = (long)38,
                    RoleId = (long)1,
                    PermissionId = (long)43,
                },
                new
                {
                    Id = (long)39,
                    RoleId = (long)1,
                    PermissionId = (long)44,
                },
                new
                {
                    Id = (long)40,
                    RoleId = (long)1,
                    PermissionId = (long)38,
                },
                new
                {
                    Id = (long)41,
                    RoleId = (long)1,
                    PermissionId = (long)36,
                },
                new
                {
                    Id = (long)42,
                    RoleId = (long)1,
                    PermissionId = (long)37,
                },
                new
                {
                    Id = (long)43,
                    RoleId = (long)2,
                    PermissionId = (long)37,
                },
                new
                {
                    Id = (long)44,
                    RoleId = (long)1,
                    PermissionId = (long)33,
                },
                new
                {
                    Id = (long)45,
                    RoleId = (long)2,
                    PermissionId = (long)33,
                },
                new
                {
                    Id = (long)46,
                    RoleId = (long)2,
                    PermissionId = (long)23,
                },
                new
                {
                    Id = (long)47,
                    RoleId = (long)1,
                    PermissionId = (long)28,
                },
                new
                {
                    Id = (long)48,
                    RoleId = (long)2,
                    PermissionId = (long)29,
                },
                new
                {
                    Id = (long)49,
                    RoleId = (long)2,
                    PermissionId = (long)45,
                },
                new
                {
                    Id = (long)50,
                    RoleId = (long)1,
                    PermissionId = (long)47
                },
                new
                {
                    Id = (long)51,
                    RoleId = (long)1,
                    PermissionId = (long)48
                },
                new
                {
                    Id = (long)52,
                    RoleId = (long)2,
                    PermissionId = (long)48
                },
                new
                {
                    Id = (long)53,
                    RoleId = (long)1,
                    PermissionId = (long)49
                },
                new
                {
                    Id = (long)54,
                    RoleId = (long)2,
                    PermissionId = (long)49
                },
                new
                {
                    Id = (long)55,
                    RoleId = (long)1,
                    PermissionId = (long)50
                },
                new
                {
                    Id = (long)56,
                    RoleId = (long)2,
                    PermissionId = (long)50
                },
                new
                {
                    Id = (long)57,
                    RoleId = (long)1,
                    PermissionId = (long)51
                },
                new
                {
                    Id = (long)58,
                    RoleId = (long)2,
                    PermissionId = (long)51
                },
                new
                {
                    Id = (long)59,
                    RoleId = (long)1,
                    PermissionId = (long)52
                },
                new
                {
                    Id = (long)60,
                    RoleId = (long)2,
                    PermissionId = (long)52
                },
                new
                {
                    Id = (long)61,
                    RoleId = (long)2,
                    PermissionId = (long)53
                },
                new
                {
                    Id = (long)62,
                    RoleId = (long)2,
                    PermissionId = (long)54
                },
                new
                {
                    Id = (long)63,
                    RoleId = (long)1,
                    PermissionId = (long)55
                },
                new
                {
                    Id = (long)64,
                    RoleId = (long)2,
                    PermissionId = (long)55
                },
                new
                {
                    Id = (long)65,
                    RoleId = (long)1,
                    PermissionId = (long)56
                },
                new
                {
                    Id = (long)66,
                    RoleId = (long)1,
                    PermissionId = (long)57
                },
                new
                {
                    Id = (long)67,
                    RoleId = (long)1,
                    PermissionId = (long)58
                },
                new
                {
                    Id = (long)68,
                    RoleId = (long)2,
                    PermissionId = (long)58
                },
                new
                {
                    Id = (long)69,
                    RoleId = (long)1,
                    PermissionId = (long)59
                },
                new
                {
                    Id = (long)70,
                    RoleId = (long)2,
                    PermissionId = (long)59
                },
                new
                {
                    Id = (long)71,
                    RoleId = (long)1,
                    PermissionId = (long)60
                },
                new
                {
                    Id = (long)72,
                    RoleId = (long)2,
                    PermissionId = (long)60
                },
                new
                {
                    Id = (long)73,
                    RoleId = (long)1,
                    PermissionId = (long)61
                },
                new
                {
                    Id = (long)74,
                    RoleId = (long)2,
                    PermissionId = (long)61
                },
                new
                {
                    Id = (long)75,
                    RoleId = (long)1,
                    PermissionId = (long)62
                },
                new
                {
                    Id = (long)76,
                    RoleId = (long)2,
                    PermissionId = (long)62
                },
                new
                {
                    Id = (long)77,
                    RoleId = (long)1,
                    PermissionId = (long)63
                },
                new
                {
                    Id = (long)78,
                    RoleId = (long)2,
                    PermissionId = (long)63
                },
                new
                {
                    Id = (long)79,
                    RoleId = (long)1,
                    PermissionId = (long)64
                },
                new
                {
                    Id = (long)80,
                    RoleId = (long)2,
                    PermissionId = (long)64
                },
                new
                {
                    Id = (long)81,
                    RoleId = (long)1,
                    PermissionId = (long)65
                },
                new
                {
                    Id = (long)82,
                    RoleId = (long)2,
                    PermissionId = (long)65
                },
                new
                {
                    Id = (long)83,
                    RoleId = (long)1,
                    PermissionId = (long)66
                },
                new
                {
                    Id = (long)84,
                    RoleId = (long)2,
                    PermissionId = (long)66
                },
                new
                {
                    Id = (long)85,
                    RoleId = (long)1,
                    PermissionId = (long)67
                },
                new
                {
                    Id = (long)86,
                    RoleId = (long)2,
                    PermissionId = (long)67
                },
                new
                {
                    Id = (long)87,
                    RoleId = (long)1,
                    PermissionId = (long)68
                },
                new
                {
                    Id = (long)88,
                    RoleId = (long)2,
                    PermissionId = (long)68
                },
                new
                {
                    Id = (long)89,
                    RoleId = (long)1,
                    PermissionId = (long)69
                },
                new
                {
                    Id = (long)90,
                    RoleId = (long)2,
                    PermissionId = (long)69
                },
                new
                {
                    Id = (long)91,
                    RoleId = (long)1,
                    PermissionId = (long)70
                },
                new
                {
                    Id = (long)92,
                    RoleId = (long)2,
                    PermissionId = (long)70
                },
                new
                {
                    Id = (long)93,
                    RoleId = (long)1,
                    PermissionId = (long)71
                },
                new
                {
                    Id = (long)94,
                    RoleId = (long)2,
                    PermissionId = (long)71
                },
                new
                {
                    Id = (long)95,
                    RoleId = (long)1,
                    PermissionId = (long)72
                },
                new
                {
                    Id = (long)96,
                    RoleId = (long)2,
                    PermissionId = (long)72
                },
                new
                {
                    Id = (long)97,
                    RoleId = (long)2,
                    PermissionId = (long)25
                },
                new
                {
                    Id = (long)98,
                    RoleId = (long)1,
                    PermissionId = (long)73
                },
                new
                {
                    Id = (long)99,
                    RoleId = (long)2,
                    PermissionId = (long)73
                },
                new
                {
                    Id = (long)100,
                    RoleId = (long)1,
                    PermissionId = (long)74
                },
                new
                {
                    Id = (long)101,
                    RoleId = (long)2,
                    PermissionId = (long)74
                },
                new
                {
                    Id = (long)102,
                    RoleId = (long)1,
                    PermissionId = (long)75
                },
                new
                {
                    Id = (long)103,
                    RoleId = (long)2,
                    PermissionId = (long)75
                },
                new
                {
                    Id = (long)104,
                    RoleId = (long)1,
                    PermissionId = (long)76
                },
                new
                {
                    Id = (long)105,
                    RoleId = (long)2,
                    PermissionId = (long)76
                },
                new
                {
                    Id = (long)106,
                    RoleId = (long)1,
                    PermissionId = (long)77
                },
                new
                {
                    Id = (long)107,
                    RoleId = (long)2,
                    PermissionId = (long)77
                },
                new
                {
                    Id = (long)108,
                    RoleId = (long)1,
                    PermissionId = (long)78
                },
                new
                {
                    Id = (long)109,
                    RoleId = (long)2,
                    PermissionId = (long)78
                },
                new
                {
                    Id = (long)110,
                    RoleId = (long)1,
                    PermissionId = (long)79
                },
                new
                {
                    Id = (long)111,
                    RoleId = (long)2,
                    PermissionId = (long)79
                },
                new
                {
                    Id = (long)112,
                    RoleId = (long)2,
                    PermissionId = (long)22
                },
                new
                {
                    Id = (long)113,
                    RoleId = (long)1,
                    PermissionId = (long)34,
                },
                new
                {
                    Id = (long)114,
                    RoleId = (long)2,
                    PermissionId = (long)34,
                },
                new
                {
                    Id = (long)115,
                    RoleId = (long)1,
                    PermissionId = (long)26,
                },
                new
                {
                    Id = (long)116,
                    RoleId = (long)2,
                    PermissionId = (long)26,
                },
                new
                {
                    Id = (long)117,
                    RoleId = (long)1,
                    PermissionId = (long)45,
                },
                new
                {
                    Id = (long)118,
                    RoleId = (long)1,
                    PermissionId = (long)29,
                },
                new
                {
                    Id = (long)119,
                    RoleId = (long)1,
                    PermissionId = (long)25,
                },
                new
                {
                    Id = (long)120,
                    RoleId = (long)1,
                    PermissionId = (long)53,
                },
                new
                {
                    Id = (long)121,
                    RoleId = (long)1,
                    PermissionId = (long)21,
                },
                new
                {
                    Id = (long)122,
                    RoleId = (long)2,
                    PermissionId = (long)21,
                },
                new
                {
                    Id = (long)123,
                    RoleId = (long)1,
                    PermissionId = (long)81,
                },
                new
                {
                    Id = (long)124,
                    RoleId = (long)1,
                    PermissionId = (long)80,
                },
                new
                {
                    Id = (long)125,
                    RoleId = (long)2,
                    PermissionId = (long)80,
                },
                new
                {
                    Id = (long)126,
                    RoleId = (long)2,
                    PermissionId = (long)56
                }
            );

            modelBuilder.Entity<TenantDetails>().HasData(
                new TenantDetails
                {
                    Id = 1,
                    TenantName = "Tenant 1",
                    PhoneNumber = "5554442341",
                    CountyCode = "1",
                    PublicKey = "b14ca5898a4e4142aace2ea2143a2410",
                    UserKey = "activeassistzuci",
                    TenantCode = "MHC",
                    EmailAddress = "support@tenant1.com",
                    CreatedDate = Constants.CreatedDateTime
                },
                new TenantDetails
                {
                    Id = 2,
                    TenantName = "Tenant 2",
                    PhoneNumber = "6663432341",
                    CountyCode = "1",
                    PublicKey = "b14ca5898a4e4142aace2ea2143a2410",
                    UserKey = "activeassistzuci",
                    TenantCode = "LOC",
                    EmailAddress = "support@tenant2.com",
                    CreatedDate = Constants.CreatedDateTime
                },
                new TenantDetails
                {
                    Id = 3,
                    TenantName = "Tenant 3",
                    PhoneNumber = "4463432341",
                    CountyCode = "1",
                    PublicKey = "b14ca5898a4e4142aace2ea2143a2410",
                    UserKey = "activeassistzuci",
                    TenantCode = "MV",
                    EmailAddress = "support@tenant3.com",
                    CreatedDate = Constants.CreatedDateTime
                }
            );
            modelBuilder.Entity<ReasonNoSsn>().HasData(
                new ReasonNoSsn
                {
                    Id = 1,
                    CodeData = "NA",
                    CodeType = "NoSSNReason",
                    CodeDescription = "Does Not Have One",
                },
                new ReasonNoSsn
                {
                    Id = 2,
                    CodeData = "UNC",
                    CodeType = "NoSSNReason",
                    CodeDescription = "Unconcious - Could Not Provide",
                },
                new ReasonNoSsn
                {
                    Id = 3,
                    CodeData = "OTH",
                    CodeType = "NoSSNReason",
                    CodeDescription = "Other",
                }
            );
        }
    }
}
