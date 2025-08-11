using LibraryAPI.Data;
using LibraryAPI.Models.Entities;
using LibraryAPI.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace LibraryAPI.Repositories.Implementations
{
    public class BookRepository : IBookRepository
    {
        private readonly LibraryDbContext _context;

        public BookRepository(LibraryDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Book>> GetAllAsync()
        {
            return await _context.Books.Include(b => b.Category).ToListAsync();
        }

        public async Task<Book?> GetByIdAsync(int id)
        {
            return await _context.Books.Include(b => b.Category).FirstOrDefaultAsync(b => b.Id == id);
        }

        public async Task<Book> AddAsync(Book book)
        {
            _context.Books.Add(book);

            await _context.SaveChangesAsync();

            return book;
        }

        public async Task<Book?> UpdateAsync(Book book)
        {
            var existing = await _context.Books.FindAsync(book.Id);

            if (existing == null) return null;

            existing.Title = book.Title;
            existing.Author = book.Author;
            existing.Description = book.Description;
            existing.PublishedAt = book.PublishedAt;
            existing.CategoryId = book.CategoryId;

            await _context.SaveChangesAsync();

            return existing;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var book = await _context.Books.FindAsync(id);

            if (book == null) return false;

            _context.Books.Remove(book);

            await _context.SaveChangesAsync();

            return true;
        }
    }
}