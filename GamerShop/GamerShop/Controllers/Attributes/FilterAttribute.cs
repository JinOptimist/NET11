namespace GamerShop.Controllers.Attributes
{
    public class FilterAttribute : Attribute
    {
        public string Operation { get; set; }

        public FilterAttribute(string operation)
        {
            Operation = operation;
        }
    }
}
