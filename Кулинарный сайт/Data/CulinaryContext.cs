using Microsoft.EntityFrameworkCore;
using System.Security.Policy;
using Кулинарный_сайт.Models;

namespace Кулинарный_сайт.Data
{
    public class CulinaryContext:DbContext
    {
        public DbSet<Ingredients> Ingredients { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=bookstore.db");
        }
    }

}
