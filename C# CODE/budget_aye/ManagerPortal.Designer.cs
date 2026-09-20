using System.Drawing;

namespace budget_eye
{
    partial class ManagerPortal
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
            dgvRequests = new DataGridView();
            lblMessage = new Label();
            grpAction = new GroupBox();
            btnDisapprove = new Button();
            btnApprove = new Button();
            txtComments = new TextBox();
            lblComments = new Label();
            grpInfo = new GroupBox();
            lblThreshold = new Label();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
            splitContainer1.Panel1.SuspendLayout();
            splitContainer1.Panel2.SuspendLayout();
            splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvRequests).BeginInit();
            grpAction.SuspendLayout();
            grpInfo.SuspendLayout();
            SuspendLayout();
            // 
            // splitContainer1
            // 
            splitContainer1.Dock = DockStyle.Fill;
            splitContainer1.Location = new Point(0, 0);
            splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            splitContainer1.Panel1.Controls.Add(dgvRequests);
            // 
            // splitContainer1.Panel2
            // 
            splitContainer1.Panel2.Controls.Add(lblMessage);
            splitContainer1.Panel2.Controls.Add(grpAction);
            splitContainer1.Panel2.Controls.Add(grpInfo);
            splitContainer1.Panel2.Paint += splitContainer1_Panel2_Paint;
            splitContainer1.Size = new Size(1500, 700);
            splitContainer1.SplitterDistance = 1027;
            splitContainer1.TabIndex = 0;
            // 
            // dgvRequests
            // 
            dgvRequests.AllowUserToAddRows = false;
            dgvRequests.AllowUserToDeleteRows = false;
            dgvRequests.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvRequests.BackgroundColor = SystemColors.ButtonHighlight;
            dgvRequests.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvRequests.Dock = DockStyle.Fill;
            dgvRequests.Font = new Font("Segoe UI", 11F);
            dgvRequests.Location = new Point(0, 0);
            dgvRequests.MultiSelect = false;
            dgvRequests.Name = "dgvRequests";
            dgvRequests.ReadOnly = true;
            dgvRequests.RowHeadersVisible = false;
            dgvRequests.RowHeadersWidth = 51;
            dgvRequests.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvRequests.Size = new Size(1027, 700);
            dgvRequests.TabIndex = 0;
            dgvRequests.CellClick += dgvRequests_CellClick;
            dgvRequests.CellContentClick += dgvRequests_CellContentClick;
            dgvRequests.SelectionChanged += dgvRequests_SelectionChanged;
            // 
            // lblMessage
            // 
            lblMessage.AutoSize = true;
            lblMessage.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblMessage.Location = new Point(20, 120);
            lblMessage.Name = "lblMessage";
            lblMessage.Size = new Size(0, 23);
            lblMessage.TabIndex = 2;
            // 
            // grpAction
            // 
            grpAction.Controls.Add(btnDisapprove);
            grpAction.Controls.Add(btnApprove);
            grpAction.Controls.Add(txtComments);
            grpAction.Controls.Add(lblComments);
            grpAction.Dock = DockStyle.Bottom;
            grpAction.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            grpAction.Location = new Point(0, 95);
            grpAction.Name = "grpAction";
            grpAction.Size = new Size(469, 605);
            grpAction.TabIndex = 1;
            grpAction.TabStop = false;
            grpAction.Text = "Action";
            // 
            // btnDisapprove
            // 
            btnDisapprove.BackColor = Color.Crimson;
            btnDisapprove.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            btnDisapprove.ForeColor = Color.White;
            btnDisapprove.Location = new Point(290, 110);
            btnDisapprove.Name = "btnDisapprove";
            btnDisapprove.Size = new Size(160, 45);
            btnDisapprove.TabIndex = 3;
            btnDisapprove.Text = "DISAPPROVE";
            btnDisapprove.UseVisualStyleBackColor = false;
            btnDisapprove.Click += btnDisapprove_Click;
            // 
            // btnApprove
            // 
            btnApprove.BackColor = Color.SeaGreen;
            btnApprove.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            btnApprove.ForeColor = Color.White;
            btnApprove.Location = new Point(130, 110);
            btnApprove.Name = "btnApprove";
            btnApprove.Size = new Size(140, 45);
            btnApprove.TabIndex = 2;
            btnApprove.Text = "APPROVE";
            btnApprove.UseVisualStyleBackColor = false;
            btnApprove.Click += btnApprove_Click;
            // 
            // txtComments
            // 
            txtComments.Font = new Font("Segoe UI", 10F);
            txtComments.Location = new Point(130, 47);
            txtComments.Name = "txtComments";
            txtComments.Size = new Size(300, 30);
            txtComments.TabIndex = 1;
            // 
            // lblComments
            // 
            lblComments.AutoSize = true;
            lblComments.Font = new Font("Segoe UI", 10F);
            lblComments.Location = new Point(20, 50);
            lblComments.Name = "lblComments";
            lblComments.Size = new Size(97, 23);
            lblComments.TabIndex = 0;
            lblComments.Text = "Comments:";
            // 
            // grpInfo
            // 
            grpInfo.Controls.Add(lblThreshold);
            grpInfo.Dock = DockStyle.Top;
            grpInfo.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            grpInfo.Location = new Point(0, 0);
            grpInfo.Name = "grpInfo";
            grpInfo.Size = new Size(469, 100);
            grpInfo.TabIndex = 0;
            grpInfo.TabStop = false;
            grpInfo.Text = "Current Configuration";
            grpInfo.Enter += grpInfo_Enter;
            // 
            // lblThreshold
            // 
            lblThreshold.AutoSize = true;
            lblThreshold.Font = new Font("Segoe UI", 11F);
            lblThreshold.Location = new Point(20, 45);
            lblThreshold.Name = "lblThreshold";
            lblThreshold.Size = new Size(149, 25);
            lblThreshold.TabIndex = 0;
            lblThreshold.Text = "Threshold: $0.00";
            // 
            // ManagerPortal
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.Window;
            Controls.Add(splitContainer1);
            Name = "ManagerPortal";
            Size = new Size(1500, 700);
            splitContainer1.Panel1.ResumeLayout(false);
            splitContainer1.Panel2.ResumeLayout(false);
            splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
            splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvRequests).EndInit();
            grpAction.ResumeLayout(false);
            grpAction.PerformLayout();
            grpInfo.ResumeLayout(false);
            grpInfo.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private SplitContainer splitContainer1;
        private DataGridView dgvRequests;
        private GroupBox grpInfo;
        private Label lblThreshold;
        private GroupBox grpAction;
        private Button btnDisapprove;
        private Button btnApprove;
        private TextBox txtComments;
        private Label lblComments;
        private Label lblMessage;
    }
}