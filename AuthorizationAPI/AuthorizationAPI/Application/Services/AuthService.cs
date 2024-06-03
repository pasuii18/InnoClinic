using Application.Common.Interfaces;
using Application.Common.Models;
using Application.Common.Result;
using Domain.Entities;
using IdentityServer4.Services;
using Microsoft.AspNetCore.Identity;

namespace Application.Services;

public class AuthService(
        SignInManager<User> signInManager,
        UserManager<User> userManager,
        IIdentityServerInteractionService interactionService)
    : IAuthService
{
    public async Task<Result> SignInAsync(LoginViewModel vm)
    {
        var user = await userManager.FindByEmailAsync(vm.Email);
        if (user == null) return Result.Failure(AuthErrors.IncorrectUserData);

        var result = await signInManager.PasswordSignInAsync(user, vm.Password, false, false);
        if(!result.Succeeded) return Result.Failure(AuthErrors.IncorrectUserData);

        return Result.Success();
    }

    public async Task<Result> SignUpAsync(RegisterViewModel vm)
    {
        if (!vm.Email.Contains('@')) return Result.Failure(AuthErrors.IncorrectEmail);
        
        var user = await userManager.FindByEmailAsync(vm.Email);
        if (user != null) return Result.Failure(AuthErrors.EmailAlreadyTaken);
        
        var newUser = new User { UserName = vm.Email, Email = vm.Email }; // prob fix someday
        var result = await userManager.CreateAsync(newUser, vm.Password);
        
        if (!result.Succeeded) return Result.Failure(AuthErrors.UndefinedError);
        
        await signInManager.SignInAsync(newUser, false);
        return Result.Success();
    }

    public async Task<string> Logout(string logoutId)
    {
        await signInManager.SignOutAsync();
        var logoutRequest = await interactionService.GetLogoutContextAsync(logoutId);
        return logoutRequest.PostLogoutRedirectUri;
    }
}