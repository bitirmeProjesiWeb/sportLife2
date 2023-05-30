namespace sportLife2.DbModel
{
    public class Rezervation:BaseEntity
    {
        public int UserId { get; set; }
        public int PitchId { get; set; }
        public int SessionId { get; set; }
        public string Date { get; set; }
    }
}
