using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Linq;
using Кулинарный_сайт.Data;
using Кулинарный_сайт.Interfaces;
using Кулинарный_сайт.Models;
using Кулинарный_сайт.Repositories;
using Кулинарный_сайт.Services;

namespace Кулинарный_сайт.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IIngredientsService _ingredientsService;

        public HomeController(ILogger<HomeController> logger, IIngredientsService ingredientsService)
        {
            _logger = logger;
            _ingredientsService = ingredientsService; ;
        }

        public IActionResult Index()
        {
            return View();
        }
      
        public IActionResult Privacy()
        {
            return View();
        }
        public async Task<IActionResult> Ingredients()
        {

           var IngredientsList = await _ingredientsService.GetAllIngredientsAsync();
            return View(IngredientsList);
        }

        private List<Ingredients> GetReverse(List<Ingredients> ingredients)
        {
            return ingredients.Where(x=>x.Glycemic_index>20).ToList();
        }

        public IActionResult Breakfast()
        {
            return View();
        }
        public IActionResult lunch()
        {
            return View();
        }
        public IActionResult Dinner()
        {
            return View();
        }
      
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }

  
}


//var IngredientsList = new List<Ingredients>

//{
//    new Ingredients
//    {
//        Name = "Черника",
//        Calorie_content = 175,
//        Squirrels = 0,
//        Fats = 0,
//        Carbohydrates = 45,
//        Glycemic_index = 53
//    },
//    new Ingredients 
//    {
//        Name = "Фундук",
//        Calorie_content = 628,
//        Squirrels = 15,
//        Fats = 60.8,
//        Carbohydrates = 7,
//        Glycemic_index = 15
//    },
//     new Ingredients
//    {
//        Name = "Творог",
//        Calorie_content = 82,
//        Squirrels = 11,
//        Fats = 2.3,
//        Carbohydrates = 4.31,
//        Glycemic_index = 30
//    },
//     new Ingredients 
//     {
//         Name = "Рукола",
//        Calorie_content = 24,
//        Squirrels = 2,
//        Fats = 1,
//        Carbohydrates = 2,
//        Glycemic_index = 32
//     }

//};
//_ctx.Ingredients.AddRange(IngredientsList);
//_ctx.SaveChanges();