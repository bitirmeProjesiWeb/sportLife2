using System.ComponentModel;

namespace sportLife2.DTOs
{
    public class PitchUpdateDTO
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int Price { get; set; }
        public string City { get; set; }
        public string County { get; set; }
        public string Type { get; set; }
        public bool IsActive { get; set; }
    }
}
