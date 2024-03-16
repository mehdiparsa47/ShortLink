using Microsoft.Extensions.DependencyInjection;
using ShortLink.Application.Services.Implement;
using ShortLink.Application.Services.Interfaces;
using ShortLink.Domain.Interfaces;
using ShortLink.Infra.Data.Repositories;

namespace ShortLink.IoC;

public static class DependencyContainer
{
    public static void RegisterService(IServiceCollection services)
    {
        #region services

        services.AddScoped<IUserService, UserService>();


        #endregion

        #region repository


        services.AddScoped<IUserRepository, UserRepository>();

        #endregion

        #region tools

        services.AddScoped<IPasswordHelper, PasswordHelper>();

        #endregion
    }

}