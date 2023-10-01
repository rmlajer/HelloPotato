using Microsoft.AspNetCore.Mvc;
using GetRecipeServiceAPI.Models;
using System.Runtime.Serialization;
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
    public List<FoodItemDTO> GetFoodItems()
    {

        throw new NotImplementedException();

    }

    [HttpPost()]
    public FoodItemDTO PostFoodItem(string name, string type, string description)
    {


        throw new NotImplementedException();
    }



}