using GamerShop.Controllers.Attributes;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace GamerShop.Services
{
    public class LayoutService 
    {
         static public ViewLayoutAttribute? GetLayoutName(ViewContext viewContext)
        {
            var currentController = viewContext.ActionDescriptor
                                    .GetType()
                                    .GetProperty("ControllerTypeInfo")?
                                    .GetValue(viewContext.ActionDescriptor);

            if (currentController != null)
            {
                return Attribute.GetCustomAttribute((Type)currentController,typeof(ViewLayoutAttribute)) as ViewLayoutAttribute;
            }

            return null;

        }
    }
}
