using Microsoft.AspNet.Mvc;

namespace cats.Controllers
{
    public class LoginController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
