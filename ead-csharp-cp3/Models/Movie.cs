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
    [Column("title")]
    [MaxLength(255)]
    public required string Title { get; set; }

    [Column("original_title")]
    [MaxLength(255)]
    public string? OriginalTitle { get; set; }

    [Column("original_language")]
    [MaxLength(20)]
    public string? OriginalLanguage { get; set; }

    [Column("release_year")]
    public int ReleaseYear { get; set; }

    [Column("duration")]
    public int Duration { get; set; }

    [Column("content_rating")]
    [MaxLength(20)]
    public string? ContentRating { get; set; }

    [Column("genre")]
    [MaxLength(255)]
    public string? Genre { get; set; }

    [Column("budget")]
    public decimal? Budget { get; set; }

    [Column("revenue")]
    public decimal? Revenue { get; set; }
}