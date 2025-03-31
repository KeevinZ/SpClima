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
    public DbSet<Eletrodomestico> Eletrodomesticos { get; set; }
    public DbSet<Btu> Btus { get; set; }
    public DbSet<Orcamento> Orcamentos { get; set; }
    public DbSet<OrcamentoServico> OrcamentoSevicos { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        #region Definição dos Nomes do Entity (Identity)
        builder.Entity<Usuario>().ToTable("usuario");
        builder.Entity<IdentityRole>().ToTable("perfil");
        builder.Entity<IdentityUserRole<string>>().ToTable("usuario_perfil");
        builder.Entity<IdentityUserClaim<string>>().ToTable("usuario_regra");
        builder.Entity<IdentityUserToken<string>>().ToTable("usuario_token");
        builder.Entity<IdentityUserLogin<string>>().ToTable("usuario_login");
        builder.Entity<IdentityRoleClaim<string>>().ToTable("perfil_regra");
        #endregion

        #region Configuração dos Relacionamentos Customizados

        builder.Entity<Usuario>()
            .HasMany(u => u.Eletrodomesticos)
            .WithOne(e => e.Usuario)
            .HasForeignKey(e => e.UsuarioId)
            .OnDelete(DeleteBehavior.Cascade); // Opcional: define exclusão em cascata


        builder.Entity<Usuario>()
            .HasMany(u => u.Orcamentos)
            .WithOne(o => o.Usuario)
            .HasForeignKey(o => o.UsuarioId)
            .OnDelete(DeleteBehavior.Restrict); // Impede exclusão se houver orçamentos


        builder.Entity<Eletrodomestico>()
            .HasMany(e => e.Orcamentos)
            .WithOne(o => o.Eletrodomestico)
            .HasForeignKey(o => o.EletrodomesticoId)
            .OnDelete(DeleteBehavior.Restrict);


        builder.Entity<Orcamento>()
            .HasMany(o => o.Servicos)
            .WithOne(os => os.Orcamento)
            .HasForeignKey(os => os.OrcamentoId)
            .OnDelete(DeleteBehavior.Cascade);


        builder.Entity<Servico>()
            .HasMany(s => s.OrcamentoServicos)
            .WithOne(os => os.Servico)
            .HasForeignKey(os => os.ServicoId)
            .OnDelete(DeleteBehavior.Restrict);


        builder.Entity<Btu>()
            .HasMany(b => b.OrcamentoServicos)
            .WithOne(os => os.Btu)
            .HasForeignKey(os => os.BtuId)
            .OnDelete(DeleteBehavior.SetNull); // Permite nulo se BTU for excluído

        #endregion


        AppDbSeed seed = new(builder);
    }
}
