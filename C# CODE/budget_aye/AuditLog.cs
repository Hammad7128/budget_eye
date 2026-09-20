using System;

namespace budget_eye
{
    public class AuditLog
    {
        public int LogId { get; set; }
        public int ApplicationId { get; set; }
        public string Action { get; set; }
        public int PerformedBy { get; set; }
        public DateTime Timestamp { get; set; }
        public string Details { get; set; }

        private static int _logIdCounter = 0;  // Start at 0, sync from DB

        public AuditLog() { }

        public static void SyncCounterFromDb()
        {
            _logIdCounter = DatabaseService.GetMaxLogId();
        }

        public static AuditLog Create(int applicationId, string action, int performedBy, string details)
        {
            Validate(applicationId, action, performedBy);

            AuditLog log = new AuditLog
            {
                LogId = GenerateLogId(),
                ApplicationId = applicationId,
                Action = action.Trim(),
                PerformedBy = performedBy,
                Timestamp = DateTime.Now
            };

            if (string.IsNullOrWhiteSpace(details))
            {
                log.Details = null;
            }
            else
            {
                log.Details = details.Trim();
            }

            DatabaseService.InsertAuditLog(log);
            return log;
        }

        private static void Validate(int applicationId, string action, int performedBy)
        {
            if (applicationId < 0)
                throw new ArgumentException("ApplicationId must be >= 0.");

            if (string.IsNullOrWhiteSpace(action))
                throw new ArgumentException("Action cannot be empty.");

            if (performedBy <= 0)
                throw new ArgumentException("PerformedBy must be greater than 0.");
        }

        private static int GenerateLogId()
        {
            _logIdCounter++;
            return _logIdCounter;
        }
    }
}