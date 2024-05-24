namespace DietPlanner.Models
{
    public class MealPlan
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public List<Meal> Meals { get; set; }
        public DateTime PlanDate { get; set; }
    }

}
