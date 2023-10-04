using GamerShop.Controllers.Attributes;
using System.Collections;
using System.Reflection;

namespace GamerShop.Services
{
    public class FilterService : IFilterService
    {
        public IEnumerable GetAllFilters<T>(T model)
        => model
            .GetType()
            .GetProperties()
            .Where(x => Attribute.GetCustomAttribute(x, typeof(FilterAttribute)) as FilterAttribute != null)
            .Select(x => new
            {
                Name = x.Name,
                value = x.GetValue(model),
                Operation = GetAttributeValue(x),
                IsUse = false
            })
            .ToList();


        public string GetAttributeValue(PropertyInfo propertyInfo)
        {
            var filter = Attribute.GetCustomAttribute(propertyInfo, typeof(FilterAttribute)) as FilterAttribute;
            return filter.Operation;
        }
    }


}
