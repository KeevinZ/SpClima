// using SpClima.Models;
// using Microsoft.AspNetCore.Identity;
// using Microsoft.EntityFrameworkCore;


// namespace SpClima.Data;

// public class AppDbSeed
// {
//     public static void Seed(ModelBuilder builder)
//     {
//         // Inserção de dados iniciais para TipoServico
//         builder.Entity<TipoServico>().HasData(
//             new TipoServico { Id = 1, Nome = "Limpeza" },
//             new TipoServico { Id = 2, Nome = "Manutenção" }
//         );

//         // Inserção de dados iniciais para Cliente
//         builder.Entity<Cliente>().HasData(
//             new Cliente { Id = 1, Nome = "João Silva", Email = "joao@example.com" },
//             new Cliente { Id = 2, Nome = "Maria Souza", Email = "maria@example.com" }
//         );

//         // Inserção de dados iniciais para Servico
//         builder.Entity<Servico>().HasData(
//             new Servico { Id = 1, Nome = "Limpeza Residencial", ClienteId = 1, TipoServicoId = 1 },
//             new Servico { Id = 2, Nome = "Manutenção de Ar Condicionado", ClienteId = 2, TipoServicoId = 2 }
//         );

//         // Inserção de dados iniciais para Orcamento
//         builder.Entity<Orcamento>().HasData(
//             new Orcamento { Id = 1, Data = DateTime.Now, ValorTotal = 500.00m },
//             new Orcamento { Id = 2, Data = DateTime.Now, ValorTotal = 300.00m }
//         );

//         // Inserção de dados iniciais para OrcamentoServico
//         builder.Entity<OrcamentoServico>().HasData(
//             new OrcamentoServico { OrcamentoId = 1, ServicoId = 1 },
//             new OrcamentoServico { OrcamentoId = 2, ServicoId = 2 }
//         );
//     }

//     #region Populate Roles - Perfis de Usuário
//     List<IdentityRole> roles = new()
//         {
//             new IdentityRole() {
//                Id = "0b44ca04-f6b0-4a8f-a953-1f2330d30894",
//                Name = "Administrador",
//                NormalizedName = "ADMINISTRADOR"
//             },
//             new IdentityRole() {
//                Id = "ddf093a6-6cb5-4ff7-9a64-83da34aee005",
//                Name = "Cliente",
//                NormalizedName = "CLIENTE"
//             },
//         };
//     Builder.Entity<IdentityRole>().HasData(roles);

//     public AppDbSeed(ModelBuilder builder)
//     {
//         this.builder = builder;
//     }
//     #endregion

//     #region Populate Usuário
//     List<Usuario> usuarios = new() {
//             new Usuario(){
//                 Id = "ddf093a6-6cb5-4ff7-9a64-83da34aee005",
//                 Email = "admin@gmail.com",
//                 NormalizedEmail = "ADMIN@GMAIL.COM",
//                 UserName = "Admin",
//                 NormalizedUserName = "ADMIN",
//                 LockoutEnabled = true,
//                 EmailConfirmed = true,
//                 Nome = "Admin",
//                 DataNascimento = DateTime.Parse("20/07/2002"),
//                 Foto = "/img/usuarios/Galingo.png"
//             }
//         };
//         foreach (var user in usuarios)
//         {
//             PasswordHasher<IdentityUser> pass = new();
//     private ModelBuilder builder;

//     user.PasswordHash = pass.HashPassword(user, "123456");
//         }
// builder.Entity<Usuario>().HasData(usuarios);
// #endregion

// #region Populate UserRole - Usuário com Perfil
// List<IdentityUserRole<string>> userRoles = new()
//         {
//             new IdentityUserRole<string>() {
//                 UserId = usuarios[0].Id,
//                 RoleId = roles[0].Id
//             },
//             new IdentityUserRole<string>() {
//                 UserId = usuarios[0].Id,
//                 RoleId = roles[1].Id
//             },
//             new IdentityUserRole<string>() {
//                 UserId = usuarios[0].Id,
//                 RoleId = roles[2].Id
//             }
//         };
// builder.Entity<IdentityUserRole<string>>().HasData(userRoles);
//         #endregion
//     }

//     internal static void Seed(ModelBuilder builder)
// {
//     throw new NotImplementedException();
// }
