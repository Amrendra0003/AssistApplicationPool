namespace Healthware.Core.Configurations
{
    public static class PropertyValues
    {
        private const string _true = "true";
        private static string CanEnableMockData { get; set; }
        private static string EnvironmentName { get; set; }
        private static string CanEnableOTP { get; set; }
        private static string CanEnableMockService { get; set; }
        private static string CanByepassVerification { get; set; }

        public static void EnableMockService(string value)
        {
            CanEnableMockService = value;
        }
        public static bool IsServiceMockEnabled()
        {
            return CanEnableMockService.ToLower().Equals(_true);
        }
        public static void EnableMockData(string value)
        {
            CanEnableMockData = value;
        }

        public static bool isMockEnabled()
        {
            return CanEnableMockData.ToLower().Equals("true");
        }


        public static void SetEnvironmentName(string value)
        {
            EnvironmentName = value;
        }
        public static string GetEnvironmentName()
        {
            return EnvironmentName;
        }
        public static string EnableOTP(string value)
        {
            return CanEnableOTP = value;
        }
        public static bool isOTPEnabled()
        {
            return CanEnableOTP.ToLower().Equals("true");
        }
        public static string ByePassVerification(string value)
        {
            return CanByepassVerification = value;
        }
        public static bool IsVerificationByePassed()
        {
            return CanByepassVerification.ToLower().Equals("true");
        }
    }
}