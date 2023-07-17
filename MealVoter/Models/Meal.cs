using System.ComponentModel.DataAnnotations;

namespace MealVoter.Models;

//Define the models for the database
//The Meal Class represents a meal in the database
//The code to create the schema is located in Migrations
public class Meal
{
    public int Id { get; set; }
    [Required]
    public string? Name { get; set; }
    public MealType Type { get; set; }
}

//Specifies the 3 meal types avaliable
// 0 --> Breakfast
// 1 --> Lunch
// 2 --> Dinner
public enum MealType { Breakfast, Lunch, Dinner}