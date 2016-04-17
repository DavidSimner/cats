using cats.Services;
using Microsoft.AspNet.Mvc;

namespace cats.Controllers
{
    public class LoginController : Controller
    {
        private readonly LoginService m_LoginService;
        private readonly SessionService m_SessionService;
        
        public LoginController(LoginService loginService, SessionService sessionService)
        {
            m_LoginService = loginService;
            m_SessionService = sessionService;
        }
        
        public IActionResult Index()
        {
            return View();
        }
        
        [HttpPost]
        public IActionResult DoLogin(string email, string password)
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
