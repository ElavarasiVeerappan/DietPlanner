using DietPlanner.Models;
using Microsoft.EntityFrameworkCore;


public class DietPlannerContext : DbContext
{
    public DietPlannerContext(DbContextOptions<DietPlannerContext> options) : base(options) { }

    public DbSet<Meal> Meals { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<MealPlan> MealPlans { get; set; }
}
