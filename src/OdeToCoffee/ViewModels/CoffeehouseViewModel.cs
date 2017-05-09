using System.ComponentModel.DataAnnotations;
using OdeToCoffee.Models;

namespace OdeToCoffee.ViewModels
{
    public class CoffeehouseViewModel
    {
        [MinLength(4)]
        [Required]
        public string Name { get; set; }

        public CoffeehouseStyle Style { get; set; }
    }
}