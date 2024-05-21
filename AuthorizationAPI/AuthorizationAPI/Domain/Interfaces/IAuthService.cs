using Domain.Models;

namespace Domain.Interfaces;

public interface IAuthService
{
    Task<bool> SignInAsync(LoginViewModel vm);
    Task<bool> SignUpAsync(RegisterViewModel vm);
    Task<string> Logout(string logoutId);
}