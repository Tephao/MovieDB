using Microsoft.EntityFrameworkCore;
using moviedb.Domain.Entidades;

namespace moviedb.Infra
{
    public class DbContexto: DbContext
    {
        public DbContexto()
        {
        }

        public DbSet<Filme> Filmes { get; set; }
        public DbSet<Serie> Series { get; set; }
        public DbSet<Ator> Atores { get; set; }
        public DbContexto(DbContextOptions<DbContexto> options) : base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                string conexao = "server=localhost; port=3306; database=moviedb; user=root; password=";
                optionsBuilder.UseMySql(conexao, ServerVersion.AutoDetect(conexao));
            }
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Filme>(entity =>
            {
                entity.Property(e => e.Nome);
                entity.Property(e => e.Genero);
                entity.Property(e => e.Descricao);
                entity.Property(e => e.Ano);
            }
            );

            modelBuilder.Entity<Serie>(entity =>
            {
                entity.Property(e => e.Nome);
                entity.Property(e => e.Genero);
                entity.Property(e => e.Descricao);
                entity.Property(e => e.EmProducao);
                entity.Property(e => e.NumeroDeTemporadas);
                entity.Property(e => e.NumeroDeEpisodios);
            }
            );

            modelBuilder.Entity<Ator>(entity =>
            {
                entity.Property(e => e.Nome);
                entity.Property(e => e.Nacionalidade);
                entity.Property(e => e.DataDeNascimento);
            }
            );
        }
    }
}
