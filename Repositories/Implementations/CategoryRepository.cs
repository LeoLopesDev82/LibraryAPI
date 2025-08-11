﻿using LibraryAPI.Data;
using LibraryAPI.Models.Entities;
using LibraryAPI.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace LibraryAPI.Repositories.Implementations
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly LibraryDbContext _context;

        public CategoryRepository(LibraryDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Category>> GetAllAsync()
        {
            return await _context.Categories.Include(c => c.Books).ToListAsync();
        }

        public async Task<Category?> GetByIdAsync(int id)
        {
            return await _context.Categories.Include(c => c.Books).FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task<Category> AddAsync(Category category)
        {
            _context.Categories.Add(category);

            await _context.SaveChangesAsync();

            return category;
        }

        public async Task<Category?> UpdateAsync(Category category)
        {
            var existing = await _context.Categories.FindAsync(category.Id);

            if (existing == null) return null;

            existing.Name = category.Name;

            await _context.SaveChangesAsync();

            return existing;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var category = await _context.Categories.FindAsync(id);

            if (category == null) return false;

            _context.Categories.Remove(category);

            await _context.SaveChangesAsync();

            return true;
        }
    }
}
