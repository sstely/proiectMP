using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Security.Policy;

namespace proiectMP.Models
{
    public class Product
    {
        public int ID { get; set; }

        [Display(Name = "Product")]
        [StringLength(200, ErrorMessage = "Name length too long. It can't be more than 200")]
        public string Name { get; set; }

        [StringLength(500, ErrorMessage = "Description too long. It can't be more than 500")]
        public string Description { get; set; }

        [Column(TypeName = "decimal(6,2)")]
        [Range(0.01, 500)]
        public decimal Price { get; set; }

        public int Quantity { get; set; }

        public int? CategoryID { get; set; }

        public Category? Category { get; set; }

        public ICollection<ProductIngredient>? ProductIngredients { get; set; }

        public ICollection<ProductAllergen>? ProductAllergens { get; set; }

        public string CoverImageURL { get; set; }


        [NotMapped]

        public IFormFile CoverImageFile { get; set; }

    }
}
