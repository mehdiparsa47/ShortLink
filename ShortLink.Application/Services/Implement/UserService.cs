using ShortLink.Application.DTOs.Account.LoginDto;
using ShortLink.Application.DTOs.Account.RegisterDto;
using ShortLink.Application.Services.Interfaces;
using ShortLink.Domain.Entities.Account;
using ShortLink.Domain.Interfaces;

namespace ShortLink.Application.Services.Implement;

public class UserService : IUserService
{
    #region ctor

    private readonly IUserRepository _userRepository;
    private readonly IPasswordHelper _passwordHelper;

    public UserService(IUserRepository userRepository, IPasswordHelper passwordHelper)
    {
        _userRepository = userRepository;
        _passwordHelper = passwordHelper;
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
                Password = _passwordHelper.EncodePasswordMd5(registerUser.Password) ,
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

    public async Task<LoginUserResult> LoginUser(LoginUserDto loginUser)
    {
        var user = await _userRepository.GetUserByMobile(loginUser.Mobile);
        if (user == null) return LoginUserResult.NotFound;
        if (! user.IsMobileActive) return LoginUserResult.NotActivate;
        if (user.Password != _passwordHelper.EncodePasswordMd5(loginUser.Password)) return LoginUserResult.NotActivate;


        return LoginUserResult.Success;

    }

    #region login



    #endregion

    #endregion


}