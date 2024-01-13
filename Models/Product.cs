using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace proiectMP.Models
{
    public class Product
    {
        public int ID { get; set; }

        [Display(Name = "Product")]
        public string Name { get; set; }

        public string Description { get; set; }

        [Column(TypeName = "decimal(6,2)")]
        public decimal Price { get; set; }

        public int Quantity { get; set; }

        public string CoverImageURL { get; set; }

    }
}
