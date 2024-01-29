﻿using Core.Entities;

namespace WineWeb.Shared.Entities
{
    public class Location : BaseEntity
    {
        public int? ParentId { get; set; }
        public int? Level { get; set; }
    }
}
