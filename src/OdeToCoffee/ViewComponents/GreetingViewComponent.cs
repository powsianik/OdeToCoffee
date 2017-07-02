using Microsoft.AspNetCore.Mvc;
using OdeToCoffee.Services;

namespace OdeToCoffee.ViewComponents
{
    public class GreetingViewComponent : ViewComponent
    {
        private IMessageGetter messageGetter;

        public GreetingViewComponent(IMessageGetter messageGetter)
        {
            this.messageGetter = messageGetter;
        }

        public IViewComponentResult Invoke()
        {
            var model = this.messageGetter.GetMessage();

            return View("Default", model);
        }
    }
}