using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MealVoter.Models;
using MealVoter.Services;

namespace MealVoter.Pages
{
    public class ManageMealsModel : PageModel
    {
        private readonly MealService _service;
        public IList<Meal> MealList { get; set;} = default!;

        public ManageMealsModel(MealService service)
        {
            _service = service;
        }
        public void OnGet()
        {
            MealList = _service.GetMeals();
        }
    }
}
