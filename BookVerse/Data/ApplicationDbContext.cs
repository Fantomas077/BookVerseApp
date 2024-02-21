using BookVerse.Models;
using Microsoft.EntityFrameworkCore;

namespace BookVerse.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<Registration> Registrations { get; set; }
    }
}
