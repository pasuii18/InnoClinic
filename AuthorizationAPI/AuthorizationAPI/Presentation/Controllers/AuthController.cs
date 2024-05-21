using Domain.Interfaces;
using Domain.Models;
using IdentityServer4.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Presentation.Controllers;

public class AuthController(
    IAuthService _authService)
    : Controller
{
    
    [HttpGet]
    public IActionResult Login(string returnUrl)
    {
        return View(new LoginViewModel { ReturnUrl = returnUrl });
    }
    
    [HttpPost]
    public async Task<IActionResult> Login(LoginViewModel vm)
    {
        if (!ModelState.IsValid) return View(vm);

        if (await _authService.SignInAsync(vm)) return Redirect(vm.ReturnUrl);
        
        ModelState.AddModelError(string.Empty, "Login Error");
        return View(vm);
    }
    
    [HttpGet]
    public IActionResult Register(string returnUrl)
    {
        return View(new RegisterViewModel { ReturnUrl = returnUrl });
    }

    [HttpPost]
    public async Task<IActionResult> Register(RegisterViewModel vm)
    {
        if (!ModelState.IsValid) return View(vm);

        if (await _authService.SignUpAsync(vm)) return Redirect(vm.ReturnUrl);
        
        ModelState.AddModelError(string.Empty, "Error occurred");
        return View(vm);
    }
    
    [HttpGet]
    public async Task<IActionResult> Logout(string logoutId)
    {
        var postLogoutRedirectUri = await _authService.Logout(logoutId);
        return string.IsNullOrEmpty(postLogoutRedirectUri)
            ? RedirectToAction("Home", "Home", null)
            : Redirect(postLogoutRedirectUri);
    }
}