using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace cloudApp.Models
{
    public class DataContext : DbContext
    {
        protected readonly IConfiguration Configuration;

        public DbSet<Image> Images { get; set; }

        public DataContext() : base() { }

        public DataContext(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            // key vault
            options.UseSqlServer(Configuration.GetConnectionString("WebApiDatabase"));
        }
    }
}
