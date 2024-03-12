using ShortLink.Application.DTOs.Account;

namespace ShortLink.Application.Services.Interfaces;

public interface IUserService
{
    Task<RegisterUserResult> RegisterUser(RegisterUserDto registerUser);
}