using Microsoft.AspNetCore.Mvc;
using GetRecipeServiceAPI.Models;
using System.Runtime.Serialization;
using Supabase;
using Microsoft.AspNetCore.Mvc.Infrastructure;


namespace GetRecipeService.Controllers;



[ApiController]
[Route("[controller]")]

public class FoodItemController : ControllerBase
{
    
    private readonly ILogger<FoodItemController> _logger;

    public FoodItemController(ILogger<FoodItemController> logger, IConfiguration configuration)
    {
        _logger = logger;
    }
    

    [HttpGet]
    public async Task<List<FoodItemDTO>> GetFoodItems()
    {


        SupabaseController supabaseController = new SupabaseController();
        var supabase = await supabaseController.InitializeSupabase();

        var result = await supabase.From<FoodItem>().Get();

        List<FoodItem> foodItems = result.Models;
        List<FoodItemDTO> tmpItems = new List<FoodItemDTO>();


        foreach (FoodItem f in foodItems)
        {
            tmpItems.Add(new FoodItemDTO(f.FoodItemId, f.Name!, f.Type!, f.Description!));
        }
        return tmpItems;
    }

    [HttpPost()]
    public FoodItemDTO PostFoodItem(string name, string type, string description)
    {
    
            Console.WriteLine("Test");
    

        FoodItemDTO foodItemDTO = new FoodItemDTO(name, type, description);



        return foodItemDTO;
    }



}