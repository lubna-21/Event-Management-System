@"
# 🎉 Event Management System

This project is a full-featured **event booking platform** built using **ASP.NET Core MVC**, designed to let users discover, search, and book events such as birthdays, weddings, and anniversaries — while giving admins complete control to manage events, users, and bookings.

The system follows a clean **layered architecture** (Controller → Service → Repository → EF Core) and demonstrates real-world concepts such as session-based authentication, role-based dashboards, search/filtering, and invoice generation.

---

## 🎯 Objectives

- Provide a simple, intuitive platform for users to browse and book events.
- Allow admins to manage event categories, users, and bookings from a central dashboard.
- Demonstrate clean separation of concerns using the Repository–Service–Controller pattern.
- Apply real-world features like search/filter, seat-based booking, and invoice generation.

---

## ✨ Key Features

### 👩‍💼 Admin Panel
- Secure admin login with session-based authentication
- Dashboard showing total users, total events, and total bookings
- Create, edit, and delete event categories (Birthday, Wedding, Anniversary, etc.)
- View, edit, and delete registered users
- View all bookings and confirm or cancel them

### 👤 User Panel
- User registration with confirm-password validation
- Secure login with session-based authentication
- Browse events with **search by name** and **filter by price range**
- Book events by selecting seat count (auto-calculates total price)
- View a printable **booking invoice/receipt** right after confirming
- Track bookings in "My Bookings" with live status (Pending / Confirmed)
- Cancel a booking while it is still Pending

---

## 🛠 Technologies Used

- C# / ASP.NET Core MVC
- Entity Framework Core
- SQL Server
- AutoMapper
- Razor Views + Bootstrap

---

## 🗄 Database Schema

| Table | Key Fields |
|---|---|
| **Admins** | Id, FullName, Email, Password |
| **Users** | Id, FullName, Email, Phone, Password, CreatedAt |
| **EventCategories** | Id, Name, Price |
| **Bookings** | Id, UserId, EventCategoryId, SeatCount, TotalPrice, BookingDate, Status |

---

## ⚙ Setup Instructions

1. Install **Visual Studio 2022** with the **ASP.NET and web development** workload.
2. Install **SQL Server** (or SQL Server Express).
3. Clone the repository:
``````bash
   git clone https://github.com/lubna-21/Event-Management-System.git
``````
4. Open ``EventManag.slnx`` in Visual Studio.
5. Update the connection string in ``EventSystem/appsettings.json`` to point to your SQL Server instance.
6. Apply migrations to create the database:
``````bash
   Update-Database
``````
7. Run the project (**F5**). The app opens at ``/Home/SelectLogin``, where you can log in as **Admin** or **User**.

---

## 🚀 How It Works

- A **User** registers, logs in, and lands on the Event Category page where all events are listed with price and available booking option.
- Users can **search** events by name or **filter by price range** to quickly find what they need.
- Selecting **Book Now** lets the user choose a seat count, after which a **booking invoice** is generated automatically.
- An **Admin** logs in separately to manage event categories, view/edit/delete users, and confirm or cancel bookings from a dedicated dashboard.

---

## 🔮 Future Enhancements

- Add online payment gateway integration for booking confirmation.
- Add event image uploads for a richer browsing experience.
- Add email notifications for booking confirmation and cancellation.
- Add pagination for large event/user/booking lists.
- Add password hashing (BCrypt) for stronger security.

---

## 👩‍💻 Author

**Lubna Akter**
CSE Student, American International University–Bangladesh (AIUB)
📧 lubnaakter995@gmail.com
🔗 [GitHub](https://github.com/lubna-21)
"@ | Out-File -FilePath README.md -Encoding utf8
