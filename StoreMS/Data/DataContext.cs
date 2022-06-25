using Microsoft.EntityFrameworkCore;
using StoreMS.Models;

namespace StoreMS.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions options) : base(options)
        { }

        public DbSet<User> Users { get; set; }
        public DbSet<Actor> Actors { get; set; }

    }
}
