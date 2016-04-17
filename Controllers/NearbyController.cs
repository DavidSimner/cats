using cats.Models;
using Microsoft.AspNet.Mvc;

namespace cats.Controllers
{
    public class NearbyController : Controller
    {
        public IActionResult Index()
        {
            return View(new Nearby("TODO"));
        }
    }
}
