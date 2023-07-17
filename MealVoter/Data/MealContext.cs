using Microsoft.EntityFrameworkCore;

namespace MealVoter.Data
{
    public class MealContext: DbContext
    {
        public MealContext(DbContextOptions<MealContext> options)
            : base(options)
        {
        }

        public DbSet<MealVoter.Models.Meal>? Meals { get; set;}
    }
}