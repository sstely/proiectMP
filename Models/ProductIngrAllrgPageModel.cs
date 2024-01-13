using Microsoft.AspNetCore.Mvc.RazorPages;
using proiectMP.Data;

namespace proiectMP.Models
{
    public class ProductIngrAllrgPageModel : PageModel
    {
        public List<AssignedIngredientData> AssignedIngredientDataList;
        public List<AssignedAllergenData> AssignedAllergenDataList;

        public void PopulateAssignedIngredientData(proiectMPContext context, Product product)
        {
            var allIngredients = context.Ingredient;
            var productIngredients = new HashSet<int>(product.ProductIngredients.Select(l => l.IngredientID));
            AssignedIngredientDataList = new List<AssignedIngredientData>();

            foreach (var ingr in allIngredients)
            {
                AssignedIngredientDataList.Add(new AssignedIngredientData
                {
                    IngredientID = ingr.ID,
                    Name = ingr.IngredientName,
                    Assigned = productIngredients.Contains(ingr.ID)
                });
            }
        }

        public void PopulateAssignedAllergenData(proiectMPContext context, Product product)
        {
            var allAllergens = context.Allergen;
            var productAllergens = new HashSet<int>(product.ProductAllergens.Select(l => l.AllergenID));
            AssignedAllergenDataList = new List<AssignedAllergenData>();

            foreach (var alg in allAllergens)
            {
                AssignedAllergenDataList.Add(new AssignedAllergenData
                {
                    AllergenID = alg.ID,
                    Name = alg.AllergenName,
                    Assigned = productAllergens.Contains(alg.ID)
                });
            }
        }

        public void UpdateProductIngredients(proiectMPContext context, string[] selectedIngredients, Product productToUpdate)
        {
            if (selectedIngredients == null)
            {
                productToUpdate.ProductIngredients = new List<ProductIngredient>();
                return;
            }

            var selectedIngredientsHS = new HashSet<string>(selectedIngredients);
            var productIngredients = new HashSet<int>(productToUpdate.ProductIngredients.Select(l => l.Ingredient.ID));

            foreach (var ingr in context.Ingredient)
            {
                if (selectedIngredientsHS.Contains(ingr.ID.ToString()))
                {
                    if (!productIngredients.Contains(ingr.ID))
                    {
                        productToUpdate.ProductIngredients.Add(new ProductIngredient
                        {
                            ProductID = productToUpdate.ID,
                            IngredientID = ingr.ID
                        });
                    }
                }
                else
                {
                    if (productIngredients.Contains(ingr.ID))
                    {
                        ProductIngredient courseToRemove = productToUpdate.ProductIngredients.SingleOrDefault(i => i.IngredientID == ingr.ID);
                        context.Remove(courseToRemove);
                    }
                }
            }
        }

        public void UpdateProductAllergens(proiectMPContext context, string[] selectedAllergens, Product productToUpdate)
        {
            if (selectedAllergens == null)
            {
                productToUpdate.ProductAllergens = new List<ProductAllergen>();
                return;
            }

            var selectedAllergensHS = new HashSet<string>(selectedAllergens);
            var productAllergens = new HashSet<int>(productToUpdate.ProductAllergens.Select(l => l.Allergen.ID));

            foreach (var alg in context.Allergen)
            {
                if (selectedAllergensHS.Contains(alg.ID.ToString()))
                {
                    if (!productAllergens.Contains(alg.ID))
                    {
                        productToUpdate.ProductAllergens.Add(new ProductAllergen
                        {
                            ProductID = productToUpdate.ID,
                            AllergenID = alg.ID
                        });
                    }
                }
                else
                {
                    if (productAllergens.Contains(alg.ID))
                    {
                        ProductAllergen courseToRemove = productToUpdate.ProductAllergens.SingleOrDefault(i => i.AllergenID == alg.ID);
                        context.Remove(courseToRemove);
                    }
                }
            }
        }
    }
}
