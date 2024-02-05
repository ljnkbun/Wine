using Core.Entities;

namespace WineWeb.Shared.Entities
{
    public class Category : BaseEntity
    {
        public string? Description { get; set; }
        public int? ParentId { get; set; }
        public int? Level { get; set; }
    }
}
