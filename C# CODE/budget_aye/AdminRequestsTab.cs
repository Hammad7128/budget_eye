using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using Microsoft.Data.SqlClient;

namespace budget_eye
{
    public partial class AdminRequestsTab : UserControl
    {
        private string _connString = "Server=DESKTOP-9LNIKCT\\SQLEXPRESS;Database=BudgetEyeDB;Trusted_Connection=True;TrustServerCertificate=True;";
        private Application _app;
        private int? _selectedRequestId = null;
        private int? _selectedStatus = null;

        public AdminRequestsTab(Application app)
        {
            InitializeComponent();
            _app = app;
            LoadAllRequests(null);
            LoadDeletedRequests();
            SetupDatePickers();
        }

        private void SetupDatePickers()
        {
            dtpStartDate.Value = DateTime.Now.AddMonths(-1);
            dtpEndDate.Value = DateTime.Now;
        }

        private void LoadAllRequests(int? statusFilter)
        {
            _selectedStatus = statusFilter;
            try
            {
                using (var conn = new SqlConnection(_connString))
                {
                    conn.Open();
                    using (var cmd = new SqlCommand("sp_GetAllRequests", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@StatusFilter", (object)statusFilter ?? DBNull.Value);

                        var adapter = new SqlDataAdapter(cmd);
                        var table = new DataTable();
                        adapter.Fill(table);

                        if (!table.Columns.Contains("StatusText"))
                        {
                            table.Columns.Add("StatusText", typeof(string));
                            foreach (DataRow row in table.Rows)
                            {
                                int s = Convert.ToInt32(row["Status"]);
                                row["StatusText"] = ((BudgetStatus)s).ToString();
                            }
                        }

                        dgvAllRequests.DataSource = table;

                        if (dgvAllRequests.Columns.Count == 0) return;

                        dgvAllRequests.Columns["Status"].Visible = false;
                        dgvAllRequests.Columns["EmployeeId"].Visible = false;
                        dgvAllRequests.Columns["ApprovedBy"].Visible = false;
                        dgvAllRequests.Columns["RequiresSenior"].Visible = false;

                        dgvAllRequests.Columns["ApplicationId"].HeaderText = "Request ID";
                        dgvAllRequests.Columns["EmployeeName"].HeaderText = "Employee";
                        dgvAllRequests.Columns["RequestedAmount"].HeaderText = "Amount";
                        dgvAllRequests.Columns["Purpose"].HeaderText = "Purpose";
                        dgvAllRequests.Columns["StatusText"].HeaderText = "Status";
                        dgvAllRequests.Columns["SubmittedDate"].HeaderText = "Submitted";
                        dgvAllRequests.Columns["ResolvedDate"].HeaderText = "Resolved";
                        dgvAllRequests.Columns["ApprovedByName"].HeaderText = "Approved By";
                        dgvAllRequests.Columns["Comments"].HeaderText = "Comments";

                        dgvAllRequests.Columns["RequestedAmount"].DefaultCellStyle.Format = "C2";
                        dgvAllRequests.Columns["RequestedAmount"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                        dgvAllRequests.Columns["SubmittedDate"].DefaultCellStyle.Format = "g";
                        dgvAllRequests.Columns["ResolvedDate"].DefaultCellStyle.Format = "g";

                        foreach (DataGridViewRow row in dgvAllRequests.Rows)
                        {
                            var status = row.Cells["StatusText"].Value?.ToString();
                            if (status == "Approved")
                                row.Cells["StatusText"].Style.ForeColor = Color.Green;
                            else if (status == "Disapproved")
                                row.Cells["StatusText"].Style.ForeColor = Color.Red;
                            else if (status == "Pending")
                                row.Cells["StatusText"].Style.ForeColor = Color.Orange;
                            else if (status == "Resolved")
                                row.Cells["StatusText"].Style.ForeColor = Color.DodgerBlue;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading requests: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadDeletedRequests()
        {
            try
            {
                using (var conn = new SqlConnection(_connString))
                {
                    conn.Open();
                    using (var cmd = new SqlCommand("sp_GetDeletedRequests", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        var adapter = new SqlDataAdapter(cmd);
                        var table = new DataTable();
                        adapter.Fill(table);

                        if (!table.Columns.Contains("StatusText"))
                        {
                            table.Columns.Add("StatusText", typeof(string));
                            foreach (DataRow row in table.Rows)
                            {
                                int s = Convert.ToInt32(row["Status"]);
                                row["StatusText"] = ((BudgetStatus)s).ToString();
                            }
                        }

                        dgvDeletedRequests.DataSource = table;

                        if (dgvDeletedRequests.Columns.Count == 0) return;

                        dgvDeletedRequests.Columns["Status"].Visible = false;
                        dgvDeletedRequests.Columns["EmployeeId"].Visible = false;
                        dgvDeletedRequests.Columns["DeletedBy"].Visible = false;

                        dgvDeletedRequests.Columns["ApplicationId"].HeaderText = "Request ID";
                        dgvDeletedRequests.Columns["EmployeeName"].HeaderText = "Employee";
                        dgvDeletedRequests.Columns["RequestedAmount"].HeaderText = "Amount";
                        dgvDeletedRequests.Columns["Purpose"].HeaderText = "Purpose";
                        dgvDeletedRequests.Columns["StatusText"].HeaderText = "Status";
                        dgvDeletedRequests.Columns["SubmittedDate"].HeaderText = "Submitted";
                        dgvDeletedRequests.Columns["ResolvedDate"].HeaderText = "Resolved";
                        dgvDeletedRequests.Columns["Comments"].HeaderText = "Comments";
                        dgvDeletedRequests.Columns["DeletedByName"].HeaderText = "Deleted By";
                        dgvDeletedRequests.Columns["DeletionTime"].HeaderText = "Deleted On";

                        dgvDeletedRequests.Columns["RequestedAmount"].DefaultCellStyle.Format = "C2";
                        dgvDeletedRequests.Columns["RequestedAmount"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                        dgvDeletedRequests.Columns["DeletionTime"].DefaultCellStyle.Format = "g";
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading deleted requests: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadAuditLog(int requestId)
        {
            try
            {
                using (var conn = new SqlConnection(_connString))
                {
                    conn.Open();
                    using (var cmd = new SqlCommand("sp_GetRequestAudit", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@ApplicationId", requestId);

                        var adapter = new SqlDataAdapter(cmd);
                        var table = new DataTable();
                        adapter.Fill(table);

                        dgvAuditLog.DataSource = table;

                        if (dgvAuditLog.Columns.Count == 0) return;

                        dgvAuditLog.Columns["LogId"].HeaderText = "Log ID";
                        dgvAuditLog.Columns["ApplicationId"].HeaderText = "Request ID";
                        dgvAuditLog.Columns["Action"].HeaderText = "Action";
                        dgvAuditLog.Columns["PerformedBy"].Visible = false;
                        dgvAuditLog.Columns["PerformedByName"].HeaderText = "By";
                        dgvAuditLog.Columns["Timestamp"].HeaderText = "Date/Time";
                        dgvAuditLog.Columns["Details"].HeaderText = "Details";

                        dgvAuditLog.Columns["Timestamp"].DefaultCellStyle.Format = "g";
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading audit log: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvAllRequests_SelectionChanged(object sender, EventArgs e)
        {
            lblMessage.Text = "";
            btnDeletePending.Enabled = false;

            if (dgvAllRequests.SelectedRows.Count == 0)
            {
                _selectedRequestId = null;
                dgvAuditLog.DataSource = null;
                return;
            }

            var row = dgvAllRequests.SelectedRows[0];
            _selectedRequestId = Convert.ToInt32(row.Cells["ApplicationId"].Value);

            LoadAuditLog(_selectedRequestId.Value);

            var statusText = row.Cells["StatusText"].Value?.ToString();
            if (statusText == "Pending")
            {
                btnDeletePending.Enabled = true;
            }
        }

        private void btnFilter_Click(object sender, EventArgs e)
        {
            int? filter = null;
            if (sender == btnAll) filter = null;
            else if (sender == btnPending) filter = 0;
            else if (sender == btnApproved) filter = 1;
            else if (sender == btnDisapproved) filter = 2;
            else if (sender == btnResolved) filter = 3;

            LoadAllRequests(filter);
        }

        private void btnDeletePending_Click(object sender, EventArgs e)
        {
            if (_selectedRequestId == null) return;

            var user = _app?.GetCurrentUser();
            if (user == null)
            {
                MessageBox.Show("Unable to identify current admin user.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var confirm = MessageBox.Show(
                $"Are you sure you want to delete Request ID {_selectedRequestId}?\n\nOnly pending requests can be deleted. This will archive the request.",
                "Confirm Delete",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);

            if (confirm != DialogResult.Yes) return;

            try
            {
                using (var conn = new SqlConnection(_connString))
                {
                    conn.Open();
                    using (var cmd = new SqlCommand("sp_DeletePendingRequest", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@ApplicationId", _selectedRequestId.Value);
                        cmd.Parameters.AddWithValue("@DeletedBy", user.UserId);

                        var result = cmd.ExecuteScalar();
                        int success = Convert.ToInt32(result);

                        if (success == 1)
                        {
                            lblMessage.Text = $"Request {_selectedRequestId} deleted and archived.";
                            lblMessage.ForeColor = Color.Green;
                            _selectedRequestId = null;
                            btnDeletePending.Enabled = false;
                            dgvAuditLog.DataSource = null;
                            LoadAllRequests(_selectedStatus);
                            LoadDeletedRequests();
                        }
                        else
                        {
                            lblMessage.Text = "Delete failed. Request may not be pending or does not exist.";
                            lblMessage.ForeColor = Color.Red;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                lblMessage.Text = "Error: " + ex.Message;
                lblMessage.ForeColor = Color.Red;
            }
        }

        private void btnGetStats_Click(object sender, EventArgs e)
        {
            lblMessage.Text = "";
            try
            {
                using (var conn = new SqlConnection(_connString))
                {
                    conn.Open();
                    using (var cmd = new SqlCommand("sp_GetRequestsByDateRange", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@StartDate", dtpStartDate.Value.Date);
                        cmd.Parameters.AddWithValue("@EndDate", dtpEndDate.Value.Date);

                        var ds = new DataSet();
                        using (var adapter = new SqlDataAdapter(cmd))
                        {
                            adapter.Fill(ds);
                        }

                        // Bind detail records to the date range grid
                        if (ds.Tables.Count > 0)
                        {
                            var detailTable = ds.Tables[0];

                            if (!detailTable.Columns.Contains("StatusText"))
                            {
                                detailTable.Columns.Add("StatusText", typeof(string));
                                foreach (DataRow row in detailTable.Rows)
                                {
                                    int s = Convert.ToInt32(row["Status"]);
                                    row["StatusText"] = ((BudgetStatus)s).ToString();
                                }
                            }

                            dgvDateRangeResults.DataSource = detailTable;

                            if (dgvDateRangeResults.Columns.Count > 0)
                            {
                                dgvDateRangeResults.Columns["Status"].Visible = false;
                                dgvDateRangeResults.Columns["EmployeeId"].Visible = false;

                                dgvDateRangeResults.Columns["ApplicationId"].HeaderText = "Request ID";
                                dgvDateRangeResults.Columns["EmployeeName"].HeaderText = "Employee";
                                dgvDateRangeResults.Columns["RequestedAmount"].HeaderText = "Amount";
                                dgvDateRangeResults.Columns["Purpose"].HeaderText = "Purpose";
                                dgvDateRangeResults.Columns["StatusText"].HeaderText = "Status";
                                dgvDateRangeResults.Columns["SubmittedDate"].HeaderText = "Submitted";
                                dgvDateRangeResults.Columns["ResolvedDate"].HeaderText = "Resolved";
                                dgvDateRangeResults.Columns["Comments"].HeaderText = "Comments";

                                dgvDateRangeResults.Columns["RequestedAmount"].DefaultCellStyle.Format = "C2";
                                dgvDateRangeResults.Columns["RequestedAmount"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                                dgvDateRangeResults.Columns["SubmittedDate"].DefaultCellStyle.Format = "g";
                                dgvDateRangeResults.Columns["ResolvedDate"].DefaultCellStyle.Format = "g";

                                foreach (DataGridViewRow row in dgvDateRangeResults.Rows)
                                {
                                    var status = row.Cells["StatusText"].Value?.ToString();
                                    if (status == "Approved")
                                        row.Cells["StatusText"].Style.ForeColor = Color.Green;
                                    else if (status == "Disapproved")
                                        row.Cells["StatusText"].Style.ForeColor = Color.Red;
                                    else if (status == "Pending")
                                        row.Cells["StatusText"].Style.ForeColor = Color.Orange;
                                }
                            }
                        }
                        else
                        {
                            dgvDateRangeResults.DataSource = null;
                        }

                        // Summary totals
                        if (ds.Tables.Count > 1 && ds.Tables[1].Rows.Count > 0)
                        {
                            var row = ds.Tables[1].Rows[0];
                            lblTotalRequests.Text = $"Total Requests: {row["TotalRequests"]}";
                            lblTotalApproved.Text = $"Approved Amount: {Convert.ToDecimal(row["TotalApprovedAmount"]):C2}";
                            lblTotalPending.Text = $"Pending Amount: {Convert.ToDecimal(row["TotalPendingAmount"]):C2}";
                            lblTotalDisapproved.Text = $"Disapproved Amount: {Convert.ToDecimal(row["TotalDisapprovedAmount"]):C2}";
                        }
                        else
                        {
                            lblTotalRequests.Text = "Total Requests: 0";
                            lblTotalApproved.Text = "Approved Amount: $0.00";
                            lblTotalPending.Text = "Pending Amount: $0.00";
                            lblTotalDisapproved.Text = "Disapproved Amount: $0.00";
                        }

                        lblMessage.Text = "Statistics loaded.";
                        lblMessage.ForeColor = Color.Green;
                    }
                }
            }
            catch (Exception ex)
            {
                lblMessage.Text = "Error: " + ex.Message;
                lblMessage.ForeColor = Color.Red;
            }
        }
    }
}