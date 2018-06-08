using Microsoft.EntityFrameworkCore;

namespace banze.Core
{
    public class ApplicationDbContext : DbContext
    {
        private readonly AppSettings _settings;
        
        public DbSet<Client> Clients { get; set; }
        public DbSet<BocaDeUrna> BocasDeUrna { get; set; }
        public DbSet<Candidato> Candidatos { get; set; }
        public DbSet<Local> Locais { get; set; }
        public DbSet<Noticia> Noticias { get; set; }
        public DbSet<Titulo> Titulos { get; set; }
        public DbSet<Zona> Zonas { get; set; }


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