using Microsoft.AspNetCore.Mvc;
using ShortLink.Application.DTOs.Account.LoginDto;
using ShortLink.Application.DTOs.Account.RegisterDto;
using ShortLink.Application.Services.Interfaces;

namespace ShortLink.Wab.Controllers
{
    public class AccountController : SiteBaseController
    {
        #region ctor
        private readonly IUserService _userService;

        public AccountController(IUserService userService)
        {
            _userService = userService;
        }

        #endregion

        #region register

        [HttpGet("register")]
        public async Task<IActionResult> Register()
        {
            return View();
        }

        [HttpPost("register"),ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegisterUserDto registerUser)
        {
            if (ModelState.IsValid)
            {
                var result = await _userService.RegisterUser(registerUser);

                switch (result)
                {
                    case RegisterUserResult.IsMobileExist:
                        TempData[ErrorMessage] = "تلفن همراه وارد شده تکراری میباشد";
                        ModelState.AddModelError("Mobile", "تلفن همراه وارد شده تکراری میباشد");
                        break;
                    case RegisterUserResult.Success:
                        TempData[SuccessMessage] = "ثبت نام با موفقیت انجام شد";
                        return Redirect("/");

                }
            }
            return View(registerUser);
        }

        #endregion

        #region login

        [HttpGet("login")]
        public async Task<IActionResult> Login()
        {
            return View();
        }


        [HttpPost("login"),ValidateAntiForgeryToken]
        public async Task<IActionResult> LoginUser(LoginUserDto loginUser)
        {
            if (ModelState.IsValid)
            {

            }
            return View(loginUser);
        }



        #endregion

        #region logout



        #endregion
    }
}
