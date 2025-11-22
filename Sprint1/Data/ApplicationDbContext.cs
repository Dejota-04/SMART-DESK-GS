using Microsoft.EntityFrameworkCore;
using Sprint1.Models;

namespace Sprint1.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Dispositivo> Dispositivos { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Suporte> Suportes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // =========================================================
            // 1. MAPEAMENTO DE TABELAS (MAIÚSCULO)
            // =========================================================
            modelBuilder.Entity<Dispositivo>().ToTable("DISPOSITIVO");
            modelBuilder.Entity<Usuario>().ToTable("USUARIO");
            modelBuilder.Entity<Suporte>().ToTable("SUPORTE");

            // =========================================================
            // 2. MAPEAMENTO DE COLUNAS (MAIÚSCULO) - O Segredo do ORA-00904
            // =========================================================

            // --- Dispositivo ---
            modelBuilder.Entity<Dispositivo>(e =>
            {
                e.Property(d => d.Uuid).HasColumnName("UUID"); // <--- AQUI ESTAVA O SEU ERRO
                e.Property(d => d.DataCadastro).HasColumnName("DATA_CADASTRO");
            });

            // --- Usuario ---
            modelBuilder.Entity<Usuario>(e =>
            {
                e.Property(u => u.Id).HasColumnName("ID");
                e.Property(u => u.DispositivoId).HasColumnName("DISPOSITIVO_ID");
                e.Property(u => u.Nome).HasColumnName("NOME");
                e.Property(u => u.Email).HasColumnName("EMAIL");
                e.Property(u => u.SenhaHash).HasColumnName("SENHA_HASH");
                e.Property(u => u.Altura).HasColumnName("ALTURA");
                e.Property(u => u.Peso).HasColumnName("PESO");
                e.Property(u => u.Sexo).HasColumnName("SEXO").HasConversion<string>(); // Enum como String
                e.Property(u => u.ModeloTrabalho).HasColumnName("MODELO_TRABALHO").HasConversion<string>(); // Enum como String
                e.Property(u => u.Role).HasColumnName("ROLE").HasConversion<string>(); // Enum como String
                e.Property(u => u.DataCadastro).HasColumnName("DATA_CADASTRO");
            });

            // --- Suporte ---
            modelBuilder.Entity<Suporte>(e =>
            {
                e.Property(s => s.Id).HasColumnName("ID");
                e.Property(s => s.UsuarioId).HasColumnName("USUARIO_ID");
                e.Property(s => s.AdminId).HasColumnName("ADMIN_ID");
                e.Property(s => s.Titulo).HasColumnName("TITULO");
                e.Property(s => s.Descricao).HasColumnName("DESCRICAO");
                e.Property(s => s.DataReclamacao).HasColumnName("DATA_RECLAMACAO");
                e.Property(s => s.DataResolucao).HasColumnName("DATA_RESOLUCAO");
                e.Property(s => s.Status).HasColumnName("STATUS").HasConversion<string>(); // Enum como String
            });

            // =========================================================
            // 3. RELACIONAMENTOS (FKs)
            // =========================================================
            modelBuilder.Entity<Usuario>()
                .HasOne(u => u.Dispositivo)
                .WithMany()
                .HasForeignKey(u => u.DispositivoId);

            modelBuilder.Entity<Suporte>()
                .HasOne(s => s.Solicitante)
                .WithMany()
                .HasForeignKey(s => s.UsuarioId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Suporte>()
                .HasOne(s => s.Atendente)
                .WithMany()
                .HasForeignKey(s => s.AdminId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}