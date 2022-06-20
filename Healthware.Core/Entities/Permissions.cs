using System.ComponentModel.DataAnnotations;

//Todo:Remove from Core
namespace Healthware.Core.Entities
{
    public enum Permissions : ushort
    {
        [Display(GroupName = "Address", Name = "View", Description = "Can read Address")]
        ViewAddress = 0x10,
        [Display(GroupName = "Address", Name = "Create", Description = "Can create a Address entry")]
        CreateAddress = 0x11,
        [Display(GroupName = "Address", Name = "Update", Description = "Can update a Address entry")]
        UpdateAddress = 0x12,
        [Display(GroupName = "Address", Name = "Delete", Description = "Can delete a Address entry")]
        DeleteAddress = 0x13,

        [Display(GroupName = "Admin", Name = "View users", Description = "Can list User")]
        ViewUser = 0x20,
        //This is an example of grouping multiple actions under one permission
        [Display(GroupName = "Admin", Name = "Alter user", Description = "Can do anything to the User")]
        UpdateUser = 0x21,

        //Dashboard details
        [Display(GroupName = "Dashboard", Name = "View", Description = "Can read dashboard details")]
        ViewPatientDashboard = 0x30,
        [Display(GroupName = "Dashboard", Name = "View", Description = "Can read dashboard details")]
        ViewAdvocateDashboard = 0x31,
        [Display(GroupName = "Dashboard", Name = "AssessmentSummaryView", Description = "Can read assessment summary")]
        ViewComponentAssessmentSummary = 0x31,
        [Display(GroupName = "Dashboard", Name = "AssessmentSummaryView", Description = "Can view dashboard information")]
        ViewDashboardInfo = 0x32,

        //Review Notes
        [Display(GroupName = "ReviewNotes", Name = "View", Description = "Can read review notes")]
        ViewReviewNotes = 0x40,
        [Display(GroupName = "ReviewNotes", Name = "Create", Description = "Can create a review note")]
        CreateReviewNotes = 0x41,

        //Patient details
        [Display(GroupName = "Patient", Name = "View", Description = "Can read a patient")]
        ViewPatient = 0x50,
        [Display(GroupName = "Patient", Name = "Create", Description = "Can create a patient")]
        CreatePatient = 0x51,
        [Display(GroupName = "Patient", Name = "Update", Description = "Can update a patient")]
        UpdatePatient = 0x52,

        //Guarantor details
        [Display(GroupName = "Guarantor", Name = "View", Description = "Can read a Guarantor")]
        ViewGuarantor = 0x60,
        [Display(GroupName = "Guarantor", Name = "Create", Description = "Can create a Guarantor")]
        CreateGuarantor = 0x61,
        [Display(GroupName = "Guarantor", Name = "Update", Description = "Can update a Guarantor")]
        UpdateGuarantor = 0x62,

        //Contact preference details
        [Display(GroupName = "ContactPreference", Name = "View", Description = "Can read a Contact preference")]
        ViewContactPreference = 0x70,
        [Display(GroupName = "ContactPreference", Name = "Create", Description = "Can create a Contact preference")]
        CreateContactPreference = 0x71,
        [Display(GroupName = "ContactPreference", Name = "Update", Description = "Can update a Contact preference")]
        UpdateContactPreference = 0x72,

        //Assessment
        [Display(GroupName = "Assessment", Name = "Create", Description = "Can read a Assessment")]
        CreateAssessmentByAdvocate = 0x73,

        //Assessment
        [Display(GroupName = "Assessment", Name = "View", Description = "Can read a Assessment")]
        ViewAssessment = 0x80,
        [Display(GroupName = "Assessment", Name = "Create", Description = "Can create a Assessment")]
        CreateAssessment = 0x81,
        [Display(GroupName = "Assessment", Name = "Update", Description = "Can update a Assessment")]
        UpdateAssessment = 0x82,
        [Display(GroupName = "Assessment", Name = "Delete", Description = "Can update a Assessment")]
        DeleteAssessment = 0x83,

