# Smart Quiz Conducting System

A full-stack desktop quiz application built with C# .NET WinForms and SQL Server, featuring role-based access for admins and students.

---

## Features

**Admin**
- Add/delete students, admins, and exams
- Manage question bank with stored procedures
- Assign exams to students
- View and manage student results

**Student**
- Login and take assigned exams
- Timer-based quiz with auto-grading
- View results after submission

---

## Tech Stack

- **Language:** C# (.NET Framework 4.7.2)
- **UI:** Windows Forms (WinForms) with MetroModernUI
- **Database:** SQL Server (LocalDB / SSMS)
- **IDE:** Visual Studio 2022

---

## Getting Started

### Prerequisites

- Visual Studio 2022
- SQL Server + SQL Server Management Studio (SSMS)
- .NET Framework 4.7.2

---

### 1. Restore the Database

1. Open **SSMS** and connect to your SQL Server instance
2. Right-click **Databases** → **Restore Database**
3. Select **Device** → click `...` → **Add**
4. Navigate to and select `Database/quiz_app`
5. Click **OK** to restore

Alternatively, run the schema script to create the structure:
```
Database/DB scheme.sql
```
> Note: The SQL script creates the schema only. The `.backup` file (`quiz_app`) includes all stored procedures and is the recommended restore method.

---

### 2. Configure the Connection String

Open `QuizApp/App.config` and at all other places where conn string is written and update the connection string to match your SQL Server instance:

```xml
<connectionStrings>
  <add name="QuizApp.Properties.Settings.quiz_appConnectionString"
       connectionString="Data Source=YOUR_SERVER_NAME\SQLEXPRESS;
                         Initial Catalog=quiz_app;
                         Integrated Security=True"
       providerName="System.Data.SqlClient" />
</connectionStrings>
```

Replace `YOUR_SERVER_NAME` with your machine name or use `.` for the default local instance.

---

### 3. Build and Run

1. Open `QuizApp.sln` in Visual Studio 2022
2. Build the solution (`Ctrl + Shift + B`)
3. Run with `F5`

---

## Default Credentials

> Update these after first login.

| Role | Username | Password |
|------|----------|----------|
| Admin | `admin` | `admin123` |

Student accounts are created by the admin through the application.

---

## Project Structure

```
QuizApp/
├── Database/
│   ├── DB scheme.sql       # Schema-only SQL script
│   └── quiz_app            # Full database backup (restore in SSMS)
├── QuizApp/
│   ├── *.cs                # All form and logic source files
│   ├── Resources/          # UI icons and images
│   ├── Properties/         # Assembly and app settings
│   └── App.config          # Connection string config
├── Documentation.pdf
├── Smart-Quiz-Conducting-System_OOP.pptx
└── QuizApp.sln
```

---

## Documentation

- Full project documentation: [`Documentation.pdf`](Documentation.pdf)
- OOP design presentation: [`Smart-Quiz-Conducting-System_OOP.pptx`](Smart-Quiz-Conducting-System_OOP.pptx)