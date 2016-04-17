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
            for (var i = 0; i < 1 << 9; ++i)
            {
                content.AppendLine(Guid.NewGuid().ToString());
            }
            return new ContentResult { Content = content.ToString() };
        }
    }
}
