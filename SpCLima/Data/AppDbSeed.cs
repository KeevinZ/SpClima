using SpClima.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace SpClima.Data;

public class AppDbSeed
{
    public AppDbSeed(ModelBuilder builder)
    {
        // 1. Seed das Categorias (mantido igual)
        List<ItemCategoria> categorias = new()
        {
            new ItemCategoria { Id = 1, Nome = "ArCondicionado" },
            new ItemCategoria { Id = 2, Nome = "CortinaAr" },
            new ItemCategoria { Id = 3, Nome = "Lavadora" },
            new ItemCategoria { Id = 4, Nome = "Geladeira" },
            new ItemCategoria { Id = 5, Nome = "Bebedouro" },
            new ItemCategoria { Id = 6, Nome = "Freezer" }
        };
        builder.Entity<ItemCategoria>().HasData(categorias);

        // 2. Seed dos Itens (REMOVENDO PrecoBase)
        List<Item> items = new() {
            new Item { 
                Id = 1, 
                Titulo = "Instalação de Ar‑Condicionado",
                Descricao = "Instalação padrão com 3 metros de cobre, para manter a garantia da máquina",
                Destaque = true,
                ItemCategoriaId = 1,
                ImagemUrl = "/img/produtos/AR/2.jpg" 
            },
            new Item { 
                Id = 2, 
                Titulo = "Limpeza de Ar‑Condicionado",
                Descricao = "Higienização interna e externa para melhor eficiencia",
                Destaque = false,
                ItemCategoriaId = 1,
                ImagemUrl = "/img/produtos/AR/3.jpg" 
            },
            new Item { 
                Id = 3, 
                Titulo = "Manutenção de Ar‑Condicionado",
                Descricao = "Verificação de gás e revisão completa para garantir o bom funcionamento do ar-condicionado.",
                Destaque = false,
                ItemCategoriaId = 1,
                ImagemUrl = "/img/produtos/AR/1.jpg" 
            },
            new Item { 
                Id = 4, 
                Titulo = "Instalação de Cortina de Ar",
                Descricao = "Fixação e teste de cortina de ar institucional",
                Destaque = true,
                ItemCategoriaId = 2,
                ImagemUrl = "/img/produtos/Cortina/1.jpg" 
            },
            new Item { 
                Id = 5, 
                Titulo = "Limpeza de Cortina de Ar",
                Descricao = "Limpeza completa de filtros e pás",
                Destaque = false,
                ItemCategoriaId = 2,
                ImagemUrl = "/img/produtos/Cortina/2.jpg" 
            },
            new Item { 
                Id = 6, 
                Titulo = "Limpeza de Lavadoura", 
                Descricao = "Higienização interna da Lavadoura, para melhor limpeza de roupas",
                Destaque = true, 
                ItemCategoriaId = 3,
                ImagemUrl = "/img/produtos/Lavadoura/1.jpg" 
            },
            new Item { 
                Id = 7, 
                Titulo = "Manutenção de Lavadoura", 
                Descricao = "Troca de peça se necessario",
                Destaque = false, 
                ItemCategoriaId = 3,
                ImagemUrl = "/img/produtos/Lavadoura/3.jpg" 
            },
            new Item { 
                Id = 8, 
                Titulo = "Manutenção de Geladeira", 
                Descricao = "Manutenção preventiva e corretiva com limpeza, verificação de gás e desempenho do motor.",
                Destaque = true, 
                ItemCategoriaId = 4,
                ImagemUrl = "/img/produtos/Geladeira/1.jpg" 
            },
            new Item { 
                Id = 9, 
                Titulo = "Manutenção de Bebedouro", 
                Descricao = "Revisão e limpeza para garantir o bom funcionamento do bebedouro.",
                Destaque = true, 
                ItemCategoriaId = 5,
                ImagemUrl = "/img/produtos/Bebedouro/1.jpg" 
            },
            new Item { 
                Id = 10, 
                Titulo = "Instalação de Bebedouro", 
                Descricao = "Instale seu bebedouro com praticidade e segurança! Fazemos a fixação, conexão à rede de água e ajustes finais para garantir o funcionamento perfeito.",
                Destaque = false, 
                ItemCategoriaId = 5,
                ImagemUrl = "/img/produtos/Bebedouro/3.jpg" 
            },
            new Item { 
                Id = 11, 
                Titulo = "Manutenção de Freezer", 
                Descricao = "Manutenção e limpeza completa do freezer para garantir desempenho ideal e prevenir falhas.",
                Destaque = true, 
                ItemCategoriaId = 6,
                ImagemUrl = "/img/produtos/Freezer/1.jpg" 
            },
        };
        builder.Entity<Item>().HasData(items);

        // 3. Seed das Variações (ATUALIZADO)
        List<ItemVariacao> variacoes = new(){
            // Itens com múltiplas variações
            new ItemVariacao { Id =  1, ItemId = 1, Nome = "9 000 BTU",  Preco = 650.00M },
            new ItemVariacao { Id =  2, ItemId = 1, Nome = "12 000 BTU", Preco = 750.00M },
            new ItemVariacao { Id =  3, ItemId = 1, Nome = "18 000 BTU", Preco = 880.00M },

            new ItemVariacao { Id =  4, ItemId = 2, Nome = "9 000 BTU",  Preco = 150.00M },
            new ItemVariacao { Id =  5, ItemId = 2, Nome = "12 000 BTU", Preco = 200.00M },
            new ItemVariacao { Id =  6, ItemId = 2, Nome = "18 000 BTU", Preco = 250.00M },

            new ItemVariacao { Id =  7, ItemId = 4, Nome = "90–150 cm",  Preco = 200.00M },
            new ItemVariacao { Id =  8, ItemId = 4, Nome = "180–200 cm", Preco = 250.00M },
            new ItemVariacao { Id =  9, ItemId = 4, Nome = "250 cm",     Preco = 300.00M },

            new ItemVariacao { Id = 10, ItemId = 5, Nome = "90–150 cm",  Preco = 120.00M },
            new ItemVariacao { Id = 11, ItemId = 5, Nome = "180–200 cm", Preco = 140.00M },
            new ItemVariacao { Id = 12, ItemId = 5, Nome = "250 cm",     Preco = 170.00M },

            // Itens com UMA variação padrão
            new ItemVariacao { Id = 13, ItemId = 3,  Nome = "Padrão", Preco = 300.00M }, // Manutenção Ar
            new ItemVariacao { Id = 14, ItemId = 6,  Nome = "Padrão", Preco = 200.00M }, // Limpeza Lavadora
            new ItemVariacao { Id = 15, ItemId = 7,  Nome = "Padrão", Preco = 200.00M }, // Manutenção Lavadora
            new ItemVariacao { Id = 16, ItemId = 8,  Nome = "Padrão", Preco = 100.00M }, // Manutenção Geladeira
            new ItemVariacao { Id = 17, ItemId = 9,  Nome = "Padrão", Preco = 200.00M }, // Manutenção Bebedouro
            new ItemVariacao { Id = 18, ItemId = 10, Nome = "Padrão", Preco = 200.00M }, // Instalação Bebedouro
            new ItemVariacao { Id = 19, ItemId = 11, Nome = "Padrão", Preco = 200.00M }  // Manutenção Freezer
        };
        builder.Entity<ItemVariacao>().HasData(variacoes);

        // ... (restante do código permanece igual) ...
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
        };
        builder.Entity<IdentityUserRole<string>>().HasData(userRoles);
        #endregion
    }
}