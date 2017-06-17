using System.ComponentModel.DataAnnotations;

namespace OdeToCoffee.Model.Entities
{
    public enum CoffeehouseStyle
    {
        None,
        Modern,
        Classic,
        Mixed,
    }

    public class Coffeehouse
    {
        public int Id { get; set; }

        [Display(Name="Coffeehouse Name: ")]
        [MinLength(4)]
        public string Name { get; set; }

        public CoffeehouseStyle Style { get; set; }
    }
}