﻿using Core.Entities;

namespace WineWeb.Shared.Entities
{
    public class Users : BaseEntity
    {
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}
