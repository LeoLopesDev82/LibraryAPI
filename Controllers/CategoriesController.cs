using LibraryAPI.Models.DTOs.Category;
using LibraryAPI.Models.Entities;
using LibraryAPI.Repositories.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LibraryAPI.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoryRepository _repository;

        public CategoriesController(ICategoryRepository repository)
        {
            _repository = repository;
        }

        /// <summary>
        /// Retrieves all categories.
        /// </summary>
        /// <returns>List of category DTOs.</returns>
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var categories = await _repository.GetAllAsync();

            var dto = categories.Select(c => new CategoryDto
            {
                Id = c.Id,
                Name = c.Name,
                CreatedAt = c.CreatedAt
            });

            return Ok(dto);
        }

        /// <summary>
        /// Retrieves a specific category by its ID.
        /// </summary>
        /// <param name="id">Category ID.</param>
        /// <returns>Category DTO if found; otherwise, NotFound.</returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var category = await _repository.GetByIdAsync(id);

            if (category == null) return NotFound();

            var dto = new CategoryDto
            {
                Id = category.Id,
                Name = category.Name,
                CreatedAt = category.CreatedAt
            };

            return Ok(dto);
        }

        /// <summary>
        /// Creates a new category.
        /// </summary>
        /// <param name="dto">Category create DTO.</param>
        /// <returns>The created category DTO.</returns>
        [HttpPost]
        public async Task<IActionResult> Create(CategoryCreateDto dto)
        {
            var category = new Category
            {
                Name = dto.Name
            };

            var created = await _repository.AddAsync(category);

            var result = new CategoryDto
            {
                Id = created.Id,
                Name = created.Name,
                CreatedAt = created.CreatedAt
            };

            return CreatedAtAction(nameof(GetById), new { id = result.Id }, result);
        }

        /// <summary>
        /// Updates an existing category by ID.
        /// </summary>
        /// <param name="id">Category ID.</param>
        /// <param name="dto">Category update DTO.</param>
        /// <returns>The updated category DTO if successful; BadRequest or NotFound otherwise.</returns>
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, CategoryUpdateDto dto)
        {
            if (id != dto.Id) return BadRequest("ID mismatch");

            var existing = await _repository.GetByIdAsync(id);

            if (existing == null) return NotFound();

            existing.Name = dto.Name;

            var updated = await _repository.UpdateAsync(existing);

            var result = new CategoryDto
            {
                Id = updated.Id,
                Name = updated.Name,
                CreatedAt = updated.CreatedAt
            };

            return Ok(result);
        }

        /// <summary>
        /// Deletes a category by ID.
        /// </summary>
        /// <param name="id">Category ID.</param>
        /// <returns>NoContent if deleted; NotFound if category does not exist.</returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var deleted = await _repository.DeleteAsync(id);

            if (!deleted) return NotFound();

            return NoContent();
        }
    }
}