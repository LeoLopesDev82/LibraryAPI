using System;
using System.ComponentModel.DataAnnotations;

namespace LibraryAPI.Models.DTOs.Book
{
    /// <summary>
    /// Data Transfer Object used to create a new book.
    /// </summary>
    public class CreateBookDto
    {
        /// <summary>
        /// Title of the book. Required. Maximum length: 100 characters.
        /// </summary>
        [Required]
        [MaxLength(100)]
        public string Title { get; set; }

        /// <summary>
        /// Author of the book. Required. Maximum length: 100 characters.
        /// </summary>
        [Required]
        [MaxLength(100)]
        public string Author { get; set; }

        /// <summary>
        /// Optional description of the book. Maximum length: 500 characters.
        /// </summary>
        [MaxLength(500)]
        public string? Description { get; set; }

        /// <summary>
        /// Date when the book was published, if known.
        /// </summary>
        public DateTime? PublishedAt { get; set; }

        /// <summary>
        /// Identifier of the category the book belongs to. Required.
        /// </summary>
        [Required]
        public int CategoryId { get; set; }
    }
}
