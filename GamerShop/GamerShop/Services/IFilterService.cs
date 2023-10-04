using System.Collections;
using System.Reflection;

namespace GamerShop.Services
{
    public interface IFilterService
    {
         IEnumerable GetAllFilters<T>(T model);
         string GetAttributeValue(PropertyInfo propertyInfo);
    }
}
