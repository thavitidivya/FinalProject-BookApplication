using Microsoft.EntityFrameworkCore;
using AuthorService.Models;

namespace AuthorService.Data
{
    public class BookAppContext : DbContext
    {
        public BookAppContext(DbContextOptions<BookAppContext> options) : base(options) { }

        public DbSet<Author> Authorss { get; set; }
    }
}
