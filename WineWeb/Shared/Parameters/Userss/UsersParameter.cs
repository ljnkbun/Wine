﻿using Core.Models.Parameters;

namespace WineWeb.Shared.Parameters.Userss
{
    public class UsersParameter : RequestParameter
    {
        public string? Username { get; set; }
        public string? Password { get; set; }
    }
}
