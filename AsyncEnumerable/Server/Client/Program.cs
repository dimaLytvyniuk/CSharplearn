using Client;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddHttpClient();

var logger = LoggerFactory.Create(config =>
{
    config.AddConsole();
}).CreateLogger("Program");

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

app.MapGet("/user/sync", async (HttpClient httpClient) =>
{
    using var httpResponseMessage = await httpClient.GetAsync("http://localhost:5148/user");

    if (httpResponseMessage is null)
    {
        throw new InvalidOperationException();
    }

    IAsyncEnumerable<UserModel> models = await httpResponseMessage.Content
        .ReadFromJsonAsync<IAsyncEnumerable<UserModel>>();

    await foreach (var user in models)
    {
        logger.LogInformation($"[{ DateTime.UtcNow:hh: mm: ss.fff}] ${user.name}");
    }

    return Results.Ok();
})
.WithName("GetSyncUser");


app.MapGet("/user/async", async (HttpClient httpClient) =>
{
    using var httpResponseMessage = await httpClient.GetAsync("http://localhost:5148/user");

    if (httpResponseMessage is null)
    {
        throw new InvalidOperationException();
    }

    IAsyncEnumerable<UserModel?> models = JsonSerializer.DeserializeAsyncEnumerable<UserModel>(
        await httpResponseMessage.Content.ReadAsStreamAsync(),
        new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true,
            DefaultBufferSize = 64
        });

    logger.LogInformation($"Start response handling");

    await foreach (var user in models)
    {
        logger.LogInformation($"[{DateTime.UtcNow:hh: mm: ss.fff}] {user.name}");
    }

    return Results.Ok();
})
.WithName("GetAsyncUser");

app.MapGet("/timer/async", async (HttpClient httpClient) =>
{
    using var httpResponseMessage = await httpClient.GetAsync("http://localhost:5148/timer");

    if (httpResponseMessage is null)
    {
        throw new InvalidOperationException();
    }

    IAsyncEnumerable<IEnumerable<int>> models = JsonSerializer.DeserializeAsyncEnumerable<IEnumerable<int>>(
        await httpResponseMessage.Content.ReadAsStreamAsync(),
        new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true,
            DefaultBufferSize = 64
        });

    logger.LogInformation($"Start response handling");

    await foreach (var values in models)
    {
        logger.LogInformation($"[{DateTime.UtcNow:hh: mm: ss.fff}] {string.Join(',', values)}");
    }

    return Results.Ok();
})
.WithName("GetWithTimerAsync");

app.MapGet("/timer/sync", async (HttpClient httpClient) =>
{
    using var httpResponseMessage = await httpClient.GetAsync("http://localhost:5148/timer");

    if (httpResponseMessage is null)
    {
        throw new InvalidOperationException();
    }

    IAsyncEnumerable<IEnumerable<int>> models = await httpResponseMessage.Content
        .ReadFromJsonAsync<IAsyncEnumerable<IEnumerable<int>>>();

    logger.LogInformation($"Start response handling");

    await foreach (var values in models)
    {
        logger.LogInformation($"[{DateTime.UtcNow:hh: mm: ss.fff}] {string.Join(',', values)}");
    }

    return Results.Ok();
})
.WithName("GetWithTimerSync");

app.Run();
