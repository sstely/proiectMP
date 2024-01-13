using System.ComponentModel.DataAnnotations;

namespace proiectMP.Models
{
    public class Allergen
    {
        public int ID { get; set; }

        [Display(Name = "Allergen")]
        public string AllergenName { get; set; }

        public ICollection<ProductAllergen>? ProductAllergens { get; set; }

    }
}
