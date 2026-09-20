using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace budget_eye
{
    public partial class ManagerPortal : UserControl
    {
        private Application _app;

        public ManagerPortal(Application app)
        {
            InitializeComponent();
            _app = app;
            ShowThreshold();
            LoadManagerRequests();
        }

        private void ShowThreshold()
        {
            decimal threshold = Configuration.GetCurrentThreshold();
            lblThreshold.Text = $"Threshold: {threshold:C2}\n(Requests above this need Senior Manager approval)";
        }

        private void LoadManagerRequests()
        {
            var user = _app.GetCurrentUser();
            if (user == null) return;

            // Get all requests
            var allRequests = _app.GetRequests();

            // Filter: Pending OR Approved/Disapproved by this manager
            var filtered = allRequests.Where(r =>
                r.Status == BudgetStatus.Pending ||
                (r.Status != BudgetStatus.Pending && r.ApprovedBy == user.UserId)
            ).ToList();

            dgvRequests.DataSource = null;
            dgvRequests.DataSource = filtered;

            if (dgvRequests.Columns.Count == 0) return;

            dgvRequests.Columns["EmployeeId"].Visible = false;
            dgvRequests.Columns["RequiresSenior"].Visible = false;

            dgvRequests.Columns["ApplicationId"].HeaderText = "Request ID";
            dgvRequests.Columns["RequestedAmount"].HeaderText = "Amount";
            dgvRequests.Columns["Purpose"].HeaderText = "Purpose";
            dgvRequests.Columns["Status"].HeaderText = "Status";
            dgvRequests.Columns["SubmittedDate"].HeaderText = "Submitted";
            dgvRequests.Columns["ResolvedDate"].HeaderText = "Resolved";
            dgvRequests.Columns["ApprovedBy"].HeaderText = "Approved By";
            dgvRequests.Columns["Comments"].HeaderText = "Comments";

            dgvRequests.Columns["RequestedAmount"].DefaultCellStyle.Format = "C2";
            dgvRequests.Columns["RequestedAmount"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            // Color status
            foreach (DataGridViewRow row in dgvRequests.Rows)
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

        private int? GetSelectedRequestId()
        {
            if (dgvRequests.SelectedRows.Count == 0) return null;
            return Convert.ToInt32(dgvRequests.SelectedRows[0].Cells["ApplicationId"].Value);
        }

        private bool IsPendingRequest(int requestId)
        {
            var req = _app.GetRequests().FirstOrDefault(r => r.ApplicationId == requestId);
            return req != null && req.Status == BudgetStatus.Pending;
        }

        private bool RequiresSeniorApproval(int requestId)
        {
            var req = _app.GetRequests().FirstOrDefault(r => r.ApplicationId == requestId);
            return req != null && req.RequiresSenior;
        }

        private void dgvRequests_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            lblMessage.Text = "";
        }

        private void dgvRequests_SelectionChanged(object sender, EventArgs e)
        {
            lblMessage.Text = "";
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

            if (!IsPendingRequest(id.Value))
            {
                lblMessage.Text = "This request is already resolved.";
                lblMessage.ForeColor = Color.Red;
                return;
            }

            if (RequiresSeniorApproval(id.Value))
            {
                lblMessage.Text = "This request exceeds threshold. Only Senior Manager can approve.";
                lblMessage.ForeColor = Color.Red;
                return;
            }

            string result = _app.ApproveRequest(id.Value, txtComments.Text.Trim());

            if (result == "Approved")
            {
                lblMessage.Text = "Request approved!";
                lblMessage.ForeColor = Color.Green;
                txtComments.Clear();
                LoadManagerRequests();
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

            if (!IsPendingRequest(id.Value))
            {
                lblMessage.Text = "This request is already resolved.";
                lblMessage.ForeColor = Color.Red;
                return;
            }

            if (RequiresSeniorApproval(id.Value))
            {
                lblMessage.Text = "This request exceeds threshold. Only Senior Manager can disapprove.";
                lblMessage.ForeColor = Color.Red;
                return;
            }

            string result = _app.DisapproveRequest(id.Value, txtComments.Text.Trim());

            if (result == "Disapproved")
            {
                lblMessage.Text = "Request disapproved.";
                lblMessage.ForeColor = Color.Green;
                txtComments.Clear();
                LoadManagerRequests();
            }
            else
            {
                lblMessage.Text = result;
                lblMessage.ForeColor = Color.Red;
            }
        }

        private void splitContainer1_Panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void grpInfo_Enter(object sender, EventArgs e)
        {

        }

        private void dgvRequests_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}