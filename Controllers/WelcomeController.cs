using Microsoft.AspNet.Mvc;

namespace cats.Controllers
{
    public class WelcomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
