using Library.Models;
using Library.Models.Books;
using Library.Models.Sales;
using Microsoft.EntityFrameworkCore;

namespace Library
{
    public class ApplicationDBContext : DbContext
    {
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options) : base(options)
        {
        }

            public DbSet<Book>Books { get; set; }
            public DbSet<Shelf> Shelves { get; set; }
            public DbSet<Sales> Sales { get; set; }
            public DbSet<CartItems> CartItems { get; set; }



    }
}