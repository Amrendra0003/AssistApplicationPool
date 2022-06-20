using System;

namespace HealthWare.ActiveASSIST.Repositories
{
    public static class Constants
    {
        public const string GetAssessmentSummaryQuery = "SELECT SQM.KeyName, ANS.[Value], AO.[Value] as AnswerOptionValue FROM Answer as ANS WITH(NOLOCK) INNER JOIN Question as QST WITH(NOLOCK) ON ANS.QuestionId = QST.Id INNER JOIN ScreenQuestionMapping as SQM WITH(NOLOCK) ON ANS.ScreenQuestionMappingId = SQM.Id left JOIN AnswerOption as AO ON ANS.AnswerOptionId = AO.Id WHERE AssessmentId = {0}";

        public const string UspGetAssessmentDashboardDetails = "USP_GetAssessmentDashboardDetails";
        public const string UspGetPatientDashboardDetails = "USP_GetPatientDashboardDetails";
        public const string ExecuteStoredProcedure = "Exec";
        public const string UserIdParameter = "@UserId";
        public const string EmailParameter = "@EmailAddress";
        public const string PartialNameParameter = "@PartialName";
        public const string TenantIdParameter = "@TenantId";

        public const string Self = "Self";
        public const string Myself = "Myself";
        public const string Guarantor = "Guarantor";
        public const string Home = "Home";
        public const string Work = "Work";
        public const string Basic = "Basic";
        public const string Other = "Other";
        public const string HouseholdMember = "Household Member";
        public const string UserProfile = "User Profile";
        public const string SecondaryEmail = "SecondaryEmail";

        public const string UserId = "UserId";

        public const string AdminUserId = "-1";
        public const string CreatedBy = "CreatedBy";
        public const string UpdatedBy = "UpdatedBy";
        public const string CreatedDate = "CreatedDate";
        public const string UpdatedDate = "UpdatedDate";
        
        public static DateTime CreatedDateTime = new DateTime(637450560000000000);

    }

    public static class DataConstants
    {
        public const string FirstName = "Naresh";
        public const string LastName = "Kumar";
        public const string DateFormat = "MM/dd/yyyy";
        public const string Date = "07/08/1995";
        public const string Ssn = "111223334";
        public const string Email = "naresh.k @zucisystems.com";
        public const string Cell = "8889991234";
        public const string CountryCode = "1";
        public const string Password = "Password@123";
        public const string HomeAddress = "HomeAddress";
        public const string City = "Chicago";
        public const string State = "Illinois";
        public const string Zip = "60026";



    }
}
