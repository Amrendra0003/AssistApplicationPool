namespace HealthWare.ActiveASSIST.WebAPI
{
    public static class Constants
    {
        public static string AssessmentId = "AssessmentId";
        public static string UserId = "UserId";
        public static string HouseHoldMemberId = "HouseHoldMemberId";
        public static string ProgramId = "ProgramId";
        public static string DocumentTitle = "DocumentTitle";
        public static string Esign = "Esigned";
        public static string DocumentCategory = "DocumentCategory";
        public static string DocumentType = "DocumentType";
        public static string ProgramDocumentId = "ProgramDocumentId";
        public static string DocumentId = "DocumentId";
        public static string SignatureText = "SignatureText";
        public static string SignatureCanvas = "SignatureCanvas";
        public static string File = "File";

        public const string JwtBearer = "JwtBearer";
        public const string createUser = "CreateUser";
        public const string GetUserDetails = "GetUserDetails";
        public const string CreateUserDetails = "CreateUserDetails";
        public const string UpdateUserDetails = "UpdateUserDetails";


        #region ActionMethodNames
        //Assessment Controller
        public const string GetPatientById = "GetPatientById";
        public const string UpdatePersonalDetail = "UpdatePersonalDetail";
        public const string GetContactDetails = "GetContactDetails";
        public const string InsertContactDetails = "InsertContactDetails";
        public const string UpdateContactDetails = "UpdateContactDetails";
        public const string DeleteContactDetails = "DeleteContactDetails";
        public const string GetGuarantorByAssessmentId = "GetGuarantorByAssessmentId";
        public const string CreateGuarantor = "CreateGuarantor";
        public const string UpdateGuarantor = "UpdateGuarantor";
        public const string SendEmailVerification = "SendEmailVerification";
        public const string ValidateCellVerificationOtp = "ValidateCellVerificationOTP";
        public const string GetHouseHoldMemberNames = "GetHouseHoldMemberNames";
        public const string UpdatePatientReviewPrograms = "UpdatePatientReviewPrograms";
        public const string GetActiveReviewPrograms = "GetActiveReviewPrograms";
        public const string GetAllReviewPrograms = "GetAllReviewPrograms";
        public const string GetNotEvaluatedActiveReviewPrograms = "GetNotEvaluatedActiveReviewPrograms";
        public const string GetVerificationStatus = "GetVerificationStatus";
        public const string GetEFormData = "GetEFormData";
        public const string GetPreferredCell = "GetPreferredCell";
        public const string GetPreferredEmail = "GetPreferredEmail";
        public const string GetPreferredAddress = "GetPreferredAddress";
        public const string CreateContactPreference = "CreateContactPreference";
        public const string UpdateContactPreference = "UpdateContactPreference";
        public const string GetContactPreference = "GetContactPreference";
        public const string UpdateAssessmentStatus = "UpdateAssessmentStatus";
        public const string DeleteAssessment = "DeleteAssessment";
        public const string AddReviewNotes = "AddReviewNotes";
        public const string GetReviewNotes = "GetReviewNotes";
        public const string GetPrograms = "GetPrograms";
        public const string CreatePatientProgramMapping = "CreatePatientProgramMapping";
        public const string CreateProgramMapping = "CreateProgramMapping";
        public const string GetPatientProgram = "GetPatientProgram";
        public const string GetTabCompletionStatus = "GetTabCompletionStatus";
        public const string EvaluateAssessment = "EvaluateAssessment";
        public const string GetEvaluatedPrograms = "GetEvaluatedPrograms";
        public const string ValidateEmailConfirmationToken = "ValidateEmailConfirmationToken";
        public const string SendOtpToCell = "SendOtpToCell";

        //DashboardController
        public const string GetDashboardDetails = "GetDashboardDetails";
        public const string GetAdvocateDashboardDetails = "GetAdvocateDashboardDetails";
        public const string GetAssessmentSummary = "GetAssessmentSummary";
        public const string GetEstimatedCostForVisit = "GetEstimatedCostForVisit";

        //DropDownController
        public const string GetGenderValues = "GetGenderValues";
        public const string GetMaritalStatus = "GetMaritalStatus";
        public const string GetRelationshipToPatient = "GetRelationshipToPatient";
        public const string GetIncomeType = "GetIncomeType";
        public const string GetIncomeTypeCurrentStatus = "GetIncomeTypeCurrentStatus";
        public const string GetPayPeriod = "GetPayPeriod";
        public const string GetResourceType = "GetResourceType";
        public const string GetResourceTypeCurrentStatus = "GetResourceTypeCurrentStatus";
        public const string GetVerification = "GetVerification";
        public const string GetReasonNoSSN = "GetReasonNoSSN";

        //FileUploadController
        public const string UploadAssessmentProfileImage = "UploadAssessmentProfileImage";
        public const string UploadUserProfileImage = "UploadUserProfileImage";
        public const string GetAssessmentProfileImage = "GetAssessmentProfileImage";
        public const string GetUserProfileImage = "GetUserProfileImage";
        public const string DeleteDocument = "DeleteDocument";
        public const string GetIncomeVerificationFileDetail = "GetIncomeVerificationFileDetail";
        public const string UploadFile = "UploadFile";
        public const string GetIDVerificationFileDetail = "GetIDVerificationFileDetail";
        public const string GetAddressVerificationFileDetail = "GetAddressVerificationFileDetail";
        public const string GetOtherVerificationFileDetail = "GetOtherVerificationFileDetail";
        public const string PreviewDocument = "PreviewDocument";
        public const string PreviewProgramDocument = "PreviewProgramDocument";
        public const string DownloadProgramDocument = "DownloadProgramDocument";
        public const string GetProgramDocumentDetails = "GetProgramDocumentDetails";
        public const string GetDocumentByAssessmentIdTypeName = "GetDocumentByAssessmentIdTypeName";
        public const string UpdateVerificationDocument = "UpdateVerificationDocument";
        public const string UpdateFilePath = "UpdateFilePath";
        public const string UploadSignature = "UploadSignature";
        public const string CompleteUploadedDocument = "CompleteUploadedDocument"; 

        //HouseHoldController
        public const string CreateHouseHoldMember = "CreateHouseHoldMember";
        public const string GetHouseHoldMembersList = "GetHouseHoldMembersList";
        public const string GetHouseHoldMemberById = "GetHouseHoldMemberById";
        public const string DeleteHouseHoldMember = "DeleteHouseHoldMember";
        public const string GetIncomeResourcesAmount = "GetIncomeResourcesAmount";

        //LoginController
        public const string LoginWithoutOTP = "LoginWithoutOTP";
        public const string SendOTP = "SendOTP";
        public const string ValidateOTP = "ValidateOTP";
        public const string ForgotMyPassword = "ForgotMyPassword";
        public const string UpdateNewPassword = "UpdateNewPassword";
        public const string ChangePassword = "ChangePassword";
        public const string IsSessionActive = "IsSessionActive";
        public const string Logout = "Logout";

        //QuickAssessmentController
        public const string GetQuickAssessmentData = "GetQuickAssessmentData";
        public const string GetQuickAssessmentDataByAssessmentId = "GetQuickAssessmentDataByAssessmentId";
        public const string CreateNewAssessment = "CreateNewAssessment";
        public const string SavePartialAssessment = "SavePartialAssessment";
        public const string GetPartialAssessment = "GetPartialAssessment";
        public const string UpdatePartialAssessment = "UpdatePartialAssessment";
        public const string DeletePartialAssessment = "DeletePartialAssessment";
        public const string GetStateAndCounty = "GetStateAndCounty";
        public const string GetSelfDetails = "GetSelfDetails";
        public const string ValidatePolicyNumber = "ValidatePolicyNumber";
        public const string IsUserNameExists = "IsUserNameExists";
        public const string GetUserNameInfo = "GetUserNameInfo";

        //UserManagementController
        public const string GetProfileDetails = "GetProfileDetails";
        public const string UpdateProfileDetails = "UpdateProfileDetails";
        public const string CreateUserProfile = "CreateUserProfile";
        public const string VerifyAddressDetails = "VerifyAddressDetails";

        //SubDomainController
        public const string GetTenantBySubDomain = "GetTenantBySubDomain";
        public const string GetPasswordPolicyBySubDomain = "GetPasswordPolicyBySubDomain";
        
        //TenantDataController
        public const string UpdateMappingTables = "UpdateMappingTables";

        //Regex
        public const string FirstName = "^[a-zA-Z]+$";
        //public const string FirstName = "UpdateMappingTables";
        //public const string FirstName = "UpdateMappingTables";
        //public const string FirstName = "UpdateMappingTables";
        //public const string FirstName = "UpdateMappingTables";
        //public const string FirstName = "UpdateMappingTables";
        #endregion
    }
}
