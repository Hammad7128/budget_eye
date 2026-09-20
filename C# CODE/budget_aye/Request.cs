using System;
using System.Collections.Generic;
using System.Text;

namespace budget_eye
{
    public class Request
    {
        public int ApplicationId { get; set; }
        public int EmployeeId { get; set; }
        public decimal RequestedAmount { get; set; }
        public string Purpose { get; set; }
        public BudgetStatus Status { get; set; }
        public DateTime SubmittedDate { get; set; }
        public DateTime? ResolvedDate { get; set; }
        public int? ApprovedBy { get; set; }
        public bool RequiresSenior { get; set; }
        public string Comments { get; set; }

        private static int _idCounter = 1000;

        public Request() { }

        public static void SyncCounterFromDb()
        {
            _idCounter = Math.Max(_idCounter, DatabaseService.GetMaxRequestId());
        }

        public static Request Create(User employee, decimal requestedAmount, string purpose)
        {
            ValidateEmployee(employee);
            ValidateRequest(requestedAmount, purpose);

            decimal threshold = Configuration.GetCurrentThreshold();

            var req = new Request
            {
                ApplicationId = GenerateApplicationId(),
                EmployeeId = employee.UserId,
                RequestedAmount = requestedAmount,
                Purpose = purpose,
                Status = BudgetStatus.Pending,
                SubmittedDate = DateTime.Now,
                ResolvedDate = null,
                ApprovedBy = null,
                Comments = null,
                RequiresSenior = requestedAmount > threshold
            };

            DatabaseService.InsertRequest(req);
            return req;
        }

        private static int GenerateApplicationId()
        {
            _idCounter++;
            return _idCounter;
        }

        private static void ValidateEmployee(User employee)
        {
            if (employee == null)
                throw new ArgumentException("Employee cannot be null.");

            if (employee.UserId <= 0)
                throw new ArgumentException("Invalid Employee Id.");
        }

        private static void ValidateRequest(decimal amount, string purpose)
        {
            if (amount <= 0)
                throw new ArgumentException("Amount must be greater than 0.");

            if (string.IsNullOrWhiteSpace(purpose))
                throw new ArgumentException("Purpose cannot be empty.");
        }

        public bool Approve(User manager, string comments)
        {
            if (!IsValidApprover(manager))
                return false;

            if (Status != BudgetStatus.Pending)
                return false;

            if (RequiresSenior && manager.Role != User.UserRole.SeniorManager)
                return false;

            Status = BudgetStatus.Approved;
            ApprovedBy = manager.UserId;
            ResolvedDate = DateTime.Now;
            Comments = comments;

            DatabaseService.UpdateRequest(this);
            return true;
        }

        public bool Disapprove(User manager, string comments)
        {
            if (!IsValidApprover(manager))
                return false;

            if (Status != BudgetStatus.Pending)
                return false;

            if (RequiresSenior && manager.Role != User.UserRole.SeniorManager)
                return false;

            Status = BudgetStatus.Disapproved;
            ApprovedBy = manager.UserId;
            ResolvedDate = DateTime.Now;
            Comments = comments;

            DatabaseService.UpdateRequest(this);
            return true;
        }

        private bool IsValidApprover(User manager)
        {
            if (manager == null || manager.UserId <= 0)
                return false;

            return manager.Role == User.UserRole.Manager ||
                manager.Role == User.UserRole.SeniorManager;
        }

        public TimeSpan GetAge()
        {
            return DateTime.Now - SubmittedDate;
        }

        public string GetStatusForUser(int currentUserId)
        {
            if (currentUserId == EmployeeId)
                return Status.ToString();

            return "Resolved";
        }
    }

    public enum BudgetStatus
    {
        Pending,
        Approved,
        Disapproved,
        Resolved
    }
}
