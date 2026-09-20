using System;
using System.Collections.Generic;

namespace budget_eye
{
    public class Authentication
    {
        private User _currentUser;
        private List<User> _allUsers;

        public Authentication()
        {
            _allUsers = DatabaseService.LoadUsers();
        }

        public User Login(string username, string password)
        {
            for (int i = 0; i < _allUsers.Count; i++)
            {
                if (_allUsers[i].UserName == username && _allUsers[i].Password == password)
                {
                    _currentUser = _allUsers[i];
                    return _currentUser;
                }
            }

            return null;
        }

        public void Logout()
        {
            _currentUser = null;
        }

        public User GetCurrentUser()
        {
            return _currentUser;
        }

        public bool IsLoggedIn()
        {
            return _currentUser != null;
        }

        public bool RegisterUser(int userId, string username, string password, string email, User.UserRole role, string displayName)
        {
            if (_currentUser == null)
                return false;

            if (_currentUser.Role != User.UserRole.Administrator)
                return false;

            User newUser = User.Create(userId, username, password, email, role, displayName);
            _allUsers.Add(newUser);

            return true;
        }

        public List<User> GetAllUsers()
        {
            return _allUsers;
        }

        public User GetUserById(int userId)
        {
            for (int i = 0; i < _allUsers.Count; i++)
            {
                if (_allUsers[i].UserId == userId)
                    return _allUsers[i];
            }

            return null;
        }
    }
}
