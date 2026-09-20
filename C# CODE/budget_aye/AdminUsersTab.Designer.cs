using System.Drawing;

namespace budget_eye
{
    partial class AdminUsersTab
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        private void InitializeComponent()
        {
            splitContainerMain = new SplitContainer();
            splitContainerLeft = new SplitContainer();
            dgvUsers = new DataGridView();
            dgvDeletedUsers = new DataGridView();
            lblMessage = new Label();
            grpUpdate = new GroupBox();
            btnDelete = new Button();
            btnUpdate = new Button();
            cmbRoleUpdate = new ComboBox();
            txtDisplayNameUpdate = new TextBox();
            txtEmailUpdate = new TextBox();
            txtPasswordUpdate = new TextBox();
            txtUsernameUpdate = new TextBox();
            lblRoleUpdate = new Label();
            lblDisplayNameUpdate = new Label();
            lblEmailUpdate = new Label();
            lblPasswordUpdate = new Label();
            lblUsernameUpdate = new Label();
            lblSelectedId = new Label();
            grpCreate = new GroupBox();
            btnCreate = new Button();
            cmbRole = new ComboBox();
            txtDisplayName = new TextBox();
            txtEmail = new TextBox();
            txtPassword = new TextBox();
            txtUsername = new TextBox();
            lblRole = new Label();
            lblDisplayName = new Label();
            lblEmail = new Label();
            lblPassword = new Label();
            lblUsername = new Label();
            ((System.ComponentModel.ISupportInitialize)splitContainerMain).BeginInit();
            splitContainerMain.Panel1.SuspendLayout();
            splitContainerMain.Panel2.SuspendLayout();
            splitContainerMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainerLeft).BeginInit();
            splitContainerLeft.Panel1.SuspendLayout();
            splitContainerLeft.Panel2.SuspendLayout();
            splitContainerLeft.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvUsers).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvDeletedUsers).BeginInit();
            grpUpdate.SuspendLayout();
            grpCreate.SuspendLayout();
            SuspendLayout();
            // 
            // splitContainerMain
            // 
            splitContainerMain.Dock = DockStyle.Fill;
            splitContainerMain.Location = new Point(0, 0);
            splitContainerMain.Name = "splitContainerMain";
            // 
            // splitContainerMain.Panel1
            // 
            splitContainerMain.Panel1.Controls.Add(splitContainerLeft);
            // 
            // splitContainerMain.Panel2
            // 
            splitContainerMain.Panel2.Controls.Add(lblMessage);
            splitContainerMain.Panel2.Controls.Add(grpUpdate);
            splitContainerMain.Panel2.Controls.Add(grpCreate);
            splitContainerMain.Panel2.Paint += splitContainerMain_Panel2_Paint;
            splitContainerMain.Size = new Size(1100, 750);
            splitContainerMain.SplitterDistance = 733;
            splitContainerMain.TabIndex = 0;
            // 
            // splitContainerLeft
            // 
            splitContainerLeft.Dock = DockStyle.Fill;
            splitContainerLeft.Location = new Point(0, 0);
            splitContainerLeft.Name = "splitContainerLeft";
            splitContainerLeft.Orientation = Orientation.Horizontal;
            // 
            // splitContainerLeft.Panel1
            // 
            splitContainerLeft.Panel1.Controls.Add(dgvUsers);
            // 
            // splitContainerLeft.Panel2
            // 
            splitContainerLeft.Panel2.Controls.Add(dgvDeletedUsers);
            splitContainerLeft.Size = new Size(733, 750);
            splitContainerLeft.SplitterDistance = 400;
            splitContainerLeft.TabIndex = 0;
            // 
            // dgvUsers
            // 
            dgvUsers.AllowUserToAddRows = false;
            dgvUsers.AllowUserToDeleteRows = false;
            dgvUsers.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvUsers.BackgroundColor = Color.White;
            dgvUsers.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvUsers.Dock = DockStyle.Fill;
            dgvUsers.Font = new Font("Segoe UI", 10F);
            dgvUsers.Location = new Point(0, 0);
            dgvUsers.Name = "dgvUsers";
            dgvUsers.ReadOnly = true;
            dgvUsers.RowHeadersVisible = false;
            dgvUsers.RowHeadersWidth = 51;
            dgvUsers.Size = new Size(733, 400);
            dgvUsers.TabIndex = 0;
            dgvUsers.CellClick += dgvUsers_CellClick;
            // 
            // dgvDeletedUsers
            // 
            dgvDeletedUsers.AllowUserToAddRows = false;
            dgvDeletedUsers.AllowUserToDeleteRows = false;
            dgvDeletedUsers.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvDeletedUsers.BackgroundColor = Color.WhiteSmoke;
            dgvDeletedUsers.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvDeletedUsers.Dock = DockStyle.Fill;
            dgvDeletedUsers.Font = new Font("Segoe UI", 10F);
            dgvDeletedUsers.Location = new Point(0, 0);
            dgvDeletedUsers.Name = "dgvDeletedUsers";
            dgvDeletedUsers.ReadOnly = true;
            dgvDeletedUsers.RowHeadersVisible = false;
            dgvDeletedUsers.RowHeadersWidth = 51;
            dgvDeletedUsers.Size = new Size(733, 346);
            dgvDeletedUsers.TabIndex = 0;
            // 
            // lblMessage
            // 
            lblMessage.AutoSize = true;
            lblMessage.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblMessage.Location = new Point(10, 720);
            lblMessage.Name = "lblMessage";
            lblMessage.Size = new Size(0, 23);
            lblMessage.TabIndex = 2;
            // 
            // grpUpdate
            // 
            grpUpdate.Controls.Add(btnDelete);
            grpUpdate.Controls.Add(btnUpdate);
            grpUpdate.Controls.Add(cmbRoleUpdate);
            grpUpdate.Controls.Add(txtDisplayNameUpdate);
            grpUpdate.Controls.Add(txtEmailUpdate);
            grpUpdate.Controls.Add(txtPasswordUpdate);
            grpUpdate.Controls.Add(txtUsernameUpdate);
            grpUpdate.Controls.Add(lblRoleUpdate);
            grpUpdate.Controls.Add(lblDisplayNameUpdate);
            grpUpdate.Controls.Add(lblEmailUpdate);
            grpUpdate.Controls.Add(lblPasswordUpdate);
            grpUpdate.Controls.Add(lblUsernameUpdate);
            grpUpdate.Controls.Add(lblSelectedId);
            grpUpdate.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            grpUpdate.Location = new Point(40, 330);
            grpUpdate.Name = "grpUpdate";
            grpUpdate.Size = new Size(340, 380);
            grpUpdate.TabIndex = 1;
            grpUpdate.TabStop = false;
            grpUpdate.Text = "Update / Delete User";
            // 
            // btnDelete
            // 
            btnDelete.BackColor = Color.Crimson;
            btnDelete.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            btnDelete.ForeColor = Color.White;
            btnDelete.Location = new Point(177, 280);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(120, 40);
            btnDelete.TabIndex = 12;
            btnDelete.Text = "DELETE";
            btnDelete.UseVisualStyleBackColor = false;
            btnDelete.Click += btnDelete_Click;
            // 
            // btnUpdate
            // 
            btnUpdate.BackColor = Color.Orange;
            btnUpdate.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            btnUpdate.ForeColor = Color.White;
            btnUpdate.Location = new Point(37, 280);
            btnUpdate.Name = "btnUpdate";
            btnUpdate.Size = new Size(120, 40);
            btnUpdate.TabIndex = 11;
            btnUpdate.Text = "UPDATE";
            btnUpdate.UseVisualStyleBackColor = false;
            btnUpdate.Click += btnUpdate_Click;
            // 
            // cmbRoleUpdate
            // 
            cmbRoleUpdate.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbRoleUpdate.Font = new Font("Segoe UI", 10F);
            cmbRoleUpdate.FormattingEnabled = true;
            cmbRoleUpdate.Location = new Point(132, 178);
            cmbRoleUpdate.Name = "cmbRoleUpdate";
            cmbRoleUpdate.Size = new Size(200, 31);
            cmbRoleUpdate.TabIndex = 8;
            // 
            // txtDisplayNameUpdate
            // 
            txtDisplayNameUpdate.Font = new Font("Segoe UI", 10F);
            txtDisplayNameUpdate.Location = new Point(132, 223);
            txtDisplayNameUpdate.Name = "txtDisplayNameUpdate";
            txtDisplayNameUpdate.Size = new Size(200, 30);
            txtDisplayNameUpdate.TabIndex = 10;
            // 
            // txtEmailUpdate
            // 
            txtEmailUpdate.Font = new Font("Segoe UI", 10F);
            txtEmailUpdate.Location = new Point(132, 138);
            txtEmailUpdate.Name = "txtEmailUpdate";
            txtEmailUpdate.Size = new Size(200, 30);
            txtEmailUpdate.TabIndex = 6;
            // 
            // txtPasswordUpdate
            // 
            txtPasswordUpdate.Font = new Font("Segoe UI", 10F);
            txtPasswordUpdate.Location = new Point(132, 98);
            txtPasswordUpdate.Name = "txtPasswordUpdate";
            txtPasswordUpdate.Size = new Size(200, 30);
            txtPasswordUpdate.TabIndex = 4;
            // 
            // txtUsernameUpdate
            // 
            txtUsernameUpdate.Font = new Font("Segoe UI", 10F);
            txtUsernameUpdate.Location = new Point(132, 58);
            txtUsernameUpdate.Name = "txtUsernameUpdate";
            txtUsernameUpdate.Size = new Size(200, 30);
            txtUsernameUpdate.TabIndex = 2;
            // 
            // lblRoleUpdate
            // 
            lblRoleUpdate.AutoSize = true;
            lblRoleUpdate.Font = new Font("Segoe UI", 10F);
            lblRoleUpdate.Location = new Point(15, 180);
            lblRoleUpdate.Name = "lblRoleUpdate";
            lblRoleUpdate.Size = new Size(43, 23);
            lblRoleUpdate.TabIndex = 7;
            lblRoleUpdate.Text = "Role";
            // 
            // lblDisplayNameUpdate
            // 
            lblDisplayNameUpdate.AutoSize = true;
            lblDisplayNameUpdate.Font = new Font("Segoe UI", 10F);
            lblDisplayNameUpdate.Location = new Point(15, 225);
            lblDisplayNameUpdate.Name = "lblDisplayNameUpdate";
            lblDisplayNameUpdate.Size = new Size(115, 23);
            lblDisplayNameUpdate.TabIndex = 9;
            lblDisplayNameUpdate.Text = "Display Name";
            // 
            // lblEmailUpdate
            // 
            lblEmailUpdate.AutoSize = true;
            lblEmailUpdate.Font = new Font("Segoe UI", 10F);
            lblEmailUpdate.Location = new Point(15, 140);
            lblEmailUpdate.Name = "lblEmailUpdate";
            lblEmailUpdate.Size = new Size(51, 23);
            lblEmailUpdate.TabIndex = 5;
            lblEmailUpdate.Text = "Email";
            // 
            // lblPasswordUpdate
            // 
            lblPasswordUpdate.AutoSize = true;
            lblPasswordUpdate.Font = new Font("Segoe UI", 10F);
            lblPasswordUpdate.Location = new Point(15, 100);
            lblPasswordUpdate.Name = "lblPasswordUpdate";
            lblPasswordUpdate.Size = new Size(80, 23);
            lblPasswordUpdate.TabIndex = 3;
            lblPasswordUpdate.Text = "Password";
            // 
            // lblUsernameUpdate
            // 
            lblUsernameUpdate.AutoSize = true;
            lblUsernameUpdate.Font = new Font("Segoe UI", 10F);
            lblUsernameUpdate.Location = new Point(15, 60);
            lblUsernameUpdate.Name = "lblUsernameUpdate";
            lblUsernameUpdate.Size = new Size(87, 23);
            lblUsernameUpdate.TabIndex = 1;
            lblUsernameUpdate.Text = "Username";
            // 
            // lblSelectedId
            // 
            lblSelectedId.AutoSize = true;
            lblSelectedId.Font = new Font("Segoe UI", 10F, FontStyle.Italic);
            lblSelectedId.ForeColor = Color.Gray;
            lblSelectedId.Location = new Point(15, 25);
            lblSelectedId.Name = "lblSelectedId";
            lblSelectedId.Size = new Size(173, 23);
            lblSelectedId.TabIndex = 0;
            lblSelectedId.Text = "Select a user from grid";
            // 
            // grpCreate
            // 
            grpCreate.Controls.Add(btnCreate);
            grpCreate.Controls.Add(cmbRole);
            grpCreate.Controls.Add(txtDisplayName);
            grpCreate.Controls.Add(txtEmail);
            grpCreate.Controls.Add(txtPassword);
            grpCreate.Controls.Add(txtUsername);
            grpCreate.Controls.Add(lblRole);
            grpCreate.Controls.Add(lblDisplayName);
            grpCreate.Controls.Add(lblEmail);
            grpCreate.Controls.Add(lblPassword);
            grpCreate.Controls.Add(lblUsername);
            grpCreate.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            grpCreate.Location = new Point(40, 10);
            grpCreate.Name = "grpCreate";
            grpCreate.Size = new Size(340, 300);
            grpCreate.TabIndex = 0;
            grpCreate.TabStop = false;
            grpCreate.Text = "Create New User";
            // 
            // btnCreate
            // 
            btnCreate.BackColor = Color.DodgerBlue;
            btnCreate.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            btnCreate.ForeColor = Color.White;
            btnCreate.Location = new Point(107, 245);
            btnCreate.Name = "btnCreate";
            btnCreate.Size = new Size(120, 40);
            btnCreate.TabIndex = 10;
            btnCreate.Text = "CREATE";
            btnCreate.UseVisualStyleBackColor = false;
            btnCreate.Click += btnCreate_Click;
            // 
            // cmbRole
            // 
            cmbRole.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbRole.Font = new Font("Segoe UI", 10F);
            cmbRole.FormattingEnabled = true;
            cmbRole.Location = new Point(132, 153);
            cmbRole.Name = "cmbRole";
            cmbRole.Size = new Size(200, 31);
            cmbRole.TabIndex = 7;
            // 
            // txtDisplayName
            // 
            txtDisplayName.Font = new Font("Segoe UI", 10F);
            txtDisplayName.Location = new Point(132, 198);
            txtDisplayName.Name = "txtDisplayName";
            txtDisplayName.Size = new Size(200, 30);
            txtDisplayName.TabIndex = 9;
            // 
            // txtEmail
            // 
            txtEmail.Font = new Font("Segoe UI", 10F);
            txtEmail.Location = new Point(132, 113);
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(200, 30);
            txtEmail.TabIndex = 5;
            // 
            // txtPassword
            // 
            txtPassword.Font = new Font("Segoe UI", 10F);
            txtPassword.Location = new Point(132, 73);
            txtPassword.Name = "txtPassword";
            txtPassword.Size = new Size(200, 30);
            txtPassword.TabIndex = 3;
            // 
            // txtUsername
            // 
            txtUsername.Font = new Font("Segoe UI", 10F);
            txtUsername.Location = new Point(132, 33);
            txtUsername.Name = "txtUsername";
            txtUsername.Size = new Size(200, 30);
            txtUsername.TabIndex = 1;
            // 
            // lblRole
            // 
            lblRole.AutoSize = true;
            lblRole.Font = new Font("Segoe UI", 10F);
            lblRole.Location = new Point(15, 155);
            lblRole.Name = "lblRole";
            lblRole.Size = new Size(43, 23);
            lblRole.TabIndex = 6;
            lblRole.Text = "Role";
            // 
            // lblDisplayName
            // 
            lblDisplayName.AutoSize = true;
            lblDisplayName.Font = new Font("Segoe UI", 10F);
            lblDisplayName.Location = new Point(15, 200);
            lblDisplayName.Name = "lblDisplayName";
            lblDisplayName.Size = new Size(115, 23);
            lblDisplayName.TabIndex = 8;
            lblDisplayName.Text = "Display Name";
            // 
            // lblEmail
            // 
            lblEmail.AutoSize = true;
            lblEmail.Font = new Font("Segoe UI", 10F);
            lblEmail.Location = new Point(15, 115);
            lblEmail.Name = "lblEmail";
            lblEmail.Size = new Size(51, 23);
            lblEmail.TabIndex = 4;
            lblEmail.Text = "Email";
            // 
            // lblPassword
            // 
            lblPassword.AutoSize = true;
            lblPassword.Font = new Font("Segoe UI", 10F);
            lblPassword.Location = new Point(15, 75);
            lblPassword.Name = "lblPassword";
            lblPassword.Size = new Size(80, 23);
            lblPassword.TabIndex = 2;
            lblPassword.Text = "Password";
            // 
            // lblUsername
            // 
            lblUsername.AutoSize = true;
            lblUsername.Font = new Font("Segoe UI", 10F);
            lblUsername.Location = new Point(15, 35);
            lblUsername.Name = "lblUsername";
            lblUsername.Size = new Size(87, 23);
            lblUsername.TabIndex = 0;
            lblUsername.Text = "Username";
            // 
            // AdminUsersTab
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            Controls.Add(splitContainerMain);
            Name = "AdminUsersTab";
            Size = new Size(1100, 750);
            splitContainerMain.Panel1.ResumeLayout(false);
            splitContainerMain.Panel2.ResumeLayout(false);
            splitContainerMain.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainerMain).EndInit();
            splitContainerMain.ResumeLayout(false);
            splitContainerLeft.Panel1.ResumeLayout(false);
            splitContainerLeft.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainerLeft).EndInit();
            splitContainerLeft.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvUsers).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvDeletedUsers).EndInit();
            grpUpdate.ResumeLayout(false);
            grpUpdate.PerformLayout();
            grpCreate.ResumeLayout(false);
            grpCreate.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private SplitContainer splitContainerMain;
        private SplitContainer splitContainerLeft;
        private DataGridView dgvUsers;
        private DataGridView dgvDeletedUsers;
        private GroupBox grpCreate;
        private Button btnCreate;
        private ComboBox cmbRole;
        private TextBox txtDisplayName;
        private TextBox txtEmail;
        private TextBox txtPassword;
        private TextBox txtUsername;
        private Label lblRole;
        private Label lblDisplayName;
        private Label lblEmail;
        private Label lblPassword;
        private Label lblUsername;
        private GroupBox grpUpdate;
        private Button btnDelete;
        private Button btnUpdate;
        private ComboBox cmbRoleUpdate;
        private TextBox txtDisplayNameUpdate;
        private TextBox txtEmailUpdate;
        private TextBox txtPasswordUpdate;
        private TextBox txtUsernameUpdate;
        private Label lblRoleUpdate;
        private Label lblDisplayNameUpdate;
        private Label lblEmailUpdate;
        private Label lblPasswordUpdate;
        private Label lblUsernameUpdate;
        private Label lblSelectedId;
        private Label lblMessage;
    }
}