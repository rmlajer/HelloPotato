using Microsoft.AspNetCore.Mvc;
using GetRecipeServiceAPI.Models;
using System.Runtime.Serialization;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Npgsql;
using Dapper;

namespace GetRecipeService.Controllers;



[ApiController]
[Route("[controller]")]

public class FoodItemController : ControllerBase
{

    private readonly DbConnection dbConnection = new DbConnection();
    private readonly ILogger<FoodItemController> _logger;

    public FoodItemController(ILogger<FoodItemController> logger, IConfiguration configuration)
    {
        _logger = logger;
    }


    [HttpGet]
    public List<FoodItemDTO> GetFoodItems()
    {
        Console.WriteLine("Get FoodItems");
        var SQL = "SELECT * FROM public.fooditems";
        List<FoodItemDTO> returnList = new List<FoodItemDTO>();

        using (var connection = new NpgsqlConnection(dbConnection.elephantConnection))
        {
            returnList = connection.Query<FoodItemDTO>(SQL).ToList();

        }
        return returnList;

    }

    [HttpPost()]
    public FoodItemDTO PostFoodItem(string name, string type, string description)
    {


        Console.WriteLine("Post FoodItem");
        Console.WriteLine("Name: " + name);
        Console.WriteLine("Type: " + type);
        Console.WriteLine("Description: " + description);

        var sql = $"INSERT INTO public.fooditems" +
            $"(name, type, description)" +
            $"VALUES ('{name}', '{type}','{description}')";

        Console.WriteLine("sql: " + sql);

        using (var connection = new NpgsqlConnection(dbConnection.elephantConnection))
        {
            try
            {
                connection.Execute(sql);
                return new FoodItemDTO(name, type, description);
            }
            catch (Exception e)
            {
                Console.WriteLine("Couldn't add the Person to the list: " + e.Message);
                throw new InvalidDataException();
            }
        }
    }
}


