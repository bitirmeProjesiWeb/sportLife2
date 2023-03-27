namespace sportLife2.DTOs
{
    public class RezervationCreateDTO
    {
        public int UserId { get; set; }
        public int PitchId { get; set; }
        public int SessionId { get; set; }
        public DateTime Date { get; set; }
    }
}
