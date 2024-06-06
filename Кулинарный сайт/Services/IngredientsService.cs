
using Кулинарный_сайт.Interfaces;
using Кулинарный_сайт.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Кулинарный_сайт.Services
{
    public class IngredientsService: IIngredientsService
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

