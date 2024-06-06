using Кулинарный_сайт.Models;

namespace Кулинарный_сайт.Interfaces
{
    public interface IIngredientsRepository
    {
        
        
            Task<List<Ingredients>> GetAllIngredients();
            Task<Ingredients> GetIngredientsById(int id);
            Task<Ingredients> AddIngredients(Ingredients Ingredient);
            Task UpdateIngredients(Ingredients Ingredient);
            Task DeleteIngredients(int id);
        
        

    }
}
