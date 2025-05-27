// Controllers/AccountController.cs
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SpClima.Models;
using SpClima.ViewModels; 

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

    // Só POST, não precisamos de GET
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Login(LoginVM vm)
    {
        if (!ModelState.IsValid)
            return PartialView("_LoginModal", vm);

        var result = await _signIn.PasswordSignInAsync(vm.Username, vm.Password, false, lockoutOnFailure: true);
        if (result.Succeeded)
        {
            var user = await _users.FindByNameAsync(vm.Username);
            if (await _users.IsInRoleAsync(user, "Administrador"))
            {
                // Se ReturnUrl for nulo ou vazio, vai para /Admin/Index
                var dest = string.IsNullOrEmpty(vm.ReturnUrl) 
                           ? Url.Action("Index","Admin") 
                           : vm.ReturnUrl;
                return LocalRedirect(dest);
            }
            await _signIn.SignOutAsync();
            ModelState.AddModelError("", "Você não tem permissão de administrador.");
        }
        else
        {
            ModelState.AddModelError("", "Usuário ou senha inválidos.");
        }

        return PartialView("_LoginModal", vm);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Logout()
    {
        await _signIn.SignOutAsync();
        return RedirectToAction("Index","Home");
    }
}
