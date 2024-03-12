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
