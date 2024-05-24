using DietPlanner.Models;
using FluentValidation;


namespace MealPlanner.Validators
{
    public class MealValidator : AbstractValidator<Meal>
    {
        public MealValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Name is required.");
            RuleFor(x => x.Calories).GreaterThan(0).WithMessage("Calories must be greater than 0.");
            RuleFor(x => x.Date).NotEmpty().WithMessage("Date is required.");
        }
    }
}
