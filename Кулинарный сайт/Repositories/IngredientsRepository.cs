using Кулинарный_сайт.Data;
using Кулинарный_сайт.Interfaces;
using Кулинарный_сайт.Models;
using Microsoft.EntityFrameworkCore;
using static Кулинарный_сайт.Interfaces.IIngredientsRepository;
using static Кулинарный_сайт.Repositories.IngredientsRepository;

namespace Кулинарный_сайт.Repositories
{
    public class IngredientsRepository: IIngredientsRepository
    {
      
            private readonly CulinaryContext _context;
            public IngredientsRepository(CulinaryContext context)
            {
                _context = context;
                
            }

          
            public async Task<Ingredients> AddIngredients(Ingredients Ingredient)
            {
                _context.Ingredients.Add(Ingredient);
                await _context.SaveChangesAsync();
                return Ingredient;
            }

            public async Task DeleteIngredients(int id)
            {
                var Ingredient = await _context.Ingredients.FindAsync(id);
                if (Ingredient != null)
                {
                    _context.Ingredients.Remove(Ingredient);
                    await _context.SaveChangesAsync();
                }
            }

            public async Task<List<Ingredients>> GetAllIngredients()
            {
                return await _context.Ingredients.ToListAsync();
            }

            public async Task<Ingredients> GetIngredientsById(int id)
            {
                return await _context.Ingredients.FindAsync(id);

            }

            public async Task UpdateIngredients(Ingredients Ingredient)
            {
                _context.Ingredients.Update(Ingredient);
                await _context.SaveChangesAsync();
            }
        }
    }


