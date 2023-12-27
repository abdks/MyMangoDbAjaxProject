using Microsoft.AspNetCore.Mvc;

namespace MyMangoDbAjaxProject.Controllers
{
	public class UIController : Controller
	{
		public IActionResult Index()
		{
			return View();
		}
	}
}
