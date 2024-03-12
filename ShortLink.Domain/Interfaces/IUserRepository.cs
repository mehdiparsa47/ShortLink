using ShortLink.Domain.Entities.Account;

namespace ShortLink.Domain.Interfaces;

public interface IUserRepository: IAsyncDisposable
{
    Task AddUser(User  user);

    Task SaveChange();  
}       