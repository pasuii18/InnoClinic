using Application.Common.Models;

namespace Application.Common.Interfaces;

public interface IAuthService
{
    Task<Result.Result> SignInAsync(LoginViewModel vm);
    Task<Result.Result> SignUpAsync(RegisterViewModel vm);
    Task<string> Logout(string logoutId);
}