using System.Drawing;

namespace budget_eye
{
    partial class AdminRequestsTab
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
            panelFilters = new Panel();
            btnAll = new Button();
            btnPending = new Button();
            btnApproved = new Button();
            btnDisapproved = new Button();
            btnResolved = new Button();
            btnDeletePending = new Button();
            dgvAllRequests = new DataGridView();
            dgvDeletedRequests = new DataGridView();
            splitContainerRight = new SplitContainer();
            grpAudit = new GroupBox();
            dgvAuditLog = new DataGridView();
            grpStats = new GroupBox();
            lblStartDate = new Label();
            dtpStartDate = new DateTimePicker();
            lblEndDate = new Label();
            dtpEndDate = new DateTimePicker();
            btnGetStats = new Button();
            lblTotalRequests = new Label();
            lblTotalApproved = new Label();
            lblTotalPending = new Label();
            lblTotalDisapproved = new Label();
            dgvDateRangeResults = new DataGridView();
            lblMessage = new Label();

            ((System.ComponentModel.ISupportInitialize)splitContainerMain).BeginInit();
            splitContainerMain.Panel1.SuspendLayout();
            splitContainerMain.Panel2.SuspendLayout();
            splitContainerMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainerLeft).BeginInit();
            splitContainerLeft.Panel1.SuspendLayout();
            splitContainerLeft.Panel2.SuspendLayout();
            splitContainerLeft.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvAllRequests).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvDeletedRequests).BeginInit();
            ((System.ComponentModel.ISupportInitialize)splitContainerRight).BeginInit();
            splitContainerRight.Panel1.SuspendLayout();
            splitContainerRight.Panel2.SuspendLayout();
            splitContainerRight.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvAuditLog).BeginInit();
            grpAudit.SuspendLayout();
            grpStats.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvDateRangeResults).BeginInit();
            SuspendLayout();

            // 
            // splitContainerMain
            // 
            splitContainerMain.Dock = DockStyle.Fill;
            splitContainerMain.Location = new Point(0, 0);
            splitContainerMain.Name = "splitContainerMain";
            splitContainerMain.Panel1.Controls.Add(splitContainerLeft);
            splitContainerMain.Panel2.Controls.Add(splitContainerRight);
            splitContainerMain.Size = new Size(1500, 800);
            splitContainerMain.SplitterDistance = 950;          // ← narrowed left side
            splitContainerMain.TabIndex = 0;

            // 
            // splitContainerLeft
            // 
            splitContainerLeft.Dock = DockStyle.Fill;
            splitContainerLeft.Location = new Point(0, 0);
            splitContainerLeft.Name = "splitContainerLeft";
            splitContainerLeft.Orientation = Orientation.Horizontal;
            splitContainerLeft.Panel1.Controls.Add(dgvAllRequests);
            splitContainerLeft.Panel1.Controls.Add(panelFilters);
            splitContainerLeft.Panel2.Controls.Add(dgvDeletedRequests);
            splitContainerLeft.Size = new Size(950, 800);       // ← matched to new left width
            splitContainerLeft.SplitterDistance = 450;
            splitContainerLeft.TabIndex = 0;

            // 
            // panelFilters
            // 
            panelFilters.Dock = DockStyle.Top;
            panelFilters.Height = 60;
            panelFilters.Name = "panelFilters";
            panelFilters.Controls.Add(btnDeletePending);
            panelFilters.Controls.Add(btnResolved);
            panelFilters.Controls.Add(btnDisapproved);
            panelFilters.Controls.Add(btnApproved);
            panelFilters.Controls.Add(btnPending);
            panelFilters.Controls.Add(btnAll);

            // 
            // btnAll
            // 
            btnAll.BackColor = Color.DodgerBlue;
            btnAll.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnAll.ForeColor = Color.White;
            btnAll.Location = new Point(10, 12);
            btnAll.Name = "btnAll";
            btnAll.Size = new Size(75, 38);
            btnAll.TabIndex = 0;
            btnAll.Text = "ALL";
            btnAll.UseVisualStyleBackColor = false;
            btnAll.Click += btnFilter_Click;

            // 
            // btnPending
            // 
            btnPending.BackColor = Color.Orange;
            btnPending.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnPending.ForeColor = Color.White;
            btnPending.Location = new Point(95, 12);
            btnPending.Name = "btnPending";
            btnPending.Size = new Size(100, 38);
            btnPending.TabIndex = 1;
            btnPending.Text = "PENDING";
            btnPending.UseVisualStyleBackColor = false;
            btnPending.Click += btnFilter_Click;

            // 
            // btnApproved
            // 
            btnApproved.BackColor = Color.SeaGreen;
            btnApproved.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnApproved.ForeColor = Color.White;
            btnApproved.Location = new Point(205, 12);
            btnApproved.Name = "btnApproved";
            btnApproved.Size = new Size(110, 38);
            btnApproved.TabIndex = 2;
            btnApproved.Text = "APPROVED";
            btnApproved.UseVisualStyleBackColor = false;
            btnApproved.Click += btnFilter_Click;

            // 
            // btnDisapproved
            // 
            btnDisapproved.BackColor = Color.Crimson;
            btnDisapproved.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnDisapproved.ForeColor = Color.White;
            btnDisapproved.Location = new Point(325, 12);
            btnDisapproved.Name = "btnDisapproved";
            btnDisapproved.Size = new Size(110, 38);
            btnDisapproved.TabIndex = 3;
            btnDisapproved.Text = "REJECTED";
            btnDisapproved.UseVisualStyleBackColor = false;
            btnDisapproved.Click += btnFilter_Click;

            // 
            // btnResolved
            // 
            btnResolved.BackColor = Color.Gray;
            btnResolved.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnResolved.ForeColor = Color.White;
            btnResolved.Location = new Point(445, 12);
            btnResolved.Name = "btnResolved";
            btnResolved.Size = new Size(110, 38);
            btnResolved.TabIndex = 4;
            btnResolved.Text = "RESOLVED";
            btnResolved.UseVisualStyleBackColor = false;
            btnResolved.Click += btnFilter_Click;

            // 
            // btnDeletePending
            // 
            btnDeletePending.BackColor = Color.Crimson;
            btnDeletePending.Enabled = false;
            btnDeletePending.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnDeletePending.ForeColor = Color.White;
            btnDeletePending.Location = new Point(600, 12);
            btnDeletePending.Name = "btnDeletePending";
            btnDeletePending.Size = new Size(160, 38);
            btnDeletePending.TabIndex = 5;
            btnDeletePending.Text = "DELETE PENDING";
            btnDeletePending.UseVisualStyleBackColor = false;
            btnDeletePending.Click += btnDeletePending_Click;

            // 
            // dgvAllRequests
            // 
            dgvAllRequests.AllowUserToAddRows = false;
            dgvAllRequests.AllowUserToDeleteRows = false;
            dgvAllRequests.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvAllRequests.BackgroundColor = Color.White;
            dgvAllRequests.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvAllRequests.Dock = DockStyle.Fill;
            dgvAllRequests.Font = new Font("Segoe UI", 10F);
            dgvAllRequests.Location = new Point(0, 60);
            dgvAllRequests.MultiSelect = false;
            dgvAllRequests.Name = "dgvAllRequests";
            dgvAllRequests.ReadOnly = true;
            dgvAllRequests.RowHeadersVisible = false;
            dgvAllRequests.RowHeadersWidth = 51;
            dgvAllRequests.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvAllRequests.Size = new Size(950, 390);           // ← matched width
            dgvAllRequests.TabIndex = 1;
            dgvAllRequests.SelectionChanged += dgvAllRequests_SelectionChanged;

            // 
            // dgvDeletedRequests
            // 
            dgvDeletedRequests.AllowUserToAddRows = false;
            dgvDeletedRequests.AllowUserToDeleteRows = false;
            dgvDeletedRequests.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvDeletedRequests.BackgroundColor = Color.WhiteSmoke;
            dgvDeletedRequests.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvDeletedRequests.Dock = DockStyle.Fill;
            dgvDeletedRequests.Font = new Font("Segoe UI", 10F);
            dgvDeletedRequests.Location = new Point(0, 0);
            dgvDeletedRequests.Name = "dgvDeletedRequests";
            dgvDeletedRequests.ReadOnly = true;
            dgvDeletedRequests.RowHeadersVisible = false;
            dgvDeletedRequests.RowHeadersWidth = 51;
            dgvDeletedRequests.Size = new Size(950, 346);        // ← matched width
            dgvDeletedRequests.TabIndex = 0;

            // 
            // splitContainerRight
            // 
            splitContainerRight.Dock = DockStyle.Fill;
            splitContainerRight.Location = new Point(0, 0);
            splitContainerRight.Name = "splitContainerRight";
            splitContainerRight.Orientation = Orientation.Horizontal;
            splitContainerRight.Panel1.Controls.Add(grpAudit);
            splitContainerRight.Panel2.Controls.Add(lblMessage);
            splitContainerRight.Panel2.Controls.Add(grpStats);
            splitContainerRight.Size = new Size(550, 800);        // ← matched new right width
            splitContainerRight.SplitterDistance = 260;         // ← shortened audit log
            splitContainerRight.TabIndex = 0;

            // 
            // grpAudit
            // 
            grpAudit.Controls.Add(dgvAuditLog);
            grpAudit.Dock = DockStyle.Fill;
            grpAudit.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            grpAudit.Location = new Point(0, 0);
            grpAudit.Name = "grpAudit";
            grpAudit.Size = new Size(550, 260);                 // ← matched
            grpAudit.TabIndex = 0;
            grpAudit.TabStop = false;
            grpAudit.Text = "Audit Log for Selected Request";

            // 
            // dgvAuditLog
            // 
            dgvAuditLog.AllowUserToAddRows = false;
            dgvAuditLog.AllowUserToDeleteRows = false;
            dgvAuditLog.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvAuditLog.BackgroundColor = Color.White;
            dgvAuditLog.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvAuditLog.Dock = DockStyle.Fill;
            dgvAuditLog.Font = new Font("Segoe UI", 10F);
            dgvAuditLog.Location = new Point(3, 30);
            dgvAuditLog.Name = "dgvAuditLog";
            dgvAuditLog.ReadOnly = true;
            dgvAuditLog.RowHeadersVisible = false;
            dgvAuditLog.RowHeadersWidth = 51;
            dgvAuditLog.Size = new Size(544, 227);              // ← adjusted
            dgvAuditLog.TabIndex = 0;

            // 
            // lblMessage
            // 
            lblMessage.Dock = DockStyle.Bottom;
            lblMessage.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblMessage.Location = new Point(0, 765);
            lblMessage.Name = "lblMessage";
            lblMessage.Size = new Size(550, 35);               // ← matched
            lblMessage.TabIndex = 2;
            lblMessage.Text = "";
            lblMessage.TextAlign = ContentAlignment.MiddleLeft;

            // 
            // grpStats
            // 
            grpStats.Controls.Add(dgvDateRangeResults);
            grpStats.Controls.Add(lblTotalDisapproved);
            grpStats.Controls.Add(lblTotalPending);
            grpStats.Controls.Add(lblTotalApproved);
            grpStats.Controls.Add(lblTotalRequests);
            grpStats.Controls.Add(btnGetStats);
            grpStats.Controls.Add(dtpEndDate);
            grpStats.Controls.Add(lblEndDate);
            grpStats.Controls.Add(dtpStartDate);
            grpStats.Controls.Add(lblStartDate);
            grpStats.Dock = DockStyle.Fill;
            grpStats.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            grpStats.Location = new Point(0, 0);
            grpStats.Name = "grpStats";
            grpStats.Size = new Size(550, 536);                 // ← more room now
            grpStats.TabIndex = 1;
            grpStats.TabStop = false;
            grpStats.Text = "Statistics by Date Range";

            // 
            // lblStartDate
            // 
            lblStartDate.AutoSize = true;
            lblStartDate.Font = new Font("Segoe UI", 10F);
            lblStartDate.Location = new Point(20, 45);
            lblStartDate.Name = "lblStartDate";
            lblStartDate.Size = new Size(87, 23);
            lblStartDate.TabIndex = 0;
            lblStartDate.Text = "Start Date";

            // 
            // dtpStartDate
            // 
            dtpStartDate.Font = new Font("Segoe UI", 10F);
            dtpStartDate.Format = DateTimePickerFormat.Short;
            dtpStartDate.Location = new Point(130, 42);
            dtpStartDate.Name = "dtpStartDate";
            dtpStartDate.Size = new Size(200, 30);
            dtpStartDate.TabIndex = 1;

            // 
            // lblEndDate
            // 
            lblEndDate.AutoSize = true;
            lblEndDate.Font = new Font("Segoe UI", 10F);
            lblEndDate.Location = new Point(20, 85);
            lblEndDate.Name = "lblEndDate";
            lblEndDate.Size = new Size(79, 23);
            lblEndDate.TabIndex = 2;
            lblEndDate.Text = "End Date";

            // 
            // dtpEndDate
            // 
            dtpEndDate.Font = new Font("Segoe UI", 10F);
            dtpEndDate.Format = DateTimePickerFormat.Short;
            dtpEndDate.Location = new Point(130, 82);
            dtpEndDate.Name = "dtpEndDate";
            dtpEndDate.Size = new Size(200, 30);
            dtpEndDate.TabIndex = 3;

            // 
            // btnGetStats
            // 
            btnGetStats.BackColor = Color.DodgerBlue;
            btnGetStats.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnGetStats.ForeColor = Color.White;
            btnGetStats.Location = new Point(130, 125);
            btnGetStats.Name = "btnGetStats";
            btnGetStats.Size = new Size(200, 40);
            btnGetStats.TabIndex = 4;
            btnGetStats.Text = "GET STATISTICS";
            btnGetStats.UseVisualStyleBackColor = false;
            btnGetStats.Click += btnGetStats_Click;

            // 
            // lblTotalRequests
            // 
            lblTotalRequests.AutoSize = true;
            lblTotalRequests.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblTotalRequests.Location = new Point(20, 180);
            lblTotalRequests.Name = "lblTotalRequests";
            lblTotalRequests.Size = new Size(137, 23);
            lblTotalRequests.TabIndex = 5;
            lblTotalRequests.Text = "Total Requests: -";

            // 
            // lblTotalApproved
            // 
            lblTotalApproved.AutoSize = true;
            lblTotalApproved.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblTotalApproved.ForeColor = Color.SeaGreen;
            lblTotalApproved.Location = new Point(20, 205);
            lblTotalApproved.Name = "lblTotalApproved";
            lblTotalApproved.Size = new Size(160, 23);
            lblTotalApproved.TabIndex = 6;
            lblTotalApproved.Text = "Approved Amount: -";

            // 
            // lblTotalPending
            // 
            lblTotalPending.AutoSize = true;
            lblTotalPending.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblTotalPending.ForeColor = Color.Orange;
            lblTotalPending.Location = new Point(20, 230);
            lblTotalPending.Name = "lblTotalPending";
            lblTotalPending.Size = new Size(152, 23);
            lblTotalPending.TabIndex = 7;
            lblTotalPending.Text = "Pending Amount: -";

            // 
            // lblTotalDisapproved
            // 
            lblTotalDisapproved.AutoSize = true;
            lblTotalDisapproved.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblTotalDisapproved.ForeColor = Color.Crimson;
            lblTotalDisapproved.Location = new Point(20, 255);
            lblTotalDisapproved.Name = "lblTotalDisapproved";
            lblTotalDisapproved.Size = new Size(186, 23);
            lblTotalDisapproved.TabIndex = 8;
            lblTotalDisapproved.Text = "Disapproved Amount: -";

            // 
            // dgvDateRangeResults
            // 
            dgvDateRangeResults.AllowUserToAddRows = false;
            dgvDateRangeResults.AllowUserToDeleteRows = false;
            dgvDateRangeResults.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvDateRangeResults.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvDateRangeResults.BackgroundColor = Color.White;
            dgvDateRangeResults.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvDateRangeResults.Location = new Point(10, 285);
            dgvDateRangeResults.Name = "dgvDateRangeResults";
            dgvDateRangeResults.ReadOnly = true;
            dgvDateRangeResults.RowHeadersVisible = false;
            dgvDateRangeResults.RowHeadersWidth = 51;
            dgvDateRangeResults.Size = new Size(530, 240);    // ← much taller
            dgvDateRangeResults.TabIndex = 9;

            // 
            // AdminRequestsTab
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            Controls.Add(splitContainerMain);
            Name = "AdminRequestsTab";
            Size = new Size(1500, 800);
            splitContainerMain.Panel1.ResumeLayout(false);
            splitContainerMain.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainerMain).EndInit();
            splitContainerMain.ResumeLayout(false);
            splitContainerLeft.Panel1.ResumeLayout(false);
            splitContainerLeft.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainerLeft).EndInit();
            splitContainerLeft.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvAllRequests).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvDeletedRequests).EndInit();
            splitContainerRight.Panel1.ResumeLayout(false);
            splitContainerRight.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainerRight).EndInit();
            splitContainerRight.ResumeLayout(false);
            grpAudit.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvAuditLog).EndInit();
            grpStats.ResumeLayout(false);
            grpStats.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvDateRangeResults).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private SplitContainer splitContainerMain;
        private SplitContainer splitContainerLeft;
        private Panel panelFilters;
        private Button btnAll;
        private Button btnPending;
        private Button btnApproved;
        private Button btnDisapproved;
        private Button btnResolved;
        private Button btnDeletePending;
        private DataGridView dgvAllRequests;
        private DataGridView dgvDeletedRequests;
        private SplitContainer splitContainerRight;
        private GroupBox grpAudit;
        private DataGridView dgvAuditLog;
        private GroupBox grpStats;
        private Label lblStartDate;
        private DateTimePicker dtpStartDate;
        private Label lblEndDate;
        private DateTimePicker dtpEndDate;
        private Button btnGetStats;
        private Label lblTotalRequests;
        private Label lblTotalApproved;
        private Label lblTotalPending;
        private Label lblTotalDisapproved;
        private DataGridView dgvDateRangeResults;
        private Label lblMessage;
    }
}