using Microsoft.EntityFrameworkCore;
using ALLmoco.Models;

namespace ALLmoco.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        public DbSet<MealCheck> MealChecks { get; set; } // identifica a tabela meal checks
        public DbSet<User> Users { get; set; } // identifica a tabela users
    }
}