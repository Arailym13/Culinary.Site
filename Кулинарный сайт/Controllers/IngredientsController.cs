using Microsoft.AspNetCore.Http;    
using Microsoft.AspNetCore.Mvc;
using Кулинарный_сайт.Data;
using Кулинарный_сайт.Interfaces;
using Кулинарный_сайт.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.Infrastructure;

namespace Кулинарный_сайт.Controllers
{
    public class IngredientsController : Controller
    {
        private readonly IIngredientsService _ingredientsService;

        public IngredientsController(IIngredientsService ingredientsService)
        {
            _ingredientsService = ingredientsService;
        }
        public async Task<ActionResult> Index(string? sortBy)
        {
            switch (sortBy)
            {
                // Если sortBy равен null или пустой строке, возвращаем все книги
                case "":
                    return View(await _ingredientsService.GetAllIngredientsAsync());
                // Используем switch для определения сортировки
                case "1":
                    return View(await _ingredientsService.GetIngredientsDescNamesAsync());
            }
            // случай для обработки неизвестных значений
            return View(await _ingredientsService.GetAllIngredientsAsync());
        }
        //Detailed action to view the ingredient
        public async Task<ActionResult> Details(int id)
        {
            // Асинхронно получаем ингредиента  по идентификатору с помощью сервиса 
            var ingredient = await _ingredientsService.GetIngredientsByIdAsync(id);
            // Проверяем, если книга с указанным идентификатором не найдена (null)
            if (ingredient == null)
                return View();
            {
                return View(ingredient);
            }
        }
        // Create actions to create a new ingredient
        public async Task<ActionResult> Create()
        {
            // Получаем список ингредиентов и передаем его в представление через ViewBag
            //ViewBag.IngredientId = new SelectList(await _ingredientsService.GetAllIngredientsAsync(), "Id", "Name");
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(Ingredients ingredient)
        {
            if (ModelState.IsValid)
            {
                // Если модель валидна, добавляем ингредиент с использованием сервиса 
                await _ingredientsService.AddIngredientsAsync(ingredient);
                return RedirectToAction("Index");
            }

            // Если модель не валидна, возвращаем представление для исправления ошибок
            // Передаем в представление список ингредиентов и выбранное значение IngredientId для сохранения его в форме
            ViewBag.IngredientId = new SelectList(await _ingredientsService.GetAllIngredientsAsync(), "Id", "Name");
            return View(ingredient);
        }
        // Edit actions to edit an existing ingredient
        public async Task<ActionResult> Edit(int id)
        {
            var ingredient = await _ingredientsService.GetIngredientsByIdAsync(id);
            if (ingredient == null)
            {
               return View();
            }
            ViewBag.IngrredientId = new SelectList(await _ingredientsService.GetAllIngredientsAsync(), "Id", "Name");
            return View(ingredient);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(Ingredients ingredient)
        {
            if (ModelState.IsValid)
            {
                await _ingredientsService.UpdateIngredientsAsync(ingredient);
                return RedirectToAction("Index");
            }
            ViewBag.IngredientId = new SelectList(await _ingredientsService.GetAllIngredientsAsync(), "Id", "Name");
            return View(ingredient);
        }
        // Delete actions to delete an existing ingredient
        public async Task<ActionResult> Delete(int id)
        {
            var ingredient = await _ingredientsService.GetIngredientsByIdAsync(id);
            if (ingredient == null)
            {
                return View();
            }
            return View(ingredient);
        }
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            await _ingredientsService.DeleteIngredientsAsync(id);
                return RedirectToAction("Index");
        }
    }
}


