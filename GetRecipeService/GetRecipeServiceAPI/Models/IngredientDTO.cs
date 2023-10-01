using System.ComponentModel.DataAnnotations;

namespace GetRecipeServiceAPI.Models;

public record IngredientDTO : FoodItemDTO
{
    public IngredientDTO() { }

    //Constructor without ID
    public IngredientDTO(string name, string type, string description, string unit, float quantity, int foodItemId, int recipeId)
    {

        this.Name = name;
        this.Type = type;
        this.Description = description;
        this.Unit = unit;
        this.Quantity = quantity;
        this.FoodItemId = foodItemId;
        this.RecipeId = recipeId;

    }
    public IngredientDTO(string name, string type, string description, int ingredientId, string unit, float quantity, int foodItemId, int recipeId)
    {

        this.IngredientId = ingredientId;
        this.Name = name;
        this.Type = type;
        this.Description = description;
        this.Unit = unit;
        this.Quantity = quantity;
        this.FoodItemId = foodItemId;
        this.RecipeId = recipeId;

    }

    [Required]
    public int IngredientId { get; set; }
    [Required]
    public float? Quantity { get; set; }
    [Required]
    public string? Unit { get; set; }
    [Required]
    public int RecipeId { get; set; }

}