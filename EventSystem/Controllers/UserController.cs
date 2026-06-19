using BLL.DTOs;
using BLL.Services;
using Microsoft.AspNetCore.Mvc;

namespace EventSystem.Controllers
{
    public class UserController : Controller
    {
        UserService userService;

        public UserController(UserService userService)
        {
            this.userService = userService;
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View(new UserDTO());
        }

        [HttpPost]
        public IActionResult Register(UserDTO dto)
        {
            if (ModelState.IsValid)
            {
                if (userService.EmailExists(dto.Email))
                {
                    ViewBag.Error = "Email already registered";
                    return View(dto);
                }
                var res = userService.Create(dto);
                if (res) return RedirectToAction("Login");
            }
            return View(dto);
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View(new UserDTO());
        }

        [HttpPost]
        public IActionResult Login(UserDTO dto)
        {
            var res = userService.Login(dto.Email, dto.Password);
            if (res != null)
            {
                HttpContext.Session.SetString("UserId", res.Id.ToString());
                HttpContext.Session.SetString("UserName", res.FullName);

                return RedirectToAction("Index", "EventCategory");
            }
            ViewBag.Error = "Invalid email or password";
            return View(dto);
        }

        public IActionResult Logout()
        {
            if (HttpContext.Session.GetString("UserId") != null)
            {
                HttpContext.Session.Remove("UserId");
                HttpContext.Session.Remove("UserName");
                return RedirectToAction("Register");
            }
            return RedirectToAction("Register");
        }

        public IActionResult Dashboard()
        {
            if (HttpContext.Session.GetString("UserId") == null)
                return RedirectToAction("Login");

            ViewBag.UserName = HttpContext.Session.GetString("UserName");
            return View();
        }
    }
}
