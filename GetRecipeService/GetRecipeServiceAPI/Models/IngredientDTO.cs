using System.ComponentModel.DataAnnotations;

namespace GetRecipeServiceAPI.Models;

public record IngredientDTO : FoodItemDTO
{
    public IngredientDTO(){}
    public IngredientDTO(int ingredientId, float quantity, string unit, int foodItemId, string name, string type, string description){
        
        this.IngredientId = ingredientId;
        this.Quantity = quantity;
        this.Unit = unit;
        this.FoodItemId = foodItemId;
        this.Name = name;
        this.Type = type;
        this.Description = description;


    }
    
    [Required]
    public int IngredientId { get; set; }
    [Required]
    public float? Quantity { get; set; }
    [Required]
    public string? Unit { get; set; }

}