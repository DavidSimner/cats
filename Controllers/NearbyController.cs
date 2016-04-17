using Microsoft.AspNet.Mvc;

namespace cats.Controllers
{
    public class NearbyController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
