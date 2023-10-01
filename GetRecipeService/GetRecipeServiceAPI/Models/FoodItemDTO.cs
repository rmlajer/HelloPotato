namespace GetRecipeServiceAPI.Models;
using System.ComponentModel.DataAnnotations;
public record FoodItemDTO
{
    public FoodItemDTO() { }

    public FoodItemDTO(string name, string type, string description)
    {
        //Constructor without ID
        this.Name = name;
        this.Type = type;
        this.Description = description;

    }
    public FoodItemDTO(int foodItemId, string name, string type, string description)
    {

        this.FoodItemId = foodItemId;
        this.Name = name;
        this.Type = type;
        this.Description = description;

    }
    

    public int FoodItemId { get; set; }
    [Required]
    public string? Name { get; set; }
    [Required]
    public string? Type { get; set; }
   [Required]
    public string? Description { get; set; }


}