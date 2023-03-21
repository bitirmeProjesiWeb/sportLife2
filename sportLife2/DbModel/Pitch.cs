namespace sportLife2.DbModel
{
    public class Pitch:BaseEntity
    {
        public string Name { get; set; }
        public int AdminId { get; set; }
        public string Description { get; set; }
        public int Price { get; set; }
        public string City { get; set; }
        public string County { get; set; }
        public string Type { get; set; }
    }
}
