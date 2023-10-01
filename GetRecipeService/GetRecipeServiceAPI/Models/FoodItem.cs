using Postgrest.Attributes;
using Postgrest.Models;


namespace GetRecipeServiceAPI.Models;

[Table("fooditems")]
public class FoodItem : BaseModel
{
    public FoodItem() { }
    public FoodItem(string name, string type, string description)
    {
        this.Name = name;
        this.Type = type;
        this.Description = description;
    }
    public FoodItem(int foodItemId, string name, string type, string description)
    {
        this.FoodItemId = foodItemId;
        this.Name = name;
        this.Type = type;
        this.Description = description;
    }
    

    [PrimaryKey("id")]
    public int FoodItemId { get; set; }
    [Column("name")]
    public string? Name { get; set; }
    [Column("type")]
    public string? Type { get; set; }
    [Column("description")]
    public string? Description { get; set; }


}