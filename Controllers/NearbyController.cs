using cats.Models;
using cats.Services;
using Microsoft.AspNet.Mvc;

namespace cats.Controllers
{
    public class NearbyController : Controller
    {
        private readonly SessionService m_SessionService;
        
        public NearbyController(SessionService sessionService)
        {
            m_SessionService = sessionService;
        }
        
        public IActionResult Index()
        {
            var session = CookieService.GetOrCreateSession(HttpContext);
            var email = m_SessionService.GetSessionEmail(session);
            if (email == null)
            {
                return RedirectToAction("index", "login");
            }
            
            return View(new Nearby(email));
        }
        
        public IActionResult Image(string id)
        {
            var session = CookieService.GetOrCreateSession(HttpContext);
            var email = m_SessionService.GetSessionEmail(session);
            if (email == null)
            {
                return RedirectToAction("index", "login");
            }
            
            return new RedirectResult($"/images/cats/{id}.jpg");
        }
    }
}
