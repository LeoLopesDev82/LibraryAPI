using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace LibraryAPI.Models.Entities
{
    public class Category
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string Name { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        [JsonIgnore]
        public ICollection<Book>? Books { get; set; } = new List<Book>();
    }
}
