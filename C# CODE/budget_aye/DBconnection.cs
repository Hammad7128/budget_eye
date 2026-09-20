using Microsoft.Data.SqlClient;
using System;

namespace budget_eye
{
    public static class DBconnection
    {
        private static string _connectionString = "Server=DESKTOP-9LNIKCT\\SQLEXPRESS;Database=BudgetEyeDB;Trusted_Connection=True;TrustServerCertificate=True;";

        public static SqlConnection GetConnection()
        {
            return new SqlConnection(_connectionString);
        }

        public static void SetConnectionString(string connectionString)
        {
            _connectionString = connectionString;
        }
    }
}