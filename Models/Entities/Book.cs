using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace LibraryAPI.Models.Entities
{
    public class Book
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Title { get; set; }
        [Required]
        [MaxLength(100)]
        public string Author { get; set; }
        [MaxLength(500)]
        public string? Description { get; set; }
        public DateTime? PublishedAt { get; set; }
        [ForeignKey("Category")]
        public int CategoryId { get; set; }
        public Category? Category { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}
