using System.Drawing;

namespace budget_eye
{
    partial class AdminConfigurationsTab
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
            dgvAllConfigs = new DataGridView();
            grpCreate = new GroupBox();
            lblCurrentThreshold = new Label();
            lblThreshold = new Label();
            nudThreshold = new NumericUpDown();
            btnCreate = new Button();
            lblMessage = new Label();

            ((System.ComponentModel.ISupportInitialize)splitContainerMain).BeginInit();
            splitContainerMain.Panel1.SuspendLayout();
            splitContainerMain.Panel2.SuspendLayout();
            splitContainerMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvAllConfigs).BeginInit();
            grpCreate.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)nudThreshold).BeginInit();
            SuspendLayout();

            // 
            // splitContainerMain
            // 
            splitContainerMain.Dock = DockStyle.Fill;
            splitContainerMain.Location = new Point(0, 0);
            splitContainerMain.Name = "splitContainerMain";
            splitContainerMain.Panel1.Controls.Add(dgvAllConfigs);
            splitContainerMain.Panel2.Controls.Add(lblMessage);
            splitContainerMain.Panel2.Controls.Add(grpCreate);
            splitContainerMain.Size = new Size(1100, 750);
            splitContainerMain.SplitterDistance = 700;
            splitContainerMain.TabIndex = 0;

            // 
            // dgvAllConfigs
            // 
            dgvAllConfigs.AllowUserToAddRows = false;
            dgvAllConfigs.AllowUserToDeleteRows = false;
            dgvAllConfigs.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvAllConfigs.BackgroundColor = Color.White;
            dgvAllConfigs.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvAllConfigs.Dock = DockStyle.Fill;
            dgvAllConfigs.Font = new Font("Segoe UI", 10F);
            dgvAllConfigs.Location = new Point(0, 0);
            dgvAllConfigs.Name = "dgvAllConfigs";
            dgvAllConfigs.ReadOnly = true;
            dgvAllConfigs.RowHeadersVisible = false;
            dgvAllConfigs.RowHeadersWidth = 51;
            dgvAllConfigs.Size = new Size(700, 750);
            dgvAllConfigs.TabIndex = 0;

            // 
            // grpCreate
            // 
            grpCreate.Controls.Add(btnCreate);
            grpCreate.Controls.Add(nudThreshold);
            grpCreate.Controls.Add(lblThreshold);
            grpCreate.Controls.Add(lblCurrentThreshold);
            grpCreate.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            grpCreate.Location = new Point(30, 20);
            grpCreate.Name = "grpCreate";
            grpCreate.Size = new Size(340, 280);
            grpCreate.TabIndex = 0;
            grpCreate.TabStop = false;
            grpCreate.Text = "Create New Configuration";

            // 
            // lblCurrentThreshold
            // 
            lblCurrentThreshold.AutoSize = true;
            lblCurrentThreshold.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            lblCurrentThreshold.ForeColor = Color.SeaGreen;
            lblCurrentThreshold.Location = new Point(20, 45);
            lblCurrentThreshold.Name = "lblCurrentThreshold";
            lblCurrentThreshold.Size = new Size(220, 25);
            lblCurrentThreshold.TabIndex = 0;
            lblCurrentThreshold.Text = "Current Threshold: $0.00";

            // 
            // lblThreshold
            // 
            lblThreshold.AutoSize = true;
            lblThreshold.Font = new Font("Segoe UI", 10F);
            lblThreshold.Location = new Point(20, 100);
            lblThreshold.Name = "lblThreshold";
            lblThreshold.Size = new Size(130, 23);
            lblThreshold.TabIndex = 1;
            lblThreshold.Text = "New Threshold";

            // 
            // nudThreshold
            // 
            nudThreshold.DecimalPlaces = 2;
            nudThreshold.Font = new Font("Segoe UI", 10F);
            nudThreshold.Location = new Point(160, 98);
            nudThreshold.Maximum = new decimal(new int[] { 100000000, 0, 0, 0 });
            nudThreshold.Name = "nudThreshold";
            nudThreshold.Size = new Size(150, 30);
            nudThreshold.TabIndex = 2;

            // 
            // btnCreate
            // 
            btnCreate.BackColor = Color.DodgerBlue;
            btnCreate.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            btnCreate.ForeColor = Color.White;
            btnCreate.Location = new Point(160, 155);
            btnCreate.Name = "btnCreate";
            btnCreate.Size = new Size(150, 45);
            btnCreate.TabIndex = 3;
            btnCreate.Text = "CREATE";
            btnCreate.UseVisualStyleBackColor = false;
            btnCreate.Click += btnCreate_Click;

            // 
            // lblMessage
            // 
            lblMessage.AutoSize = true;
            lblMessage.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblMessage.Location = new Point(30, 320);
            lblMessage.Name = "lblMessage";
            lblMessage.Size = new Size(0, 23);
            lblMessage.TabIndex = 1;

            // 
            // AdminConfigurationsTab
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            Controls.Add(splitContainerMain);
            Name = "AdminConfigurationsTab";
            Size = new Size(1100, 750);
            splitContainerMain.Panel1.ResumeLayout(false);
            splitContainerMain.Panel2.ResumeLayout(false);
            splitContainerMain.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainerMain).EndInit();
            splitContainerMain.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvAllConfigs).EndInit();
            grpCreate.ResumeLayout(false);
            grpCreate.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)nudThreshold).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private SplitContainer splitContainerMain;
        private DataGridView dgvAllConfigs;
        private GroupBox grpCreate;
        private Label lblCurrentThreshold;
        private Label lblThreshold;
        private NumericUpDown nudThreshold;
        private Button btnCreate;
        private Label lblMessage;
    }
}