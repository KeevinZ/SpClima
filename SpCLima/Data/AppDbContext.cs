using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SpClima.Models;

namespace SpClima.Data;


public class AppDbContext : IdentityDbContext<Usuario>
{
    public AppDbContext (DbContextOptions<AppDbContext> options) : base(options)
    {      
    }
    public DbSet<Item> items { get; set; }
    public DbSet<ItemVariacao> itemVariacoes { get; set; }
    public DbSet<Orcamento> Orcamentos { get; set; }
    public DbSet<OrcamentoItem> OrcamentoItems { get; set; }
    public DbSet<Usuario> Usuarios { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        #region Renomeação das tabelas do identity
        builder.Entity<Usuario>().ToTable("Usuario");
        builder.Entity<IdentityRole>().ToTable("perfil");
        builder.Entity<IdentityUserRole<string>>().ToTable("usuario_perfil");
        builder.Entity<IdentityUserToken<string>>().ToTable("usuario_token");
        builder.Entity<IdentityUserClaim<string>>().ToTable("usuario_regra");
        builder.Entity<IdentityUserLogin<string>>().ToTable("usuario_login");
        builder.Entity<IdentityRoleClaim<string>>().ToTable("perfil_regra");
        #endregion

// chave composta para OrcamentoItem
    builder.Entity<OrcamentoItem>()
        .HasKey(ci => new { ci.OrcamentoId, ci.ItemVariacaoId });

    builder.Entity<OrcamentoItem>()
        .HasOne(ci => ci.Orcamento)
        .WithMany(o => o.OrcamentoItems)
        .HasForeignKey(ci => ci.OrcamentoId);

    builder.Entity<OrcamentoItem>()
        .HasOne(ci => ci.Variacao)
        .WithMany(i => i.OrcamentoItems)
        .HasForeignKey(ci => ci.ItemVariacaoId);

        AppDbSeed seed = new(builder);
       
    }

}
