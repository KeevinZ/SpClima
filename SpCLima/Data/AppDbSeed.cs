using SpClima.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace SpClima.Data;

public class AppDbSeed
{
    public AppDbSeed(ModelBuilder builder)
    {
        List<Categoria> categorias = new() {
            new Categoria { Id = 1, Nome = "Smartphones" },
            new Categoria { Id = 2, Nome = "Notebooks" },
            new Categoria { Id = 3, Nome = "Smartwatches" },
        };
        builder.Entity<Categoria>().HasData(categorias);

        List<Produto> produtos = new List<Produto>
        {
        // Geladeiras
        new Produto { Id = 1, CategoriaId = 1, Nome = "Geladeira Brastemp Inverse Frost Free", Descricao = "Geladeira duplex com tecnologia Frost Free e capacidade de 400 litros.", ValorCusto = 1800.00m, ValorVenda = 3000.00m, QtdeEstoque = 10 },
        new Produto { Id = 2, CategoriaId = 1, Nome = "Geladeira Samsung French Door", Descricao = "Geladeira French Door com capacidade de 500 litros e iluminação LED.", ValorCusto = 2500.00m, ValorVenda = 4200.00m, QtdeEstoque = 8, Destaque = true},
        new Produto { Id = 3, CategoriaId = 1, Nome = "Geladeira Consul Duplex Frost Free", Descricao = "Geladeira duplex com tecnologia Frost Free e capacidade de 350 litros.", ValorCusto = 1500.00m, ValorVenda = 2500.00m, QtdeEstoque = 12, Destaque = true },
        new Produto { Id = 4, CategoriaId = 1, Nome = "Geladeira Electrolux Side by Side", Descricao = "Geladeira Side by Side com capacidade de 600 litros e sistema Smart Cooling.", ValorCusto = 3000.00m, ValorVenda = 4500.00m, QtdeEstoque = 6, Destaque = true },
        new Produto { Id = 5, CategoriaId = 1, Nome = "Geladeira LG Smart Inverter", Descricao = "Geladeira com tecnologia Smart Inverter e capacidade de 450 litros.", ValorCusto = 2000.00m, ValorVenda = 3500.00m, QtdeEstoque = 9 },

        // Ar Condicionados
        new Produto { Id = 6, CategoriaId = 2, Nome = "Ar Condicionado Split LG Dual Inverter", Descricao = "Ar condicionado Split com tecnologia Dual Inverter e capacidade de 12,000 BTU.", ValorCusto = 1600.00m, ValorVenda = 2600.00m, QtdeEstoque = 15 },
        new Produto { Id = 7, CategoriaId = 2, Nome = "Ar Condicionado Janela Consul Facilite", Descricao = "Ar condicionado de janela com capacidade de 7,500 BTU e controle manual.", ValorCusto = 800.00m, ValorVenda = 1300.00m, QtdeEstoque = 20, Destaque = true },
        new Produto { Id = 8, CategoriaId = 2, Nome = "Ar Condicionado Portátil Philco", Descricao = "Ar condicionado portátil com capacidade de 10,000 BTU e controle remoto.", ValorCusto = 1000.00m, ValorVenda = 1800.00m, QtdeEstoque = 10, Destaque = true },
        new Produto { Id = 9, CategoriaId = 2, Nome = "Ar Condicionado Split Samsung Digital Inverter", Descricao = "Ar condicionado Split com tecnologia Digital Inverter e capacidade de 18,000 BTU.", ValorCusto = 2200.00m, ValorVenda = 3200.00m, QtdeEstoque = 12, Destaque = true },
        new Produto { Id = 10, CategoriaId = 2, Nome = "Ar Condicionado Central Springer", Descricao = "Ar condicionado central com capacidade de 24,000 BTU e controle via app.", ValorCusto = 3500.00m, ValorVenda = 5000.00m, QtdeEstoque = 8 },
        };
        builder.Entity<Produto>().HasData(produtos);

        List<ProdutoFoto> produtoFotos = new List<ProdutoFoto>
        {
        // Produto 1
        new ProdutoFoto { Id = 1, ProdutoId = 1, ArquivoFoto = "/img/produtos/1/1.png" },
        new ProdutoFoto { Id = 2, ProdutoId = 1, ArquivoFoto = "/img/produtos/1/2.png" },
        new ProdutoFoto { Id = 3, ProdutoId = 1, ArquivoFoto = "/img/produtos/1/3.png" },

        // Produto 2
        new ProdutoFoto { Id = 4, ProdutoId = 2, ArquivoFoto = "/img/produtos/2/1.png" },
        new ProdutoFoto { Id = 5, ProdutoId = 2, ArquivoFoto = "/img/produtos/2/2.png" },
        new ProdutoFoto { Id = 6, ProdutoId = 2, ArquivoFoto = "/img/produtos/2/3.png" },

        // Produto 3
        new ProdutoFoto { Id = 7, ProdutoId = 3, ArquivoFoto = "/img/produtos/3/1.png" },
        new ProdutoFoto { Id = 8, ProdutoId = 3, ArquivoFoto = "/img/produtos/3/2.png" },
        new ProdutoFoto { Id = 9, ProdutoId = 3, ArquivoFoto = "/img/produtos/3/3.png" },

        // Produto 4
        new ProdutoFoto { Id = 10, ProdutoId = 4, ArquivoFoto = "/img/produtos/4/1.png" },
        new ProdutoFoto { Id = 11, ProdutoId = 4, ArquivoFoto = "/img/produtos/4/2.png" },
        new ProdutoFoto { Id = 12, ProdutoId = 4, ArquivoFoto = "/img/produtos/4/3.png" },

        // Produto 5
        new ProdutoFoto { Id = 13, ProdutoId = 5, ArquivoFoto = "/img/produtos/5/1.png" },
        new ProdutoFoto { Id = 14, ProdutoId = 5, ArquivoFoto = "/img/produtos/5/2.png" },
        new ProdutoFoto { Id = 15, ProdutoId = 5, ArquivoFoto = "/img/produtos/5/3.png" },

        // Produto 6
        new ProdutoFoto { Id = 16, ProdutoId = 6, ArquivoFoto = "/img/produtos/6/1.png" },
        new ProdutoFoto { Id = 17, ProdutoId = 6, ArquivoFoto = "/img/produtos/6/2.png" },
        new ProdutoFoto { Id = 18, ProdutoId = 6, ArquivoFoto = "/img/produtos/6/3.png" },

        // Produto 7
        new ProdutoFoto { Id = 19, ProdutoId = 7, ArquivoFoto = "/img/produtos/7/1.png" },
        new ProdutoFoto { Id = 20, ProdutoId = 7, ArquivoFoto = "/img/produtos/7/2.png" },

        // Produto 8
        new ProdutoFoto { Id = 21, ProdutoId = 8, ArquivoFoto = "/img/produtos/8/1.png" },
        new ProdutoFoto { Id = 22, ProdutoId = 8, ArquivoFoto = "/img/produtos/8/2.png" },
        new ProdutoFoto { Id = 23, ProdutoId = 8, ArquivoFoto = "/img/produtos/8/3.png" },

        // Produto 9
        new ProdutoFoto { Id = 24, ProdutoId = 9, ArquivoFoto = "/img/produtos/9/1.png" },
        new ProdutoFoto { Id = 25, ProdutoId = 9, ArquivoFoto = "/img/produtos/9/2.png" },
        new ProdutoFoto { Id = 26, ProdutoId = 9, ArquivoFoto = "/img/produtos/9/3.png" },

        // Produto 10
        new ProdutoFoto { Id = 27, ProdutoId = 10, ArquivoFoto = "/img/produtos/10/1.png" },
        new ProdutoFoto { Id = 28, ProdutoId = 10, ArquivoFoto = "/img/produtos/10/2.png" },
        new ProdutoFoto { Id = 29, ProdutoId = 10, ArquivoFoto = "/img/produtos/10/3.png" },

        };
        builder.Entity<ProdutoFoto>().HasData(produtoFotos);


        #region Populate Roles - Perfis de Usuário
        List<IdentityRole> roles = new()
        {
            new IdentityRole() {
               Id = "0b44ca04-f6b0-4a8f-a953-1f2330d30894",
               Name = "Administrador",
               NormalizedName = "ADMINISTRADOR"
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
                Email = "admin@gmail.com",
                NormalizedEmail = "ADMIN@GMAIL.COM",
                UserName = "Admin",
                NormalizedUserName = "ADMIN",
                LockoutEnabled = true,
                EmailConfirmed = true,
                Nome = "Admin",
                DataNascimento = DateTime.Parse("20/07/2002"),
                Foto = "/img/usuarios/Galingo.png"
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