        //Account
        [Display(GroupName = "Account", Name = "Create", Description = "Can create an account")]
        CreateAccount = 0x84,
        [Display(GroupName = "Account", Name = "View", Description = "Can view an account")]
        ViewAccount = 0x85,

        //Programs
        [Display(GroupName = "Program", Name = "View", Description = "Can view a Program")]
        ViewProgram = 0x86,
        [Display(GroupName = "Program", Name = "Create", Description = "Can Create a Program")]
        CreateProgram = 0x87,
        [Display(GroupName = "Program", Name = "Delete", Description = "Can Delete a Program")]
        DeleteProgram = 0x88,
        [Display(GroupName = "Program", Name = "Update", Description = "Can Update a Program")]
        UpdateProgram = 0x88,

        //Profile
        [Display(GroupName = "Profile", Name = "Update", Description = "Can Update a Profile")]
        UpdateProfile = 0x89,
        [Display(GroupName = "Profile", Name = "View", Description = "Can view a Profile")]
        ViewProfile = 0x90,
        [Display(GroupName = "Profile", Name = "Create", Description = "Can Create a Profile")]
        CreateProfile = 0x91,
        [Display(GroupName = "Profile", Name = "Delete", Description = "Can Delete a Profile")]
        DeleteProfile = 0x92,

        [Display(GroupName = "SSN", Name = "View", Description = "Can view SSN page")]
        ViewPatientSSN = 0x93,
        [Display(GroupName = "Payment", Name = "View", Description = "Can view Payment option")]
        ViewPaymentOptions = 0x94,

        [Display(GroupName = "GeneralInformation", Name = "View", Description = "Can view General Information")]
        ViewGeneralInformation = 0x95,

        [Display(GroupName = "QuickAssessment", Name = "View", Description = "Can view Insurance Coverage")]
        ViewInsuranceCoverage = 0x96,
        [Display(GroupName = "QuickAssessment", Name = "View", Description = "Can view Patient Demographics")]
        ViewPatientDemographics = 0x97,
        [Display(GroupName = "QuickAssessment", Name = "View", Description = "Can view Citizenship Status")]
        ViewCitizenshipStatus = 0x98,
        [Display(GroupName = "QuickAssessment", Name = "View", Description = "Can view Residential Information")]
        ViewResidentialInformation = 0x99,
        [Display(GroupName = "QuickAssessment", Name = "View", Description = "Can view HouseHold Member")]
        ViewHouseHoldMember = 0x100,
        [Display(GroupName = "QuickAssessment", Name = "View", Description = "Can view Household Income Resource")]
        ViewHouseholdIncomeResource = 0x101,
        [Display(GroupName = "QuickAssessment", Name = "Create", Description = "Can create quick assessment")]
        AdvocateQuickAssessment = 0x102,
        [Display(GroupName = "QuickAssessment", Name = "Create", Description = "Can create patient quick assessment")]
        CreateDynamicAssessment = 0x103,
        [Display(GroupName = "PatientAccount", Name = "Create", Description = "Can create patient account")]
        CreatePatientAccount = 0x104,

        [Display(GroupName = "DashboardInfo", Name = "View", Description = "Can view quick assessment component")]
        ViewComponentQuickAssessment = 0x105,
        [Display(GroupName = "DashboardInfo", Name = "View", Description = "Can view Personal component")]
        ViewComponentPersonal = 0x106,
        [Display(GroupName = "DashboardInfo", Name = "View", Description = "Can view Guarantor component")]
        ViewComponentGuarantor = 0x107,
        [Display(GroupName = "DashboardInfo", Name = "View", Description = "Can view Contact Preference component")]
        ViewComponentContactPreference = 0x108,
        [Display(GroupName = "DashboardInfo", Name = "View", Description = "Can view HouseHold component")]
        ViewComponentHouseHold = 0x109,
        [Display(GroupName = "DashboardInfo", Name = "View", Description = "Can view Programs component")]
        ViewComponentPrograms = 0x110,
        [Display(GroupName = "DashboardInfo", Name = "View", Description = "Can view Forms component")]
        ViewComponentForms = 0x111,
        [Display(GroupName = "DashboardInfo", Name = "View", Description = "Can view Verification component")]
        ViewComponentVerification = 0x112,
        [Display(GroupName = "DashboardInfo", Name = "View", Description = "Can view Application Forms component")]
        ViewComponentApplicationForms = 0x113,

