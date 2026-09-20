using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace budget_eye
{
    public partial class SeniorManagerPortal : UserControl
    {
        private Application _app;

        public SeniorManagerPortal(Application app)
        {
            InitializeComponent();
            _app = app;
            LoadAllRequests();
        }

        private void LoadAllRequests()
        {
            var requests = _app.GetRequests(); // SeniorManager sees all requests

            dgvAllRequests.DataSource = null;
            dgvAllRequests.DataSource = requests;

            if (dgvAllRequests.Columns.Count == 0) return;

            dgvAllRequests.Columns["EmployeeId"].Visible = false;
            dgvAllRequests.Columns["ApprovedBy"].Visible = false;
            dgvAllRequests.Columns["RequiresSenior"].Visible = false;

            dgvAllRequests.Columns["ApplicationId"].HeaderText = "Request ID";
            dgvAllRequests.Columns["RequestedAmount"].HeaderText = "Amount";
            dgvAllRequests.Columns["Purpose"].HeaderText = "Purpose";
            dgvAllRequests.Columns["Status"].HeaderText = "Status";
            dgvAllRequests.Columns["SubmittedDate"].HeaderText = "Submitted";
            dgvAllRequests.Columns["ResolvedDate"].HeaderText = "Resolved";
            dgvAllRequests.Columns["Comments"].HeaderText = "Comments";

            dgvAllRequests.Columns["RequestedAmount"].DefaultCellStyle.Format = "C2";
            dgvAllRequests.Columns["RequestedAmount"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            foreach (DataGridViewRow row in dgvAllRequests.Rows)
            {
                var status = row.Cells["Status"].Value?.ToString();
                if (status == "Approved")
                    row.Cells["Status"].Style.ForeColor = Color.Green;
                else if (status == "Disapproved")
                    row.Cells["Status"].Style.ForeColor = Color.Red;
                else if (status == "Pending")
                    row.Cells["Status"].Style.ForeColor = Color.Orange;
            }
        }

        private void LoadAuditLogForRequest(int requestId)
        {
            var allLogs = _app.GetLogs(); // SeniorManager can see all logs
            var filteredLogs = allLogs.Where(l => l.ApplicationId == requestId).ToList();

            dgvAuditLog.DataSource = null;
            dgvAuditLog.DataSource = filteredLogs;

            if (dgvAuditLog.Columns.Count == 0) return;

            dgvAuditLog.Columns["LogId"].HeaderText = "Log ID";
            dgvAuditLog.Columns["ApplicationId"].HeaderText = "Request ID";
            dgvAuditLog.Columns["Action"].HeaderText = "Action";
            dgvAuditLog.Columns["PerformedBy"].HeaderText = "By User ID";
            dgvAuditLog.Columns["Timestamp"].HeaderText = "Date/Time";
            dgvAuditLog.Columns["Details"].HeaderText = "Details";

            dgvAuditLog.Columns["Timestamp"].DefaultCellStyle.Format = "g";
        }

        private int? GetSelectedRequestId()
        {
            if (dgvAllRequests.SelectedRows.Count == 0) return null;
            return Convert.ToInt32(dgvAllRequests.SelectedRows[0].Cells["ApplicationId"].Value);
        }

        private void dgvAllRequests_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            var id = GetSelectedRequestId();
            if (id.HasValue)
                LoadAuditLogForRequest(id.Value);
        }

        private void dgvAllRequests_SelectionChanged(object sender, EventArgs e)
        {
            var id = GetSelectedRequestId();
            if (id.HasValue)
                LoadAuditLogForRequest(id.Value);
        }

        private void btnApprove_Click(object sender, EventArgs e)
        {
            lblMessage.Text = "";
            var id = GetSelectedRequestId();
            if (id == null)
            {
                lblMessage.Text = "Please select a request.";
                lblMessage.ForeColor = Color.Red;
                return;
            }

            string result = _app.ApproveRequest(id.Value, txtComments.Text.Trim());

            if (result == "Approved")
            {
                lblMessage.Text = "Request approved!";
                lblMessage.ForeColor = Color.Green;
                txtComments.Clear();
                LoadAllRequests();
                LoadAuditLogForRequest(id.Value);
            }
            else
            {
                lblMessage.Text = result;
                lblMessage.ForeColor = Color.Red;
            }
        }

        private void btnDisapprove_Click(object sender, EventArgs e)
        {
            lblMessage.Text = "";
            var id = GetSelectedRequestId();
            if (id == null)
            {
                lblMessage.Text = "Please select a request.";
                lblMessage.ForeColor = Color.Red;
                return;
            }

            string result = _app.DisapproveRequest(id.Value, txtComments.Text.Trim());

            if (result == "Disapproved")
            {
                lblMessage.Text = "Request disapproved.";
                lblMessage.ForeColor = Color.Green;
                txtComments.Clear();
                LoadAllRequests();
                LoadAuditLogForRequest(id.Value);
            }
            else
            {
                lblMessage.Text = result;
                lblMessage.ForeColor = Color.Red;
            }
        }
    }
}