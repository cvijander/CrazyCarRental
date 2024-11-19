using Microsoft.AspNetCore.Mvc;

namespace CrazyCarRental.Controllers
{
    public class ReviewController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
