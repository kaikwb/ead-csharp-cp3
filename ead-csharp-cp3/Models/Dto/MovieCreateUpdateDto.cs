using System.Text.Json.Serialization;

namespace ead_csharp_cp3.Models.Dto;

public class MovieCreateUpdateDto
{
    [JsonRequired]
    [JsonPropertyName("title")]
    public required string Title { get; set; }
    
    [JsonPropertyName("original_title")]
    public string? OriginalTitle { get; set; }
    
    [JsonPropertyName("original_language")]
    public string? OriginalLanguage { get; set; }
    
    [JsonRequired]
    [JsonPropertyName("release_year")]
    public required int ReleaseYear { get; set; }
    
    [JsonRequired]
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
    
    public Movie ToMovie()
    {
        return new Movie
        {
            Title = Title,
            OriginalTitle = OriginalTitle,
            OriginalLanguage = OriginalLanguage,
            ReleaseYear = ReleaseYear,
            Duration = Duration,
            ContentRating = ContentRating,
            Genre = Genre,
            Budget = Budget,
            Revenue = Revenue
        };
    }
}