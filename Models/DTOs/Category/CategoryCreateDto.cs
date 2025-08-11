using System.ComponentModel.DataAnnotations;

namespace LibraryAPI.Models.DTOs.Category
{
    /// <summary>
    /// Data Transfer Object used to create a new category.
    /// </summary>
    public class CategoryCreateDto
    {
        /// <summary>
        /// Name of the category. Required. Maximum length: 50 characters.
        /// </summary>
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }
    }
}