        [Display(GroupName = "DashboardTabs", Name = "View", Description = "Can view Personal Basic Info tab")]
        ViewComponentPersonalBasicInfo = 0x114,
        [Display(GroupName = "DashboardTabs", Name = "View", Description = "Can view Personal Home Address tab")]
        ViewComponentPersonalHomeAddress = 0x115,
        [Display(GroupName = "DashboardTabs", Name = "View", Description = "Can view Personal Work Address tab")]
        ViewComponentPersonalWorkAddress = 0x116,
        [Display(GroupName = "DashboardTabs", Name = "View", Description = "Can view Guarantor Basic Info tab")]
        ViewComponentGuarantorBasicInfo = 0x117,
        [Display(GroupName = "DashboardTabs", Name = "View", Description = "Can view Guarantor Home Address tab")]
        ViewComponentGuarantorHomeAddress = 0x118,
        [Display(GroupName = "DashboardTabs", Name = "View", Description = "Can view Guarantor Work Address tab")]
        ViewComponentGuarantorWorkAddress = 0x119,
        [Display(GroupName = "DashboardTabs", Name = "View", Description = "Can view HouseHold MemberList tab")]
        ViewComponentHouseHoldMemberList = 0x120,
        [Display(GroupName = "DashboardTabs", Name = "View", Description = "Can view Edit HouseHold Member tab")]
        ViewComponentEditHouseHoldMember = 0x121,
        [Display(GroupName = "DashboardTabs", Name = "View", Description = "Can view Programs Information tab")]
        ViewProgramsInformation = 0x122,
        [Display(GroupName = "DashboardTabs", Name = "View", Description = "Can view Component Review Notes tab")]
        ViewComponentReviewNotes = 0x123,
        [Display(GroupName = "DashboardTabs", Name = "View", Description = "Can view Email Verification tab")]
        ViewComponentEmailVerification = 0x124,
        [Display(GroupName = "DashboardTabs", Name = "View", Description = "Can view Cell Verification tab")]
        ViewComponentCellVerification = 0x125,
        [Display(GroupName = "DashboardTabs", Name = "View", Description = "Can view Id Verification tab")]
        ViewComponentIdVerification = 0x126,
        [Display(GroupName = "DashboardTabs", Name = "View", Description = "Can view Address Verification tab")]
        ViewComponentAddressVerification = 0x127,
        [Display(GroupName = "DashboardTabs", Name = "View", Description = "Can view Income Verification tab")]
        ViewComponentIncomeVerification = 0x128,
        [Display(GroupName = "DashboardTabs", Name = "View", Description = "Can view Other Documentation tab")]
        ViewComponentOtherDocumentation = 0x129,

        [Display(GroupName = "QuickAssessmentResult", Name = "Edit", Description = "Can edit quick assessment component")]
        EditQuickAssessmentResult = 0x130,

        [Display(GroupName = "Assessment", Name = "View", Description = "Can view esign option in Assessment")]
        ViewEsignAssessment = 0x131,
        [Display(GroupName = "Assessment", Name = "Assessment", Description = "Can view share option in assessment")]
        ViewShareAssessment = 0x132,
        [Display(GroupName = "Assessment", Name = "Assessment", Description = "Can view download option in assessment")]
        ViewDownloadAssessment = 0x133,
        [Display(GroupName = "Assessment", Name = "Assessment", Description = "Can view upload option in assessment")]
        ViewUploadAssessment = 0x134,
        [Display(GroupName = "Themes", Name = "Edit", Description = "Can edit theme")]
        EditTheme = 0x135,
        [Display(GroupName = "Profile", Name = "Edit", Description = "Can update Password")]
        UpdatePassword = 0x136,
        [Display(GroupName = "Assessment", Name = "Submit", Description = "Can submit assessment")]
        ViewComponentApplicationCompleted = 0x137
    }
}
