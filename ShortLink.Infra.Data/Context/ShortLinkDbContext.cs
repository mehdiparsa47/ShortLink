using Microsoft.EntityFrameworkCore;
using ShortLink.Domain.Entities.Account;

namespace ShortLink.Infra.Data.Context;

public class ShortLinkDbContext : DbContext
{
    public ShortLinkDbContext(DbContextOptions<ShortLinkDbContext> options): base(options)
    {
        
    }


    #region account

    public DbSet<User> Users { get; set; }

    #endregion

    #region on model createing

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        foreach (var relation in modelBuilder.Model.GetEntityTypes().SelectMany(s=>s.GetForeignKeys()))
        {
            relation.DeleteBehavior = DeleteBehavior.Restrict;
        }
        base.OnModelCreating(modelBuilder);
    }

    #endregion
}