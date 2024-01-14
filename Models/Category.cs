using System.ComponentModel.DataAnnotations;

namespace proiectMP.Models
{
    public class Category
    {
        public int ID { get; set; }

        [Display(Name = "Category")]
        [StringLength(50, ErrorMessage = "Name length too long. It can't be more than 50")]
        public string CategoryName { get; set; }

        public ICollection<Product>? Products { get; set; }
    }
}
