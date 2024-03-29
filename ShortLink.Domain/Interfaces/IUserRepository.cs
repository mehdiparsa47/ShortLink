﻿using ShortLink.Domain.Entities.Account;

namespace ShortLink.Domain.Interfaces;

public interface IUserRepository: IAsyncDisposable
{
    Task AddUser(User  user);
    Task<bool> IsExistMobile(string  mobile);
    Task<User> GetUserByMobile(string mobile);
    Task SaveChange();  
}       