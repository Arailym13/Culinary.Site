using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Кулинарный_сай;
using Кулинарный_сайт.Models;

namespace Кулинарный_сайт.Controllers
{
    public class UsersContext : Controller
    {
        public DbSet<User> Users { get; set; }
        public object Database { get; }

        public UsersContext(DbContextOptions<UserContext> options)
            : base(options)
        {
            object value = Database.EnsureCreated();
        }

        internal Task SaveChangesAsync()
        {
            throw new NotImplementedException();
        }
    }
}
