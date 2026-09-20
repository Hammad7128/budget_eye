using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;

namespace budget_eye
{
    public static class DatabaseService
    {
        // ===================== LOAD ALL =====================

        public static List<User> LoadUsers()
        {
            var list = new List<User>();
            using (var conn = DBconnection.GetConnection())
            {
                conn.Open();
                string sql = "SELECT UserId, UserName, Password, Email, Role, DisplayName, Timestamp FROM Users";
                using (var cmd = new SqlCommand(sql, conn))
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        list.Add(new User
                        {
                            UserId = reader.GetInt32(0),
                            UserName = reader.GetString(1),
                            Password = reader.GetString(2),
                            Email = reader.GetString(3),
                            Role = (User.UserRole)reader.GetInt32(4),
                            DisplayName = reader.GetString(5),
                            Timestamp = reader.GetDateTime(6)
                        });
                    }
                }
            }
            return list;
        }

        public static List<Request> LoadRequests()
        {
            var list = new List<Request>();
            using (var conn = DBconnection.GetConnection())
            {
                conn.Open();
                string sql = @"SELECT ApplicationId, EmployeeId, RequestedAmount, Purpose, Status,
                                      SubmittedDate, ResolvedDate, ApprovedBy, RequiresSenior, Comments
                               FROM Requests";
                using (var cmd = new SqlCommand(sql, conn))
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        list.Add(new Request
                        {
                            ApplicationId = reader.GetInt32(0),
                            EmployeeId = reader.GetInt32(1),
                            RequestedAmount = reader.GetDecimal(2),
                            Purpose = reader.GetString(3),
                            Status = (BudgetStatus)reader.GetInt32(4),
                            SubmittedDate = reader.GetDateTime(5),
                            ResolvedDate = reader.IsDBNull(6) ? (DateTime?)null : reader.GetDateTime(6),
                            ApprovedBy = reader.IsDBNull(7) ? (int?)null : reader.GetInt32(7),
                            RequiresSenior = reader.GetBoolean(8),
                            Comments = reader.IsDBNull(9) ? null : reader.GetString(9)
                        });
                    }
                }
            }
            return list;
        }

        public static List<AuditLog> LoadAuditLogs()
        {
            var list = new List<AuditLog>();
            using (var conn = DBconnection.GetConnection())
            {
                conn.Open();
                string sql = "SELECT LogId, ApplicationId, Action, PerformedBy, Timestamp, Details FROM AuditLogs";
                using (var cmd = new SqlCommand(sql, conn))
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        list.Add(new AuditLog
                        {
                            LogId = reader.GetInt32(0),
                            ApplicationId = reader.GetInt32(1),
                            Action = reader.GetString(2),
                            PerformedBy = reader.GetInt32(3),
                            Timestamp = reader.GetDateTime(4),
                            Details = reader.IsDBNull(5) ? null : reader.GetString(5)
                        });
                    }
                }
            }
            return list;
        }

        public static List<Configuration> LoadConfigurations()
        {
            var list = new List<Configuration>();
            using (var conn = DBconnection.GetConnection())
            {
                conn.Open();
                string sql = "SELECT ConfigId, ThresholdAmount, SetByAdminId, EffectiveDate, IsActive FROM Configuration";
                using (var cmd = new SqlCommand(sql, conn))
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        list.Add(new Configuration
                        {
                            ConfigId = reader.GetInt32(0),
                            ThresholdAmount = reader.GetDecimal(1),
                            SetByAdminId = reader.GetInt32(2),
                            EffectiveDate = reader.GetDateTime(3),
                            IsActive = reader.GetBoolean(4)
                        });
                    }
                }
            }
            return list;
        }

        // ===================== INSERT =====================

        public static void InsertUser(User u)
        {
            using (var conn = DBconnection.GetConnection())
            {
                conn.Open();
                string sql = @"INSERT INTO Users (UserId, UserName, Password, Email, Role, DisplayName, Timestamp)
                                VALUES (@id, @u, @p, @e, @r, @d, @t)";
                using (var cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@id", u.UserId);
                    cmd.Parameters.AddWithValue("@u", u.UserName);
                    cmd.Parameters.AddWithValue("@p", u.Password);
                    cmd.Parameters.AddWithValue("@e", u.Email);
                    cmd.Parameters.AddWithValue("@r", (int)u.Role);
                    cmd.Parameters.AddWithValue("@d", u.DisplayName);
                    cmd.Parameters.AddWithValue("@t", u.Timestamp);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public static void InsertRequest(Request r)
        {
            using (var conn = DBconnection.GetConnection())
            {
                conn.Open();
                string sql = @"INSERT INTO Requests (ApplicationId, EmployeeId, RequestedAmount, Purpose, Status,
                                                      SubmittedDate, ResolvedDate, ApprovedBy, RequiresSenior, Comments)
                                VALUES (@id, @eid, @amt, @pur, @st, @sub, @res, @app, @sen, @com)";
                using (var cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@id", r.ApplicationId);
                    cmd.Parameters.AddWithValue("@eid", r.EmployeeId);
                    cmd.Parameters.AddWithValue("@amt", r.RequestedAmount);
                    cmd.Parameters.AddWithValue("@pur", r.Purpose);
                    cmd.Parameters.AddWithValue("@st", (int)r.Status);
                    cmd.Parameters.AddWithValue("@sub", r.SubmittedDate);
                    cmd.Parameters.AddWithValue("@res", (object)r.ResolvedDate ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@app", (object)r.ApprovedBy ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@sen", r.RequiresSenior);
                    cmd.Parameters.AddWithValue("@com", (object)r.Comments ?? DBNull.Value);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public static void InsertAuditLog(AuditLog l)
        {
            using (var conn = DBconnection.GetConnection())
            {
                conn.Open();
                string sql = @"INSERT INTO AuditLogs (LogId, ApplicationId, Action, PerformedBy, Timestamp, Details)
                                VALUES (@id, @app, @act, @by, @ts, @det)";
                using (var cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@id", l.LogId);
                    cmd.Parameters.AddWithValue("@app", l.ApplicationId);
                    cmd.Parameters.AddWithValue("@act", l.Action);
                    cmd.Parameters.AddWithValue("@by", l.PerformedBy);
                    cmd.Parameters.AddWithValue("@ts", l.Timestamp);
                    cmd.Parameters.AddWithValue("@det", (object)l.Details ?? DBNull.Value);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public static void InsertConfiguration(Configuration c)
        {
            using (var conn = DBconnection.GetConnection())
            {
                conn.Open();
                string sql = @"INSERT INTO Configuration (ConfigId, ThresholdAmount, SetByAdminId, EffectiveDate, IsActive)
                                VALUES (@id, @amt, @adm, @eff, @act)";
                using (var cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@id", c.ConfigId);
                    cmd.Parameters.AddWithValue("@amt", c.ThresholdAmount);
                    cmd.Parameters.AddWithValue("@adm", c.SetByAdminId);
                    cmd.Parameters.AddWithValue("@eff", c.EffectiveDate);
                    cmd.Parameters.AddWithValue("@act", c.IsActive);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        // ===================== UPDATE =====================

        public static void UpdateRequest(Request r)
        {
            using (var conn = DBconnection.GetConnection())
            {
                conn.Open();
                string sql = @"UPDATE Requests SET Status = @st, ResolvedDate = @res,
                               ApprovedBy = @app, Comments = @com WHERE ApplicationId = @id";
                using (var cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@st", (int)r.Status);
                    cmd.Parameters.AddWithValue("@res", (object)r.ResolvedDate ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@app", (object)r.ApprovedBy ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@com", (object)r.Comments ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@id", r.ApplicationId);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public static void UpdateUserPassword(User u)
        {
            using (var conn = DBconnection.GetConnection())
            {
                conn.Open();
                string sql = "UPDATE Users SET Password = @p WHERE UserId = @id";
                using (var cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@p", u.Password);
                    cmd.Parameters.AddWithValue("@id", u.UserId);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public static void DeactivateAllConfigs()
        {
            using (var conn = DBconnection.GetConnection())
            {
                conn.Open();
                using (var cmd = new SqlCommand("UPDATE Configuration SET IsActive = 0", conn))
                    cmd.ExecuteNonQuery();
            }
        }

        // ===================== GET MAX IDs =====================

        public static int GetMaxUserId() => GetMax("Users", "UserId");
        public static int GetMaxRequestId() => GetMax("Requests", "ApplicationId");
        public static int GetMaxLogId() => GetMax("AuditLogs", "LogId");
        public static int GetMaxConfigId() => GetMax("Configuration", "ConfigId");

        private static int GetMax(string table, string col)
        {
            using (var conn = DBconnection.GetConnection())
            {
                conn.Open();
                string sql = $"SELECT ISNULL(MAX({col}), 0) FROM {table}";
                using (var cmd = new SqlCommand(sql, conn))
                {
                    var result = cmd.ExecuteScalar();
                    return result == DBNull.Value ? 0 : Convert.ToInt32(result);
                }
            }
        }
    }
}
