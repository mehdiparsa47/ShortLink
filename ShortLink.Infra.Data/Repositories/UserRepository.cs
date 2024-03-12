using Microsoft.EntityFrameworkCore;
using ShortLink.Domain.Entities.Account;
using ShortLink.Domain.Interfaces;
using ShortLink.Infra.Data.Context;

namespace ShortLink.Infra.Data.Repositories;

public class UserRepository : IUserRepository
{

    #region ctor

    private readonly ShortLinkDbContext _context;

    public UserRepository(ShortLinkDbContext context)
    {
        _context = context;
    }

    #endregion

    #region account

    public async Task AddUser(User user)
    { 
        await _context.Users.AddAsync(user);
    }

    public async Task<bool> IsExistMobile(string mobile)
    {
        return await _context.Users.AnyAsync(p => p.Mobile == mobile);
    }


    public async Task SaveChange()
    {
        await _context.SaveChangesAsync();
    }

    #endregion

    #region dispose
    public async ValueTask DisposeAsync()
    {
        if (_context != null) await _context.DisposeAsync();
    }
    #endregion


   
}