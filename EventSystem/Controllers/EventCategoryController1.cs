using BLL.DTOs;
using BLL.Services;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace EventSystem.Controllers
{
    public class EventCategoryController : Controller
    {
        EventCategoryService eventCategoryService;
        BookingService bookingService;

        public EventCategoryController(EventCategoryService eventCategoryService, BookingService bookingService)
        {
            this.eventCategoryService = eventCategoryService;
            this.bookingService = bookingService;
        }

        public IActionResult Index(string? searchName, double? minPrice, double? maxPrice)
        {
            if (HttpContext.Session.GetString("UserId") == null)
                return RedirectToAction("Login", "User");

            ViewBag.UserName = HttpContext.Session.GetString("UserName");

            var data = eventCategoryService.Search(searchName, minPrice, maxPrice);

            ViewBag.SearchName = searchName;
            ViewBag.MinPrice = minPrice;
            ViewBag.MaxPrice = maxPrice;

            return View(data);
        }

        [HttpGet]
        public IActionResult Book(int id)
        {
            if (HttpContext.Session.GetString("UserId") == null)
                return RedirectToAction("Login", "User");

            var eventData = eventCategoryService.Get(id);
            var dto = new BookingDTO
            {
                EventCategoryId = eventData.Id,
                EventCategoryName = eventData.Name,
                EventPrice = eventData.Price
            };
            return View(dto);
        }

        [HttpPost]
        public IActionResult Book(BookingDTO dto)
        {
            if (ModelState.IsValid)
            {
                dto.UserId = int.Parse(HttpContext.Session.GetString("UserId")!);
                dto.TotalPrice = dto.SeatCount * dto.EventPrice;
                var res = bookingService.Create(dto);
                if (res)
                {
                    var lastBooking = bookingService.GetByUser(dto.UserId)
                                        .OrderByDescending(b => b.Id)
                                        .FirstOrDefault();
                    if (lastBooking != null)
                        return RedirectToAction("Invoice", new { id = lastBooking.Id });

                    return RedirectToAction("MyBookings");
                }
            }
            return View(dto);
        }

        public IActionResult Invoice(int id)
        {
            if (HttpContext.Session.GetString("UserId") == null)
                return RedirectToAction("Login", "User");

            int userId = int.Parse(HttpContext.Session.GetString("UserId")!);
            var booking = bookingService.Get(id);

            if (booking == null || booking.UserId != userId)
                return RedirectToAction("MyBookings");

            return View(booking);
        }

        public IActionResult MyBookings()
        {
            if (HttpContext.Session.GetString("UserId") == null)
                return RedirectToAction("Login", "User");

            int userId = int.Parse(HttpContext.Session.GetString("UserId")!);
            var data = bookingService.GetByUser(userId);
            return View(data);
        }

        public IActionResult CancelBooking(int id)
        {
            if (HttpContext.Session.GetString("UserId") == null)
                return RedirectToAction("Login", "User");

            int userId = int.Parse(HttpContext.Session.GetString("UserId")!);
            var booking = bookingService.Get(id);

            if (booking == null || booking.UserId != userId)
                return RedirectToAction("MyBookings");

            if (booking.Status == "Pending")
            {
                bookingService.Delete(id);
            }

            return RedirectToAction("MyBookings");
        }
    }
}