using Microsoft.AspNetCore.Mvc;

namespace CrazyCarRental.Controllers
{
    public class UserController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
