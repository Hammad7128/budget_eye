using System;
using System.Collections.Generic;

namespace budget_eye
{
    public class Application
    {
        private Authentication _auth;
        private List<Request> _requests;
        private List<AuditLog> _logs;

        public Application()
        {
            _auth = new Authentication();
            _requests = DatabaseService.LoadRequests();
            _logs = DatabaseService.LoadAuditLogs();

            // SYNC ALL COUNTERS FROM DB
            Request.SyncCounterFromDb();
            AuditLog.SyncCounterFromDb();
            Configuration.SyncCounterFromDb();
        }

        // ================= AUTH =================

        public string Login(string username, string password)
        {
            var user = _auth.Login(username, password);

            if (user == null)
                return "Invalid credentials";

            return "Login successful";
        }

        public void Logout()
        {
            _auth.Logout();
        }

        public User GetCurrentUser()
        {
            return _auth.GetCurrentUser();
        }

        public bool IsLoggedIn()
        {
            return _auth.IsLoggedIn();
        }

        // ================= PASSWORD =================

        public string ChangePassword(string oldPassword, string newPassword)
        {
            var user = _auth.GetCurrentUser();

            if (user == null)
                return "Login required";

            if (!user.UpdatePassword(oldPassword, newPassword))
                return "Password change failed";

            return "Password updated";
        }

        // ================= USERS =================

        public string RegisterUser(int id, string username, string password, string email, User.UserRole role, string displayName)
        {
            if (!_auth.RegisterUser(id, username, password, email, role, displayName))
                return "Only admin can create users";

            return "User created";
        }

        public List<User> GetAllUsers()
        {
            return _auth.GetAllUsers();
        }

        public User GetUserById(int id)
        {
            return _auth.GetUserById(id);
        }

        // ================= REQUESTS =================

        public string CreateRequest(decimal amount, string purpose)
        {
            var user = _auth.GetCurrentUser();
            if (user == null) return "Login required";
            if (user.Role != User.UserRole.Employee) return "Only employees allowed";

            var req = Request.Create(user, amount, purpose);
            _requests.Add(req);

            try
            {
                _logs.Add(AuditLog.Create(req.ApplicationId, "Created", user.UserId, "Request created"));
            }
            catch (Exception ex)
            {
                // Log this somewhere or show it — this will reveal the true error
                return $"Request created but audit log failed: {ex.Message}";
            }

            return "Request created";
        }

        public string ApproveRequest(int id, string comments)
        {
            var user = _auth.GetCurrentUser();
            var req = FindRequest(id);

            if (user == null || req == null)
                return "Invalid operation";

            if (!req.Approve(user, comments))
                return "Approval failed";

            _logs.Add(AuditLog.Create(id, "Approved", user.UserId, comments));

            return "Approved";
        }

        public string DisapproveRequest(int id, string comments)
        {
            var user = _auth.GetCurrentUser();
            var req = FindRequest(id);

            if (user == null || req == null)
                return "Invalid operation";

            if (!req.Disapprove(user, comments))
                return "Disapproval failed";

            _logs.Add(AuditLog.Create(id, "Disapproved", user.UserId, comments));

            return "Disapproved";
        }

        public List<Request> GetRequests()
        {
            var user = _auth.GetCurrentUser();
            var result = new List<Request>();

            if (user == null)
                return result;

            foreach (var r in _requests)
            {
                if (user.Role == User.UserRole.Employee)
                {
                    if (r.EmployeeId == user.UserId)
                        result.Add(r);
                }
                else
                {
                    result.Add(r);
                }
            }

            return result;
        }

        private Request FindRequest(int id)
        {
            foreach (var r in _requests)
            {
                if (r.ApplicationId == id)
                    return r;
            }

            return null;
        }

        // ================= LOGS =================

        public List<AuditLog> GetLogs()
        {
            var user = _auth.GetCurrentUser();

            if (user == null)
                return new List<AuditLog>();

            if (user.Role == User.UserRole.SeniorManager ||
                user.Role == User.UserRole.Administrator)
                return _logs;

            return new List<AuditLog>();
        }

        // ================= CONFIG =================

        public string SetThreshold(decimal amount)
        {
            var user = _auth.GetCurrentUser();

            if (user == null || user.Role != User.UserRole.Administrator)
                return "Only admin allowed";

            Configuration.Create(amount, user.UserId);

            _logs.Add(AuditLog.Create(0, "ThresholdUpdated", user.UserId, $"New threshold: {amount}"));

            return "Threshold updated";
        }

        // ================= STATS =================

        public decimal GetTotalApprovedAmount()
        {
            decimal total = 0;

            foreach (var r in _requests)
            {
                if (r.Status == BudgetStatus.Approved)
                    total += r.RequestedAmount;
            }

            return total;
        }
    }
}