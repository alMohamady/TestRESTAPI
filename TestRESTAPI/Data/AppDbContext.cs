using Microsoft.EntityFrameworkCore;
using TestRESTAPI.Data.Models;

namespace TestRESTAPI.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext>  options) : base(options) 
        { 
        
        }

        public DbSet<Category> Categories { get; set; }

        public DbSet<Item> Items { get; set; }
    }
}
