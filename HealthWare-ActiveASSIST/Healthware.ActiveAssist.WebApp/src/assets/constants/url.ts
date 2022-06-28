import { environment } from 'src/environments/environment';

// config all the rest api url required
export class ApiConstants {
    public static url = {

        BaseUrl: environment.apiBaseUrl,
        /*auth*/
        EmailToken: "api/Verification/ValidateEmailConfirmationToken/",
        Login: "api/Login",
        Otp: "api/Login/SendOTP",
        ValidateOtp: "api/Login/ValidateOTP",
        ResetPassword: "api/Login/UpdateNewPassword",
        ChangePassword: "api/Login/ChangePassword",
        ForgotPassword: "api/Login/ForgotMyPassword",
        LoginWithoutOtp: "api/Login/LoginWithoutOTP",
        Logout: "api/Login/Logout",
        /*Dashboard details*/
        Dashboard: "api/Dashboard/GetDashboardDetails",
        DeleteDashboard: 'api/Assessment/DeleteAssessment',
        /*Basic Info*/
        DashboardBasicInfo: "api/Assessment/GetPatientById",
        DashboardUpdatePersonalDetail: "api/Assessment/UpdatePersonalDetail",
        /*Address Info*/
        DashboardVerifyAddress: "api/UserManagement/VerifyAddressDetails",
        DashboardAddressInfo: "api/Assessment/GetContactDetails",
        DashboardAddAddress: "api/Assessment/InsertContactDetails",
        DashboardUpdateAddress: "api/Assessment/UpdateContactDetails",
        DeleteWorkAddress: "api/Assessment/DeleteContactDetails",
        /*Guarantor Info*/
        DashboardGetGuarantorInfo: "api/Assessment/GetGuarantorByAssessmentId",
        DashboardAddGuarantorInfo: "api/Assessment/CreateGuarantor",
        DashboardUpdateGuarantorInfo: "api/Assessment/UpdateGuarantor",
        /*Household */
        DashboardGetHouseholdInfo: "api/HouseHold/GetHouseHoldMembersList",
        DashboardCreateHouseHoldMember: "api/HouseHold/CreateHouseHoldMember",
        DashboardUpdateHouseHoldMemberBasicInfo: "api/HouseHold/UpdateHouseHoldMember",
        DashboardUpdateHouseHoldMemberIncomeInfo: "api/HouseHold/UpdateHouseHoldIncome",
        DashboardUpdateHouseHoldMemberResourceInfo: "api/HouseHold/UpdateHouseHoldResource",
        DashboardGetHouseHoldMemberDetails: "api/HouseHold/GetHouseHoldMemberById",
        DashboardGetHouseHoldMemberIncomeDetails: "api/HouseHold/GetHouseHoldIncomeById",
        DashboardGetHouseHoldResourceDetails: "api/HouseHold/GetHouseHoldResourceById",
        DashboardCreateHouseHoldIncome: "api/HouseHold/CreateHouseHoldIncome",
        DashboardCreateHouseHoldResource: "api/HouseHold/CreateHouseHoldResource",
        DashboardDeleteIncome: "api/HouseHold/DeleteHouseHoldIncome",
        DashboardDeleteResource: "api/HouseHold/DeleteHouseHoldResource",
        DashboardDeleteHouseholdMember: "api/HouseHold/DeleteHouseHoldMember",
        GetIncomeResourceAmount:"api/HouseHold/GetIncomeResourcesAmount",
        /*DropDown*/
        Gender: "api/DropDown/GetGenderValues",
        Relatioship: "api/DropDown/GetRelationshipToPatient",
        Marital: "api/DropDown/GetMaritalStatus",
        Income: "api/DropDown/GetIncomeType",
        IcomeCurrentStatus: "api/DropDown/GetIncomeTypeCurrentStatus",
        Verification: "api/DropDown/GetVerification",
        GrossPayPeriod: "api/DropDown/GetPayPeriod",
        Resource: "api/DropDown/GetResourceType",
        ResourceCurrentStatus: "api/DropDown/GetResourceTypeCurrentStatus",
        /*FileUpload*/
        ProfileImageUpload: "api/FileUpload/UploadFile",
        ProfileImageDownload: "api/FileUpload/LoadProfileImage?Email=",
        AssessmentProfileImageUpload: "api/FileUpload/UploadAssessmentProfileImage?AssmtId=",
        AssessmentProfileImageDownload: "api/FileUpload/GetAssessmentProfileImage?AssmtId=",
        UserProfileImageUpload: "api/FileUpload/UploadUserProfileImage?userId=",
        UserProfileImageDownload: "api/FileUpload/GetUserProfileImage?userId=",
        UploadFile: "api/FileUpload/UploadFile",
        UploadSignature: "api/FileUpload/UploadSignature",
        CompleteUploadedDocument: "api/FileUpload/CompleteUploadedDocument",
        GetIDVerificationFileDetail: "api/FileUpload/GetIDVerificationFileDetail?AssmtId=",
        GetOtherVerificationFileDetail: "api/FileUpload/GetOtherVerificationFileDetail?AssmtId=",
        GetAddressVerificationFileDetail: "api/FileUpload/GetAddressVerificationFileDetail?AssmtId=",
        GetIncomeVerificationFileDetail: "api/FileUpload/GetIncomeVerificationFileDetail?AssmtId=",
        DeleteDocument: "api/FileUpload/DeleteDocument",
        GetProgramDocumentDownloadUrl: "api/FileUpload/PreviewProgramDocument?PgrmdocId=",
        GetProgramDocumentDetails: "api/FileUpload/GetProgramDocumentDetails",
        PreviewDocument: "api/FileUpload/PreviewDocument?DocId=",
        GetDocumentByAssessmentIdTypeName: "api/FileUpload/GetDocumentByAssessmentIdTypeName",
        UpdateVerificationDocument: "api/FileUpload/UpdateVerificationDocument",
        GetAssessmentProgramDocument : "api/FileUpload/GetAssessmentProgramDocument",
        UpdateDocumentPathByID : "api/FileUpload/UpdateFilePath",

        /*Verification*/
        EmailVerification: "api/Verification/SendEmailVerification",
        ValidateEmailToken: "api/Verification/ValidateEmailConfirmationToken",
        CellVerification: "api/Verification/SendOTPToCell",
        ValidateCellVerification: "api/Verification/ValidateCellVerificationOTP",
        GetVerificationStatus: "api/Verification/GetVerificationStatus",
        /*Submit Application*/
        SubmitApplication: "api/Assessment/UpdateAssessmentStatus",
        /*Quick Assessment Result*/
        GetHouseHoldMemberNames: "api/Verification/GetHouseHoldMemberNames",
        UpdatePatientReviewPrograms: "api/Assessment/UpdatePatientReviewPrograms",
        GetActiveReviewPrograms: "api/Assessment/GetActiveReviewPrograms",
        GetNotEvaluatedActiveReviewPrograms: "api/Assessment/GetNotEvaluatedActiveReviewPrograms",
        GetAllReviewPrograms: "api/Assessment/GetAllReviewPrograms",
        GetEFormData: "api/Assessment/GetEFormData",
        GetEvaluatedReviewPrograms: "api/Assessment/GetEvaluatedPrograms",
        EvaluateAssessment: "api/Assessment/EvaluateAssessment",
        /*Contact Preference */
        GetPreferredCell: "api/Assessment/GetPreferredCell",
        GetPreferredAddress: "api/Assessment/GetPreferredAddress",
        GetPreferredEmail: "api/Assessment/GetPreferredEmail",
        SaveContactPreference: "api/Assessment/CreateContactPreference",
        GetContactPreference: "api/Assessment/GetContactPreference",
        UpdateContactPreference: "api/Assessment/UpdateContactPreference",
        /*Quick Assessment*/
        GetDynamicAssessmentData: "api/QuickAssessment/GetQuickAssessmentData",
        updateAssessmentDetails: "api/QuickAssessment/CreateNewAssessment",
        GetStateAndCity: "api/QuickAssessment/GetStateAndCounty",
        GetSelfDetails: "api/QuickAssessment/GetSelfDetails",
        GetPatientSelfDetails: "api/QuickAssessment/GetAdvocatePatient",
        ValidatePolicyNumber: "api/QuickAssessment/ValidatePolicyNumber",
        UserNameExists: "api/QuickAssessment/IsUserNameExists",
        UserInfo: "api/QuickAssessment/GetUserNameInfo",
        GetDynamicQuestions: "api/QuickAssessment/GetDynamicQuestions",
        SavePartialAssessment: "api/QuickAssessment/SavePartialAssessment",
        UpdatePartialAssessment: "api/QuickAssessment/UpdatePartialAssessment",
        GetPartialAssessment: "api/QuickAssessment/GetPartialAssessment",
        DeletePartialAssessment: "api/QuickAssessment/DeletePartialAssessment",
        GetTenantBySubDomain:'api/SubDomain/GetTenantBySubDomain',
        GetPasswordPolicy:'api/SubDomain/GetPasswordPolicyBySubDomain',
        /* Advocate Dashboard*/
        AdvocateDashboard: "api/Dashboard/GetAdvocateDashboardDetails",
        CreateAssessment: "api/QuickAssessment/GetAdvocatePatientsNames",
        AdvocateSummaryPanel: "api/Dashboard/GetAssessmentSummary",
        AddReviewNotes: "api/Assessment/AddReviewNotes",
        GetReviewNotes: "api/Assessment/GetReviewNotes",
        /*Check already existing Email*/
        CheckEmailStatus: "api/QuickAssessment/IsUserNameExists",
        /*User Management*/
        CreateUserProfile: "api/UserManagement/CreateUserProfile",
        UpdateProfileDetails: "api/UserManagement/UpdateProfileDetails",
        GetProfileDetails: "api/UserManagement/GetProfileDetails",
        AddMorePrograms: "api/Assessment/GetPrograms",
        UpdateQuickAssessmentPrograms: "api/Assessment/CreatePatientProgramMapping",
        //Tab Status Completion!
        TabStatus: "api/Assessment/GetTabCompletionStatus",
        /* Permission Management */
        GetUserPermissions: "api/UserManagement/GetPermissionsForUser",
        /*User Verification*/
        GetUserDetails: "GetUserDetails",
        updateUserDetails:"CreateUserDetails",
        createProgramMapping: "api/Assessment/CreateProgramMapping",
        /*Reason No SSN*/
        GetReasonNoSSN:"api/DropDown/GetReasonNoSSN",
        ValidateUserAccount:"api/UserManagement/ValidateUserAccount"
    };
}
