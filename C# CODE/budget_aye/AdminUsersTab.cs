using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using Microsoft.Data.SqlClient;

namespace budget_eye
{
    public partial class AdminUsersTab : UserControl
    {
        private string _connString = "Server=DESKTOP-9LNIKCT\\SQLEXPRESS;Database=BudgetEyeDB;Trusted_Connection=True;TrustServerCertificate=True;";
        private int? _selectedUserId = null;

        public AdminUsersTab()
        {
            InitializeComponent();
            LoadRoles();
            LoadRolesUpdate();
            LoadUsersFromDb();
            LoadDeletedUsersFromDb();
        }

        private void LoadRoles()
        {
            cmbRole.Items.Add("Administrator");
            cmbRole.Items.Add("SeniorManager");
            cmbRole.Items.Add("Manager");
            cmbRole.Items.Add("Employee");
            cmbRole.SelectedIndex = 3;
        }

        private void LoadRolesUpdate()
        {
            cmbRoleUpdate.Items.Add("Administrator");
            cmbRoleUpdate.Items.Add("SeniorManager");
            cmbRoleUpdate.Items.Add("Manager");
            cmbRoleUpdate.Items.Add("Employee");
            cmbRoleUpdate.SelectedIndex = 3;
        }

        private void LoadUsersFromDb()
        {
            using (var conn = new SqlConnection(_connString))
            {
                conn.Open();
                using (var cmd = new SqlCommand("sp_GetAllUsers", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    var adapter = new SqlDataAdapter(cmd);
                    var table = new DataTable();
                    adapter.Fill(table);
                    dgvUsers.DataSource = table;

                    dgvUsers.Columns["Password"].Visible = false;
                    dgvUsers.Columns["UserId"].HeaderText = "ID";
                    dgvUsers.Columns["UserName"].HeaderText = "Username";
                    dgvUsers.Columns["DisplayName"].HeaderText = "Name";
                    dgvUsers.Columns["Email"].HeaderText = "Email";
                    dgvUsers.Columns["Role"].HeaderText = "Role";
                    dgvUsers.Columns["Timestamp"].HeaderText = "Created";
                }
            }
        }

        private void LoadDeletedUsersFromDb()
        {
            using (var conn = new SqlConnection(_connString))
            {
                conn.Open();
                using (var cmd = new SqlCommand("sp_GetDeletedUsers", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    var adapter = new SqlDataAdapter(cmd);
                    var table = new DataTable();
                    adapter.Fill(table);
                    dgvDeletedUsers.DataSource = table;

                    dgvDeletedUsers.Columns["UserId"].HeaderText = "ID";
                    dgvDeletedUsers.Columns["UserName"].HeaderText = "Username";
                    dgvDeletedUsers.Columns["DisplayName"].HeaderText = "Name";
                    dgvDeletedUsers.Columns["Email"].HeaderText = "Email";
                    dgvDeletedUsers.Columns["Role"].HeaderText = "Role";
                    dgvDeletedUsers.Columns["OriginalTimestamp"].HeaderText = "Original Created";
                    dgvDeletedUsers.Columns["DeletionTime"].HeaderText = "Deleted On";
                }
            }
        }

        private void dgvUsers_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            if (dgvUsers.Rows.Count == 0) return;

            var row = dgvUsers.Rows[e.RowIndex];
            _selectedUserId = Convert.ToInt32(row.Cells["UserId"].Value);

            txtUsernameUpdate.Text = row.Cells["UserName"].Value?.ToString();
            txtPasswordUpdate.Text = row.Cells["Password"].Value?.ToString();
            txtEmailUpdate.Text = row.Cells["Email"].Value?.ToString();
            txtDisplayNameUpdate.Text = row.Cells["DisplayName"].Value?.ToString();
            cmbRoleUpdate.SelectedIndex = Convert.ToInt32(row.Cells["Role"].Value);

            lblSelectedId.Text = $"Selected ID: {_selectedUserId}";
            lblSelectedId.ForeColor = Color.DodgerBlue;
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            lblMessage.Text = "";
            lblMessage.ForeColor = Color.Black;

            if (!ValidateInputs(txtUsername, txtPassword, txtEmail, txtDisplayName)) return;

            try
            {
                using (var conn = new SqlConnection(_connString))
                {
                    conn.Open();
                    using (var cmd = new SqlCommand("sp_CreateUser", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@UserName", txtUsername.Text.Trim());
                        cmd.Parameters.AddWithValue("@Password", txtPassword.Text);
                        cmd.Parameters.AddWithValue("@Email", txtEmail.Text.Trim());
                        cmd.Parameters.AddWithValue("@Role", cmbRole.SelectedIndex);
                        cmd.Parameters.AddWithValue("@DisplayName", txtDisplayName.Text.Trim());

                        var result = cmd.ExecuteScalar();
                        int newId = Convert.ToInt32(result);

                        lblMessage.Text = $"User created! ID: {newId}";
                        lblMessage.ForeColor = Color.Green;

                        ClearCreateForm();
                        LoadUsersFromDb();
                    }
                }
            }
            catch (Exception ex)
            {
                lblMessage.Text = "Error: " + ex.Message;
                lblMessage.ForeColor = Color.Red;
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            lblMessage.Text = "";
            lblMessage.ForeColor = Color.Black;

            if (_selectedUserId == null)
            {
                lblMessage.Text = "Please select a user from the grid first.";
                lblMessage.ForeColor = Color.Red;
                return;
            }

            if (!ValidateInputs(txtUsernameUpdate, txtPasswordUpdate, txtEmailUpdate, txtDisplayNameUpdate)) return;

            try
            {
                using (var conn = new SqlConnection(_connString))
                {
                    conn.Open();
                    using (var cmd = new SqlCommand("sp_UpdateUser", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@UserId", _selectedUserId.Value);
                        cmd.Parameters.AddWithValue("@UserName", txtUsernameUpdate.Text.Trim());
                        cmd.Parameters.AddWithValue("@Password", txtPasswordUpdate.Text);
                        cmd.Parameters.AddWithValue("@Email", txtEmailUpdate.Text.Trim());
                        cmd.Parameters.AddWithValue("@Role", cmbRoleUpdate.SelectedIndex);
                        cmd.Parameters.AddWithValue("@DisplayName", txtDisplayNameUpdate.Text.Trim());

                        cmd.ExecuteNonQuery();

                        lblMessage.Text = $"User ID {_selectedUserId} updated!";
                        lblMessage.ForeColor = Color.Green;

                        LoadUsersFromDb();
                    }
                }
            }
            catch (Exception ex)
            {
                lblMessage.Text = "Error: " + ex.Message;
                lblMessage.ForeColor = Color.Red;
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            lblMessage.Text = "";
            lblMessage.ForeColor = Color.Black;

            if (_selectedUserId == null)
            {
                lblMessage.Text = "Please select a user from the grid first.";
                lblMessage.ForeColor = Color.Red;
                return;
            }

            var confirm = MessageBox.Show(
                $"Are you sure you want to delete User ID {_selectedUserId}?\n\nThis will move the user to DeletedUsers table.",
                "Confirm Delete",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);

            if (confirm != DialogResult.Yes) return;

            try
            {
                using (var conn = new SqlConnection(_connString))
                {
                    conn.Open();
                    using (var cmd = new SqlCommand("sp_DeleteUser", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@UserId", _selectedUserId.Value);

                        cmd.ExecuteNonQuery();

                        lblMessage.Text = $"User ID {_selectedUserId} deleted and archived!";
                        lblMessage.ForeColor = Color.Green;

                        _selectedUserId = null;
                        lblSelectedId.Text = "Select a user from grid";
                        lblSelectedId.ForeColor = Color.Gray;

                        ClearUpdateForm();
                        LoadUsersFromDb();
                        LoadDeletedUsersFromDb();
                    }
                }
            }
            catch (Exception ex)
            {
                lblMessage.Text = "Error: " + ex.Message;
                lblMessage.ForeColor = Color.Red;
            }
        }

        private bool ValidateInputs(TextBox username, TextBox password, TextBox email, TextBox displayName)
        {
            if (string.IsNullOrWhiteSpace(username.Text) ||
                string.IsNullOrWhiteSpace(password.Text) ||
                string.IsNullOrWhiteSpace(email.Text) ||
                string.IsNullOrWhiteSpace(displayName.Text))
            {
                lblMessage.Text = "All fields are required.";
                lblMessage.ForeColor = Color.Red;
                return false;
            }

            if (!email.Text.Contains("@"))
            {
                lblMessage.Text = "Invalid email.";
                lblMessage.ForeColor = Color.Red;
                return false;
            }

            if (password.Text.Length < 6)
            {
                lblMessage.Text = "Password must be at least 6 characters.";
                lblMessage.ForeColor = Color.Red;
                return false;
            }

            return true;
        }

        private void ClearCreateForm()
        {
            txtUsername.Clear();
            txtPassword.Clear();
            txtEmail.Clear();
            txtDisplayName.Clear();
            cmbRole.SelectedIndex = 3;
        }

        private void ClearUpdateForm()
        {
            txtUsernameUpdate.Clear();
            txtPasswordUpdate.Clear();
            txtEmailUpdate.Clear();
            txtDisplayNameUpdate.Clear();
            cmbRoleUpdate.SelectedIndex = 3;
        }

        private void splitContainerMain_Panel2_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}