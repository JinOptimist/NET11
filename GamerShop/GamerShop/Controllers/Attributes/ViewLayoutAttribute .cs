namespace GamerShop.Controllers.Attributes
{
    public class ViewLayoutAttribute : Attribute
    {

        public ViewLayoutAttribute(string layoutName)
        {
            LayoutName = layoutName;
        }

        public string LayoutName { get; }
    }
}
