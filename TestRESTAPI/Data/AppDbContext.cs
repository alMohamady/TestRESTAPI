using Microsoft.EntityFrameworkCore;

namespace TestRESTAPI.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext>  options) : base(options) 
        { 
        
        }


    }
}
