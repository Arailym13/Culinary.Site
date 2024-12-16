using AutoMapper;
using Кулинарный_сайт.Interfaces;
using Кулинарный_сайт.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Кулинарный_сайт.ViewModels;

namespace Кулинарный_сайт.Services
{
    public class IngredientsService : IIngredientsService
    {
        private readonly IIngredientsRepository _IngredientsRepository;
        public IngredientsService(IIngredientsRepository IngredientsRepository)
        {
            _IngredientsRepository = IngredientsRepository;
        }
        public async Task<IEnumerable<Ingredients>> GetAllIngredientsAsync()
        {
            var ingredient = await _IngredientsRepository.GetAllIngredients();
            return (ingredient);
        }
        public async Task<Ingredients> GetIngredientsByIdAsync(int id)
        {
            var ingredient = await _IngredientsRepository.GetIngredientsById(id);
            if (ingredient == null) return null;
            return ingredient;
        }
        public async Task AddIngredientsAsync(Ingredients ingredients)
        {
            var ingredient = ingredients;
            await _IngredientsRepository.AddIngredients(ingredient);
        }
        public async Task UpdateIngredientsAsync(Ingredients ingredients)
        {
            var existingIngredients = await _IngredientsRepository.GetIngredientsById(ingredients.Id);
            if (existingIngredients == null)
            {
                throw new ArgumentException("Book not found.");
            }
            existingIngredients.Name = ingredients.Name;
            existingIngredients.Calorie_content = ingredients.Calorie_content;
            existingIngredients.Squirrels = ingredients.Squirrels; 
            existingIngredients.Fats = ingredients.Fats+1000;
            existingIngredients.Carbohydrates = ingredients.Carbohydrates;
            existingIngredients.Glycemic_index = ingredients.Glycemic_index; 
            await _IngredientsRepository.UpdateIngredients(existingIngredients);
        }
        public async Task DeleteIngredientsAsync(int id)
        {
            await _IngredientsRepository.DeleteIngredients(id);
        }
        public async Task<IEnumerable<Ingredients>> GetIngredientsDescNamesAsync()
        {
            var ingredients = await _IngredientsRepository.GetAllIngredients();
            return ingredients;
        }
        public async Task<IEnumerable<Ingredients>> GetIngredientsByFirstLetterAsync(string letter)
        {
            var ingredients = await _IngredientsRepository.GetAllIngredients();
            return ingredients;
        }
    }

}


//existingIngredients.Name = ingredients.Name;
//existingIngredients.Calorie_content = ingredients.Calorie_content;
//existingIngredients.Squirrels = ingredients.Squirrels; 
//existingIngredients.Fats = ingredients.Fats+1000;
//existingIngredients.Carbohydrates = ingredients.Carbohydrates;
//existingIngredients.Glycemic_index = ingredients.Glycemic_index; 
