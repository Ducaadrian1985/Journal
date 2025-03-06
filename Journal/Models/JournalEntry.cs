using System.ComponentModel.DataAnnotations;

namespace Journal.Models;

public class JournalEntry
{
    //[Key]
    public int Id { get; set; }

    [Required(ErrorMessage = "Title is required!")]
    [StringLength(50, MinimumLength = 3, ErrorMessage = "Title must be between 3 to 50 Characters!")]
    public string Title { get; set; } = string.Empty;

    [Required(ErrorMessage = "Content is required!")]
    [StringLength(1000, MinimumLength = 10, ErrorMessage = "Content must be between 10 to 1000 Characters!")]
    public string Content { get; set; } = string.Empty;

    [Required] public DateTime Created { get; set; } = DateTime.Now;

    public int? CategoryId { get; set; }
    public Category? Category { get; set; }

    public int? TagId { get; set; }
    public Tag? Tag { get; set; }
}