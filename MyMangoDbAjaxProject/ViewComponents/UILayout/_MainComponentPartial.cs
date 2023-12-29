using Microsoft.AspNetCore.Mvc;

namespace MyMangoDbAjaxProject.ViewComponents.MainComponents
{
    public class _MainComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
