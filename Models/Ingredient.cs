using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace proiectMP.Models
{
    public class Ingredient
    {
        public int ID { get; set; }

        [Display(Name = "Ingredient")]
        [StringLength(200, ErrorMessage = "Name length too long. It can't be more than 200")]
        public string IngredientName { get; set; }

        [Column(TypeName = "decimal(8,2)")]
        public decimal Calories { get; set; }

        [Column(TypeName = "decimal(8,2)")]
        public decimal Unsaturated_Fats { get; set; }

        [Column(TypeName = "decimal(8,2)")]
        public decimal Saturated_Fats { get; set; }

        [Column(TypeName = "decimal(8,2)")]
        public decimal Sugars { get; set; }

        [Column(TypeName = "decimal(8,2)")]
        public decimal Fibers { get; set; }

        [Column(TypeName = "decimal(8,2)")]
        public decimal Proteins { get; set; }

        [Column(TypeName = "decimal(8,2)")]
        public decimal Minerals { get; set; }

        public ICollection<ProductIngredient>? ProductIngredients { get; set; }

    }
}
