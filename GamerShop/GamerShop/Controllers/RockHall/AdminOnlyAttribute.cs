using GamerShop.Services;
using Microsoft.AspNetCore.Mvc.Filters;

namespace GamerShop.Controllers.RockHall
{
    public class AdminOnlyAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            var authService = context.HttpContext.RequestServices.GetService<IAuthService>();
            if(authService.GetCurrentUser().Name != "Admin")
            {
                context.HttpContext.Response.Redirect("IsNotAdmin");
            }
            base.OnActionExecuting(context);
        }
    }
}
