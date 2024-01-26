namespace Core.Entities
{
    public class BaseModel
    {
        public int Id { get; set; }
        public bool IsDel { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public DateTime? CreateDate { get; set; }
        public int? CreateBy { get; set; }
        public DateTime? UpdateDate { get; set; }
        public int? UpdateBy { get; set; }
    }
}
