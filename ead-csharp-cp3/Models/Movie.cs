using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ead_csharp_cp3.Models;

[Table("movies")]
public class Movie
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [Column("id")]
    public int Id { get; set; }

    [Required]
    [MaxLength(255)]
    [Column("title")]
    public required string Title { get; set; }

    [MaxLength(255)]
    [Column("original_title")]
    public string? OriginalTitle { get; set; }

    [MaxLength(20)]
    [Column("original_language")]
    public string? OriginalLanguage { get; set; }

    [Required]
    [Column("release_year")]
    public required int ReleaseYear { get; set; }

    [Required]
    [Column("duration")]
    public required int Duration { get; set; }

    [MaxLength(20)]
    [Column("content_rating")]
    public string? ContentRating { get; set; }

    [MaxLength(255)]
    [Column("genre")]
    public string? Genre { get; set; }

    [Column("budget")]
    public decimal? Budget { get; set; }

    [Column("revenue")]
    public decimal? Revenue { get; set; }
}