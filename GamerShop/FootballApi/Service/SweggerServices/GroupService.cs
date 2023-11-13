using FootballApi.Attributes;
using FootballApi.DatabaseStuff.Models;
using FootballApi.EndPoints;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using System.Runtime.CompilerServices;

namespace FootballApi.Service.SweggerServices
{
    public static class GroupService
    {
        public static string[] Rename(this ApiDescription api) 
        {
            var customName =  GetDisplayNameForSwagger(api.ActionDescriptor.RouteValues.First());

            return customName != null ? new[] { customName }: new[] { api.ActionDescriptor.RouteValues.First().Value };
        }
        
        private static string GetDisplayNameForSwagger(KeyValuePair<string,string> routeValues) 
        {
            var type = Type.GetType("FootballApi.EndPoints."+routeValues.Value);
            if (type == null)
            {
                return null;
            }
             var attr =  Attribute.GetCustomAttribute((Type)type, typeof(DisplayNameForSwagger)) as DisplayNameForSwagger;

            return attr != null ? attr.Name:null ;
        }
    }
}
