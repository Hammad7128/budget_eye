# 👁️ BudgetEye — Enterprise Budget & Expense Approval System

[![.NET](https://img.shields.io/badge/.NET-10.0-512BD4?style=for-the-badge&logo=dotnet&logoColor=white)](https://dotnet.microsoft.com/)
[![C#](https://img.shields.io/badge/C%23-12.0-239120?style=for-the-badge&logo=csharp&logoColor=white)](https://learn.microsoft.com/dotnet/csharp/)
[![Platform](https://img.shields.io/badge/Platform-Windows%20Forms-0078D7?style=for-the-badge&logo=windows&logoColor=white)](https://learn.microsoft.com/dotnet/desktop/winforms/)
[![Database](https://img.shields.io/badge/Database-Microsoft%20SQL%20Server-CC292B?style=for-the-badge&logo=microsoftsqlserver&logoColor=white)](https://www.microsoft.com/sql-server)

**BudgetEye** is a role-based desktop financial management application built on **.NET 10 Windows Forms** and **Microsoft SQL Server**. It streamlines the submission, threshold-based escalation, approval, auditing, and reporting of organizational budget and expense requests.

---

## 📑 Table of Contents

- [Overview & Workflow](#-overview--workflow)
- [Role-Based Feature Matrix](#-role-based-feature-matrix)
- [Code Structure & Architecture](#-code-structure--architecture)
- [Prerequisites](#-prerequisites)
- [Database Setup Guide](#-database-setup-guide)
- [Configuration](#-configuration)
- [How to Build and Run](#-how-to-build-and-run)
- [Default Credentials & Quick Start](#-default-credentials--quick-start)
- [GitHub Push Instructions](#-github-push-instructions)

---

## 🚀 Overview & Workflow

BudgetEye enforces hierarchical authorization and transparent tracking across all stages of budget requests:

```
                  ┌──────────────────────┐
                  │   Employee Submits   │
                  │    Budget Request    │
                  └──────────┬───────────┘
                             │
            ┌────────────────┴────────────────┐
            ▼                                 ▼
   [Amount <= Threshold]             [Amount > Threshold]
(e.g., <= $10,000 by default)     (Requires Senior Approval)
            │                                 │
            ▼                                 ▼
   ┌─────────────────┐               ┌─────────────────┐
   │ Manager Portal  │               │ Senior Manager  │
   │ Review & Action │               │ Review & Action │
   └────────┬────────┘               └────────┬────────┘
            │                                 │
            └───────────────┬─────────────────┘
                            │
              ┌─────────────┴─────────────┐
              ▼                           ▼
        [ APPROVED ]                [ DISAPPROVED ]
              │                           │
              └─────────────┬─────────────┘
                            │
                            ▼
              ┌───────────────────────────┐
              │  Audit Trail Logged &     │
              │ Available to Admin/Portal │
              └───────────────────────────┘
```

1. **Submission**: An **Employee** creates a budget request specifying the amount and purpose.
2. **Threshold Evaluation**: If the requested amount exceeds the system-configured threshold (default `$10,000.00`), the request is automatically flagged with `RequiresSenior = true`.
3. **Approval / Rejection**:
   - Standard requests are reviewed by a **Manager**.
   - Escalated high-value requests require a **Senior Manager**.
   - Approvers can approve or disapprove with review comments.
4. **Audit Logging**: Every action (Creation, Approval, Disapproval, Deletion, Threshold Update) is recorded in the `AuditLogs` table.
5. **Administrative Governance**: An **Administrator** can manage users, delete requests, adjust threshold configurations, and generate analytics reports.

---

## 👥 Role-Based Feature Matrix

| Feature | Employee | Manager | Senior Manager | Administrator |
| :--- | :---: | :---: | :---: | :---: |
| **Submit Budget Requests** | ✅ | ❌ | ❌ | ❌ |
| **Track Personal Requests & Status** | ✅ | ❌ | ❌ | ❌ |
| **Approve/Disapprove Standard Requests** | ❌ | ✅ | ✅ | ❌ |
| **Approve/Disapprove High-Value Requests** | ❌ | ❌ | ✅ | ❌ |
| **View Audit Trail for Requests** | ❌ | ❌ | ✅ | ✅ |
| **User Management (CRUD & Restore Archive)** | ❌ | ❌ | ❌ | ✅ |
| **Pending Request Deletion** | ❌ | ❌ | ❌ | ✅ |
| **System Threshold Configuration** | ❌ | ❌ | ❌ | ✅ |
| **Financial & Date-Range Reports** | ❌ | ❌ | ❌ | ✅ |

---

## 📂 Code Structure & Architecture

The solution follows a clean multi-tier architecture separating UI presentation, domain models, business logic, data access, and database scripts.

```
budget_eye/
│
├── .gitignore                      # Git ignore rules for .NET and Visual Studio
├── README.md                       # Project documentation & run guide
│
├── DB_QUERIES/                     # SQL Server Database Scripts
│   ├── tables.sql                  # Database (BudgetEyeDB) & schema definition
│   ├── procedures.sql              # Stored procedures for CRUD, filtering & stats
│   └── default_admin.sql           # Seed script (Default admin user & initial threshold)
│
└── C# CODE/
    └── budget_aye/
        ├── budget_aye.csproj       # Project file (.NET 10 Windows Forms)
        ├── budget_aye.slnx         # Solution file (Visual Studio 2022 format)
        ├── Program.cs              # Application entry point
        ├── Logo.png                # Application UI logo asset
        │
        ├── ── Models & Domain Entities ──
        │   ├── User.cs             # User model, validation & UserRole enum
        │   ├── Request.cs          # Request model, validation, threshold checks & BudgetStatus enum
        │   ├── Configurations.cs   # Configuration entity for approval threshold amount
        │   └── AuditLog.cs         # AuditLog model & action tracker
        │
        ├── ── Business Logic & Services ──
        │   ├── Application.cs      # Core application controller / coordinator
        │   ├── Authentication.cs   # User session, login, and registration logic
        │   ├── DBconnection.cs     # SQL Server connection provider
        │   └── DatabaseService.cs  # ADO.NET Data Access Layer calling SQL stored procedures
        │
        ├── ── Presentation Layer (Forms & User Controls) ──
        │   ├── Form1.cs / .Designer.cs / .resx               # Login window
        │   ├── MainForm.cs / .Designer.cs / .resx            # Dashboard host (loads tabs by role)
        │   ├── EmployeePortal.cs / .Designer.cs / .resx      # Employee request submission & history
        │   ├── ManagerPortal.cs / .Designer.cs / .resx       # Manager approval portal
        │   ├── SeniorManagerPortal.cs / .Designer.cs / .resx # Senior Manager escalated approval portal
        │   ├── AdminUsersTab.cs / .Designer.cs / .resx       # Admin: User management tab
        │   ├── AdminRequestsTab.cs / .Designer.cs / .resx    # Admin: Request management & audit tab
        │   ├── AdminConfigurationTab.cs / .Designer.cs / .resx # Admin: Threshold configuration tab
        │   └── AdminReportsTab.cs / .Designer.cs / .resx     # Admin: Reporting & analytics tab
        │
        └── Properties/
            ├── Resources.Designer.cs
            └── Resources.resx
```

### Key Components Explained:
- **`DBconnection.cs`**: Supplies the `SqlConnection` instance. Contains the central connection string configured for SQL Server.
- **`DatabaseService.cs`**: Encapsulates all ADO.NET queries and stored procedure invocations (`sp_GetAllUsers`, `sp_CreateUser`, `sp_GetAllRequests`, `sp_GetRequestStats`, etc.).
- **`Application.cs`**: Serves as the application service/facade coordinating session state, data caching, in-memory filtering, and database synchronization.
- **`MainForm.cs`**: Inspects `user.Role` upon login and dynamically renders only the authorized portal or administration tabs into the UI.

---

## 💻 Prerequisites

Before running the application, ensure the following are installed:

1. **Operating System**: Windows 10 / 11 (required for Windows Forms).
2. **.NET SDK**: [.NET 10.0 SDK](https://dotnet.microsoft.com/download/dotnet/10.0) or higher.
   - Verify by running `dotnet --version` in your terminal.
3. **IDE**: [Visual Studio 2022](https://visualstudio.microsoft.com/) (version 17.10 or higher with *.NET Desktop Development* workload) OR [VS Code](https://code.visualstudio.com/) with C# Dev Kit.
4. **Database Server**: [Microsoft SQL Server](https://www.microsoft.com/sql-server/sql-server-downloads) (Express, Developer, or Standard edition) or LocalDB.
5. **Database Client**: [SQL Server Management Studio (SSMS)](https://learn.microsoft.com/sql/ssms/download-sql-server-management-studio-ssms) or [Azure Data Studio](https://learn.microsoft.com/azure-data-studio/).

---

## 🗄️ Database Setup Guide

Execute the SQL scripts in the `DB_QUERIES` directory in the exact order below:

### Step 1: Create Database and Tables
Open `DB_QUERIES/tables.sql` in SSMS or Azure Data Studio and run the entire script.
- Creates database `BudgetEyeDB`.
- Creates tables:
  - `Users`
  - `Requests`
  - `AuditLogs`
  - `Configuration`
  - `DeletedUsers`
  - `DeletedRequests`

### Step 2: Create Stored Procedures
Open `DB_QUERIES/procedures.sql` and execute it.
- Creates all stored procedures including user management (`sp_CreateUser`, `sp_UpdateUser`, `sp_DeleteUser`), request management (`sp_GetAllRequests`, `sp_DeletePendingRequest`, `sp_GetRequestAudit`), configurations (`sp_GetAllConfigurations`), and reporting (`sp_GetRequestStats`, `sp_GetRequestsByDateRange`).

### Step 3: Seed Initial Data
Open `DB_QUERIES/default_admin.sql` and execute it.
- Seeds the initial Administrator account:
  - **Username**: `admin`
  - **Password**: `admin123`
  - **Role**: `0` (Administrator)
- Seeds the initial active configuration threshold:
  - **Threshold**: `$10,000.00`

---

## ⚙️ Configuration

Set your SQL Server instance connection string in [DBconnection.cs](file:///C#%20CODE/budget_aye/DBconnection.cs):

```csharp
// Path: C# CODE/budget_aye/DBconnection.cs
namespace budget_eye
{
    public static class DBconnection
    {
        private static string _connectionString = 
            "Server=YOUR_SERVER_NAME\\SQLEXPRESS;Database=BudgetEyeDB;Trusted_Connection=True;TrustServerCertificate=True;";

        public static SqlConnection GetConnection()
        {
            return new SqlConnection(_connectionString);
        }
    }
}
```

### Common Connection String Examples:

- **Local SQL Express Instance**:
  ```
  Server=localhost\\SQLEXPRESS;Database=BudgetEyeDB;Trusted_Connection=True;TrustServerCertificate=True;
  ```
- **Local Default SQL Server Instance**:
  ```
  Server=localhost;Database=BudgetEyeDB;Trusted_Connection=True;TrustServerCertificate=True;
  ```
- **LocalDB**:
  ```
  Server=(localdb)\\MSSQLLocalDB;Database=BudgetEyeDB;Trusted_Connection=True;TrustServerCertificate=True;
  ```
- **SQL Server Authentication (Username & Password)**:
  ```
  Server=localhost\\SQLEXPRESS;Database=BudgetEyeDB;User Id=sa;Password=YourStrongPassword;TrustServerCertificate=True;
  ```

---

## 🏃 How to Build and Run

### Option 1: Using Visual Studio 2022 (Recommended)
1. Open Visual Studio 2022.
2. Select **Open a project or solution**.
3. Browse to `C# CODE/budget_aye/` and select `budget_aye.slnx` (or `budget_aye.csproj`).
4. Select `Debug` or `Release` configuration and `Any CPU`.
5. Press **F5** (or click the green **Start** button) to build and run.

### Option 2: Using the .NET CLI
Open PowerShell or Command Prompt, navigate to the project directory, and run:

```powershell
# Navigate to the project directory
cd "C# CODE\budget_aye"

# Restore NuGet dependencies
dotnet restore

# Build the project
dotnet build

# Run the application
dotnet run
```

---

## 🔑 Default Credentials & Quick Start

### 1. Log in as Administrator
- **Username**: `admin`
- **Password**: `admin123`

### 2. Set Up Users for Testing
Once logged in as Administrator, navigate to the **Users** tab and create accounts for the different roles:
1. **Employee User**:
   - Username: `employee1` | Password: `password123` | Role: `Employee`
2. **Manager User**:
   - Username: `manager1` | Password: `password123` | Role: `Manager`
3. **Senior Manager User**:
   - Username: `srmanager1` | Password: `password123` | Role: `SeniorManager`

### 3. Test the Full Workflow
1. Log out and sign in as `employee1`.
2. Submit two requests:
   - **Request A**: `$3,500` for "Team Monitors" (Below threshold).
   - **Request B**: `$15,000` for "Server Hardware Upgrade" (Above threshold).
3. Log out and sign in as `manager1`:
   - Notice that **Request A** is available for approval in the Manager Portal.
   - Review and approve **Request A**.
4. Log out and sign in as `srmanager1`:
   - Notice that **Request B** is routed to the Senior Manager Portal because it exceeds the threshold.
   - Review and approve **Request B**.
5. Log out and sign back in as `admin`:
   - Check the **Requests** tab to view the complete audit log.
   - Check the **Reports** tab to see updated financial statistics.

---

## 📤 GitHub Push Instructions

Follow these steps to push the project to a new GitHub repository:

```bash
# 1. Initialize git (if not already initialized)
git init

# 2. Verify git status (ensures .gitignore excludes bin/ and obj/)
git status

# 3. Stage all source files and documentation
git add .

# 4. Create initial commit
git commit -m "feat: initial commit for BudgetEye application with documentation"

# 5. Rename default branch to main
git branch -M main

# 6. Add your GitHub repository remote (replace with your repo URL)
git remote add origin https://github.com/YOUR_USERNAME/YOUR_REPOSITORY.git

# 7. Push to GitHub
git push -u origin main
```

---

## 🛡️ License & Acknowledgments

- Built for organization and academic budget tracking.
- Developed with C#, .NET 10, Windows Forms, and Microsoft SQL Server.
