namespace Core.Models
{
    public class Color : EntityBase
    {
        protected Color() { }
        public Color(int id, string name)
        {
            ID = id;
            Name = name;
        }
        public string Name { get; set; }
    }
}
