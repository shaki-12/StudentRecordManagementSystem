# Student Record Management System

## Introduction

This project is a simple Student Record Management System developed using ASP.NET Core MVC, ADO.NET, SQL Server, and Stored Procedures. It allows different users to access the system based on their roles.

There are two types of users:

- **Invigilator** – Can manage student records.
- **Student** – Can log in and view their own academic record.

---

## Features

### Invigilator

- Add a new student record
- Update marks of an existing student
- Delete a student record (Soft Delete)
- View all student records
- Search and view a student record using roll number

### Student

- Login to the system
- View own academic details and marks

---

## Technologies Used

- ASP.NET Core MVC
- ADO.NET
- SQL Server
- Stored Procedures
- Cookie Authentication
- Bootstrap

---

## Architecture Used

```
Views
↓
Controllers
↓
Service Layer
↓
Repository Layer
↓
ADO.NET
↓
Stored Procedures
↓
SQL Server
```

---

## Project Structure

```
Controllers
Models
Interfaces
Repositories
Services
Views
wwwroot
```

---

## Database Tables

### Students

- Id
- RollNumber
- Name
- Maths
- Physics
- Chemistry
- English
- Programming
- IsActive

### Users

- UserId
- Username
- Password
- Role
- RollNumber

---

## Validation

The application includes both client-side and server-side validation.

- Student name is mandatory
- Name cannot exceed 30 characters
- Name accepts only alphabets and spaces
- Marks should be between 1 and 100
- Negative marks are not allowed

---

## Authentication and Authorization

Cookie Authentication is used to provide role-based access.

### Roles

- **Invigilator**
- **Student**

Students can view only their own records, while invigilators have access to all management operations.

---

## How to Run the Project

1. Clone the repository.

```bash
git clone <repository-url>
```

2. Open the solution in Visual Studio 2022.

3. Restore the required NuGet packages.

4. Update the connection string in `appsettings.json`.

5. Execute the SQL scripts to create tables and stored procedures.

6. Run the application.

---

## Author

SHAKITH  A

Developed as part of a Machine Test using ASP.NET Core MVC and SQL Server.