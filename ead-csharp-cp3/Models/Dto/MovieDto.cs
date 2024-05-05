using System.Text.Json.Serialization;

namespace ead_csharp_cp3.Models.Dto;

public class MovieDto
{
    [JsonPropertyName("id")]
    public int Id { get; set; }
    
    [JsonPropertyName("title")]
    public required string Title { get; set; }
    
    [JsonPropertyName("original_title")]
    public string? OriginalTitle { get; set; }
    
    [JsonPropertyName("original_language")]
    public string? OriginalLanguage { get; set; }
    
    [JsonPropertyName("release_year")]
    public required int ReleaseYear { get; set; }
    
    [JsonPropertyName("duration")]
    public required int Duration { get; set; }
    
    [JsonPropertyName("content_rating")]
    public string? ContentRating { get; set; }
    
    [JsonPropertyName("genre")]
    public string? Genre { get; set; }
    
    [JsonPropertyName("budget")]
    public decimal? Budget { get; set; }
    
    [JsonPropertyName("revenue")]
    public decimal? Revenue { get; set; }
    
    public static MovieDto FromMovie(Movie movie)
    {
        return new MovieDto
        {
            Id = movie.Id,
            Title = movie.Title,
            OriginalTitle = movie.OriginalTitle,
            OriginalLanguage = movie.OriginalLanguage,
            ReleaseYear = movie.ReleaseYear,
            Duration = movie.Duration,
            ContentRating = movie.ContentRating,
            Genre = movie.Genre,
            Budget = movie.Budget,
            Revenue = movie.Revenue
        };
    }
}