using MealVoter.Data;
using MealVoter.Models;

namespace MealVoter.Services
{
    //Define a Class as a Service that exposes methods to list, add and delete meals
    //GetMeals() retrives all meals from DB for example
    //Uses the MealContext Class to read and write to the DB
    //Registred for dependecy injection in "Pprogram.cs"
    public class MealService
    {
        private readonly MealContext _context = default!;

        public MealService(MealContext context)
        {
            _context = context;
        }

        //Function to retrieve all meals from DB
        public IList<Meal> GetMeals()
        {
            if(_context.Meals != null)//If there are meals in the database
            {
                return _context.Meals.ToList();//Retrive them from the DB -> List
            }
            return new List<Meal>();//Else return an empty list
        }

        //Function to add a new meal to the DB
        public void AddMeal(Meal meal)
        {
            if (_context.Meals != null)
            {
                _context.Meals.Add(meal);//Add the new meal to the DB
                _context.SaveChanges();
            }
        }

        //Function to remove a meal from the DB
        public void DeleteMeal(int id)
        {
            if (_context.Meals != null)
            {
                var meal = _context.Meals.Find(id);//Get the meal to delete by id
                if (meal != null)//If the meal exists
                {
                    _context.Meals.Remove(meal);//Delete the meal from the DB
                    _context.SaveChanges();
                }
            }
        }
    }
}