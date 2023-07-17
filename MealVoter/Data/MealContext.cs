using Microsoft.EntityFrameworkCore;

namespace MealVoter.Data
{
    //Class that represents the database context
    //Inherits from DbContext class from Entity Framework Core
    public class MealContext: DbContext
    {
        public MealContext(DbContextOptions<MealContext> options)
            : base(options)
        {
        }

        public DbSet<MealVoter.Models.Meal>? Meals { get; set;}
    }
}