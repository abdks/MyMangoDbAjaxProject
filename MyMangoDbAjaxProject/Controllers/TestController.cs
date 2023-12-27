using Microsoft.AspNetCore.Mvc;

namespace MyMangoDbAjaxProject.Controllers
{
    public class TestController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
