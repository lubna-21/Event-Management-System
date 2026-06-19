# Event Management System

A full-featured event booking platform built with **ASP.NET Core MVC**, following a clean layered architecture (Controller → Service → Repository → EF Core). The system supports two types of users — **Admins** who manage events and bookings, and **Users** who browse, search, and book events.

## Features

### Admin Panel
- Secure admin login with session-based authentication
- Dashboard showing total users, total events, and total bookings
- Create, edit, and delete event categories (e.g. Birthday, Wedding, Anniversary)
- View and manage all registered users (edit / delete)
- View all bookings and confirm or cancel them

### User Panel
- User registration with confirm-password validation
- Secure login with session-based authentication
- Browse all available events with **search by name** and **filter by price range**
- Book an event by selecting seat count (auto-calculates total price)
- View a printable **booking invoice / receipt** right after confirming a booking
- View "My Bookings" with live status (Pending / Confirmed)
- Cancel a booking while it is still Pending

## Tech Stack

| Layer | Technology |
|---|---|
| Frontend | ASP.NET Core MVC, Razor Views, Bootstrap |
| Backend | ASP.NET Core MVC (C#) |
| Database | SQL Server |
| ORM | Entity Framework Core |
| Object Mapping | AutoMapper |
| Architecture | Controller → Service → Repository (layered) |

## Project Structure

```
EventManag/
├── DAL/                          # Data Access Layer
│   ├── EF/
│   │   ├── EventDBContext.cs
│   │   └── Tables/                # Admin, User, EventCategory, Booking
│   └── Repo/                      # AdminRepo, UserRepo, EventCategoryRepo, BookingRepo
│
├── BLL/                          # Business Logic Layer
│   ├── DTOs/                      # AdminDTO, UserDTO, EventCategoryDTO, BookingDTO, EditUserDTO
│   ├── Services/                  # AdminService, UserService, EventCategoryService, BookingService
│   ├── Validation/                 # Custom validation attributes
│   └── Mapperconfig.cs            # AutoMapper configuration
│
└── EventSystem/                  # Presentation Layer
    ├── Controllers/                # AdminController, UserController, EventCategoryController, HomeController
    ├── Views/
    │   ├── Admin/                   # Dashboard, Users, EventCategories, Bookings...
    │   ├── User/                    # Register, Login, Dashboard
    │   ├── EventCategory/           # Index, Book, Invoice, MyBookings
    │   └── Shared/                  # _Layout and partials
    └── Program.cs
```

## Database Schema

- **Admins** — Id, FullName, Email, Password
- **Users** — Id, FullName, Email, Phone, Password, CreatedAt
- **EventCategories** — Id, Name, Price
- **Bookings** — Id, UserId, EventCategoryId, SeatCount, TotalPrice, BookingDate, Status

## Getting Started

### Prerequisites
- .NET SDK 8.0+
- SQL Server (or SQL Server Express)
- Visual Studio 2022

### Setup

1. Clone the repository
   ```bash
   git clone https://github.com/lubna-21/Event-Management-System.git
   ```

2. Open `EventManag.slnx` in Visual Studio

3. Update the connection string in `EventSystem/appsettings.json` to point to your SQL Server instance

4. Apply migrations / create the database
   ```bash
   Update-Database
   ```

5. Run the project (F5)

6. The app opens at `/Home/SelectLogin` where you can choose to log in as Admin or User

## Author

**Lubna Akter**
CSE Student, American International University-Bangladesh (AIUB)
📧 lubnaakter995@gmail.com
