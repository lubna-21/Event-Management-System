using BLL.DTOs;
using BLL.Services;
using Microsoft.AspNetCore.Mvc;

    namespace EventSystem.Controllers
    {
        public class AdminController : Controller
        {
            AdminService adminService;
            UserService userService;
            EventCategoryService eventCategoryService;
            BookingService bookingService;

            public AdminController(AdminService adminService, UserService userService,
                EventCategoryService eventCategoryService, BookingService bookingService)
            {
                this.adminService = adminService;
                this.userService = userService;
                this.eventCategoryService = eventCategoryService;
                this.bookingService = bookingService;
            }

            [HttpGet]
            public IActionResult Login()
            {
                return View(new AdminDTO());
            }

            [HttpPost]
            public IActionResult Login(AdminDTO dto)
            {
                var res = adminService.Login(dto.Email, dto.Password);
                if (res != null)
                {
                    HttpContext.Session.SetString("AdminId", res.Id.ToString());
                    HttpContext.Session.SetString("AdminName", res.FullName);
                    return RedirectToAction("Dashboard");
                }
                ViewBag.Error = "Invalid email or password";
                return View(dto);
            }

        public IActionResult Logout()
        {
            if (HttpContext.Session.GetString("AdminId") != null)
            {
                HttpContext.Session.Remove("AdminId");
                HttpContext.Session.Remove("AdminName");
                return RedirectToAction("Register", "User");
            }
            return RedirectToAction("Register", "User");
        }
            public IActionResult Dashboard()
            {
                if (HttpContext.Session.GetString("AdminId") == null)
                    return RedirectToAction("Login");

                ViewBag.TotalUsers = userService.Get().Count;
                ViewBag.TotalEvents = eventCategoryService.Get().Count;
                ViewBag.TotalBookings = bookingService.Get().Count;
                ViewBag.AdminName = HttpContext.Session.GetString("AdminName");
                return View();
            }

            
            public IActionResult Users()
            {
                if (HttpContext.Session.GetString("AdminId") == null) return RedirectToAction("Login");
                return View(userService.Get());
            }

            [HttpGet]
            public IActionResult DeleteUser(int id)
            {
                if (HttpContext.Session.GetString("AdminId") == null) return RedirectToAction("Login");
                return View(userService.Get(id));
            }

            [HttpPost]
            public IActionResult DeleteUser(int id, string Decision)
            {
                if (Decision.Equals("Yes"))
                {
                    userService.Delete(id);
                }
                return RedirectToAction("Users");
            }

           
            public IActionResult EventCategories()
            {
                if (HttpContext.Session.GetString("AdminId") == null) return RedirectToAction("Login");
                return View(eventCategoryService.Get());
            }

            [HttpGet]
            public IActionResult CreateEvent()
            {
                if (HttpContext.Session.GetString("AdminId") == null) return RedirectToAction("Login");
                return View(new EventCategoryDTO());
            }

            [HttpPost]
            public IActionResult CreateEvent(EventCategoryDTO dto)
            {
                if (ModelState.IsValid)
                {
                    var res = eventCategoryService.Create(dto);
                    if (res) return RedirectToAction("EventCategories");
                }
                return View(dto);
            }

            [HttpGet]
            public IActionResult EditEvent(int id)
            {
                if (HttpContext.Session.GetString("AdminId") == null) return RedirectToAction("Login");
                return View(eventCategoryService.Get(id));
            }

            [HttpPost]
            public IActionResult EditEvent(EventCategoryDTO dto)
            {
                if (ModelState.IsValid)
                {
                    var res = eventCategoryService.Update(dto);
                    if (res) return RedirectToAction("EventCategories");
                }
                return View(dto);
            }

            [HttpGet]
            public IActionResult DeleteEvent(int id)
            {
                if (HttpContext.Session.GetString("AdminId") == null) return RedirectToAction("Login");
                return View(eventCategoryService.Get(id));
            }

            [HttpPost]
            public IActionResult DeleteEvent(int id, string Decision)
            {
                if (Decision.Equals("Yes"))
                {
                    eventCategoryService.Delete(id);
                }
                return RedirectToAction("EventCategories");
            }

            public IActionResult Bookings()
            {
                if (HttpContext.Session.GetString("AdminId") == null) return RedirectToAction("Login");
                return View(bookingService.Get());
            }

        public IActionResult ConfirmBooking(int id)
        {
            bookingService.UpdateStatus(id, "Confirmed");
            return RedirectToAction("Bookings");
        }
        public IActionResult CancelBooking(int id)
        {
            bookingService.Delete(id);
            return RedirectToAction("Bookings");
        }

            [HttpGet]
            public IActionResult DeleteBooking(int id)
            {
                if (HttpContext.Session.GetString("AdminId") == null) return RedirectToAction("Login");
                return View(bookingService.Get(id));
            }

            [HttpPost]
            public IActionResult DeleteBooking(int id, string Decision)
            {
                if (Decision.Equals("Yes"))
                {
                    bookingService.Delete(id);
                }
                return RedirectToAction("Bookings");
            }
        }
    }