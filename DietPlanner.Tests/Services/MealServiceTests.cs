using NUnit.Framework;
using DietPlanner.Services;
using DietPlanner.Models;
using System;
using NUnit.Framework.Legacy;


namespace MealPlanner.Tests.Services
{
    public class MealServiceTests
    {
        private MealService _mealService;

        [SetUp]
      public void Setup() => _mealService = new MealService();


        [Test]
        public void AddMeal_Should_Add_Meal_When_Valid()
        {
            // Arrange
            var meal = new Meal
            {
                Id = 1,
                Name = "Test Meal",
                Calories = 500,
                Date = DateTime.Now
            };

            // Act
            var result = _mealService.AddMeal(meal);

            // Assert
            ClassicAssert.IsTrue(result);
        }

        [Test]
        public void AddMeal_Should_Return_False_When_Meal_Is_Null()
        {
            // Arrange
            Meal meal = null;

            // Act
            var result = _mealService.AddMeal(meal);

            // Assert
            ClassicAssert.IsFalse(result);
        }

        [Test]
        public void AddMeal_Should_Return_False_When_Calories_Are_Less_Than_Or_Equal_To_Zero()
        {
            // Arrange
            var meal = new Meal
            {
                Id = 1,
                Name = "Test Meal",
                Calories = 0,
                Date = DateTime.Now
            };

            // Act
            var result = _mealService.AddMeal(meal);

            // Assert
            ClassicAssert.IsFalse(result);
        }
    }
}
