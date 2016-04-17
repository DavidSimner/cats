using cats.Services;
using Microsoft.AspNet.Mvc;

namespace cats.Controllers
{
    public class SessionController : Controller
    {
        private readonly LoginService m_LoginService;
        private readonly SessionService m_SessionService;
        
        public SessionController(LoginService loginService, SessionService sessionService)
        {
            m_LoginService = loginService;
            m_SessionService = sessionService;
        }
        
        [HttpPost]
        public IActionResult LogIn(string email, string password)
        {
            if (!m_LoginService.IsPasswordCorrect(email, password))
            {
                return new BadRequestResult();
            }
            
            var session = CookieService.GetOrCreateSession(HttpContext);
            
            m_SessionService.LogSessionIn(session, email);
            
            return new NoContentResult();
        }
    }
}
