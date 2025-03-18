using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MySqlX.XDevAPI;
using SpClima.Models;
using SpCLima.Models;

namespace SpClima.Data;

public class AppDbContext :IdentityDbContext<Usuario>
{
    public AppDbContext(DbContextOptions<AppDbContext> options): base(options)
    {
    }

    public DbSet<Client> Clientes { get; set; }
    public DbSet<Servico> Servicos  { get; set; }
    public DbSet<ServicoFoto> ServicoFotos  { get; set; }
    public DbSet<TipoSevico> TipoSevico  { get; set; }
    public DbSet<Orcamento> Orcamentos  { get; set; }
    public DbSet<OrcamentoServico> OrcamentoSevicos  { get; set; }
    public DbSet<Usuario> Usuarios { get; set; }
    public DbSet<TipoSevico> TiposServicos { get; set; }
    public object Database { get; internal set; }


    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        #region Renomeação das tabelas do Identity
        builder.Entity<Usuario>().ToTable("usuario");
        builder.Entity<IdentityRole>().ToTable("perfil");
        builder.Entity<IdentityUserRole<string>>().ToTable("usuario_perfil");
        builder.Entity<IdentityUserToken<string>>().ToTable("usuario_token");
        builder.Entity<IdentityUserClaim<string>>().ToTable("usuario_regra");
        builder.Entity<IdentityUserLogin<string>>().ToTable("usuario_login");
        builder.Entity<IdentityRoleClaim<string>>().ToTable("perfil_regra");
        #endregion


        AppDbSeed seed = new(builder);

    }
}