using System.Collections.Generic;

namespace Core.Models
{
    public class Model : EntityBase
    {
        public Manufacturer Manufacturer { get; set; }
        public int ManufacturerID { get; set; }
        public List<Vehicle> Vehicles { get; set; }
        public string Name { get; set; }
    }
}
