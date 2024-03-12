using ShortLink.Application.Services.Interfaces;
using ShortLink.Domain.Interfaces;

namespace ShortLink.Application.Services.Implement;

public class UserService : IUserService
{
    #region ctor

    private readonly IUserRepository _userRepository;

    public UserService(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    #endregion
}