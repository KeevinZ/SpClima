using SpClima.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace SpClima.Data;

public class AppDbSeed
{
    public AppDbSeed(ModelBuilder builder)
    {
        List<Item> items = new() {
        new Item { Id = 1, Titulo = "Instalação de Ar‑Condicionado", 
                    Descricao = "Instalação completa (unidade interna + externa)",
                    Destaque = true ,
                    Tipo = ItemType.ArCondicionado, 
                    ImagemUrl = "/img/itens/instalacao-ac.jpg" },

            new Item { Id = 2, Titulo = "Limpeza de Ar‑Condicionado", 
                    Descricao = "Higienização interna com filtro anti‑mofo",
                    Destaque = true , 
                    Tipo = ItemType.ArCondicionado, 
                    ImagemUrl = "/img/itens/limpeza-ac.jpg" },

            new Item { Id = 3, Titulo = "Instalação de Cortina de Ar", 
                    Descricao = "Fixação e teste de cortina de ar institucional", 
                    Destaque = true ,
                    Tipo = ItemType.CortinaAr, 
                    ImagemUrl = "/img/itens/instalacao-cortina.jpg" },

            new Item { Id = 4, Titulo = "Limpeza de Cortina de Ar", 
                    Descricao = "Limpeza completa de filtros e pás",
                    Destaque = true , 
                    Tipo = ItemType.CortinaAr, 
                    ImagemUrl = "/img/itens/limpeza-cortina.jpg" }
        };
        builder.Entity<Item>().HasData(items);

       
        List<ItemVariacao> itemVariacaos = new(){
            
            // Variações para Item 1 (Instalação AC)
            new ItemVariacao { Id =  1, ItemId = 1, Nome = "9 000 BTU",  Preco = 250.00M },
            new ItemVariacao { Id =  2, ItemId = 1, Nome = "12 000 BTU", Preco = 230.00M },
            new ItemVariacao { Id =  3, ItemId = 1, Nome = "18 000 BTU", Preco = 280.00M },

            // Variações para Item 2 (Limpeza AC)
            new ItemVariacao { Id =  4, ItemId = 2, Nome = "9 000 BTU",  Preco = 100.00M },
            new ItemVariacao { Id =  5, ItemId = 2, Nome = "12 000 BTU", Preco = 120.00M },
            new ItemVariacao { Id =  6, ItemId = 2, Nome = "18 000 BTU", Preco = 150.00M },

            // Variações para Item 3 (Instalação Cortina)
            new ItemVariacao { Id =  7, ItemId = 3, Nome = "90–150 cm",  Preco = 200.00M },
            new ItemVariacao { Id =  8, ItemId = 3, Nome = "180–200 cm", Preco = 250.00M },
            new ItemVariacao { Id =  9, ItemId = 3, Nome = "250 cm",     Preco = 300.00M },

            // Variações para Item 4 (Limpeza Cortina)
            new ItemVariacao { Id = 10, ItemId = 4, Nome = "90–150 cm",  Preco = 120.00M },
            new ItemVariacao { Id = 11, ItemId = 4, Nome = "180–200 cm", Preco = 140.00M },
            new ItemVariacao { Id = 12, ItemId = 4, Nome = "250 cm",     Preco = 170.00M }
        };
        builder.Entity<ItemVariacao>().HasData(itemVariacaos); 


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