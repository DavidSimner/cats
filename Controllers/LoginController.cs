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
        public IActionResult DoLogin(string email, string password)
        {
            if (!m_LoginService.IsPasswordCorrect(email, password))
            {
                return new BadRequestResult();
            }
            
            return new NoContentResult();
        }
    }
}
