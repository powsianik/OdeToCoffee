using System.Collections.Generic;
using OdeToCoffee.Models;

namespace OdeToCoffee.ViewModels
{
    public class HomePageViewModel
    {
        public string MessageOfTheDay { get; set; }
        public IEnumerable<Coffeehouse> Coffeehouses { get; set; }
    }
}