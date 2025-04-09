using SpClima.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using SpCLima.Models;

namespace SpClima.Data;

public class AppDbSeed
{
    public AppDbSeed(ModelBuilder builder)
    {
        List<Categoria> categorias = new() {
            new Categoria { Id = 1, Nome = "AR" },
            new Categoria { Id = 2, Nome = "Lavadoura" },
            new Categoria { Id = 3, Nome = "Geladeira" },
            new Categoria { Id = 4, Nome = "Freezer" },
            new Categoria { Id = 5, Nome = "Cortina de Ar" },
            new Categoria { Id = 6, Nome = "Bebedouro" },
        };
        builder.Entity<Categoria>().HasData(categorias);

        List<Produto> produtos = new List<Produto>
        {
            // AR
            new Produto { Id = 1, CategoriaId = 1, Nome = "Ar-Condicionado LG", BTU = 9000},
            new Produto { Id = 2, CategoriaId = 1, Nome = "Ar-Condicionado Elgin", BTU = 9000},
            new Produto { Id = 3, CategoriaId = 1, Nome = "Ar-Condicionado Samsung", BTU = 9000},
            new Produto { Id = 4, CategoriaId = 1, Nome = "Ar-Condicionado Carrier", BTU = 9000},
            new Produto { Id = 5, CategoriaId = 1, Nome = "Ar-Condicionado Philco", BTU = 9000},
            

            // Lavadoura
            new Produto { Id = 6, CategoriaId = 2, Nome = "Maquina Pequena (8-9 KG)" },
            new Produto { Id = 7, CategoriaId = 2, Nome = "Maquina Médias (10-12 kg)"},
            new Produto { Id = 8, CategoriaId = 2, Nome = "Maquina Grandes (13-16 kg)"},
            new Produto { Id = 9, CategoriaId = 2, Nome = "Maquina Extra Grandes (17-20 kg)"},

            // Geladeira
            new Produto { Id = 6, CategoriaId = 2, Nome = "Geladeira Pequena (8-9 KG)" },
            new Produto { Id = 7, CategoriaId = 2, Nome = "Geladeira Médias (10-12 kg)"},
            new Produto { Id = 8, CategoriaId = 2, Nome = "Geladeira Grandes (13-16 kg)"},

            // Freezer
            new Produto { Id = 16, CategoriaId = 4, Nome = "AirPods Pro", Descricao = "Cancelamento de Ruído Ativo", ValorCusto = 900.00m, ValorVenda = 1499.00m, QtdeEstoque = 12, Destaque = true },
            new Produto { Id = 17, CategoriaId = 4, Nome = "Sony WH-1000XM5", Descricao = "Over-ear, Noise Cancelling", ValorCusto = 1400.00m, ValorVenda = 2199.00m, QtdeEstoque = 10 },
            new Produto { Id = 18, CategoriaId = 4, Nome = "JBL Live 660NC", Descricao = "Fone Bluetooth, Graves Potentes", ValorCusto = 600.00m, ValorVenda = 999.00m, QtdeEstoque = 20 },
            new Produto { Id = 19, CategoriaId = 4, Nome = "Beats Studio Buds", Descricao = "Fones In-Ear, Bluetooth", ValorCusto = 800.00m, ValorVenda = 1299.00m, QtdeEstoque = 15 },
            new Produto { Id = 20, CategoriaId = 4, Nome = "Razer Kraken X", Descricao = "Headset Gamer, Surround 7.1", ValorCusto = 400.00m, ValorVenda = 699.00m, QtdeEstoque = 25 },

            // Cortina
            new Produto { Id = 21, CategoriaId = 5, Nome = "LG Ultragear 27\"", Descricao = "IPS, 144Hz, 1ms", ValorCusto = 1200.00m, ValorVenda = 1899.00m, QtdeEstoque = 8, Destaque = true },
            new Produto { Id = 22, CategoriaId = 5, Nome = "Samsung Odyssey G5", Descricao = "Curvo, 165Hz, 2K", ValorCusto = 1400.00m, ValorVenda = 2399.00m, QtdeEstoque = 10 },
            new Produto { Id = 23, CategoriaId = 5, Nome = "AOC Hero 24\"", Descricao = "IPS, 144Hz, FreeSync", ValorCusto = 900.00m, ValorVenda = 1499.00m, QtdeEstoque = 15 },
            new Produto { Id = 24, CategoriaId = 5, Nome = "Dell P2723QE", Descricao = "4K UHD, 60Hz, USB-C", ValorCusto = 2000.00m, ValorVenda = 3299.00m, QtdeEstoque = 5 },
            new Produto { Id = 25, CategoriaId = 5, Nome = "BenQ Zowie XL2546", Descricao = "240Hz, 1ms, eSports", ValorCusto = 2500.00m, ValorVenda = 3999.00m, QtdeEstoque = 6 },

            // Bebedouro
            new Produto { Id = 26, CategoriaId = 6, Nome = "Logitech G Pro X", Descricao = "Teclado Mecânico, RGB", ValorCusto = 700.00m, ValorVenda = 1099.00m, QtdeEstoque = 20, Destaque = true },
            new Produto { Id = 27, CategoriaId = 6, Nome = "Razer Huntsman Mini", Descricao = "Teclado Óptico, 60%", ValorCusto = 800.00m, ValorVenda = 1299.00m, QtdeEstoque = 12 },
            new Produto { Id = 28, CategoriaId = 6, Nome = "HyperX Alloy FPS", Descricao = "Teclado Mecânico, Red Switch", ValorCusto = 600.00m, ValorVenda = 999.00m, QtdeEstoque = 18 },
            new Produto { Id = 29, CategoriaId = 6, Nome = "Logitech G502 Hero", Descricao = "Mouse Gamer, 16K DPI", ValorCusto = 300.00m, ValorVenda = 599.00m, QtdeEstoque = 25 },
            new Produto { Id = 30, CategoriaId = 6, Nome = "Razer DeathAdder V2", Descricao = "Mouse Ergonômico, 20K DPI", ValorCusto = 400.00m, ValorVenda = 699.00m, QtdeEstoque = 20 },
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

            // Produto 6
            new ProdutoFoto { Id = 7, ProdutoId = 6, ArquivoFoto = "/img/produtos/6/1.png" },
            new ProdutoFoto { Id = 8, ProdutoId = 6, ArquivoFoto = "/img/produtos/6/2.png" },
            new ProdutoFoto { Id = 9, ProdutoId = 6, ArquivoFoto = "/img/produtos/6/3.png" },

            // Produto 11
            new ProdutoFoto { Id = 10, ProdutoId = 11, ArquivoFoto = "/img/produtos/11/1.png" },
            new ProdutoFoto { Id = 11, ProdutoId = 11, ArquivoFoto = "/img/produtos/11/2.png" },
            new ProdutoFoto { Id = 12, ProdutoId = 11, ArquivoFoto = "/img/produtos/11/3.png" },

            // Produto 16
            new ProdutoFoto { Id = 13, ProdutoId = 16, ArquivoFoto = "/img/produtos/16/1.png" },
            new ProdutoFoto { Id = 14, ProdutoId = 16, ArquivoFoto = "/img/produtos/16/2.png" },
            new ProdutoFoto { Id = 15, ProdutoId = 16, ArquivoFoto = "/img/produtos/16/3.png" },

            // Produto 21
            new ProdutoFoto { Id = 16, ProdutoId = 21, ArquivoFoto = "/img/produtos/21/1.png" },
            new ProdutoFoto { Id = 17, ProdutoId = 21, ArquivoFoto = "/img/produtos/21/2.png" },
            new ProdutoFoto { Id = 18, ProdutoId = 21, ArquivoFoto = "/img/produtos/21/3.png" },

            // Produto 26
            new ProdutoFoto { Id = 19, ProdutoId = 26, ArquivoFoto = "/img/produtos/26/1.png" },
            new ProdutoFoto { Id = 20, ProdutoId = 26, ArquivoFoto = "/img/produtos/26/2.png" },

            // Produto 31
            new ProdutoFoto { Id = 21, ProdutoId = 31, ArquivoFoto = "/img/produtos/31/1.png" },
            new ProdutoFoto { Id = 22, ProdutoId = 31, ArquivoFoto = "/img/produtos/31/2.png" },
            new ProdutoFoto { Id = 23, ProdutoId = 31, ArquivoFoto = "/img/produtos/31/3.png" },

            // Produto 36
            new ProdutoFoto { Id = 24, ProdutoId = 36, ArquivoFoto = "/img/produtos/36/1.png" },
            new ProdutoFoto { Id = 25, ProdutoId = 36, ArquivoFoto = "/img/produtos/36/2.png" },
            new ProdutoFoto { Id = 26, ProdutoId = 36, ArquivoFoto = "/img/produtos/36/3.png" },

            // Produto 41
            new ProdutoFoto { Id = 27, ProdutoId = 41, ArquivoFoto = "/img/produtos/41/1.png" },
            new ProdutoFoto { Id = 28, ProdutoId = 41, ArquivoFoto = "/img/produtos/41/2.png" },
            new ProdutoFoto { Id = 29, ProdutoId = 41, ArquivoFoto = "/img/produtos/41/3.png" },

            // Produto 46
            new ProdutoFoto { Id = 30, ProdutoId = 46, ArquivoFoto = "/img/produtos/46/1.png" },
            new ProdutoFoto { Id = 31, ProdutoId = 46, ArquivoFoto = "/img/produtos/46/2.png" },
            new ProdutoFoto { Id = 32, ProdutoId = 46, ArquivoFoto = "/img/produtos/46/3.png" },
        };
        builder.Entity<ProdutoFoto>().HasData(produtoFotos);

         List<Servico> servicos = new List<Servico>
         {
        new Servico {Id = 1, Nome = "Instalação Padrão  ", Preco = }



         };


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
                Email = "maximocaua13@gmail.com",
                NormalizedEmail = "MAXIMOCAUA13@GMAIL.COM",
                UserName = "ManoGabs",
                NormalizedUserName = "MANOGABS",
                LockoutEnabled = true,
                EmailConfirmed = true,
                Nome = "Gabis Junior Junior",
                DataNascimento = DateTime.Parse("13/09/2007"),
                Foto = "/img/usuarios/no-photo.png"
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