using Domain.Common.Interfaces;
using Domain.Common.Models;
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

        var result = await _authService.SignInAsync(vm);
        if (result.IsSuccess) return Redirect(vm.ReturnUrl);
        
        ModelState.AddModelError(string.Empty, result.Error.Description);
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

        var result = await _authService.SignUpAsync(vm);
        if (result.IsSuccess) return Redirect(vm.ReturnUrl);
        
        ModelState.AddModelError(string.Empty, result.Error.Description);
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