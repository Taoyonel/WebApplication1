using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Controllers
{
    public class Demo : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
