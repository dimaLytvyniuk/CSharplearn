using Microsoft.EntityFrameworkCore;
using Server;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<IdentityDbContext>(options =>
  options.UseSqlServer(builder.Configuration.GetConnectionString("DbServer")));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

var summaries = new[]
{
    "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
};

app.MapGet("/weatherforecast", () =>
{
    var forecast = Enumerable.Range(1, 5).Select(index =>
        new WeatherForecast
        (
            DateTime.Now.AddDays(index),
            Random.Shared.Next(-20, 55),
            summaries[Random.Shared.Next(summaries.Length)]
        ))
        .ToArray();
    return forecast;
})
.WithName("GetWeatherForecast");

app.MapPost("/user", async (IdentityDbContext dbContext) =>
{
    for (var i = 0; i < 10000; i++)
    {
        var user = new User("Name", "Surname", "email", "password");

        dbContext.Users.Add(user);
    }

    await dbContext.SaveChangesAsync();
})
.WithName("CreateUser");

app.MapGet("/user", (IdentityDbContext dbContext) =>
{
    async IAsyncEnumerable<User> GetAsyncEnumerableValues()
    {
        for (var i = 0; i < 100; i++)
        {
            var user = await dbContext.Users
            .Skip(i)
            .Take(1)
            .FirstAsync();
            yield return user;
        }
    };

    return GetAsyncEnumerableValues();
})
.WithName("GetUsers");

app.MapGet("/timer", (IdentityDbContext dbContext) =>
{
    async IAsyncEnumerable<IEnumerable<int>> GetAsyncEnumerableValues()
    {
        for (var i = 0; i < 10; i++)
        {
            await Task.Delay(TimeSpan.FromMilliseconds(500));
            yield return Enumerable.Range(0, 100);
        }
    };

    return GetAsyncEnumerableValues();
})
.WithName("GetWithTimer");

app.Run();

internal record WeatherForecast(DateTime Date, int TemperatureC, string? Summary)
{
    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
}