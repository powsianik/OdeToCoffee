using Microsoft.AspNetCore.Mvc;

namespace OdeToCoffee.Controllers
{
    public class HomeController : Controller
    {
        public string Index()
        {
            return "Hello MVC";
        }
    }
}