namespace Healthware.Core.Constants
{
    public static class Application
    {
        /// <summary>
        /// Default pass phrase for SimpleStringCipher decrypt/encrypt operations
        /// </summary>
        public const string DefaultPassPhrase = "gsKxGZ012HLL3MI5";
        public const string EmailConfirmSubject = "Email Verification";
        public const string CreateUserSubject = "Create User";
        public const string ForgotPasswordEmailSubject = "Forgot Password Link for your Healthware ActiveASSIST Account";
        public const string ForgotPasswordEmailBodyThree = "Note that this link is valid for 24 hours. After 24 hours link will expire, then you need to resubmit a request for resetting your password.<br>";
        public const string NavigationLink = "Please Click Here";
        public const string PatientPortalAnnouncementUrl = "api/Announcements?system=PatientPortal";
        public const int AddOneDay = 1;
        public const string TimeFormat = "hh:mm:ss:tt";
        public const string FullDateTimeFormat = "f";
        public const string AppointmentStatusNew = "New";
        public const string ModifiedAppointmentStatus = "Yet to Accept";
        public const string AppointmentsbySpeciality = "Speciality";
        public const string AppointmentsbyStatus = "Status";
        public const string AppointmentsbyMonth = "Month";
        public const string AppointmentsbyPastMonths = "PastMonths";
        public const string AppointmentsbyYear = "Year";
        public const int GetYesterday = -1;
        public const string AppointmentActionUrl = "api/appointment/";
        public const string ActionSeen = "/Seen";
        public const string ActionAccepted = "/Accepted";
        public const string ActionRequestCancel = "/RequestCancel";
        public const string ActionRequestCancelPatient = "/RequestCancelPatient";
        public const string ActionRequestReschedule = "/RequestReschedule";
        public const string ActionRequestReschedulePatient = "/RequestReschedulePatient";
        public const string ActionReschedule = "/Reschedule";
        public const string ActionCancel = "/Cancel";
        public const string ActionUndo = "/Undo";
        public const string ClaimsMail = "http://ccube.zucisystems.com/identity/claims/Email";
        public const string ClaimsAssessmentId = "http://activeassist.zucisystems.com/identity/claims/AssessmentId";
        public const string ClaimsPatientId = "http://activeassist.zucisystems.com/identity/claims/PatientId";
        public const string MailTypeSetPassword = "SetPassword";
        public const string MailTypeEmailConfirmation = "EmailConfirmation";
        public const string MailTypeForgotPassword = "ForgotPassword";
        public const string MailTypeCreateUser = "CreateUser";
        public const string SetPasswordmessage = "Set Password link has been send to your mail. Please check your email to activate your account.";
        public const string ForgotPasswordmessage = "Mail sent successfully to the User for resetting the password.";
        public const string EmailTemplatePath = "//Templates//EmailTemplate//";
        public const string HtmlExtension = ".html";
        public const string JsonExtension = ".json";
        public const string MailNotExistsMessage = "Email Address does not exists";
        public const string InvalidEmailMessage = "Unable to send Email. Invalid email address";
        public const string StatusUpdateMessage = "Status changed successfully";
        public const string NotesUpdateMessage = "Notes updated successfully";
        public const string ObservationUpdateMessage = "Observations updated successfully";
        public const string ArchiveUsersSuccessMessage = "Archive Inactive Users Successfully";
        public const string ArchiveUsersFailureMessage = "Unable to Archive Inactive Users";
        public const string NoInactiveUsersMessage = "No Inactive Users";
        public const string MailTypeOTP = "OTP";
        public const string OTPLoginEmailSubject = "OTP for your Healthware ActiveASSIST sign-in";
        public const string GenderJsonPath = "//Dropdowns//";
        public const string MonthDayYear = "MM/dd/yyyy";
        public const string Citizenship = "U.S. Citizen";

        public const string Success = "SUCCESS";
        public const string UpdateGuarantorSuccess = "Guarantor updated successfully.";
        public const string AssessmentDeleteSuccess = "Assessment deleted successfully.";
        public const string UpdateUserSuccess = "User updated successfully.";
        public const string UpdateContactDetailsSuccess = "Address details updated successfully.";
        public const string UpdatePasswordSuccess = "Your Password has been changed successfully.";
        public const string CreateContactPreferenceSuccess = "Contact preference saved successfully";
        public const string CreateContactDetailsSuccess = "Address saved successfully";
        public const string DeleteContactDetailsSuccess = "Address deleted successfully";
        public const string DeletedHouseholdMemberSuccess = "Household Member deleted successfully";
        public const string AddReviewNotesSuccess = "Review notes added successfully";

        public const string UpdatePatientFailed = "Could not update Patient.";
        public const string UpdateUserFailed = "Could not update User.";
        public const string AssessmentStatusUpdated = "Assessment Status updated.";
        public const string OTPValidationSuccess = "OTP validation success.";

        public const string GuarantorExists = "Guarantor exists for the assessment.";
        public const string InsertGuarantorFailed = "Could not insert Guarantor.";

        //Authentication
        public const string OTPSuccess = "OTP sent successfully.";
        public const string LogoutSuccess = "User logged out successfully.";

        public const string SelfRelation = "Self";
        public const string VerificationEmailSent = "Please check your email to activate your account.";

        public const string AdminNotification = "AdminNotification";
        public const string BasicInfo = "BasicInfo";

        //Controller Actions
        public const string GetAdvocatePatientsNames = "GetAdvocatePatientsNames";
        public const string GetAdvocatePatient = "GetAdvocatePatient";
        public const string getDynamicQuestions = "GetDynamicQuestions";

        //Table Names
        public const string ReviewNotes = "ReviewNotes";

        public const string UserCreationSuccess = "New User created.";
        public const string MockData = "MockData";
        public const string MockService = "MockService";
        public const string BaseUrl = "EDRMService:BaseUrl";
        public const string AdminEmailNotification = "AdminEmailNotification";
        public const string IsOTPEnabled = "IsOTPEnabled";
        public const string IsEstimatedVisitCostEnabled = "IsEstimatedVisitCostEnabled";
        public const string BypassVerification = "BypassVerification";

        /// <summary>
        /// The claim name holding the packed permission string
        /// </summary>
        public const string PackedPermissionClaimType = "Permissions";
        /// <summary>
        /// The claim name holding the optional DataKey
        /// </summary>
        public const string DataKeyClaimType = "DataKey";

        /// <summary>
        /// This is the char for the AccessAll permission
        /// </summary>
        public const char PackedAccessAllPermission = (char)ushort.MaxValue;
        public const string SessionId = "SessionID";
    }
}
