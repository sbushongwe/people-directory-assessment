People Directory

A full-stack People Directory application built using ASP.NET Core, Entity Framework Core and MVC.

The application consists of two main sections:
1. Public Client Section
2. Admin Management Section

The goal of the project was to implement a clean layered architecture while meeting the functional requirements around predictive search, filtering, CRUD management and email notifications.

Technologies Used:
- ASP.NET Core MVC (.NET 8)
- ASP.NET Core Web API
- Entity Framework Core (Code First)
- SQL Server
- Bootstrap 5
- AdminLTE
- jQuery / AJAX
- MailKit (SMTP Email Sending)

Architecture & Design Patterns:
The solution follows a layered architecture and makes use of the following patterns and principles:
- MVC Pattern
- Repository Pattern
- Dependency Injection
- DTO Pattern

SOLID Principles:
The project was structured with separation of concerns in mind
Controllers handle request orchestration only
Services contain business logic
Repositories handle database access
DTOs are used for API contracts and response shaping

--------------------------------------------------------------------------------------------------------------------------------

Solution Structure:
- PeopleDirectory.API
- PeopleDirectory.Core
- PeopleDirectory.Infrastructure
- PeopleDirectory.Web

PeopleDirectory.Core
Contains:
- Entities
- Interfaces
- DTOs
- Configuration models
- Business contracts

PeopleDirectory.Infrastructure
Contains:
- Entity Framework DbContext
- Repository implementations
- Email service implementation
- External integrations

PeopleDirectory.API
Contains:
- REST API endpoints
- Dependency injection setup
- Application configuration
  
PeopleDirectory.Web
Contains:
- MVC frontend
- Admin management UI
- AJAX interactions

------------------------------------------------------------------------------------------------------------------------

Email Notifications
The application sends email notifications whenever:
- A person record is created
- A person record is updated

Emails include:
- Previous values
- New values
- Timestamp

SMTP email sending was implemented using MailKit.

Email Configuration
SMTP settings are configured inside:

PeopleDirectory.API/appsettings.json

"EmailSettings": {
  "SmtpServer": "smtp.gmail.com",
  
  "Port": 587,
  
  "SenderName": "People Directory",
  
  "SenderEmail": "your-email@gmail.com",
  
  "Username": "your-email@gmail.com",
  
  "Password": "your-app-password",
  
  "Recipient": "mark@bluegrassdigital.com"
}

If you will be using Gmail as SMTP, then follow the below steps:
- Enable 2-Factor Authentication
- Generate an App Password
- Use the App Password instead of your normal Gmail password

For security reasons, I have removed my Gmail credentials from the code.

----------------------------------------------------------------------------------------------------------------------

Database:

Entity Framework Core Code First approach was the one used.

Migrations were created using:
- Add-Migration InitialCreate
- Update-Database

----------------------------------------------------------------------------------------------------------------------

Running The Application:

1. Clone the repository
- git clone https://github.com/sbushongwe/people-directory-assessment.git
- GitHub CLI: gh repo clone sbushongwe/people-directory-assessment

2. Configure appsettings.json

   Update the Database connection string, SMTP settings, Admin credentials

3. Run EF Core Migrations

   Inside Package Manager Console: run Update-Database

4. Run the Solution

   Set both PeopleDirectory.API and PeopleDirectory.Web as startup projects.

-----------------------------------------------------------------------------------------------------------------------

Notes

For assessment simplicity:
- Session-based authentication was used instead of ASP.NET Identity
- Admin credentials are stored in configuration

In a production environment:
- ASP.NET Identity would be my preferrence
- Password hashing would be implemented on passwords
- Role-based authorization would be added

Additionally, in production I’d move email sending to a background process or queue to improve responsiveness and avoid blocking user requests during SMTP operations.
