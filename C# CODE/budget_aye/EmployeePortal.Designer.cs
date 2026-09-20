using System.Drawing;
namespace budget_eye
{
    partial class EmployeePortal
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
            dgvMyRequests = new DataGridView();
            groupBox1 = new GroupBox();
            btnSubmit = new Button();
            txtPurpose = new TextBox();
            label2 = new Label();
            nudAmount = new NumericUpDown();
            label1 = new Label();
            lblMessage = new Label();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
            splitContainer1.Panel1.SuspendLayout();
            splitContainer1.Panel2.SuspendLayout();
            splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvMyRequests).BeginInit();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)nudAmount).BeginInit();
            SuspendLayout();

            // splitContainer1 — SPLITS LEFT/RIGHT, AUTO FILLS EVERYTHING
            splitContainer1.Dock = DockStyle.Fill;
            splitContainer1.Location = new Point(0, 0);
            splitContainer1.Name = "splitContainer1";

            // LEFT PANEL — DataGrid
            splitContainer1.Panel1.Controls.Add(dgvMyRequests);

            // dgvMyRequests — FILLS LEFT PANEL
            dgvMyRequests.AllowUserToAddRows = false;
            dgvMyRequests.AllowUserToDeleteRows = false;
            dgvMyRequests.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvMyRequests.BackgroundColor = SystemColors.ButtonHighlight;
            dgvMyRequests.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvMyRequests.Dock = DockStyle.Fill;   // ← FILLS ENTIRE LEFT PANEL
            dgvMyRequests.Font = new Font("Segoe UI", 11F, FontStyle.Regular);
            dgvMyRequests.Name = "dgvMyRequests";
            dgvMyRequests.ReadOnly = true;
            dgvMyRequests.RowHeadersVisible = false;
            dgvMyRequests.ScrollBars = ScrollBars.Both;
            dgvMyRequests.TabIndex = 0;

            // RIGHT PANEL — Submit Form
            splitContainer1.Panel2.Controls.Add(lblMessage);
            splitContainer1.Panel2.Controls.Add(groupBox1);
            splitContainer1.Panel2MinSize = 300;
            splitContainer1.Size = new Size(1500, 700);
            splitContainer1.SplitterDistance = 1000;   // ← 1000px for grid, rest for form
            splitContainer1.TabIndex = 0;

            // groupBox1
            groupBox1.Controls.Add(btnSubmit);
            groupBox1.Controls.Add(txtPurpose);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(nudAmount);
            groupBox1.Controls.Add(label1);
            groupBox1.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            groupBox1.Location = new Point(20, 20);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(300, 250);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            groupBox1.Text = "New Request";

            // label1
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 11F, FontStyle.Regular);
            label1.Location = new Point(20, 50);
            label1.Name = "label1";
            label1.Size = new Size(76, 25);
            label1.TabIndex = 0;
            label1.Text = "Amount";

            // nudAmount
            nudAmount.Font = new Font("Segoe UI", 11F, FontStyle.Regular);
            nudAmount.Location = new Point(130, 48);
            nudAmount.Maximum = new decimal(new int[] { 100000000, 0, 0, 0 });
            nudAmount.Name = "nudAmount";
            nudAmount.Size = new Size(150, 32);
            nudAmount.TabIndex = 1;
            nudAmount.DecimalPlaces = 2;

            // label2
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 11F, FontStyle.Regular);
            label2.Location = new Point(20, 105);
            label2.Name = "label2";
            label2.Size = new Size(78, 25);
            label2.TabIndex = 2;
            label2.Text = "Purpose";

            // txtPurpose
            txtPurpose.Font = new Font("Segoe UI", 11F, FontStyle.Regular);
            txtPurpose.Location = new Point(130, 102);
            txtPurpose.Name = "txtPurpose";
            txtPurpose.Size = new Size(150, 32);
            txtPurpose.TabIndex = 3;

            // btnSubmit
            btnSubmit.BackColor = Color.SeaGreen;
            btnSubmit.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            btnSubmit.ForeColor = Color.White;
            btnSubmit.Location = new Point(130, 170);
            btnSubmit.Name = "btnSubmit";
            btnSubmit.Size = new Size(150, 45);
            btnSubmit.TabIndex = 4;
            btnSubmit.Text = "SUBMIT";
            btnSubmit.UseVisualStyleBackColor = false;
            btnSubmit.Click += btnSubmit_Click;

            // lblMessage
            lblMessage.AutoSize = true;
            lblMessage.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            lblMessage.Location = new Point(20, 290);
            lblMessage.Name = "lblMessage";
            lblMessage.Size = new Size(0, 25);
            lblMessage.TabIndex = 1;

            // EmployeePortal
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.Window;
            Controls.Add(splitContainer1);
            Name = "EmployeePortal";
            Size = new Size(1500, 700);
            splitContainer1.Panel1.ResumeLayout(false);
            splitContainer1.Panel2.ResumeLayout(false);
            splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
            splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvMyRequests).EndInit();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)nudAmount).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private SplitContainer splitContainer1;
        private DataGridView dgvMyRequests;
        private GroupBox groupBox1;
        private Button btnSubmit;
        private TextBox txtPurpose;
        private Label label2;
        private Label label1;
        private NumericUpDown nudAmount;
        private Label lblMessage;
    }
}