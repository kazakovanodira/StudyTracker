using Microsoft.AspNetCore.Mvc;

namespace StudyTracker.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
