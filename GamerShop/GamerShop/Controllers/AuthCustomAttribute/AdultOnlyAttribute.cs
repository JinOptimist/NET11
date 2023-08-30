using GamerShop.Services;
using Microsoft.AspNetCore.Mvc.Filters;

namespace GamerShop.Controllers.AuthCustomAttribute
{
    public class AdultOnlyAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            // BEFORE ACTION RUN
            var authService = context.HttpContext.RequestServices.GetService<IAuthService>();

            if (authService.GetCurrentUser().AgeInDays < 17)
            {
                context.HttpContext.Response.Redirect("/Auth/PageNotForChild");
                // DO NOT run next attribute
                return;
            }

            // Run Next Atttibute
            base.OnActionExecuting(context);
        }
    }
}
