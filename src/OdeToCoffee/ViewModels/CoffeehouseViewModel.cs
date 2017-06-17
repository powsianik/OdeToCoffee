using System.ComponentModel.DataAnnotations;
using OdeToCoffee.Model.Entities;

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