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
            new Categoria { Id = 1, Nome = "Ar-Condicionado" },
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
            new Produto { Id = 15, CategoriaId = 5, Nome = "Cortina de ar (90-150 CM)"},
            new Produto { Id = 16, CategoriaId = 5, Nome = "Cortina de ar (180-200 CM)"},
            new Produto { Id = 17, CategoriaId = 5, Nome = "Cortina de ar (250 CM)"},

            // Bebedouro
            new Produto { Id = 18, CategoriaId = 6, Nome = "Bebedouro (5–10 L)"},
            new Produto { Id = 19, CategoriaId = 6, Nome = "Bebedouro (20–30 L)"},
            new Produto { Id = 20, CategoriaId = 6, Nome = "Bebedouro (50+ L)"},
        };
        builder.Entity<Produto>().HasData(produtos);

        List<ProdutoFoto> produtoFotos = new List<ProdutoFoto>
        {
            // Ar (5 produtos)
            new ProdutoFoto { Id = 1, ProdutoId = 1, ArquivoFoto = "/img/produtos/AR/1.png" },
            new ProdutoFoto { Id = 2, ProdutoId = 2, ArquivoFoto = "/img/produtos/AR/2.png" },
            new ProdutoFoto { Id = 3, ProdutoId = 3, ArquivoFoto = "/img/produtos/AR/3.png" },
            new ProdutoFoto { Id = 4, ProdutoId = 4, ArquivoFoto = "/img/produtos/AR/4.png" },
            new ProdutoFoto { Id = 5, ProdutoId = 5, ArquivoFoto = "/img/produtos/AR/5.png" },

            // Lavadoura (4 produtos )
            new ProdutoFoto { Id = 6, ProdutoId = 6, ArquivoFoto = "/img/produtos/Lavadoura/1.png" },
            new ProdutoFoto { Id = 7, ProdutoId = 7, ArquivoFoto = "/img/produtos/Lavadoura/2.png" },
            new ProdutoFoto { Id = 8, ProdutoId = 8, ArquivoFoto = "/img/produtos/Lavadoura/3.png" },
            new ProdutoFoto { Id = 9, ProdutoId = 9, ArquivoFoto = "/img/produtos/Lavadoura/4.png" },

            // Geladeira (3 produtos)
            new ProdutoFoto { Id = 10, ProdutoId = 10, ArquivoFoto = "/img/produtos/Geladeira/1.png" },
            new ProdutoFoto { Id = 11, ProdutoId = 11, ArquivoFoto = "/img/produtos/Geladeira/2.png" },
            new ProdutoFoto { Id = 12, ProdutoId = 12, ArquivoFoto = "/img/produtos/Geladeira/3.png" },

            // Freezer (2 produtos)
            new ProdutoFoto { Id = 13, ProdutoId = 13, ArquivoFoto = "/img/produtos/Freezer/1.png" },
            new ProdutoFoto { Id = 14, ProdutoId = 14, ArquivoFoto = "/img/produtos/Freezer/2.png" },

            // Cortina (4 produtos )
            new ProdutoFoto { Id = 15, ProdutoId = 15, ArquivoFoto = "/img/produtos/Cortina/1.png" },
            new ProdutoFoto { Id = 16, ProdutoId = 16, ArquivoFoto = "/img/produtos/Cortina/2.png" },
            new ProdutoFoto { Id = 17, ProdutoId = 17, ArquivoFoto = "/img/produtos/Cortina/3.png" },

            // Bebedouro (3 produtos )
            new ProdutoFoto { Id = 18, ProdutoId = 18, ArquivoFoto = "/img/produtos/Cortina/4.png" },
            new ProdutoFoto { Id = 19, ProdutoId = 19, ArquivoFoto = "/img/produtos/Bebedouro/1.png" },
            new ProdutoFoto { Id = 20, ProdutoId = 20, ArquivoFoto = "/img/produtos/Bebedouro/2.png" },
        };
        builder.Entity<ProdutoFoto>().HasData(produtoFotos);

        List<Servico> servicos = new List<Servico>
         {
            // Ar-Condicionado
            new Servico {Id = 1, Nome = "Instalação Normal", Preco = 450, CategoriaId = 1 },
            new Servico {Id = 2, Nome = "Instalação Padrão", Preco = 650, CategoriaId = 1},
            new Servico {Id = 3, Nome = "Higienização", Preco = 150, CategoriaId = 1},
            new Servico {Id = 4, Nome = "Manutenção", Preco = 100, CategoriaId = 1},

            // Lavadoura
<<<<<<< HEAD
            new Servico {Id = 5, Nome = "Higienização", Preco = 150, CategoriaId = 2 },
            new Servico {Id = 6, Nome = "Manutenção", Preco = 100, CategoriaId = 2 },

            //Geladeira
            new Servico {Id = 7, Nome = "Manutenção", Preco = 100, CategoriaId = 3 },
            
            //Freezer
            new Servico {Id = 8, Nome = "Manutenção", Preco = 100, CategoriaId = 4 },
            
            //Cortina
            new Servico {Id = 9, Nome = "Instalação", Preco = 200, CategoriaId = 5 },
            new Servico {Id = 10, Nome = "Higienização", Preco = 150, CategoriaId = 5 },
            new Servico {Id = 11, Nome = "Manutenção", Preco = 100, CategoriaId = 5 },
            
            // Bebedouro
            new Servico {Id = 12, Nome = "Higienização", Preco = 100, CategoriaId = 6 },
            new Servico {Id = 13, Nome = "Manutenção", Preco = 100, CategoriaId = 6 },
=======
            new Servico {Id = 1, Nome = "Instalação Normal", Preco = 450, CategoriaId = 2 },
            new Servico {Id = 2, Nome = "Instalação Padrão", Preco = 650, CategoriaId = 2 },
            new Servico {Id = 3, Nome = "Higienização", Preco = 150, CategoriaId = 2 },
            new Servico {Id = 4, Nome = "Manutenção", Preco = 100, CategoriaId = 2 },

            //Geladeira
            new Servico {Id = 1, Nome = "Instalação Normal", Preco = 450, CategoriaId = 3 },
            new Servico {Id = 2, Nome = "Instalação Padrão", Preco = 650, CategoriaId = 3},
            new Servico {Id = 3, Nome = "Higienização", Preco = 150, CategoriaId = 3 },
            new Servico {Id = 4, Nome = "Manutenção", Preco = 100, CategoriaId = 3 },
            
            //Freezer
            new Servico {Id = 1, Nome = "Instalação Normal", Preco = 450, CategoriaId = 4 },
            new Servico {Id = 2, Nome = "Instalação Padrão", Preco = 650, CategoriaId = 4 },
            new Servico {Id = 3, Nome = "Higienização", Preco = 150, CategoriaId = 4 },
            new Servico {Id = 4, Nome = "Manutenção", Preco = 100, CategoriaId = 4 },
            
            //Cortina
            new Servico {Id = 1, Nome = "Instalação Normal", Preco = 450, CategoriaId = 5 },
            new Servico {Id = 2, Nome = "Instalação Padrão", Preco = 650, CategoriaId = 5},
            new Servico {Id = 3, Nome = "Higienização", Preco = 150, CategoriaId = 5 },
            new Servico {Id = 4, Nome = "Manutenção", Preco = 100, CategoriaId = 5 },
            
            // Bebedouro
            new Servico {Id = 1, Nome = "Instalação Normal", Preco = 450, CategoriaId = 6 },
            new Servico {Id = 2, Nome = "Instalação Padrão", Preco = 650, CategoriaId = 6 },
            new Servico {Id = 3, Nome = "Higienização", Preco = 150, CategoriaId = 6 },
            new Servico {Id = 4, Nome = "Manutenção", Preco = 100, CategoriaId = 6 },
>>>>>>> 184b39e3560d142e6f5259bc74be1a665c771641
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