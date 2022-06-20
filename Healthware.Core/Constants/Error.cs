namespace Healthware.Core.Constants
{
    public static class Error
    {
        public const string HasActiveSession = "User already has an active session.";
        public const string DoesNotHaveActiveSession = "User does not an active session.";
        public const string LastLoggedInDateError = "Could not able to read last logged in date.";

        public const string LogoutFailure = "Could not find the active user.";
        public const string NotFound = "Not Found";
        public const string UnableUpdate = "Unable to Update";
        public const string AssessmentDeleteFailed = "Failed to delete Assessment.";
        public const string AssessmentUpdateFailed = "Failed to update Assessment.";
        public const string UpdateGuarantorFailed = "Failed to update Guarantor.";
        public const string UpdateAssessmentVerificationFailed = "Failed to update Assessment verification.";
        public const string UpdateContactDetailsFailed = "Failed to update Address.";
        public const string EvaluationFailed = "Failed to evaluate the assessment details.";
        public const string UpdatePasswordFailed = "Failed to update password.";
        public const string UpdateCanChangePasswordFailed = "Failed to update CanChangePassword.";
        public const string UpdateCellNumberFailed = "Failed to update CellNumberConfirmed.";
        public const string CreateContactPreferenceFailed = "Failed to create contact preference.";
        public const string UpdateHouseholdMemberFailed = "Failed to update Household member.";
        public const string CreateContactDetailsFailed = "Failed to create address.";
        public const string GuarantorCreateContactDetailsFailed = "Failed to create guarantor address.";
        public const string DeleteDocumentFailed = "Failed to delete document.";
        public const string DeletePatientDocumentFailed = "Failed to delete patient document.";
        public const string DeleteContactDetailsFailed = "Failed to delete address.";
        public const string DeleteHouseholdIncomeFailed = "Failed to delete Household Income.";
        public const string DeleteHouseholdResourceFailed = "Failed to delete Household Resource.";
        public const string DeleteHouseholdMemberFailed = "Failed to delete Household Member.";
        public const string CreateReviewNotesFailed = "Failed to add Review notes.";
        public const string UpdateUserFailed = "Failed to update user.";

        public const string ContactPreferenceAlreadyExists = "Contact preference already exists for assessment ID.";

        //Invalid Request
        public const string InvalidLogin = "Invalid username or password.";
        public const string InvalidRequest = "Invalid request.";

        //Emails and Token
        public const string FailedToSendOTP = "Couldn't send OTP. Please contact Administrator.";
        public const string FailedToSaveToken = "Error saving token in database.";
        public const string InvalidOTP = "Invalid OTP.";
        public const string InvalidToken = "Invalid token.";
        public const string TokenExpired = "Token has expired.";
        public const string EmailVerified = "Email already verified.";
        public const string CellNumberVerified = "Cell number already verified.";

        //Not found
        public const string PatientNotFound = "Patient not found.";
        public const string UserNotFound = "User not found.";
        public const string GuarantorNotFound = "Guarantor not found.";
        public const string AssessmentNotFound = "Assessment not found.";
        public const string AssessmentVerificationNotFound = "Assessment Verification does not exists.";
        public const string ContactDetailsNotFound = "Address not found.";
        public const string CreateUserNotFound = "User does not exists.";

        public const string PleaseCorrectTheErrorsMessage = "Please correct the specified errors and try again.";

        public const string DocumentNotFound = "Document not found.";
        public const string HouseholdMemberNotFound = "Household Member not found.";

        //Data exists already
        public const string ContactDetailsExists = "Address already exists.";
        public const string UserExists = "User already exists.";
        public const string UserCreationFailed = "User creation failed.";
        public const string OpenAssessmentAlreadyExists = "This patient already has an assessment in progress.  Please submit before creating a new assessment.";
        public const string OpenAssessmentAlreadyExistsSelf = "You already have an assessment in progress status. Please submit before creating a new assessment.";

        //Program
        public const string ProgramAlreadyExits = "Program already associated with the patient";

        public const string UnauthorizedMessage = "Unauthorized Access";
        public const string HealthWareServiceCallTimeoutMessage = "HealthWare Service Call Timeout";

        public static string ExceptionDetails = "No additional details are available.";
        public static string UnexpectedExceptionDetails = "An unexpected server error has occurred.";
    }
}
