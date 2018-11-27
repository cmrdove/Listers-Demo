namespace Core.Models
{
    public class Vehicle : EntityBase
    {
        public Color Color { get; set; }
        public int ColorID { get; set; }
        public string RegistrationNumber { get; set; }
        public Model Model { get; set; }
        public int ModelID { get; set; }
        public decimal Millage { get; set; }
        public decimal RetailPrice { get; set; }
    }
}
