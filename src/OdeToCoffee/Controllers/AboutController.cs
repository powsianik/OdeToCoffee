using Microsoft.AspNetCore.Mvc;

namespace OdeToCoffee.Controllers
{
    [Route("about")]
    public class AboutController
    {
        [Route("")]
        public string Phone()
        {
            return "+48-000-000-000";
        }

        [Route("address")]
        public string Address()
        {
            return "ul.Prosta Krzywo 07-007";
        }
    }
}