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
            new Produto { Id = 7, CategoriaId = 2, Nome = "Maquina Média (10-12 kg)"},
            new Produto { Id = 8, CategoriaId = 2, Nome = "Maquina Grande (13-16 kg)"},
            new Produto { Id = 9, CategoriaId = 2, Nome = "Maquina Extra Grande (17-20 kg)"},

            // Geladeira
            new Produto { Id = 10, CategoriaId = 3, Nome = "Geladeira 1 Porta" },
            new Produto { Id = 11, CategoriaId = 3, Nome = "Geladeira Duplex"},
            new Produto { Id = 12, CategoriaId = 3, Nome = "Geladeira Side by Side"},

            // Freezer
            new Produto { Id = 13, CategoriaId = 4, Nome = "Freezer (100-300 L)"},
            new Produto { Id = 14, CategoriaId = 4, Nome = "Freezer (400-600 L)"},

            // Cortina
            new Produto { Id = 15, CategoriaId = 5, Nome = "Cortina de ar (90-100 CM)"},
            new Produto { Id = 16, CategoriaId = 5, Nome = "Cortina de ar (120-150 CM)"},
            new Produto { Id = 17, CategoriaId = 5, Nome = "Cortina de ar (180-200 CM)"},
            new Produto { Id = 18, CategoriaId = 5, Nome = "Cortina de ar (250 CM)"},

            // Bebedouro
            new Produto { Id = 19, CategoriaId = 6, Nome = "Bebedouro (5–10 L)"},
            new Produto { Id = 20, CategoriaId = 6, Nome = "Bebedouro (20–30 L)"},
            new Produto { Id = 21, CategoriaId = 6, Nome = "Bebedouro (50+ L)"},
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

            // Produto 7
            new ProdutoFoto { Id = 10, ProdutoId = 7, ArquivoFoto = "/img/produtos/7/1.png" },
            new ProdutoFoto { Id = 11, ProdutoId = 7, ArquivoFoto = "/img/produtos/7/2.png" },
            new ProdutoFoto { Id = 12, ProdutoId = 7, ArquivoFoto = "/img/produtos/7/3.png" },

            // Produto 8
            new ProdutoFoto { Id = 13, ProdutoId = 8, ArquivoFoto = "/img/produtos/8/1.png" },
            new ProdutoFoto { Id = 14, ProdutoId = 8, ArquivoFoto = "/img/produtos/8/2.png" },
            new ProdutoFoto { Id = 15, ProdutoId = 8, ArquivoFoto = "/img/produtos/8/3.png" },

            // Produto 11
            new ProdutoFoto { Id = 16, ProdutoId = 11, ArquivoFoto = "/img/produtos/11/1.png" },
            new ProdutoFoto { Id = 17, ProdutoId = 11, ArquivoFoto = "/img/produtos/11/2.png" },
            new ProdutoFoto { Id = 18, ProdutoId = 11, ArquivoFoto = "/img/produtos/11/3.png" },

            // Produto 14
            new ProdutoFoto { Id = 19, ProdutoId = 14, ArquivoFoto = "/img/produtos/14/1.png" },
            new ProdutoFoto { Id = 20, ProdutoId = 14, ArquivoFoto = "/img/produtos/14/2.png" },

            // Produto 15
            new ProdutoFoto { Id = 21, ProdutoId = 15, ArquivoFoto = "/img/produtos/15/1.png" },
            new ProdutoFoto { Id = 22, ProdutoId = 15, ArquivoFoto = "/img/produtos/15/2.png" },
            new ProdutoFoto { Id = 23, ProdutoId = 15, ArquivoFoto = "/img/produtos/15/3.png" },

            // Produto 16
            new ProdutoFoto { Id = 24, ProdutoId = 16, ArquivoFoto = "/img/produtos/16/1.png" },
            new ProdutoFoto { Id = 25, ProdutoId = 16, ArquivoFoto = "/img/produtos/16/2.png" },
            new ProdutoFoto { Id = 26, ProdutoId = 16, ArquivoFoto = "/img/produtos/16/3.png" },

            // Produto 19
            new ProdutoFoto { Id = 27, ProdutoId = 19, ArquivoFoto = "/img/produtos/19/1.png" },
            new ProdutoFoto { Id = 28, ProdutoId = 19, ArquivoFoto = "/img/produtos/19/2.png" },
            new ProdutoFoto { Id = 29, ProdutoId = 19, ArquivoFoto = "/img/produtos/19/3.png" },

            // Produto 20
            new ProdutoFoto { Id = 30, ProdutoId = 20, ArquivoFoto = "/img/produtos/20/1.png" },
            new ProdutoFoto { Id = 31, ProdutoId = 20, ArquivoFoto = "/img/produtos/20/2.png" },
            new ProdutoFoto { Id = 32, ProdutoId = 20, ArquivoFoto = "/img/produtos/20/3.png" },
        };
        builder.Entity<ProdutoFoto>().HasData(produtoFotos);

         List<Servico> servicos = new List<Servico>
         {
        new Servico {Id = 1, Nome = "Instalação Normal", Preco = 450 },
        new Servico {Id = 1, Nome = "Instalação Padrão", Preco = 650 },
        new Servico {Id = 1, Nome = "Higienização", Preco = 150 },
        new Servico {Id = 1, Nome = "Manutenção", Preco = 100 },
         };
         builder.Entity<Servico>().HasData(servicos);


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