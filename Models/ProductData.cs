namespace proiectMP.Models
{
    public class ProductData
    {
        public IEnumerable<Product> Products { get; set; }
        public IEnumerable<Ingredient> Ingredients { get; set; }
        public IEnumerable<ProductIngredient> ProductIngredients { get; set; }
        public IEnumerable<Allergen> Allergens { get; set; }
        public IEnumerable<ProductAllergen> ProductAllergens { get; set; }
    }
}
