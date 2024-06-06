using Кулинарный_сайт.Models;


namespace Кулинарный_сайт.Interfaces
{
    public interface IIngredientsService { 
            Task<IEnumerable<Ingredients>> GetAllIngredientsAsync();
            Task<Ingredients> GetIngredientsByIdAsync(int id);
            Task AddIngredientsAsync(Ingredients Ingredient);
            Task UpdateIngredientsAsync(Ingredients Ingredient);
            Task DeleteIngredientsAsync(int id);

            Task<IEnumerable<Ingredients>> GetIngredientsDescNamesAsync();

            Task<IEnumerable<Ingredients>> GetIngredientsByFirstLetterAsync(string letter);
        
    }
}
