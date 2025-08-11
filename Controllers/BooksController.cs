using LibraryAPI.Models.DTOs.Book;
using LibraryAPI.Models.Entities;
using LibraryAPI.Repositories.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LibraryAPI.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class BooksController : ControllerBase
    {
        private readonly IBookRepository _repository;

        public BooksController(IBookRepository repository)
        {
            _repository = repository;
        }

        /// <summary>
        /// Retrieves all books.
        /// </summary>
        /// <returns>A list of books in DTO format.</returns>
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var books = await _repository.GetAllAsync();

            var dto = books.Select(b => new BookDto
            {
                Id = b.Id,
                Title = b.Title,
                Author = b.Author,
                Description = b.Description,
                PublishedAt = b.PublishedAt,
                CategoryId = b.CategoryId,
                CategoryName = b.Category?.Name ?? string.Empty,
                CreatedAt = b.CreatedAt
            });

            return Ok(dto);
        }

        /// <summary>
        /// Retrieves a book by its ID.
        /// </summary>
        /// <param name="id">The ID of the book.</param>
        /// <returns>The book in DTO format or 404 if not found.</returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var b = await _repository.GetByIdAsync(id);

            if (b == null) return NotFound();

            var dto = new BookDto
            {
                Id = b.Id,
                Title = b.Title,
                Author = b.Author,
                Description = b.Description,
                PublishedAt = b.PublishedAt,
                CategoryId = b.CategoryId,
                CategoryName = b.Category?.Name ?? string.Empty,
                CreatedAt = b.CreatedAt
            };

            return Ok(dto);
        }

        /// <summary>
        /// Creates a new book.
        /// </summary>
        /// <param name="dto">The data for the book to create.</param>
        /// <returns>The created book in DTO format with 201 status and Location header.</returns>
        [HttpPost]
        public async Task<IActionResult> Create(CreateBookDto dto)
        {
            var book = new Book
            {
                Title = dto.Title,
                Author = dto.Author,
                Description = dto.Description,
                PublishedAt = dto.PublishedAt,
                CategoryId = dto.CategoryId
            };

            var created = await _repository.AddAsync(book);

            var result = new BookDto
            {
                Id = created.Id,
                Title = created.Title,
                Author = created.Author,
                Description = created.Description,
                PublishedAt = created.PublishedAt,
                CategoryId = created.CategoryId,
                CategoryName = created.Category?.Name ?? string.Empty,
                CreatedAt = created.CreatedAt
            };

            return CreatedAtAction(nameof(GetById), new { id = created.Id }, result);
        }

        /// <summary>
        /// Updates an existing book.
        /// </summary>
        /// <param name="id">The ID of the book to update.</param>
        /// <param name="dto">The updated book data.</param>
        /// <returns>The updated book in DTO format, or 404 if not found, or 400 if ID mismatch.</returns>
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, UpdateBookDto dto)
        {
            if (id != dto.Id) return BadRequest("ID mismatch");

            var book = new Book
            {
                Id = dto.Id,
                Title = dto.Title,
                Author = dto.Author,
                Description = dto.Description,
                PublishedAt = dto.PublishedAt,
                CategoryId = dto.CategoryId
            };

            var updated = await _repository.UpdateAsync(book);

            if (updated == null) return NotFound();

            var result = new BookDto
            {
                Id = updated.Id,
                Title = updated.Title,
                Author = updated.Author,
                Description = updated.Description,
                PublishedAt = updated.PublishedAt,
                CategoryId = updated.CategoryId,
                CategoryName = updated.Category?.Name ?? string.Empty,
                CreatedAt = updated.CreatedAt
            };

            return Ok(result);
        }

        /// <summary>
        /// Deletes a book by its ID.
        /// </summary>
        /// <param name="id">The ID of the book to delete.</param>
        /// <returns>No content (204) if deleted, or 404 if not found.</returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var deleted = await _repository.DeleteAsync(id);

            if (!deleted) return NotFound();

            return NoContent();
        }
    }
}
