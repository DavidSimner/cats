using cats.Models;
using cats.Services;
using Microsoft.AspNet.Mvc;

namespace cats.Controllers
{
    public class NearbyController : Controller
    {
        private readonly SessionService m_SessionService;
        private readonly AccountService m_AccountService;
        
        public NearbyController(SessionService sessionService, AccountService accountService)
        {
            m_SessionService = sessionService;
            m_AccountService = accountService;
        }
        
        public IActionResult Index()
        {
            var session = CookieService.GetOrCreateSession(HttpContext);
            var email = m_SessionService.GetSessionEmail(session);
            if (email == null)
            {
                return RedirectToAction("index", "login");
            }
            
            var name = m_AccountService.GetName(email);
            
            return View(new Nearby(name));
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
