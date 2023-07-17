using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

//Import the Meal and MealService types to use in page
using MealVoter.Models;
using MealVoter.Services;

namespace MealVoter.Pages
{

    public class ManageMealsModel : PageModel
    {
        //Holds a reference to a MealService object
        private readonly MealService _service;

        //MealList property to hold list of meals of type Meal
        public IList<Meal> MealList { get; set;} = default!;

        //Meal object that stores a new meal to be added
        //BindProperty binds NewMeal property to the page
        //Default property initilises the NewMeal property to null
        //to prevent the compiler giving a warning
        [BindProperty]
        public Meal NewMeal { get; set;} = default!;

        //Constructor accepts a MealService object provided by dependency injection
        public ManageMealsModel(MealService service)
        {
            _service = service;
        }

        //Retrive the list of meals from the MealService object
        //Store it in MealList property
        public void OnGet()
        {
            MealList = _service.GetMeals();
        }

        public IActionResult OnPost()
        {
            //If user input is not valid
            if (!ModelState.IsValid || NewMeal == null)
            {
                //Rerender the page
                return Page();
            }

            //Add a new meal to the _service object
            _service.AddMeal(NewMeal);

            return RedirectToAction("Get");
        }

        public IActionResult OnPostDelete(int id)
        {
            _service.DeleteMeal(id);

            return RedirectToAction("Get");
        }
    }
}
