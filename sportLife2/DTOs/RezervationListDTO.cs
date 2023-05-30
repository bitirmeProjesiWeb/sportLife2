namespace sportLife2.DTOs
{
    public class RezervationListDTO
    {
        public int UserId { get; set; }
        public int PitchId { get; set; }
        public int SessionId { get; set; }
        public string Date { get; set; }
        public bool IsActive { get; set; }

    }
}
