using ShortLink.Application.DTOs.Account;
using ShortLink.Application.Services.Interfaces;
using ShortLink.Domain.Entities.Account;
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

    #region account

    #region register


    public async Task<RegisterUserResult> RegisterUser(RegisterUserDto registerUser)
    {

        //check mobil exist
        if (! await _userRepository.IsExistMobile(registerUser.Mobile))
        {
            //Add User
            var user = new User
            {
                FirstName = registerUser.FirstName,
                LastName = registerUser.LastName,
                Mobile = registerUser.Mobile,   
                MobileActiveCode = new Random().Next(10000,99999).ToString(),
                CreateDate = DateTime.Now,
                LastUpdateDate = DateTime.Now,
            };

            //Add To DataBase
            await _userRepository.AddUser(user);
            await _userRepository.SaveChange();
            return RegisterUserResult.Success;
        }

        //Is Mobil Exist
        return RegisterUserResult.IsMobileExist;
    }


    #endregion



    #region login



    #endregion

    #endregion


}