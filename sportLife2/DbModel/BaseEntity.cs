namespace sportLife2.DbModel
{
    public class BaseEntity
    {
        public int Id { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
        public Boolean IsActive { get; set; }

    }
}
