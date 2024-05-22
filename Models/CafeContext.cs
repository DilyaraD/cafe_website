using Microsoft.EntityFrameworkCore;

namespace Cafe_website.Models
{
    public class CafeContext : DbContext
    {
        public CafeContext(DbContextOptions<CafeContext> options) : base(options)
        {
        }

        public CafeContext()
        {
        }

        public DbSet<Administrator> Administrator { get; set; }
        public DbSet<Bron> Bron { get; set; }
        public DbSet<Stol> Stol { get; set; }
        public DbSet<Waiter> Waiter { get; set; }
        public DbSet<ConfirmedBooking> ConfirmedBooking { get; set; }
    }
}
