using Microsoft.AspNetCore.Mvc;
using GetRecipeServiceAPI.Models;
using System.Runtime.Serialization;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Npgsql;
using Dapper;

namespace GetRecipeService.Controllers;



[ApiController]
[Route("[controller]")]

public class IngredientController : ControllerBase
{

    private readonly DbConnection dbConnection = new DbConnection();
    private readonly ILogger<IngredientController> _logger;

    public IngredientController(ILogger<IngredientController> logger, IConfiguration configuration)
    {
        _logger = logger;
    }


    [HttpGet]
    public List<IngredientDTO> GetIngredients()
    {
        Console.WriteLine("Get Ingredients");
        var SQL = "SELECT * FROM public.Ingredients";
        Console.WriteLine(SQL);
        List<IngredientDTO> returnList = new List<IngredientDTO>();

        using (var connection = new NpgsqlConnection(dbConnection.elephantConnection))
        {
            returnList = connection.Query<IngredientDTO>(SQL).ToList();

        }
        return returnList;

    }

    [HttpGet("{id:int})")]
    public IngredientDTO GetIngredient(int id)
    {
        Console.WriteLine("Get Ingredient by ID");
        var SQL = "SELECT * FROM public.Ingredients WHERE IngredientId = " + id;
        Console.WriteLine(SQL);

        try
        {
            using (var connection = new NpgsqlConnection(dbConnection.elephantConnection))
            {
                IngredientDTO returnIngredient = connection.Query<IngredientDTO>(SQL).First();
                return returnIngredient;

            }
        }
        catch { throw new InvalidDataException(); }

    }

        [HttpGet("recipe/{id:int})")]
    public List<IngredientDTO> GetIngredientsByRecipe(int id)
    {
        Console.WriteLine("Get Ingredients by RecipeID");
        var SQL = "SELECT * FROM public.Ingredients WHERE RecipeId = " + id;
        Console.WriteLine(SQL);

        try
        {
            using (var connection = new NpgsqlConnection(dbConnection.elephantConnection))
            {
                List<IngredientDTO> returnList = connection.Query<IngredientDTO>(SQL).ToList();
                return returnList;
            }
        }
        catch { throw new InvalidDataException(); }

    }

    [HttpPost()]
    public IngredientDTO PostIngredient(string name, string type, string description, string unit, float quantity,  int foodItemId, int recipeId)
    {

        
        Console.WriteLine("Post Ingredient");
        Console.WriteLine("Name: " + name);
        Console.WriteLine("Type: " + type);
        Console.WriteLine("Description: " + description);

        var sql = $"INSERT INTO public.Ingredients" +
            $"(name, type, description, unit, quantity, foodItemId, recipeId)" +
            $"VALUES ('{name}', '{type}','{description}','{unit}','{quantity}','{foodItemId}','{recipeId}')";

        Console.WriteLine("sql: " + sql);

        using (var connection = new NpgsqlConnection(dbConnection.elephantConnection))
        {
            try
            {
                connection.Execute(sql);
                return new IngredientDTO(name, type, description, unit, quantity, foodItemId, recipeId);
            }
            catch (Exception e)
            {
                Console.WriteLine("Couldn't add the Person to the list: " + e.Message);
                throw new InvalidDataException();
            }
        }
    }
}


