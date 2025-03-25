using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SpClima.Models;
using SpCLima.Models;

namespace SpClima.Data;

public class AppDbContext : IdentityDbContext<Usuario>
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    public DbSet<Usuario> Usuarios { get; set; }
    public DbSet<Servico> Servicos { get; set; }
    public DbSet<TipoServico> TipoServicos { get; set; }
    public DbSet<Orcamento> Orcamentos { get; set; }
    public DbSet<OrcamentoServico> OrcamentoSevicos { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        #region Definição dos Nomes do Entity
        builder.Entity<Usuario>().ToTable("usuario");
        builder.Entity<IdentityRole>().ToTable("perfil");
        builder.Entity<IdentityUserRole<string>>().ToTable("usuario_perfil");
        builder.Entity<IdentityUserClaim<string>>().ToTable("usuario_regra");
        builder.Entity<IdentityUserToken<string>>().ToTable("usuario_token");
        builder.Entity<IdentityUserLogin<string>>().ToTable("usuario_login");
        builder.Entity<IdentityRoleClaim<string>>().ToTable("perfil_regra");
        #endregion

        // Configuração dos relacionamentos
        builder.Entity<Usuario>()
            .HasMany(u => u.Servicos)
            .WithOne(s => s.Usuario)
            .HasForeignKey(s => s.ClienteId);

        builder.Entity<TipoServico>()
            .HasMany(t => t.Servicos)
            .WithOne(s => s.TipoServico)
            .HasForeignKey(s => s.TipoServicoId);

        builder.Entity<Orcamento>()
            .HasMany(o => o.OrcamentoServicos)
            .WithOne(os => os.Orcamento)
            .HasForeignKey(os => os.OrcamentoId);

        builder.Entity<Servico>()
            .HasMany(s => s.OrcamentoServicos)
            .WithOne(os => os.Servico)
            .HasForeignKey(os => os.ServicoId);

        builder.Entity<OrcamentoServico>()
            .HasKey(os => new { os.OrcamentoId, os.ServicoId });


        AppDbSeed seed = new(builder);
    }
}