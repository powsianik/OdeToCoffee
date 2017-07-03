using Microsoft.AspNetCore.Mvc;

namespace OdeToCoffee.ViewComponents
{
    public class LoginLogoutViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}