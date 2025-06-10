using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SpClima.Models;
using SpClima.ViewModels;

namespace SpClima.Controllers;

[AllowAnonymous]
public class AccountController : Controller
{
    private readonly SignInManager<Usuario> _signIn;
    private readonly UserManager<Usuario> _users;

    public AccountController(
        SignInManager<Usuario> signInManager,
        UserManager<Usuario> userManager)
    {
        _signIn = signInManager;
        _users = userManager;
    }
    
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Login(LoginVM vm)
    {
        // Se o modelo for inválido, retorna um JSON de erro.
        if (!ModelState.IsValid)
        {
            // Pega a primeira mensagem de erro para exibir ao usuário.
            var erro = ModelState.Values.SelectMany(v => v.Errors).FirstOrDefault();
            return Json(new { success = false, message = erro?.ErrorMessage ?? "Dados inválidos." });
        }

        var result = await _signIn.PasswordSignInAsync(vm.Username, vm.Password, false, lockoutOnFailure: true);
        if (result.Succeeded)
        {
            var user = await _users.FindByNameAsync(vm.Username);
            if (await _users.IsInRoleAsync(user, "Administrador"))
            {
                // SUCESSO! Retorna um JSON com a URL de redirecionamento.
                var dest = string.IsNullOrEmpty(vm.ReturnUrl)
                                ? Url.Action("Index", "Admin") // Garanta que este Controller/Action exista
                                : vm.ReturnUrl;
                return Json(new { success = true, redirectUrl = dest });
            }

            // Se o usuário logou mas não é admin, desloga e retorna erro.
            await _signIn.SignOutAsync();
            return Json(new { success = false, message = "Você não tem permissão de administrador." });
        }
        else
        {
            // Se o login falhou (usuário/senha errados, conta bloqueada, etc.).
            return Json(new { success = false, message = "Usuário ou senha inválidos." });
        }
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Logout()
    {
        await _signIn.SignOutAsync();
        return RedirectToAction("Index", "Home");
    }
}