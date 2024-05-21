using Domain.Interfaces;
using Domain.Models;
using IdentityServer4.Services;
using Microsoft.AspNetCore.Identity;

namespace Application.Services;

public class AuthService(
        SignInManager<IdentityUser> signInManager,
        UserManager<IdentityUser> userManager,
        IIdentityServerInteractionService interactionService)
    : IAuthService
{
    public async Task<bool> SignInAsync(LoginViewModel vm)
    {
        var user = await userManager.FindByNameAsync(vm.Username);
        if (user == null) return false;

        var result = await signInManager.PasswordSignInAsync(vm.Username, vm.Password, false, false);

        return result.Succeeded;
    }

    public async Task<bool> SignUpAsync(RegisterViewModel vm)
    {
        var user = new IdentityUser(vm.Username);
        var result = await userManager.CreateAsync(user, vm.Password);
        
        if (!result.Succeeded) return false;
        
        await signInManager.SignInAsync(user, false);
        return true;
    }

    public async Task<string> Logout(string logoutId)
    {
        await signInManager.SignOutAsync();
        var logoutRequest = await interactionService.GetLogoutContextAsync(logoutId);
        return logoutRequest.PostLogoutRedirectUri;
    }
}