namespace Healthware.Core.EmailService
{
    public class AdminNotification
    {
        public string UserName { get; set; }
        public string Action { get; set; }
        public string Message { get; set; }
        public string Stacktrace { get; set; }

        public AdminNotification(string userName, string action, string message, string stacktrace)
        {
            UserName = userName;
            Action = action;
            Message = message;
            Stacktrace = stacktrace;
        }
    }
}
