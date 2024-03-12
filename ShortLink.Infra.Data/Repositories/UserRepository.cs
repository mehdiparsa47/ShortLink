using ShortLink.Domain.Interface;
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



    #region dispose
    public async ValueTask DisposeAsync()
    {
        if (_context != null) await _context.DisposeAsync();
    }
    #endregion


}