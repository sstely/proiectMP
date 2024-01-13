namespace proiectMP.Models
{
    public class ProductAllergen
    {
        public int ID { get; set; }
        public int ProductID { get; set; }
        public Product Product { get; set; }
        public int AllergenID { get; set; }
        public Allergen Allergen { get; set; }
    }
}
