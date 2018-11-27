using System.Collections.Generic;

namespace Core.Models
{
    public class Manufacturer : EntityBase
    {
        public List<Model> Models { get; set; }
        public string Name { get; set; }
    }
}
