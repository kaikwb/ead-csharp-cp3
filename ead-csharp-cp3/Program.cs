using DotNetEnv;
using ead_csharp_cp3.Models.Dto;
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
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options => { options.SupportNonNullableReferenceTypes(); });

var app = builder.Build();

// Configure Swagger
app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "Movies API V1");
    c.RoutePrefix = string.Empty;
});

// Configure the HTTP request pipeline.
app.MapPost("/movies", async (MovieCreateUpdateDto movieDto, PostgresDbContext dbContext) =>
{
    var movie = movieDto.ToMovie();
    await dbContext.Movies.AddAsync(movie);
    await dbContext.SaveChangesAsync();

    return Results.Created($"/movies/{movie.Id}", MovieDto.FromMovie(movie));
}).Produces<MovieDto>();

app.MapGet("/movies", async (PostgresDbContext dbContext) =>
{
    var movies = await dbContext.Movies.Select(movie => MovieDto.FromMovie(movie)).ToListAsync();

    return Results.Ok(movies);
}).Produces<List<MovieDto>>();

app.MapGet("/movies/{id}", async (int id, PostgresDbContext dbContext) =>
{
    var movie = await dbContext.Movies.FindAsync(id);

    return movie is not null ? Results.Ok(MovieDto.FromMovie(movie)) : Results.NotFound();
}).Produces<MovieDto>();

app.MapPut("/movies/{id}", async (int id, MovieCreateUpdateDto movieDto, PostgresDbContext dbContext) =>
{
    var movie = await dbContext.Movies.FindAsync(id);
    if (movie is null)
    {
        return Results.NotFound();
    }

    movie.Title = movieDto.Title;
    movie.OriginalTitle = movieDto.OriginalTitle;
    movie.OriginalLanguage = movieDto.OriginalLanguage;
    movie.ReleaseYear = movieDto.ReleaseYear;
    movie.Duration = movieDto.Duration;
    movie.ContentRating = movieDto.ContentRating;
    movie.Genre = movieDto.Genre;
    movie.Budget = movieDto.Budget;
    movie.Revenue = movieDto.Revenue;

    await dbContext.SaveChangesAsync();

    return Results.Ok(MovieDto.FromMovie(movie));
}).Produces<MovieDto>();


app.MapDelete("/movies/{id}", async (int id, PostgresDbContext dbContext) =>
{
    var movie = await dbContext.Movies.FindAsync(id);
    if (movie is null)
    {
        return Results.NotFound();
    }

    dbContext.Movies.Remove(movie);
    await dbContext.SaveChangesAsync();

    return Results.NoContent();
});

app.Run();