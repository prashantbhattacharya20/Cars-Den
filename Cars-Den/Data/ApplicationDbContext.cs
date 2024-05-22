using Cars_Den.Models;
using Microsoft.EntityFrameworkCore;

namespace Cars_Den.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<Users> Users { get; set; }

        public DbSet<Cars> Cars { get; set; }

        public DbSet<Bookings> Bookings { get; set; }

    }
    
}
