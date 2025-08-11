namespace LibraryAPI.Models.DTOs.Book
{
    /// <summary>
    /// Data Transfer Object for returning book details.
    /// </summary>
    public class BookDto
    {
        /// <summary>
        /// Unique identifier of the book.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Title of the book.
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// Author of the book.
        /// </summary>
        public string Author { get; set; }

        /// <summary>
        /// Optional description of the book.
        /// </summary>
        public string? Description { get; set; }

        /// <summary>
        /// Date when the book was published, if known.
        /// </summary>
        public DateTime? PublishedAt { get; set; }

        /// <summary>
        /// Identifier of the category this book belongs to.
        /// </summary>
        public int CategoryId { get; set; }

        /// <summary>
        /// Name of the category this book belongs to.
        /// </summary>
        public string CategoryName { get; set; }

        /// <summary>
        /// Date when the book record was created.
        /// </summary>
        public DateTime CreatedAt { get; set; }
    }
}
