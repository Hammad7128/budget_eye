using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using Microsoft.Data.SqlClient;

namespace budget_eye
{
    public partial class AdminConfigurationsTab : UserControl
    {
        private string _connString = "Server=DESKTOP-9LNIKCT\\SQLEXPRESS;Database=BudgetEyeDB;Trusted_Connection=True;TrustServerCertificate=True;";
        private Application _app;

        public AdminConfigurationsTab(Application app)
        {
            InitializeComponent();
            _app = app;
            LoadAllConfigurations();
            ShowCurrentThreshold();
        }

        private void LoadAllConfigurations()
        {
            try
            {
                using (var conn = new SqlConnection(_connString))
                {
                    conn.Open();
                    using (var cmd = new SqlCommand("sp_GetAllConfigurations", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        var adapter = new SqlDataAdapter(cmd);
                        var table = new DataTable();
                        adapter.Fill(table);

                        dgvAllConfigs.DataSource = table;

                        if (dgvAllConfigs.Columns.Count == 0) return;

                        dgvAllConfigs.Columns["ConfigId"].HeaderText = "Config ID";
                        dgvAllConfigs.Columns["ThresholdAmount"].HeaderText = "Threshold";
                        dgvAllConfigs.Columns["SetByAdminId"].Visible = false;
                        dgvAllConfigs.Columns["SetByName"].HeaderText = "Set By";
                        dgvAllConfigs.Columns["EffectiveDate"].HeaderText = "Effective Date";
                        dgvAllConfigs.Columns["IsActive"].HeaderText = "Active";

                        dgvAllConfigs.Columns["ThresholdAmount"].DefaultCellStyle.Format = "C2";
                        dgvAllConfigs.Columns["ThresholdAmount"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                        dgvAllConfigs.Columns["EffectiveDate"].DefaultCellStyle.Format = "g";

                        foreach (DataGridViewRow row in dgvAllConfigs.Rows)
                        {
                            var isActive = Convert.ToBoolean(row.Cells["IsActive"].Value);
                            if (isActive)
                            {
                                row.Cells["IsActive"].Style.ForeColor = Color.SeaGreen;
                                row.Cells["IsActive"].Style.Font = new Font(dgvAllConfigs.Font, FontStyle.Bold);
                                row.DefaultCellStyle.BackColor = Color.Honeydew;
                            }
                            else
                            {
                                row.Cells["IsActive"].Style.ForeColor = Color.Gray;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading configurations: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ShowCurrentThreshold()
        {
            decimal current = Configuration.GetCurrentThreshold();
            lblCurrentThreshold.Text = $"Current Active Threshold: {current:C2}";
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            lblMessage.Text = "";
            lblMessage.ForeColor = Color.Black;

            decimal amount = nudThreshold.Value;

            if (amount <= 0)
            {
                lblMessage.Text = "Threshold must be greater than 0.";
                lblMessage.ForeColor = Color.Red;
                return;
            }

            string result = _app.SetThreshold(amount);

            if (result == "Threshold updated")
            {
                lblMessage.Text = "New configuration created and activated!";
                lblMessage.ForeColor = Color.Green;
                nudThreshold.Value = 0;
                LoadAllConfigurations();
                ShowCurrentThreshold();
            }
            else
            {
                lblMessage.Text = result;
                lblMessage.ForeColor = Color.Red;
            }
        }
    }
}