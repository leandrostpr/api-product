using Microsoft.EntityFrameworkCore;

namespace ApiProduto.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Produto> Produtos { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            => optionsBuilder.UseNpgsql("Host=localhost;Database=teste;Username=postgres;Password=123456");

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Produto>()
                .Property(p => p.Nome)
                .HasMaxLength(80);

            modelBuilder.Entity<Produto>()
                 .Property(p => p.Preco)
                 .HasPrecision(10, 2);

            modelBuilder.Entity<Produto>()
               .HasData(
                    new Produto { Id = 1, Nome = "Caneta", Preco = 7.95M, Estoque = 10 },
                    new Produto { Id = 2, Nome = "Caderno", Preco = 12.99M, Estoque = 11 },
                    new Produto { Id = 3, Nome = "Lápis", Preco = 0.95M, Estoque = 12 },
                    new Produto { Id = 4, Nome = "Estojo", Preco = 10.95M, Estoque = 13 }
                );
        }
    }
}
