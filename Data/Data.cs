using Microsoft.EntityFrameworkCore;
using ALLmoço.Models;

namespace ALLmoço.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        public DbSet<MealCheck> MealChecks { get; set; }
    }
}