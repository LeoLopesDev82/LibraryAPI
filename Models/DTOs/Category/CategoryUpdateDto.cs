using System.ComponentModel.DataAnnotations;

namespace LibraryAPI.Models.DTOs.Category
{
    /// <summary>
    /// Data Transfer Object for updating an existing category.
    /// </summary>
    public class CategoryUpdateDto
    {
        /// <summary>
        /// Unique identifier of the category to be updated.
        /// </summary>
        [Required]
        public int Id { get; set; }

        /// <summary>
        /// Updated name of the category.
        /// </summary>
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }
    }
}
