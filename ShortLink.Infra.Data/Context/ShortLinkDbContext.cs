using Microsoft.EntityFrameworkCore;

namespace ShortLink.Infra.Data.Context;

public class ShortLinkDbContext : DbContext
{
    public ShortLinkDbContext(DbContextOptions<ShortLinkDbContext> options): base(options)
    {
        
    }
}