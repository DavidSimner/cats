using cats.Services;
using Microsoft.AspNet.Mvc;

namespace cats.Controllers
{
    public class AccountController : Controller
    {
        private readonly SessionService m_SessionService;
        private readonly AccountService m_AccountService;
        
        public AccountController(SessionService sessionService, AccountService accountService)
        {
            m_SessionService = sessionService;
            m_AccountService = accountService;
        }
        
        [HttpPost]
        public IActionResult ChangeName(string name)
        {
            // only AJAX requests can call this so no need for CSRF protection
            
            var session = CookieService.GetOrCreateSession(HttpContext);
            var email = m_SessionService.GetSessionEmail(session);
            if (email == null)
            {
                return RedirectToAction("index", "login");
            }
            
            m_AccountService.SetName(email, name);
            
            return new NoContentResult();
        }
    }
}
