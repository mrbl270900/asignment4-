using Microsoft.AspNetCore.Mvc;

namespace WebServer.Controllers
{
    public class TestController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}