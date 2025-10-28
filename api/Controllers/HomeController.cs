using Microsoft.AspNetCore.Mvc;

namespace Myshop.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
                // The MVC framework looks for a view file named
                // Index.cshtml in the Views/Home directory
        }
    }
}