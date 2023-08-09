namespace GamerShop.Models
{
    public class Plants
    {
        private static int _nextId = 1;
        public int Id { get; set; }
        public string Name { get; set; }
        public Plants(string name)
        {
            Id = _nextId++;
            Name = name;
        }
    }
}
