using ShortLink.Application.DTOs.Account.LoginDto;
using ShortLink.Application.DTOs.Account.RegisterDto;

namespace ShortLink.Application.Services.Interfaces;

public interface IUserService
{
    Task<RegisterUserResult> RegisterUser(RegisterUserDto registerUser);
    Task<LoginUserResult> LoginUser(LoginUserDto loginUser);
}