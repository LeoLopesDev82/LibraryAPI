using LibraryAPI.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace LibraryAPI.Data
{
    public class LibraryDbContext : DbContext
    {
        public LibraryDbContext(DbContextOptions<LibraryDbContext> options) : base(options)
        {

        }
        public DbSet<Book> Books { get; set; }
        public DbSet<Category> Categories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Category>()
                .HasMany(c => c.Books)
                .WithOne(b => b.Category)
                .HasForeignKey(b => b.CategoryId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
