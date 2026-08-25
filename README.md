# New Finance Bank(NFB) Employee Information

NFB Employee Information is a Windows desktop employee directory built with C# Windows Forms. It is designed to let users maintain employee contact information, associate employees with internal extensions and departments, search for an employee, and view basic usage guidance.

## Project status

This repository contains an internship-era prototype. The user interface and database access layer show the intended workflow, but the current checkout is not build-ready. In particular:

- `Newdesign/Form1.cs` contains CSS markup instead of the `Form1` C# partial class implementation expected by the project.
- `Newdesign/Help.cs` contains an invalid C# method declaration and Java-style syntax.
- `Newdesign/DataManagement.cs` ends with an invalid `AddingUsers` declaration and Java-style syntax.
- `SQLQuery1.sql` contains destructive and syntactically invalid SQL statements in addition to the table definitions.
- The application uses a LocalDB connection in `DataManagement.ConnectDB`, while `App.config` and `Properties/Settings.settings` contain a different SQL Server Express connection string and database name.

These issues should be resolved before treating the project as a deployable application.

## Features

### Home: employee search

The Home view provides a search box for an employee's exact name. When a matching record is found, it displays:

- Profile image
- Full name
- Gender
- Telephone number
- Extension
- Department/location
- Role

Employee profile images are stored as Base64 strings and converted back into images when displayed.

### Add employee

The Add Employee view collects:

- Full name
- Gender, using Male/Female radio buttons
- Phone number
- Department
- Extension
- Role in department
- Profile image

Departments and extensions are loaded into combo boxes from the `Extensions` table. A profile image can be selected through a file picker supporting JPEG, BMP, PNG, and JPG files. Saving inserts the employee record into the database and shows the result in a message box.

### Add extension

The Add Extension view creates an extension/location entry. The user enters a department name and extension number, then saves the values to the `Extensions` table.

### Help

The Help view explains the purpose of Home, Add Extension, and Add Employee. The main form also includes sidebar navigation and social/web image buttons.

## Technology

- C# Windows Forms
- .NET Framework 4.6.1
- Visual Studio 2017-era MSBuild project format
- SQL Server / SQL Server LocalDB
- `System.Data.SqlClient` for database access
- Embedded Windows Forms resources (`.resx`)

## Repository structure

```text
.
|-- Newdesign.sln
|-- SQLQuery1.sql                 Database/table draft for NFBDataBase
|-- SQLQuery2.sql                 Unrelated database experiment
|-- Newdesign/
    |-- Newdesign.csproj          .NET Framework WinForms project
    |-- Program.cs                Application entry point
    |-- Form1.*                   Main window and designer resources
    |-- MainPage.*                Employee search view
    |-- AddEmployeeMainPage.*     Employee creation view
    |-- AddExtensionPanel.*       Extension/location creation view
    |-- Help.*                    In-app help view
    |-- DataManagement.cs         Database and image helper methods
    |-- RegisterProperties.cs     Employee data model
    |-- ExtensionClass.cs         Extension data model
    |-- App.config                Runtime configuration
    |-- Properties/               Assembly, settings, and resource metadata
```

Designer files and resource files are generated or maintained by Visual Studio and should normally be edited through the Windows Forms designer.

## Database design

The application code expects a database named `NFBDataBase` with these tables:

```sql
CREATE TABLE Employee (
    ID INT PRIMARY KEY IDENTITY(1, 1),
    Name VARCHAR(50) NOT NULL,
    Gender VARCHAR(10) NOT NULL,
    Extension VARCHAR(30) NOT NULL,
    PhoneNumber VARCHAR(20) NOT NULL,
    Location VARCHAR(20) NOT NULL,
    Role VARCHAR(20) NOT NULL,
    Profile TEXT NOT NULL
);

CREATE TABLE Extensions (
    ID INT PRIMARY KEY IDENTITY(1, 1),
    Extension VARCHAR(30) NOT NULL,
    Location VARCHAR(20) NOT NULL
);
```

