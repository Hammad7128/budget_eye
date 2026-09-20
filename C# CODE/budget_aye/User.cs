using System;
using System.Collections.Generic;
using System.Text;

namespace budget_eye
{
     public class User
     {

        public enum UserRole
        {
            Administrator,
            SeniorManager,
            Manager,
            Employee
        }
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public UserRole Role { get; set; }
        public string DisplayName { get; set; }
        public DateTime Timestamp { get; set; }

        public User() { } 

        public static User Create(
        int userId,
        string userName,
        string password,
        string email,
        UserRole role,
        string displayName)
        {
            Validate(userId, userName, password, email, role, displayName);

            var user = new User
            {
                UserId = userId,
                UserName = userName,
                Password = password,
                Email = email,
                Role = role,
                DisplayName = displayName,
                Timestamp = DateTime.Now
            };

            DatabaseService.InsertUser(user);
            return user;
        }

        private static void Validate(
            int userId,
            string userName,
            string password,
            string email,
            UserRole role,
            string displayName)
        {
            if (userId <= 0)
                throw new ArgumentException("UserId must be greater than 0.");

            if (string.IsNullOrWhiteSpace(userName))
                throw new ArgumentException("UserName cannot be empty.");

            if (string.IsNullOrWhiteSpace(password) || password.Length < 6)
                throw new ArgumentException("Password must be at least 6 characters long.");

            if (string.IsNullOrWhiteSpace(email) || !email.Contains("@")) 
                throw new ArgumentException("Invalid email.");

            if (string.IsNullOrWhiteSpace(displayName))
                throw new ArgumentException("DisplayName cannot be empty.");
        }

        public bool UpdatePassword(string oldPassword, string newPassword)
        {
            if (Password != oldPassword)
            {
                Console.WriteLine("Password update failed: old password is incorrect.");
                return false;
            }

            if (string.IsNullOrWhiteSpace(newPassword) || newPassword.Length < 6)
            {
                Console.WriteLine("Password update failed: new password is invalid.");
                return false;
            }

            Password = newPassword;
            DatabaseService.UpdateUserPassword(this);
            Console.WriteLine("Password updated successfully.");
            return true;
        }

        public int PermissionLevel()
        {
            switch (Role)
            {
                case UserRole.Administrator:
                    return 1;
                case UserRole.SeniorManager:
                    return 2;
                case UserRole.Manager:
                    return 3;
                case UserRole.Employee:
                    return 4;
                default:
                    return 0;
            }
        }

        public void DisplayInfo()
        {
            Console.WriteLine("       User Information      ");
            Console.WriteLine($"UserId      : {UserId}");
            Console.WriteLine($"UserName    : {UserName}");
            Console.WriteLine($"Email       : {Email}");
            Console.WriteLine($"Role        : {Role}");
            Console.WriteLine($"DisplayName : {DisplayName}");
            Console.WriteLine($"Timestamp   : {Timestamp}");
            Console.WriteLine("                             ");
        }
     }
}
