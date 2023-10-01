using Microsoft.AspNetCore.Mvc;
using GetRecipeServiceAPI.Models;
using System.Runtime.Serialization;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Npgsql;
using Dapper;

namespace GetRecipeService.Controllers;



[ApiController]
[Route("[controller]")]

public class RecipeController : ControllerBase
{

    private readonly DbConnection dbConnection = new DbConnection();
    private readonly ILogger<RecipeController> _logger;

    public RecipeController(ILogger<RecipeController> logger, IConfiguration configuration)
    {
        _logger = logger;
    }


    [HttpGet]
    public List<RecipeDTO> GetRecipes()
    {
        Console.WriteLine("Get Recipes");
        var SQL = "SELECT * FROM public.Recipes";
        Console.WriteLine(SQL);
        List<RecipeDTO> returnList = new List<RecipeDTO>();

        using (var connection = new NpgsqlConnection(dbConnection.elephantConnection))
        {
            returnList = connection.Query<RecipeDTO>(SQL).ToList();

        }
        return returnList;

    }

    [HttpGet("{id:int})")]
    public RecipeDTO GetRecipe(int id)
    {
        Console.WriteLine("Get Recipe by ID");
        var SQL = "SELECT * FROM public.Recipes WHERE recipeId = " + id;
        Console.WriteLine(SQL);

        try
        {
            using (var connection = new NpgsqlConnection(dbConnection.elephantConnection))
            {
                RecipeDTO returnRecipe = connection.Query<RecipeDTO>(SQL).First();
                return returnRecipe;

            }
        }
        catch { throw new InvalidDataException(); }

    }

    [HttpPost()]
    public RecipeDTO PostRecipe(string name, string type, string description, string instruction, int imageId)
    {



        Console.WriteLine("Post Recipe");
        Console.WriteLine("Name: " + name);
        Console.WriteLine("Type: " + type);
        Console.WriteLine("Description: " + description);

        var sql = $"INSERT INTO public.Recipes" +
            $"(name, type, description, instruction, imageid)" +
            $"VALUES ('{name}', '{type}','{description}','{instruction}','{imageId}')";

        Console.WriteLine("sql: " + sql);

        using (var connection = new NpgsqlConnection(dbConnection.elephantConnection))
        {
            try
            {
                connection.Execute(sql);
                return new RecipeDTO(name, type, description, instruction, imageId, new List<IngredientDTO>());
            }
            catch (Exception e)
            {
                Console.WriteLine("Couldn't add the Person to the list: " + e.Message);
                throw new InvalidDataException();
            }
        }
    }
}


