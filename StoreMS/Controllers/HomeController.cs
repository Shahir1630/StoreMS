using Microsoft.AspNetCore.Mvc;
using StoreMS.Data;
using StoreMS.Models;
using StoreMS.ViewModels;
using System.Diagnostics;

namespace StoreMS.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly DataContext _context;

        public HomeController(ILogger<HomeController> logger, DataContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult AdminDashboard()
        {
            return View();
        }
        public IActionResult ManagerDashboard()
        {
            return View();
        }

        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Login(LoginViewModel model)
        {
            var user = _context.Users.FirstOrDefault(x => x.Email == model.Email && x.Password == model.Password);
            if (user == null)
            {
                return View("Error", new ErrorViewModel { RequestId = "User Email or Password are Wrong!!"});
            }
            HttpContext.Session.SetString("userId", user.Id.ToString());
            HttpContext.Session.SetString("email", user.Email.ToString());
            HttpContext.Session.SetString("actorId", user.ActorId.ToString());
            if (user.ActorId == 1)
                return RedirectToAction(nameof(AdminDashboard));
            if (user.ActorId == 2)
                return RedirectToAction(nameof(ManagerDashboard));
            
            return RedirectToAction(nameof(Index));

        }

        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction(nameof(Login));
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}