`DataManagement` maps employee columns by ordinal position, so the column order returned by `SELECT * FROM Employee` must match the schema above. It maps extension rows as `ID`, `Extension`, and `Location`.

## Database connection

The active connection created in `DataManagement.ConnectDB` is:

```text
Data Source=(localdb)\ProjectsV13;Initial Catalog=NFBDataBase;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False
```

Before running the application, install SQL Server LocalDB or change the connection string to a reachable SQL Server instance. Create `NFBDataBase`, then create the `Employee` and `Extensions` tables with a reviewed schema script. Do not run the checked-in SQL script unchanged against a shared database because it includes `DROP DATABASE` and `DROP TABLE` statements.

The connection string in `Newdesign/App.config` points instead to `DESKTOP-TLJPLGA\SQLEXPRESS` and database `NfBEmployees`; this does not match the connection used by the application code. Keep one reviewed connection configuration and avoid committing machine-specific settings.

## Getting started

### Prerequisites

1. Windows
2. Visual Studio with the .NET desktop development workload
3. .NET Framework 4.6.1 developer targeting pack
4. SQL Server LocalDB or SQL Server Express
5. A configured `NFBDataBase` database with the required tables

### Build and run

1. Open `Newdesign.sln` in Visual Studio.
2. Restore or install the .NET Framework 4.6.1 developer tools if Visual Studio reports a missing target framework.
3. Review and correct the connection string and database schema.
4. Repair the invalid source files listed in [Project status](#project-status).
5. Set `Newdesign` as the startup project.
6. Build the solution with **Build > Build Solution**.
7. Run with **Debug > Start Debugging**.

The application entry point is `Newdesign/Program.cs`, which starts `Form1` and enables standard Windows Forms visual styles.

## Data access API

`DataManagement` exposes the following static operations:

- `ConnectDB()` creates the SQL connection.
- `AddEmployee(...)` inserts an employee.
- `AddExtensions(...)` inserts an extension/location record.
- `GetAllEmployees()` reads all employees.
- `GetAllExtensions()` reads all extensions.
- `UpdateEmployee(...)` updates all editable employee fields by ID.
- `DeleteUser(...)` deletes an employee by ID.
- `ImageToBase64(...)` serializes an image for storage.
- `Base64ToImage(...)` reconstructs an image for display.

## Important limitations and security notes

- SQL commands are assembled through string concatenation. This permits SQL injection and breaks when input contains apostrophes. Replace these commands with parameterized `SqlCommand` queries.
- Connections, commands, and readers are stored in public static fields and are manually opened/closed across multiple layers. Refactor to scoped `using` disposal patterns and avoid shared mutable connection state.
- Employee and extension lists are static and are appended to without being cleared, which can produce duplicate results across repeated reads.
- Employee search uses an exact, case-insensitive name comparison and does not report a clear not-found result.
- There is no visible validation for required fields, gender selection, phone format, duplicate extensions, or invalid/missing profile images.
- The database stores images as Base64 in a legacy `TEXT` column. A binary column such as `VARBINARY(MAX)` or managed file/object storage would be more appropriate for production use.
- The update and delete methods exist in the data layer but are not exposed by the current visible forms.
- Connection failures and database errors are not handled with user-friendly error handling.
- `SQLQuery2.sql` creates `StudentManagement` and queries a `Malawi` table; it does not match this application's schema and appears to be an unrelated experiment.

## Suggested repair order

1. Restore valid C# implementations for `Form1.cs`, `Help.cs`, and the invalid tail of `DataManagement.cs`.
2. Replace the SQL scripts with a safe, repeatable schema/migration script.
3. Consolidate the connection string into configuration and remove machine-specific values.
4. Parameterize every database command and add exception handling.
5. Add input validation and a not-found state to the UI.
6. Add automated tests for data mapping, image conversion, and database operations.

## License

No license file is included in this repository. Add an appropriate license before distributing the project.
