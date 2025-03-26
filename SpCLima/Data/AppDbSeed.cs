using SpClima.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using SpCLima.Models;


namespace SpClima.Data;

public class AppDbSeed
{
    public AppDbSeed(ModelBuilder builder)
    {
        // Servico
        builder.Entity<Servico>().HasData(
            new Servico { Id = 1, NomeDoServico = "Limpeza Residencial", Descricao = "Higienização profunda para remover poeira, ácaros e impurezas, garantindo ar mais puro e melhor desempenho do aparelho.", Valor = 250.00m, TipoServicoId = 1 },
            new Servico { Id = 2, NomeDoServico = "Manutenção de Ar Condicionado", Descricao = "Inspeção e ajustes para prevenir falhas, prolongar a vida útil e manter a eficiência do equipamento.", Valor = 250.00m, TipoServicoId = 2 }
        );

        // TipoServico
        builder.Entity<TipoServico>().HasData(
            new TipoServico { Id = 1, Nome = "Ar-Condicionado", Foto = "" },
            new TipoServico { Id = 2, Nome = "Geladeira", Foto = "" },
            new TipoServico { Id = 3     , Nome = "Maquina de Lavar", Foto = "" }
        );

        
    // Popula a tabela BTU
    builder.Entity<Btu>().HasData(
        new Btu { Id = 1, Valor = 9000,  CustoInstalacaoBase = 150.00m },
        new Btu { Id = 2, Valor = 12000, CustoInstalacaoBase = 200.00m }
    );

    // Exemplo: Popula um serviço de Ar-Condicionado com BTU
    builder.Entity<Servico>().HasData(
        new Servico
        { 
            Id = 1,
            Descricao = "Instalação de Ar-Condicionado Split",
            TipoServicoId = 1, // ID do "Ar-Condicionado"
            BtuId = 1 // BTU de 9000
        });

        // Orcamento
        builder.Entity<Orcamento>().HasData(
            new Orcamento { Id = 1, DataPedido = DateTime.Now, DescricaoPedido = "", StatusOrcamento = "Rejeitado", Desconto = 00, Total = 00 },
            new Orcamento { Id = 2, DataPedido = DateTime.Now, DescricaoPedido = "", StatusOrcamento = "", Desconto = 00, Total = 00 }
        );

        // OrcamentoServico
        builder.Entity<OrcamentoServico>().HasData(
            new OrcamentoServico { OrcamentoId = 1, ServicoId = 1 },
            new OrcamentoServico { OrcamentoId = 2, ServicoId = 2 }
        );


        #region Populate Roles - Perfis de Usuário
        List<IdentityRole> roles = new()
        {
            new IdentityRole() {
               Id = "0b44ca04-f6b0-4a8f-a953-1f2330d30894",
               Name = "Administrador",
               NormalizedName = "ADMINISTRADOR"
            },
            new IdentityRole() {
               Id = "bec71b05-8f3d-4849-88bb-0e8d518d2de8",
               Name = "Funcionário",
               NormalizedName = "FUNCIONÁRIO"
            },
            new IdentityRole() {
               Id = "ddf093a6-6cb5-4ff7-9a64-83da34aee005",
               Name = "Cliente",
               NormalizedName = "CLIENTE"
            },
        };
        builder.Entity<IdentityRole>().HasData(roles);
        #endregion

        #region Populate Usuário
        List<Usuario> usuarios = new() {
            new Usuario(){
                Id = "ddf093a6-6cb5-4ff7-9a64-83da34aee005",
                Email = "gallojunior@gmail.com",
                NormalizedEmail = "GALLOJUNIOR@GMAIL.COM",
                UserName = "GalloJunior",
                NormalizedUserName = "GALLOJUNIOR",
                LockoutEnabled = true,
                EmailConfirmed = true,
                Nome = "José Antonio Gallo Junior",
                DataNascimento = DateTime.Parse("05/08/1981"),
                Foto = "/img/usuarios/ddf093a6-6cb5-4ff7-9a64-83da34aee005.png"
            }
        };
        foreach (var user in usuarios)
        {
            PasswordHasher<IdentityUser> pass = new();
            user.PasswordHash = pass.HashPassword(user, "123456");
        }
        builder.Entity<Usuario>().HasData(usuarios);
        #endregion

        #region Populate UserRole - Usuário com Perfil
        List<IdentityUserRole<string>> userRoles = new()
        {
            new IdentityUserRole<string>() {
                UserId = usuarios[0].Id,
                RoleId = roles[0].Id
            },
            new IdentityUserRole<string>() {
                UserId = usuarios[0].Id,
                RoleId = roles[1].Id
            },
            new IdentityUserRole<string>() {
                UserId = usuarios[0].Id,
                RoleId = roles[2].Id
            }
        };
        builder.Entity<IdentityUserRole<string>>().HasData(userRoles);
        #endregion
    }
}


