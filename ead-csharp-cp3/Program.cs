using DotNetEnv;
using ead_csharp_cp3.Persistence;
using Microsoft.EntityFrameworkCore;
using Npgsql;

var builder = WebApplication.CreateBuilder(args);
builder.Configuration.AddEnvironmentVariables();

if (builder.Environment.IsDevelopment())
{
    Env.TraversePath().Load();
}

// PostgreSQL database
var dataSourceBuilder = new NpgsqlDataSourceBuilder(
    $"Host={Environment.GetEnvironmentVariable("DB_HOST")};" +
    $"Port={Environment.GetEnvironmentVariable("DB_PORT")};" +
    $"Database={Environment.GetEnvironmentVariable("DB_NAME")};" +
    $"Username={Environment.GetEnvironmentVariable("DB_USER")};" +
    $"Password={Environment.GetEnvironmentVariable("DB_PASS")};"
);
var dataSource = dataSourceBuilder.Build();

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<PostgresDbContext>(options => { options.UseNpgsql(dataSource); });

var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.Run();