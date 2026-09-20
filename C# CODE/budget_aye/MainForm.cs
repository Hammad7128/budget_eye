using System;
using System.Drawing;
using System.Windows.Forms;

namespace budget_eye
{
    public partial class MainForm : Form
    {
        private Application _app;

        public MainForm(Application app)
        {
            InitializeComponent();
            _app = app;

            try
            {
                ShowUserInfo();
                LoadTabsByRole();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading dashboard:\n\n" + ex.Message,
                                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ShowUserInfo()
        {
            var user = _app.GetCurrentUser();
            if (user != null)
                lblWelcome.Text = $"Welcome, {user.DisplayName}  |  Role: {user.Role}";
        }

        private void LoadTabsByRole()
        {
            var user = _app.GetCurrentUser();
            if (user == null) return;

            tabControl.TabPages.Clear();

            if (user.Role == User.UserRole.Employee)
            {
                TabPage page = new TabPage("My Requests");
                EmployeePortal portal = new EmployeePortal(_app);
                portal.Dock = DockStyle.Fill;
                page.Controls.Add(portal);
                tabControl.TabPages.Add(page);
            }
            else if (user.Role == User.UserRole.SeniorManager)
            {
                TabPage page = new TabPage("Senior Manager Portal");
                SeniorManagerPortal portal = new SeniorManagerPortal(_app);
                portal.Dock = DockStyle.Fill;
                page.Controls.Add(portal);
                tabControl.TabPages.Add(page);
            }
            else if (user.Role == User.UserRole.Manager)
            {
                TabPage page = new TabPage("Manager Portal");
                ManagerPortal portal = new ManagerPortal(_app);
                portal.Dock = DockStyle.Fill;
                page.Controls.Add(portal);
                tabControl.TabPages.Add(page);
            }
            else if (user.Role == User.UserRole.Administrator)
            {
                // Users tab
                TabPage pageUsers = new TabPage("Users");
                AdminUsersTab usersTab = new AdminUsersTab();
                usersTab.Dock = DockStyle.Fill;
                pageUsers.Controls.Add(usersTab);
                tabControl.TabPages.Add(pageUsers);

                // Requests tab
                TabPage pageRequests = new TabPage("Requests");
                AdminRequestsTab requestsTab = new AdminRequestsTab(_app);
                requestsTab.Dock = DockStyle.Fill;
                pageRequests.Controls.Add(requestsTab);
                tabControl.TabPages.Add(pageRequests);

                // Configurations tab
                TabPage pageConfig = new TabPage("Configurations");
                AdminConfigurationsTab configTab = new AdminConfigurationsTab(_app);
                configTab.Dock = DockStyle.Fill;
                pageConfig.Controls.Add(configTab);
                tabControl.TabPages.Add(pageConfig);

                // Reports tab
                TabPage pageReports = new TabPage("Reports");
                AdminReportsTab reportsTab = new AdminReportsTab();
                reportsTab.Dock = DockStyle.Fill;
                pageReports.Controls.Add(reportsTab);
                tabControl.TabPages.Add(pageReports);
            }
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            _app.Logout();

            Form1 login = new Form1();
            login.Show();

            // Use Hide + BeginInvoke to delay close until after Show() processes
            this.BeginInvoke(new Action(() => this.Hide()));
        }
    }
}