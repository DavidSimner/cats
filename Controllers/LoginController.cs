using cats.Services;
using Microsoft.AspNet.Mvc;

namespace cats.Controllers
{
    public class LoginController : Controller
    {
        private readonly LoginService m_LoginService;
        
        public LoginController(LoginService loginService)
        {
            m_LoginService = loginService;
        }
        
        public IActionResult Index()
        {
            return View();
        }
        
        [HttpPost]
        public void DoLogin(string email, string password)
        {
        }
    }
}
