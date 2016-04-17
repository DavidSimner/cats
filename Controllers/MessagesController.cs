using Microsoft.AspNet.Mvc;

namespace cats.Controllers
{
    public class MessagesController : Controller
    {
        public IActionResult Between(string id)
        {
            var content = new string(' ', 1 << (id != "4" ? 0 : 20));
            return new ContentResult { Content = content };
        }
    }
}
