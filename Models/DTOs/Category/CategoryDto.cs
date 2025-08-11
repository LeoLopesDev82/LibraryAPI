namespace LibraryAPI.Models.DTOs.Category
{
    /// <summary>
    /// Data Transfer Object for returning category information.
    /// </summary>
    public class CategoryDto
    {
        /// <summary>
        /// Unique identifier of the category.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Name of the category.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Date and time when the category was created.
        /// </summary>
        public DateTime CreatedAt { get; set; }
    }
}
