using Microsoft.EntityFrameworkCore;

namespace banze.Core
{
    public class ApplicationDbContext : DbContext
    {
        private readonly AppSettings _settings;
        
        public DbSet<Client> Clients { get; set; }

        public ApplicationDbContext(AppSettings settings)
        {
            _settings = settings;
        }
        
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder
                .UseSqlServer(_settings.ConnectionStrings.DefaultConnection);
        }
        
    }
}