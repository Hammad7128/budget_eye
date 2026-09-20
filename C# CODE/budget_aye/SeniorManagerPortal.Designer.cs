using System.Drawing;

namespace budget_eye
{
    partial class SeniorManagerPortal
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
            splitContainer1 = new SplitContainer();
            dgvAllRequests = new DataGridView();
            grpAudit = new GroupBox();
            dgvAuditLog = new DataGridView();
            grpAction = new GroupBox();
            btnDisapprove = new Button();
            btnApprove = new Button();
            txtComments = new TextBox();
            lblComments = new Label();
            lblMessage = new Label();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
            splitContainer1.Panel1.SuspendLayout();
            splitContainer1.Panel2.SuspendLayout();
            splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvAllRequests).BeginInit();
            grpAudit.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvAuditLog).BeginInit();
            grpAction.SuspendLayout();
            SuspendLayout();

            // splitContainer1
            splitContainer1.Dock = DockStyle.Fill;
            splitContainer1.Location = new Point(0, 0);
            splitContainer1.Name = "splitContainer1";

            // LEFT PANEL — All Requests + Action buttons
            splitContainer1.Panel1.Controls.Add(lblMessage);
            splitContainer1.Panel1.Controls.Add(grpAction);
            splitContainer1.Panel1.Controls.Add(dgvAllRequests);

            // dgvAllRequests
            dgvAllRequests.AllowUserToAddRows = false;
            dgvAllRequests.AllowUserToDeleteRows = false;
            dgvAllRequests.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvAllRequests.BackgroundColor = SystemColors.ButtonHighlight;
            dgvAllRequests.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvAllRequests.Dock = DockStyle.Top;
            dgvAllRequests.Font = new System.Drawing.Font("Segoe UI", 11F, FontStyle.Regular);
            dgvAllRequests.Height = 400;
            dgvAllRequests.Name = "dgvAllRequests";
            dgvAllRequests.ReadOnly = true;
            dgvAllRequests.RowHeadersVisible = false;
            dgvAllRequests.ScrollBars = ScrollBars.Both;
            dgvAllRequests.TabIndex = 0;
            dgvAllRequests.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvAllRequests.MultiSelect = false;
            dgvAllRequests.CellClick += dgvAllRequests_CellClick;
            dgvAllRequests.SelectionChanged += dgvAllRequests_SelectionChanged;

            // grpAction
            grpAction.Controls.Add(btnDisapprove);
            grpAction.Controls.Add(btnApprove);
            grpAction.Controls.Add(txtComments);
            grpAction.Controls.Add(lblComments);
            grpAction.Dock = DockStyle.Bottom;
            grpAction.Font = new System.Drawing.Font("Segoe UI", 11F, FontStyle.Bold);
            grpAction.Height = 200;
            grpAction.Name = "grpAction";
            grpAction.TabIndex = 1;
            grpAction.TabStop = false;
            grpAction.Text = "Approve / Disapprove Request";

            // lblComments
            lblComments.AutoSize = true;
            lblComments.Font = new System.Drawing.Font("Segoe UI", 10F, FontStyle.Regular);
            lblComments.Location = new Point(20, 40);
            lblComments.Name = "lblComments";
            lblComments.Size = new Size(94, 23);
            lblComments.TabIndex = 0;
            lblComments.Text = "Comments:";

            // txtComments
            txtComments.Font = new System.Drawing.Font("Segoe UI", 10F, FontStyle.Regular);
            txtComments.Location = new Point(130, 37);
            txtComments.Name = "txtComments";
            txtComments.Size = new Size(400, 30);
            txtComments.TabIndex = 1;

            // btnApprove
            btnApprove.BackColor = Color.SeaGreen;
            btnApprove.Font = new System.Drawing.Font("Segoe UI", 11F, FontStyle.Bold);
            btnApprove.ForeColor = Color.White;
            btnApprove.Location = new Point(130, 90);
            btnApprove.Name = "btnApprove";
            btnApprove.Size = new Size(140, 45);
            btnApprove.TabIndex = 2;
            btnApprove.Text = "APPROVE";
            btnApprove.UseVisualStyleBackColor = false;
            btnApprove.Click += btnApprove_Click;

            // btnDisapprove
            btnDisapprove.BackColor = Color.Crimson;
            btnDisapprove.Font = new System.Drawing.Font("Segoe UI", 11F, FontStyle.Bold);
            btnDisapprove.ForeColor = Color.White;
            btnDisapprove.Location = new Point(290, 90);
            btnDisapprove.Name = "btnDisapprove";
            btnDisapprove.Size = new Size(160, 45);
            btnDisapprove.TabIndex = 3;
            btnDisapprove.Text = "DISAPPROVE";
            btnDisapprove.UseVisualStyleBackColor = false;
            btnDisapprove.Click += btnDisapprove_Click;

            // lblMessage
            lblMessage.AutoSize = true;
            lblMessage.Font = new System.Drawing.Font("Segoe UI", 10F, FontStyle.Bold);
            lblMessage.Location = new Point(20, 370);
            lblMessage.Name = "lblMessage";
            lblMessage.Size = new Size(0, 23);
            lblMessage.TabIndex = 2;

            // RIGHT PANEL — Audit Log
            splitContainer1.Panel2.Controls.Add(grpAudit);

            // grpAudit
            grpAudit.Controls.Add(dgvAuditLog);
            grpAudit.Dock = DockStyle.Fill;
            grpAudit.Font = new System.Drawing.Font("Segoe UI", 12F, FontStyle.Bold);
            grpAudit.Name = "grpAudit";
            grpAudit.TabIndex = 0;
            grpAudit.TabStop = false;
            grpAudit.Text = "Audit Log for Selected Request";

            // dgvAuditLog
            dgvAuditLog.AllowUserToAddRows = false;
            dgvAuditLog.AllowUserToDeleteRows = false;
            dgvAuditLog.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvAuditLog.BackgroundColor = SystemColors.ButtonHighlight;
            dgvAuditLog.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvAuditLog.Dock = DockStyle.Fill;
            dgvAuditLog.Font = new System.Drawing.Font("Segoe UI", 10F, FontStyle.Regular);
            dgvAuditLog.Name = "dgvAuditLog";
            dgvAuditLog.ReadOnly = true;
            dgvAuditLog.RowHeadersVisible = false;
            dgvAuditLog.ScrollBars = ScrollBars.Both;
            dgvAuditLog.TabIndex = 0;

            // SeniorManagerPortal
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.Window;
            Controls.Add(splitContainer1);
            Name = "SeniorManagerPortal";
            Size = new Size(1500, 700);
            splitContainer1.Panel1.ResumeLayout(false);
            splitContainer1.Panel1.PerformLayout();
            splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
            splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvAllRequests).EndInit();
            grpAudit.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvAuditLog).EndInit();
            grpAction.ResumeLayout(false);
            grpAction.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private SplitContainer splitContainer1;
        private DataGridView dgvAllRequests;
        private GroupBox grpAudit;
        private DataGridView dgvAuditLog;
        private GroupBox grpAction;
        private Button btnDisapprove;
        private Button btnApprove;
        private TextBox txtComments;
        private Label lblComments;
        private Label lblMessage;
    }
}