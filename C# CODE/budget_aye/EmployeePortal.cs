using System;
using System.Drawing;
using System.Windows.Forms;

namespace budget_eye
{
    public partial class EmployeePortal : UserControl
    {
        private Application _app;

        public EmployeePortal(Application app)
        {
            InitializeComponent();
            _app = app;
            LoadMyRequests();
        }

        private void LoadMyRequests()
        {
            var requests = _app.GetRequests();

            dgvMyRequests.DataSource = null;
            dgvMyRequests.DataSource = requests;

            if (dgvMyRequests.Columns.Count == 0) return;

            dgvMyRequests.Columns["EmployeeId"].Visible = false;
            dgvMyRequests.Columns["ApprovedBy"].Visible = false;
            dgvMyRequests.Columns["RequiresSenior"].Visible = false;

            dgvMyRequests.Columns["ApplicationId"].HeaderText = "Request ID";
            dgvMyRequests.Columns["RequestedAmount"].HeaderText = "Amount";
            dgvMyRequests.Columns["Purpose"].HeaderText = "Purpose";
            dgvMyRequests.Columns["Status"].HeaderText = "Status";
            dgvMyRequests.Columns["SubmittedDate"].HeaderText = "Submitted";
            dgvMyRequests.Columns["ResolvedDate"].HeaderText = "Resolved";
            dgvMyRequests.Columns["Comments"].HeaderText = "Comments";

            dgvMyRequests.Columns["RequestedAmount"].DefaultCellStyle.Format = "C2";
            dgvMyRequests.Columns["RequestedAmount"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            foreach (DataGridViewRow row in dgvMyRequests.Rows)
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

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            lblMessage.Text = "";
            lblMessage.ForeColor = Color.Black;

            decimal amount = nudAmount.Value;
            string purpose = txtPurpose.Text.Trim();

            if (amount <= 0)
            {
                lblMessage.Text = "Amount must be greater than 0.";
                lblMessage.ForeColor = Color.Red;
                return;
            }

            if (string.IsNullOrWhiteSpace(purpose))
            {
                lblMessage.Text = "Purpose cannot be empty.";
                lblMessage.ForeColor = Color.Red;
                return;
            }

            string result = _app.CreateRequest(amount, purpose);

            if (result == "Request created")
            {
                lblMessage.Text = "Request submitted!";
                lblMessage.ForeColor = Color.Green;
                nudAmount.Value = 0;
                txtPurpose.Clear();
                LoadMyRequests();
            }
            else
            {
                lblMessage.Text = result;
                lblMessage.ForeColor = Color.Red;
            }
        }

        private void EmployeePortal_Load(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void dgvMyRequests_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}