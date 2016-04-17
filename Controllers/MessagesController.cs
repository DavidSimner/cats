using System;
using System.Text;
using Microsoft.AspNet.Mvc;

namespace cats.Controllers
{
    public class MessagesController : Controller
    {
        public IActionResult Between(string id)
        {
            var content = new StringBuilder();
            var total = 1 << (id != "4" ? 0 : 16);
            for (var i = 0; i < total; ++i)
            {
                content.AppendLine(Guid.NewGuid().ToString());
            }
            return new ContentResult { Content = content.ToString() };
        }
    }
}
