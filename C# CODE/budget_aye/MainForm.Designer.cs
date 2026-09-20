using System.Drawing;

namespace budget_eye
{
    partial class MainForm
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

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            panelTop = new Panel();
            lblWelcome = new Label();
            btnLogout = new Button();
            tabControl = new TabControl();
            panelTop.SuspendLayout();
            SuspendLayout();

            // panelTop — HOLDS LABEL AND BUTTON
            panelTop.Controls.Add(btnLogout);
            panelTop.Controls.Add(lblWelcome);
            panelTop.Dock = DockStyle.Top;
            panelTop.Height = 60;
            panelTop.Name = "panelTop";
            panelTop.TabIndex = 0;

            // lblWelcome
            lblWelcome.AutoSize = true;
            lblWelcome.Font = new System.Drawing.Font("Segoe UI", 14F, FontStyle.Bold);
            lblWelcome.Location = new Point(30, 15);
            lblWelcome.Name = "lblWelcome";
            lblWelcome.Size = new Size(110, 32);
            lblWelcome.TabIndex = 0;
            lblWelcome.Text = "Welcome";

            // btnLogout
            btnLogout.BackColor = Color.Crimson;
            btnLogout.Font = new System.Drawing.Font("Segoe UI", 11F, FontStyle.Bold);
            btnLogout.ForeColor = Color.White;
            btnLogout.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnLogout.Location = new Point(1350, 10);
            btnLogout.Name = "btnLogout";
            btnLogout.Size = new Size(120, 45);
            btnLogout.TabIndex = 1;
            btnLogout.Text = "LOGOUT";
            btnLogout.UseVisualStyleBackColor = false;
            btnLogout.Click += btnLogout_Click;

            // tabControl — FILLS REST OF FORM BELOW PANEL
            tabControl.Dock = DockStyle.Fill;
            tabControl.Name = "tabControl";
            tabControl.SelectedIndex = 0;
            tabControl.TabIndex = 1;

            // MainForm
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1560, 830);
            Controls.Add(tabControl);
            Controls.Add(panelTop);
            Name = "MainForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Budget Eye - Dashboard";
            WindowState = FormWindowState.Maximized;
            panelTop.ResumeLayout(false);
            panelTop.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel panelTop;
        private Label lblWelcome;
        private Button btnLogout;
        private TabControl tabControl;
    }
}