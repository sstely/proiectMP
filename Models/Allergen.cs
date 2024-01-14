using System.ComponentModel.DataAnnotations;

namespace proiectMP.Models
{
    public class Allergen
    {
        public int ID { get; set; }

        [Display(Name = "Allergen")]
        [StringLength(80, ErrorMessage = "Name length too long. It can't be more than 80")]
        public string AllergenName { get; set; }

        public ICollection<ProductAllergen>? ProductAllergens { get; set; }

    }
}
