# Student Event Management System (CCP Project)

This project is a backend RESTful API developed using ASP.NET Core Web API and Entity Framework Core as part of the Complex Computing Problem (CCP) assignment for the Web Engineering course. 
The API allows management of events, student registrations for events (many-to-many relationship), and submission of feedback after event completion.

## Technologies Used

- ASP.NET Core 8.0 Web API
- Entity Framework Core 8.0
- SQL Server LocalDB (Local Database)
- Swagger (API Testing Tool)
- Visual Studio Code

## Project Structure

- **Controllers/** – Contains API endpoint logic for Events, Registration, and Feedback.
- **Models/** – Defines EF Core entities: Event, Student, Registration, and Feedback.
- **Data/** – Contains the `ApplicationDbContext` used for database configuration and model binding.
- **DTOs/** – Reserved folder for future use of Data Transfer Objects (currently not required).
- **Services/** – Reserved folder for separating business logic if needed (currently empty).
- **Migrations/** – Contains EF Core migration files generated via CLI commands.

## How to Run the Project

1. Open the terminal in the root project folder.
2. Run EF Core migration commands to generate the database:
dotnet ef migrations add InitialCreate
dotnet ef database update
3. Run the project using:
dotnet run
4. Once the application starts, navigate to Swagger UI for testing:
http://localhost:{your-port}/swagger

Replace `{your-port}` with the actual port number shown in the terminal.

## API Functionality

- **Events**
- Create, Read, Update, Delete Events
- Search by name or venue
- Filter by date or venue
- **Registration**
- Register a student to an event
- Prevent duplicate registration
- View registered students per event
- **Feedback**
- Submit feedback for an event only after it has ended
- View feedback per event

## Notes

- All responses use standard HTTP status codes (`200 OK`, `201 Created`, `400 Bad Request`, `404 Not Found`, etc.).
- Entity relationships and data integrity are handled via EF Core configuration in `ApplicationDbContext`.


## Author

Usman Asalat (63158)
BS (Software Engineering)  
Web Engineering - Complex Computing Problem Submission  
FEST
