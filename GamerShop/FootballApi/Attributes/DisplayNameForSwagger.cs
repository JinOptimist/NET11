namespace FootballApi.Attributes
{
    public class DisplayNameForSwagger:Attribute
    {
        public string Name { get; }
        public DisplayNameForSwagger(string name) 
        {
          Name = name;
        }
    }
}
