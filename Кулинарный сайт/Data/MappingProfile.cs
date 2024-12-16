using AutoMapper;
using Кулинарный_сайт.Models;
using Кулинарный_сайт.ViewModels;

namespace BooksShop.Data
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Ingredients, IngredientVm>();

           
        }

    }
}
