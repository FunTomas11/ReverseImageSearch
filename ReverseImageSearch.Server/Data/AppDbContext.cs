using Microsoft.EntityFrameworkCore;
using ReverseImageSearch.Server.Models;

namespace ReverseImageSearch.Server.Data
{
    public class AppDbContext: DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) 
            {
            }

        public DbSet<ImageMetadata> ImageMetadata { get; set; }
    }
}
