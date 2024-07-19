using BookApp.Models;
using Microsoft.EntityFrameworkCore;

namespace BookApp.Data
{
    public class BookAppContext : DbContext
    {
        public BookAppContext(DbContextOptions<BookAppContext> options) : base(options)
        {
        }

        public DbSet<Favorite> Favoritess { get; set; }
    }
}
