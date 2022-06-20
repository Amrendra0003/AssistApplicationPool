using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using HealthWare.ActiveASSIST.DTOs;
using HealthWare.ActiveASSIST.Entities;
using HealthWare.ActiveASSIST.Entities.DropDown;
using Healthware.Core.MultiTenancy.Entities;
using Healthware.Core.MultiTenancy.Entities.Interfaces;
using Microsoft.EntityFrameworkCore;
using Option = HealthWare.ActiveASSIST.Entities.Option;
using VerificationDocument = HealthWare.ActiveASSIST.Entities.VerificationDocument;
using Healthware.Core.MultiTenancy.Services.Interfaces;
using Healthware.Core.Entities;
using Healthware.Core.Security;
using HealthWare.ActiveASSIST.Entities.Mappings;

namespace HealthWare.ActiveASSIST.Repositories.Base.Connection
{
    public class PatientDbContext : DbContext
    {
        public string TenantId { get; set; }
        private readonly ITenantService _tenantService;
        public PatientDbContext(DbContextOptions<PatientDbContext> options, ITenantService tenantService) : base(options)
        {
            _tenantService = tenantService;
            TenantId = _tenantService.GetTenant()?.TID;
        }
        public virtual DbSet<BasicInfo> BasicInfo { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<UserAccount> UserAccount { get; set; }
        public virtual DbSet<SessionActivity> SessionActivity { get; set; }
        public virtual DbSet<ServiceAuditTrail> ServiceAuditTrails { get; set; }
        public virtual DbSet<JournalEntry> JournalEntries { get; set; }
        public virtual DbSet<Role> Roles { get; set; }
        public virtual DbSet<UserHasRoles> UserHasRoles { get; set; }
        public virtual DbSet<HouseHoldMember> HouseHoldMember { get; set; }
        public virtual DbSet<HouseHoldMemberIncome> HouseHoldMemberIncome { get; set; }
        public virtual DbSet<HouseHoldMemberResource> HouseHoldMemberResource { get; set; }
        public virtual DbSet<Healthware.Core.Entities.ContactDetails> ContactDetails { get; set; }
        public virtual DbSet<Guarantor> Guarantor { get; set; }
        public virtual DbSet<Program> Program { get; set; }
        public virtual DbSet<Entities.Screen> Screen { get; set; }
        public virtual DbSet<Control> Control { get; set; }
        public virtual DbSet<Answer> Answer { get; set; }
        public virtual DbSet<AnswerOption> AnswerOption { get; set; }
        public virtual DbSet<Entities.Question> Question { get; set; }
        public virtual DbSet<PatientProgramMapping> PatientProgramMapping { get; set; }
        public virtual DbSet<Gender> Gender { get; set; }
        public virtual DbSet<MaritalStatus> MaritalStatus { get; set; }
        public virtual DbSet<RelationshipToPatient> RelationshipToPatient { get; set; }
        public virtual DbSet<IncomeType> IncomeType { get; set; }
        public virtual DbSet<IncomeTypeCurrentStatus> IncomeTypeCurrentStatus { get; set; }
        public virtual DbSet<PayPeriod> PayPeriod { get; set; }
        public virtual DbSet<Verification> Verification { get; set; }
        public virtual DbSet<ResourceType> ResourceType { get; set; }
        public virtual DbSet<ResourceTypeCurrentStatus> ResourceTypeCurrentStatus { get; set; }
        public virtual DbSet<AssessmentVerification> AssessmentVerification { get; set; }
        public virtual DbSet<ProgramDocument> ProgramDocument { get; set; }
        public virtual DbSet<ContactPreference> ContactPreference { get; set; }
        public virtual DbSet<ReviewNotes> ReviewNotes { get; set; }
        public virtual DbSet<HouseholdMemberDocument> HouseholdMemberDocument { get; set; }
        public virtual DbSet<Document> Document { get; set; }
        public virtual DbSet<Permission> Permission { get; set; }
        public virtual DbSet<RolesPermission> RolesPermissions { get; set; }
        public virtual DbSet<ScreenQuestionMapping> ScreenQuestionMapping { get; set; }
        public virtual DbSet<AssessmentSummaryResult> AssessmentSummaryResult { get; set; }
        public virtual DbSet<AssessmentResult> AssessmentResult { get; set; }
        public virtual DbSet<DocumentCategoryMaster> DocumentCategoryMaster { get; set; }
        public virtual DbSet<DocumentTypeMaster> DocumentTypeMaster { get; set; }
        public virtual DbSet<DocumentCategoryDocumentTypeMapping> DocumentCategoryDocumentTypeMapping { get; set; }
        public virtual DbSet<ContactTypeMaster> ContactTypeMaster { get; set; }
        public virtual DbSet<DocumentProgramMapping> DocumentProgramMapping { get; set; }
        public virtual DbSet<TabCompletionStatus> TabCompletionStatus { get; set; }
        public virtual DbSet<AssessmentStatusMaster> AssessmentStatusMaster { get; set; }
        public virtual DbSet<DashboardAssessment> DashboardAssessment { get; set; }
        public virtual DbSet<AssessmentInPatientDashboard> AssessmentInPatientDashboard { get; set; }
        public virtual DbSet<DynamicScreens> DynamicScreens { get; set; }
        public virtual DbSet<QuickAssessmentQuestions> QuickAssessmentQuestions { get; set; }
        public virtual DbSet<Option> Options { get; set; }
        public virtual DbSet<Validators> Validators { get; set; }
        public virtual DbSet<QuickAssessmentResult> QuickAssessmentResult { get; set; }
        public virtual DbSet<VerificationDocument> VerificationDocument { get; set; }
        public virtual DbSet<SubDomainMaster> SubDomainMaster { get; set; }
        public virtual DbSet<ScreenTenantMapping> ScreenTenantMapping { get; set; }
        public virtual DbSet<TenantDetails> TenantDetails { get; set; }
        public virtual DbSet<UserVerification> UserVerification { get; set; }
        public virtual DbSet<PasswordPolicy> PasswordPolicy { get; set; }
        public virtual DbSet<UserLoginHistory> UserLoginHistory { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ContactTypeMaster>().HasData(
                new ContactTypeMaster()
                {
                    Id = 1,
                    EntityType = Constants.Self,
                    ContactType = Constants.Basic
                },
                new ContactTypeMaster()
                {
                    Id = 2,
                    EntityType = Constants.Self,
                    ContactType = Constants.Home
                },
                new ContactTypeMaster()
                {
                    Id = 3,
                    EntityType = Constants.Self,
                    ContactType = Constants.Work
                },
                new ContactTypeMaster()
                {
                    Id = 4,
                    EntityType = Constants.Guarantor,
                    ContactType = Constants.Basic
                },
                new ContactTypeMaster()
                {
                    Id = 5,
                    EntityType = Constants.Guarantor,
                    ContactType = Constants.Home
                },
                new ContactTypeMaster()
                {
                    Id = 6,
                    EntityType = Constants.Guarantor,
                    ContactType = Constants.Work
                },
                new ContactTypeMaster()
                {
                    Id = 7,
                    EntityType = Constants.HouseholdMember,
                    ContactType = Constants.Work
                },
                new ContactTypeMaster()
                {
                    Id = 8,
                    EntityType = Constants.Other,
                    ContactType = Constants.Other
                },
                new ContactTypeMaster()
                {
                    Id = 9,
                    EntityType = Constants.UserProfile,
                    ContactType = Constants.Home
                },
                new ContactTypeMaster()
                {
                    Id = 10,
                    EntityType = Constants.UserProfile,
                    ContactType = Constants.SecondaryEmail
                }
            );

            modelBuilder.Entity<Healthware.Core.Entities.ContactDetails>().HasData(new
                {
                    Id = (long)1,
                    Name = "Dummy",
                    CountyCode = "1",
                    Email = "dummy",
                    Cell = "1111111111",
                    ContactTypeDetailsId = (long)9,
                    CreatedDate = Constants.CreatedDateTime
                },
                new
                {
                    Id = (long)2,
                    CountyCode = "1",
                    Name = "Naresh Kumar",
                    Email = "naresh.k@zucisystems.com",
                    Cell = "2222222222",
                    City = "Schenectady",
                    State = "New York",
                    Zip = "12345",
                    County = "United States",
                    StateCode = "NY",
                    ContactTypeDetailsId = (long)9,
                    CreatedDate = Constants.CreatedDateTime
                },
                new
                {
                    Id = (long)3,
                    Name = "Naresh Kumar",
                    Email = "naresh.k@zucisystems.com",
                    ContactTypeDetailsId = (long)10,
                    CreatedDate = Constants.CreatedDateTime
                },
                new
                {
                    Id = (long)4,
                    CountyCode = "1",
                    Name = "Iniya J",
                    Email = "iniya.j@zucisystems.com",
                    Cell = "3333333333",
                    City = "Schenectady",
                    State = "New York",
                    Zip = "12345",
                    County = "United States",
                    StateCode = "NY",
                    ContactTypeDetailsId = (long)9,
                    CreatedDate = Constants.CreatedDateTime
                },
                new
                {
                    Id = (long)5,
                    Name = "Iniya J",
                    Email = "iniya.j@zucisystems.com",
                    ContactTypeDetailsId = (long)10,
                    CreatedDate = Constants.CreatedDateTime
                },
                new
                {
                    Id = (long)6,
                    CountyCode = "1",
                    Name = "Dimitriy Kucherina",
                    Email = "dkucherina@healthwaresystems.com",
                    Cell = "3333333333",
                    City = "Schenectady",
                    State = "New York",
                    Zip = "12345",
                    County = "United States",
                    StateCode = "NY",
                    ContactTypeDetailsId = (long)9,
                    CreatedDate = Constants.CreatedDateTime
                },
                new
                {
                    Id = (long)7,
                    Name = "Dimitriy Kucherina",
                    Email = "dkucherina@healthwaresystems.com",
                    ContactTypeDetailsId = (long)10,
                    CreatedDate = Constants.CreatedDateTime
                },
                new
                {
                    Id = (long)8,
                    CountyCode = "1",
                    Name = "Subba Raman",
                    Email = "psubbaraman@healthwaresystems.com",
                    Cell = "3333333333",
                    City = "Schenectady",
                    State = "New York",
                    Zip = "12345",
                    County = "United States",
                    StateCode = "NY",
                    ContactTypeDetailsId = (long)9,
                    CreatedDate = Constants.CreatedDateTime
                },
                new
                {
                    Id = (long)9,
                    Name = "Subba Raman",
                    Email = "psubbaraman@healthwaresystems.com",
                    ContactTypeDetailsId = (long)10,
                    CreatedDate = Constants.CreatedDateTime
                },
                new
                {
                    Id = (long)10,
                    CountyCode = "1",
                    Name = "Stephen Gruner",
                    Email = "sgruner@healthwaresystems.com",
                    Cell = "3333333333",
                    City = "Schenectady",
                    State = "New York",
                    Zip = "12345",
                    County = "United States",
                    StateCode = "NY",
                    ContactTypeDetailsId = (long)9,
                    CreatedDate = Constants.CreatedDateTime
                },
                new
                {
                    Id = (long)11,
                    Name = "Stephen Gruner",
                    Email = "sgruner@healthwaresystems.com",
                    ContactTypeDetailsId = (long)10,
                    CreatedDate = Constants.CreatedDateTime
                },
                new
                {
                    Id = (long)12,
                    CountyCode = "1",
                    Name = "Jay Kunwar",
                    Email = "jkunwar@healthwaresystems.com",
                    Cell = "3333333333",
                    City = "Schenectady",
                    State = "New York",
                    Zip = "12345",
                    County = "United States",
                    StateCode = "NY",
                    ContactTypeDetailsId = (long)9,
                    CreatedDate = Constants.CreatedDateTime
                },
                new
                {
                    Id = (long)13,
                    Name = "Jay Kunwar",
                    Email = "jkunwar@healthwaresystems.com",
                    ContactTypeDetailsId = (long)10,
                    CreatedDate = Constants.CreatedDateTime
                },
                new
                {
                    Id = (long)14,
                    CountyCode = "1",
                    Name = "Mynthan Kumar",
                    Email = "mynthan.k@zucisystems.com",
                    Cell = "3333333333",
                    City = "Schenectady",
                    State = "New York",
                    Zip = "12345",
                    County = "United States",
                    StateCode = "NY",
                    ContactTypeDetailsId = (long)9,
                    CreatedDate = Constants.CreatedDateTime
                },
                new
                {
                    Id = (long)15,
                    Name = "Mynthan Kumar",
                    Email = "mynthan.k@zucisystems.com",
                    ContactTypeDetailsId = (long)10,
                    CreatedDate = Constants.CreatedDateTime
                },
                new
                {
                    Id = (long)16,
                    CountyCode = "1",
                    Name = "Uma Raja",
                    Email = "uma.r@zucisystems.com",
                    Cell = "3333333333",
                    City = "Schenectady",
                    State = "New York",
                    Zip = "12345",
                    County = "United States",
                    StateCode = "NY",
                    ContactTypeDetailsId = (long)9,
                    CreatedDate = Constants.CreatedDateTime
                },
                new
                {
                    Id = (long)17,
                    Name = "Uma Raja",
                    Email = "uma.r@zucisystems.com",
                    ContactTypeDetailsId = (long)10,
                    CreatedDate = Constants.CreatedDateTime
                });
            modelBuilder.Entity<User>().HasData(
                new
                {
                    Id = (long)-1,
                    EmailAddress = "dummy",
                    Cell = "1111111111",
                    ContactDetailsId = (long)1,
                    Password = PasswordEncryptionDecryption.HashPassword("dummyUser"),
                    IsActive = true,
                    CanChangePassword = false,
                    IsTokenConsumed = false,
                    IsAuthenticated = false,
                    CreatedDate = Constants.CreatedDateTime,
                    LoginOTPUpdatedTime = (DateTime?)(null),
                },
                new
                {
                    Id = (long)1,
                    EmailAddress = "naresh.k@zucisystems.com",
                    CountyCode = "1",
                    Cell = "2222222222",
                    ContactDetailsId = (long)2,
                    FirstName = "Naresh",
                    LastName = "Kumar",
                    DateOfBirth = new DateTime(629833536000000000),
                    Gender = "Male",
                    MaritalStatus = "Single",
                    Password = PasswordEncryptionDecryption.HashPassword("Password@123"),
                    IsActive = true,
                    CanChangePassword = false,
                    IsTokenConsumed = false,
                    IsAuthenticated = false,
                    LoginOTPUpdatedTime = (DateTime?)(null),
                    SSNNumber = "212128812",
                    TenantId = "1",
                    SecondaryEmailContactDetailsId = (long)3,
                    CreatedDate = Constants.CreatedDateTime 
                },
                new
                {
                    Id = (long)2,
                    EmailAddress = "iniya.j@zucisystems.com",
                    CountyCode = "1",
                    Cell = "3333333333",
                    ContactDetailsId = (long)4,
                    FirstName = "Iniya",
                    LastName = "J",
                    DateOfBirth = new DateTime(629833536000000000),
                    Gender = "Female",
                    MaritalStatus = "Married",
                    Password = PasswordEncryptionDecryption.HashPassword("Password@123"),
                    IsActive = true,
                    CanChangePassword = false,
                    IsTokenConsumed = false,
                    IsAuthenticated = false,
                    LoginOTPUpdatedTime = (DateTime?)(null),
                    SSNNumber = "212127744",
                    TenantId = "1",
                    SecondaryEmailContactDetailsId = (long)5,
                    CreatedDate = Constants.CreatedDateTime
                },
                new
                {
                    Id = (long)3,
                    EmailAddress = "dkucherina@healthwaresystems.com",
                    CountyCode = "1",
                    Cell = "9998789876",
                    ContactDetailsId = (long)6,
                    FirstName = "Dimitriy",
                    LastName = "Kucherina",
                    DateOfBirth = new DateTime(629833536000000000),
                    Gender = "Male",
                    MaritalStatus = "Single",
                    Password = PasswordEncryptionDecryption.HashPassword("Password@123"),
                    IsActive = true,
                    CanChangePassword = false,
                    IsTokenConsumed = false,
                    IsAuthenticated = false,
                    LoginOTPUpdatedTime = (DateTime?)(null),
                    SSNNumber = "212127766",
                    TenantId = "1",
                    SecondaryEmailContactDetailsId = (long)7,
                    CreatedDate = Constants.CreatedDateTime
                },
                new
                {
                    Id = (long)4,
                    EmailAddress = "psubbaraman@healthwaresystems.com",
                    CountyCode = "1",
                    Cell = "9998789876",
                    ContactDetailsId = (long)8,
                    FirstName = "Subba",
                    LastName = "Raman",
                    DateOfBirth = new DateTime(629833536000000000),
                    Gender = "Male",
                    MaritalStatus = "Single",
                    Password = PasswordEncryptionDecryption.HashPassword("Password@123"),
                    IsActive = true,
                    CanChangePassword = false,
                    IsTokenConsumed = false,
                    IsAuthenticated = false,
                    LoginOTPUpdatedTime = (DateTime?)(null),
                    SSNNumber = "212127788",
                    TenantId = "1",
                    SecondaryEmailContactDetailsId = (long)9,
                    CreatedDate = Constants.CreatedDateTime
                },
                new
                {
                    Id = (long)5,
                    EmailAddress = "jkunwar@healthwaresystems.com",
                    CountyCode = "1",
                    Cell = "9998789876",
                    ContactDetailsId = (long)10,
                    FirstName = "Jay",
                    LastName = "Kunwar",
                    DateOfBirth = new DateTime(629833536000000000),
                    Gender = "Male",
                    MaritalStatus = "Single",
                    Password = PasswordEncryptionDecryption.HashPassword("Password@123"),
                    IsActive = true,
                    CanChangePassword = false,
                    IsTokenConsumed = false,
                    IsAuthenticated = false,
                    LoginOTPUpdatedTime = (DateTime?)(null),
                    SSNNumber = "212127724",
                    TenantId = "1",
                    SecondaryEmailContactDetailsId = (long)11,
                    CreatedDate = Constants.CreatedDateTime
                },
                new
                {
                    Id = (long)6,
                    EmailAddress = "sgruner@healthwaresystems.com",
                    CountyCode = "1",
                    Cell = "9998789876",
                    ContactDetailsId = (long)12,
                    FirstName = "Stephen",
                    LastName = "Gruner",
                    DateOfBirth = new DateTime(629833536000000000),
                    Gender = "Male",
                    MaritalStatus = "Single",
                    Password = PasswordEncryptionDecryption.HashPassword("Password@123"),
                    IsActive = true,
                    CanChangePassword = false,
                    IsTokenConsumed = false,
                    IsAuthenticated = false,
                    LoginOTPUpdatedTime = (DateTime?)(null),
                    SSNNumber = "212126682",
                    TenantId = "1",
                    SecondaryEmailContactDetailsId = (long)13,
                    CreatedDate = Constants.CreatedDateTime
                },
                new
                {
                    Id = (long)7,
                    EmailAddress = "mynthan.k@zucisystems.com",
                    CountyCode = "1",
                    Cell = "9998789876",
                    ContactDetailsId = (long)14,
                    FirstName = "Mynthan",
                    LastName = "Kumar",
                    DateOfBirth = new DateTime(629833536000000000),
                    Gender = "Male",
                    MaritalStatus = "Single",
                    Password = PasswordEncryptionDecryption.HashPassword("Password@123"),
                    IsActive = true,
                    CanChangePassword = false,
                    IsTokenConsumed = false,
                    IsAuthenticated = false,
                    LoginOTPUpdatedTime = (DateTime?)(null),
                    SSNNumber = "215526682",
                    TenantId = "3",
                    SecondaryEmailContactDetailsId = (long)15,
                    CreatedDate = Constants.CreatedDateTime
                },
                new
                {
                    Id = (long)8,
                    EmailAddress = "uma.r@zucisystems.com",
                    CountyCode = "1",
                    Cell = "9998789876",
                    ContactDetailsId = (long)16,
                    FirstName = "Uma",
                    LastName = "Raja",
                    DateOfBirth = new DateTime(629833536000000000),
                    Gender = "Male",
                    MaritalStatus = "Married",
                    Password = PasswordEncryptionDecryption.HashPassword("Password@123"),
                    IsActive = true,
                    CanChangePassword = false,
                    IsTokenConsumed = false,
                    IsAuthenticated = false,
                    LoginOTPUpdatedTime = (DateTime?)(null),
                    SSNNumber = "215526999",
                    TenantId = "3",
                    SecondaryEmailContactDetailsId = (long)17,
                    CreatedDate = Constants.CreatedDateTime
                }
            );

            modelBuilder.Entity<Role>().HasData(
                new Role()
                {
                    Id = (long)1,
                    RoleName = Entities.Master.Roles.Patient.RoleName
                },
                new Role()
                {
                    Id = (long)2,
                    RoleName = Entities.Master.Roles.Advocate.RoleName
                }
            );
            var permissions = new List<Permission>();
            int count = 0;
            foreach (string name in Enum.GetNames(typeof(Permissions)))
            {
                count += 1;
                permissions.Add(new Permission()
                {
                    Id = count,
                    Name = name
                });
            }
            modelBuilder.Entity<Healthware.Core.Entities.Permission>().HasData(permissions);

            modelBuilder.Entity<UserHasRoles>().HasData(
                new
                {
                    Id = (long)1,
                    UserId = (long)1,
                    RoleId = (long)1
                },
                new
                {
                    Id = (long)2,
                    UserId = (long)2,
                    RoleId = (long)2
                },
                new
                {
                    Id = (long)3,
                    UserId = (long)3,
                    RoleId = (long)1
                },
                new
                {
                    Id = (long)4,
                    UserId = (long)4,
                    RoleId = (long)2
                },
                new
                {
                    Id = (long)5,
                    UserId = (long)5,
                    RoleId = (long)1
                },
                new
                {
                    Id = (long)6,
                    UserId = (long)6,
                    RoleId = (long)2
                },
                new
                {
                    Id = (long)7,
                    UserId = (long)7,
                    RoleId = (long)1
                },
                new
                {
                    Id = (long)8,
                    UserId = (long)8,
                    RoleId = (long)2
                }
            );

            modelBuilder.Entity<SubDomainMaster>().HasData(
                new SubDomainMaster
                {
                    Id = (long)1,
                    SubDomain = @"activeassist-qa.zucisystems.com:8090",
                    TenantId = "1"
                },
                new SubDomainMaster
                {
                    Id = (long)2,
                    SubDomain = @"localhost:4200",
                    TenantId = "2"
                },
                new SubDomainMaster
                {
                    Id = (long)3,
                    SubDomain = @"activeassist-pt.zucisystems.com:8080",
                    TenantId = "3"
                }
            );


            //Values for AddressTypeMaster table

            modelBuilder.Seed();

            modelBuilder.Entity<Entities.HouseHoldMemberIncome>().Property(x => x.GrossPay).HasPrecision(16, 2);
            modelBuilder.Entity<Entities.HouseHoldMemberIncome>().Property(x => x.CalculatedMonthlyIncome).HasPrecision(16, 2);
            modelBuilder.Entity<Entities.HouseHoldMemberResource>().Property(x => x.CalculatedValue).HasPrecision(16, 2);
            modelBuilder.Entity<Entities.HouseHoldMemberResource>().Property(x => x.CurrentMarketValue).HasPrecision(16, 2);
            modelBuilder.Entity<AssessmentSummaryResult>().HasNoKey();
            modelBuilder.Entity<AssessmentResult>().HasNoKey();
            modelBuilder.Entity<DashboardAssessment>().HasNoKey();
            modelBuilder.Entity<AssessmentInPatientDashboard>().HasNoKey();

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var tenantConnectionString = _tenantService.GetConnectionString();
            if (!string.IsNullOrEmpty(tenantConnectionString))
            {
                var dbProvider = _tenantService.GetDatabaseProvider();
                if (dbProvider.ToLower() == "mssql")
                {
                    optionsBuilder.UseSqlServer(_tenantService.GetConnectionString());
                }
            }
        }

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            foreach (var entry in ChangeTracker.Entries<ITenantInterface>().ToList())
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                    case EntityState.Modified:
                        entry.Entity.TenantId = TenantId;
                        break;
                }
            }
            var result = await base.SaveChangesAsync(cancellationToken);
            return result;
        }
    }
}
