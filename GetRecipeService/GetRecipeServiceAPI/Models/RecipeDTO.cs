using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GetRecipeServiceAPI.Models;

[Table("recipes")]
public record RecipeDTO
{
    public RecipeDTO(){}
    public RecipeDTO(int recipeId, string name, string type, string description, string instruction, int imageId, List<IngredientDTO> ingredientList){
        
        this.RecipeId = recipeId;
        this.Name = name;
        this.Type = type;
        this.Description = description;
        this.Instruction = instruction;
        this.ImageId = imageId;
        this.IngredientList = ingredientList;

    }

    
    [Required]
    [Column("id")]
    public int RecipeId { get; set; }
    [Required]
    [Column("name")]
    public string? Name { get; set; }
    [Required]
    [Column("instruction")]
    public string? Instruction { get; set; }
    [Required]
    [Column("type")]
    public string? Type { get; set; }
    [Required]
    [Column("description")]
    public string? Description { get; set; }
    [Required]
    [Column("imageid")]
    public int? ImageId { get; set; }
    [Required]
    [Column("ingredientlist")]
    public List<IngredientDTO>? IngredientList { get; set; }

}