﻿using WineWeb.Shared.Entities;

namespace WineWeb.Shared.Services.Implements
{
    public class UsersRepository : IUsersRepository
    {
        public async Task<Users> Authen(string username, string password)
        {
            if (username == "admin" && password == "admin")
            {
                return new Users() { UserName = username, Password = password };
            }
            return null;
        }
    }
}
