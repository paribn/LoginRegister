using Microsoft.AspNetCore.Mvc;

namespace login.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

    }
}