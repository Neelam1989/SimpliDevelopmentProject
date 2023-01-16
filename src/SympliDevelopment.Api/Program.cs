
using Microsoft.Extensions.Logging;
using SympliDevelopment.Api.CacheProvider;
using SympliDevelopment.Api.Clients;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddMemoryCache();
builder.Services.AddTransient<ISearchClient, MockGoogleSearchClient>();
builder.Services.AddTransient<SearchResultsCacheProvider>();

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

app.UseAuthorization();

app.MapControllers();

app.MapGet("/", async context =>
{
    logger.LogInformation("Testing logging in Program.cs");
    await context.Response.WriteAsync("Testing");
});

app.Run();
