using System;
using System.Data;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;
using Microsoft.Data.SqlClient;

namespace budget_eye
{
    public partial class AdminReportsTab : UserControl
    {
        private string _connString = "Server=DESKTOP-9LNIKCT\\SQLEXPRESS;Database=BudgetEyeDB;Trusted_Connection=True;TrustServerCertificate=True;";

        public AdminReportsTab()
        {
            InitializeComponent();
            LoadStats();
        }

        private void LoadStats()
        {
            try
            {
                using var conn = new SqlConnection(_connString);
                conn.Open();
                using var cmd = new SqlCommand("sp_GetRequestStats", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                using var reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    lblStats.Text = $"Total: {reader["TotalRequests"]} | Pending: {reader["PendingCount"]} | Approved: {reader["ApprovedCount"]} | Disapproved: {reader["DisapprovedCount"]} | Amount: {Convert.ToDecimal(reader["TotalApprovedAmount"]):C2}";
                }
            }
            catch (Exception ex)
            {
                lblStats.Text = "Error: " + ex.Message;
                lblStats.ForeColor = Color.Red;
            }
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            try
            {
                var sb = new StringBuilder();
                using var conn = new SqlConnection(_connString);
                conn.Open();

                // Users
                sb.AppendLine("=== USERS ===");
                using (var cmd = new SqlCommand("SELECT * FROM Users", conn))
                using (var r = cmd.ExecuteReader())
                    while (r.Read()) sb.AppendLine($"{r["UserId"]},{r["UserName"]},{r["DisplayName"]},{r["Email"]},{r["Role"]}");

                // Requests
                sb.AppendLine("\n=== REQUESTS ===");
                using (var cmd = new SqlCommand("SELECT * FROM Requests", conn))
                using (var r = cmd.ExecuteReader())
                    while (r.Read()) sb.AppendLine($"{r["ApplicationId"]},{r["EmployeeId"]},{r["RequestedAmount"]},{r["Purpose"]},{r["Status"]},{r["SubmittedDate"]}");

                // AuditLogs
                sb.AppendLine("\n=== AUDIT LOGS ===");
                using (var cmd = new SqlCommand("SELECT * FROM AuditLogs", conn))
                using (var r = cmd.ExecuteReader())
                    while (r.Read()) sb.AppendLine($"{r["LogId"]},{r["ApplicationId"]},{r["Action"]},{r["PerformedBy"]},{r["Timestamp"]}");

                // Configuration
                sb.AppendLine("\n=== CONFIGURATIONS ===");
                using (var cmd = new SqlCommand("SELECT * FROM Configuration", conn))
                using (var r = cmd.ExecuteReader())
                    while (r.Read()) sb.AppendLine($"{r["ConfigId"]},{r["ThresholdAmount"]},{r["SetByAdminId"]},{r["EffectiveDate"]},{r["IsActive"]}");

                // DeletedUsers
                sb.AppendLine("\n=== DELETED USERS ===");
                using (var cmd = new SqlCommand("SELECT * FROM DeletedUsers", conn))
                using (var r = cmd.ExecuteReader())
                    while (r.Read()) sb.AppendLine($"{r["UserId"]},{r["UserName"]},{r["DisplayName"]},{r["DeletionTime"]}");

                // DeletedRequests
                sb.AppendLine("\n=== DELETED REQUESTS ===");
                using (var cmd = new SqlCommand("SELECT * FROM DeletedRequests", conn))
                using (var r = cmd.ExecuteReader())
                    while (r.Read()) sb.AppendLine($"{r["ApplicationId"]},{r["EmployeeId"]},{r["RequestedAmount"]},{r["Purpose"]},{r["DeletionTime"]}");

                txtPreview.Text = sb.ToString();
                lblMessage.Text = "Data loaded. Click Export to save as CSV.";
                lblMessage.ForeColor = Color.Green;
            }
            catch (Exception ex)
            {
                lblMessage.Text = "Error: " + ex.Message;
                lblMessage.ForeColor = Color.Red;
            }
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtPreview.Text))
            {
                lblMessage.Text = "Load data first.";
                lblMessage.ForeColor = Color.Red;
                return;
            }

            using var sfd = new SaveFileDialog();
            sfd.Filter = "CSV files (*.csv)|*.csv|Text files (*.txt)|*.txt";
            sfd.FileName = $"BudgetEye_Report_{DateTime.Now:yyyyMMdd_HHmmss}.csv";

            if (sfd.ShowDialog() == DialogResult.OK)
            {
                File.WriteAllText(sfd.FileName, txtPreview.Text);
                lblMessage.Text = $"Saved: {sfd.FileName}";
                lblMessage.ForeColor = Color.Green;
            }
        }
    }
}