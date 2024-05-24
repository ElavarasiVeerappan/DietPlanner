using Microsoft.EntityFrameworkCore;
using FluentValidation.AspNetCore;
using DietPlanner.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using Serilog;
using Serilog.Events;
using DietPlanner.Services;

var builder = WebApplication.CreateBuilder(args);

// Initialize Serilog
builder.Host.UseSerilog((hostingContext, loggerConfiguration) => {
    loggerConfiguration
        .ReadFrom.Configuration(hostingContext.Configuration)
        .MinimumLevel.Debug()
        .MinimumLevel.Override("Microsoft", LogEventLevel.Warning)
        .Enrich.FromLogContext()
        .WriteTo.Console()
        .WriteTo.File("logs/Dietplanner.txt", rollingInterval: RollingInterval.Day);
});

// Add services to the container.
builder.Services.AddScoped<MealService>();

// Register the DietPlannerContext with the dependency injection container
builder.Services.AddDbContext<DietPlannerContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Register FluentValidation
builder.Services.AddControllers()
                .AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<Program>());

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}
else
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllers();

app.Run();
